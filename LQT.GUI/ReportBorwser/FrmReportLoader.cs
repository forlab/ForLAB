
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
using System.Windows.Forms;
using System.IO;
using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using System.Data.SqlClient;
using LQT.Core;
using Microsoft.Reporting.WinForms;

namespace LQT.GUI.Reports
{
    public partial class FrmReportLoader : Form
    {
        private FileInfo _fileToLoad;
        private OReports _Report;
        private string _reportLabel;
        private SortedList<string, object> _parameters;
        private DataSet _rDataSet;
        private bool _load=false;
        private ForecastInfo _finfo;
        private MorbidityForecast _mforecast;
        private DataSet _rDataSet2;
        

        public FrmReportLoader(FileInfo pFile, string pReportLabel, OReports pReport)
            : this(pFile, pReportLabel, pReport, null)
        {
            InitializeComponent();
            PopForecastInfo();
        }

        public FrmReportLoader(FileInfo pFile, string pReportLabel, OReports pReport, SortedList<string, object> parameters)
        {
            InitializeComponent();
            _fileToLoad = pFile;
            _Report = pReport;
            _reportLabel = pReportLabel;
            _parameters = parameters;
            //PopForecastInfo();
        }

        public FrmReportLoader()
        {

            InitializeComponent();
            comMethodologey.Items.AddRange(Enum.GetNames(typeof(MethodologyEnum)));
            comMethodologey.Items.Insert(0, "--Select Methodology--");
            comMethodologey.SelectedIndex = 0;

            PopForecastInfo();
        }

        private void PopForecastInfo()
        {
            if (comMethodologey.Text == MethodologyEnum.DEMOGRAPHIC.ToString())
            {

                cbomforecast.DataSource = DataRepository.GetAllMorbidityForecast();
                pnlreport.Visible = true;
                pnlreport.BringToFront();
            }
            else//if (comMethodologey.Text != "--All--")
            {
                pnlreport.Visible = false;
                pnlreport.SendToBack();
               
                    comForecastinfo.DataSource = DataRepository.GetForecastInfoByMethodology(comMethodologey.Text);
            }
            //else
              //  comForecastinfo.DataSource = DataRepository.GetAllForecastInfo();

           
        }

        private void buttonLaunchReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (comMethodologey.Text == MethodologyEnum.DEMOGRAPHIC.ToString())
                {
                    _mforecast = LqtUtil.GetComboBoxValue<MorbidityForecast>(cbomforecast);
                    LoadReport(cboreport.SelectedIndex);
                }
                else
                {
                    FileInfo filinfo = null;

                    _finfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
                    List<ReportParameter> param = new List<ReportParameter>();
                    ReportParameter finfo = new ReportParameter("ForecastId", _finfo.Id.ToString());
                    param.Add(finfo);


                    FillReportDataSet();


                    if (rdosite.Checked)
                        filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.ServiceQSummary)));
                    else
                        filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.FullQSummary)));


                    _fileToLoad = filinfo;


                    FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);



                    frmRV.Dock = DockStyle.Fill;
                    Close();
                    frmRV.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new FrmShowError(new ExceptionStatus() { message = "", ex = ex }).ShowDialog();
            }
        }

        public void LoadReport(int reportId)
        {
            if (reportId == 0)//supply Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillsupplyForecastDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.MorbiditySupplyForecast)));
                _fileToLoad = filinfo;

                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 1)//supply procurement Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillsupplyprocurementDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.MorbiditySupplyProcurement)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 2)//Patinet Distribution Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillPatinetDistributionDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.PatientNumberForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 3)//Cd4 hivrapid Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillCD4HIVRapidDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.CD4TestNumberForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, _rDataSet2, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 4)//chemistry Other
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillchemistryOtherDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.ChemistryNumberofTestForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 5)//hematology viral
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillhematologyviralDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.HemaandViralTestNumberForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
        }

        private void FillsupplyForecastDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spMorbiditySupplyForecast";
            cmd.Parameters.AddWithValue("@ForecastId", _mforecast.Id);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spMorbiditySupplyForecast");
        }

        private void FillsupplyprocurementDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spMorbiditySupplyProcuremnetForecast";
            cmd.Parameters.AddWithValue("@ForecastId", _mforecast.Id);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spMorbiditySupplyProcuremnetForecast");
        }

        private void FillPatinetDistributionDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spPatientNumberofTestforecast";
            cmd.Parameters.AddWithValue("@ForecastId", _mforecast.Id);
            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spPatientNumberofTestforecast");

        }

        private void FillCD4HIVRapidDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCD4TestNumberForecast";
            cmd.Parameters.AddWithValue("@ForecastId", _mforecast.Id);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spCD4TestNumberForecast");


            SqlConnection cn2 = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd2 = cn2.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "spHIVRapidTestNumberForecast";
            cmd2.Parameters.AddWithValue("@ForecastId", _mforecast.Id);
            _rDataSet2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(_rDataSet2, "spHIVRapidTestNumberForecast");

        }

        private void FillchemistryOtherDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();


            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spChemandOtherNumberofTestforecast";
            cmd.Parameters.AddWithValue("@ForecastId", _mforecast.Id);


            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spChemandOtherNumberofTestforecast");

        }

        private void FillhematologyviralDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spHemaandViralNumberofTest";
            cmd.Parameters.AddWithValue("@ForecastId", _mforecast.Id);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spHemaandViralNumberofTest");
        }

        private void FillReportDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
         

            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.CommandText = "spForecastSummeries";
            cmd.Parameters.AddWithValue("@ForecastId", _finfo.Id);

        
            _rDataSet = new DataSet();
         
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spForecastSummeries");
           
        }

        private void AddArguments(OReports pReport)
        {
        }

        private void FrmReportLoader_Load(object sender, EventArgs e)
        {
            if (_Report == OReports.ForecastResultSummary)
            {
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _parameters);
                frmRV.Dock = DockStyle.Fill;
                Close();
                frmRV.ShowDialog();
            }
           
        }

        private void comMethodologey_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopForecastInfo();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

    }
}
