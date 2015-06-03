
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.Tools
{
    partial class RapidTestForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lsvSerial = new LQT.GUI.LQTListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lsvParallel = new LQT.GUI.LQTListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comDiscordant = new System.Windows.Forms.ComboBox();
            this.comBothpostive = new System.Windows.Forms.ComboBox();
            this.comBothnegative = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comSCrapid2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comSCrapid1 = new System.Windows.Forms.ComboBox();
            this.comSCrapid3 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.comSTrapid2 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comSTrapid1 = new System.Windows.Forms.ComboBox();
            this.comSTrapid3 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comSrapid2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comSrapid1 = new System.Windows.Forms.ComboBox();
            this.comSrapid3 = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 439);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serial";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.lsvSerial, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(964, 407);
            this.tableLayoutPanel4.TabIndex = 10;
            // 
            // lsvSerial
            // 
            this.lsvSerial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.lsvSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvSerial.FullRowSelect = true;
            this.lsvSerial.GridLines = true;
            this.lsvSerial.Location = new System.Drawing.Point(3, 3);
            this.lsvSerial.Name = "lsvSerial";
            this.lsvSerial.Size = new System.Drawing.Size(668, 401);
            this.lsvSerial.TabIndex = 9;
            this.lsvSerial.UseCompatibleStateImageBehavior = false;
            this.lsvSerial.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "HIV rapid test";
            this.columnHeader1.Width = 228;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Test Sensitivity";
            this.columnHeader2.Width = 97;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Test Specificity";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "HIV + False Negative";
            this.columnHeader5.Width = 117;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "HIV - False Positive";
            this.columnHeader6.Width = 116;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(677, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 401);
            this.panel2.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(970, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parallel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Controls.Add(this.lsvParallel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(964, 407);
            this.tableLayoutPanel5.TabIndex = 11;
            // 
            // lsvParallel
            // 
            this.lsvParallel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lsvParallel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvParallel.FullRowSelect = true;
            this.lsvParallel.GridLines = true;
            this.lsvParallel.Location = new System.Drawing.Point(3, 3);
            this.lsvParallel.Name = "lsvParallel";
            this.lsvParallel.Size = new System.Drawing.Size(668, 401);
            this.lsvParallel.TabIndex = 9;
            this.lsvParallel.UseCompatibleStateImageBehavior = false;
            this.lsvParallel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "HIV rapid test";
            this.columnHeader4.Width = 228;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Test Sensitivity";
            this.columnHeader7.Width = 97;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Test Specificity";
            this.columnHeader8.Width = 88;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "HIV + False Negative";
            this.columnHeader9.Width = 117;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "HIV - False Positive";
            this.columnHeader10.Width = 116;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(677, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 401);
            this.panel1.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comDiscordant);
            this.groupBox5.Controls.Add(this.comBothpostive);
            this.groupBox5.Controls.Add(this.comBothnegative);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Location = new System.Drawing.Point(7, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(268, 169);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rules for Progressing Through Algorithm";
            // 
            // comDiscordant
            // 
            this.comDiscordant.FormattingEnabled = true;
            this.comDiscordant.Items.AddRange(new object[] {
            "Proceed",
            "Stop"});
            this.comDiscordant.Location = new System.Drawing.Point(13, 135);
            this.comDiscordant.Name = "comDiscordant";
            this.comDiscordant.Size = new System.Drawing.Size(170, 21);
            this.comDiscordant.TabIndex = 5;
            this.comDiscordant.Text = "Proceed";
            // 
            // comBothpostive
            // 
            this.comBothpostive.FormattingEnabled = true;
            this.comBothpostive.Items.AddRange(new object[] {
            "Proceed",
            "Stop"});
            this.comBothpostive.Location = new System.Drawing.Point(13, 88);
            this.comBothpostive.Name = "comBothpostive";
            this.comBothpostive.Size = new System.Drawing.Size(170, 21);
            this.comBothpostive.TabIndex = 4;
            this.comBothpostive.Text = "Proceed";
            // 
            // comBothnegative
            // 
            this.comBothnegative.FormattingEnabled = true;
            this.comBothnegative.Items.AddRange(new object[] {
            "Proceed",
            "Stop"});
            this.comBothnegative.Location = new System.Drawing.Point(13, 38);
            this.comBothnegative.Name = "comBothnegative";
            this.comBothnegative.Size = new System.Drawing.Size(170, 21);
            this.comBothnegative.TabIndex = 3;
            this.comBothnegative.Text = "Proceed";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 119);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Discordant";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 72);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "Both Positive";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Both Negative";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(332, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 155);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Confirmatory Tests";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.comSCrapid2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comSCrapid1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comSCrapid3, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 128);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // comSCrapid2
            // 
            this.comSCrapid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSCrapid2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSCrapid2.FormattingEnabled = true;
            this.comSCrapid2.Location = new System.Drawing.Point(4, 66);
            this.comSCrapid2.Name = "comSCrapid2";
            this.comSCrapid2.Size = new System.Drawing.Size(292, 21);
            this.comSCrapid2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(292, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rapid Product";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comSCrapid1
            // 
            this.comSCrapid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSCrapid1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSCrapid1.FormattingEnabled = true;
            this.comSCrapid1.Location = new System.Drawing.Point(4, 35);
            this.comSCrapid1.Name = "comSCrapid1";
            this.comSCrapid1.Size = new System.Drawing.Size(292, 21);
            this.comSCrapid1.TabIndex = 7;
            // 
            // comSCrapid3
            // 
            this.comSCrapid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSCrapid3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSCrapid3.FormattingEnabled = true;
            this.comSCrapid3.Location = new System.Drawing.Point(4, 97);
            this.comSCrapid3.Name = "comSCrapid3";
            this.comSCrapid3.Size = new System.Drawing.Size(292, 21);
            this.comSCrapid3.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(653, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 155);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tiebreaker Tests";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Controls.Add(this.comSTrapid2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comSTrapid1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.comSTrapid3, 0, 3);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(300, 128);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // comSTrapid2
            // 
            this.comSTrapid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSTrapid2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSTrapid2.FormattingEnabled = true;
            this.comSTrapid2.Location = new System.Drawing.Point(4, 66);
            this.comSTrapid2.Name = "comSTrapid2";
            this.comSTrapid2.Size = new System.Drawing.Size(292, 21);
            this.comSTrapid2.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(292, 30);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tie-breaker Product";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comSTrapid1
            // 
            this.comSTrapid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSTrapid1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSTrapid1.FormattingEnabled = true;
            this.comSTrapid1.Location = new System.Drawing.Point(4, 35);
            this.comSTrapid1.Name = "comSTrapid1";
            this.comSTrapid1.Size = new System.Drawing.Size(292, 21);
            this.comSTrapid1.TabIndex = 7;
            // 
            // comSTrapid3
            // 
            this.comSTrapid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSTrapid3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSTrapid3.FormattingEnabled = true;
            this.comSTrapid3.Location = new System.Drawing.Point(4, 97);
            this.comSTrapid3.Name = "comSTrapid3";
            this.comSTrapid3.Size = new System.Drawing.Size(292, 21);
            this.comSTrapid3.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screening Tests";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.comSrapid2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comSrapid1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comSrapid3, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 128);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // comSrapid2
            // 
            this.comSrapid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSrapid2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSrapid2.FormattingEnabled = true;
            this.comSrapid2.Location = new System.Drawing.Point(4, 66);
            this.comSrapid2.Name = "comSrapid2";
            this.comSrapid2.Size = new System.Drawing.Size(292, 21);
            this.comSrapid2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rapid Product";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comSrapid1
            // 
            this.comSrapid1.DisplayMember = "ProductName";
            this.comSrapid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSrapid1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSrapid1.FormattingEnabled = true;
            this.comSrapid1.Location = new System.Drawing.Point(4, 35);
            this.comSrapid1.Name = "comSrapid1";
            this.comSrapid1.Size = new System.Drawing.Size(292, 21);
            this.comSrapid1.TabIndex = 7;
            this.comSrapid1.ValueMember = "Id";
            // 
            // comSrapid3
            // 
            this.comSrapid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comSrapid3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSrapid3.FormattingEnabled = true;
            this.comSrapid3.Location = new System.Drawing.Point(4, 97);
            this.comSrapid3.Name = "comSrapid3";
            this.comSrapid3.Size = new System.Drawing.Size(292, 21);
            this.comSrapid3.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(978, 655);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save Rapid Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RapidTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 655);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RapidTestForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapid Test Specifications";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RapidTestForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox comSTrapid2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comSTrapid1;
        private System.Windows.Forms.ComboBox comSTrapid3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comSrapid2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSrapid1;
        private System.Windows.Forms.ComboBox comSrapid3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comSCrapid2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comSCrapid1;
        private System.Windows.Forms.ComboBox comSCrapid3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comDiscordant;
        private System.Windows.Forms.ComboBox comBothpostive;
        private System.Windows.Forms.ComboBox comBothnegative;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private LQTListView lsvSerial;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private LQTListView lsvParallel;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
