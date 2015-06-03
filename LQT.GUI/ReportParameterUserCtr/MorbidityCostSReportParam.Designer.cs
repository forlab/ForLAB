
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.ReportParameterUserCtr
{
    partial class MorbidityCostSReportParam
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
            this.label3 = new System.Windows.Forms.Label();
            this.cobdemography = new System.Windows.Forms.ComboBox();
            this.btnviewreport = new System.Windows.Forms.Button();
            this.comMethodologey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cobserviceorconsumption = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSiteCat = new System.Windows.Forms.Label();
            this.cobType = new System.Windows.Forms.ComboBox();
            this.cobSite = new System.Windows.Forms.ComboBox();
            this.cobCat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forecast";
            // 
            // cobdemography
            // 
            this.cobdemography.DisplayMember = "Title";
            this.cobdemography.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobdemography.FormattingEnabled = true;
            this.cobdemography.Location = new System.Drawing.Point(111, 39);
            this.cobdemography.Name = "cobdemography";
            this.cobdemography.Size = new System.Drawing.Size(283, 21);
            this.cobdemography.TabIndex = 4;
            this.cobdemography.ValueMember = "Id";
            this.cobdemography.SelectedIndexChanged += new System.EventHandler(this.cobdemography_SelectedIndexChanged);
            // 
            // btnviewreport
            // 
            this.btnviewreport.Location = new System.Drawing.Point(14, 124);
            this.btnviewreport.Name = "btnviewreport";
            this.btnviewreport.Size = new System.Drawing.Size(75, 23);
            this.btnviewreport.TabIndex = 6;
            this.btnviewreport.Text = "View Report";
            this.btnviewreport.UseVisualStyleBackColor = true;
            this.btnviewreport.Click += new System.EventHandler(this.btnviewreport_Click);
            // 
            // comMethodologey
            // 
            this.comMethodologey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMethodologey.FormattingEnabled = true;
            this.comMethodologey.Location = new System.Drawing.Point(111, 12);
            this.comMethodologey.Name = "comMethodologey";
            this.comMethodologey.Size = new System.Drawing.Size(163, 21);
            this.comMethodologey.TabIndex = 8;
            this.comMethodologey.SelectedIndexChanged += new System.EventHandler(this.comMethodologey_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Methodology";
            // 
            // cobserviceorconsumption
            // 
            this.cobserviceorconsumption.DisplayMember = "ForecastNo";
            this.cobserviceorconsumption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobserviceorconsumption.FormattingEnabled = true;
            this.cobserviceorconsumption.Location = new System.Drawing.Point(111, 39);
            this.cobserviceorconsumption.Name = "cobserviceorconsumption";
            this.cobserviceorconsumption.Size = new System.Drawing.Size(283, 21);
            this.cobserviceorconsumption.TabIndex = 9;
            this.cobserviceorconsumption.ValueMember = "Id";
            this.cobserviceorconsumption.SelectedIndexChanged += new System.EventHandler(this.cobserviceorconsumption_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product Type";
            this.label2.Visible = false;
            // 
            // lblSiteCat
            // 
            this.lblSiteCat.AutoSize = true;
            this.lblSiteCat.Location = new System.Drawing.Point(11, 98);
            this.lblSiteCat.Name = "lblSiteCat";
            this.lblSiteCat.Size = new System.Drawing.Size(72, 13);
            this.lblSiteCat.TabIndex = 2;
            this.lblSiteCat.Text = "Site/Category";
            this.lblSiteCat.Visible = false;
            // 
            // cobType
            // 
            this.cobType.DisplayMember = "TypeName";
            this.cobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobType.FormattingEnabled = true;
            this.cobType.Location = new System.Drawing.Point(111, 67);
            this.cobType.Name = "cobType";
            this.cobType.Size = new System.Drawing.Size(283, 21);
            this.cobType.TabIndex = 9;
            this.cobType.ValueMember = "Id";
            this.cobType.Visible = false;
            // 
            // cobSite
            // 
            this.cobSite.DisplayMember = "SiteName";
            this.cobSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobSite.FormattingEnabled = true;
            this.cobSite.Location = new System.Drawing.Point(111, 98);
            this.cobSite.Name = "cobSite";
            this.cobSite.Size = new System.Drawing.Size(283, 21);
            this.cobSite.TabIndex = 9;
            this.cobSite.ValueMember = "Id";
            // 
            // cobCat
            // 
            this.cobCat.DisplayMember = "CategoryName";
            this.cobCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCat.FormattingEnabled = true;
            this.cobCat.Location = new System.Drawing.Point(400, 98);
            this.cobCat.Name = "cobCat";
            this.cobCat.Size = new System.Drawing.Size(283, 21);
            this.cobCat.TabIndex = 10;
            this.cobCat.ValueMember = "Id";
            // 
            // MorbidityCostSReportParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cobCat);
            this.Controls.Add(this.cobSite);
            this.Controls.Add(this.cobType);
            this.Controls.Add(this.cobserviceorconsumption);
            this.Controls.Add(this.comMethodologey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnviewreport);
            this.Controls.Add(this.cobdemography);
            this.Controls.Add(this.lblSiteCat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "MorbidityCostSReportParam";
            this.Size = new System.Drawing.Size(881, 162);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cobdemography;
        private System.Windows.Forms.Button btnviewreport;
        private System.Windows.Forms.ComboBox comMethodologey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cobserviceorconsumption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSiteCat;
        private System.Windows.Forms.ComboBox cobType;
        private System.Windows.Forms.ComboBox cobSite;
        private System.Windows.Forms.ComboBox cobCat;
    }
}
