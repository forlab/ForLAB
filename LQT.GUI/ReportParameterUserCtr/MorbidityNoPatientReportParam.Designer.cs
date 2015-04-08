
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

namespace LQT.GUI.ReportParameterUserCtr
{
    partial class MorbidityNoPatientReportParam
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
            // MorbidityNoPatientReportParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnviewreport);
            this.Controls.Add(this.cobdemography);
            this.Controls.Add(this.label3);
            this.Name = "MorbidityNoPatientReportParam";
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
