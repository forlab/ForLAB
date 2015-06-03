
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI
{
    partial class ForecastForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lnkCatInstUtilizaiton = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comStatus = new System.Windows.Forms.ComboBox();
            this.comMethodologey = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comForecastinfo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewlocation = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.butForecast = new System.Windows.Forms.Button();
            this.cboOrder = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboRegressionType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAddby = new System.Windows.Forms.TextBox();
            this.txtDusage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtWestage = new System.Windows.Forms.TextBox();
            this.txtMethodology = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtSdate = new System.Windows.Forms.TextBox();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.butToxml = new System.Windows.Forms.Button();
            this.butSummary = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRegressionType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabdashboard = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkshowmapesummary = new System.Windows.Forms.LinkLabel();
            this.lblSelectedTitle = new System.Windows.Forms.Label();
            this.bwforecast = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 631);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.lnkCatInstUtilizaiton);
            this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer4.Size = new System.Drawing.Size(254, 631);
            this.splitContainer4.SplitterDistance = 172;
            this.splitContainer4.TabIndex = 4;
            // 
            // lnkCatInstUtilizaiton
            // 
            this.lnkCatInstUtilizaiton.AutoSize = true;
            this.lnkCatInstUtilizaiton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCatInstUtilizaiton.Location = new System.Drawing.Point(8, 140);
            this.lnkCatInstUtilizaiton.Name = "lnkCatInstUtilizaiton";
            this.lnkCatInstUtilizaiton.Size = new System.Drawing.Size(180, 13);
            this.lnkCatInstUtilizaiton.TabIndex = 6;
            this.lnkCatInstUtilizaiton.TabStop = true;
            this.lnkCatInstUtilizaiton.Text = "Category Instrument Utilization";
            this.lnkCatInstUtilizaiton.Visible = false;
            this.lnkCatInstUtilizaiton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCatInstUtilizaiton_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comStatus);
            this.groupBox3.Controls.Add(this.comMethodologey);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comForecastinfo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 108);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filiter";
            // 
            // comStatus
            // 
            this.comStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comStatus.FormattingEnabled = true;
            this.comStatus.Location = new System.Drawing.Point(76, 46);
            this.comStatus.Name = "comStatus";
            this.comStatus.Size = new System.Drawing.Size(163, 21);
            this.comStatus.TabIndex = 7;
            this.comStatus.SelectedIndexChanged += new System.EventHandler(this.comStatus_SelectedIndexChanged);
            // 
            // comMethodologey
            // 
            this.comMethodologey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMethodologey.FormattingEnabled = true;
            this.comMethodologey.Location = new System.Drawing.Point(76, 19);
            this.comMethodologey.Name = "comMethodologey";
            this.comMethodologey.Size = new System.Drawing.Size(163, 21);
            this.comMethodologey.TabIndex = 5;
            this.comMethodologey.SelectedIndexChanged += new System.EventHandler(this.comMethodologey_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Data Usage";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Forecast ID:";
            // 
            // comForecastinfo
            // 
            this.comForecastinfo.DisplayMember = "ForecastNo";
            this.comForecastinfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comForecastinfo.FormattingEnabled = true;
            this.comForecastinfo.Location = new System.Drawing.Point(76, 73);
            this.comForecastinfo.Name = "comForecastinfo";
            this.comForecastinfo.Size = new System.Drawing.Size(163, 21);
            this.comForecastinfo.TabIndex = 3;
            this.comForecastinfo.ValueMember = "Id";
            this.comForecastinfo.SelectedIndexChanged += new System.EventHandler(this.comForecastinfo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Methodology";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.treeViewlocation, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(254, 455);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // treeViewlocation
            // 
            this.treeViewlocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewlocation.Location = new System.Drawing.Point(0, 30);
            this.treeViewlocation.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewlocation.Name = "treeViewlocation";
            this.treeViewlocation.Size = new System.Drawing.Size(254, 425);
            this.treeViewlocation.TabIndex = 0;
            this.treeViewlocation.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewlocation_AfterSelect);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.label17);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(248, 24);
            this.panel5.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(172, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Select Product/Test To view Chart";
            // 
            // butForecast
            // 
            this.butForecast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butForecast.Location = new System.Drawing.Point(268, 15);
            this.butForecast.Name = "butForecast";
            this.butForecast.Size = new System.Drawing.Size(74, 116);
            this.butForecast.TabIndex = 24;
            this.butForecast.Text = "Do Forecast";
            this.butForecast.UseVisualStyleBackColor = true;
            this.butForecast.Click += new System.EventHandler(this.butForecast_Click);
            // 
            // cboOrder
            // 
            this.cboOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrder.Items.AddRange(new object[] {
            "3",
            "4",
            "5"});
            this.cboOrder.Location = new System.Drawing.Point(124, 111);
            this.cboOrder.Name = "cboOrder";
            this.cboOrder.Size = new System.Drawing.Size(139, 21);
            this.cboOrder.TabIndex = 21;
            this.cboOrder.Visible = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "&Order:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Visible = false;
            // 
            // cboRegressionType
            // 
            this.cboRegressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegressionType.Location = new System.Drawing.Point(123, 40);
            this.cboRegressionType.Name = "cboRegressionType";
            this.cboRegressionType.Size = new System.Drawing.Size(139, 21);
            this.cboRegressionType.TabIndex = 17;
            this.cboRegressionType.SelectedIndexChanged += new System.EventHandler(this.cboRegressionType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Regression Type:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 37);
            this.label15.TabIndex = 14;
            this.label15.Text = "Program growth over the forecast period  %:";
            // 
            // txtAddby
            // 
            this.txtAddby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddby.Location = new System.Drawing.Point(124, 89);
            this.txtAddby.Name = "txtAddby";
            this.txtAddby.Size = new System.Drawing.Size(138, 20);
            this.txtAddby.TabIndex = 15;
            this.txtAddby.Text = "0";
            this.txtAddby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // txtDusage
            // 
            this.txtDusage.BackColor = System.Drawing.Color.Ivory;
            this.txtDusage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDusage.Enabled = false;
            this.txtDusage.Location = new System.Drawing.Point(100, 88);
            this.txtDusage.Name = "txtDusage";
            this.txtDusage.Size = new System.Drawing.Size(116, 20);
            this.txtDusage.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Data Usage:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Wastage  %:";
            // 
            // txtWestage
            // 
            this.txtWestage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWestage.Location = new System.Drawing.Point(123, 65);
            this.txtWestage.Name = "txtWestage";
            this.txtWestage.Size = new System.Drawing.Size(140, 20);
            this.txtWestage.TabIndex = 11;
            this.txtWestage.Text = "3";
            this.txtWestage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
            // 
            // txtMethodology
            // 
            this.txtMethodology.BackColor = System.Drawing.Color.Ivory;
            this.txtMethodology.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMethodology.Enabled = false;
            this.txtMethodology.Location = new System.Drawing.Point(100, 65);
            this.txtMethodology.Name = "txtMethodology";
            this.txtMethodology.Size = new System.Drawing.Size(116, 20);
            this.txtMethodology.TabIndex = 8;
            // 
            // txtExtension
            // 
            this.txtExtension.BackColor = System.Drawing.Color.Ivory;
            this.txtExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtension.Enabled = false;
            this.txtExtension.Location = new System.Drawing.Point(123, 15);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(139, 20);
            this.txtExtension.TabIndex = 7;
            // 
            // txtSdate
            // 
            this.txtSdate.BackColor = System.Drawing.Color.Ivory;
            this.txtSdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSdate.Enabled = false;
            this.txtSdate.Location = new System.Drawing.Point(100, 42);
            this.txtSdate.Name = "txtSdate";
            this.txtSdate.Size = new System.Drawing.Size(116, 20);
            this.txtSdate.TabIndex = 6;
            // 
            // txtPeriod
            // 
            this.txtPeriod.BackColor = System.Drawing.Color.Ivory;
            this.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPeriod.Enabled = false;
            this.txtPeriod.Location = new System.Drawing.Point(100, 19);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(117, 20);
            this.txtPeriod.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Methodology:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Forecast Period:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reporting Period:";
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(254, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 631);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // butToxml
            // 
            this.butToxml.Enabled = false;
            this.butToxml.Location = new System.Drawing.Point(129, 3);
            this.butToxml.Name = "butToxml";
            this.butToxml.Size = new System.Drawing.Size(87, 40);
            this.butToxml.TabIndex = 2;
            this.butToxml.Text = "Export To XML";
            this.butToxml.UseVisualStyleBackColor = true;
            this.butToxml.Click += new System.EventHandler(this.butToxml_Click);
            // 
            // butSummary
            // 
            this.butSummary.Enabled = false;
            this.butSummary.Location = new System.Drawing.Point(7, 3);
            this.butSummary.Name = "butSummary";
            this.butSummary.Size = new System.Drawing.Size(90, 40);
            this.butSummary.TabIndex = 0;
            this.butSummary.Text = "Show Summary";
            this.butSummary.UseVisualStyleBackColor = true;
            this.butSummary.Click += new System.EventHandler(this.butSummary_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LabelStyle.Format = "MMM yyyy";
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsDockedInsideChartArea = false;
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(44, 18);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.Legend = "Default";
            series1.Name = "Range";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 2;
            series2.BorderWidth = 2;
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series2.Legend = "Default";
            series2.Name = "Forecasting";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.ShadowOffset = 1;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.BorderWidth = 2;
            series3.ChartArea = "Default";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series3.Legend = "Default";
            series3.Name = "Input";
            series3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series3.ShadowOffset = 1;
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(182, 130);
            this.chart1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(258, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel6);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(780, 631);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.99254F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.00746F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel6.Controls.Add(this.panel7, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(780, 172);
            this.tableLayoutPanel6.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.butSummary);
            this.panel7.Controls.Add(this.butToxml);
            this.panel7.Controls.Add(this.groupBox4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(557, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(220, 166);
            this.panel7.TabIndex = 29;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtbInfo);
            this.groupBox4.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 121);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Info";
            // 
            // rtbInfo
            // 
            this.rtbInfo.BackColor = System.Drawing.SystemColors.Info;
            this.rtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInfo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInfo.ForeColor = System.Drawing.Color.Green;
            this.rtbInfo.Location = new System.Drawing.Point(4, 17);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(203, 86);
            this.rtbInfo.TabIndex = 0;
            this.rtbInfo.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRegressionType);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.txtPeriod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSdate);
            this.groupBox1.Controls.Add(this.txtMethodology);
            this.groupBox1.Controls.Add(this.txtDusage);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 166);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forecast Property";
            // 
            // txtRegressionType
            // 
            this.txtRegressionType.BackColor = System.Drawing.Color.Ivory;
            this.txtRegressionType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegressionType.Enabled = false;
            this.txtRegressionType.Location = new System.Drawing.Point(101, 111);
            this.txtRegressionType.Name = "txtRegressionType";
            this.txtRegressionType.Size = new System.Drawing.Size(116, 20);
            this.txtRegressionType.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Regression Type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Location = new System.Drawing.Point(101, 135);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(115, 20);
            this.txtStatus.TabIndex = 23;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.lblProgress);
            this.groupBox2.Controls.Add(this.butForecast);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cboOrder);
            this.groupBox2.Controls.Add(this.txtAddby);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtWestage);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboRegressionType);
            this.groupBox2.Controls.Add(this.txtExtension);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(219, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(332, 166);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Forecasting Parameters";
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(5, 151);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(313, 10);
            this.progressBar1.TabIndex = 25;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.SystemColors.Info;
            this.lblProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProgress.Location = new System.Drawing.Point(6, 134);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(312, 15);
            this.lblProgress.TabIndex = 26;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgress.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 455);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(780, 425);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabdashboard);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 415);
            this.tabControl1.TabIndex = 0;
            // 
            // tabdashboard
            // 
            this.tabdashboard.Location = new System.Drawing.Point(4, 22);
            this.tabdashboard.Name = "tabdashboard";
            this.tabdashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabdashboard.Size = new System.Drawing.Size(762, 389);
            this.tabdashboard.TabIndex = 0;
            this.tabdashboard.Text = "Forecast Summary";
            this.tabdashboard.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lnkshowmapesummary);
            this.panel2.Controls.Add(this.lblSelectedTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 24);
            this.panel2.TabIndex = 1;
            // 
            // lnkshowmapesummary
            // 
            this.lnkshowmapesummary.AutoSize = true;
            this.lnkshowmapesummary.Enabled = false;
            this.lnkshowmapesummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkshowmapesummary.Location = new System.Drawing.Point(889, 9);
            this.lnkshowmapesummary.Name = "lnkshowmapesummary";
            this.lnkshowmapesummary.Size = new System.Drawing.Size(130, 13);
            this.lnkshowmapesummary.TabIndex = 3;
            this.lnkshowmapesummary.TabStop = true;
            this.lnkshowmapesummary.Text = "Show MAPE Summary";
            this.lnkshowmapesummary.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkshowmapesummary_LinkClicked);
            // 
            // lblSelectedTitle
            // 
            this.lblSelectedTitle.AutoSize = true;
            this.lblSelectedTitle.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTitle.Location = new System.Drawing.Point(12, 9);
            this.lblSelectedTitle.Name = "lblSelectedTitle";
            this.lblSelectedTitle.Size = new System.Drawing.Size(0, 16);
            this.lblSelectedTitle.TabIndex = 0;
            // 
            // bwforecast
            // 
            this.bwforecast.WorkerReportsProgress = true;
            this.bwforecast.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwforecast_DoWork);
            this.bwforecast.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwforecast_RunWorkerCompleted);
            // 
            // ForecastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 631);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ForecastForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forecasting Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button butSummary;
        private System.Windows.Forms.Button butToxml;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAddby;
        private System.Windows.Forms.TextBox txtDusage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtWestage;
        private System.Windows.Forms.TextBox txtMethodology;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtSdate;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView treeViewlocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboRegressionType;
        private System.Windows.Forms.ComboBox cboOrder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comMethodologey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comForecastinfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button butForecast;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtRegressionType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblSelectedTitle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.LinkLabel lnkshowmapesummary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Panel panel7;
        private System.ComponentModel.BackgroundWorker bwforecast;
        private System.Windows.Forms.LinkLabel lnkCatInstUtilizaiton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabdashboard;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
