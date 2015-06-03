
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
    partial class MorbidityNoofTestReportParam
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
            this.cobdemography = new System.Windows.Forms.ComboBox();
            this.btnviewreport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Demographic Methodology";
            // 
            // cobdemography
            // 
            this.cobdemography.DisplayMember = "Title";
            this.cobdemography.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobdemography.FormattingEnabled = true;
            this.cobdemography.Location = new System.Drawing.Point(172, 17);
            this.cobdemography.Name = "cobdemography";
            this.cobdemography.Size = new System.Drawing.Size(283, 21);
            this.cobdemography.TabIndex = 4;
            this.cobdemography.ValueMember = "Id";
            // 
            // btnviewreport
            // 
            this.btnviewreport.Location = new System.Drawing.Point(15, 54);
            this.btnviewreport.Name = "btnviewreport";
            this.btnviewreport.Size = new System.Drawing.Size(75, 23);
            this.btnviewreport.TabIndex = 6;
            this.btnviewreport.Text = "View Report";
            this.btnviewreport.UseVisualStyleBackColor = true;
            this.btnviewreport.Click += new System.EventHandler(this.btnviewreport_Click);
            // 
            // MorbidityNoofTestReportParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnviewreport);
            this.Controls.Add(this.cobdemography);
            this.Controls.Add(this.label3);
            this.Name = "MorbidityNoofTestReportParam";
            this.Size = new System.Drawing.Size(881, 89);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobdemography;
        private System.Windows.Forms.Button btnviewreport;
    }
}
