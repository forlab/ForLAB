
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
    partial class FrmSelectPro
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
            this.lvProductAll = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.butOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comClass = new System.Windows.Forms.ComboBox();
            this.butCancle = new System.Windows.Forms.Button();
            this.butSelect = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstSelectedPro = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lvProductAll, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(695, 253);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lvProductAll
            // 
            this.lvProductAll.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvProductAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7});
            this.lvProductAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProductAll.FullRowSelect = true;
            this.lvProductAll.GridLines = true;
            this.lvProductAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProductAll.Location = new System.Drawing.Point(0, 35);
            this.lvProductAll.Margin = new System.Windows.Forms.Padding(0);
            this.lvProductAll.Name = "lvProductAll";
            this.lvProductAll.Size = new System.Drawing.Size(695, 218);
            this.lvProductAll.TabIndex = 5;
            this.lvProductAll.UseCompatibleStateImageBehavior = false;
            this.lvProductAll.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Product/Reagent Name";
            this.columnHeader3.Width = 289;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Serial No";
            this.columnHeader4.Width = 143;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Basic Unit";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Specification";
            this.columnHeader7.Width = 136;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butOk);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comClass);
            this.panel2.Controls.Add(this.butCancle);
            this.panel2.Controls.Add(this.butSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 35);
            this.panel2.TabIndex = 1;
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butOk.Location = new System.Drawing.Point(583, 3);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(53, 30);
            this.butOk.TabIndex = 7;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Quantify according to…";
            // 
            // comClass
            // 
            this.comClass.DisplayMember = "DisplayTitle";
            this.comClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comClass.FormattingEnabled = true;
            this.comClass.Location = new System.Drawing.Point(119, 8);
            this.comClass.Name = "comClass";
            this.comClass.Size = new System.Drawing.Size(406, 21);
            this.comClass.TabIndex = 5;
            this.comClass.ValueMember = "Id";
            this.comClass.SelectedIndexChanged += new System.EventHandler(this.comClass_SelectedIndexChanged);
            // 
            // butCancle
            // 
            this.butCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancle.Location = new System.Drawing.Point(638, 3);
            this.butCancle.Name = "butCancle";
            this.butCancle.Size = new System.Drawing.Size(53, 30);
            this.butCancle.TabIndex = 4;
            this.butCancle.Text = "Cancel";
            this.butCancle.UseVisualStyleBackColor = true;
            this.butCancle.Click += new System.EventHandler(this.butCancle_Click);
            // 
            // butSelect
            // 
            this.butSelect.Location = new System.Drawing.Point(526, 3);
            this.butSelect.Name = "butSelect";
            this.butSelect.Size = new System.Drawing.Size(54, 30);
            this.butSelect.TabIndex = 3;
            this.butSelect.Text = "Select";
            this.butSelect.UseVisualStyleBackColor = true;
            this.butSelect.Click += new System.EventHandler(this.butSelect_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Panel2.Controls.Add(this.lstSelectedPro);
            this.splitContainer1.Size = new System.Drawing.Size(695, 529);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 4;
            // 
            // lstSelectedPro
            // 
            this.lstSelectedPro.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstSelectedPro.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8});
            this.lstSelectedPro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelectedPro.FullRowSelect = true;
            this.lstSelectedPro.GridLines = true;
            this.lstSelectedPro.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSelectedPro.Location = new System.Drawing.Point(0, 0);
            this.lstSelectedPro.MultiSelect = false;
            this.lstSelectedPro.Name = "lstSelectedPro";
            this.lstSelectedPro.Size = new System.Drawing.Size(695, 268);
            this.lstSelectedPro.TabIndex = 4;
            this.lstSelectedPro.UseCompatibleStateImageBehavior = false;
            this.lstSelectedPro.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product";
            this.columnHeader1.Width = 289;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Quantify according to";
            this.columnHeader8.Width = 380;
            // 
            // FrmSelectPro
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancle;
            this.ClientSize = new System.Drawing.Size(695, 529);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSelectPro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Reagents";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvProductAll;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button butCancle;
        private System.Windows.Forms.Button butSelect;
        private System.Windows.Forms.ComboBox comClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lstSelectedPro;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button butOk;
    }
}
