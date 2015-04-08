
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

namespace LQT.GUI.Location
{
    partial class FrmReferalSite
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
            this.label2 = new System.Windows.Forms.Label();
            this.cobRegion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cobsite = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Referal Site:";
            // 
            // cobRegion
            // 
            this.cobRegion.DisplayMember = "RegionName";
            this.cobRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobRegion.FormattingEnabled = true;
            this.cobRegion.Location = new System.Drawing.Point(150, 6);
            this.cobRegion.Name = "cobRegion";
            this.cobRegion.Size = new System.Drawing.Size(189, 21);
            this.cobRegion.TabIndex = 3;
            this.cobRegion.ValueMember = "Id";
            this.cobRegion.SelectedIndexChanged += new System.EventHandler(this.cobRegion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Region/District/Province:";
            // 
            // cobsite
            // 
            this.cobsite.DisplayMember = "SiteName";
            this.cobsite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobsite.FormattingEnabled = true;
            this.cobsite.Location = new System.Drawing.Point(150, 33);
            this.cobsite.Name = "cobsite";
            this.cobsite.Size = new System.Drawing.Size(189, 21);
            this.cobsite.TabIndex = 5;
            this.cobsite.ValueMember = "Id";
            this.cobsite.SelectedIndexChanged += new System.EventHandler(this.cobsite_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(183, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btncancel
            // 
            this.btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancel.Location = new System.Drawing.Point(264, 60);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 7;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // FrmReferalSite
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btncancel;
            this.ClientSize = new System.Drawing.Size(362, 89);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cobsite);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cobRegion);
            this.Controls.Add(this.label2);
            this.Name = "FrmReferalSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Referal Site";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cobRegion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobsite;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btncancel;
    }
}
