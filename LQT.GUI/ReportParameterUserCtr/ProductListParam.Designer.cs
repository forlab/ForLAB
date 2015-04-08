
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
    partial class ProductListParam
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
            this.btnViewreport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnViewreport
            // 
            this.btnViewreport.Location = new System.Drawing.Point(12, 50);
            this.btnViewreport.Name = "btnViewreport";
            this.btnViewreport.Size = new System.Drawing.Size(75, 23);
            this.btnViewreport.TabIndex = 13;
            this.btnViewreport.Text = "View Report";
            this.btnViewreport.UseVisualStyleBackColor = true;
            this.btnViewreport.Click += new System.EventHandler(this.btnViewreport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Product Category:";
            // 
            // comCategory
            // 
            this.comCategory.DisplayMember = "TypeName";
            this.comCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(104, 15);
            this.comCategory.Name = "comCategory";
            this.comCategory.Size = new System.Drawing.Size(256, 21);
            this.comCategory.TabIndex = 16;
            this.comCategory.ValueMember = "Id";
            // 
            // ProductListParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnViewreport);
            this.Name = "ProductListParam";
            this.Size = new System.Drawing.Size(728, 79);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewreport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comCategory;
    }
}
