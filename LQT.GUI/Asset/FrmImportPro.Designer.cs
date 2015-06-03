
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.Asset
{
    partial class FrmImportPro
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
            this.lvImport = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colproductname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.producttype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serialno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.specificaiton = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.basicunit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.minpacksite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.testspec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.packagingsize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pricedate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butClear = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butImport = new System.Windows.Forms.Button();
            this.butBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvImport
            // 
            this.lvImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colproductname,
            this.producttype,
            this.serialno,
            this.specificaiton,
            this.basicunit,
            this.minpacksite,
            this.testspec,
            this.price,
            this.packagingsize,
            this.Pricedate,
            this.exist,
            this.Description});
            this.lvImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImport.GridLines = true;
            this.lvImport.Location = new System.Drawing.Point(0, 44);
            this.lvImport.Name = "lvImport";
            this.lvImport.Size = new System.Drawing.Size(963, 385);
            this.lvImport.TabIndex = 32;
            this.lvImport.UseCompatibleStateImageBehavior = false;
            this.lvImport.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No";
            this.colNo.Width = 28;
            // 
            // colproductname
            // 
            this.colproductname.Text = "Product Name";
            this.colproductname.Width = 82;
            // 
            // producttype
            // 
            this.producttype.Text = "Product Type";
            this.producttype.Width = 79;
            // 
            // serialno
            // 
            this.serialno.Text = "Serial No";
            this.serialno.Width = 57;
            // 
            // specificaiton
            // 
            this.specificaiton.Text = "Specification";
            this.specificaiton.Width = 77;
            // 
            // basicunit
            // 
            this.basicunit.Text = "Basic Unit";
            // 
            // minpacksite
            // 
            this.minpacksite.Text = "Min. Packs / Site";
            this.minpacksite.Width = 96;
            // 
            // testspec
            // 
            this.testspec.Text = "Test Specification";
            this.testspec.Width = 97;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.Width = 48;
            // 
            // packagingsize
            // 
            this.packagingsize.Text = "Packaging Size";
            this.packagingsize.Width = 87;
            // 
            // Pricedate
            // 
            this.Pricedate.Text = "Price As of Date";
            this.Pricedate.Width = 90;
            // 
            // exist
            // 
            this.exist.Text = "Exist";
            this.exist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.exist.Width = 40;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 118;
            // 
            // butClear
            // 
            this.butClear.Enabled = false;
            this.butClear.Location = new System.Drawing.Point(378, 5);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(50, 30);
            this.butClear.TabIndex = 5;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilename.Location = new System.Drawing.Point(7, 8);
            this.txtFilename.MaximumSize = new System.Drawing.Size(2, 25);
            this.txtFilename.MinimumSize = new System.Drawing.Size(250, 25);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(250, 25);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.WordWrap = false;
            // 
            // butSave
            // 
            this.butSave.Enabled = false;
            this.butSave.Location = new System.Drawing.Point(431, 5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(50, 30);
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
            this.panel2.Size = new System.Drawing.Size(963, 44);
            this.panel2.TabIndex = 31;
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(326, 5);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(50, 30);
            this.butImport.TabIndex = 2;
            this.butImport.Text = "Import";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // butBrowse
            // 
            this.butBrowse.Location = new System.Drawing.Point(263, 5);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(61, 30);
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
            // FrmImportPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 429);
            this.Controls.Add(this.lvImport);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportPro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Product";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvImport;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colproductname;
        private System.Windows.Forms.ColumnHeader serialno;
        private System.Windows.Forms.ColumnHeader exist;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader producttype;
        private System.Windows.Forms.ColumnHeader basicunit;
        private System.Windows.Forms.ColumnHeader packagingsize;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader testspec;
        private System.Windows.Forms.ColumnHeader specificaiton;
        private System.Windows.Forms.ColumnHeader minpacksite;
        private System.Windows.Forms.ColumnHeader Pricedate;
        private System.Windows.Forms.ColumnHeader Description;
    }
}
