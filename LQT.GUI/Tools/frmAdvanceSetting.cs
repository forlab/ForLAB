
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
using System.IO;
using System.Text;
using System.Windows.Forms;
using LQT.Core;

namespace LQT.GUI.Tools
{
    public partial class frmAdvanceSetting : Form
    {
        private bool _badServerName;
        private bool _badLoginName;
        private bool _badPasswordName;
        private List<SqlDatabaseSettings> _sqlDatabases;
        private bool _exitApplicationIfClose;
        private readonly bool _showBackupRestoreButtons;

        private struct DatabaseOperation
        {
            public SqlDatabaseSettings Settings;
            public string File;
        }

        private enum Authentication
        {
            Windows_Authentication,
            SQL_Server_Authentication
        }

        public frmAdvanceSetting(FrmDatabaseSettingsEnum pDatabaseSettingsEnum, bool pExitApplicationIfClose, bool pShowBackupRestoreButtons)
        {
            InitializeComponent();

            _exitApplicationIfClose = pExitApplicationIfClose;
            _showBackupRestoreButtons = pShowBackupRestoreButtons;

            string[] anames = Enum.GetNames(typeof(Authentication));
            cbAuthentication.Items.Add(anames[0].Replace('_', ' '));
            cbAuthentication.Items.Add(anames[1].Replace('_', ' '));

            cbServerName.Text = AppSettings.DatabaseServerName;
            if (AppSettings.IntegratedSecurity)
            {
                cbAuthentication.SelectedIndex = 0;
                txtLoginName.Text = String.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
                txtPassword.Text = AppSettings.DatabasePassword;
            }
            else
            {
                cbAuthentication.SelectedIndex = 1;
                txtLoginName.Text = AppSettings.DatabaseLoginName;
                txtPassword.Text = AppSettings.DatabasePassword;
                txtLoginName.Enabled = true;
                txtPassword.Enabled = true;
            }
            _InitializeForm(pDatabaseSettingsEnum);
        }

        private void _InitializeForm(FrmDatabaseSettingsEnum pFrmDatabaseSettingsEnum)
        {
            labelResult.Text = string.Empty;
            if (pFrmDatabaseSettingsEnum == FrmDatabaseSettingsEnum.SqlServerConnection)
            {
                tabControlDatabase.TabPages.Remove(tabPageSQLServerSettings);
                _InitializeTabPageServerConnection();
            }
            else
            {
                tabControlDatabase.TabPages.Remove(tabPageSQLServerConnection);
                _InitializeTabPageSqlServerSettings();
            }
            groupBoxDatabaseManagement.TabStop = true;
        }

        private void _InitializeTabPageServerConnection()
        {
            buttonSave.Visible = false;
            btnDatabaseConnection.Visible = true;
        }

        private void buttonGetServersList_Click(object sender, EventArgs e)
        {
            _DetectServers();
        }

        private void _DetectServers()
        {
            Cursor = Cursors.WaitCursor;

            var sie = new SQLInfoEnumerator();
            cbServerName.Items.Clear();
            cbServerName.Items.AddRange(sie.EnumerateSQLServers());

            Cursor = Cursors.Default;
        }

