
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
    partial class RegionForm
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
            this.butNewsite = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butDeletesite = new System.Windows.Forms.Button();
            this.butEditsite = new System.Windows.Forms.Button();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvGroups = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShortname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSites = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.631728F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.36827F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 30);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(623, 24);
            this.lqtToolStrip1.TabIndex = 1;
            // 
            // butNewsite
            // 
            this.butNewsite.Location = new System.Drawing.Point(539, 119);
            this.butNewsite.Name = "butNewsite";
            this.butNewsite.Size = new System.Drawing.Size(75, 23);
            this.butNewsite.TabIndex = 27;
            this.butNewsite.Text = "New...";
            this.butNewsite.UseVisualStyleBackColor = true;
            this.butNewsite.Click += new System.EventHandler(this.butNewsite_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Currently Open";
            this.columnHeader1.Width = 88;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Opening Date";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Closing Date";
            this.columnHeader3.Width = 103;
            // 
            // butDeletesite
            // 
            this.butDeletesite.Enabled = false;
            this.butDeletesite.Location = new System.Drawing.Point(539, 177);
            this.butDeletesite.Name = "butDeletesite";
            this.butDeletesite.Size = new System.Drawing.Size(75, 23);
            this.butDeletesite.TabIndex = 29;
            this.butDeletesite.Text = "Delete";
            this.butDeletesite.UseVisualStyleBackColor = true;
            this.butDeletesite.Click += new System.EventHandler(this.butDeletesite_Click);
            // 
            // butEditsite
            // 
            this.butEditsite.Enabled = false;
            this.butEditsite.Location = new System.Drawing.Point(539, 148);
            this.butEditsite.Name = "butEditsite";
            this.butEditsite.Size = new System.Drawing.Size(75, 23);
            this.butEditsite.TabIndex = 28;
            this.butEditsite.Text = "Edit...";
            this.butEditsite.UseVisualStyleBackColor = true;
            this.butEditsite.Click += new System.EventHandler(this.butEditsite_Click);
            // 
            // colName
            // 
            this.colName.Text = "Site Name";
            this.colName.Width = 150;
            // 
            // lsvGroups
            // 
            this.lsvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvGroups.FullRowSelect = true;
            this.lsvGroups.GridLines = true;
            this.lsvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvGroups.Location = new System.Drawing.Point(92, 119);
            this.lsvGroups.MultiSelect = false;
            this.lsvGroups.Name = "lsvGroups";
            this.lsvGroups.Size = new System.Drawing.Size(441, 197);
            this.lsvGroups.TabIndex = 26;
            this.lsvGroups.UseCompatibleStateImageBehavior = false;
            this.lsvGroups.View = System.Windows.Forms.View.Details;
            this.lsvGroups.SelectedIndexChanged += new System.EventHandler(this.lsvGroups_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(41, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(493, 1);
            this.label4.TabIndex = 25;
            // 
            // txtShortname
            // 
            this.txtShortname.Location = new System.Drawing.Point(92, 62);
            this.txtShortname.MaxLength = 8;
            this.txtShortname.Name = "txtShortname";
            this.txtShortname.Size = new System.Drawing.Size(100, 20);
            this.txtShortname.TabIndex = 24;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 36);
            this.txtName.MaxLength = 64;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 20);
            this.txtName.TabIndex = 23;
            // 
            // lblSites
            // 
            this.lblSites.AutoSize = true;
            this.lblSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSites.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSites.Location = new System.Drawing.Point(14, 97);
            this.lblSites.Name = "lblSites";
            this.lblSites.Size = new System.Drawing.Size(35, 13);
            this.lblSites.TabIndex = 22;
            this.lblSites.Text = "Sites";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Short Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name:";
            // 
            // RegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 353);
            this.Controls.Add(this.butNewsite);
            this.Controls.Add(this.butDeletesite);
            this.Controls.Add(this.butEditsite);
            this.Controls.Add(this.lsvGroups);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtShortname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSites);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Region/District/Province";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.Button butNewsite;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button butDeletesite;
        private System.Windows.Forms.Button butEditsite;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ListView lsvGroups;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShortname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
      //  private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
