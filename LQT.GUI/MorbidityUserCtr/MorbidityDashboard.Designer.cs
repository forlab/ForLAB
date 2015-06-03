
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.MorbidityUserCtr
{
    partial class MorbidityDashboard
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
            this.taskPane1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskPane();
            this.taskFrame1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.taskFrame2 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.taskPane1.SuspendLayout();
            this.taskFrame1.SuspendLayout();
            this.taskFrame2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.taskPane1);
            this.splitContainer1.Size = new System.Drawing.Size(671, 469);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 0;
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScroll = true;
            this.taskPane1.AutoScrollMinSize = new System.Drawing.Size(0, 1078);
            this.taskPane1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.taskPane1.Controls.Add(this.taskFrame1);
            this.taskPane1.Controls.Add(this.taskFrame2);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPane1.Location = new System.Drawing.Point(0, 0);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(671, 429);
            this.taskPane1.TabIndex = 1;
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
            this.taskFrame1.Location = new System.Drawing.Point(12, 33);
            this.taskFrame1.Name = "taskFrame1";
            this.taskFrame1.Size = new System.Drawing.Size(629, 500);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(627, 498);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // taskFrame2
            // 
            this.taskFrame2.AllowDrop = true;
            this.taskFrame2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(212)))));
            this.taskFrame2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taskFrame2.CaptionBlend = new Microsoft.Samples.Windows.Forms.TaskPane.BlendFill(Microsoft.Samples.Windows.Forms.TaskPane.BlendStyle.Horizontal, System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252))))), System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(212))))));
            this.taskFrame2.Controls.Add(this.flowLayoutPanel2);
            this.taskFrame2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.taskFrame2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.taskFrame2.IsExpanded = false;
            this.taskFrame2.Location = new System.Drawing.Point(12, 566);
            this.taskFrame2.Name = "taskFrame1";
            this.taskFrame2.Size = new System.Drawing.Size(629, 500);
            this.taskFrame2.TabIndex = 3;
            this.taskFrame2.Text = "No. of Tests Forecast Result";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(627, 498);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // MorbidityDashboard
            // 
            this.Controls.Add(this.splitContainer1);
            this.Name = "MorbidityDashboard";
            this.Size = new System.Drawing.Size(671, 469);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.taskPane1.ResumeLayout(false);
            this.taskFrame1.ResumeLayout(false);
            this.taskFrame1.PerformLayout();
            this.taskFrame2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskPane taskPane1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame taskFrame1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame taskFrame2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
