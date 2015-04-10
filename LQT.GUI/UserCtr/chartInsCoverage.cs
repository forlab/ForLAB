
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
    public partial class chartInsCoverage : LQT.GUI.UserCtr.BaseUserControl
    {
      
        private int _ForecastId;
        private SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
        private DataSet _dataSet;
        private ForecastInfo _finfo;
        private string _title;
        private int _siteorcatid=0;

        public chartInsCoverage()
        {
            InitializeComponent();
        }

        public chartInsCoverage(int forecastId, int siteorcatid)
        {
            _ForecastId = forecastId;
            _siteorcatid = siteorcatid;
            InitializeComponent();

            cobtestingarea.Items.AddRange(Enum.GetNames(typeof(TestingAreaEnum)));
            cobtestingarea.Items.Insert(0, "--Select Here--");
            cobtestingarea.SelectedIndex = 0;
        }

        private void chartSandCForecast_Load(object sender, EventArgs e)
        {
            _finfo = DataRepository.GetForecastInfoById(_ForecastId);
            if (cobtestingarea.SelectedIndex>0)
                BindDataToChart();
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
                    cmd.Parameters.Add("@TestingArea", SqlDbType.NVarChar).Value =cobtestingarea.Text;
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

                    _title = cobtestingarea.Text + " Instrument Coverage";
                }
            }
            return _dataSet;
        }

        private void BindDataToChart()
        {
            GetChartData();

            chart2.Series["Coverage"].Points.Clear();
           
            chart2.Titles[0].Text = "";

            if (_finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
                {
                    int totalsum = 0;
                     DataView dv = new DataView(_dataSet.Tables[0]);
                     
                     foreach (DataRow dr in _dataSet.Tables[0].Rows)
                     {
                         totalsum = totalsum + Convert.ToInt32(dr["Qty"]);
                     }
                     foreach (DataRow dr in _dataSet.Tables[0].Rows)
                     {
                         chart2.Series["Coverage"].Points.AddXY(dr["InstrumentName"].ToString(),Convert.ToDecimal(dr["Qty"])/totalsum);
                     }

                }
               
            }

            chart2.Titles[0].Text = _title;
            chart2.Invalidate();
          
          
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private void cobtestingarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobtestingarea.SelectedIndex > 0)
                BindDataToChart();
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
    }
}
