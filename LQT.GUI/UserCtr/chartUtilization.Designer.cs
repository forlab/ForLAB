
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
    partial class chartUtilization
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart2 = new LQT.GUI.LQTChart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cobtestingarea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkshowvalues = new System.Windows.Forms.CheckBox();
            this.lstInstrument = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.chart2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstInstrument, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 368);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart2.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart2.BorderlineWidth = 2;
            this.chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LabelStyle.Interval = 0D;
            chartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.LabelStyle.IsStaggered = true;
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LabelStyle.Format = "P";
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "Default";
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend2.IsDockedInsideChartArea = false;
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Default";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(3, 3);
            this.chart2.Name = "chart2";
            series4.BorderWidth = 2;
            series4.ChartArea = "Default";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series4.Legend = "Default";
            series4.Name = "Contribution";
            series4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series4.ShadowOffset = 1;
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series5.BorderWidth = 2;
            series5.ChartArea = "Default";
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series5.Legend = "Default";
            series5.Name = "Utilization";
            series5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series5.ShadowOffset = 1;
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series5.YValuesPerPoint = 4;
            series6.ChartArea = "Default";
            series6.Legend = "Default";
            series6.Name = "Coverage";
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(495, 362);
            this.chart2.TabIndex = 5;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            this.chart2.Titles.Add(title2);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.cobtestingarea);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.chkshowvalues);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 30);
            this.panel3.TabIndex = 1;
            // 
            // cobtestingarea
            // 
            this.cobtestingarea.DisplayMember = "AreaName";
            this.cobtestingarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobtestingarea.FormattingEnabled = true;
            this.cobtestingarea.Location = new System.Drawing.Point(181, 4);
            this.cobtestingarea.Name = "cobtestingarea";
            this.cobtestingarea.Size = new System.Drawing.Size(165, 21);
            this.cobtestingarea.TabIndex = 5;
            this.cobtestingarea.ValueMember = "Id";
            this.cobtestingarea.SelectedIndexChanged += new System.EventHandler(this.cobtestingarea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Testing Area:";
            // 
            // chkshowvalues
            // 
            this.chkshowvalues.AutoSize = true;
            this.chkshowvalues.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkshowvalues.Location = new System.Drawing.Point(3, 7);
            this.chkshowvalues.Name = "chkshowvalues";
            this.chkshowvalues.Size = new System.Drawing.Size(88, 17);
            this.chkshowvalues.TabIndex = 2;
            this.chkshowvalues.Text = "Show Values";
            this.chkshowvalues.UseVisualStyleBackColor = true;
            this.chkshowvalues.CheckedChanged += new System.EventHandler(this.chkshowvalues_CheckedChanged);
            // 
            // lstInstrument
            // 
            this.lstInstrument.CheckOnClick = true;
            this.lstInstrument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInstrument.FormattingEnabled = true;
            this.lstInstrument.Location = new System.Drawing.Point(504, 3);
            this.lstInstrument.Name = "lstInstrument";
            this.lstInstrument.Size = new System.Drawing.Size(120, 362);
            this.lstInstrument.TabIndex = 6;
            this.lstInstrument.SelectedIndexChanged += new System.EventHandler(this.lstInstrument_SelectedIndexChanged);
            // 
            // chartUtilization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Name = "chartUtilization";
            this.Size = new System.Drawing.Size(627, 398);
            this.Load += new System.EventHandler(this.chartSandCForecast_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private LQTChart chart2;
        private System.Windows.Forms.CheckBox chkshowvalues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobtestingarea;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox lstInstrument;

    }
}
