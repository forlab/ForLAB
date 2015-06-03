
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI
{
    partial class FrmFillterSite
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comRegion = new System.Windows.Forms.ComboBox();
            this.comSite = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Region/District/Province :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Site Name:";
            // 
            // comRegion
            // 
            this.comRegion.DisplayMember = "RegionName";
            this.comRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comRegion.FormattingEnabled = true;
            this.comRegion.Location = new System.Drawing.Point(148, 12);
            this.comRegion.Name = "comRegion";
            this.comRegion.Size = new System.Drawing.Size(179, 21);
            this.comRegion.TabIndex = 2;
            this.comRegion.ValueMember = "Id";
            this.comRegion.SelectedIndexChanged += new System.EventHandler(this.comRegion_SelectedIndexChanged);
            // 
            // comSite
            // 
            this.comSite.DisplayMember = "SiteName";
            this.comSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSite.FormattingEnabled = true;
            this.comSite.Location = new System.Drawing.Point(148, 39);
            this.comSite.Name = "comSite";
            this.comSite.Size = new System.Drawing.Size(179, 21);
            this.comSite.TabIndex = 3;
            this.comSite.ValueMember = "Id";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(252, 65);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmFillterSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 88);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comSite);
            this.Controls.Add(this.comRegion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmFillterSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Site";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comRegion;
        private System.Windows.Forms.ComboBox comSite;
        private System.Windows.Forms.Button btnOk;
    }
}