        private void cbServerName_TextChanged(object sender, EventArgs e)
        {
            cbServerName.BackColor = Color.White;
            _badServerName = false;
            if (string.IsNullOrEmpty(cbServerName.Text))
            {
                cbServerName.BackColor = Color.Red;
                _badServerName = true;
            }
        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {
            txtLoginName.BackColor = Color.White;
            _badLoginName = false;
            if (string.IsNullOrEmpty(txtLoginName.Text))
            {
                txtLoginName.BackColor = Color.Red;
                _badLoginName = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            _badPasswordName = false;
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.BackColor = Color.Red;
                _badPasswordName = true;
            }
        }

        private void btnDatabaseConnection_Click(object sender, EventArgs e)
        {
            if (_badLoginName || _badPasswordName || _badServerName)
                MessageBox.Show("Please, Check and correct all red labels!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                AppSettings.DatabaseServerName = cbServerName.Text;

                string[] names = Enum.GetNames(typeof(Authentication));
                if (cbAuthentication.Text == names[0].Replace('_', ' '))
                {
                    AppSettings.IntegratedSecurity = true;
                }
                else
                {
                    AppSettings.DatabaseLoginName = txtLoginName.Text;
                    AppSettings.DatabasePassword = txtPassword.Text;
                    AppSettings.IntegratedSecurity = false;
                }
                _CheckDatabaseSettings();
            }
        }

        private void _CheckDatabaseSettings()
        {
            if (ConnectionManager.CheckSQLServerConnection())
            {
                tabControlDatabase.TabPages.Add(tabPageSQLServerSettings);
                tabControlDatabase.TabPages.Remove(tabPageSQLServerConnection);
                _InitializeTabPageSqlServerSettings();
            }
            else
                MessageBox.Show("A connection to SqlServer could not be made! Are you sure you have filled correctly the fields?", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void _InitializeTabPageSqlServerSettings()
        {
            if (AppSettings.IntegratedSecurity)
                lbSQLServerSettings.Text = string.Format("Server:  {0}     Login:  {1}\\{2}", AppSettings.DatabaseServerName, Environment.UserDomainName, Environment.UserName);
            else
                lbSQLServerSettings.Text = string.Format("Server:  {0}     Login:  {1}     Password:  ****", AppSettings.DatabaseServerName, AppSettings.DatabaseLoginName);
            labelResult.Text = string.Empty;

            buttonBackup.Visible = _showBackupRestoreButtons;
            buttonRestore.Visible = _showBackupRestoreButtons;

            buttonSave.Visible = true;
            btnDatabaseConnection.Visible = false;
            buttonSQLServerChangeSettings.Enabled = false;

            bWDatabasesDetection.RunWorkerAsync();

            _DisplayDatabases();
        }

        private void _DisplayDatabases()
        {
            if (_sqlDatabases == null)
            {
                groupBoxDatabaseManagement.Enabled = false;
                labelDetectDatabasesInProgress.Visible = true;
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                listViewDatabases.Items.Clear();
                lbDatabases.Text = string.Format("{0} ({1})", "Databases", _sqlDatabases.Count);

                _sqlDatabases.Sort((x, y) => x.Name.CompareTo(y.Name));
                foreach (SqlDatabaseSettings sqlDatabase in _sqlDatabases)
                {
                    ListViewItem item = new ListViewItem(sqlDatabase.Name);
                    item.SubItems.Add(sqlDatabase.Version);
                    item.SubItems.Add(sqlDatabase.Size);
                    item.Tag = sqlDatabase;
                    if (sqlDatabase.Name == AppSettings.DatabaseName)
                    {
                        item.BackColor = Color.Green;
                        listViewDatabases.Items.Insert(0, item);
                        item.Selected = true;
                    }
                    else
                        listViewDatabases.Items.Add(item);
                }

            }
            Cursor = Cursors.Default;
            listViewDatabases.Focus();
        }


        private void FrmDatabaseSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_exitApplicationIfClose)
                Environment.Exit(0);
        }

        private void listViewDatabases_DoubleClick(object sender, EventArgs e)
        {
        }

        private void buttonSetAsDefault_Click(object sender, EventArgs e)
        {
            if (listViewDatabases.SelectedItems.Count == 0)
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Select a database in the list above";
                return;
            }

            AppSettings.DatabaseName = listViewDatabases.SelectedItems[0].Text;
            _DisplayDatabases();
            _exitApplicationIfClose = true;
            labelResult.ForeColor = Color.Black;
            labelResult.Text = string.Format("{0} {1}", AppSettings.DatabaseName, "is now the default database");
        }

        private void buttonSQLServerChangeSettings_Click(object sender, EventArgs e)
        {
            tabControlDatabase.TabPages.Remove(tabPageSQLServerSettings);
            tabControlDatabase.TabPages.Add(tabPageSQLServerConnection);
            _InitializeTabPageServerConnection();
            _exitApplicationIfClose = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_exitApplicationIfClose)
            {
                //Close();
                Restart.LaunchRestarter();
            }
            else
            {
                Close();
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            //if (listViewDatabases.SelectedItems.Count == 0)
            //{
            //    labelResult.ForeColor = Color.Red;
            //    labelResult.Text = "Select a database in the list above";
            //    return;
            //}

            //folderBrowserDialog.SelectedPath = AppSettings.BackupPath;
            //if (DialogResult.OK != folderBrowserDialog.ShowDialog()) return;

            //AppSettings.BackupPath = folderBrowserDialog.SelectedPath;

            //var sqlDatabase = (SqlDatabaseSettings)listViewDatabases.SelectedItems[0].Tag;

            //groupBoxDatabaseManagement.Enabled = false;
            //labelResult.ForeColor = Color.Black;
            //labelResult.Text = string.Format("Backup database {0} in progress... ", sqlDatabase.Name);

            //bWDatabaseBackup.RunWorkerAsync(sqlDatabase);
            FrmProgress frm = new FrmProgress();
            frm.InitializeTimer();
            frm.ShowDialog();
        }

       


