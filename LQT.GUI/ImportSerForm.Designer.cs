
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
    partial class ImportSerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtForecastid = new System.Windows.Forms.TextBox();
            this.txtDusage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMethodology = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSdate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvImport = new System.Windows.Forms.ListView();
            this.colRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSitename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStockout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDowntime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.butClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.butImport = new System.Windows.Forms.Button();
            this.butBrowse = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtForecastid);
            this.groupBox1.Controls.Add(this.txtDusage);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMethodology);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPeriod);
            this.groupBox1.Controls.Add(this.txtExtension);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSdate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 91);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forecast Information ";
            // 
            // txtForecastid
            // 
            this.txtForecastid.BackColor = System.Drawing.Color.Ivory;
            this.txtForecastid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtForecastid.Enabled = false;
            this.txtForecastid.Location = new System.Drawing.Point(110, 27);
            this.txtForecastid.Name = "txtForecastid";
            this.txtForecastid.Size = new System.Drawing.Size(149, 20);
            this.txtForecastid.TabIndex = 25;
            // 
            // txtDusage
            // 
            this.txtDusage.BackColor = System.Drawing.Color.Ivory;
            this.txtDusage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDusage.Enabled = false;
            this.txtDusage.Location = new System.Drawing.Point(637, 59);
            this.txtDusage.Name = "txtDusage";
            this.txtDusage.Size = new System.Drawing.Size(149, 20);
            this.txtDusage.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(557, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Data Usage:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forecast ID:";
            // 
            // txtMethodology
            // 
            this.txtMethodology.BackColor = System.Drawing.Color.Ivory;
            this.txtMethodology.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMethodology.Enabled = false;
            this.txtMethodology.Location = new System.Drawing.Point(637, 27);
            this.txtMethodology.Name = "txtMethodology";
            this.txtMethodology.Size = new System.Drawing.Size(149, 20);
            this.txtMethodology.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Reporting Period:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Methodology:";
            // 
            // txtPeriod
            // 
            this.txtPeriod.BackColor = System.Drawing.Color.Ivory;
            this.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPeriod.Enabled = false;
            this.txtPeriod.Location = new System.Drawing.Point(110, 59);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(149, 20);
            this.txtPeriod.TabIndex = 18;
            // 
            // txtExtension
            // 
            this.txtExtension.BackColor = System.Drawing.Color.Ivory;
            this.txtExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtension.Enabled = false;
            this.txtExtension.Location = new System.Drawing.Point(389, 59);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(149, 20);
            this.txtExtension.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "S.Date:";
            // 
            // txtSdate
            // 
            this.txtSdate.BackColor = System.Drawing.Color.Ivory;
            this.txtSdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSdate.Enabled = false;
            this.txtSdate.Location = new System.Drawing.Point(389, 27);
            this.txtSdate.Name = "txtSdate";
            this.txtSdate.Size = new System.Drawing.Size(149, 20);
            this.txtSdate.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Forecast Period:";
            // 
            // colCategory
            // 
            this.colCategory.Text = "Site Category";
            this.colCategory.Width = 85;
            // 
            // colNo
            // 
            this.colNo.Text = "No";
            this.colNo.Width = 39;
            // 
            // lvImport
            // 
            this.lvImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colCategory,
            this.colRegion,
            this.colSitename,
            this.colTest,
            this.colPeriod,
            this.colConsumption,
            this.colStockout,
            this.colDowntime,
            this.colDescription});
            this.lvImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImport.GridLines = true;
            this.lvImport.Location = new System.Drawing.Point(0, 147);
            this.lvImport.Name = "lvImport";
            this.lvImport.Size = new System.Drawing.Size(876, 432);
            this.lvImport.TabIndex = 34;
            this.lvImport.UseCompatibleStateImageBehavior = false;
            this.lvImport.View = System.Windows.Forms.View.Details;
            // 
            // colRegion
            // 
            this.colRegion.Text = "Region Name";
            this.colRegion.Width = 80;
            // 
            // colSitename
            // 
            this.colSitename.Tag = "colSitename";
            this.colSitename.Text = "Site";
            this.colSitename.Width = 68;
            // 
            // colTest
            // 
            this.colTest.Text = "Test Name";
            this.colTest.Width = 90;
            // 
            // colPeriod
            // 
            this.colPeriod.Text = "Reporting Period";
            this.colPeriod.Width = 68;
            // 
            // colConsumption
            // 
            this.colConsumption.Text = "Test Performed";
            this.colConsumption.Width = 100;
            // 
            // colStockout
            // 
            this.colStockout.Text = "Stock Out";
            this.colStockout.Width = 80;
            // 
            // colDowntime
            // 
            this.colDowntime.Text = "Instrument Downtime";
            this.colDowntime.Width = 111;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 144;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 144);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(876, 3);
            this.splitter2.TabIndex = 33;
            this.splitter2.TabStop = false;
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(643, 6);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(75, 30);
            this.butClear.TabIndex = 5;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butClear);
            this.panel2.Controls.Add(this.txtFilename);
            this.panel2.Controls.Add(this.butSave);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.butImport);
            this.panel2.Controls.Add(this.butBrowse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 38);
            this.panel2.TabIndex = 32;
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilename.Location = new System.Drawing.Point(130, 8);
            this.txtFilename.MaximumSize = new System.Drawing.Size(2, 25);
            this.txtFilename.MinimumSize = new System.Drawing.Size(350, 25);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(350, 25);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.WordWrap = false;
            // 
            // butSave
            // 
            this.butSave.Enabled = false;
            this.butSave.Location = new System.Drawing.Point(726, 6);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 30);
            this.butSave.TabIndex = 4;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Excel File To Import:";
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(562, 6);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(75, 30);
            this.butImport.TabIndex = 2;
            this.butImport.Text = "Import";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(481, 6);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 30);
            this.butBrowse.TabIndex = 1;
            this.butBrowse.Text = "Browse...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 100);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(876, 6);
            this.splitter1.TabIndex = 31;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 100);
            this.panel1.TabIndex = 30;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xls";
            this.openFileDialog1.Filter = "Excel files|*.xls";
            // 
            // ImportSerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 579);
            this.Controls.Add(this.lvImport);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportSerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Service Statistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtForecastid;
        private System.Windows.Forms.TextBox txtDusage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMethodology;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ListView lvImport;
        private System.Windows.Forms.ColumnHeader colRegion;
        private System.Windows.Forms.ColumnHeader colSitename;
        private System.Windows.Forms.ColumnHeader colTest;
        private System.Windows.Forms.ColumnHeader colPeriod;
        private System.Windows.Forms.ColumnHeader colConsumption;
        private System.Windows.Forms.ColumnHeader colStockout;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader colDowntime;
        private System.Windows.Forms.ColumnHeader colDescription;
    }
}
