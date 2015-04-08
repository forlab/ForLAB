
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
    partial class CheckupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckupForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.trueFalseImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.butCalculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRate = new System.Windows.Forms.TabPage();
            this.scPBehavior = new System.Windows.Forms.SplitContainer();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butRecheck = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMigration = new System.Windows.Forms.TextBox();
            this.txtAttrition = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabInstrument = new System.Windows.Forms.TabPage();
            this.tabSupply = new System.Windows.Forms.TabPage();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRate.SuspendLayout();
            this.scPBehavior.Panel1.SuspendLayout();
            this.scPBehavior.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "5-site.png");
            this.imageList1.Images.SetKeyName(1, "3-instrument.png");
            this.imageList1.Images.SetKeyName(2, "2-productprofile.png");
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.butCalculate);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(600, 450);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 4;
            // 
            // butCalculate
            // 
            this.butCalculate.Location = new System.Drawing.Point(6, 5);
            this.butCalculate.Name = "butCalculate";
            this.butCalculate.Size = new System.Drawing.Size(99, 39);
            this.butCalculate.TabIndex = 6;
            this.butCalculate.Text = "Calculate!";
            this.butCalculate.UseVisualStyleBackColor = true;
            this.butCalculate.Click += new System.EventHandler(this.butCalculate_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(587, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "NOTE: Once you start the calculating process, the model may take a longer time to" +
                " run, depending on the number of sites included. ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(111, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 39);
            this.label1.TabIndex = 7;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRate);
            this.tabControl1.Controls.Add(this.tabInstrument);
            this.tabControl1.Controls.Add(this.tabSupply);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 376);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabRate
            // 
            this.tabRate.Controls.Add(this.scPBehavior);
            this.tabRate.ImageIndex = 0;
            this.tabRate.Location = new System.Drawing.Point(4, 29);
            this.tabRate.Margin = new System.Windows.Forms.Padding(0);
            this.tabRate.Name = "tabRate";
            this.tabRate.Size = new System.Drawing.Size(592, 343);
            this.tabRate.TabIndex = 0;
            this.tabRate.Text = "Patient Behavior";
            this.tabRate.UseVisualStyleBackColor = true;
            // 
            // scPBehavior
            // 
            this.scPBehavior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPBehavior.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scPBehavior.IsSplitterFixed = true;
            this.scPBehavior.Location = new System.Drawing.Point(0, 0);
            this.scPBehavior.Margin = new System.Windows.Forms.Padding(0);
            this.scPBehavior.Name = "scPBehavior";
            this.scPBehavior.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scPBehavior.Panel1
            // 
            this.scPBehavior.Panel1.Controls.Add(this.label18);
            this.scPBehavior.Panel1.Controls.Add(this.label19);
            this.scPBehavior.Panel1.Controls.Add(this.label17);
            this.scPBehavior.Panel1.Controls.Add(this.label5);
            this.scPBehavior.Panel1.Controls.Add(this.label14);
            this.scPBehavior.Panel1.Controls.Add(this.label15);
            this.scPBehavior.Panel1.Controls.Add(this.label16);
            this.scPBehavior.Panel1.Controls.Add(this.label13);
            this.scPBehavior.Panel1.Controls.Add(this.label10);
            this.scPBehavior.Panel1.Controls.Add(this.label9);
            this.scPBehavior.Panel1.Controls.Add(this.label6);
            this.scPBehavior.Panel1.Controls.Add(this.groupBox2);
            this.scPBehavior.Panel1.Controls.Add(this.groupBox1);
            this.scPBehavior.Size = new System.Drawing.Size(592, 343);
            this.scPBehavior.SplitterDistance = 120;
            this.scPBehavior.SplitterWidth = 1;
            this.scPBehavior.TabIndex = 23;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.LightGray;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(376, 80);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 40);
            this.label18.TabIndex = 34;
            this.label18.Text = "%Ped in Pre-ART";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.LightGray;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(325, 80);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 40);
            this.label19.TabIndex = 33;
            this.label19.Text = "%Ped in Treatment";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.LightGray;
            this.label17.Location = new System.Drawing.Point(2, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(150, 39);
            this.label17.TabIndex = 32;
            this.label17.Text = "Site Name";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Location = new System.Drawing.Point(437, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Pediatric";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.LightGray;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(539, 93);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 25);
            this.label14.TabIndex = 30;
            this.label14.Text = "Migration";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LightGray;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(488, 93);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 25);
            this.label15.TabIndex = 29;
            this.label15.Text = "Pre ART attrition";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.LightGray;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(437, 93);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 25);
            this.label16.TabIndex = 28;
            this.label16.Text = "Treatment attrition";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LightGray;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(265, 93);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 25);
            this.label13.TabIndex = 27;
            this.label13.Text = "Migration";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGray;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(214, 93);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "Pre ART attrition";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(163, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "Treatment attrition";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(163, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Adult";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butRecheck);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtMigration);
            this.groupBox2.Controls.Add(this.txtAttrition);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(14, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 65);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Migration and Attrition checkup value";
            // 
            // butRecheck
            // 
            this.butRecheck.Location = new System.Drawing.Point(195, 22);
            this.butRecheck.Name = "butRecheck";
            this.butRecheck.Size = new System.Drawing.Size(70, 34);
            this.butRecheck.TabIndex = 21;
            this.butRecheck.Text = "Recheck";
            this.butRecheck.UseVisualStyleBackColor = true;
            this.butRecheck.Click += new System.EventHandler(this.butRecheck_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "%Max Attrition rate >";
            // 
            // txtMigration
            // 
            this.txtMigration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMigration.Location = new System.Drawing.Point(128, 20);
            this.txtMigration.Name = "txtMigration";
            this.txtMigration.Size = new System.Drawing.Size(61, 20);
            this.txtMigration.TabIndex = 17;
            this.txtMigration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // txtAttrition
            // 
            this.txtAttrition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAttrition.Location = new System.Drawing.Point(128, 41);
            this.txtAttrition.Name = "txtAttrition";
            this.txtAttrition.Size = new System.Drawing.Size(61, 20);
            this.txtAttrition.TabIndex = 18;
            this.txtAttrition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyDigt_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "%Min Migration Rate < ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(291, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 65);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cell with error color code";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Attrition rate greater than maximum value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Migration rate less than a minimam value";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(6, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 13;
            // 
            // tabInstrument
            // 
            this.tabInstrument.ImageIndex = 1;
            this.tabInstrument.Location = new System.Drawing.Point(4, 29);
            this.tabInstrument.Margin = new System.Windows.Forms.Padding(0);
            this.tabInstrument.Name = "tabInstrument";
            this.tabInstrument.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstrument.Size = new System.Drawing.Size(592, 343);
            this.tabInstrument.TabIndex = 1;
            this.tabInstrument.Text = "Service and Platform";
            this.tabInstrument.UseVisualStyleBackColor = true;
            // 
            // tabSupply
            // 
            this.tabSupply.ImageIndex = 2;
            this.tabSupply.Location = new System.Drawing.Point(4, 29);
            this.tabSupply.Name = "tabSupply";
            this.tabSupply.Padding = new System.Windows.Forms.Padding(3);
            this.tabSupply.Size = new System.Drawing.Size(592, 343);
            this.tabSupply.TabIndex = 2;
            this.tabSupply.Text = "Supply List";
            this.tabSupply.UseVisualStyleBackColor = true;
            // 
            // CheckupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CheckupForm";
            this.Size = new System.Drawing.Size(600, 450);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabRate.ResumeLayout(false);
            this.scPBehavior.Panel1.ResumeLayout(false);
            this.scPBehavior.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList trueFalseImageList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butRecheck;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAttrition;
        private System.Windows.Forms.TextBox txtMigration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butCalculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRate;
        private System.Windows.Forms.TabPage tabInstrument;
        private System.Windows.Forms.SplitContainer scPBehavior;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabSupply;
    }
}
