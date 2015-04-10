
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

namespace LQT.GUI.Testing
{
    partial class TestFrom
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
            this.comInstrument = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvProductUsage = new LQT.GUI.LQTListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.butRemove = new System.Windows.Forms.Button();
            this.comProduct = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTestname = new System.Windows.Forms.TextBox();
            this.comGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comTestarea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lqtToolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 35);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(643, 29);
            this.lqtToolStrip1.TabIndex = 8;
            // 
            // comInstrument
            // 
            this.comInstrument.DisplayMember = "InstrumentName";
            this.comInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comInstrument.FormattingEnabled = true;
            this.comInstrument.Location = new System.Drawing.Point(38, 19);
            this.comInstrument.Name = "comInstrument";
            this.comInstrument.Size = new System.Drawing.Size(217, 21);
            this.comInstrument.TabIndex = 3;
            this.comInstrument.ValueMember = "Id";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvProductUsage);
            this.groupBox1.Controls.Add(this.comInstrument);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butRemove);
            this.groupBox1.Controls.Add(this.comProduct);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(10, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 317);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Product Usage Rate";
            // 
            // lsvProductUsage
            // 
            this.lsvProductUsage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvProductUsage.FullRowSelect = true;
            this.lsvProductUsage.GridLines = true;
            this.lsvProductUsage.Location = new System.Drawing.Point(7, 50);
            this.lsvProductUsage.Name = "lsvProductUsage";
            this.lsvProductUsage.Size = new System.Drawing.Size(614, 249);
            this.lsvProductUsage.TabIndex = 311;
            this.lsvProductUsage.TabStop = false;
            this.lsvProductUsage.UseCompatibleStateImageBehavior = false;
            this.lsvProductUsage.View = System.Windows.Forms.View.Details;
            this.lsvProductUsage.SelectedIndexChanged += new System.EventHandler(this.lsvProductUsage_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product";
            this.columnHeader1.Width = 520;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Usage Rate";
            this.columnHeader2.Width = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Ins.";
            // 
            // butAdd
            // 
            this.butAdd.Enabled = false;
            this.butAdd.Location = new System.Drawing.Point(505, 18);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(50, 22);
            this.butAdd.TabIndex = 5;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butRemove
            // 
            this.butRemove.Enabled = false;
            this.butRemove.Location = new System.Drawing.Point(561, 17);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(60, 22);
            this.butRemove.TabIndex = 6;
            this.butRemove.Text = "Remove";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // comProduct
            // 
            this.comProduct.DisplayMember = "ProductName";
            this.comProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProduct.FormattingEnabled = true;
            this.comProduct.Location = new System.Drawing.Point(297, 19);
            this.comProduct.Name = "comProduct";
            this.comProduct.Size = new System.Drawing.Size(202, 21);
            this.comProduct.TabIndex = 4;
            this.comProduct.ValueMember = "Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(261, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Pro.";
            // 
            // txtTestname
            // 
            this.txtTestname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestname.Location = new System.Drawing.Point(101, 53);
            this.txtTestname.MaximumSize = new System.Drawing.Size(311, 25);
            this.txtTestname.MinimumSize = new System.Drawing.Size(311, 25);
            this.txtTestname.Name = "txtTestname";
            this.txtTestname.Size = new System.Drawing.Size(311, 20);
            this.txtTestname.TabIndex = 0;
            // 
            // comGroup
            // 
            this.comGroup.DisplayMember = "GroupName";
            this.comGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGroup.Location = new System.Drawing.Point(101, 114);
            this.comGroup.Name = "comGroup";
            this.comGroup.Size = new System.Drawing.Size(311, 21);
            this.comGroup.TabIndex = 2;
            this.comGroup.Tag = "";
            this.comGroup.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Testing Group:";
            // 
            // comTestarea
            // 
            this.comTestarea.DisplayMember = "AreaName";
            this.comTestarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTestarea.FormattingEnabled = true;
            this.comTestarea.Location = new System.Drawing.Point(101, 83);
            this.comTestarea.Name = "comTestarea";
            this.comTestarea.Size = new System.Drawing.Size(311, 21);
            this.comTestarea.TabIndex = 1;
            this.comTestarea.Tag = "";
            this.comTestarea.ValueMember = "Id";
            this.comTestarea.SelectedIndexChanged += new System.EventHandler(this.comTestarea_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Test Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Testing Area:";
            // 
            // TestFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTestname);
            this.Controls.Add(this.comGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comTestarea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestFrom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestFrom_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestFrom_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.ComboBox comInstrument;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butRemove;
        private System.Windows.Forms.ComboBox comProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTestname;
        private System.Windows.Forms.ComboBox comGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comTestarea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private LQTListView lsvProductUsage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        // private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
