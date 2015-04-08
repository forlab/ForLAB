namespace LQT.GUI.UserCtr
{
    partial class ProductTypePane
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
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butDeletepro = new System.Windows.Forms.Button();
            this.butEditpro = new System.Windows.Forms.Button();
            this.butNewpro = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvGroups = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkuseindemograph = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // colName
            // 
            this.colName.Text = "Product Name";
            this.colName.Width = 120;
            // 
            // butDeletepro
            // 
            this.butDeletepro.Enabled = false;
            this.butDeletepro.Location = new System.Drawing.Point(451, 201);
            this.butDeletepro.Name = "butDeletepro";
            this.butDeletepro.Size = new System.Drawing.Size(75, 23);
            this.butDeletepro.TabIndex = 24;
            this.butDeletepro.Text = "Delete";
            this.butDeletepro.UseVisualStyleBackColor = true;
            this.butDeletepro.Click += new System.EventHandler(this.butDeletepro_Click);
            // 
            // butEditpro
            // 
            this.butEditpro.Enabled = false;
            this.butEditpro.Location = new System.Drawing.Point(451, 172);
            this.butEditpro.Name = "butEditpro";
            this.butEditpro.Size = new System.Drawing.Size(75, 23);
            this.butEditpro.TabIndex = 23;
            this.butEditpro.Text = "Edit...";
            this.butEditpro.UseVisualStyleBackColor = true;
            this.butEditpro.Click += new System.EventHandler(this.butEditpro_Click);
            // 
            // butNewpro
            // 
            this.butNewpro.Location = new System.Drawing.Point(451, 143);
            this.butNewpro.Name = "butNewpro";
            this.butNewpro.Size = new System.Drawing.Size(75, 23);
            this.butNewpro.TabIndex = 22;
            this.butNewpro.Text = "New...";
            this.butNewpro.UseVisualStyleBackColor = true;
            this.butNewpro.Click += new System.EventHandler(this.butNewpro_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(3, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Products";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(60, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 2);
            this.label2.TabIndex = 20;
            // 
            // lsvGroups
            // 
            this.lsvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.lsvGroups.FullRowSelect = true;
            this.lsvGroups.GridLines = true;
            this.lsvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvGroups.Location = new System.Drawing.Point(76, 145);
            this.lsvGroups.MultiSelect = false;
            this.lsvGroups.Name = "lsvGroups";
            this.lsvGroups.Size = new System.Drawing.Size(369, 195);
            this.lsvGroups.TabIndex = 19;
            this.lsvGroups.UseCompatibleStateImageBehavior = false;
            this.lsvGroups.View = System.Windows.Forms.View.Details;
            this.lsvGroups.SelectedIndexChanged += new System.EventHandler(this.lsvGroups_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Serial No";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Specification";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Basic Unit";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 6);
            this.txtName.MaximumSize = new System.Drawing.Size(311, 25);
            this.txtName.MinimumSize = new System.Drawing.Size(311, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(311, 25);
            this.txtName.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Type Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 39);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(311, 52);
            this.txtDescription.TabIndex = 26;
            // 
            // chkuseindemograph
            // 
            this.chkuseindemograph.AutoSize = true;
            this.chkuseindemograph.Location = new System.Drawing.Point(76, 98);
            this.chkuseindemograph.Name = "chkuseindemograph";
            this.chkuseindemograph.Size = new System.Drawing.Size(179, 17);
            this.chkuseindemograph.TabIndex = 27;
            this.chkuseindemograph.Text = "Use In Demograph Methodology";
            this.chkuseindemograph.UseVisualStyleBackColor = true;
            // 
            // ProductTypePane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.chkuseindemograph);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butDeletepro);
            this.Controls.Add(this.butEditpro);
            this.Controls.Add(this.butNewpro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsvGroups);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "ProductTypePane";
            this.Size = new System.Drawing.Size(529, 355);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button butDeletepro;
        private System.Windows.Forms.Button butEditpro;
        private System.Windows.Forms.Button butNewpro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvGroups;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkuseindemograph;
    }
}
