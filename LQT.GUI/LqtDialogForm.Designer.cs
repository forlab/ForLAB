
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
    partial class LqtDialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LqtDialogForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSaveandclose = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveandnew = new System.Windows.Forms.ToolStripButton();
            this.tlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveandclose,
            this.tsbSaveandnew});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(540, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSaveandclose
            // 
            this.tsbSaveandclose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveandclose.Name = "tsbSaveandclose";
            this.tsbSaveandclose.Size = new System.Drawing.Size(90, 36);
            this.tsbSaveandclose.Text = "Save and Close";
            // 
            // tsbSaveandnew
            // 
            this.tsbSaveandnew.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveandnew.Image")));
            this.tsbSaveandnew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveandnew.Name = "tsbSaveandnew";
            this.tsbSaveandnew.Size = new System.Drawing.Size(117, 36);
            this.tsbSaveandnew.Text = "Save and New";
            // 
            // tlPanel
            // 
            this.tlPanel.ColumnCount = 1;
            this.tlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPanel.Location = new System.Drawing.Point(0, 39);
            this.tlPanel.Name = "tlPanel";
            this.tlPanel.RowCount = 1;
            this.tlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlPanel.Size = new System.Drawing.Size(540, 262);
            this.tlPanel.TabIndex = 4;
            // 
            // LqtDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 301);
            this.Controls.Add(this.tlPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LqtDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LqtDialogForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSaveandclose;
        private System.Windows.Forms.ToolStripButton tsbSaveandnew;
        private System.Windows.Forms.TableLayoutPanel tlPanel;
    }
}
