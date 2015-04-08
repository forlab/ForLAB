
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

namespace LQT.GUI.MorbidityUserCtr
{
    partial class TestingEfficiency
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstSites = new LQT.GUI.LQTListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butApplyall = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPediatric = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAte = new System.Windows.Forms.TextBox();
            this.txtPte = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 65);
            this.label1.TabIndex = 5;
            this.label1.Text = "OPTIONAL: \r\nEnter national level figures and click on the button below to load th" +
                "em as a default value for all sites.  You may still edit individual sites.\r\n";
            // 
            // lstSites
            // 
            this.lstSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSites.FullRowSelect = true;
            this.lstSites.GridLines = true;
            this.lstSites.Location = new System.Drawing.Point(3, 133);
            this.lstSites.Name = "lstSites";
            this.lstSites.Size = new System.Drawing.Size(594, 264);
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
            this.columnHeader12.Width = 139;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "A.T.E";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "P.T.E";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "% Pediatric";
            this.columnHeader8.Width = 70;
            // 
            // butApplyall
            // 
            this.butApplyall.Location = new System.Drawing.Point(222, 83);
            this.butApplyall.Name = "butApplyall";
            this.butApplyall.Size = new System.Drawing.Size(174, 34);
            this.butApplyall.TabIndex = 4;
            this.butApplyall.Text = "Apply Default Values to All Sites";
            this.butApplyall.UseVisualStyleBackColor = true;
            this.butApplyall.Click += new System.EventHandler(this.butApplyall_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 130);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.butApplyall);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPediatric);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAte);
            this.groupBox1.Controls.Add(this.txtPte);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 123);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Values";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pediatric Testing Efficiency:";
            // 
            // txtPediatric
            // 
            this.txtPediatric.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtPediatric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPediatric.Location = new System.Drawing.Point(173, 85);
            this.txtPediatric.Name = "txtPediatric";
            this.txtPediatric.Size = new System.Drawing.Size(40, 20);
            this.txtPediatric.TabIndex = 3;
            this.txtPediatric.Tag = "2";
            this.txtPediatric.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Adult Testing Efficiency:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "%Pediatric (Pre Existing Patients)";
            // 
            // txtAte
            // 
            this.txtAte.BackColor = System.Drawing.Color.SpringGreen;
            this.txtAte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAte.Location = new System.Drawing.Point(173, 23);
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(40, 20);
            this.txtAte.TabIndex = 1;
            this.txtAte.Tag = "0";
            this.txtAte.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // txtPte
            // 
            this.txtPte.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.txtPte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPte.Location = new System.Drawing.Point(173, 54);
            this.txtPte.Name = "txtPte";
            this.txtPte.Size = new System.Drawing.Size(40, 20);
            this.txtPte.TabIndex = 2;
            this.txtPte.Tag = "1";
            this.txtPte.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lstSites, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 400);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // TestingEfficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TestingEfficiency";
            this.Size = new System.Drawing.Size(600, 400);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LQTListView lstSites;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button butApplyall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPediatric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAte;
        private System.Windows.Forms.TextBox txtPte;
    }
}
