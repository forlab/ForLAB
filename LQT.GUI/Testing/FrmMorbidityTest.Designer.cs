
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

namespace LQT.GUI.Testing
{
    partial class FrmMorbidityTest
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.comInstrument = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTestname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTestType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbtRemoveReagent = new System.Windows.Forms.LinkLabel();
            this.lbtAddReagent = new System.Windows.Forms.LinkLabel();
            this.lqtToolStrip1 = new LQT.GUI.UserCtr.LqtToolStrip();
            this.panProduct = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 31);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(564, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // comInstrument
            // 
            this.comInstrument.DisplayMember = "InstrumentName";
            this.comInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comInstrument.FormattingEnabled = true;
            this.comInstrument.Location = new System.Drawing.Point(105, 94);
            this.comInstrument.Name = "comInstrument";
            this.comInstrument.Size = new System.Drawing.Size(311, 21);
            this.comInstrument.TabIndex = 3;
            this.comInstrument.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Platform:";
            // 
            // txtTestname
            // 
            this.txtTestname.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTestname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestname.Location = new System.Drawing.Point(105, 61);
            this.txtTestname.MaximumSize = new System.Drawing.Size(311, 25);
            this.txtTestname.MinimumSize = new System.Drawing.Size(311, 25);
            this.txtTestname.Name = "txtTestname";
            this.txtTestname.ReadOnly = true;
            this.txtTestname.Size = new System.Drawing.Size(311, 20);
            this.txtTestname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Test Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Test Type:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTestType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTestname);
            this.groupBox1.Controls.Add(this.comInstrument);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 133);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Info";
            // 
            // txtTestType
            // 
            this.txtTestType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTestType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestType.Location = new System.Drawing.Point(105, 28);
            this.txtTestType.MaximumSize = new System.Drawing.Size(311, 25);
            this.txtTestType.MinimumSize = new System.Drawing.Size(311, 25);
            this.txtTestType.Name = "txtTestType";
            this.txtTestType.ReadOnly = true;
            this.txtTestType.Size = new System.Drawing.Size(311, 20);
            this.txtTestType.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(540, 1);
            this.label3.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Selected Reagent According to Test";
            // 
            // lbtRemoveReagent
            // 
            this.lbtRemoveReagent.AutoSize = true;
            this.lbtRemoveReagent.Location = new System.Drawing.Point(90, 198);
            this.lbtRemoveReagent.Name = "lbtRemoveReagent";
            this.lbtRemoveReagent.Size = new System.Drawing.Size(91, 13);
            this.lbtRemoveReagent.TabIndex = 5;
            this.lbtRemoveReagent.TabStop = true;
            this.lbtRemoveReagent.Text = "Remove Reagent";
            this.lbtRemoveReagent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtRemoveReagent_LinkClicked);
            // 
            // lbtAddReagent
            // 
            this.lbtAddReagent.AutoSize = true;
            this.lbtAddReagent.Location = new System.Drawing.Point(11, 198);
            this.lbtAddReagent.Name = "lbtAddReagent";
            this.lbtAddReagent.Size = new System.Drawing.Size(73, 13);
            this.lbtAddReagent.TabIndex = 4;
            this.lbtAddReagent.TabStop = true;
            this.lbtAddReagent.Text = "Add  Reagent";
            this.lbtAddReagent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtAddReagent_LinkClicked);
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lqtToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(564, 31);
            this.lqtToolStrip1.TabIndex = 7;
            // 
            // panProduct
            // 
            this.panProduct.Location = new System.Drawing.Point(12, 214);
            this.panProduct.Name = "panProduct";
            this.panProduct.Size = new System.Drawing.Size(540, 250);
            this.panProduct.TabIndex = 6;
            // 
            // FrmMorbidityTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 476);
            this.Controls.Add(this.panProduct);
            this.Controls.Add(this.lbtRemoveReagent);
            this.Controls.Add(this.lbtAddReagent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lqtToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMorbidityTest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Morbidity Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMorbidityTest_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox comInstrument;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTestname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTestType;
        private System.Windows.Forms.LinkLabel lbtRemoveReagent;
        private System.Windows.Forms.LinkLabel lbtAddReagent;
        private System.Windows.Forms.Panel panProduct;
    }
}
