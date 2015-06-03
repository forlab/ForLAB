
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
    partial class ImportForm
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
            this.txtDusage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMethodology = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtSdate = new System.Windows.Forms.TextBox();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtForecastid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butClear = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.butImport = new System.Windows.Forms.Button();
            this.butBrowse = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lvImport = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDusage
            // 
            this.txtDusage.BackColor = System.Drawing.Color.Ivory;
            this.txtDusage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDusage.Enabled = false;
            this.txtDusage.Location = new System.Drawing.Point(574, 59);
            this.txtDusage.Name = "txtDusage";
            this.txtDusage.Size = new System.Drawing.Size(149, 20);
            this.txtDusage.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(494, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Data Usage:";
            // 
            // txtMethodology
            // 
            this.txtMethodology.BackColor = System.Drawing.Color.Ivory;
            this.txtMethodology.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMethodology.Enabled = false;
            this.txtMethodology.Location = new System.Drawing.Point(574, 27);
            this.txtMethodology.Name = "txtMethodology";
            this.txtMethodology.Size = new System.Drawing.Size(149, 20);
            this.txtMethodology.TabIndex = 21;
            // 
            // txtExtension
            // 
            this.txtExtension.BackColor = System.Drawing.Color.Ivory;
            this.txtExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExtension.Enabled = false;
            this.txtExtension.Location = new System.Drawing.Point(320, 59);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(149, 20);
            this.txtExtension.TabIndex = 20;
            // 
            // txtSdate
            // 
            this.txtSdate.BackColor = System.Drawing.Color.Ivory;
            this.txtSdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSdate.Enabled = false;
            this.txtSdate.Location = new System.Drawing.Point(320, 27);
            this.txtSdate.Name = "txtSdate";
            this.txtSdate.Size = new System.Drawing.Size(149, 20);
            this.txtSdate.TabIndex = 19;
            // 
            // txtPeriod
            // 
            this.txtPeriod.BackColor = System.Drawing.Color.Ivory;
            this.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPeriod.Enabled = false;
            this.txtPeriod.Location = new System.Drawing.Point(77, 59);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(149, 20);
            this.txtPeriod.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Methodology:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Extension:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "S.Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Period:";
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
            this.txtForecastid.Location = new System.Drawing.Point(77, 27);
            this.txtForecastid.Name = "txtForecastid";
            this.txtForecastid.Size = new System.Drawing.Size(149, 20);
            this.txtForecastid.TabIndex = 25;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 100);
            this.panel1.TabIndex = 25;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 100);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(876, 6);
            this.splitter1.TabIndex = 26;
            this.splitter1.TabStop = false;
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
            this.panel2.TabIndex = 27;
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
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 144);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(876, 3);
            this.splitter2.TabIndex = 28;
            this.splitter2.TabStop = false;
            // 
            // lvImport
            // 
            this.lvImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImport.GridLines = true;
            this.lvImport.Location = new System.Drawing.Point(0, 147);
            this.lvImport.Name = "lvImport";
            this.lvImport.Size = new System.Drawing.Size(876, 432);
            this.lvImport.TabIndex = 29;
            this.lvImport.UseCompatibleStateImageBehavior = false;
            this.lvImport.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "No";
            this.columnHeader8.Width = 39;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Region";
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Site";
            this.columnHeader2.Width = 143;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Product";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Reporting Period";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Consumption";
            this.columnHeader5.Width = 107;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Stock Out";
            this.columnHeader6.Width = 81;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Adjusted";
            this.columnHeader7.Width = 103;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xls";
            this.openFileDialog1.Filter = "Excel files|*.xls";
            // 
            // ImportForm
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
            this.Name = "ImportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDusage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMethodology;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtSdate;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtForecastid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ListView lvImport;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butClear;
    }
}
