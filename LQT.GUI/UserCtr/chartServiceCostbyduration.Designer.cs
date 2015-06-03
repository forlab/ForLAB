
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
    partial class chartServiceCostbyduration
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lqtChart2 = new LQT.GUI.LQTChart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkshowlabel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lqtChart2)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lqtChart2
            // 
            this.lqtChart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
            this.lqtChart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.lqtChart2.BorderlineColor = System.Drawing.Color.DarkRed;
            this.lqtChart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.lqtChart2.BorderlineWidth = 2;
            this.lqtChart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Format = "MMM yyyy";
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.IsStaggered = true;
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 8F);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.Name = "ChartArea1";
            this.lqtChart2.ChartAreas.Add(chartArea1);
            this.lqtChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.lqtChart2.Legends.Add(legend1);
            this.lqtChart2.Location = new System.Drawing.Point(0, 30);
            this.lqtChart2.Name = "lqtChart2";
            this.lqtChart2.Size = new System.Drawing.Size(352, 278);
            this.lqtChart2.TabIndex = 11;
            this.lqtChart2.Text = "lqtChart2";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            this.lqtChart2.Titles.Add(title1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.chkshowlabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(352, 30);
            this.panel4.TabIndex = 12;
            // 
            // chkshowlabel
            // 
            this.chkshowlabel.AutoSize = true;
            this.chkshowlabel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkshowlabel.Location = new System.Drawing.Point(5, 7);
            this.chkshowlabel.Name = "chkshowlabel";
            this.chkshowlabel.Size = new System.Drawing.Size(138, 17);
            this.chkshowlabel.TabIndex = 1;
            this.chkshowlabel.Text = "Show DataPoint Values";
            this.chkshowlabel.UseVisualStyleBackColor = true;
            this.chkshowlabel.CheckedChanged += new System.EventHandler(this.chkshowlabel_CheckedChanged);
            // 
            // chartServiceCostbyduration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.lqtChart2);
            this.Controls.Add(this.panel4);
            this.Name = "chartServiceCostbyduration";
            this.Size = new System.Drawing.Size(352, 308);
            this.Load += new System.EventHandler(this.chartServiceCostbyduration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lqtChart2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LQTChart lqtChart2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkshowlabel;

    }
}
