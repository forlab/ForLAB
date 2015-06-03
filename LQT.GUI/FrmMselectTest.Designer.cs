
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
    partial class FrmMselectTest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lsvSites = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNoperiod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butCancle = new System.Windows.Forms.Button();
            this.butSelect = new System.Windows.Forms.Button();
            this.lvTests = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(725, 483);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 1;
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
            this.lsvSites.Size = new System.Drawing.Size(229, 483);
            this.lsvSites.TabIndex = 3;
            this.lsvSites.UseCompatibleStateImageBehavior = false;
            this.lsvSites.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Site Name";
            this.columnHeader4.Width = 200;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lvTests, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(492, 483);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.panel2.Size = new System.Drawing.Size(486, 34);
            this.panel2.TabIndex = 1;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "No. of reporting periods:";
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
            // lvTests
            // 
            this.lvTests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTests.FullRowSelect = true;
            this.lvTests.GridLines = true;
            this.lvTests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTests.HideSelection = false;
            this.lvTests.Location = new System.Drawing.Point(3, 43);
            this.lvTests.Name = "lvTests";
            this.lvTests.Size = new System.Drawing.Size(486, 437);
            this.lvTests.TabIndex = 3;
            this.lvTests.UseCompatibleStateImageBehavior = false;
            this.lvTests.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Test Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Group Name";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Area Name";
            this.columnHeader3.Width = 150;
            // 
            // FrmMselectTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 483);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMselectTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Test";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNoperiod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butCancle;
        private System.Windows.Forms.Button butSelect;
        private System.Windows.Forms.ListView lvTests;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lsvSites;
        private System.Windows.Forms.ColumnHeader columnHeader4;

    }
}
