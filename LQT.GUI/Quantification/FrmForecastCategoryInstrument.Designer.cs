
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.Quantification
{
    partial class FrmForecastCategoryInstrument
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
            this.lbtRemove = new System.Windows.Forms.LinkLabel();
            this.lbtAddins = new System.Windows.Forms.LinkLabel();
            this.lsvInstrument = new LQT.GUI.LQTListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lbtRemove
            // 
            this.lbtRemove.AutoSize = true;
            this.lbtRemove.Enabled = false;
            this.lbtRemove.Location = new System.Drawing.Point(96, 9);
            this.lbtRemove.Name = "lbtRemove";
            this.lbtRemove.Size = new System.Drawing.Size(47, 13);
            this.lbtRemove.TabIndex = 313;
            this.lbtRemove.TabStop = true;
            this.lbtRemove.Text = "Remove";
            this.lbtRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtRemove_LinkClicked);
            // 
            // lbtAddins
            // 
            this.lbtAddins.AutoSize = true;
            this.lbtAddins.Location = new System.Drawing.Point(12, 9);
            this.lbtAddins.Name = "lbtAddins";
            this.lbtAddins.Size = new System.Drawing.Size(78, 13);
            this.lbtAddins.TabIndex = 312;
            this.lbtAddins.TabStop = true;
            this.lbtAddins.Text = "Add Instrument";
            this.lbtAddins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddins_LinkClicked);
            // 
            // lsvInstrument
            // 
            this.lsvInstrument.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.lsvInstrument.FullRowSelect = true;
            this.lsvInstrument.GridLines = true;
            this.lsvInstrument.Location = new System.Drawing.Point(12, 29);
            this.lsvInstrument.Name = "lsvInstrument";
            this.lsvInstrument.Size = new System.Drawing.Size(563, 345);
            this.lsvInstrument.TabIndex = 311;
            this.lsvInstrument.TabStop = false;
            this.lsvInstrument.UseCompatibleStateImageBehavior = false;
            this.lsvInstrument.View = System.Windows.Forms.View.Details;
            this.lsvInstrument.SelectedIndexChanged += new System.EventHandler(this.lsvInstrument_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Instrument Name";
            this.columnHeader2.Width = 481;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "% Tests Run";
            this.columnHeader4.Width = 72;
            // 
            // FrmForecastCategoryInstrument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 386);
            this.Controls.Add(this.lbtRemove);
            this.Controls.Add(this.lbtAddins);
            this.Controls.Add(this.lsvInstrument);
            this.Name = "FrmForecastCategoryInstrument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forecast Category Instrument Utilization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmForecastCategoryInstrument_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LQTListView lsvInstrument;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.LinkLabel lbtRemove;
        private System.Windows.Forms.LinkLabel lbtAddins;
    }
}
