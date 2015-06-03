
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.ReportParameterUserCtr
{
    partial class ComparisionReportParam
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cobconsumption = new System.Windows.Forms.ComboBox();
            this.cobdemography = new System.Windows.Forms.ComboBox();
            this.cobservice = new System.Windows.Forms.ComboBox();
            this.btnviewreport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Demographic Methodology";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Service Statistic Methodology";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consumption Methodology";
            // 
            // cobconsumption
            // 
            this.cobconsumption.DisplayMember = "ForecastNo";
            this.cobconsumption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobconsumption.FormattingEnabled = true;
            this.cobconsumption.Location = new System.Drawing.Point(176, 13);
            this.cobconsumption.Name = "cobconsumption";
            this.cobconsumption.Size = new System.Drawing.Size(283, 21);
            this.cobconsumption.TabIndex = 3;
            this.cobconsumption.ValueMember = "Id";
            // 
            // cobdemography
            // 
            this.cobdemography.DisplayMember = "Title";
            this.cobdemography.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobdemography.FormattingEnabled = true;
            this.cobdemography.Location = new System.Drawing.Point(176, 68);
            this.cobdemography.Name = "cobdemography";
            this.cobdemography.Size = new System.Drawing.Size(283, 21);
            this.cobdemography.TabIndex = 4;
            this.cobdemography.ValueMember = "Id";
            // 
            // cobservice
            // 
            this.cobservice.DisplayMember = "ForecastNo";
            this.cobservice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobservice.FormattingEnabled = true;
            this.cobservice.Location = new System.Drawing.Point(176, 40);
            this.cobservice.Name = "cobservice";
            this.cobservice.Size = new System.Drawing.Size(283, 21);
            this.cobservice.TabIndex = 5;
            this.cobservice.ValueMember = "Id";
            // 
            // btnviewreport
            // 
            this.btnviewreport.Location = new System.Drawing.Point(19, 112);
            this.btnviewreport.Name = "btnviewreport";
            this.btnviewreport.Size = new System.Drawing.Size(75, 23);
            this.btnviewreport.TabIndex = 6;
            this.btnviewreport.Text = "View Report";
            this.btnviewreport.UseVisualStyleBackColor = true;
            this.btnviewreport.Click += new System.EventHandler(this.btnviewreport_Click);
            // 
            // ComparisionReportParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnviewreport);
            this.Controls.Add(this.cobservice);
            this.Controls.Add(this.cobdemography);
            this.Controls.Add(this.cobconsumption);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ComparisionReportParam";
            this.Size = new System.Drawing.Size(881, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobconsumption;
        private System.Windows.Forms.ComboBox cobdemography;
        private System.Windows.Forms.ComboBox cobservice;
        private System.Windows.Forms.Button btnviewreport;
    }
}
