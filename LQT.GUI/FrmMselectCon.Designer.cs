
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
    partial class FrmMselectCon
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
            this.txtNoperiod = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.butCancle = new System.Windows.Forms.Button();
            this.butSelect = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lvProductAll = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvSites = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNoperiod
            // 
            this.txtNoperiod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoperiod.Location = new System.Drawing.Point(150, 8);
            this.txtNoperiod.Name = "txtNoperiod";
            this.txtNoperiod.Size = new System.Drawing.Size(74, 20);
            this.txtNoperiod.TabIndex = 9;
            this.txtNoperiod.Text = "3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtNoperiod);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.butCancle);
            this.panel2.Controls.Add(this.butSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 34);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "# of reporting periods:";
            // 
            // butCancle
            // 
            this.butCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancle.Location = new System.Drawing.Point(314, 3);
            this.butCancle.Name = "butCancle";
            this.butCancle.Size = new System.Drawing.Size(75, 30);
            this.butCancle.TabIndex = 4;
            this.butCancle.Text = "Cancel";
            this.butCancle.UseVisualStyleBackColor = true;
            this.butCancle.Click += new System.EventHandler(this.butCancle_Click);
            // 
            // butSelect
            // 
            this.butSelect.Location = new System.Drawing.Point(233, 3);
            this.butSelect.Name = "butSelect";
            this.butSelect.Size = new System.Drawing.Size(75, 30);
            this.butSelect.TabIndex = 3;
            this.butSelect.Text = "Select";
            this.butSelect.UseVisualStyleBackColor = true;
            this.butSelect.Click += new System.EventHandler(this.butSelect_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lvProductAll, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(516, 496);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lvProductAll
            // 
            this.lvProductAll.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvProductAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader7});
            this.lvProductAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProductAll.FullRowSelect = true;
            this.lvProductAll.GridLines = true;
            this.lvProductAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProductAll.Location = new System.Drawing.Point(3, 43);
            this.lvProductAll.Name = "lvProductAll";
            this.lvProductAll.Size = new System.Drawing.Size(510, 450);
            this.lvProductAll.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProductAll.TabIndex = 6;
            this.lvProductAll.UseCompatibleStateImageBehavior = false;
            this.lvProductAll.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Product Name";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Serial No";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Basic Unit";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Specification";
            this.columnHeader7.Width = 150;
            // 
            // lsvSites
            // 
            this.lsvSites.CheckBoxes = true;
            this.lsvSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lsvSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvSites.FullRowSelect = true;
            this.lsvSites.GridLines = true;
            this.lsvSites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvSites.Location = new System.Drawing.Point(0, 0);
            this.lsvSites.Name = "lsvSites";
            this.lsvSites.Size = new System.Drawing.Size(210, 496);
            this.lsvSites.TabIndex = 3;
            this.lsvSites.UseCompatibleStateImageBehavior = false;
            this.lsvSites.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Site Name";
            this.columnHeader4.Width = 200;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lsvSites);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(730, 496);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 2;
            // 
            // FrmMselectCon
            // 
            this.AcceptButton = this.butSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancle;
            this.ClientSize = new System.Drawing.Size(730, 496);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMselectCon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Products";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoperiod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butCancle;
        private System.Windows.Forms.Button butSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView lsvSites;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView lvProductAll;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}
