
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
    partial class RegionListParam
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
            this.chknoofsite = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comlogic = new System.Windows.Forms.ComboBox();
            this.txtnoofsite = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnviewreport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chknoofsite
            // 
            this.chknoofsite.AutoSize = true;
            this.chknoofsite.Location = new System.Drawing.Point(19, 16);
            this.chknoofsite.Name = "chknoofsite";
            this.chknoofsite.Size = new System.Drawing.Size(114, 17);
            this.chknoofsite.TabIndex = 0;
            this.chknoofsite.Text = "Include No. of Site";
            this.chknoofsite.UseVisualStyleBackColor = true;
            this.chknoofsite.CheckedChanged += new System.EventHandler(this.chknoofsite_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "No. of Site:";
            // 
            // comlogic
            // 
            this.comlogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comlogic.FormattingEnabled = true;
            this.comlogic.Items.AddRange(new object[] {
            "",
            ">",
            "<",
            "="});
            this.comlogic.Location = new System.Drawing.Point(69, 7);
            this.comlogic.Name = "comlogic";
            this.comlogic.Size = new System.Drawing.Size(39, 21);
            this.comlogic.TabIndex = 2;
            // 
            // txtnoofsite
            // 
            this.txtnoofsite.Location = new System.Drawing.Point(110, 8);
            this.txtnoofsite.Name = "txtnoofsite";
            this.txtnoofsite.Size = new System.Drawing.Size(47, 20);
            this.txtnoofsite.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtnoofsite);
            this.panel1.Controls.Add(this.comlogic);
            this.panel1.Location = new System.Drawing.Point(159, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 35);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // btnviewreport
            // 
            this.btnviewreport.Location = new System.Drawing.Point(19, 55);
            this.btnviewreport.Name = "btnviewreport";
            this.btnviewreport.Size = new System.Drawing.Size(75, 23);
            this.btnviewreport.TabIndex = 5;
            this.btnviewreport.Text = "View Report";
            this.btnviewreport.UseVisualStyleBackColor = true;
            this.btnviewreport.Click += new System.EventHandler(this.btnviewreport_Click);
            // 
            // RegionListParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnviewreport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chknoofsite);
            this.Name = "RegionListParam";
            this.Size = new System.Drawing.Size(568, 88);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chknoofsite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comlogic;
        private System.Windows.Forms.TextBox txtnoofsite;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnviewreport;
    }
}
