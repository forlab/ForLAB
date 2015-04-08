
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

namespace LQT.GUI.Tools
{
    partial class frmAdvanceSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonSetAsDefault = new System.Windows.Forms.Button();
            this.groupBoxDatabaseManagement = new System.Windows.Forms.GroupBox();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.labelDetectDatabasesInProgress = new System.Windows.Forms.Label();
            this.buttonCreateNewDatabase = new System.Windows.Forms.Button();
            this.lbDatabases = new System.Windows.Forms.Label();
            this.listViewDatabases = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSQLSettings = new System.Windows.Forms.GroupBox();
            this.buttonSQLServerChangeSettings = new System.Windows.Forms.Button();
            this.lbSQLServerSettings = new System.Windows.Forms.Label();
            this.tabControlDatabase = new System.Windows.Forms.TabControl();
            this.tabPageSQLServerConnection = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAuthentication = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.buttonGetServersList = new System.Windows.Forms.Button();
            this.cbServerName = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageSQLServerSettings = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBoxSaveSettings = new System.Windows.Forms.GroupBox();
            this.btnDatabaseConnection = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.bWDatabasesDetection = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bWDatabaseCreation = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bWDatabaseFromSql = new System.ComponentModel.BackgroundWorker();
            this.groupBoxDatabaseManagement.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxSQLSettings.SuspendLayout();
            this.tabControlDatabase.SuspendLayout();
            this.tabPageSQLServerConnection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageSQLServerSettings.SuspendLayout();
            this.groupBoxSaveSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBackup
            // 
            this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackup.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBackup.Location = new System.Drawing.Point(744, 191);
            this.buttonBackup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(194, 37);
            this.buttonBackup.TabIndex = 13;
            this.buttonBackup.Text = "Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // buttonSetAsDefault
            // 
            this.buttonSetAsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetAsDefault.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonSetAsDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSetAsDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSetAsDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSetAsDefault.Location = new System.Drawing.Point(744, 69);
            this.buttonSetAsDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSetAsDefault.Name = "buttonSetAsDefault";
            this.buttonSetAsDefault.Size = new System.Drawing.Size(194, 37);
            this.buttonSetAsDefault.TabIndex = 12;
            this.buttonSetAsDefault.Text = "Set as default";
            this.buttonSetAsDefault.UseVisualStyleBackColor = true;
            this.buttonSetAsDefault.Click += new System.EventHandler(this.buttonSetAsDefault_Click);
            // 
            // groupBoxDatabaseManagement
            // 
            this.groupBoxDatabaseManagement.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDatabaseManagement.Controls.Add(this.buttonRestore);
            this.groupBoxDatabaseManagement.Controls.Add(this.labelDetectDatabasesInProgress);
            this.groupBoxDatabaseManagement.Controls.Add(this.buttonCreateNewDatabase);
            this.groupBoxDatabaseManagement.Controls.Add(this.buttonBackup);
            this.groupBoxDatabaseManagement.Controls.Add(this.buttonSetAsDefault);
            this.groupBoxDatabaseManagement.Controls.Add(this.lbDatabases);
            this.groupBoxDatabaseManagement.Controls.Add(this.listViewDatabases);
            this.groupBoxDatabaseManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDatabaseManagement.Location = new System.Drawing.Point(4, 100);
            this.groupBoxDatabaseManagement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDatabaseManagement.Name = "groupBoxDatabaseManagement";
            this.groupBoxDatabaseManagement.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxDatabaseManagement.Size = new System.Drawing.Size(1059, 334);
            this.groupBoxDatabaseManagement.TabIndex = 10;
            this.groupBoxDatabaseManagement.TabStop = false;
            this.groupBoxDatabaseManagement.Text = "Database Management";
            // 
            // buttonRestore
            // 
            this.buttonRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRestore.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRestore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonRestore.Location = new System.Drawing.Point(744, 238);
            this.buttonRestore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(194, 37);
            this.buttonRestore.TabIndex = 40;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.butNewdbFromsql_Click);
            // 
            // labelDetectDatabasesInProgress
            // 
            this.labelDetectDatabasesInProgress.AutoSize = true;
            this.labelDetectDatabasesInProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelDetectDatabasesInProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDetectDatabasesInProgress.Location = new System.Drawing.Point(94, 145);
            this.labelDetectDatabasesInProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDetectDatabasesInProgress.Name = "labelDetectDatabasesInProgress";
            this.labelDetectDatabasesInProgress.Size = new System.Drawing.Size(406, 25);
            this.labelDetectDatabasesInProgress.TabIndex = 39;
            this.labelDetectDatabasesInProgress.Text = "Please wait during databases detection...";
            // 
            // buttonCreateNewDatabase
            // 
            this.buttonCreateNewDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateNewDatabase.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCreateNewDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCreateNewDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCreateNewDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCreateNewDatabase.Location = new System.Drawing.Point(460, 285);
            this.buttonCreateNewDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreateNewDatabase.Name = "buttonCreateNewDatabase";
            this.buttonCreateNewDatabase.Size = new System.Drawing.Size(261, 35);
            this.buttonCreateNewDatabase.TabIndex = 15;
            this.buttonCreateNewDatabase.Text = "Create new database";
            this.buttonCreateNewDatabase.UseVisualStyleBackColor = true;
            this.buttonCreateNewDatabase.Click += new System.EventHandler(this.buttonCreateNewDatabase_Click);
            // 
            // lbDatabases
            // 
            this.lbDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbDatabases.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDatabases.Location = new System.Drawing.Point(21, 35);
            this.lbDatabases.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDatabases.Name = "lbDatabases";
            this.lbDatabases.Size = new System.Drawing.Size(135, 32);
            this.lbDatabases.TabIndex = 21;
            this.lbDatabases.Text = "Databases";
            this.lbDatabases.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewDatabases
            // 
            this.listViewDatabases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize});
            this.listViewDatabases.FullRowSelect = true;
            this.listViewDatabases.GridLines = true;
            this.listViewDatabases.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewDatabases.HideSelection = false;
            this.listViewDatabases.Location = new System.Drawing.Point(26, 71);
            this.listViewDatabases.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewDatabases.Name = "listViewDatabases";
            this.listViewDatabases.Size = new System.Drawing.Size(689, 204);
            this.listViewDatabases.TabIndex = 11;
            this.listViewDatabases.UseCompatibleStateImageBehavior = false;
            this.listViewDatabases.View = System.Windows.Forms.View.Details;
            this.listViewDatabases.DoubleClick += new System.EventHandler(this.listViewDatabases_DoubleClick);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Width = 300;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Width = 70;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxSQLSettings, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxDatabaseManagement, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 439);
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // groupBoxSQLSettings
            // 
            this.groupBoxSQLSettings.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSQLSettings.CausesValidation = false;
            this.groupBoxSQLSettings.Controls.Add(this.buttonSQLServerChangeSettings);
            this.groupBoxSQLSettings.Controls.Add(this.lbSQLServerSettings);
            this.groupBoxSQLSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSQLSettings.Location = new System.Drawing.Point(4, 5);
            this.groupBoxSQLSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSQLSettings.Name = "groupBoxSQLSettings";
            this.groupBoxSQLSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSQLSettings.Size = new System.Drawing.Size(1059, 85);
            this.groupBoxSQLSettings.TabIndex = 8;
            this.groupBoxSQLSettings.TabStop = false;
            this.groupBoxSQLSettings.Text = "SQLServer Settings";
            // 
            // buttonSQLServerChangeSettings
            // 
            this.buttonSQLServerChangeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSQLServerChangeSettings.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonSQLServerChangeSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSQLServerChangeSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSQLServerChangeSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSQLServerChangeSettings.Location = new System.Drawing.Point(744, 31);
            this.buttonSQLServerChangeSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSQLServerChangeSettings.Name = "buttonSQLServerChangeSettings";
            this.buttonSQLServerChangeSettings.Size = new System.Drawing.Size(194, 37);
            this.buttonSQLServerChangeSettings.TabIndex = 9;
            this.buttonSQLServerChangeSettings.Text = "Change";
            this.buttonSQLServerChangeSettings.UseVisualStyleBackColor = true;
            this.buttonSQLServerChangeSettings.Click += new System.EventHandler(this.buttonSQLServerChangeSettings_Click);
            // 
            // lbSQLServerSettings
            // 
            this.lbSQLServerSettings.AutoSize = true;
            this.lbSQLServerSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbSQLServerSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbSQLServerSettings.Location = new System.Drawing.Point(34, 42);
            this.lbSQLServerSettings.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSQLServerSettings.Name = "lbSQLServerSettings";
            this.lbSQLServerSettings.Size = new System.Drawing.Size(0, 20);
            this.lbSQLServerSettings.TabIndex = 0;
            // 
            // tabControlDatabase
            // 
            this.tabControlDatabase.Controls.Add(this.tabPageSQLServerConnection);
            this.tabControlDatabase.Controls.Add(this.tabPageSQLServerSettings);
            this.tabControlDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlDatabase.Location = new System.Drawing.Point(0, 0);
            this.tabControlDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlDatabase.Name = "tabControlDatabase";
            this.tabControlDatabase.SelectedIndex = 0;
            this.tabControlDatabase.Size = new System.Drawing.Size(1083, 482);
            this.tabControlDatabase.TabIndex = 0;
            // 
            // tabPageSQLServerConnection
            // 
            this.tabPageSQLServerConnection.Controls.Add(this.groupBox1);
            this.tabPageSQLServerConnection.Location = new System.Drawing.Point(4, 29);
            this.tabPageSQLServerConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageSQLServerConnection.Name = "tabPageSQLServerConnection";
            this.tabPageSQLServerConnection.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageSQLServerConnection.Size = new System.Drawing.Size(1075, 449);
            this.tabPageSQLServerConnection.TabIndex = 0;
            this.tabPageSQLServerConnection.Text = "Connect to SQL Server";
            this.tabPageSQLServerConnection.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAuthentication);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.buttonDefault);
            this.groupBox1.Controls.Add(this.buttonGetServersList);
            this.groupBox1.Controls.Add(this.cbServerName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtLoginName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1067, 439);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SQL Server Settings";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 37);
            this.label1.TabIndex = 44;
            this.label1.Text = "Authentication:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAuthentication
            // 
            this.cbAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthentication.FormattingEnabled = true;
            this.cbAuthentication.Location = new System.Drawing.Point(164, 128);
            this.cbAuthentication.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAuthentication.Name = "cbAuthentication";
            this.cbAuthentication.Size = new System.Drawing.Size(400, 28);
            this.cbAuthentication.TabIndex = 5;
            this.cbAuthentication.SelectedIndexChanged += new System.EventHandler(this.cbAuthentication_SelectedIndexChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label.Location = new System.Drawing.Point(159, 38);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(885, 22);
            this.label.TabIndex = 42;
            this.label.Text = "ForLAB needs to know where to find the database. Please enter the database detail" +
                "s below and click Connect";
            // 
            // buttonDefault
            // 
            this.buttonDefault.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonDefault.Font = new System.Drawing.Font("Arial", 9.75F);
            this.buttonDefault.ForeColor = System.Drawing.Color.Black;
            this.buttonDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDefault.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonDefault.Location = new System.Drawing.Point(574, 77);
            this.buttonDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(100, 38);
            this.buttonDefault.TabIndex = 3;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = false;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // buttonGetServersList
            // 
            this.buttonGetServersList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonGetServersList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonGetServersList.Font = new System.Drawing.Font("Arial", 9.75F);
            this.buttonGetServersList.ForeColor = System.Drawing.Color.Black;
            this.buttonGetServersList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetServersList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGetServersList.Location = new System.Drawing.Point(684, 78);
            this.buttonGetServersList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonGetServersList.Name = "buttonGetServersList";
            this.buttonGetServersList.Size = new System.Drawing.Size(170, 38);
            this.buttonGetServersList.TabIndex = 4;
            this.buttonGetServersList.Text = "Get servers list";
            this.buttonGetServersList.UseVisualStyleBackColor = false;
            this.buttonGetServersList.Click += new System.EventHandler(this.buttonGetServersList_Click);
            // 
            // cbServerName
            // 
            this.cbServerName.FormattingEnabled = true;
            this.cbServerName.Location = new System.Drawing.Point(164, 80);
            this.cbServerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.Size = new System.Drawing.Size(400, 28);
            this.cbServerName.TabIndex = 2;
            this.cbServerName.TextChanged += new System.EventHandler(this.cbServerName_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(164, 228);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(401, 26);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(4, 232);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 37);
            this.label9.TabIndex = 12;
            this.label9.Text = "Password:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLoginName
            // 
            this.txtLoginName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginName.Enabled = false;
            this.txtLoginName.Location = new System.Drawing.Point(164, 177);
            this.txtLoginName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(401, 26);
            this.txtLoginName.TabIndex = 6;
            this.txtLoginName.TextChanged += new System.EventHandler(this.txtLoginName_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(4, 177);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 37);
            this.label8.TabIndex = 10;
            this.label8.Text = "User Name:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(4, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Server:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageSQLServerSettings
            // 
            this.tabPageSQLServerSettings.Controls.Add(this.tableLayoutPanel1);
            this.tabPageSQLServerSettings.Location = new System.Drawing.Point(4, 29);
            this.tabPageSQLServerSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageSQLServerSettings.Name = "tabPageSQLServerSettings";
            this.tabPageSQLServerSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageSQLServerSettings.Size = new System.Drawing.Size(1075, 449);
            this.tabPageSQLServerSettings.TabIndex = 1;
            this.tabPageSQLServerSettings.Text = "SQL Server Settings";
            this.tabPageSQLServerSettings.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 482);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1083, 5);
            this.splitter1.TabIndex = 48;
            this.splitter1.TabStop = false;
            // 
            // groupBoxSaveSettings
            // 
            this.groupBoxSaveSettings.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSaveSettings.Controls.Add(this.btnDatabaseConnection);
            this.groupBoxSaveSettings.Controls.Add(this.buttonExit);
            this.groupBoxSaveSettings.Controls.Add(this.labelResult);
            this.groupBoxSaveSettings.Controls.Add(this.buttonSave);
            this.groupBoxSaveSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxSaveSettings.Location = new System.Drawing.Point(0, 494);
            this.groupBoxSaveSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSaveSettings.Name = "groupBoxSaveSettings";
            this.groupBoxSaveSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSaveSettings.Size = new System.Drawing.Size(1083, 78);
            this.groupBoxSaveSettings.TabIndex = 16;
            this.groupBoxSaveSettings.TabStop = false;
            // 
            // btnDatabaseConnection
            // 
            this.btnDatabaseConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatabaseConnection.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDatabaseConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDatabaseConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatabaseConnection.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDatabaseConnection.Location = new System.Drawing.Point(666, 29);
            this.btnDatabaseConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDatabaseConnection.Name = "btnDatabaseConnection";
            this.btnDatabaseConnection.Size = new System.Drawing.Size(195, 37);
            this.btnDatabaseConnection.TabIndex = 17;
            this.btnDatabaseConnection.Text = "Connect";
            this.btnDatabaseConnection.UseVisualStyleBackColor = true;
            this.btnDatabaseConnection.Click += new System.EventHandler(this.btnDatabaseConnection_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Font = new System.Drawing.Font("Arial", 9.75F);
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(88)))), ((int)(((byte)(56)))));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonExit.Location = new System.Drawing.Point(9, 32);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(132, 37);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "Quit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelResult.Location = new System.Drawing.Point(150, 35);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 25);
            this.labelResult.TabIndex = 36;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSave.Location = new System.Drawing.Point(870, 32);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(195, 37);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "Launch ForLAB";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // bWDatabasesDetection
            // 
            this.bWDatabasesDetection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDetectDatabases_DoWork);
            this.bWDatabasesDetection.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDetectDatabases_RunWorkerCompleted);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Backups|*.bak;*.zip";
            this.openFileDialog.Title = "Select the backup file to restore";
            // 
            // bWDatabaseCreation
            // 
            this.bWDatabaseCreation.WorkerSupportsCancellation = true;
            this.bWDatabaseCreation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWDatabaseCreation_DoWork);
            this.bWDatabaseCreation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWDatabaseCreation_RunWorkerCompleted);
            // 
            // bWDatabaseFromSql
            // 
            this.bWDatabaseFromSql.WorkerSupportsCancellation = true;
            this.bWDatabaseFromSql.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWDatabaseFromSql_DoWork);
            this.bWDatabaseFromSql.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWDatabaseFromSql_RunWorkerCompleted);
            // 
            // frmAdvanceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 572);
            this.Controls.Add(this.groupBoxSaveSettings);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlDatabase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAdvanceSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Control Panel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDatabaseSettings_FormClosed);
            this.groupBoxDatabaseManagement.ResumeLayout(false);
            this.groupBoxDatabaseManagement.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxSQLSettings.ResumeLayout(false);
            this.groupBoxSQLSettings.PerformLayout();
            this.tabControlDatabase.ResumeLayout(false);
            this.tabPageSQLServerConnection.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageSQLServerSettings.ResumeLayout(false);
            this.groupBoxSaveSettings.ResumeLayout(false);
            this.groupBoxSaveSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBackup;
        private System.Windows.Forms.Button buttonSetAsDefault;
        private System.Windows.Forms.GroupBox groupBoxDatabaseManagement;
        private System.Windows.Forms.Label labelDetectDatabasesInProgress;
        private System.Windows.Forms.Button buttonCreateNewDatabase;
        private System.Windows.Forms.Label lbDatabases;
        private System.Windows.Forms.ListView listViewDatabases;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControlDatabase;
        private System.Windows.Forms.TabPage tabPageSQLServerConnection;
        private System.Windows.Forms.TabPage tabPageSQLServerSettings;
        private System.Windows.Forms.GroupBox groupBoxSQLSettings;
        private System.Windows.Forms.Button buttonSQLServerChangeSettings;
        private System.Windows.Forms.Label lbSQLServerSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Button buttonGetServersList;
        private System.Windows.Forms.ComboBox cbServerName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBoxSaveSettings;
        private System.Windows.Forms.Button btnDatabaseConnection;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonSave;
        private System.ComponentModel.BackgroundWorker bWDatabasesDetection;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker bWDatabaseCreation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAuthentication;
        private System.Windows.Forms.Button buttonRestore;
        private System.ComponentModel.BackgroundWorker bWDatabaseFromSql;
    }
}
