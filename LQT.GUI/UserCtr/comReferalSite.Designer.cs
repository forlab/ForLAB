
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.UserCtr
{
    partial class comReferalSite
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
            this.txtsitename = new System.Windows.Forms.TextBox();
            this.btnaddrefsite = new System.Windows.Forms.Button();
            this.butnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtsitename
            // 
            this.txtsitename.Location = new System.Drawing.Point(2, 2);
            this.txtsitename.Name = "txtsitename";
            this.txtsitename.ReadOnly = true;
            this.txtsitename.Size = new System.Drawing.Size(114, 20);
            this.txtsitename.TabIndex = 0;
            // 
            // btnaddrefsite
            // 
            this.btnaddrefsite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddrefsite.Location = new System.Drawing.Point(116, 0);
            this.btnaddrefsite.Name = "btnaddrefsite";
            this.btnaddrefsite.Size = new System.Drawing.Size(30, 23);
            this.btnaddrefsite.TabIndex = 1;
            this.btnaddrefsite.Text = "...";
            this.btnaddrefsite.UseVisualStyleBackColor = true;
            this.btnaddrefsite.Click += new System.EventHandler(this.btnaddrefsite_Click);
            // 
            // butnDelete
            // 
            this.butnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.butnDelete.Location = new System.Drawing.Point(146, 0);
            this.butnDelete.Name = "butnDelete";
            this.butnDelete.Size = new System.Drawing.Size(38, 23);
            this.butnDelete.TabIndex = 2;
            this.butnDelete.Text = "Del";
            this.butnDelete.UseVisualStyleBackColor = true;
            this.butnDelete.Click += new System.EventHandler(this.butnDelete_Click);
            // 
            // comReferalSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.butnDelete);
            this.Controls.Add(this.btnaddrefsite);
            this.Controls.Add(this.txtsitename);
            this.Name = "comReferalSite";
            this.Size = new System.Drawing.Size(184, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsitename;
        private System.Windows.Forms.Button btnaddrefsite;
        private System.Windows.Forms.Button butnDelete;
    }
}
