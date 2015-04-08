
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

namespace LQT.GUI.ReportBorwser
{
    partial class FrmReportParameter
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
            this.lblforecastno = new System.Windows.Forms.Label();
            this.lblreporttype = new System.Windows.Forms.Label();
            this.cobforecast = new System.Windows.Forms.ComboBox();
            this.cobreporttype = new System.Windows.Forms.ComboBox();
            this.btnviewreport = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblforecastno
            // 
            this.lblforecastno.AutoSize = true;
            this.lblforecastno.Location = new System.Drawing.Point(12, 20);
            this.lblforecastno.Name = "lblforecastno";
            this.lblforecastno.Size = new System.Drawing.Size(74, 13);
            this.lblforecastno.TabIndex = 0;
            this.lblforecastno.Text = "Forecast No. :";
            // 
            // lblreporttype
            // 
            this.lblreporttype.AutoSize = true;
            this.lblreporttype.Location = new System.Drawing.Point(12, 47);
            this.lblreporttype.Name = "lblreporttype";
            this.lblreporttype.Size = new System.Drawing.Size(69, 13);
            this.lblreporttype.TabIndex = 1;
            this.lblreporttype.Text = "Report Type:";
            // 
            // cobforecast
            // 
            this.cobforecast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobforecast.FormattingEnabled = true;
            this.cobforecast.Location = new System.Drawing.Point(92, 17);
            this.cobforecast.Name = "cobforecast";
            this.cobforecast.Size = new System.Drawing.Size(333, 21);
            this.cobforecast.TabIndex = 2;
            // 
            // cobreporttype
            // 
            this.cobreporttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobreporttype.FormattingEnabled = true;
            this.cobreporttype.Items.AddRange(new object[] {
            "Full Aggregate Summary",
            "Grouped By Site/Category"});
            this.cobreporttype.Location = new System.Drawing.Point(92, 44);
            this.cobreporttype.Name = "cobreporttype";
            this.cobreporttype.Size = new System.Drawing.Size(214, 21);
            this.cobreporttype.TabIndex = 3;
            // 
            // btnviewreport
            // 
            this.btnviewreport.Location = new System.Drawing.Point(269, 81);
            this.btnviewreport.Name = "btnviewreport";
            this.btnviewreport.Size = new System.Drawing.Size(75, 23);
            this.btnviewreport.TabIndex = 4;
            this.btnviewreport.Text = "View Report";
            this.btnviewreport.UseVisualStyleBackColor = true;
            this.btnviewreport.Click += new System.EventHandler(this.btnviewreport_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(350, 81);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // FrmReportParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 109);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnviewreport);
            this.Controls.Add(this.cobreporttype);
            this.Controls.Add(this.cobforecast);
            this.Controls.Add(this.lblreporttype);
            this.Controls.Add(this.lblforecastno);
            this.Name = "FrmReportParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Parameter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblforecastno;
        private System.Windows.Forms.Label lblreporttype;
        private System.Windows.Forms.ComboBox cobforecast;
        private System.Windows.Forms.ComboBox cobreporttype;
        private System.Windows.Forms.Button btnviewreport;
        private System.Windows.Forms.Button btnclose;
    }
}
