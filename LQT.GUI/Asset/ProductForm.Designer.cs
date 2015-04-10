
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

namespace LQT.GUI.Asset
{
    partial class ProductForm
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
            this.txtminimumPacks = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvPrice = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.butEdit = new System.Windows.Forms.Button();
            this.butNewprice = new System.Windows.Forms.Button();
            this.txtBasicunit = new System.Windows.Forms.TextBox();
            this.txtSpecification = new System.Windows.Forms.TextBox();
            this.txtSerialno = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comSpecification = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lqtToolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 48);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(485, 44);
            this.lqtToolStrip1.TabIndex = 1;
            // 
            // txtminimumPacks
            // 
            this.txtminimumPacks.Location = new System.Drawing.Point(160, 211);
            this.txtminimumPacks.MaxLength = 16;
            this.txtminimumPacks.Name = "txtminimumPacks";
            this.txtminimumPacks.Size = new System.Drawing.Size(100, 20);
            this.txtminimumPacks.TabIndex = 6;
            this.txtminimumPacks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtminimumPacks_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Price";
            // 
            // comCategory
            // 
            this.comCategory.DisplayMember = "TypeName";
            this.comCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(160, 101);
            this.comCategory.Name = "comCategory";
            this.comCategory.Size = new System.Drawing.Size(256, 21);
            this.comCategory.TabIndex = 2;
            this.comCategory.ValueMember = "Id";
            this.comCategory.SelectedIndexChanged += new System.EventHandler(this.comCategory_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pack Size";
            this.columnHeader5.Width = 80;
            // 
            // lsvPrice
            // 
            this.lsvPrice.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPrice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2});
            this.lsvPrice.FullRowSelect = true;
            this.lsvPrice.GridLines = true;
            this.lsvPrice.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvPrice.Location = new System.Drawing.Point(162, 348);
            this.lsvPrice.MultiSelect = false;
            this.lsvPrice.Name = "lsvPrice";
            this.lsvPrice.Size = new System.Drawing.Size(256, 103);
            this.lsvPrice.TabIndex = 33;
            this.lsvPrice.UseCompatibleStateImageBehavior = false;
            this.lsvPrice.View = System.Windows.Forms.View.Details;
            this.lsvPrice.SelectedIndexChanged += new System.EventHandler(this.lsvPrice_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "As of Date";
            this.columnHeader2.Width = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Min. Packs / Site:";
            // 
            // butEdit
            // 
            this.butEdit.Enabled = false;
            this.butEdit.Location = new System.Drawing.Point(73, 407);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(50, 27);
            this.butEdit.TabIndex = 10;
            this.butEdit.Text = "Edit";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butNewprice
            // 
            this.butNewprice.Location = new System.Drawing.Point(73, 372);
            this.butNewprice.Name = "butNewprice";
            this.butNewprice.Size = new System.Drawing.Size(50, 27);
            this.butNewprice.TabIndex = 9;
            this.butNewprice.Text = "New";
            this.butNewprice.UseVisualStyleBackColor = true;
            this.butNewprice.Click += new System.EventHandler(this.butNewprice_Click);
            // 
            // txtBasicunit
            // 
            this.txtBasicunit.Location = new System.Drawing.Point(160, 184);
            this.txtBasicunit.MaxLength = 16;
            this.txtBasicunit.Name = "txtBasicunit";
            this.txtBasicunit.Size = new System.Drawing.Size(100, 20);
            this.txtBasicunit.TabIndex = 5;
            // 
            // txtSpecification
            // 
            this.txtSpecification.Location = new System.Drawing.Point(160, 156);
            this.txtSpecification.MaxLength = 256;
            this.txtSpecification.Name = "txtSpecification";
            this.txtSpecification.Size = new System.Drawing.Size(256, 20);
            this.txtSpecification.TabIndex = 4;
            // 
            // txtSerialno
            // 
            this.txtSerialno.Location = new System.Drawing.Point(160, 128);
            this.txtSerialno.MaxLength = 16;
            this.txtSerialno.Name = "txtSerialno";
            this.txtSerialno.Size = new System.Drawing.Size(100, 20);
            this.txtSerialno.TabIndex = 3;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(160, 238);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(256, 45);
            this.txtNote.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(160, 72);
            this.txtName.MaxLength = 64;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(256, 20);
            this.txtName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Note:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Basic Unit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Specification:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Serial No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Product Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Product Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Rapid Test Specification:";
            // 
            // comSpecification
            // 
            this.comSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSpecification.Enabled = false;
            this.comSpecification.FormattingEnabled = true;
            this.comSpecification.Location = new System.Drawing.Point(160, 289);
            this.comSpecification.Name = "comSpecification";
            this.comSpecification.Size = new System.Drawing.Size(256, 21);
            this.comSpecification.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(29, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Price";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(67, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(383, 2);
            this.label10.TabIndex = 40;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 459);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comSpecification);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtminimumPacks);
            this.Controls.Add(this.comCategory);
            this.Controls.Add(this.lsvPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butNewprice);
            this.Controls.Add(this.txtBasicunit);
            this.Controls.Add(this.txtSpecification);
            this.Controls.Add(this.txtSerialno);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.TextBox txtminimumPacks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lsvPrice;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butNewprice;
        private System.Windows.Forms.TextBox txtBasicunit;
        private System.Windows.Forms.TextBox txtSpecification;
        private System.Windows.Forms.TextBox txtSerialno;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comSpecification;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        // private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
