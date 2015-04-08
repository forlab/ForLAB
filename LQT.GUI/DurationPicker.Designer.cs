
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
