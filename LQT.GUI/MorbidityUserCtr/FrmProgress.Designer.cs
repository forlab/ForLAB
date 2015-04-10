
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
    partial class FrmProgress
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTasks = new System.Windows.Forms.Label();
            this.bwCalculation = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lqtProgressBar1 = new LQT.GUI.LQTProgressBar();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblProgress, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lqtProgressBar1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.progressBar1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTasks, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(537, 61);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lblProgress
            // 
            this.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProgress.Location = new System.Drawing.Point(203, 3);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(331, 31);
            this.lblProgress.TabIndex = 28;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(203, 34);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(331, 25);
            this.progressBar1.TabIndex = 27;
            // 
            // lblTasks
            // 
            this.lblTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasks.ForeColor = System.Drawing.Color.Navy;
            this.lblTasks.Location = new System.Drawing.Point(3, 3);
            this.lblTasks.Margin = new System.Windows.Forms.Padding(0);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(200, 30);
            this.lblTasks.TabIndex = 30;
            this.lblTasks.Text = "Tasks to do";
            this.lblTasks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bwCalculation
            // 
            this.bwCalculation.WorkerReportsProgress = true;
            this.bwCalculation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCalculation_DoWork);
            this.bwCalculation.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCalculation_ProgressChanged);
            this.bwCalculation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCalculation_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lqtProgressBar1
            // 
            this.lqtProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.lqtProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lqtProgressBar1.ForeColor = System.Drawing.Color.White;
            this.lqtProgressBar1.Location = new System.Drawing.Point(3, 34);
            this.lqtProgressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.lqtProgressBar1.Name = "lqtProgressBar1";
            this.lqtProgressBar1.Size = new System.Drawing.Size(200, 25);
            this.lqtProgressBar1.Step = 0;
            this.lqtProgressBar1.TabIndex = 29;
            this.lqtProgressBar1.Text = "0";
            this.lqtProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lqtProgressBar1.Value = 0;
            // 
            // FrmProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(537, 61);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblProgress;
        private LQTProgressBar lqtProgressBar1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTasks;
        private System.ComponentModel.BackgroundWorker bwCalculation;
        private System.Windows.Forms.Timer timer1;
    }
}
