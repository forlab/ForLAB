
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.UserCtr
{
    partial class ListProductPane
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPageno = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.butLast = new System.Windows.Forms.Button();
            this.butNext = new System.Windows.Forms.Button();
            this.butPriv = new System.Windows.Forms.Button();
            this.butFirst = new System.Windows.Forms.Button();
            this.lbtAddnew = new System.Windows.Forms.LinkLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(634, 520);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader7});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(632, 490);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product Name";
            this.columnHeader1.Width = 193;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product Type";
            this.columnHeader2.Width = 84;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Serial No";
            this.columnHeader3.Width = 77;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Basic Unit";
            this.columnHeader4.Width = 62;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pack Size";
            this.columnHeader5.Width = 61;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Pack Cost";
            this.columnHeader8.Width = 65;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Min. Pack/Site";
            this.columnHeader7.Width = 83;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(632, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPageno);
            this.panel1.Controls.Add(this.lblPages);
            this.panel1.Controls.Add(this.butLast);
            this.panel1.Controls.Add(this.butNext);
            this.panel1.Controls.Add(this.butPriv);
            this.panel1.Controls.Add(this.butFirst);
            this.panel1.Controls.Add(this.lbtAddnew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 25);
            this.panel1.TabIndex = 0;
            // 
            // txtPageno
            // 
            this.txtPageno.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPageno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPageno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtPageno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageno.Location = new System.Drawing.Point(182, 4);
            this.txtPageno.Name = "txtPageno";
            this.txtPageno.Size = new System.Drawing.Size(40, 18);
            this.txtPageno.TabIndex = 8;
            this.txtPageno.Text = "15";
            this.txtPageno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPages
            // 
            this.lblPages.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblPages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPages.Location = new System.Drawing.Point(222, 4);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(40, 18);
            this.lblPages.TabIndex = 7;
            this.lblPages.Text = "100";
            this.lblPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butLast
            // 
            this.butLast.BackgroundImage = global::LQT.GUI.Properties.Resources.go_last;
            this.butLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butLast.FlatAppearance.BorderSize = 0;
            this.butLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLast.Location = new System.Drawing.Point(288, 5);
            this.butLast.Name = "butLast";
            this.butLast.Size = new System.Drawing.Size(16, 16);
            this.butLast.TabIndex = 5;
            this.butLast.Tag = "LP";
            this.butLast.UseVisualStyleBackColor = true;
            this.butLast.Click += new System.EventHandler(this.navButton_Click);
            // 
            // butNext
            // 
            this.butNext.BackgroundImage = global::LQT.GUI.Properties.Resources.go_next;
            this.butNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butNext.FlatAppearance.BorderSize = 0;
            this.butNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNext.Location = new System.Drawing.Point(268, 5);
            this.butNext.Name = "butNext";
            this.butNext.Size = new System.Drawing.Size(16, 16);
            this.butNext.TabIndex = 4;
            this.butNext.Tag = "NP";
            this.butNext.UseVisualStyleBackColor = true;
            this.butNext.Click += new System.EventHandler(this.navButton_Click);
            // 
            // butPriv
            // 
            this.butPriv.BackgroundImage = global::LQT.GUI.Properties.Resources.go_previous;
            this.butPriv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butPriv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butPriv.FlatAppearance.BorderSize = 0;
            this.butPriv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPriv.Location = new System.Drawing.Point(162, 5);
            this.butPriv.Name = "butPriv";
            this.butPriv.Size = new System.Drawing.Size(16, 16);
            this.butPriv.TabIndex = 3;
            this.butPriv.Tag = "PP";
            this.butPriv.UseVisualStyleBackColor = true;
            this.butPriv.Click += new System.EventHandler(this.navButton_Click);
            // 
            // butFirst
            // 
            this.butFirst.BackgroundImage = global::LQT.GUI.Properties.Resources.go_first;
            this.butFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butFirst.FlatAppearance.BorderSize = 0;
            this.butFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butFirst.Location = new System.Drawing.Point(142, 5);
            this.butFirst.Name = "butFirst";
            this.butFirst.Size = new System.Drawing.Size(16, 16);
            this.butFirst.TabIndex = 2;
            this.butFirst.Tag = "FP";
            this.butFirst.UseVisualStyleBackColor = true;
            this.butFirst.Click += new System.EventHandler(this.navButton_Click);
            // 
            // lbtAddnew
            // 
            this.lbtAddnew.AutoSize = true;
            this.lbtAddnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtAddnew.LinkColor = System.Drawing.Color.Navy;
            this.lbtAddnew.Location = new System.Drawing.Point(4, 5);
            this.lbtAddnew.Name = "lbtAddnew";
            this.lbtAddnew.Size = new System.Drawing.Size(101, 15);
            this.lbtAddnew.TabIndex = 1;
            this.lbtAddnew.TabStop = true;
            this.lbtAddnew.Text = "Add New Product";
            this.lbtAddnew.VisitedLinkColor = System.Drawing.Color.Navy;
            this.lbtAddnew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddnew_LinkClicked);
            // 
            // ListProductPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ListProductPane";
            this.Size = new System.Drawing.Size(634, 520);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.LinkLabel lbtAddnew;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button butFirst;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Button butLast;
        private System.Windows.Forms.Button butNext;
        private System.Windows.Forms.Button butPriv;
        private System.Windows.Forms.Label txtPageno;
    }
}
