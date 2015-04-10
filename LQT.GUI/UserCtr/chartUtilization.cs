
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace LQT.GUI.UserCtr
{
    public partial class chartUtilization : LQT.GUI.UserCtr.BaseUserControl
    {

        private int _ForecastId;
        private SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
        private DataSet _dataSet;
        private ForecastInfo _finfo;
        private string _title;
        private int _siteorcatid = 0;
        private string _testingArea = string.Empty;

        public chartUtilization()
        {
            InitializeComponent();
        }

        public chartUtilization(int forecastId, int siteorcatid)
        {
            _ForecastId = forecastId;
            _siteorcatid = siteorcatid;
            InitializeComponent();
            _finfo = DataRepository.GetForecastInfoById(_ForecastId);
            BindTestingArea();
        }

        public void BindTestingArea()
        {
            try
            {
                IList<TestingArea> tal = DataRepository.GetAllTestingArea();

                TestingArea ta = new TestingArea();
                ta.Id = 0;
                ta.AreaName = "--Select Here--";
                tal.Insert(0, ta);

                
                cobtestingarea.DataSource = tal;
                cobtestingarea.DisplayMember = "AreaName";
                cobtestingarea.ValueMember = "Id";
            }
            catch (Exception ex)
            {
            }
        }

        private void chartSandCForecast_Load(object sender, EventArgs e)
        {
           // _finfo = DataRepository.GetForecastInfoById(_ForecastId);
            // if (cobtestingarea.SelectedIndex>0)
           // BindDataToChart();
        }

        private DataSet GetChartData()
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            if (_finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
                {
                    if (_siteorcatid > 0)
                    {
                        cmd.CommandText = "spSiteLevelContribandUtil";
                        cmd.Parameters.Add("@SiteId", SqlDbType.Int).Value = _siteorcatid;
                    }
                    else
                    {
                        cmd.CommandText = "spContribandUtil";

                    }

                    cmd.Parameters.Add("@ForecastId", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@TestingArea", SqlDbType.NVarChar).Value = _testingArea;
                    if (_siteorcatid > 0)
                    {
                        _dataSet = new DataSet("spSiteLevelContribandUtil");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(_dataSet, "spSiteLevelContribandUtil");
                    }
                    else
                    {
                        _dataSet = new DataSet("spContribandUtil");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(_dataSet, "spContribandUtil");
                    }

                    _title = " Forecasted Service ";
                }
            }
            return _dataSet;
        }

        private void BindDataToChart()
        {
            IList<Instrument> _instList = new List<Instrument>();
            GetChartData();

            chart2.Series["Contribution"].Points.Clear();
            chart2.Series["Utilization"].Points.Clear();
            chart2.Series["Coverage"].Points.Clear();
            chart2.Titles[0].Text = "";

            if (_finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
                {
                    DataView dv = new DataView(_dataSet.Tables[0]);
                    //coverage
                    int totalsum = 0;
                    List<InstrumentPerTA> listofITA = new List<InstrumentPerTA>();
                    bool isinthelist = false;
                    foreach (DataRow dr in _dataSet.Tables[0].Rows)
                    {
                        foreach (TestingArea ta in DataRepository.GetAllTestingArea())
                        {
                            if (ta.AreaName == Convert.ToString(dr["TestingArea"]))
                            {
                                //add instruments
                                Instrument ins = DataRepository.GetInstrumentByName(Convert.ToString(dr["InstrumentName"]));
                                _instList.Add(ins);

                                foreach (InstrumentPerTA a in listofITA)
                                {
                                    if (a.TestingArea == ta)
                                    {
                                        isinthelist = true;
                                        break;
                                    }
                                    else
                                    {
                                        isinthelist = false;
                                        break;
                                    }
                                }
                                if (!isinthelist)
                                {
                                    InstrumentPerTA IPTA = new InstrumentPerTA();
                                    IPTA.TestingArea = ta;
                                    IPTA.TotalTestDone = 0;//added jan 17
                                    listofITA.Add(IPTA);

                                }
                                foreach (InstrumentPerTA ia in listofITA)
                                {
                                    if (ia.TestingArea.AreaName == Convert.ToString(dr["TestingArea"]))
                                    {
                                        ia.Quantity = ia.Quantity + Convert.ToInt32(dr["Qty"]);
                                        ia.TotalTestDone = ia.TotalTestDone + Convert.ToDecimal(dr["TestsDone"]); //added jan 17
                                    }
                                }
                            }
                            //totalsum = totalsum + Convert.ToInt32(dr["Qty"]);
                        }
                    }

                    //bind instrument to list box
                    Instrument instrument = new Instrument();
                    instrument.Id = 0;
                    instrument.InstrumentName = "--All--";
                    _instList.Insert(0,instrument);
                    lstInstrument.DataSource = _instList;
                    lstInstrument.DisplayMember = "InstrumentName";
                    lstInstrument.ValueMember = "Id";
                    
                    foreach (DataRow dr in _dataSet.Tables[0].Rows)
                    {
                        if(isSelectedInstrument(dr["InstrumentName"].ToString()))
                        {
                        decimal c = 0;
                        foreach (InstrumentPerTA a in listofITA)
                        {
                            if (a.TestingArea.AreaName == Convert.ToString(dr["TestingArea"]))
                            {
                                totalsum = a.Quantity;
                                c = (Convert.ToDecimal(Convert.ToDecimal(dr["TestsDone"]))) * 100 / a.TotalTestDone;
                                break;
                            }
                        }
                        decimal coverage = 0;
                        if (totalsum != 0)
                            coverage = Convert.ToDecimal(dr["Qty"]) / totalsum;

                        chart2.Series["Contribution"].Points.AddXY(dr["InstrumentName"].ToString(), c / 100);
                        // chart2.Series["Contribution"].LegendText = "Dx Contribution";

                        chart2.Series["Coverage"].Points.AddXY(dr["InstrumentName"].ToString(), coverage);
                        chart2.Series["Coverage"].LegendText = "Instrument Distribution";
                        }
                    }
                    //end coverage
                    // chart2.Series["Contribution"].Points.DataBindXY(dv, "InstrumentName", dv, "Contribution");
                    chart2.Series["Utilization"].Points.DataBindXY(dv, "InstrumentName", dv, "Utilization");
                    chart2.Series["Contribution"].LegendText = "Dx Contribution";
                    chart2.Series["Utilization"].LegendText = "Instrument Utilization";
                }
            }

            chart2.Titles[0].Text = _title;
            chart2.Invalidate();
        }

        public bool isSelectedInstrument(string InstrumentName)
        {
            foreach (object item in lstInstrument.CheckedItems)
            {
                Instrument i = (Instrument)item;
                if (i.InstrumentName == InstrumentName)
                    return true;
            }
            return false;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private void chkshowvalues_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Series s in chart2.Series)
            {
                s.IsValueShownAsLabel = chkshowvalues.Checked;
                s.LabelFormat = "P";
            }
            chart2.Invalidate();
        }

        private void cobtestingarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cobtestingarea.DisplayMember = "AreaName";
            cobtestingarea.ValueMember = "Id";

            if (cobtestingarea.Text == "--Select Here--")
                _testingArea = string.Empty;
            else
            {
                if (LqtUtil.GetComboBoxValue<TestingArea>(cobtestingarea) != null)
                {
                    _testingArea = LqtUtil.GetComboBoxValue<TestingArea>(cobtestingarea).AreaName;
                }
                else
                    _testingArea = string.Empty; 
            }
            BindDataToChart();
        }

        private void lstInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart2.Series["Contribution"].Points.Clear();
            chart2.Series["Utilization"].Points.Clear();
            chart2.Series["Coverage"].Points.Clear();
            BindDataToChart();
            chart2.Invalidate();
        }

      
    }
}