        private void buttonSQLDatabaseSettingsChangeName_Click(object sender, EventArgs e)
        {
            tabControlDatabase.TabPages.Remove(tabPageSQLServerSettings);
            tabControlDatabase.TabPages.Add(tabPageSQLServerConnection);
            _InitializeTabPageSqlServerSettings();
            _exitApplicationIfClose = true;
        }


        public List<string> FileSearch(string pDir, string pFile)
        {
            List<string> listFiles = new List<string>();
            try
            {
                foreach (string f in Directory.GetFiles(pDir, pFile))
                {
                    listFiles.Add(f);
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return listFiles;
        }

        private void buttonCreateNewDatabase_Click(object sender, EventArgs e)
        {
            var frmDatabaseName = new FrmDatabaseName();
            if (DialogResult.OK != frmDatabaseName.ShowDialog()) return;

            if (FileSearch(DatabaseManager.GetDatabaseDefaultPath(), frmDatabaseName.Result + ".mdf").Count > 0 || FileSearch(DatabaseManager.GetDatabaseDefaultPath(), frmDatabaseName.Result + "_log.ldf").Count > 0)
            {
                labelResult.Text = "Please check database files";
            }
            else
            {
                groupBoxDatabaseManagement.Enabled = false;
                labelResult.ForeColor = Color.Black;
                labelResult.Text = "Database creation in progress...";
                string[] userInput={frmDatabaseName.Result,frmDatabaseName.IncludeDefaultData.ToString()};
                bWDatabaseCreation.RunWorkerAsync(userInput);
            }
        }

        private void backgroundWorkerDetectDatabases_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            buttonSQLServerChangeSettings.Enabled = true;
            groupBoxDatabaseManagement.Enabled = true;
            labelDetectDatabasesInProgress.Visible = false;
            _DisplayDatabases();
        }

        private void backgroundWorkerDetectDatabases_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            _sqlDatabases = DatabaseManager.GetSQLDatabasesSettings(AppSettings.DatabaseServerName, AppSettings.DatabaseLoginName, AppSettings.DatabasePassword, AppSettings.IntegratedSecurity);
        }

