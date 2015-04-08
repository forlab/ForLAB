
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
    partial class SiteListParam
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkworkingday = new System.Windows.Forms.CheckBox();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.comRegion = new System.Windows.Forms.ComboBox();
            this.btnViewreport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comstatus = new System.Windows.Forms.ComboBox();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.lbldate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Region:";
            // 
            // chkworkingday
            // 
            this.chkworkingday.AutoSize = true;
            this.chkworkingday.Location = new System.Drawing.Point(87, 79);
            this.chkworkingday.Name = "chkworkingday";
            this.chkworkingday.Size = new System.Drawing.Size(131, 17);
            this.chkworkingday.TabIndex = 2;
            this.chkworkingday.Text = "Include Working Days";
            this.chkworkingday.UseVisualStyleBackColor = true;
            // 
            // comCategory
            // 
            this.comCategory.DisplayMember = "CategoryName";
            this.comCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(87, 23);
            this.comCategory.Name = "comCategory";
            this.comCategory.Size = new System.Drawing.Size(183, 21);
            this.comCategory.TabIndex = 12;
            this.comCategory.ValueMember = "Id";
            // 
            // comRegion
            // 
            this.comRegion.DisplayMember = "RegionName";
            this.comRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comRegion.FormattingEnabled = true;
            this.comRegion.Location = new System.Drawing.Point(87, 50);
            this.comRegion.Name = "comRegion";
            this.comRegion.Size = new System.Drawing.Size(183, 21);
            this.comRegion.TabIndex = 11;
            this.comRegion.ValueMember = "Id";
            // 
            // btnViewreport
            // 
            this.btnViewreport.Location = new System.Drawing.Point(11, 114);
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
            this.label3.Location = new System.Drawing.Point(293, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Status:";
            // 
            // comstatus
            // 
            this.comstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comstatus.FormattingEnabled = true;
            this.comstatus.Items.AddRange(new object[] {
            "< Select Option >",
            "Open",
            "Close"});
            this.comstatus.Location = new System.Drawing.Point(339, 23);
            this.comstatus.Name = "comstatus";
            this.comstatus.Size = new System.Drawing.Size(183, 21);
            this.comstatus.TabIndex = 15;
            this.comstatus.SelectedIndexChanged += new System.EventHandler(this.comstatus_SelectedIndexChanged);
            // 
            // dtpdate
            // 
            this.dtpdate.Location = new System.Drawing.Point(339, 50);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(183, 20);
            this.dtpdate.TabIndex = 16;
            this.dtpdate.Visible = false;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(293, 53);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(40, 13);
            this.lbldate.TabIndex = 17;
            this.lbldate.Text = "Month:";
            this.lbldate.Visible = false;
            // 
            // SiteListParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.comstatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnViewreport);
            this.Controls.Add(this.comCategory);
            this.Controls.Add(this.comRegion);
            this.Controls.Add(this.chkworkingday);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SiteListParam";
            this.Size = new System.Drawing.Size(728, 147);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkworkingday;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.ComboBox comRegion;
        private System.Windows.Forms.Button btnViewreport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comstatus;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label lbldate;
    }
}
