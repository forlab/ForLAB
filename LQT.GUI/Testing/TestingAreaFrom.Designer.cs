
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

namespace LQT.GUI.Testing
{
    partial class TestingAreaFrom
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
            this.cobCategory = new System.Windows.Forms.ComboBox();
            this.lblcategory = new System.Windows.Forms.Label();
            this.chkuseindemograph = new System.Windows.Forms.CheckBox();
            this.butDeletegroup = new System.Windows.Forms.Button();
            this.butEditgoup = new System.Windows.Forms.Button();
            this.butNewgroup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvGroups = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAreaname = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.07266F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.92734F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(494, 24);
            this.lqtToolStrip1.TabIndex = 7;
            // 
            // cobCategory
            // 
            this.cobCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCategory.Enabled = false;
            this.cobCategory.FormattingEnabled = true;
            this.cobCategory.Location = new System.Drawing.Point(121, 102);
            this.cobCategory.Name = "cobCategory";
            this.cobCategory.Size = new System.Drawing.Size(282, 21);
            this.cobCategory.TabIndex = 2;
            // 
            // lblcategory
            // 
            this.lblcategory.AutoSize = true;
            this.lblcategory.Location = new System.Drawing.Point(44, 105);
            this.lblcategory.Name = "lblcategory";
            this.lblcategory.Size = new System.Drawing.Size(71, 13);
            this.lblcategory.TabIndex = 29;
            this.lblcategory.Text = "Class of Test:";
            // 
            // chkuseindemograph
            // 
            this.chkuseindemograph.AutoSize = true;
            this.chkuseindemograph.Location = new System.Drawing.Point(121, 79);
            this.chkuseindemograph.Name = "chkuseindemograph";
            this.chkuseindemograph.Size = new System.Drawing.Size(179, 17);
            this.chkuseindemograph.TabIndex = 1;
            this.chkuseindemograph.Text = "Use In Demograph Methodology";
            this.chkuseindemograph.UseVisualStyleBackColor = true;
            this.chkuseindemograph.CheckedChanged += new System.EventHandler(this.chkuseindemograph_CheckedChanged);
            // 
            // butDeletegroup
            // 
            this.butDeletegroup.Enabled = false;
            this.butDeletegroup.Location = new System.Drawing.Point(409, 208);
            this.butDeletegroup.Name = "butDeletegroup";
            this.butDeletegroup.Size = new System.Drawing.Size(75, 23);
            this.butDeletegroup.TabIndex = 6;
            this.butDeletegroup.Text = "Delete";
            this.butDeletegroup.UseVisualStyleBackColor = true;
            this.butDeletegroup.Click += new System.EventHandler(this.butDeletegroup_Click);
            // 
            // butEditgoup
            // 
            this.butEditgoup.Enabled = false;
            this.butEditgoup.Location = new System.Drawing.Point(409, 179);
            this.butEditgoup.Name = "butEditgoup";
            this.butEditgoup.Size = new System.Drawing.Size(75, 23);
            this.butEditgoup.TabIndex = 5;
            this.butEditgoup.Text = "Edit...";
            this.butEditgoup.UseVisualStyleBackColor = true;
            this.butEditgoup.Click += new System.EventHandler(this.butEditgoup_Click);
            // 
            // butNewgroup
            // 
            this.butNewgroup.Location = new System.Drawing.Point(409, 150);
            this.butNewgroup.Name = "butNewgroup";
            this.butNewgroup.Size = new System.Drawing.Size(75, 23);
            this.butNewgroup.TabIndex = 4;
            this.butNewgroup.Text = "New...";
            this.butNewgroup.UseVisualStyleBackColor = true;
            this.butNewgroup.Click += new System.EventHandler(this.butNewgroup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(23, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Testing Groups";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(103, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 2);
            this.label2.TabIndex = 23;
            // 
            // lsvGroups
            // 
            this.lsvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lsvGroups.FullRowSelect = true;
            this.lsvGroups.GridLines = true;
            this.lsvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvGroups.Location = new System.Drawing.Point(121, 150);
            this.lsvGroups.MultiSelect = false;
            this.lsvGroups.Name = "lsvGroups";
            this.lsvGroups.Size = new System.Drawing.Size(282, 129);
            this.lsvGroups.TabIndex = 3;
            this.lsvGroups.UseCompatibleStateImageBehavior = false;
            this.lsvGroups.View = System.Windows.Forms.View.Details;
            this.lsvGroups.SelectedIndexChanged += new System.EventHandler(this.lsvGroups_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Group Name";
            this.colName.Width = 311;
            // 
            // txtAreaname
            // 
            this.txtAreaname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaname.Location = new System.Drawing.Point(121, 53);
            this.txtAreaname.Name = "txtAreaname";
            this.txtAreaname.Size = new System.Drawing.Size(282, 20);
            this.txtAreaname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Testing Area Name:";
            // 
            // TestingAreaFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 289);
            this.Controls.Add(this.cobCategory);
            this.Controls.Add(this.lblcategory);
            this.Controls.Add(this.chkuseindemograph);
            this.Controls.Add(this.butDeletegroup);
            this.Controls.Add(this.butEditgoup);
            this.Controls.Add(this.butNewgroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsvGroups);
            this.Controls.Add(this.txtAreaname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(506, 327);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(506, 327);
            this.Name = "TestingAreaFrom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing Area";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.ComboBox cobCategory;
        private System.Windows.Forms.Label lblcategory;
        private System.Windows.Forms.CheckBox chkuseindemograph;
        private System.Windows.Forms.Button butDeletegroup;
        private System.Windows.Forms.Button butEditgoup;
        private System.Windows.Forms.Button butNewgroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvGroups;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.TextBox txtAreaname;
        private System.Windows.Forms.Label label1;
        //   private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

    }
}
