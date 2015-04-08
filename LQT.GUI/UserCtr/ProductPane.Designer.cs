namespace LQT.GUI.UserCtr
{
    partial class ProductPane
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtSerialno = new System.Windows.Forms.TextBox();
            this.txtSpecification = new System.Windows.Forms.TextBox();
            this.txtBasicunit = new System.Windows.Forms.TextBox();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.lsvPrice = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butNewprice = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtminimumPacks = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Category:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serial No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Specification:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Basic Unit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Note:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 12);
            this.txtName.MaxLength = 64;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(256, 20);
            this.txtName.TabIndex = 8;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(100, 178);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(256, 49);
            this.txtNote.TabIndex = 9;
            // 
            // txtSerialno
            // 
            this.txtSerialno.Location = new System.Drawing.Point(100, 68);
            this.txtSerialno.MaxLength = 16;
            this.txtSerialno.Name = "txtSerialno";
            this.txtSerialno.Size = new System.Drawing.Size(100, 20);
            this.txtSerialno.TabIndex = 10;
            // 
            // txtSpecification
            // 
            this.txtSpecification.Location = new System.Drawing.Point(100, 96);
            this.txtSpecification.MaxLength = 256;
            this.txtSpecification.Name = "txtSpecification";
            this.txtSpecification.Size = new System.Drawing.Size(256, 20);
            this.txtSpecification.TabIndex = 11;
            // 
            // txtBasicunit
            // 
            this.txtBasicunit.Location = new System.Drawing.Point(100, 124);
            this.txtBasicunit.MaxLength = 16;
            this.txtBasicunit.Name = "txtBasicunit";
            this.txtBasicunit.Size = new System.Drawing.Size(100, 20);
            this.txtBasicunit.TabIndex = 12;
            // 
            // comCategory
            // 
            this.comCategory.DisplayMember = "TypeName";
            this.comCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(100, 41);
            this.comCategory.Name = "comCategory";
            this.comCategory.Size = new System.Drawing.Size(256, 21);
            this.comCategory.TabIndex = 15;
            this.comCategory.ValueMember = "Id";
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
            this.lsvPrice.Location = new System.Drawing.Point(100, 235);
            this.lsvPrice.MultiSelect = false;
            this.lsvPrice.Name = "lsvPrice";
            this.lsvPrice.Size = new System.Drawing.Size(256, 103);
            this.lsvPrice.TabIndex = 16;
            this.lsvPrice.UseCompatibleStateImageBehavior = false;
            this.lsvPrice.View = System.Windows.Forms.View.Details;
            this.lsvPrice.SelectedIndexChanged += new System.EventHandler(this.lsvPrice_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Price";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pack Size";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "As of Date";
            this.columnHeader2.Width = 100;
            // 
            // butNewprice
            // 
            this.butNewprice.Location = new System.Drawing.Point(47, 259);
            this.butNewprice.Name = "butNewprice";
            this.butNewprice.Size = new System.Drawing.Size(50, 27);
            this.butNewprice.TabIndex = 17;
            this.butNewprice.Text = "New";
            this.butNewprice.UseVisualStyleBackColor = true;
            this.butNewprice.Click += new System.EventHandler(this.butNewprice_Click);
            // 
            // butEdit
            // 
            this.butEdit.Enabled = false;
            this.butEdit.Location = new System.Drawing.Point(48, 288);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(50, 27);
            this.butEdit.TabIndex = 18;
            this.butEdit.Text = "Edit";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Min. Packs / Site:";
            // 
            // txtminimumPacks
            // 
            this.txtminimumPacks.Location = new System.Drawing.Point(100, 151);
            this.txtminimumPacks.MaxLength = 16;
            this.txtminimumPacks.Name = "txtminimumPacks";
            this.txtminimumPacks.Size = new System.Drawing.Size(100, 20);
            this.txtminimumPacks.TabIndex = 20;
            // 
            // ProductPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.txtminimumPacks);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butNewprice);
            this.Controls.Add(this.lsvPrice);
            this.Controls.Add(this.comCategory);
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
            this.Name = "ProductPane";
            this.Size = new System.Drawing.Size(379, 347);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtSerialno;
        private System.Windows.Forms.TextBox txtSpecification;
        private System.Windows.Forms.TextBox txtBasicunit;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.ListView lsvPrice;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button butNewprice;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtminimumPacks;
    }
}
