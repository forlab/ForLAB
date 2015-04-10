
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

namespace LQT.GUI.MorbidityUserCtr
{
    partial class SiteSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteSelection));
            this.butDelete = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.txtCatname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butImportPatient = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtUserdifiend = new System.Windows.Forms.RadioButton();
            this.rbtRegion = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butAddnew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lvCategory = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbtRemovesite = new System.Windows.Forms.LinkLabel();
            this.lbtAddsite = new System.Windows.Forms.LinkLabel();
            this.panSites = new System.Windows.Forms.Panel();
            this.trueFalseImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butDelete
            // 
            this.butDelete.Enabled = false;
            this.butDelete.Location = new System.Drawing.Point(84, 65);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 30);
            this.butDelete.TabIndex = 6;
            this.butDelete.Text = "Delete";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Enabled = false;
            this.butSave.Location = new System.Drawing.Point(9, 65);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 30);
            this.butSave.TabIndex = 5;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // txtCatname
            // 
            this.txtCatname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCatname.Enabled = false;
            this.txtCatname.Location = new System.Drawing.Point(9, 41);
            this.txtCatname.Name = "txtCatname";
            this.txtCatname.Size = new System.Drawing.Size(150, 20);
            this.txtCatname.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.butImportPatient);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(213, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 124);
            this.panel1.TabIndex = 1;
            // 
            // butImportPatient
            // 
            this.butImportPatient.Location = new System.Drawing.Point(5, 80);
            this.butImportPatient.Name = "butImportPatient";
            this.butImportPatient.Size = new System.Drawing.Size(179, 30);
            this.butImportPatient.TabIndex = 4;
            this.butImportPatient.Text = "Import  Patient Numbers";
            this.butImportPatient.UseVisualStyleBackColor = true;
            this.butImportPatient.Click += new System.EventHandler(this.butImportPatient_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtUserdifiend);
            this.groupBox2.Controls.Add(this.rbtRegion);
            this.groupBox2.Location = new System.Drawing.Point(5, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 69);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categorize site by";
            // 
            // rbtUserdifiend
            // 
            this.rbtUserdifiend.AutoSize = true;
            this.rbtUserdifiend.Location = new System.Drawing.Point(7, 42);
            this.rbtUserdifiend.Name = "rbtUserdifiend";
            this.rbtUserdifiend.Size = new System.Drawing.Size(153, 17);
            this.rbtUserdifiend.TabIndex = 1;
            this.rbtUserdifiend.TabStop = true;
            this.rbtUserdifiend.Text = "Use user difiend categories";
            this.rbtUserdifiend.UseVisualStyleBackColor = true;
            // 
            // rbtRegion
            // 
            this.rbtRegion.AutoSize = true;
            this.rbtRegion.Location = new System.Drawing.Point(6, 21);
            this.rbtRegion.Name = "rbtRegion";
            this.rbtRegion.Size = new System.Drawing.Size(142, 17);
            this.rbtRegion.TabIndex = 0;
            this.rbtRegion.TabStop = true;
            this.rbtRegion.Text = "Use region as categories";
            this.rbtRegion.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butAddnew);
            this.groupBox1.Controls.Add(this.butDelete);
            this.groupBox1.Controls.Add(this.butSave);
            this.groupBox1.Controls.Add(this.txtCatname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(190, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Active User Defiend Category";
            // 
            // butAddnew
            // 
            this.butAddnew.Location = new System.Drawing.Point(165, 41);
            this.butAddnew.Name = "butAddnew";
            this.butAddnew.Size = new System.Drawing.Size(75, 54);
            this.butAddnew.TabIndex = 7;
            this.butAddnew.Text = "Add New";
            this.butAddnew.UseVisualStyleBackColor = true;
            this.butAddnew.Click += new System.EventHandler(this.butAddnew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "List of Categories";
            this.columnHeader2.Width = 193;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(658, 291);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lvCategory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 130);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvCategory
            // 
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCategory.FullRowSelect = true;
            this.lvCategory.GridLines = true;
            this.lvCategory.Location = new System.Drawing.Point(3, 3);
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.Size = new System.Drawing.Size(204, 124);
            this.lvCategory.TabIndex = 0;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            this.lvCategory.SelectedIndexChanged += new System.EventHandler(this.lvCategory_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panSites, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(658, 155);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbtRemovesite);
            this.panel2.Controls.Add(this.lbtAddsite);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 19);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "List of Sites";
            // 
            // lbtRemovesite
            // 
            this.lbtRemovesite.AutoSize = true;
            this.lbtRemovesite.Enabled = false;
            this.lbtRemovesite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtRemovesite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtRemovesite.Location = new System.Drawing.Point(147, 3);
            this.lbtRemovesite.Name = "lbtRemovesite";
            this.lbtRemovesite.Size = new System.Drawing.Size(79, 13);
            this.lbtRemovesite.TabIndex = 9;
            this.lbtRemovesite.TabStop = true;
            this.lbtRemovesite.Text = "Remove Site";
            this.lbtRemovesite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtRemovesite_LinkClicked);
            // 
            // lbtAddsite
            // 
            this.lbtAddsite.AutoSize = true;
            this.lbtAddsite.Enabled = false;
            this.lbtAddsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtAddsite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbtAddsite.Location = new System.Drawing.Point(91, 3);
            this.lbtAddsite.Name = "lbtAddsite";
            this.lbtAddsite.Size = new System.Drawing.Size(55, 13);
            this.lbtAddsite.TabIndex = 8;
            this.lbtAddsite.TabStop = true;
            this.lbtAddsite.Text = "Add Site";
            this.lbtAddsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddsite_LinkClicked);
            // 
            // panSites
            // 
            this.panSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSites.Location = new System.Drawing.Point(3, 28);
            this.panSites.Name = "panSites";
            this.panSites.Padding = new System.Windows.Forms.Padding(3);
            this.panSites.Size = new System.Drawing.Size(652, 124);
            this.panSites.TabIndex = 10;
            // 
            // trueFalseImageList
            // 
            this.trueFalseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("trueFalseImageList.ImageStream")));
            this.trueFalseImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.trueFalseImageList.Images.SetKeyName(0, "true.gif");
            this.trueFalseImageList.Images.SetKeyName(1, "false.gif");
            this.trueFalseImageList.Images.SetKeyName(2, "down.png");
            this.trueFalseImageList.Images.SetKeyName(3, "up.png");
            this.trueFalseImageList.Images.SetKeyName(4, "checked.png");
            this.trueFalseImageList.Images.SetKeyName(5, "unchecked.png");
            // 
            // SiteSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SiteSelection";
            this.Size = new System.Drawing.Size(658, 291);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.TextBox txtCatname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butAddnew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvCategory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtUserdifiend;
        private System.Windows.Forms.RadioButton rbtRegion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbtRemovesite;
        private System.Windows.Forms.LinkLabel lbtAddsite;
        private System.Windows.Forms.ImageList trueFalseImageList;
        private System.Windows.Forms.Panel panSites;
        private System.Windows.Forms.Button butImportPatient;
    }
}
