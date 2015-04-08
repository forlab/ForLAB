
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
    public partial class chartFoercastResultDashboard : LQT.GUI.UserCtr.BaseUserControl
    {
        private CD4TestNumber _cd;
        private int _ForecastId;
        private SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
        private DataSet _dataSet;
        private decimal _total;
        private int _siteorCatId;
        private IList<ForecastSummaryData> _fSummaryData;
        private int _typeId;

        public chartFoercastResultDashboard()
        {
            InitializeComponent();
           
        }


        public chartFoercastResultDashboard(int _forecastId, int siteorcatid)
        {
            InitializeComponent();
            _ForecastId = _forecastId;
            _siteorCatId = siteorcatid;
           // _typeId = typeId;
            PopulateCostSummaryChart();
            PoplateCostSummaryTrendChart();
        }

        public void PopulateCostSummaryChart()
        {
            chart1.Series["Series2"].Points.Clear();

            GetSummary();

            DataView dv = new DataView(_dataSet.Tables[0]);

            foreach (DataRowView rowView in dv)
            {
                DataRow row = rowView.Row;
                _total = _total + (decimal)row["TotalPrice"];
            }

            for (int i = 0; i < dv.Count; i++)
            {
                decimal percentage = decimal.Round(((decimal)dv[i]["TotalPrice"]), 4, MidpointRounding.AwayFromZero);
                dv[i]["percentage"] = percentage;
            }
            // $#VALY , 
            chart1.Series["Series2"].Label = "(#PERCENT)";
            chart1.Series["Series2"].Points.DataBindXY(dv, "ProductType", dv, "percentage");
            chart1.Series["Series2"].LegendText = "#VALX ,(#PERCENT)";
            lbltotalcost.Text = String.Format("{0:C}", _total);
            
        }

        private DataSet GetSummary()
        {
            ForecastInfo _finfo = DataRepository.GetForecastInfoById(_ForecastId);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            if (_finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    //consumption site
                    cmd.CommandText = "spConsumptionPriceSummary";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@siteid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spConsumptionPriceSummary");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spConsumptionPriceSummary");
                    // _chartTitle = "Consumption Statistics Total Cost By Product Type";
                }
                else
                {
                    //service site
                    cmd.CommandText = "spServicePriceSummary";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@siteid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spServicePriceSummary");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spServicePriceSummary");
                    //_chartTitle = "Service Statistics Total Cost By Product Type";
                }
            }
            else
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    //consumption category
                    cmd.CommandText = "spConsumptionPriceSummary";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@catid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spConsumptionPriceSummary");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spConsumptionPriceSummary");
                    // _chartTitle = "Consumption Statistics Total Cost By Product Type";
                }
                else
                {
                    //service category

                    cmd.CommandText = "spServicePriceSummary";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@catid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spServicePriceSummary");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spServicePriceSummary");
                    //_chartTitle = "Service Statistics Total Cost By Product Type";
                }
            }
            return _dataSet;
        }

        private DataSet GetDurationSummary()
        {
            ///
            ForecastInfo _finfo = DataRepository.GetForecastInfoById(_ForecastId);
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            if (_finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    //consumption site
                    cmd.CommandText = "spConsumptionPriceSummarybyDuration";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@siteid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spConsumptionPriceSummarybyDuration");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spConsumptionPriceSummarybyDuration");
                  
                }
                else
                {
                    //service site
                    cmd.CommandText = "spServicePriceSummarybyDuration";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@siteid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spServicePriceSummarybyDuration");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spServicePriceSummarybyDuration");
                  
                }
            }
            else
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    //consumption category
                    cmd.CommandText = "spConsumptionPriceSummarybyDuration";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@catid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spConsumptionPriceSummarybyDuration");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spConsumptionPriceSummarybyDuration");
                  
                }
                else
                {
                    //service category

                    cmd.CommandText = "spServicePriceSummarybyDuration";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@catid", SqlDbType.Int).Value = _siteorCatId;
                    _dataSet = new DataSet("spServicePriceSummarybyDuration");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spServicePriceSummarybyDuration");
                  

                }
            }
            return _dataSet;
        }

        public void PoplateCostSummaryTrendChart()
        {
            GetDurationSummary();
            GetForecastSummaryData(_dataSet);

            lqtChart2.Series.Clear();


            IList<string> UniqueTestingAreas = new List<string>();
            foreach (ForecastSummaryData fsd in _fSummaryData)
            {
                if (!UniqueTestingAreas.Contains(fsd.TestingArea))
                    UniqueTestingAreas.Add(fsd.TestingArea);
            }
            foreach (string ta in UniqueTestingAreas)
            {
                Series series = new Series(ta);
                series.ChartType = SeriesChartType.Line;

                lqtChart2.Series.Add(series);

                IList<ForecastSummaryData> currentSummary = GetForecastSummaryByTA(ta);
                foreach (ForecastSummaryData fsd in currentSummary)
                {
                    lqtChart2.Series[ta].Points.AddXY(fsd.DurationDateTime, fsd.NoOfTest);
                }
            }
        }

        private IList<ForecastSummaryData> GetForecastSummaryData(DataSet ds)
        {
            int rowno = 0;
            _fSummaryData = new List<ForecastSummaryData>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rowno++;
                ForecastSummaryData rd = new ForecastSummaryData(Convert.ToDecimal(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2]), Convert.ToDateTime(dr[3]));
                _fSummaryData.Add(rd);
            }
            return _fSummaryData;
        }

        private IList<ForecastSummaryData> GetForecastSummaryByTA(string testingArea)
        {
            IList<ForecastSummaryData> FSummaryByTA = new List<ForecastSummaryData>();
            foreach (ForecastSummaryData fsd in _fSummaryData)
            {
                if (fsd.TestingArea == testingArea)
                    FSummaryByTA.Add(fsd);
            }
            return FSummaryByTA;
        }
    }
}
