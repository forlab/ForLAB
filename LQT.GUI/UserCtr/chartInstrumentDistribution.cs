
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
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
    public partial class chartInstrumentDistribution : LQT.GUI.UserCtr.BaseUserControl
    {      
      
        private SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
        private DataSet _dataSet;
        private ForlabRegion _selectedRegion;
        private string _title;
        private int _regionId = 0;
    
        public chartInstrumentDistribution()
        {
            InitializeComponent();
            PopRegion();
        }

        private void PopRegion()
        {
            try
            {
                IList<ForlabRegion> regions = DataRepository.GetAllRegion();

                ForlabRegion region = new ForlabRegion();
                region.Id = 0;
                region.RegionName = "--Select Region Here--";
                regions.Insert(0,region);

                comregion.DataSource = regions;
            }
            catch(Exception ex)
            {
            }
           
        }

        private void chartSandCForecast_Load(object sender, EventArgs e)
        {
            
                BindDataToChart();
        }

        private DataSet GetChartData()
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spInstrumentDistribution";
            cmd.Parameters.Add("@regionId", SqlDbType.Int).Value = _regionId;

            _dataSet = new DataSet("spInstrumentDistribution");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(_dataSet, "spInstrumentDistribution");
                    _title = " Instrument Distribution ";

               
            return _dataSet;
        }

        private void BindDataToChart()
        {
            GetChartData();

         
            chart2.Series["Coverage"].Points.Clear();

           

            chart2.Titles[0].Text = "";

          
                    DataView dv = new DataView(_dataSet.Tables[0]);
                    //coverage
                    int totalsum = 0;
                    List<InstrumentPerTA> listofITA = new List<InstrumentPerTA>();
                    bool isinthelist = false;
                    foreach (DataRow dr in _dataSet.Tables[0].Rows)
                    {
                        foreach (TestingArea ta in DataRepository.GetAllTestingArea())
                        {
                            if (ta.AreaName == Convert.ToString(dr["AreaName"]))
                            {
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
                                    listofITA.Add(IPTA);
                                }
                                foreach (InstrumentPerTA ia in listofITA)
                                {
                                    if (ia.TestingArea.AreaName == Convert.ToString(dr["AreaName"]))
                                    {
                                        ia.Quantity = ia.Quantity + Convert.ToInt32(dr["Qty"]);
                                    }
                                }
                            }
                            //totalsum = totalsum + Convert.ToInt32(dr["Qty"]);
                        }
                    }
                    foreach (DataRow dr in _dataSet.Tables[0].Rows)
                    {
                        
                        foreach (InstrumentPerTA a in listofITA)
                        {
                            if (a.TestingArea.AreaName == Convert.ToString(dr["AreaName"]))
                            {
                                totalsum = a.Quantity;
                                break;
                            }
                        }
                        decimal coverage = 0;
                        if (totalsum != 0)
                            coverage = Convert.ToDecimal(dr["Qty"]) / totalsum;

                            chart2.Series["Coverage"].Points.AddXY(dr["InstrumentName"].ToString(), coverage);
                            chart2.Series["Coverage"].LegendText = "Instrument Distribution";
                    }

                    chart2.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
                    chart2.ChartAreas[0].AxisX.IsLabelAutoFit = true;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                    chart2.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                   // chart2.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                    chart2.ChartAreas[0].AxisX.LabelStyle.TruncatedLabels = true;

           
            
                    //end coverage
                    
                 

            chart2.Titles[0].Text = _title;
            chart2.Invalidate();
          
          
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private void chkshowvalues_CheckedChanged(object sender, EventArgs e)
        {
            foreach(Series s in chart2.Series)
            {
                s.IsValueShownAsLabel = chkshowvalues.Checked;
                s.LabelFormat = "P";
            }
            chart2.Invalidate();
        }

        private void comregion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comregion.Text == "--Select Region Here--")
                _regionId = 0;
            else
            {
                if (LqtUtil.GetComboBoxValue<ForlabRegion>(comregion) != null)
                {
                    _selectedRegion = LqtUtil.GetComboBoxValue<ForlabRegion>(comregion);
                    _regionId = _selectedRegion.Id;
                }
                else
                    _regionId = 0;
            }
            BindDataToChart();
        }
    }
}
