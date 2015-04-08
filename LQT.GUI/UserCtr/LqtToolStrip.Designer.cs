
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

namespace LQT.GUI.UserCtr
{
    partial class LqtToolStrip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LqtToolStrip));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSaveandclose = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveandnew = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveandclose,
            this.tsbSaveandnew});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(529, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSaveandclose
            // 
            this.tsbSaveandclose.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveandclose.Image")));
            this.tsbSaveandclose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveandclose.Name = "tsbSaveandclose";
            this.tsbSaveandclose.Size = new System.Drawing.Size(114, 28);
            this.tsbSaveandclose.Text = "Save and Close";
            this.tsbSaveandclose.Click += new System.EventHandler(this.tsbSaveandclose_Click);
            // 
            // tsbSaveandnew
            // 
            this.tsbSaveandnew.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveandnew.Image")));
            this.tsbSaveandnew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveandnew.Name = "tsbSaveandnew";
            this.tsbSaveandnew.Size = new System.Drawing.Size(109, 28);
            this.tsbSaveandnew.Text = "Save and New";
            this.tsbSaveandnew.Click += new System.EventHandler(this.tsbSaveandnew_Click);
            // 
            // LqtToolStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "LqtToolStrip";
            this.Size = new System.Drawing.Size(529, 31);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSaveandclose;
        private System.Windows.Forms.ToolStripButton tsbSaveandnew;
    }
}
