
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

namespace LQT.GUI.MorbidityProtocolSetting
{
    partial class FrmProtocol
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
            this.butDeletepanel = new System.Windows.Forms.Button();
            this.butEditpanel = new System.Windows.Forms.Button();
            this.butNewpanel = new System.Windows.Forms.Button();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txttestsrepeated = new System.Windows.Forms.TextBox();
            this.txtsymptomdirected = new System.Windows.Forms.TextBox();
            this.txtprotocolcategory = new System.Windows.Forms.TextBox();
            this.lblsystemdirected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPanels = new System.Windows.Forms.TabPage();
            this.lsvpanel = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCD4 = new System.Windows.Forms.TabPage();
            this.tabChem = new System.Windows.Forms.TabPage();
            this.tabOther = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPanels.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.069212F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.93079F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(769, 35);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(763, 29);
            this.lqtToolStrip1.TabIndex = 0;
            // 
            // butDeletepanel
            // 
            this.butDeletepanel.Enabled = false;
            this.butDeletepanel.Location = new System.Drawing.Point(581, 107);
            this.butDeletepanel.Name = "butDeletepanel";
            this.butDeletepanel.Size = new System.Drawing.Size(75, 33);
            this.butDeletepanel.TabIndex = 7;
            this.butDeletepanel.Text = "Delete";
            this.butDeletepanel.UseVisualStyleBackColor = true;
            this.butDeletepanel.Click += new System.EventHandler(this.butDeletepanel_Click);
            // 
            // butEditpanel
            // 
            this.butEditpanel.Enabled = false;
            this.butEditpanel.Location = new System.Drawing.Point(581, 68);
            this.butEditpanel.Name = "butEditpanel";
            this.butEditpanel.Size = new System.Drawing.Size(75, 33);
            this.butEditpanel.TabIndex = 6;
            this.butEditpanel.Text = "Edit...";
            this.butEditpanel.UseVisualStyleBackColor = true;
            this.butEditpanel.Click += new System.EventHandler(this.butEditpanel_Click);
            // 
            // butNewpanel
            // 
            this.butNewpanel.Location = new System.Drawing.Point(581, 29);
            this.butNewpanel.Name = "butNewpanel";
            this.butNewpanel.Size = new System.Drawing.Size(75, 33);
            this.butNewpanel.TabIndex = 5;
            this.butNewpanel.Text = "New...";
            this.butNewpanel.UseVisualStyleBackColor = true;
            this.butNewpanel.Click += new System.EventHandler(this.butNewpanel_Click);
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(118, 77);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(641, 50);
            this.txtdescription.TabIndex = 2;
            // 
            // txttestsrepeated
            // 
            this.txttestsrepeated.Location = new System.Drawing.Point(659, 50);
            this.txttestsrepeated.Name = "txttestsrepeated";
            this.txttestsrepeated.Size = new System.Drawing.Size(100, 20);
            this.txttestsrepeated.TabIndex = 1;
            this.txttestsrepeated.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttestsrepeated_KeyPress);
            // 
            // txtsymptomdirected
            // 
            this.txtsymptomdirected.Location = new System.Drawing.Point(658, 133);
            this.txtsymptomdirected.Name = "txtsymptomdirected";
            this.txtsymptomdirected.Size = new System.Drawing.Size(100, 20);
            this.txtsymptomdirected.TabIndex = 3;
            this.txtsymptomdirected.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttestsrepeated_KeyPress);
            // 
            // txtprotocolcategory
            // 
            this.txtprotocolcategory.BackColor = System.Drawing.SystemColors.Info;
            this.txtprotocolcategory.Location = new System.Drawing.Point(118, 50);
            this.txtprotocolcategory.MaxLength = 64;
            this.txtprotocolcategory.Name = "txtprotocolcategory";
            this.txtprotocolcategory.ReadOnly = true;
            this.txtprotocolcategory.Size = new System.Drawing.Size(159, 20);
            this.txtprotocolcategory.TabIndex = 0;
            // 
            // lblsystemdirected
            // 
            this.lblsystemdirected.AutoSize = true;
            this.lblsystemdirected.Location = new System.Drawing.Point(477, 136);
            this.lblsystemdirected.Name = "lblsystemdirected";
            this.lblsystemdirected.Size = new System.Drawing.Size(166, 13);
            this.lblsystemdirected.TabIndex = 30;
            this.lblsystemdirected.Text = "% Symptom-Directed Tests /Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Protocol Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "% of tests repeated :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Description:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPanels);
            this.tabControl1.Controls.Add(this.tabCD4);
            this.tabControl1.Controls.Add(this.tabChem);
            this.tabControl1.Controls.Add(this.tabOther);
            this.tabControl1.Location = new System.Drawing.Point(12, 166);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 210);
            this.tabControl1.TabIndex = 119;
            // 
            // tabPanels
            // 
            this.tabPanels.Controls.Add(this.lsvpanel);
            this.tabPanels.Controls.Add(this.butDeletepanel);
            this.tabPanels.Controls.Add(this.butNewpanel);
            this.tabPanels.Controls.Add(this.butEditpanel);
            this.tabPanels.Location = new System.Drawing.Point(4, 22);
            this.tabPanels.Name = "tabPanels";
            this.tabPanels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPanels.Size = new System.Drawing.Size(739, 184);
            this.tabPanels.TabIndex = 0;
            this.tabPanels.Text = "Panel";
            this.tabPanels.UseVisualStyleBackColor = true;
            // 
            // lsvpanel
            // 
            this.lsvpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvpanel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14});
            this.lsvpanel.FullRowSelect = true;
            this.lsvpanel.GridLines = true;
            this.lsvpanel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvpanel.Location = new System.Drawing.Point(6, 6);
            this.lsvpanel.MultiSelect = false;
            this.lsvpanel.Name = "lsvpanel";
            this.lsvpanel.Size = new System.Drawing.Size(569, 172);
            this.lsvpanel.TabIndex = 4;
            this.lsvpanel.UseCompatibleStateImageBehavior = false;
            this.lsvpanel.View = System.Windows.Forms.View.Details;
            this.lsvpanel.SelectedIndexChanged += new System.EventHandler(this.lsvpanel_SelectedIndexChanged);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Panel Name";
            this.columnHeader14.Width = 551;
            // 
            // tabCD4
            // 
            this.tabCD4.Location = new System.Drawing.Point(4, 22);
            this.tabCD4.Name = "tabCD4";
            this.tabCD4.Padding = new System.Windows.Forms.Padding(3);
            this.tabCD4.Size = new System.Drawing.Size(739, 184);
            this.tabCD4.TabIndex = 1;
            this.tabCD4.Text = "Patient protocol as number of blood samples drawn for CD4 tests in a given month " +
                "(after the initial CD4 test)";
            this.tabCD4.UseVisualStyleBackColor = true;
            // 
            // tabChem
            // 
            this.tabChem.Location = new System.Drawing.Point(4, 22);
            this.tabChem.Name = "tabChem";
            this.tabChem.Padding = new System.Windows.Forms.Padding(3);
            this.tabChem.Size = new System.Drawing.Size(739, 184);
            this.tabChem.TabIndex = 2;
            this.tabChem.Text = "% Total patients requiring 1 symptom-directed test/year";
            this.tabChem.UseVisualStyleBackColor = true;
            // 
            // tabOther
            // 
            this.tabOther.Location = new System.Drawing.Point(4, 22);
            this.tabOther.Name = "tabOther";
            this.tabOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabOther.Size = new System.Drawing.Size(739, 184);
            this.tabOther.TabIndex = 3;
            this.tabOther.Text = "% Total patients requiring 1 symptom-directed test/year";
            this.tabOther.UseVisualStyleBackColor = true;
            // 
            // FrmProtocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 394);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.txttestsrepeated);
            this.Controls.Add(this.txtsymptomdirected);
            this.Controls.Add(this.txtprotocolcategory);
            this.Controls.Add(this.lblsystemdirected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProtocol";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocol Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProtocol_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPanels.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.Button butDeletepanel;
        private System.Windows.Forms.Button butEditpanel;
        private System.Windows.Forms.Button butNewpanel;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txttestsrepeated;
        private System.Windows.Forms.TextBox txtsymptomdirected;
        private System.Windows.Forms.TextBox txtprotocolcategory;
        private System.Windows.Forms.Label lblsystemdirected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPanels;
        private System.Windows.Forms.TabPage tabCD4;
        private System.Windows.Forms.TabPage tabChem;
        private System.Windows.Forms.TabPage tabOther;
        private System.Windows.Forms.ListView lsvpanel;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        //private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
