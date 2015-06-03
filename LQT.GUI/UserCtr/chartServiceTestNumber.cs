
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
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

namespace LQT.GUI.UserCtr
{
    public partial class chartServiceTestNumber : LQT.GUI.UserCtr.BaseUserControl
    {
        private CD4TestNumber _cd;
        private int _ForecastId;
        private SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
        private DataSet _dataSet;
        private decimal _total;
        private int _siteorCatId;
        private int _typeId;
        private string _chartTitle;

        public chartServiceTestNumber()
        {
            InitializeComponent();
        }

        public chartServiceTestNumber(int _forecastId, int siteorcatid, int typeId)
        {
            _ForecastId = _forecastId;
            _siteorCatId = siteorcatid;
            _typeId = typeId;

            InitializeComponent();
        }

        private void chartServiceTestNumber_Load(object sender, EventArgs e)
        {
            chart1.Series["Series2"].Points.Clear();
            
            GetSummary();

            DataView dv = new DataView(_dataSet.Tables[0]);
          
            foreach (DataRowView rowView in dv)
            {
                DataRow row = rowView.Row;
                _total = _total + (decimal)row["NoofTest"];
            }
        
            for (int i=0;i<dv.Count;i++)
            {
             decimal percentage= decimal.Round(((decimal)dv[i]["NoofTest"]), 4, MidpointRounding.AwayFromZero);
             dv[i]["percentage"] = percentage;
            }

            chart1.Series["Series2"].LegendText ="#VALX , #VALY , (#PERCENT)";
            chart1.Series["Series2"].Points.DataBindXY(dv, "AreaName", dv, "percentage");
            chart1.Series["Series2"].IsValueShownAsLabel = false;
            chart1.Series["Series2"]["PieLabelStyle"] = "Disabled";
            chart1.Titles[0].Text = _chartTitle;
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
                    cmd.CommandText = "spConsumptionForecastSummary";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@siteid", SqlDbType.Int).Value = _siteorCatId;
                    cmd.Parameters.Add("@protypeid", SqlDbType.Int).Value = _typeId;
                    _dataSet = new DataSet("spConsumptionForecastSummary");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spConsumptionForecastSummary");
                    _chartTitle = "Consumption Statistics Product Usage By Product Type";
                }
                else
                {
                    //service site
                    cmd.CommandText = "spServiceNoofTest";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@siteid", SqlDbType.Int).Value = _siteorCatId;
                    cmd.Parameters.Add("@testareaId", SqlDbType.Int).Value = _typeId;
                    _dataSet = new DataSet("spServiceNoofTest");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spServiceNoofTest");
                    _chartTitle = "Service Statistics Test By TestingArea";
                }
            }
            else
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    //consumption category
                    cmd.CommandText = "spConsumptionForecastSummary";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@catid", SqlDbType.Int).Value = _siteorCatId;
                    cmd.Parameters.Add("@protypeid", SqlDbType.Int).Value = _typeId;
                    _dataSet = new DataSet("spConsumptionForecastSummary");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spConsumptionForecastSummary");
                    _chartTitle = "Consumption Statistics Product Usage By Product Type";
                }
                else
                {
                    //service category

                    cmd.CommandText = "spServiceNoofTest";
                    cmd.Parameters.Add("@forecastid", SqlDbType.Int).Value = _ForecastId;
                    cmd.Parameters.Add("@catid", SqlDbType.Int).Value = _siteorCatId;
                    cmd.Parameters.Add("@testareaId", SqlDbType.Int).Value = _typeId;
                    _dataSet = new DataSet("spServiceNoofTest");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(_dataSet, "spServiceNoofTest");
                    _chartTitle = "Service Statistics Test By TestingArea";
                }
            }
            return _dataSet;
        }
    }
}
