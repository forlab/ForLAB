
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.MorbidityUserCtr
{
    partial class OptRecentData
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
            this.label3 = new System.Windows.Forms.Label();
            this.lqtCheckBox1 = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.lqtCheckBox2 = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 57);
            this.label3.TabIndex = 2;
            this.label3.Text = "1- Enter patient numbers for at each site.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lqtCheckBox1
            // 
            this.lqtCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.lqtCheckBox1.Checked = false;
            this.lqtCheckBox1.Location = new System.Drawing.Point(44, 51);
            this.lqtCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.lqtCheckBox1.Name = "lqtCheckBox1";
            this.lqtCheckBox1.Size = new System.Drawing.Size(33, 33);
            this.lqtCheckBox1.TabIndex = 8;
            this.lqtCheckBox1.Tag = "1";
            // 
            // lqtCheckBox2
            // 
            this.lqtCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.lqtCheckBox2.Checked = false;
            this.lqtCheckBox2.Location = new System.Drawing.Point(44, 128);
            this.lqtCheckBox2.Margin = new System.Windows.Forms.Padding(0);
            this.lqtCheckBox2.Name = "lqtCheckBox2";
            this.lqtCheckBox2.Size = new System.Drawing.Size(33, 33);
            this.lqtCheckBox2.TabIndex = 9;
            this.lqtCheckBox2.Tag = "2";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 57);
            this.label1.TabIndex = 10;
            this.label1.Text = "2- Enter patient numbers for a different month that is\r\n     available and apply " +
                "the same percentages to sites\r\n     for the current forecast.";
            // 
            // OptRecentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lqtCheckBox2);
            this.Controls.Add(this.lqtCheckBox1);
            this.Controls.Add(this.label3);
            this.Name = "OptRecentData";
            this.Size = new System.Drawing.Size(716, 311);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private LQTCheckBox lqtCheckBox1;
        private LQTCheckBox lqtCheckBox2;
        private System.Windows.Forms.Label label1;
    }
}
