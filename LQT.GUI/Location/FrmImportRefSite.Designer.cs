
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

namespace LQT.GUI.Location
{
    partial class FrmImportRefSite
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabSite = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvImport = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSitename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCD4RefSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChemRefSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHemRefSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colViralRefSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOtherRefSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.butSave = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.butImport = new System.Windows.Forms.Button();
            this.butBrowse = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvInImport = new System.Windows.Forms.ListView();
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTestingArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstrumentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTestRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInExist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.butSaveAll1 = new System.Windows.Forms.Button();
            this.butInClear = new System.Windows.Forms.Button();
            this.txtInFilename = new System.Windows.Forms.TextBox();
            this.butInSave = new System.Windows.Forms.Button();
            this.butInImport = new System.Windows.Forms.Button();
            this.butInBrowse = new System.Windows.Forms.Button();
            this.tabSite.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xls";
            this.openFileDialog1.Filter = "Excel files|*.xls";
            // 
            // tabSite
            // 
            this.tabSite.Controls.Add(this.tabPage1);
            this.tabSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSite.Location = new System.Drawing.Point(0, 0);
            this.tabSite.Name = "tabSite";
            this.tabSite.SelectedIndex = 0;
            this.tabSite.Size = new System.Drawing.Size(1054, 364);
            this.tabSite.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvImport);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1046, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import Referral Site";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvImport
            // 
            this.lvImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colRegion,
            this.colSitename,
            this.colCD4RefSite,
            this.colChemRefSite,
            this.colHemRefSite,
            this.colViralRefSite,
            this.colOtherRefSite,
            this.colExist,
            this.Description});
            this.lvImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImport.GridLines = true;
            this.lvImport.Location = new System.Drawing.Point(3, 47);
            this.lvImport.Name = "lvImport";
            this.lvImport.Size = new System.Drawing.Size(1040, 288);
            this.lvImport.TabIndex = 33;
            this.lvImport.UseCompatibleStateImageBehavior = false;
            this.lvImport.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No";
            this.colNo.Width = 27;
            // 
            // colRegion
            // 
            this.colRegion.Text = "Region/District/Province";
            this.colRegion.Width = 100;
            // 
            // colSitename
            // 
            this.colSitename.Text = "Site Name";
            this.colSitename.Width = 110;
            // 
            // colCD4RefSite
            // 
            this.colCD4RefSite.Text = "CD4 Ref Site";
            this.colCD4RefSite.Width = 79;
            // 
            // colChemRefSite
            // 
            this.colChemRefSite.Text = "Chemistry Ref Site";
            this.colChemRefSite.Width = 101;
            // 
            // colHemRefSite
            // 
            this.colHemRefSite.Text = "Hematology Ref Site";
            this.colHemRefSite.Width = 110;
            // 
            // colViralRefSite
            // 
            this.colViralRefSite.Text = "ViralLoad Ref Site";
            this.colViralRefSite.Width = 98;
            // 
            // colOtherRefSite
            // 
            this.colOtherRefSite.Text = "Other Ref Site";
            this.colOtherRefSite.Width = 83;
            // 
            // colExist
            // 
            this.colExist.Text = "Exist";
            this.colExist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 248;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butSave);
            this.panel2.Controls.Add(this.butClear);
            this.panel2.Controls.Add(this.txtFilename);
            this.panel2.Controls.Add(this.butImport);
            this.panel2.Controls.Add(this.butBrowse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 44);
            this.panel2.TabIndex = 32;
            // 
            // butSave
            // 
            this.butSave.Enabled = false;
            this.butSave.Location = new System.Drawing.Point(431, 5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 30);
            this.butSave.TabIndex = 7;
            this.butSave.Text = "Save ";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvInImport);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1029, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import Site Instrument";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvInImport
            // 
            this.lvInImport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumber,
            this.colRegionName,
            this.colSite,
            this.colTestingArea,
            this.colInstrumentName,
            this.colQuantity,
            this.colTestRun,
            this.colInExist});
            this.lvInImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvInImport.GridLines = true;
            this.lvInImport.Location = new System.Drawing.Point(3, 47);
            this.lvInImport.Name = "lvInImport";
            this.lvInImport.Size = new System.Drawing.Size(1023, 266);
            this.lvInImport.TabIndex = 33;
            this.lvInImport.UseCompatibleStateImageBehavior = false;
            this.lvInImport.View = System.Windows.Forms.View.Details;
            // 
            // colNumber
            // 
            this.colNumber.Text = "No";
            this.colNumber.Width = 46;
            // 
            // colRegionName
            // 
            this.colRegionName.Text = "Region/District/Province";
            this.colRegionName.Width = 100;
            // 
            // colSite
            // 
            this.colSite.Text = "Site Name";
            this.colSite.Width = 110;
            // 
            // colTestingArea
            // 
            this.colTestingArea.Text = "Testing Area";
            this.colTestingArea.Width = 121;
            // 
            // colInstrumentName
            // 
            this.colInstrumentName.Text = "Instrument Name";
            this.colInstrumentName.Width = 113;
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Quantity ";
            this.colQuantity.Width = 98;
            // 
            // colTestRun
            // 
            this.colTestRun.Text = "%Run";
            this.colTestRun.Width = 94;
            // 
            // colInExist
            // 
            this.colInExist.Text = "Exist";
            this.colInExist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colInExist.Width = 114;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butSaveAll1);
            this.panel1.Controls.Add(this.butInClear);
            this.panel1.Controls.Add(this.txtInFilename);
            this.panel1.Controls.Add(this.butInSave);
            this.panel1.Controls.Add(this.butInImport);
            this.panel1.Controls.Add(this.butInBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 44);
            this.panel1.TabIndex = 32;
            // 
            // butSaveAll1
            // 
            this.butSaveAll1.Location = new System.Drawing.Point(487, 8);
            this.butSaveAll1.Name = "butSaveAll1";
            this.butSaveAll1.Size = new System.Drawing.Size(75, 23);
            this.butSaveAll1.TabIndex = 6;
            this.butSaveAll1.Text = "Save All";
            this.butSaveAll1.UseVisualStyleBackColor = true;
            // 
            // butInClear
            // 
            this.butInClear.Enabled = false;
            this.butInClear.Location = new System.Drawing.Point(378, 5);
            this.butInClear.Name = "butInClear";
            this.butInClear.Size = new System.Drawing.Size(50, 30);
            this.butInClear.TabIndex = 5;
            this.butInClear.Text = "Clear";
            this.butInClear.UseVisualStyleBackColor = true;
            // 
            // txtInFilename
            // 
            this.txtInFilename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtInFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInFilename.Location = new System.Drawing.Point(7, 8);
            this.txtInFilename.MaximumSize = new System.Drawing.Size(2, 25);
            this.txtInFilename.MinimumSize = new System.Drawing.Size(250, 25);
            this.txtInFilename.Name = "txtInFilename";
            this.txtInFilename.ReadOnly = true;
            this.txtInFilename.Size = new System.Drawing.Size(250, 25);
            this.txtInFilename.TabIndex = 0;
            this.txtInFilename.WordWrap = false;
            // 
            // butInSave
            // 
            this.butInSave.Enabled = false;
            this.butInSave.Location = new System.Drawing.Point(431, 5);
            this.butInSave.Name = "butInSave";
            this.butInSave.Size = new System.Drawing.Size(50, 30);
            this.butInSave.TabIndex = 4;
            this.butInSave.Text = "Save";
            this.butInSave.UseVisualStyleBackColor = true;
            // 
            // butInImport
            // 
            this.butInImport.Location = new System.Drawing.Point(326, 5);
            this.butInImport.Name = "butInImport";
            this.butInImport.Size = new System.Drawing.Size(50, 30);
            this.butInImport.TabIndex = 2;
            this.butInImport.Text = "Import";
            this.butInImport.UseVisualStyleBackColor = true;
            // 
            // butInBrowse
            // 
            this.butInBrowse.Location = new System.Drawing.Point(263, 5);
            this.butInBrowse.Name = "butInBrowse";
            this.butInBrowse.Size = new System.Drawing.Size(61, 30);
            this.butInBrowse.TabIndex = 1;
            this.butInBrowse.Text = "Browse...";
            this.butInBrowse.UseVisualStyleBackColor = true;
            // 
            // FrmImportRefSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1054, 364);
            this.Controls.Add(this.tabSite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportRefSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import Referral Sites";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabSite.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabSite;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvImport;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colRegion;
        private System.Windows.Forms.ColumnHeader colSitename;
        private System.Windows.Forms.ColumnHeader colCD4RefSite;
        private System.Windows.Forms.ColumnHeader colChemRefSite;
        private System.Windows.Forms.ColumnHeader colHemRefSite;
        private System.Windows.Forms.ColumnHeader colViralRefSite;
        private System.Windows.Forms.ColumnHeader colOtherRefSite;
        private System.Windows.Forms.ColumnHeader colExist;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button butImport;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvInImport;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colRegionName;
        private System.Windows.Forms.ColumnHeader colSite;
        private System.Windows.Forms.ColumnHeader colTestingArea;
        private System.Windows.Forms.ColumnHeader colInstrumentName;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ColumnHeader colTestRun;
        private System.Windows.Forms.ColumnHeader colInExist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butInClear;
        private System.Windows.Forms.TextBox txtInFilename;
        private System.Windows.Forms.Button butInSave;
        private System.Windows.Forms.Button butInImport;
        private System.Windows.Forms.Button butInBrowse;
        private System.Windows.Forms.Button butSaveAll1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.ColumnHeader Description;
    }
}
