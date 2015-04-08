
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
    partial class FrmReportedPeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportedPeriod));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.butOk = new System.Windows.Forms.Button();
            this.lblstartdate = new System.Windows.Forms.Label();
            this.rdodown = new System.Windows.Forms.RadioButton();
            this.rdoup = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Reporting Period";
            this.label1.Visible = false;
            // 
            // txtPeriod
            // 
            this.txtPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPeriod.Location = new System.Drawing.Point(15, 28);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(123, 20);
            this.txtPeriod.TabIndex = 1;
            this.txtPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriod_KeyPress);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(141, 26);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(38, 23);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // lblstartdate
            // 
            this.lblstartdate.AutoSize = true;
            this.lblstartdate.Location = new System.Drawing.Point(12, 9);
            this.lblstartdate.Name = "lblstartdate";
            this.lblstartdate.Size = new System.Drawing.Size(61, 13);
            this.lblstartdate.TabIndex = 3;
            this.lblstartdate.Text = "Start Date :";
            // 
            // rdodown
            // 
            this.rdodown.AutoSize = true;
            this.rdodown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdodown.Image = ((System.Drawing.Image)(resources.GetObject("rdodown.Image")));
            this.rdodown.Location = new System.Drawing.Point(150, 86);
            this.rdodown.Name = "rdodown";
            this.rdodown.Size = new System.Drawing.Size(27, 17);
            this.rdodown.TabIndex = 7;
            this.rdodown.Text = " ";
            this.rdodown.UseVisualStyleBackColor = true;
            this.rdodown.Visible = false;
            // 
            // rdoup
            // 
            this.rdoup.AutoSize = true;
            this.rdoup.Checked = true;
            this.rdoup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdoup.Image = ((System.Drawing.Image)(resources.GetObject("rdoup.Image")));
            this.rdoup.Location = new System.Drawing.Point(150, 7);
            this.rdoup.Name = "rdoup";
            this.rdoup.Size = new System.Drawing.Size(27, 17);
            this.rdoup.TabIndex = 6;
            this.rdoup.TabStop = true;
            this.rdoup.Text = " ";
            this.rdoup.UseVisualStyleBackColor = true;
            // 
            // FrmReportedPeriod
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 53);
            this.Controls.Add(this.rdodown);
            this.Controls.Add(this.rdoup);
            this.Controls.Add(this.lblstartdate);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.txtPeriod);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReportedPeriod";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Label lblstartdate;
        private System.Windows.Forms.RadioButton rdoup;
        private System.Windows.Forms.RadioButton rdodown;
    }
}
