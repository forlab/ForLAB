
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

namespace LQT.GUI.MorbidityUserCtr
{
    partial class OpEverStartedPatientTarget
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
            this.label4 = new System.Windows.Forms.Label();
            this.chbNodata = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbOlddata = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.chbRecentdata = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(111, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(348, 53);
            this.label4.TabIndex = 16;
            this.label4.Text = "3-Enter one national number for patients\r\n    EVER STARTED.  Apply same percentag" +
                "es used\r\n    for Current Patients to each of the sites.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbNodata
            // 
            this.chbNodata.BackColor = System.Drawing.Color.Transparent;
            this.chbNodata.Checked = false;
            this.chbNodata.Location = new System.Drawing.Point(59, 195);
            this.chbNodata.Margin = new System.Windows.Forms.Padding(0);
            this.chbNodata.Name = "chbNodata";
            this.chbNodata.Size = new System.Drawing.Size(33, 33);
            this.chbNodata.TabIndex = 15;
            this.chbNodata.Tag = "3";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 53);
            this.label2.TabIndex = 14;
            this.label2.Text = "2-Enter data for a different month that is available\r\n    and apply the same perc" +
                "entages to sites for the \r\n    current forecast.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 53);
            this.label1.TabIndex = 13;
            this.label1.Text = "1-Enter EVER STARTED patient numbers\r\n   For at each Site";
            // 
            // chbOlddata
            // 
            this.chbOlddata.BackColor = System.Drawing.Color.Transparent;
            this.chbOlddata.Checked = false;
            this.chbOlddata.Location = new System.Drawing.Point(59, 124);
            this.chbOlddata.Margin = new System.Windows.Forms.Padding(0);
            this.chbOlddata.Name = "chbOlddata";
            this.chbOlddata.Size = new System.Drawing.Size(33, 33);
            this.chbOlddata.TabIndex = 12;
            this.chbOlddata.Tag = "2";
            // 
            // chbRecentdata
            // 
            this.chbRecentdata.BackColor = System.Drawing.Color.Transparent;
            this.chbRecentdata.Checked = false;
            this.chbRecentdata.Location = new System.Drawing.Point(59, 55);
            this.chbRecentdata.Margin = new System.Windows.Forms.Padding(0);
            this.chbRecentdata.Name = "chbRecentdata";
            this.chbRecentdata.Size = new System.Drawing.Size(33, 33);
            this.chbRecentdata.TabIndex = 11;
            this.chbRecentdata.Tag = "1";
            // 
            // OpEverStartedPatientTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbNodata);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbOlddata);
            this.Controls.Add(this.chbRecentdata);
            this.Name = "OpEverStartedPatientTarget";
            this.Size = new System.Drawing.Size(609, 270);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private LQTCheckBox chbNodata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private LQTCheckBox chbOlddata;
        private LQTCheckBox chbRecentdata;
    }
}
