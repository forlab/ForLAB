
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
    partial class DurationPicker
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
            this.comYear = new System.Windows.Forms.ComboBox();
            this.comMonth = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comYear
            // 
            this.comYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comYear.FormattingEnabled = true;
            this.comYear.Location = new System.Drawing.Point(1, 1);
            this.comYear.Margin = new System.Windows.Forms.Padding(0);
            this.comYear.Name = "comYear";
            this.comYear.Size = new System.Drawing.Size(70, 21);
            this.comYear.TabIndex = 0;
            // 
            // comMonth
            // 
            this.comMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comMonth.FormattingEnabled = true;
            this.comMonth.Location = new System.Drawing.Point(74, 1);
            this.comMonth.Margin = new System.Windows.Forms.Padding(0);
            this.comMonth.Name = "comMonth";
            this.comMonth.Size = new System.Drawing.Size(121, 21);
            this.comMonth.TabIndex = 1;
            // 
            // DurationPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.comMonth);
            this.Controls.Add(this.comYear);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DurationPicker";
            this.Size = new System.Drawing.Size(198, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comYear;
        private System.Windows.Forms.ComboBox comMonth;
    }
}
