
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.Testing
{
    partial class FrmImportQMenu
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
            this.butClear = new System.Windows.Forms.Button();
            this.lvImport = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShortname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butImport = new System.Windows.Forms.Button();
            this.butBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butClear
            // 
            this.butClear.Enabled = false;
            this.butClear.Location = new System.Drawing.Point(759, 6);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(65, 30);
            this.butClear.TabIndex = 5;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // lvImport
            // 
            this.lvImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colRegion,
            this.colShortname,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.lvImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImport.FullRowSelect = true;
            this.lvImport.GridLines = true;
            this.lvImport.Location = new System.Drawing.Point(0, 44);
            this.lvImport.Name = "lvImport";
            this.lvImport.Size = new System.Drawing.Size(907, 510);
            this.lvImport.TabIndex = 34;
            this.lvImport.UseCompatibleStateImageBehavior = false;
            this.lvImport.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No";
            this.colNo.Width = 35;
            // 
            // colRegion
            // 
            this.colRegion.Text = "Product Name";
            this.colRegion.Width = 225;
            // 
            // colShortname
            // 
            this.colShortname.Text = "Usage Rate";
            this.colShortname.Width = 97;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantify according to…";
            this.columnHeader4.Width = 210;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Applied to?";
            this.columnHeader3.Width = 86;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Exist";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 68;
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilename.Location = new System.Drawing.Point(7, 10);
            this.txtFilename.MinimumSize = new System.Drawing.Size(250, 25);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(604, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.WordWrap = false;
            // 
            // butSave
            // 
            this.butSave.Enabled = false;
            this.butSave.Location = new System.Drawing.Point(830, 6);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(65, 30);
            this.butSave.TabIndex = 4;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butClear);
            this.panel2.Controls.Add(this.txtFilename);
            this.panel2.Controls.Add(this.butSave);
            this.panel2.Controls.Add(this.butImport);
            this.panel2.Controls.Add(this.butBrowse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(907, 44);
            this.panel2.TabIndex = 33;
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(688, 6);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(65, 30);
            this.butImport.TabIndex = 2;
            this.butImport.Text = "Import";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(617, 6);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(65, 30);
            this.butBrowse.TabIndex = 1;
            this.butBrowse.Text = "Browse...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xls";
            this.openFileDialog1.Filter = "Excel files|*.xls";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Remarks";
            this.columnHeader2.Width = 155;
            // 
            // FrmImportQMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 554);
            this.Controls.Add(this.lvImport);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportQMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import ART Tests Quantification Variable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImportQMenu_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.ListView lvImport;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colRegion;
        private System.Windows.Forms.ColumnHeader colShortname;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
