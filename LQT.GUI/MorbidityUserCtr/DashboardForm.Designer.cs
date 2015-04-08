
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

namespace LQT.GUI.MorbidityUserCtr
{
    partial class DashboardForm
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
            this.butToxml = new System.Windows.Forms.Button();
            this.btnAdjustsupplyproc = new System.Windows.Forms.Button();
            this.pnlreport = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisplayReport = new System.Windows.Forms.Button();
            this.cboreport = new System.Windows.Forms.ComboBox();
            this.taskPane1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskPane();
            this.taskFrame1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlreport.SuspendLayout();
            this.taskPane1.SuspendLayout();
            this.taskFrame1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.butToxml);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdjustsupplyproc);
            this.splitContainer1.Panel1.Controls.Add(this.pnlreport);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.taskPane1);
            this.splitContainer1.Size = new System.Drawing.Size(1017, 570);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 1;
            // 
            // butToxml
            // 
            this.butToxml.Location = new System.Drawing.Point(173, 3);
            this.butToxml.Name = "butToxml";
            this.butToxml.Size = new System.Drawing.Size(87, 23);
            this.butToxml.TabIndex = 3;
            this.butToxml.Text = "Export To XML";
            this.butToxml.UseVisualStyleBackColor = true;
            this.butToxml.Click += new System.EventHandler(this.butToxml_Click);
            // 
            // btnAdjustsupplyproc
            // 
            this.btnAdjustsupplyproc.Location = new System.Drawing.Point(13, 3);
            this.btnAdjustsupplyproc.Name = "btnAdjustsupplyproc";
            this.btnAdjustsupplyproc.Size = new System.Drawing.Size(143, 23);
            this.btnAdjustsupplyproc.TabIndex = 3;
            this.btnAdjustsupplyproc.Text = "Adjust Supply Procurement";
            this.btnAdjustsupplyproc.UseVisualStyleBackColor = true;
            this.btnAdjustsupplyproc.Click += new System.EventHandler(this.btnAdjustsupplyproc_Click);
            // 
            // pnlreport
            // 
            this.pnlreport.Controls.Add(this.label1);
            this.pnlreport.Controls.Add(this.btnDisplayReport);
            this.pnlreport.Controls.Add(this.cboreport);
            this.pnlreport.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlreport.Location = new System.Drawing.Point(621, 0);
            this.pnlreport.Name = "pnlreport";
            this.pnlreport.Size = new System.Drawing.Size(396, 32);
            this.pnlreport.TabIndex = 2;
            this.pnlreport.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Report:";
            // 
            // btnDisplayReport
            // 
            this.btnDisplayReport.Location = new System.Drawing.Point(303, 3);
            this.btnDisplayReport.Name = "btnDisplayReport";
            this.btnDisplayReport.Size = new System.Drawing.Size(87, 23);
            this.btnDisplayReport.TabIndex = 1;
            this.btnDisplayReport.Text = "Display Report";
            this.btnDisplayReport.UseVisualStyleBackColor = true;
            this.btnDisplayReport.Click += new System.EventHandler(this.btnDisplayReport_Click);
            // 
            // cboreport
            // 
            this.cboreport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboreport.FormattingEnabled = true;
            this.cboreport.Items.AddRange(new object[] {
            "Supply Forecast",
            "Supply Procurement",
            "No. of Patient Forecast",
            "No. of CD4 & HIV Rapid Test Forecast",
            "No. of Chemisty and Other Tests Forecast",
            "No. of Hematology and ViralLoad Test Forecast"});
            this.cboreport.Location = new System.Drawing.Point(53, 5);
            this.cboreport.Name = "cboreport";
            this.cboreport.Size = new System.Drawing.Size(244, 21);
            this.cboreport.TabIndex = 0;
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScroll = true;
            this.taskPane1.AutoScrollMinSize = new System.Drawing.Size(0, 621);
            this.taskPane1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.taskPane1.Controls.Add(this.taskFrame1);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPane1.Location = new System.Drawing.Point(0, 0);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Padding = 5;
            this.taskPane1.Size = new System.Drawing.Size(1017, 534);
            this.taskPane1.TabIndex = 1;
            this.taskPane1.Visible = false;
            this.taskPane1.FrameExpanding += new Microsoft.Samples.Windows.Forms.TaskPane.FrameExpandingEventHandler(this.taskPane1_FrameExpanding);
            // 
            // taskFrame1
            // 
            this.taskFrame1.AllowDrop = true;
            this.taskFrame1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(212)))));
            this.taskFrame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskFrame1.CaptionBlend = new Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252))))), System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(212))))));
            this.taskFrame1.Controls.Add(this.flowLayoutPanel1);
            this.taskFrame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.taskFrame1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.taskFrame1.Location = new System.Drawing.Point(5, 26);
            this.taskFrame1.Name = "taskFrame1";
            this.taskFrame1.Size = new System.Drawing.Size(989, 590);
            this.taskFrame1.TabIndex = 1;
            this.taskFrame1.Text = "Supply & Procurement Forecast Result";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(987, 588);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DashboardForm";
            this.Size = new System.Drawing.Size(1017, 570);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlreport.ResumeLayout(false);
            this.pnlreport.PerformLayout();
            this.taskPane1.ResumeLayout(false);
            this.taskFrame1.ResumeLayout(false);
            this.taskFrame1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskPane taskPane1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame taskFrame1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDisplayReport;
        private System.Windows.Forms.ComboBox cboreport;
        private System.Windows.Forms.Panel pnlreport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdjustsupplyproc;
        private System.Windows.Forms.Button butToxml;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
