
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

namespace LQT.GUI.MorbidityUserCtr
{
    partial class SiteTargetCalculatorPreART
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteTargetCalculatorPreART));
            this.txtRecent = new System.Windows.Forms.TextBox();
            this.txtJaunary = new System.Windows.Forms.TextBox();
            this.txtFebruary = new System.Windows.Forms.TextBox();
            this.txtDecember = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butLinear = new System.Windows.Forms.Button();
            this.butPedatric = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPediatric = new System.Windows.Forms.TextBox();
            this.lblAnualgrowth = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNovember = new System.Windows.Forms.TextBox();
            this.txtOctober = new System.Windows.Forms.TextBox();
            this.txtSeptember = new System.Windows.Forms.TextBox();
            this.txtAgust = new System.Windows.Forms.TextBox();
            this.txtJuly = new System.Windows.Forms.TextBox();
            this.txtJune = new System.Windows.Forms.TextBox();
            this.txtMay = new System.Windows.Forms.TextBox();
            this.txtApril = new System.Windows.Forms.TextBox();
            this.txtMarch = new System.Windows.Forms.TextBox();
            this.label0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trueFalseImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRecent
            // 
            this.txtRecent.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtRecent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecent.Location = new System.Drawing.Point(1, 30);
            this.txtRecent.Margin = new System.Windows.Forms.Padding(0);
            this.txtRecent.Name = "txtRecent";
            this.txtRecent.ReadOnly = true;
            this.txtRecent.Size = new System.Drawing.Size(45, 20);
            this.txtRecent.TabIndex = 0;
            // 
            // txtJaunary
            // 
            this.txtJaunary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtJaunary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJaunary.Location = new System.Drawing.Point(48, 30);
            this.txtJaunary.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtJaunary.Name = "txtJaunary";
            this.txtJaunary.Size = new System.Drawing.Size(44, 20);
            this.txtJaunary.TabIndex = 1;
            this.txtJaunary.Tag = "1";
            this.txtJaunary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtFebruary
            // 
            this.txtFebruary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFebruary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFebruary.Location = new System.Drawing.Point(94, 30);
            this.txtFebruary.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtFebruary.Name = "txtFebruary";
            this.txtFebruary.Size = new System.Drawing.Size(44, 20);
            this.txtFebruary.TabIndex = 2;
            this.txtFebruary.Tag = "2";
            this.txtFebruary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtDecember
            // 
            this.txtDecember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDecember.Location = new System.Drawing.Point(554, 30);
            this.txtDecember.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtDecember.Name = "txtDecember";
            this.txtDecember.Size = new System.Drawing.Size(45, 20);
            this.txtDecember.TabIndex = 12;
            this.txtDecember.Tag = "12";
            this.txtDecember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butLinear);
            this.groupBox1.Controls.Add(this.butPedatric);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtPediatric);
            this.groupBox1.Controls.Add(this.lblAnualgrowth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "National Treatment Target";
            // 
            // butLinear
            // 
            this.butLinear.Location = new System.Drawing.Point(395, 76);
            this.butLinear.Name = "butLinear";
            this.butLinear.Size = new System.Drawing.Size(211, 45);
            this.butLinear.TabIndex = 6;
            this.butLinear.Text = "Calculate linear scale-up between \r\nDecember 2010 and December 2011";
            this.butLinear.UseVisualStyleBackColor = true;
            this.butLinear.Click += new System.EventHandler(this.butLinear_Click);
            // 
            // butPedatric
            // 
            this.butPedatric.Location = new System.Drawing.Point(212, 76);
            this.butPedatric.Name = "butPedatric";
            this.butPedatric.Size = new System.Drawing.Size(139, 45);
            this.butPedatric.TabIndex = 5;
            this.butPedatric.Text = "Apply Pediatric % \r\nto All Sites";
            this.butPedatric.UseVisualStyleBackColor = true;
            this.butPedatric.Click += new System.EventHandler(this.butPedatric_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(154, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "% of Patients Who Are Children";
            // 
            // txtPediatric
            // 
            this.txtPediatric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPediatric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPediatric.Location = new System.Drawing.Point(166, 90);
            this.txtPediatric.Name = "txtPediatric";
            this.txtPediatric.Size = new System.Drawing.Size(40, 20);
            this.txtPediatric.TabIndex = 3;
            this.txtPediatric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // lblAnualgrowth
            // 
            this.lblAnualgrowth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnualgrowth.Location = new System.Drawing.Point(612, 49);
            this.lblAnualgrowth.Name = "lblAnualgrowth";
            this.lblAnualgrowth.Size = new System.Drawing.Size(41, 20);
            this.lblAnualgrowth.TabIndex = 2;
            this.lblAnualgrowth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(612, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 26);
            this.label14.TabIndex = 1;
            this.label14.Text = "Anual \r\nGrowth";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.Controls.Add(this.txtRecent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtJaunary, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFebruary, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDecember, 12, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNovember, 11, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtOctober, 10, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSeptember, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAgust, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtJuly, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtJune, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMay, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtApril, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMarch, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label0, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 12, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtNovember
            // 
            this.txtNovember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNovember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNovember.Location = new System.Drawing.Point(508, 30);
            this.txtNovember.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtNovember.Name = "txtNovember";
            this.txtNovember.Size = new System.Drawing.Size(44, 20);
            this.txtNovember.TabIndex = 11;
            this.txtNovember.Tag = "11";
            this.txtNovember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtOctober
            // 
            this.txtOctober.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtOctober.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOctober.Location = new System.Drawing.Point(462, 30);
            this.txtOctober.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtOctober.Name = "txtOctober";
            this.txtOctober.Size = new System.Drawing.Size(44, 20);
            this.txtOctober.TabIndex = 10;
            this.txtOctober.Tag = "10";
            this.txtOctober.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtSeptember
            // 
            this.txtSeptember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSeptember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeptember.Location = new System.Drawing.Point(416, 30);
            this.txtSeptember.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtSeptember.Name = "txtSeptember";
            this.txtSeptember.Size = new System.Drawing.Size(44, 20);
            this.txtSeptember.TabIndex = 9;
            this.txtSeptember.Tag = "9";
            this.txtSeptember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtAgust
            // 
            this.txtAgust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAgust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgust.Location = new System.Drawing.Point(370, 30);
            this.txtAgust.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtAgust.Name = "txtAgust";
            this.txtAgust.Size = new System.Drawing.Size(44, 20);
            this.txtAgust.TabIndex = 8;
            this.txtAgust.Tag = "8";
            this.txtAgust.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtJuly
            // 
            this.txtJuly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtJuly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJuly.Location = new System.Drawing.Point(324, 30);
            this.txtJuly.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtJuly.Name = "txtJuly";
            this.txtJuly.Size = new System.Drawing.Size(44, 20);
            this.txtJuly.TabIndex = 7;
            this.txtJuly.Tag = "7";
            this.txtJuly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtJune
            // 
            this.txtJune.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtJune.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJune.Location = new System.Drawing.Point(278, 30);
            this.txtJune.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtJune.Name = "txtJune";
            this.txtJune.Size = new System.Drawing.Size(44, 20);
            this.txtJune.TabIndex = 6;
            this.txtJune.Tag = "6";
            this.txtJune.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtMay
            // 
            this.txtMay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMay.Location = new System.Drawing.Point(232, 30);
            this.txtMay.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtMay.Name = "txtMay";
            this.txtMay.Size = new System.Drawing.Size(44, 20);
            this.txtMay.TabIndex = 5;
            this.txtMay.Tag = "5";
            this.txtMay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtApril
            // 
            this.txtApril.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtApril.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApril.Location = new System.Drawing.Point(186, 30);
            this.txtApril.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtApril.Name = "txtApril";
            this.txtApril.Size = new System.Drawing.Size(44, 20);
            this.txtApril.TabIndex = 4;
            this.txtApril.Tag = "4";
            this.txtApril.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtMarch
            // 
            this.txtMarch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMarch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarch.Location = new System.Drawing.Point(140, 30);
            this.txtMarch.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtMarch.Name = "txtMarch";
            this.txtMarch.Size = new System.Drawing.Size(44, 20);
            this.txtMarch.TabIndex = 3;
            this.txtMarch.Tag = "3";
            this.txtMarch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // label0
            // 
            this.label0.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label0.Location = new System.Drawing.Point(1, 1);
            this.label0.Margin = new System.Windows.Forms.Padding(0);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(45, 28);
            this.label0.TabIndex = 13;
            this.label0.Text = "December";
            this.label0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(47, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 28);
            this.label1.TabIndex = 14;
            this.label1.Text = "January";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(93, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 28);
            this.label2.TabIndex = 15;
            this.label2.Text = "February";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(139, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 28);
            this.label3.TabIndex = 16;
            this.label3.Text = "March";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(185, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 28);
            this.label4.TabIndex = 17;
            this.label4.Text = "April";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(231, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 28);
            this.label5.TabIndex = 18;
            this.label5.Text = "May";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(277, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 28);
            this.label6.TabIndex = 19;
            this.label6.Text = "June";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(323, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 28);
            this.label7.TabIndex = 20;
            this.label7.Text = "July";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(369, 1);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 28);
            this.label8.TabIndex = 21;
            this.label8.Text = "August";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(415, 1);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 28);
            this.label9.TabIndex = 22;
            this.label9.Text = "September";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(461, 1);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 28);
            this.label10.TabIndex = 23;
            this.label10.Text = "October";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(507, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 28);
            this.label11.TabIndex = 24;
            this.label11.Text = "November";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(553, 1);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 28);
            this.label12.TabIndex = 25;
            this.label12.Text = "December";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(671, 400);
            this.splitContainer1.SplitterDistance = 141;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // trueFalseImageList
            // 
            this.trueFalseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("trueFalseImageList.ImageStream")));
            this.trueFalseImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.trueFalseImageList.Images.SetKeyName(0, "checked.png");
            this.trueFalseImageList.Images.SetKeyName(1, "unchecked.png");
            this.trueFalseImageList.Images.SetKeyName(2, "down.png");
            this.trueFalseImageList.Images.SetKeyName(3, "up.png");
            // 
            // SiteTargetCalculatorPreART
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SiteTargetCalculatorPreART";
            this.Size = new System.Drawing.Size(671, 400);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecent;
        private System.Windows.Forms.TextBox txtJaunary;
        private System.Windows.Forms.TextBox txtFebruary;
        private System.Windows.Forms.TextBox txtDecember;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butLinear;
        private System.Windows.Forms.Button butPedatric;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPediatric;
        private System.Windows.Forms.Label lblAnualgrowth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtNovember;
        private System.Windows.Forms.TextBox txtOctober;
        private System.Windows.Forms.TextBox txtSeptember;
        private System.Windows.Forms.TextBox txtAgust;
        private System.Windows.Forms.TextBox txtJuly;
        private System.Windows.Forms.TextBox txtJune;
        private System.Windows.Forms.TextBox txtMay;
        private System.Windows.Forms.TextBox txtApril;
        private System.Windows.Forms.TextBox txtMarch;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList trueFalseImageList;
    }
}
