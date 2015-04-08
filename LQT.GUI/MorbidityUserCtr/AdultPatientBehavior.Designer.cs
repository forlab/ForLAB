
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
    partial class AdultPatientBehavior
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
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPPAamt = new System.Windows.Forms.TextBox();
            this.txtPPAabdnp = new System.Windows.Forms.TextBox();
            this.txtPPAapa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPPAabdep = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPTabdep = new System.Windows.Forms.TextBox();
            this.txtPTapa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPTabdnp = new System.Windows.Forms.TextBox();
            this.butApplyall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lstSites
            // 
            this.lstSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lstSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSites.FullRowSelect = true;
            this.lstSites.GridLines = true;
            this.lstSites.Location = new System.Drawing.Point(3, 243);
            this.lstSites.Name = "lstSites";
            this.lstSites.Size = new System.Drawing.Size(594, 204);
            this.lstSites.TabIndex = 1;
            this.lstSites.UseCompatibleStateImageBehavior = false;
            this.lstSites.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Category/Region";
            this.columnHeader15.Width = 120;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "ART Sites";
            this.columnHeader16.Width = 143;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "AT- A.P.A";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "AT- A.B.D/E.P/Yr";
            this.columnHeader7.Width = 88;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "AT-A.B.D/N.P/Yr";
            this.columnHeader8.Width = 90;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "APA- A.P.A";
            this.columnHeader9.Width = 73;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "APA- A.M.T";
            this.columnHeader10.Width = 65;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "APA- A.B.D/E.P/Yr";
            this.columnHeader11.Width = 85;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "APA- A.B.D/N.P/Yr";
            this.columnHeader12.Width = 88;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 234);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.butApplyall);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 235);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Default Values";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPPAamt);
            this.groupBox3.Controls.Add(this.txtPPAabdnp);
            this.groupBox3.Controls.Add(this.txtPPAapa);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtPPAabdep);
            this.groupBox3.Location = new System.Drawing.Point(302, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 127);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Adults In Pre-ART";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Avg # Blood Draws/Existing Patient/Yr";
            // 
            // txtPPAamt
            // 
            this.txtPPAamt.BackColor = System.Drawing.Color.BurlyWood;
            this.txtPPAamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPPAamt.Location = new System.Drawing.Point(203, 45);
            this.txtPPAamt.Name = "txtPPAamt";
            this.txtPPAamt.Size = new System.Drawing.Size(40, 20);
            this.txtPPAamt.TabIndex = 2;
            this.txtPPAamt.Tag = "4";
            this.txtPPAamt.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // txtPPAabdnp
            // 
            this.txtPPAabdnp.BackColor = System.Drawing.Color.Tan;
            this.txtPPAabdnp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPPAabdnp.Location = new System.Drawing.Point(203, 97);
            this.txtPPAabdnp.Name = "txtPPAabdnp";
            this.txtPPAabdnp.Size = new System.Drawing.Size(40, 20);
            this.txtPPAabdnp.TabIndex = 4;
            this.txtPPAabdnp.Tag = "6";
            this.txtPPAabdnp.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // txtPPAapa
            // 
            this.txtPPAapa.BackColor = System.Drawing.Color.PeachPuff;
            this.txtPPAapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPPAapa.Location = new System.Drawing.Point(203, 19);
            this.txtPPAapa.Name = "txtPPAapa";
            this.txtPPAapa.Size = new System.Drawing.Size(40, 20);
            this.txtPPAapa.TabIndex = 1;
            this.txtPPAapa.Tag = "3";
            this.txtPPAapa.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Avg # Blood Draws/New Patient/Yr";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Annual % Patient Attrition";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Annual % Migration into treatment";
            // 
            // txtPPAabdep
            // 
            this.txtPPAabdep.BackColor = System.Drawing.Color.LightSalmon;
            this.txtPPAabdep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPPAabdep.Location = new System.Drawing.Point(203, 71);
            this.txtPPAabdep.Name = "txtPPAabdep";
            this.txtPPAabdep.Size = new System.Drawing.Size(40, 20);
            this.txtPPAabdep.TabIndex = 3;
            this.txtPPAabdep.Tag = "5";
            this.txtPPAabdep.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPTabdep);
            this.groupBox2.Controls.Add(this.txtPTapa);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPTabdnp);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adults In Treatment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Avg # Blood Draws/Existing Patient/Yr";
            // 
            // txtPTabdep
            // 
            this.txtPTabdep.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.txtPTabdep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPTabdep.Location = new System.Drawing.Point(203, 45);
            this.txtPTabdep.Name = "txtPTabdep";
            this.txtPTabdep.Size = new System.Drawing.Size(40, 20);
            this.txtPTabdep.TabIndex = 1;
            this.txtPTabdep.Tag = "1";
            this.txtPTabdep.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // txtPTapa
            // 
            this.txtPTapa.BackColor = System.Drawing.Color.SpringGreen;
            this.txtPTapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPTapa.Location = new System.Drawing.Point(203, 19);
            this.txtPTapa.Name = "txtPTapa";
            this.txtPTapa.Size = new System.Drawing.Size(40, 20);
            this.txtPTapa.TabIndex = 0;
            this.txtPTapa.Tag = "0";
            this.txtPTapa.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Avg # Blood Draws/New Patient/Yr";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Annual % Patient Attrition";
            // 
            // txtPTabdnp
            // 
            this.txtPTabdnp.BackColor = System.Drawing.Color.MediumAquamarine;
            this.txtPTabdnp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPTabdnp.Location = new System.Drawing.Point(203, 71);
            this.txtPTabdnp.Name = "txtPTabdnp";
            this.txtPTabdnp.Size = new System.Drawing.Size(40, 20);
            this.txtPTabdnp.TabIndex = 2;
            this.txtPTabdnp.Tag = "2";
            this.txtPTabdnp.Leave += new System.EventHandler(this.TEtextBox_Leave);
            // 
            // butApplyall
            // 
            this.butApplyall.Location = new System.Drawing.Point(6, 198);
            this.butApplyall.Name = "butApplyall";
            this.butApplyall.Size = new System.Drawing.Size(174, 34);
            this.butApplyall.TabIndex = 3;
            this.butApplyall.Text = "Apply Default Values to All Sites";
            this.butApplyall.UseVisualStyleBackColor = true;
            this.butApplyall.Click += new System.EventHandler(this.butApplyall_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(570, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "OPTIONAL: \r\nEnter national level figures and click on the button below to load th" +
                "em as a default value for all sites.  You may still edit individual sites.\r\n";
            // 
            // AdultPatientBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AdultPatientBehavior";
            this.Size = new System.Drawing.Size(600, 450);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private LQTListView lstSites;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPPAamt;
        private System.Windows.Forms.TextBox txtPPAabdnp;
        private System.Windows.Forms.TextBox txtPPAapa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPPAabdep;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPTabdep;
        private System.Windows.Forms.TextBox txtPTapa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPTabdnp;
        private System.Windows.Forms.Button butApplyall;
        private System.Windows.Forms.Label label2;
    }
}
