
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
    partial class OptTreatmentTarget
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
            this.chbOntreatment = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.chbEverstarted = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chbOntreatment
            // 
            this.chbOntreatment.BackColor = System.Drawing.Color.Transparent;
            this.chbOntreatment.Checked = false;
            this.chbOntreatment.Location = new System.Drawing.Point(71, 67);
            this.chbOntreatment.Margin = new System.Windows.Forms.Padding(0);
            this.chbOntreatment.Name = "chbOntreatment";
            this.chbOntreatment.Size = new System.Drawing.Size(33, 33);
            this.chbOntreatment.TabIndex = 0;
            this.chbOntreatment.Tag = "1";
            // 
            // chbEverstarted
            // 
            this.chbEverstarted.BackColor = System.Drawing.Color.Transparent;
            this.chbEverstarted.Checked = false;
            this.chbEverstarted.Location = new System.Drawing.Point(71, 110);
            this.chbEverstarted.Margin = new System.Windows.Forms.Padding(0);
            this.chbEverstarted.Name = "chbEverstarted";
            this.chbEverstarted.Size = new System.Drawing.Size(33, 33);
            this.chbEverstarted.TabIndex = 1;
            this.chbEverstarted.Tag = "2";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "1-Patients actually ON treatment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "2-Patients EVER STARTED on Treatment";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OptTreatmentTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbEverstarted);
            this.Controls.Add(this.chbOntreatment);
            this.Name = "OptTreatmentTarget";
            this.Size = new System.Drawing.Size(463, 284);
            this.ResumeLayout(false);

        }

        #endregion

        private LQTCheckBox chbOntreatment;
        private LQTCheckBox chbEverstarted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
