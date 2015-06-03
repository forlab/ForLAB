
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
using Microsoft.Win32;
using System.Windows.Forms;
using LQT.GUI.Tools;
using LQT.Core;

namespace LQT.GUI
{
    public partial class frmSplash : Form
    {
        private bool _settingsAreOk;
        private bool _sqlServerConnectionIsOk;
        private bool _sqlDatabaseConnectionIsOk;

        public frmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Shown(object sender, EventArgs e)
        {
            bWOneToSeven.RunWorkerAsync();
        }

        private void _CheckForlabConfiguration()
        {
            if (!_settingsAreOk)
                _CheckTechnicalSettings();

            if (!_sqlServerConnectionIsOk)
                _CheckSQLServerConnection();

            if (!_sqlDatabaseConnectionIsOk)
                _CheckSQLDatabaseConnection();
        }

        private void _CheckSQLDatabaseConnection()
        {
            bWOneToSeven.ReportProgress(3, "Check Database Connection....");
            if (!ConnectionManager.CheckSQLDatabaseConnection())
                _LoadDatabaseSettingsForm(FrmDatabaseSettingsEnum.SqlServerSettings);

            _sqlDatabaseConnectionIsOk = true;
        }

        private void _CheckSQLServerConnection()
        {
            bWOneToSeven.ReportProgress(2, "Check SQL Server Connection...");
            if (!ConnectionManager.CheckSQLServerConnection())
                _LoadDatabaseSettingsForm(FrmDatabaseSettingsEnum.SqlServerConnection);

            _sqlServerConnectionIsOk = true;
        }

        private void _CheckTechnicalSettings()
        {
            bWOneToSeven.ReportProgress(1, "Check Technical Settings...");
            if (!AppSettings.CheckSettings())
                _LoadDatabaseSettingsForm(FrmDatabaseSettingsEnum.SqlServerConnection);

            _settingsAreOk = true;
        }

        private void _LoadDatabaseSettingsForm(FrmDatabaseSettingsEnum pFrmDatabaseSettingsEnum)
        {
            frmAdvanceSetting databaseSettings = new frmAdvanceSetting(pFrmDatabaseSettingsEnum,true,false);
            databaseSettings.ShowDialog();

            _CheckForlabConfiguration();
        }
            
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _CheckForlabConfiguration();
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //if (e.ProgressPercentage == 24)
            //{
            //    progressBar1.t
            //    oPBarMicroProgression.Text = e.UserState.ToString();
            //    oPBarMicroProgression.PerformStep();
            //}
            //else
            //{
                //progressBar1 = string.Format("{0} / 9", e.ProgressPercentage);
                label1.Text = e.UserState.ToString();
                //progressBar1.PerformStep();
            //
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //Hide();

            //WindowState = FormWindowState.Normal;
            //bWSeventToEight.RunWorkerAsync();
            Close();
            //Show();
        }


    }
}
