
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

namespace LQT.GUI.Quantification
{
    partial class FrmMorbidity
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
            this.taskPane1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskPane();
            this.taskFrame1 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.taskFrame2 = new Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtstartdate = new System.Windows.Forms.TextBox();
            this.txtbudgetend = new System.Windows.Forms.TextBox();
            this.txtbudgetstart = new System.Windows.Forms.TextBox();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.taskPane1.SuspendLayout();
            this.taskFrame1.SuspendLayout();
            this.taskFrame2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskPane1
            // 
            this.taskPane1.AutoScroll = true;
            this.taskPane1.AutoScrollMinSize = new System.Drawing.Size(0, 1078);
            this.taskPane1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.taskPane1.Controls.Add(this.taskFrame1);
            this.taskPane1.Controls.Add(this.taskFrame2);
            this.taskPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskPane1.Location = new System.Drawing.Point(0, 151);
            this.taskPane1.Name = "taskPane1";
            this.taskPane1.Size = new System.Drawing.Size(1008, 551);
            this.taskPane1.TabIndex = 0;
            this.taskPane1.FrameExpanded += new Microsoft.Samples.Windows.Forms.TaskPane.FrameExpandedEventHandler(this.taskPane1_FrameExpanded);
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
            this.taskFrame1.Size = new System.Drawing.Size(966, 500);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(964, 498);
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
            this.taskFrame2.Size = new System.Drawing.Size(966, 500);
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
            this.flowLayoutPanel2.Size = new System.Drawing.Size(964, 498);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtstartdate);
            this.panel1.Controls.Add(this.txtbudgetend);
            this.panel1.Controls.Add(this.txtbudgetstart);
            this.panel1.Controls.Add(this.txttitle);
            this.panel1.Controls.Add(this.txtdescription);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 151);
            this.panel1.TabIndex = 1;
            // 
            // txtstartdate
            // 
            this.txtstartdate.BackColor = System.Drawing.SystemColors.Control;
            this.txtstartdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstartdate.Location = new System.Drawing.Point(389, 64);
            this.txtstartdate.Name = "txtstartdate";
            this.txtstartdate.ReadOnly = true;
            this.txtstartdate.Size = new System.Drawing.Size(227, 20);
            this.txtstartdate.TabIndex = 25;
            // 
            // txtbudgetend
            // 
            this.txtbudgetend.BackColor = System.Drawing.SystemColors.Control;
            this.txtbudgetend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbudgetend.Location = new System.Drawing.Point(389, 116);
            this.txtbudgetend.Name = "txtbudgetend";
            this.txtbudgetend.ReadOnly = true;
            this.txtbudgetend.Size = new System.Drawing.Size(227, 20);
            this.txtbudgetend.TabIndex = 24;
            // 
            // txtbudgetstart
            // 
            this.txtbudgetstart.BackColor = System.Drawing.SystemColors.Control;
            this.txtbudgetstart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbudgetstart.Location = new System.Drawing.Point(389, 90);
            this.txtbudgetstart.Name = "txtbudgetstart";
            this.txtbudgetstart.ReadOnly = true;
            this.txtbudgetstart.Size = new System.Drawing.Size(227, 20);
            this.txtbudgetstart.TabIndex = 23;
            // 
            // txttitle
            // 
            this.txttitle.BackColor = System.Drawing.SystemColors.Control;
            this.txttitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttitle.Location = new System.Drawing.Point(389, 21);
            this.txttitle.Multiline = true;
            this.txttitle.Name = "txttitle";
            this.txttitle.ReadOnly = true;
            this.txttitle.Size = new System.Drawing.Size(227, 37);
            this.txttitle.TabIndex = 22;
            // 
            // txtdescription
            // 
            this.txtdescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtdescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdescription.Location = new System.Drawing.Point(625, 50);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.ReadOnly = true;
            this.txtdescription.Size = new System.Drawing.Size(279, 86);
            this.txtdescription.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(622, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Budget End Period:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Budget Starting Period:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Start Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Title:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 123);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 81);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Chem";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 49);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Patientno";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(88, 75);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "hema and viral";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(88, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "CD4 Test Number";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(88, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Supply Procurement Report";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Supply Report";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMorbidity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 702);
            this.Controls.Add(this.taskPane1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMorbidity";
            this.Text = "Morbidity Forecast";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.taskPane1.ResumeLayout(false);
            this.taskFrame1.ResumeLayout(false);
            this.taskFrame1.PerformLayout();
            this.taskFrame2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Samples.Windows.Forms.TaskPane.TaskPane taskPane1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame taskFrame1;
        private Microsoft.Samples.Windows.Forms.TaskPane.TaskFrame taskFrame2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtstartdate;
        private System.Windows.Forms.TextBox txtbudgetend;
        private System.Windows.Forms.TextBox txtbudgetstart;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}
