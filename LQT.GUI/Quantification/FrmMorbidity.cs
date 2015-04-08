
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Samples.Windows.Forms.TaskPane;
using LQT.Core;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.MorbidityUserCtr;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Reporting.WinForms;
using LQT.GUI.Reports;


namespace LQT.GUI.Quantification
{
    public partial class FrmMorbidity : Form
    {
        private FileInfo _fileToLoad;
        private OReports _Report;
        private string _reportLabel;
        private SortedList<string, object> _parameters;
        private DataSet _rDataSet;
        private bool _load = false;
        private DataSet _rDataSet2;
 
        private UserControl _currentUserCtr;

        public FrmMorbidity()
        {
            InitializeComponent();
            MorbidityForecast mForecast = DataRepository.GetMorbidityForecastById(1);
            popMorbidityForecastInfo(mForecast);
            LoadCharts();

        }

        public void LoadCharts()
        {
            this._currentUserCtr = new chartMSupplyProcurmentForecast(1);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(1,1);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(1, 2);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(1, 3);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(1, 4);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMPatientNo(1);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHIVRapidTest(1);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHematologyTest(1,3);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHematologyTest(1, 4);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMCD4Test(1);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMChemOtherTest(1, 2);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMChemOtherTest(1, 5);
            LoadCurrentUserCtr1();
        }

        public void popMorbidityForecastInfo(MorbidityForecast mForecast)
        {
            txttitle.Text = mForecast.Title;
            txtstartdate.Text = mForecast.SatartDate.ToShortDateString();
            txtbudgetstart.Text = mForecast.StartBudgetPeriodEnum.ToString();
            txtbudgetend.Text = mForecast.EndBudgetPeriodEnum.ToString();
            txtdescription.Text = mForecast.Descritpion;
        }

        public void closeAllFrames()
        {
            foreach (TaskFrame tf in taskPane1.TaskFrames)
            {
                tf.IsExpanded = false;
            }
        }

        private void taskPane1_FrameExpanded(object sender, TaskPaneEventArgs e)
        {

        }

        private void taskPane1_FrameExpanding(object sender, TaskPaneCancelEventArgs ce)
        {
            closeAllFrames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList<MorbiditySupplyProcurement> MSupplyForecastSummery = DataRepository.GetMorbiditySupplyForecastSummery(1);
            DataRepository.MorbiditySupplyProcurementBatchSave(MSupplyForecastSummery);
        }

        private void LoadCurrentUserCtr()
        {


            //_currentUserCtr.MdiParentForm = this;
            // _currentUserCtr.Dock = DockStyle.None;
           // _currentUserCtr.Width = 404;
            //_currentUserCtr.Height = 283;
            //_currentUserCtr.OnDoubleClick += new EventHandler(_currentUserCtr_OnDoubleClick);
            this.flowLayoutPanel1.Controls.Add(_currentUserCtr);

        }
        private void LoadCurrentUserCtr1()
        {


            //_currentUserCtr.MdiParentForm = this;
            // _currentUserCtr.Dock = DockStyle.None;
            // _currentUserCtr.Width = 404;
            //_currentUserCtr.Height = 283;
            //_currentUserCtr.OnDoubleClick += new EventHandler(_currentUserCtr_OnDoubleClick);
            this.flowLayoutPanel2.Controls.Add(_currentUserCtr);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo filinfo = null;
            List<ReportParameter> param = new List<ReportParameter>();
            //ReportParameter finfo = new ReportParameter("ForecastId", "1");
            //param.Add(finfo);
            FillReportDataSet();
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.MorbiditySupplyForecast)));

            _fileToLoad = filinfo;


            FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);



            frmRV.Dock = DockStyle.Fill;
            Close();
            frmRV.ShowDialog();
        }

        private void FillReportDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();


            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spMorbiditySupplyForecast";
            cmd.Parameters.AddWithValue("@ForecastId", 1);


            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spMorbiditySupplyForecast");

        }
        //spMorbiditySupplyProcuremnetForecast
        private void FillReportDataSet2()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();


            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spMorbiditySupplyProcuremnetForecast";
            cmd.Parameters.AddWithValue("@ForecastId", 1);


            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spMorbiditySupplyProcuremnetForecast");

        }
        private void button3_Click(object sender, EventArgs e)
        {
            FileInfo filinfo = null;
            List<ReportParameter> param = new List<ReportParameter>();
            //ReportParameter finfo = new ReportParameter("ForecastId", "1");
            //param.Add(finfo);
            FillReportDataSet2();
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.MorbiditySupplyProcurement)));

            _fileToLoad = filinfo;


            FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);



            frmRV.Dock = DockStyle.Fill;
            Close();
            frmRV.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileInfo filinfo = null;
            List<ReportParameter> param = new List<ReportParameter>();
            //ReportParameter finfo = new ReportParameter("ForecastId", "1");
            //param.Add(finfo);
            FillReportDataSet3();
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.CD4TestNumberForecast)));

            _fileToLoad = filinfo;


            FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet,_rDataSet2,param);



            frmRV.Dock = DockStyle.Fill;
            Close();
            frmRV.ShowDialog();
        }
        private void FillReportDataSet3()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCD4TestNumberForecast";
            cmd.Parameters.AddWithValue("@ForecastId", 1);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spCD4TestNumberForecast");


            SqlConnection cn2 = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd2 = cn2.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "spHIVRapidTestNumberForecast";
            cmd2.Parameters.AddWithValue("@ForecastId", 1);
            _rDataSet2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(_rDataSet2, "spHIVRapidTestNumberForecast");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileInfo filinfo = null;
            List<ReportParameter> param = new List<ReportParameter>();
            //ReportParameter finfo = new ReportParameter("ForecastId", "1");
            //param.Add(finfo);
            FillReportDataSeth();
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.HemaandViralTestNumberForecast)));

            _fileToLoad = filinfo;


            FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);



            frmRV.Dock = DockStyle.Fill;
            Close();
            frmRV.ShowDialog();
        }

        private void FillReportDataSeth()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();


            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spHemaandViralNumberofTest";
            cmd.Parameters.AddWithValue("@ForecastId", 1);


            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spHemaandViralNumberofTest");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileInfo filinfo = null;
            List<ReportParameter> param = new List<ReportParameter>();
            //ReportParameter finfo = new ReportParameter("ForecastId", "1");
            //param.Add(finfo);
            FillReportDataSetpn();
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.PatientNumberForecast)));

            _fileToLoad = filinfo;


            FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);



            frmRV.Dock = DockStyle.Fill;
            Close();
            frmRV.ShowDialog();
        }

        private void FillReportDataSetpn()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();


            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spPatientNumberofTestforecast";
            cmd.Parameters.AddWithValue("@ForecastId", 1);


            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spPatientNumberofTestforecast");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileInfo filinfo = null;
            List<ReportParameter> param = new List<ReportParameter>();
            //ReportParameter finfo = new ReportParameter("ForecastId", "1");
            //param.Add(finfo);
            FillReportDataSetch();
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.ChemistryNumberofTestForecast)));

            _fileToLoad = filinfo;


            FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);



            frmRV.Dock = DockStyle.Fill;
            Close();
            frmRV.ShowDialog();
        }
        private void FillReportDataSetch()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();


            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spChemandOtherNumberofTestforecast";
            cmd.Parameters.AddWithValue("@ForecastId", 1);


            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spChemandOtherNumberofTestforecast");

        }
      
    }
}