        private void bWDatabaseCreation_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            groupBoxDatabaseManagement.Enabled = true;
            labelDetectDatabasesInProgress.Visible = false;
            if (e.Result == null)
            {
                labelResult.ForeColor = Color.Black;
                labelResult.Text = "Database Creation Cancelled";
            }
            else if ((bool)e.Result)
            {
                labelResult.ForeColor = Color.Black;
                labelResult.Text = string.Format("Database {0} Created", AppSettings.DatabaseName);
                _DisplayDatabases();
                _exitApplicationIfClose = true;
            }
            else
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Database creation failed!";
            }
        }

        private void bWDatabaseCreation_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //database name
            string name = ((string[])(e.Argument))[0];// e.Argument.ToString();

            bool insertProduct = bool.Parse(((string[])(e.Argument))[1]);

            e.Result = DatabaseManager.CreateDatabase(name,insertProduct, AppSettings.GetUpdatePath, AppSettings.SoftwareVersion);
            if (!(bool)e.Result) return;

            AppSettings.DatabaseName = name;
            _sqlDatabases.Add(new SqlDatabaseSettings { Name = AppSettings.DatabaseName, Version = AppSettings.SoftwareVersion, Size = "-" });
        }


        private void bWDatabaseBackup_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var sqlDatabaseSettings = (SqlDatabaseSettings)e.Argument;
            e.Result = DatabaseManager.Backup(sqlDatabaseSettings.Name, sqlDatabaseSettings.Version, AppSettings.BackupPath);
        }

        private void bWDatabaseBackup_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            groupBoxDatabaseManagement.Enabled = true;

            if (e.Result == null)
            {
                labelResult.ForeColor = Color.Black;
                labelResult.Text = "Backup Cancelled";
            }
            else if (e.Result.ToString() != string.Empty)
            {
                labelResult.ForeColor = Color.Black;
                labelResult.Text = string.Format("File {0} has been created", e.Result);
            }
            else
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Backup Cancelled";
            }
        }

        private void bWDatabaseRestore_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var dbo = (DatabaseOperation)e.Argument;
            e.Result = DatabaseManager.Restore(dbo.File, dbo.Settings.Name);
        }

        private void bWDatabaseRestore_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            groupBoxDatabaseManagement.Enabled = true;
            labelDetectDatabasesInProgress.Visible = false;
            groupBoxSQLSettings.Enabled = true;
            buttonSave.Enabled = true;

            if (e.Result == null)
            {
                labelResult.ForeColor = Color.Black;
                labelResult.Text = "Restore Cancelled";
            }
            else if ((bool)e.Result)
            {
                labelResult.ForeColor = Color.Black;
                var sqlDatabase = (SqlDatabaseSettings)buttonRestore.Tag;
                labelResult.Text = string.Format("Restore Database {0} Successful", sqlDatabase.Name);
                _sqlDatabases.Remove(sqlDatabase);
                _sqlDatabases.Add(DatabaseManager.GetSQLDatabaseSettings(sqlDatabase.Name));
                //_DisplayDatabases();

                MessageBox.Show(string.Format("Restore Database {0} Successful. Now the application will be closed, and please restart it again.",sqlDatabase.Name), "Restore Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Restore Failed!";
                MessageBox.Show("Restore Database Failed. ", "Restore Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonDefault_Click(object sender, EventArgs e)
        {
            cbServerName.Text = Environment.MachineName + "\\SQLEXPRESS";
        }

        private void cbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] names = Enum.GetNames(typeof(Authentication));
            if (cbAuthentication.Text == names[0].Replace('_', ' '))
            {
                txtLoginName.Text = String.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
                txtPassword.Text = "";
                txtLoginName.Enabled = false;
                txtPassword.Enabled = false;
                _badLoginName = false;
                _badPasswordName = false;
            }
            else
            {
                txtLoginName.Text = AppSettings.DatabaseLoginName;
                txtPassword.Text = AppSettings.DatabasePassword;
                txtLoginName.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //_exitApplicationIfClose = true;
            Close();
        }

        private void butNewdbFromsql_Click(object sender, EventArgs e)
        {
            var frm = new FrmNewDbFromSql();
            if (DialogResult.OK != frm.ShowDialog()) return;

            if (FileSearch(DatabaseManager.GetDatabaseDefaultPath(), frm.Result + ".mdf").Count > 0 ||
                FileSearch(DatabaseManager.GetDatabaseDefaultPath(), frm.Result + "_log.ldf").Count > 0)
            {
                labelResult.Text = "Please check database files";
            }
            else
            {
                groupBoxDatabaseManagement.Enabled = false;
                labelResult.ForeColor = Color.Black;
                labelResult.Text = "Database creation in progress...";
                string[] userInput = {frm.Result, frm.FilePath};
                bWDatabaseFromSql.RunWorkerAsync(userInput);
            }
        }

        private void bWDatabaseFromSql_DoWork(object sender, DoWorkEventArgs e)
        {
            string name = ((string[])(e.Argument))[0];
            string sqlFilePath = ((string[])(e.Argument))[1];

            e.Result = DatabaseManager.CreateDatabaseFromBackupFile(name, sqlFilePath);
            if (!(bool)e.Result) return;

            AppSettings.DatabaseName = name;
            _sqlDatabases.Add(new SqlDatabaseSettings { Name = AppSettings.DatabaseName, Version = AppSettings.SoftwareVersion, Size = "-" });
        }

        private void bWDatabaseFromSql_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            groupBoxDatabaseManagement.Enabled = true;
            labelDetectDatabasesInProgress.Visible = false;
            if (e.Result == null)
            {
                labelResult.ForeColor = Color.Black;
                labelResult.Text = "Database Creation Cancelled";
            }
            else if ((bool)e.Result)
            {
                labelResult.ForeColor = Color.Black;
                labelResult.Text = string.Format("Database {0} Created", AppSettings.DatabaseName);
                _DisplayDatabases();
                _exitApplicationIfClose = true;
            }
            else
            {
                labelResult.ForeColor = Color.Red;
                labelResult.Text = "Database creation failed!";
            }
        }

    }
}
