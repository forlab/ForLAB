
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

namespace LQT.GUI.Asset
{
    partial class InstrumentForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lqtToolStrip1 = new LQT.GUI.UserCtr.LqtToolStrip();
            this.comTestarea = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxput = new System.Windows.Forms.TextBox();
            this.txtmonthly = new System.Windows.Forms.TextBox();
            this.txtweekly = new System.Windows.Forms.TextBox();
            this.txtquarterly = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtnooftestBctrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdailyctrltest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lqtToolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.90141F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.09859F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 42);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(373, 36);
            this.lqtToolStrip1.TabIndex = 0;
            // 
            // comTestarea
            // 
            this.comTestarea.DisplayMember = "AreaName";
            this.comTestarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTestarea.FormattingEnabled = true;
            this.comTestarea.Location = new System.Drawing.Point(109, 86);
            this.comTestarea.Name = "comTestarea";
            this.comTestarea.Size = new System.Drawing.Size(262, 21);
            this.comTestarea.TabIndex = 2;
            this.comTestarea.ValueMember = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Testing Area:";
            // 
            // txtMaxput
            // 
            this.txtMaxput.Location = new System.Drawing.Point(109, 117);
            this.txtMaxput.Name = "txtMaxput";
            this.txtMaxput.Size = new System.Drawing.Size(100, 20);
            this.txtMaxput.TabIndex = 3;
            this.txtMaxput.Text = "0";
            this.txtMaxput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxput_KeyPress);
            // 
            // txtmonthly
            // 
            this.txtmonthly.Location = new System.Drawing.Point(100, 198);
            this.txtmonthly.Name = "txtmonthly";
            this.txtmonthly.Size = new System.Drawing.Size(100, 20);
            this.txtmonthly.TabIndex = 6;
            this.txtmonthly.Text = "0";
            this.txtmonthly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxput_KeyPress);
            // 
            // txtweekly
            // 
            this.txtweekly.Location = new System.Drawing.Point(262, 172);
            this.txtweekly.Name = "txtweekly";
            this.txtweekly.Size = new System.Drawing.Size(109, 20);
            this.txtweekly.TabIndex = 5;
            this.txtweekly.Text = "0";
            this.txtweekly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxput_KeyPress);
            // 
            // txtquarterly
            // 
            this.txtquarterly.Location = new System.Drawing.Point(262, 198);
            this.txtquarterly.Name = "txtquarterly";
            this.txtquarterly.Size = new System.Drawing.Size(109, 20);
            this.txtquarterly.TabIndex = 7;
            this.txtquarterly.Text = "0";
            this.txtquarterly.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxput_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Quarterly:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Monthly:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Weekly:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Daily:";
            // 
            // txtnooftestBctrl
            // 
            this.txtnooftestBctrl.Location = new System.Drawing.Point(100, 224);
            this.txtnooftestBctrl.Name = "txtnooftestBctrl";
            this.txtnooftestBctrl.Size = new System.Drawing.Size(100, 20);
            this.txtnooftestBctrl.TabIndex = 8;
            this.txtnooftestBctrl.Text = "0";
            this.txtnooftestBctrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxput_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Per Test:";
            // 
            // txtdailyctrltest
            // 
            this.txtdailyctrltest.Location = new System.Drawing.Point(100, 172);
            this.txtdailyctrltest.Name = "txtdailyctrltest";
            this.txtdailyctrltest.Size = new System.Drawing.Size(100, 20);
            this.txtdailyctrltest.TabIndex = 4;
            this.txtdailyctrltest.Text = "0";
            this.txtdailyctrltest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxput_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Max Through Put:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(109, 56);
            this.txtName.MaxLength = 64;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(262, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Instrument Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(13, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Control Test Needed";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(102, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(270, 2);
            this.label10.TabIndex = 58;
            // 
            // InstrumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 253);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtmonthly);
            this.Controls.Add(this.comTestarea);
            this.Controls.Add(this.txtweekly);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtquarterly);
            this.Controls.Add(this.txtMaxput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnooftestBctrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtdailyctrltest);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstrumentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instrument";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.ComboBox comTestarea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxput;
        private System.Windows.Forms.TextBox txtmonthly;
        private System.Windows.Forms.TextBox txtweekly;
        private System.Windows.Forms.TextBox txtquarterly;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtnooftestBctrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdailyctrltest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        //private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
