
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
using System.Windows.Forms;
using System.IO;
using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using System.Data.SqlClient;
using LQT.Core;
using Microsoft.Reporting.WinForms;
using LQT.GUI.Reports;

namespace LQT.GUI.ReportBorwser
{
    public partial class FrmReportParameter : Form
    {
        private FileInfo _fileToLoad;
        private OReports _Report;
        private string _reportLabel;
        private SortedList<string, object> _parameters;
        private DataSet _rDataSet;
        private bool _load = false;
        private ForecastInfo _finfo;
        private MorbidityForecast _mforecast;
        private DataSet _rDataSet2;
        private int _parentId;
        private int _subreportId;

        public FrmReportParameter(int parentId,int subreportId)
        {
            this._parentId = parentId;
            this._subreportId = subreportId;
            InitializeComponent();
            PopForecastInfo();
        }

        private void PopForecastInfo()
        {
            if(_parentId==1)//Consumption
            {
                lblforecastno.Text = "Forecast No :";
                cobforecast.DisplayMember="ForecastNo";
                cobforecast.ValueMember="Id";
                cobforecast.DataSource=DataRepository.GetForecastInfoByMethodology(MethodologyEnum.CONSUMPTION.ToString());
            }
            if(_parentId==2)//Service
            {
                lblforecastno.Text = "Forecast No :";
                cobforecast.DisplayMember = "ForecastNo";
                cobforecast.ValueMember = "Id";
                cobforecast.DataSource=DataRepository.GetForecastInfoByMethodology(MethodologyEnum.SERVICE_STATISTIC.ToString());
            
            }
            if(_parentId==3)//Demographic
            {
                lblforecastno.Text = "Forecast Title :";
                lblreporttype.Visible = false;
                cobreporttype.Visible = false;

                 cobforecast.DisplayMember="Title";
                cobforecast.ValueMember="Id";
                cobforecast.DataSource=DataRepository.GetAllMorbidityForecast();
            }
           
        }

        private void btnviewreport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_parentId == 3)
                {
                    _mforecast = LqtUtil.GetComboBoxValue<MorbidityForecast>(cobforecast);
                    LoadReport(_subreportId);
                }
                else
                {
                    FileInfo filinfo = null;

                    _finfo = LqtUtil.GetComboBoxValue<ForecastInfo>(cobforecast);
                    List<ReportParameter> param = new List<ReportParameter>();
                    ReportParameter finfo = new ReportParameter("ForecastId", _finfo.Id.ToString());
                    param.Add(finfo);


                    FillReportDataSet();


                    if (cobreporttype.SelectedIndex==0)
                        filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.ServiceQSummary)));
                    else
                        filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.FullQSummary)));


                    _fileToLoad = filinfo;


                    FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);



                    frmRV.Dock = DockStyle.Fill;
                   // Close();
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
            if (reportId == 1)//supply Forecast Report
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
            if (reportId == 2)//supply procurement Forecast Report
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
            if (reportId == 3)//Patinet Distribution Forecast Report
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
            if (reportId == 4)//Cd4 hivrapid Forecast Report
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
            if (reportId == 5)//chemistry Other
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
            if (reportId == 6)//hematology viral
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

     
    }
}
