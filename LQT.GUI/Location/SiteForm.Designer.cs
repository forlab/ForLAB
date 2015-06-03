
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.Location
{
    partial class SiteForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lqtToolStrip1 = new LQT.GUI.UserCtr.LqtToolStrip();
            this.txtworkingdays = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOtherTd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtViralTd = new System.Windows.Forms.TextBox();
            this.txthemaTd = new System.Windows.Forms.TextBox();
            this.lbtEditstatus = new System.Windows.Forms.LinkLabel();
            this.txtChemTd = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbtClose = new System.Windows.Forms.LinkLabel();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbtOpen = new System.Windows.Forms.LinkLabel();
            this.lsvStatus = new System.Windows.Forms.ListView();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvInstrument = new LQT.GUI.LQTListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbtRemove = new System.Windows.Forms.LinkLabel();
            this.lbtAddins = new System.Windows.Forms.LinkLabel();
            this.txtCd4Td = new System.Windows.Forms.TextBox();
            this.comRegion = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comsitelevel = new System.Windows.Forms.ComboBox();
            this.comViralLoadRefSite = new LQT.GUI.UserCtr.comReferalSite();
            this.comHematologyRefSite = new LQT.GUI.UserCtr.comReferalSite();
            this.comOtheRefSite = new LQT.GUI.UserCtr.comReferalSite();
            this.comChemistryRefSite = new LQT.GUI.UserCtr.comReferalSite();
            this.comCD4RefSite = new LQT.GUI.UserCtr.comReferalSite();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lqtToolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.900523F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.09948F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 40);
            this.tableLayoutPanel1.TabIndex = 234;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(772, 34);
            this.lqtToolStrip1.TabIndex = 266;
            this.lqtToolStrip1.TabStop = false;
            // 
            // txtworkingdays
            // 
            this.txtworkingdays.Location = new System.Drawing.Point(184, 131);
            this.txtworkingdays.MaxLength = 64;
            this.txtworkingdays.Name = "txtworkingdays";
            this.txtworkingdays.Size = new System.Drawing.Size(139, 20);
            this.txtworkingdays.TabIndex = 4;
            this.txtworkingdays.Text = "22";
            this.txtworkingdays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCd4Td_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 13);
            this.label18.TabIndex = 725;
            this.label18.Text = "General Working Days\\Month:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 269;
            this.label12.Text = "Hematology:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(10, 337);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 289;
            this.label16.Text = "Referral Sites";
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(93, 344);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(230, 2);
            this.label17.TabIndex = 263;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 262;
            this.label10.Text = "ViralLoad:";
            // 
            // txtOtherTd
            // 
            this.txtOtherTd.Location = new System.Drawing.Point(140, 312);
            this.txtOtherTd.Name = "txtOtherTd";
            this.txtOtherTd.Size = new System.Drawing.Size(183, 20);
            this.txtOtherTd.TabIndex = 10;
            this.txtOtherTd.Text = "0";
            this.txtOtherTd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCd4Td_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 436);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 268;
            this.label11.Text = "ViralLoad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 264);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 260;
            this.label9.Text = "Hematology:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 259;
            this.label8.Text = "Chemistry:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 386);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 267;
            this.label13.Text = "Chemistry:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 258;
            this.label7.Text = "CD4:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 361);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 266;
            this.label14.Text = "CD4:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(10, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 278;
            this.label4.Text = "Testing Days per Month";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 461);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 13);
            this.label15.TabIndex = 625;
            this.label15.Text = "Other:";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(141, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 2);
            this.label6.TabIndex = 256;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 255;
            this.label3.Text = "Other:";
            // 
            // txtViralTd
            // 
            this.txtViralTd.Location = new System.Drawing.Point(140, 287);
            this.txtViralTd.Name = "txtViralTd";
            this.txtViralTd.Size = new System.Drawing.Size(183, 20);
            this.txtViralTd.TabIndex = 9;
            this.txtViralTd.Text = "0";
            this.txtViralTd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCd4Td_KeyPress);
            // 
            // txthemaTd
            // 
            this.txthemaTd.Location = new System.Drawing.Point(140, 261);
            this.txthemaTd.Name = "txthemaTd";
            this.txthemaTd.Size = new System.Drawing.Size(183, 20);
            this.txthemaTd.TabIndex = 8;
            this.txthemaTd.Text = "0";
            this.txthemaTd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCd4Td_KeyPress);
            // 
            // lbtEditstatus
            // 
            this.lbtEditstatus.AutoSize = true;
            this.lbtEditstatus.Enabled = false;
            this.lbtEditstatus.Location = new System.Drawing.Point(45, 16);
            this.lbtEditstatus.Name = "lbtEditstatus";
            this.lbtEditstatus.Size = new System.Drawing.Size(25, 13);
            this.lbtEditstatus.TabIndex = 17;
            this.lbtEditstatus.TabStop = true;
            this.lbtEditstatus.Text = "Edit";
            this.lbtEditstatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtEditstatus_LinkClicked);
            // 
            // txtChemTd
            // 
            this.txtChemTd.Location = new System.Drawing.Point(140, 235);
            this.txtChemTd.Name = "txtChemTd";
            this.txtChemTd.Size = new System.Drawing.Size(183, 20);
            this.txtChemTd.TabIndex = 7;
            this.txtChemTd.Text = "0";
            this.txtChemTd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCd4Td_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Opened On";
            this.columnHeader1.Width = 217;
            // 
            // lbtClose
            // 
            this.lbtClose.AutoSize = true;
            this.lbtClose.Enabled = false;
            this.lbtClose.Location = new System.Drawing.Point(76, 16);
            this.lbtClose.Name = "lbtClose";
            this.lbtClose.Size = new System.Drawing.Size(33, 13);
            this.lbtClose.TabIndex = 18;
            this.lbtClose.TabStop = true;
            this.lbtClose.Text = "Close";
            this.lbtClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtClose_LinkClicked);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Closed On";
            this.columnHeader5.Width = 224;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbtClose);
            this.groupBox2.Controls.Add(this.lbtEditstatus);
            this.groupBox2.Controls.Add(this.lbtOpen);
            this.groupBox2.Controls.Add(this.lsvStatus);
            this.groupBox2.Location = new System.Drawing.Point(355, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 136);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Site Status";
            // 
            // lbtOpen
            // 
            this.lbtOpen.AutoSize = true;
            this.lbtOpen.Location = new System.Drawing.Point(6, 16);
            this.lbtOpen.Name = "lbtOpen";
            this.lbtOpen.Size = new System.Drawing.Size(33, 13);
            this.lbtOpen.TabIndex = 16;
            this.lbtOpen.TabStop = true;
            this.lbtOpen.Text = "Open";
            this.lbtOpen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtOpen_LinkClicked);
            // 
            // lsvStatus
            // 
            this.lsvStatus.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5});
            this.lsvStatus.FullRowSelect = true;
            this.lsvStatus.GridLines = true;
            this.lsvStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvStatus.Location = new System.Drawing.Point(6, 33);
            this.lsvStatus.MultiSelect = false;
            this.lsvStatus.Name = "lsvStatus";
            this.lsvStatus.Size = new System.Drawing.Size(473, 95);
            this.lsvStatus.TabIndex = 0;
            this.lsvStatus.TabStop = false;
            this.lsvStatus.UseCompatibleStateImageBehavior = false;
            this.lsvStatus.View = System.Windows.Forms.View.Details;
            this.lsvStatus.SelectedIndexChanged += new System.EventHandler(this.lsvStatus_SelectedIndexChanged);
            // 
            // comCategory
            // 
            this.comCategory.DisplayMember = "CategoryName";
            this.comCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(140, 104);
            this.comCategory.Name = "comCategory";
            this.comCategory.Size = new System.Drawing.Size(183, 21);
            this.comCategory.TabIndex = 3;
            this.comCategory.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 249;
            this.label2.Text = "Site Category:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvInstrument);
            this.groupBox1.Controls.Add(this.lbtRemove);
            this.groupBox1.Controls.Add(this.lbtAddins);
            this.groupBox1.Location = new System.Drawing.Point(355, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 287);
            this.groupBox1.TabIndex = 200;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instrument List";
            // 
            // lsvInstrument
            // 
            this.lsvInstrument.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvInstrument.FullRowSelect = true;
            this.lsvInstrument.GridLines = true;
            this.lsvInstrument.Location = new System.Drawing.Point(6, 32);
            this.lsvInstrument.Name = "lsvInstrument";
            this.lsvInstrument.Size = new System.Drawing.Size(473, 249);
            this.lsvInstrument.TabIndex = 310;
            this.lsvInstrument.TabStop = false;
            this.lsvInstrument.UseCompatibleStateImageBehavior = false;
            this.lsvInstrument.View = System.Windows.Forms.View.Details;
            this.lsvInstrument.SelectedIndexChanged += new System.EventHandler(this.lsvInstrument_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Testing Area";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Instrument Name";
            this.columnHeader2.Width = 146;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.Width = 53;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "% Tests Run";
            this.columnHeader4.Width = 72;
            // 
            // lbtRemove
            // 
            this.lbtRemove.AutoSize = true;
            this.lbtRemove.Enabled = false;
            this.lbtRemove.Location = new System.Drawing.Point(90, 16);
            this.lbtRemove.Name = "lbtRemove";
            this.lbtRemove.Size = new System.Drawing.Size(47, 13);
            this.lbtRemove.TabIndex = 20;
            this.lbtRemove.TabStop = true;
            this.lbtRemove.Text = "Remove";
            this.lbtRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtRemove_LinkClicked);
            // 
            // lbtAddins
            // 
            this.lbtAddins.AutoSize = true;
            this.lbtAddins.Location = new System.Drawing.Point(6, 16);
            this.lbtAddins.Name = "lbtAddins";
            this.lbtAddins.Size = new System.Drawing.Size(78, 13);
            this.lbtAddins.TabIndex = 19;
            this.lbtAddins.TabStop = true;
            this.lbtAddins.Text = "Add Instrument";
            this.lbtAddins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddins_LinkClicked);
            // 
            // txtCd4Td
            // 
            this.txtCd4Td.Location = new System.Drawing.Point(140, 209);
            this.txtCd4Td.Name = "txtCd4Td";
            this.txtCd4Td.Size = new System.Drawing.Size(183, 20);
            this.txtCd4Td.TabIndex = 6;
            this.txtCd4Td.Text = "0";
            this.txtCd4Td.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCd4Td_KeyPress);
            // 
            // comRegion
            // 
            this.comRegion.DisplayMember = "RegionName";
            this.comRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comRegion.FormattingEnabled = true;
            this.comRegion.Location = new System.Drawing.Point(140, 77);
            this.comRegion.Name = "comRegion";
            this.comRegion.Size = new System.Drawing.Size(183, 21);
            this.comRegion.TabIndex = 2;
            this.comRegion.ValueMember = "Id";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(140, 51);
            this.txtName.MaxLength = 64;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 20);
            this.txtName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 246;
            this.label5.Text = "Region/District/Province";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 243;
            this.label1.Text = "Site Name:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 166);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 277;
            this.label19.Text = "Site Level";
            // 
            // comsitelevel
            // 
            this.comsitelevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comsitelevel.FormattingEnabled = true;
            this.comsitelevel.Location = new System.Drawing.Point(140, 163);
            this.comsitelevel.Name = "comsitelevel";
            this.comsitelevel.Size = new System.Drawing.Size(181, 21);
            this.comsitelevel.TabIndex = 5;
            // 
            // comViralLoadRefSite
            // 
            this.comViralLoadRefSite.Location = new System.Drawing.Point(140, 432);
            this.comViralLoadRefSite.Name = "comViralLoadRefSite";
            this.comViralLoadRefSite.Size = new System.Drawing.Size(184, 23);
            this.comViralLoadRefSite.TabIndex = 14;
            this.comViralLoadRefSite.Tag = 0;
            // 
            // comHematologyRefSite
            // 
            this.comHematologyRefSite.Location = new System.Drawing.Point(140, 405);
            this.comHematologyRefSite.Name = "comHematologyRefSite";
            this.comHematologyRefSite.Size = new System.Drawing.Size(184, 23);
            this.comHematologyRefSite.TabIndex = 13;
            this.comHematologyRefSite.Tag = 0;
            // 
            // comOtheRefSite
            // 
            this.comOtheRefSite.Location = new System.Drawing.Point(140, 460);
            this.comOtheRefSite.Name = "comOtheRefSite";
            this.comOtheRefSite.Size = new System.Drawing.Size(184, 23);
            this.comOtheRefSite.TabIndex = 15;
            this.comOtheRefSite.Tag = 0;
            // 
            // comChemistryRefSite
            // 
            this.comChemistryRefSite.Location = new System.Drawing.Point(140, 379);
            this.comChemistryRefSite.Name = "comChemistryRefSite";
            this.comChemistryRefSite.Size = new System.Drawing.Size(184, 23);
            this.comChemistryRefSite.TabIndex = 12;
            this.comChemistryRefSite.Tag = 0;
            // 
            // comCD4RefSite
            // 
            this.comCD4RefSite.Location = new System.Drawing.Point(140, 353);
            this.comCD4RefSite.Name = "comCD4RefSite";
            this.comCD4RefSite.Size = new System.Drawing.Size(184, 23);
            this.comCD4RefSite.TabIndex = 11;
            this.comCD4RefSite.Tag = 0;
            // 
            // SiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 489);
            this.Controls.Add(this.comsitelevel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtworkingdays);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comViralLoadRefSite);
            this.Controls.Add(this.comHematologyRefSite);
            this.Controls.Add(this.comOtheRefSite);
            this.Controls.Add(this.comChemistryRefSite);
            this.Controls.Add(this.comCD4RefSite);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOtherTd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtViralTd);
            this.Controls.Add(this.txthemaTd);
            this.Controls.Add(this.txtChemTd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCd4Td);
            this.Controls.Add(this.comRegion);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SiteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Site";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiteForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.TextBox txtworkingdays;
        private System.Windows.Forms.Label label18;
        private UserCtr.comReferalSite comViralLoadRefSite;
        private UserCtr.comReferalSite comHematologyRefSite;
        private UserCtr.comReferalSite comOtheRefSite;
        private UserCtr.comReferalSite comChemistryRefSite;
        private UserCtr.comReferalSite comCD4RefSite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOtherTd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtViralTd;
        private System.Windows.Forms.TextBox txthemaTd;
        private System.Windows.Forms.LinkLabel lbtEditstatus;
        private System.Windows.Forms.TextBox txtChemTd;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.LinkLabel lbtClose;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lbtOpen;
        private System.Windows.Forms.ListView lsvStatus;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private LQTListView lsvInstrument;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.LinkLabel lbtRemove;
        private System.Windows.Forms.LinkLabel lbtAddins;
        private System.Windows.Forms.TextBox txtCd4Td;
        private System.Windows.Forms.ComboBox comRegion;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comsitelevel;
       // private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
