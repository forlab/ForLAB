
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

namespace LQT.GUI.MorbidityUserCtr
{
    partial class TestingInformation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstSites = new LQT.GUI.LQTListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDtfwr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.butApplyall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPtp = new System.Windows.Forms.TextBox();
            this.txtPddwf = new System.Windows.Forms.TextBox();
            this.txtAtp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddwf = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lstSites, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lstSites
            // 
            this.lstSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lstSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSites.FullRowSelect = true;
            this.lstSites.GridLines = true;
            this.lstSites.Location = new System.Drawing.Point(3, 170);
            this.lstSites.Name = "lstSites";
            this.lstSites.Size = new System.Drawing.Size(594, 277);
            this.lstSites.TabIndex = 1;
            this.lstSites.UseCompatibleStateImageBehavior = false;
            this.lstSites.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Category/Region";
            this.columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "ART Sites";
            this.columnHeader12.Width = 134;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "A.T.P";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "P.T.P";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "A.D.D.W.F";
            this.columnHeader8.Width = 70;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "P.D.D.W.F";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "D.T.F.W.R ";
            this.columnHeader10.Width = 70;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 161);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDtfwr);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.butApplyall);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtPtp);
            this.groupBox3.Controls.Add(this.txtPddwf);
            this.groupBox3.Controls.Add(this.txtAtp);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtAddwf);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(594, 165);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Default Values";
            // 
            // txtDtfwr
            // 
            this.txtDtfwr.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtDtfwr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDtfwr.Location = new System.Drawing.Point(296, 133);
            this.txtDtfwr.Name = "txtDtfwr";
            this.txtDtfwr.Size = new System.Drawing.Size(40, 20);
            this.txtDtfwr.TabIndex = 18;
            this.txtDtfwr.Tag = "4";
            this.txtDtfwr.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "% of HIV+ Diagnoses That Follow Up Which Receive CD4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(253, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "% of HIV+ Adult diagnoses to depart w/out follow-up";
            // 
            // butApplyall
            // 
            this.butApplyall.Location = new System.Drawing.Point(345, 119);
            this.butApplyall.Name = "butApplyall";
            this.butApplyall.Size = new System.Drawing.Size(174, 34);
            this.butApplyall.TabIndex = 1;
            this.butApplyall.Text = "Apply Default Values to All Sites";
            this.butApplyall.UseVisualStyleBackColor = true;
            this.butApplyall.Click += new System.EventHandler(this.butApplyall_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 82);
            this.label1.TabIndex = 2;
            this.label1.Text = "OPTIONAL: \r\nEnter national level figures and click on the button below to load th" +
                "em as a default value for all sites.  You may still edit individual sites.\r\n";
            // 
            // txtPtp
            // 
            this.txtPtp.BackColor = System.Drawing.Color.BurlyWood;
            this.txtPtp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPtp.Location = new System.Drawing.Point(296, 50);
            this.txtPtp.Name = "txtPtp";
            this.txtPtp.Size = new System.Drawing.Size(40, 20);
            this.txtPtp.TabIndex = 12;
            this.txtPtp.Tag = "1";
            this.txtPtp.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // txtPddwf
            // 
            this.txtPddwf.BackColor = System.Drawing.Color.Tan;
            this.txtPddwf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPddwf.Location = new System.Drawing.Point(296, 106);
            this.txtPddwf.Name = "txtPddwf";
            this.txtPddwf.Size = new System.Drawing.Size(40, 20);
            this.txtPddwf.TabIndex = 16;
            this.txtPddwf.Tag = "3";
            this.txtPddwf.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // txtAtp
            // 
            this.txtAtp.BackColor = System.Drawing.Color.PeachPuff;
            this.txtAtp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAtp.Location = new System.Drawing.Point(296, 24);
            this.txtAtp.Name = "txtAtp";
            this.txtAtp.Size = new System.Drawing.Size(40, 20);
            this.txtAtp.TabIndex = 10;
            this.txtAtp.Tag = "0";
            this.txtAtp.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(270, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "% of HIV+ Pediatric diagnoses to depart w/out follow-up";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "% Adult Testing Population HIV Positive";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "% Pediatric Testing Population HIV Positive";
            // 
            // txtAddwf
            // 
            this.txtAddwf.BackColor = System.Drawing.Color.LightSalmon;
            this.txtAddwf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddwf.Location = new System.Drawing.Point(296, 76);
            this.txtAddwf.Name = "txtAddwf";
            this.txtAddwf.Size = new System.Drawing.Size(40, 20);
            this.txtAddwf.TabIndex = 14;
            this.txtAddwf.Tag = "2";
            this.txtAddwf.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // TestingInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestingInformation";
            this.Size = new System.Drawing.Size(600, 450);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private LQTListView lstSites;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butApplyall;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPtp;
        private System.Windows.Forms.TextBox txtPddwf;
        private System.Windows.Forms.TextBox txtAtp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddwf;
        private System.Windows.Forms.TextBox txtDtfwr;
        private System.Windows.Forms.Label label2;
    }
}
