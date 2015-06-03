
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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Util;
using LQT.Core.Domain;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using LQT.Core;
using LQT.GUI.Reports;
using Microsoft.Reporting.WinForms;

namespace LQT.GUI.ReportParameterUserCtr
{
    public partial class MorbidityCostSReportParam : LQT.GUI.ReportParameterUserCtr.RptBaseUserControl
    {
        public int  DforecastId = 0;
        public int _siteid = 0;

        public MorbidityCostSReportParam()
        {
            InitializeComponent();

            comMethodologey.Items.AddRange(Enum.GetNames(typeof(MethodologyEnum)));
            comMethodologey.Items.Insert(0, "< Select Option >");
            comMethodologey.SelectedIndex = 0;

            PopForecastInfo();
           // popsite();
        }

        private void PopForecastInfo()
        {

            IList ServiceForecastInfo = DataRepository.GetForecastInfoByMethodology(comMethodologey.Text).ToList();
            ReportRepository.AddItem(ServiceForecastInfo, typeof(ForecastInfo), "Id", "ForecastNo", "< Select Option >");
            cobserviceorconsumption.DataSource = ServiceForecastInfo;

            

            IList demographyForecastInfo = DataRepository.GetAllMorbidityForecast().ToList();
            ReportRepository.AddItem(demographyForecastInfo, typeof(MorbidityForecast), "Id", "Title", "< Select Option >");
            cobdemography.DataSource = demographyForecastInfo;

           
        }

        //public void popsite()
        //{
        //    IList<ForlabSite> sites= DataRepository.GetAllSite();

        //    cobSite.DataSource = sites;
        //}

        public override string GetControlTitle
        {
            get
            {
                return "Forecast Summary Report";
            }
        }

        private void btnviewreport_Click(object sender, EventArgs e)
        {

            if (comMethodologey.Text == MethodologyEnum.SERVICE_STATISTIC.ToString() || comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
            {
                
                ReportParameter finfoparam = new ReportParameter("forecastid",DforecastId.ToString());
                param.Add(finfoparam);
                ReportParameter siteid = new ReportParameter("siteid", "0");
                param.Add(siteid);
                ReportParameter catid = new ReportParameter("catid", "0");
                param.Add(catid);
                ReportParameter protypeid = new ReportParameter("protypeid", "0");
                param.Add(protypeid);

                if (comMethodologey.Text == MethodologyEnum.SERVICE_STATISTIC.ToString())
                {
                    ReportParameter testareaId = new ReportParameter("testareaId", "0");
                    param.Add(testareaId);
                }
            }
            else
            {
                ReportParameter pDForecastId = new ReportParameter("ForecastId", DforecastId.ToString());
                param.Add(pDForecastId);
                SqlParameter rpMForecastId = new SqlParameter();
                rpMForecastId.ParameterName = "ForecastId";
                rpMForecastId.Value = DforecastId;
                sqlParams.Clear();
                sqlParams.Add(rpMForecastId);
            }
            
            DataSet _rDataSet = new DataSet();
            if (comMethodologey.Text == MethodologyEnum.DEMOGRAPHIC.ToString())
            {
                 _rDataSet = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spMorbiditySupplyProcuremnetForecast");
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.Dforcastcostsummary)));

                FrmReportViewer frmRV = new FrmReportViewer(filinfo, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            else if (comMethodologey.Text == MethodologyEnum.SERVICE_STATISTIC.ToString() || comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
            {
                FrmReportViewer frm = new FrmReportViewer();

                if (comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
                {
                    filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptConsumptionCostSummary)));
                     frm = new FrmReportViewer(filinfo,FillFinfoReportDataSet(), FillDetailReportDataSet(), param);
                }
                else
                {
                    filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptServiceCostSummary)));
                     frm = new FrmReportViewer(filinfo, FillReportDataSet(), FillFinfoReportDataSet(), FillDetailReportDataSet(), FillServiceDetailReportDataSet(), param);
                }

               
                frm.ShowDialog();
            }

            
        }

        private void comMethodologey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comMethodologey.Text == MethodologyEnum.DEMOGRAPHIC.ToString())
            {
                cobserviceorconsumption.Visible = false;
                cobdemography.Visible = true;
            }
            else if (comMethodologey.Text == MethodologyEnum.SERVICE_STATISTIC.ToString() || comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
            {
                cobserviceorconsumption.Visible = true;
                cobdemography.Visible = false;
            }
            else
            {
                cobserviceorconsumption.Visible = false;
                cobdemography.Visible = false;
            }

            PopForecastInfo();

        }

        private DataSet FillFinfoReportDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spForecastInfo";

            cmd.Parameters.AddWithValue("@fid",DforecastId);
            DataSet _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spForecastInfo");
            return _rDataSet;

        }

        private DataSet FillReportDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
            {
                cmd.CommandText = "spConsumptionTotalSummary";
            }
            else
            {
                cmd.CommandText = "spServiceTotalSummary";
            }
            cmd.CommandTimeout = 300000;
            cmd.Parameters.AddWithValue("@forecastid", DforecastId);
            cmd.Parameters.AddWithValue("@siteid", 0);
            cmd.Parameters.AddWithValue("@catid", 0);
            DataSet _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
                da.Fill(_rDataSet, "spConsumptionTotalSummary");
            else
                da.Fill(_rDataSet, "spServiceTotalSummary");

            return _rDataSet;

        }

        private DataSet FillDetailReportDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
            {
                cmd.CommandText = "spConsumptionForecastbytypeandduration";
                cmd.Parameters.AddWithValue("@protypeid", 0);
            }
            else
            {
                cmd.CommandText = "spServiceForecastTestbytypeandduration";
                cmd.Parameters.AddWithValue("@testareaId", 0);
            }
            cmd.CommandTimeout = 300000;
            cmd.Parameters.AddWithValue("@forecastid",DforecastId);
            cmd.Parameters.AddWithValue("@siteid",_siteid);//off
            cmd.Parameters.AddWithValue("@catid", 0);
            DataSet _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (comMethodologey.Text == MethodologyEnum.CONSUMPTION.ToString())
                da.Fill(_rDataSet, "spConsumptionForecastbytypeandduration");
            else
                da.Fill(_rDataSet, "spServiceForecastTestbytypeandduration");

            return _rDataSet;
        }

        private DataSet FillServiceDetailReportDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spServiceForecastProductbytypeandduration";

            cmd.Parameters.AddWithValue("@protypeid", 0);

            cmd.CommandTimeout = 300000;
            cmd.Parameters.AddWithValue("@forecastid", DforecastId);
            cmd.Parameters.AddWithValue("@siteid", _siteid);//off
            cmd.Parameters.AddWithValue("@catid", 0);
            DataSet _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spServiceForecastProductbytypeandduration");


            return _rDataSet;
        }

        private void cobserviceorconsumption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobserviceorconsumption.SelectedValue.ToString() != "-1")
                DforecastId = int.Parse(cobserviceorconsumption.SelectedValue.ToString());
        }

        private void cobdemography_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobdemography.SelectedValue.ToString() != "-1")
                DforecastId = int.Parse(cobdemography.SelectedValue.ToString());
        }

        //off
        private void cobSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            _siteid = int.Parse(cobSite.SelectedValue.ToString());
        }

        
    }
}
