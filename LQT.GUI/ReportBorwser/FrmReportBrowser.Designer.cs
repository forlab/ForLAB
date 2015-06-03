
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.Reports
{
    partial class FrmReportBrowser
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
            this.components = new System.ComponentModel.Container();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.imageListReports = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvFiles
            // 
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.LargeImageList = this.imageListReports;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(562, 346);
            this.lvFiles.TabIndex = 3;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.DoubleClick += new System.EventHandler(this.lvFiles_DoubleClick);
            // 
            // imageListReports
            // 
            this.imageListReports.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListReports.ImageSize = new System.Drawing.Size(138, 138);
            this.imageListReports.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmReportBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 346);
            this.Controls.Add(this.lvFiles);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReportBrowser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Browser";
            this.Load += new System.EventHandler(this.FrmReportBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ImageList imageListReports;
    }
}
