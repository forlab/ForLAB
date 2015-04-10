
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
    partial class InvAssumption
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAssumption));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSecurityStock = new System.Windows.Forms.TextBox();
            this.txtScreening = new System.Windows.Forms.TextBox();
            this.txtConfirmatory = new System.Windows.Forms.TextBox();
            this.txtCd4 = new System.Windows.Forms.TextBox();
            this.txtTibreaker = new System.Windows.Forms.TextBox();
            this.txtChemistry = new System.Windows.Forms.TextBox();
            this.txtHematology = new System.Windows.Forms.TextBox();
            this.txtViralload = new System.Windows.Forms.TextBox();
            this.txtOthertest = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.trueFalseImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Months of Security Stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rapid Test Screening %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Rapid Test Confirmatory %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rapid Test Tiebreaker %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CD4 %";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chemistry %";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(221, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Hematology %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Viral Load %";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(222, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Other Tests %";
            // 
            // txtSecurityStock
            // 
            this.txtSecurityStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecurityStock.Location = new System.Drawing.Point(151, 8);
            this.txtSecurityStock.Name = "txtSecurityStock";
            this.txtSecurityStock.Size = new System.Drawing.Size(100, 20);
            this.txtSecurityStock.TabIndex = 1;
            this.txtSecurityStock.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtSecurityStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtScreening
            // 
            this.txtScreening.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScreening.Location = new System.Drawing.Point(140, 27);
            this.txtScreening.Name = "txtScreening";
            this.txtScreening.Size = new System.Drawing.Size(40, 20);
            this.txtScreening.TabIndex = 1;
            this.txtScreening.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtScreening.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtConfirmatory
            // 
            this.txtConfirmatory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmatory.Location = new System.Drawing.Point(140, 53);
            this.txtConfirmatory.Name = "txtConfirmatory";
            this.txtConfirmatory.Size = new System.Drawing.Size(40, 20);
            this.txtConfirmatory.TabIndex = 2;
            this.txtConfirmatory.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtConfirmatory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtCd4
            // 
            this.txtCd4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCd4.Location = new System.Drawing.Point(140, 105);
            this.txtCd4.Name = "txtCd4";
            this.txtCd4.Size = new System.Drawing.Size(40, 20);
            this.txtCd4.TabIndex = 4;
            this.txtCd4.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtCd4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtTibreaker
            // 
            this.txtTibreaker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTibreaker.Location = new System.Drawing.Point(140, 79);
            this.txtTibreaker.Name = "txtTibreaker";
            this.txtTibreaker.Size = new System.Drawing.Size(40, 20);
            this.txtTibreaker.TabIndex = 3;
            this.txtTibreaker.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtTibreaker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtChemistry
            // 
            this.txtChemistry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChemistry.Location = new System.Drawing.Point(298, 27);
            this.txtChemistry.Name = "txtChemistry";
            this.txtChemistry.Size = new System.Drawing.Size(40, 20);
            this.txtChemistry.TabIndex = 5;
            this.txtChemistry.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtChemistry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtHematology
            // 
            this.txtHematology.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHematology.Location = new System.Drawing.Point(298, 53);
            this.txtHematology.Name = "txtHematology";
            this.txtHematology.Size = new System.Drawing.Size(40, 20);
            this.txtHematology.TabIndex = 6;
            this.txtHematology.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtHematology.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtViralload
            // 
            this.txtViralload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtViralload.Location = new System.Drawing.Point(298, 79);
            this.txtViralload.Name = "txtViralload";
            this.txtViralload.Size = new System.Drawing.Size(40, 20);
            this.txtViralload.TabIndex = 7;
            this.txtViralload.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtViralload.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtOthertest
            // 
            this.txtOthertest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOthertest.Location = new System.Drawing.Point(298, 105);
            this.txtOthertest.Name = "txtOthertest";
            this.txtOthertest.Size = new System.Drawing.Size(40, 20);
            this.txtOthertest.TabIndex = 8;
            this.txtOthertest.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtOthertest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOthertest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtViralload);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHematology);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtChemistry);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTibreaker);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCd4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtConfirmatory);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtScreening);
            this.groupBox1.Location = new System.Drawing.Point(14, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 146);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reagents lost through wastage/leakage etc";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "5-site.png");
            this.imageList1.Images.SetKeyName(1, "3-instrument.png");
            this.imageList1.Images.SetKeyName(2, "5-laboratory.png");
            // 
            // trueFalseImageList
            // 
            this.trueFalseImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("trueFalseImageList.ImageStream")));
            this.trueFalseImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.trueFalseImageList.Images.SetKeyName(0, "true.gif");
            this.trueFalseImageList.Images.SetKeyName(1, "false.gif");
            this.trueFalseImageList.Images.SetKeyName(2, "down.png");
            this.trueFalseImageList.Images.SetKeyName(3, "up.png");
            this.trueFalseImageList.Images.SetKeyName(4, "checked.png");
            this.trueFalseImageList.Images.SetKeyName(5, "unchecked.png");
            // 
            // InvAssumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSecurityStock);
            this.Controls.Add(this.groupBox1);
            this.Name = "InvAssumption";
            this.Size = new System.Drawing.Size(512, 276);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSecurityStock;
        private System.Windows.Forms.TextBox txtScreening;
        private System.Windows.Forms.TextBox txtConfirmatory;
        private System.Windows.Forms.TextBox txtCd4;
        private System.Windows.Forms.TextBox txtTibreaker;
        private System.Windows.Forms.TextBox txtChemistry;
        private System.Windows.Forms.TextBox txtHematology;
        private System.Windows.Forms.TextBox txtViralload;
        private System.Windows.Forms.TextBox txtOthertest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList trueFalseImageList;
    }
}
