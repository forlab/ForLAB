
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
