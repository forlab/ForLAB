
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.UserCtr
{
    partial class CDataUsage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine3 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvSite = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbtAddsite = new System.Windows.Forms.LinkLabel();
            this.lbtAddsiteall = new System.Windows.Forms.LinkLabel();
            this.lvSiteAll = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbtRemovesite = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lvProduct = new LQT.GUI.LQTListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbtAddMultipro = new System.Windows.Forms.LinkLabel();
            this.lbtImport = new System.Windows.Forms.LinkLabel();
            this.lbtRemoveproduct = new System.Windows.Forms.LinkLabel();
            this.lbtAddproduct = new System.Windows.Forms.LinkLabel();
            this.lbtAddduration = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalpcount = new System.Windows.Forms.TextBox();
            this.txttotalsite = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPcount = new System.Windows.Forms.TextBox();
            this.txtSitename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMedian = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDeviation = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(899, 484);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lvSite, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvSiteAll, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(220, 482);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvSite
            // 
            this.lvSite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSite.FullRowSelect = true;
            this.lvSite.GridLines = true;
            this.lvSite.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSite.HideSelection = false;
            this.lvSite.Location = new System.Drawing.Point(3, 225);
            this.lvSite.MultiSelect = false;
            this.lvSite.Name = "lvSite";
            this.lvSite.Size = new System.Drawing.Size(214, 254);
            this.lvSite.TabIndex = 4;
            this.lvSite.UseCompatibleStateImageBehavior = false;
            this.lvSite.View = System.Windows.Forms.View.Details;
            this.lvSite.SelectedIndexChanged += new System.EventHandler(this.lvSite_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Site Name";
            this.columnHeader1.Width = 208;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbtAddsite);
            this.panel2.Controls.Add(this.lbtAddsiteall);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 19);
            this.panel2.TabIndex = 1;
            // 
            // lbtAddsite
            // 
            this.lbtAddsite.AutoSize = true;
            this.lbtAddsite.Enabled = false;
            this.lbtAddsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtAddsite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtAddsite.Location = new System.Drawing.Point(141, 4);
            this.lbtAddsite.Name = "lbtAddsite";
            this.lbtAddsite.Size = new System.Drawing.Size(69, 13);
            this.lbtAddsite.TabIndex = 2;
            this.lbtAddsite.TabStop = true;
            this.lbtAddsite.Text = "Select Site";
            this.lbtAddsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddsite_LinkClicked);
            // 
            // lbtAddsiteall
            // 
            this.lbtAddsiteall.AutoSize = true;
            this.lbtAddsiteall.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtAddsiteall.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtAddsiteall.Location = new System.Drawing.Point(80, 4);
            this.lbtAddsiteall.Name = "lbtAddsiteall";
            this.lbtAddsiteall.Size = new System.Drawing.Size(61, 13);
            this.lbtAddsiteall.TabIndex = 2;
            this.lbtAddsiteall.TabStop = true;
            this.lbtAddsiteall.Text = "Select All";
            this.lbtAddsiteall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddsiteall_LinkClicked);
            // 
            // lvSiteAll
            // 
            this.lvSiteAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvSiteAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSiteAll.FullRowSelect = true;
            this.lvSiteAll.GridLines = true;
            this.lvSiteAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSiteAll.HideSelection = false;
            this.lvSiteAll.Location = new System.Drawing.Point(3, 28);
            this.lvSiteAll.Name = "lvSiteAll";
            this.lvSiteAll.Size = new System.Drawing.Size(214, 166);
            this.lvSiteAll.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvSiteAll.TabIndex = 3;
            this.lvSiteAll.UseCompatibleStateImageBehavior = false;
            this.lvSiteAll.View = System.Windows.Forms.View.Details;
            this.lvSiteAll.SelectedIndexChanged += new System.EventHandler(this.lvSiteAll_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "List of Sites";
            this.columnHeader2.Width = 208;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbtRemovesite);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 19);
            this.panel3.TabIndex = 5;
            // 
            // lbtRemovesite
            // 
            this.lbtRemovesite.AutoSize = true;
            this.lbtRemovesite.Enabled = false;
            this.lbtRemovesite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtRemovesite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtRemovesite.Location = new System.Drawing.Point(131, 5);
            this.lbtRemovesite.Name = "lbtRemovesite";
            this.lbtRemovesite.Size = new System.Drawing.Size(79, 13);
            this.lbtRemovesite.TabIndex = 1;
            this.lbtRemovesite.TabStop = true;
            this.lbtRemovesite.Text = "Remove Site";
            this.lbtRemovesite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtRemovesite_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selected Sites";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel1.Controls.Add(this.splitter1);
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(669, 482);
            this.splitContainer2.SplitterDistance = 384;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.lvProduct, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(669, 356);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // lvProduct
            // 
            this.lvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProduct.FullRowSelect = true;
            this.lvProduct.GridLines = true;
            this.lvProduct.Location = new System.Drawing.Point(0, 0);
            this.lvProduct.Margin = new System.Windows.Forms.Padding(0);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(669, 356);
            this.lvProduct.TabIndex = 10;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.View = System.Windows.Forms.View.Details;
            this.lvProduct.SelectedIndexChanged += new System.EventHandler(this.lvProduct_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(669, 3);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(669, 25);
            this.panel4.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbtAddMultipro);
            this.panel6.Controls.Add(this.lbtImport);
            this.panel6.Controls.Add(this.lbtRemoveproduct);
            this.panel6.Controls.Add(this.lbtAddproduct);
            this.panel6.Controls.Add(this.lbtAddduration);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(53, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(616, 25);
            this.panel6.TabIndex = 4;
            // 
            // lbtAddMultipro
            // 
            this.lbtAddMultipro.AutoSize = true;
            this.lbtAddMultipro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtAddMultipro.ForeColor = System.Drawing.Color.Navy;
            this.lbtAddMultipro.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtAddMultipro.Location = new System.Drawing.Point(112, 6);
            this.lbtAddMultipro.Name = "lbtAddMultipro";
            this.lbtAddMultipro.Size = new System.Drawing.Size(134, 13);
            this.lbtAddMultipro.TabIndex = 4;
            this.lbtAddMultipro.TabStop = true;
            this.lbtAddMultipro.Text = "Add Product and Sites";
            this.lbtAddMultipro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddMultipro_LinkClicked);
            // 
            // lbtImport
            // 
            this.lbtImport.AutoSize = true;
            this.lbtImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtImport.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtImport.Location = new System.Drawing.Point(-4, 6);
            this.lbtImport.Name = "lbtImport";
            this.lbtImport.Size = new System.Drawing.Size(118, 13);
            this.lbtImport.TabIndex = 3;
            this.lbtImport.TabStop = true;
            this.lbtImport.Text = "Import Consumption";
            this.lbtImport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtImport_LinkClicked);
            // 
            // lbtRemoveproduct
            // 
            this.lbtRemoveproduct.AutoSize = true;
            this.lbtRemoveproduct.Enabled = false;
            this.lbtRemoveproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtRemoveproduct.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtRemoveproduct.Location = new System.Drawing.Point(485, 6);
            this.lbtRemoveproduct.Name = "lbtRemoveproduct";
            this.lbtRemoveproduct.Size = new System.Drawing.Size(129, 13);
            this.lbtRemoveproduct.TabIndex = 0;
            this.lbtRemoveproduct.TabStop = true;
            this.lbtRemoveproduct.Text = "Remove Consumption";
            this.lbtRemoveproduct.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtRemoveproduct_LinkClicked);
            // 
            // lbtAddproduct
            // 
            this.lbtAddproduct.AutoSize = true;
            this.lbtAddproduct.Enabled = false;
            this.lbtAddproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtAddproduct.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtAddproduct.Location = new System.Drawing.Point(246, 6);
            this.lbtAddproduct.Name = "lbtAddproduct";
            this.lbtAddproduct.Size = new System.Drawing.Size(95, 13);
            this.lbtAddproduct.TabIndex = 0;
            this.lbtAddproduct.TabStop = true;
            this.lbtAddproduct.Text = "Add By Product";
            this.lbtAddproduct.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddproduct_LinkClicked);
            // 
            // lbtAddduration
            // 
            this.lbtAddduration.AutoSize = true;
            this.lbtAddduration.Enabled = false;
            this.lbtAddduration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtAddduration.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtAddduration.Location = new System.Drawing.Point(342, 6);
            this.lbtAddduration.Name = "lbtAddduration";
            this.lbtAddduration.Size = new System.Drawing.Size(145, 13);
            this.lbtAddduration.TabIndex = 2;
            this.lbtAddduration.TabStop = true;
            this.lbtAddduration.Text = "Add Actual Consumption";
            this.lbtAddduration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddduration_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Product Consumption";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTotalpcount);
            this.groupBox2.Controls.Add(this.txttotalsite);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(417, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 92);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Forecast summary";
            // 
            // txtTotalpcount
            // 
            this.txtTotalpcount.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalpcount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalpcount.Enabled = false;
            this.txtTotalpcount.Location = new System.Drawing.Point(140, 43);
            this.txtTotalpcount.Name = "txtTotalpcount";
            this.txtTotalpcount.ReadOnly = true;
            this.txtTotalpcount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalpcount.TabIndex = 12;
            // 
            // txttotalsite
            // 
            this.txttotalsite.BackColor = System.Drawing.SystemColors.Info;
            this.txttotalsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotalsite.Enabled = false;
            this.txttotalsite.Location = new System.Drawing.Point(140, 20);
            this.txttotalsite.Name = "txttotalsite";
            this.txttotalsite.ReadOnly = true;
            this.txttotalsite.Size = new System.Drawing.Size(100, 20);
            this.txttotalsite.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "Total Product Count:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 9;
            this.label8.Text = "Total Sites:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPcount);
            this.groupBox1.Controls.Add(this.txtSitename);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 92);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Site summary";
            // 
            // txtPcount
            // 
            this.txtPcount.BackColor = System.Drawing.SystemColors.Info;
            this.txtPcount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPcount.Enabled = false;
            this.txtPcount.Location = new System.Drawing.Point(99, 44);
            this.txtPcount.Name = "txtPcount";
            this.txtPcount.ReadOnly = true;
            this.txtPcount.Size = new System.Drawing.Size(100, 20);
            this.txtPcount.TabIndex = 8;
            // 
            // txtSitename
            // 
            this.txtSitename.BackColor = System.Drawing.SystemColors.Info;
            this.txtSitename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSitename.Enabled = false;
            this.txtSitename.Location = new System.Drawing.Point(99, 21);
            this.txtSitename.Name = "txtSitename";
            this.txtSitename.ReadOnly = true;
            this.txtSitename.Size = new System.Drawing.Size(230, 20);
            this.txtSitename.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Active Site:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Product Count:";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Reporting Period";
            this.columnHeader11.Width = 114;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Amount Used";
            this.columnHeader10.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Stock Out";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Adjusted";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Note";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.lblMedian);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblDeviation);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblMean);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(404, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 234);
            this.panel1.TabIndex = 11;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(64)))), ((int)(((byte)(1)))));
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
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX2.LabelStyle.Interval = 0D;
            chartArea1.AxisX2.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX2.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorGrid.Interval = 0D;
            chartArea1.AxisX2.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX2.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorTickMark.Interval = 0D;
            chartArea1.AxisX2.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisX2.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorTickMark.Interval = 0D;
            chartArea1.AxisY.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisY.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            stripLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(241)))), ((int)(((byte)(185)))), ((int)(((byte)(168)))));
            stripLine1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stripLine1.IntervalOffset = 20D;
            stripLine1.StripWidth = 50D;
            stripLine1.Text = "Standard Deviation";
            stripLine1.TextLineAlignment = System.Drawing.StringAlignment.Far;
            stripLine2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            stripLine2.BorderWidth = 2;
            stripLine2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stripLine2.IntervalOffset = 40D;
            stripLine2.Text = "Mean";
            stripLine2.TextLineAlignment = System.Drawing.StringAlignment.Far;
            stripLine3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            stripLine3.BorderWidth = 2;
            stripLine3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stripLine3.IntervalOffset = 50D;
            stripLine3.Text = "Median";
            stripLine3.TextAlignment = System.Drawing.StringAlignment.Near;
            stripLine3.TextLineAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.StripLines.Add(stripLine1);
            chartArea1.AxisY.StripLines.Add(stripLine2);
            chartArea1.AxisY.StripLines.Add(stripLine3);
            chartArea1.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY2.LabelStyle.Interval = 0D;
            chartArea1.AxisY2.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisY2.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorGrid.Interval = 0D;
            chartArea1.AxisY2.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisY2.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorTickMark.Interval = 0D;
            chartArea1.AxisY2.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisY2.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.BackColor = System.Drawing.Color.Ivory;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            legend1.Position.Auto = false;
            legend1.Position.Height = 15F;
            legend1.Position.Width = 30F;
            legend1.Position.X = 63F;
            legend1.Position.Y = 5F;
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.BorderWidth = 2;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.CustomProperties = "LabelStyle=\"down\"";
            series1.Legend = "Default";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.ShadowOffset = 1;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(262, 238);
            this.chart1.TabIndex = 26;
            title1.Name = "Title1";
            title1.Text = "Title";
            this.chart1.Titles.Add(title1);
            // 
            // lblMedian
            // 
            this.lblMedian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMedian.Location = new System.Drawing.Point(117, 287);
            this.lblMedian.Name = "lblMedian";
            this.lblMedian.Size = new System.Drawing.Size(60, 20);
            this.lblMedian.TabIndex = 25;
            this.lblMedian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(17, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Median:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeviation
            // 
            this.lblDeviation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDeviation.Location = new System.Drawing.Point(117, 264);
            this.lblDeviation.Name = "lblDeviation";
            this.lblDeviation.Size = new System.Drawing.Size(60, 20);
            this.lblDeviation.TabIndex = 23;
            this.lblDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(10, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 23);
            this.label11.TabIndex = 22;
            this.label11.Text = "Standard Deviation:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMean
            // 
            this.lblMean.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMean.Location = new System.Drawing.Point(117, 241);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(60, 20);
            this.lblMean.TabIndex = 21;
            this.lblMean.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(10, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 23);
            this.label13.TabIndex = 20;
            this.label13.Text = "Mean:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Instrument Downtime";
            this.columnHeader4.Width = 112;
            // 
            // CDataUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CDataUsage";
            this.Size = new System.Drawing.Size(899, 484);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvSite;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvSiteAll;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.LinkLabel lbtAddsite;
        private System.Windows.Forms.LinkLabel lbtAddsiteall;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel lbtRemovesite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private LQTListView lvProduct;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel lbtImport;
        private System.Windows.Forms.LinkLabel lbtAddproduct;
        private System.Windows.Forms.LinkLabel lbtAddduration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lbtRemoveproduct;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPcount;
        private System.Windows.Forms.TextBox txtSitename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotalpcount;
        private System.Windows.Forms.TextBox txttotalsite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.LinkLabel lbtAddMultipro;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMedian;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDeviation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
