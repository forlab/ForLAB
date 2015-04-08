namespace LQT.GUI.UserCtr
{
    partial class TestAreaPane
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
            this.butDeletegroup = new System.Windows.Forms.Button();
            this.butEditgoup = new System.Windows.Forms.Button();
            this.butNewgroup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvGroups = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAreaname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkuseindemograph = new System.Windows.Forms.CheckBox();
            this.lblcategory = new System.Windows.Forms.Label();
            this.cobCategory = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butDeletegroup
            // 
            this.butDeletegroup.Enabled = false;
            this.butDeletegroup.Location = new System.Drawing.Point(368, 128);
            this.butDeletegroup.Name = "butDeletegroup";
            this.butDeletegroup.Size = new System.Drawing.Size(75, 23);
            this.butDeletegroup.TabIndex = 16;
            this.butDeletegroup.Text = "Delete";
            this.butDeletegroup.UseVisualStyleBackColor = true;
            this.butDeletegroup.Click += new System.EventHandler(this.butDeletegroup_Click);
            // 
            // butEditgoup
            // 
            this.butEditgoup.Enabled = false;
            this.butEditgoup.Location = new System.Drawing.Point(368, 99);
            this.butEditgoup.Name = "butEditgoup";
            this.butEditgoup.Size = new System.Drawing.Size(75, 23);
            this.butEditgoup.TabIndex = 15;
            this.butEditgoup.Text = "Edit...";
            this.butEditgoup.UseVisualStyleBackColor = true;
            this.butEditgoup.Click += new System.EventHandler(this.butEditgoup_Click);
            // 
            // butNewgroup
            // 
            this.butNewgroup.Location = new System.Drawing.Point(368, 70);
            this.butNewgroup.Name = "butNewgroup";
            this.butNewgroup.Size = new System.Drawing.Size(75, 23);
            this.butNewgroup.TabIndex = 14;
            this.butNewgroup.Text = "New...";
            this.butNewgroup.UseVisualStyleBackColor = true;
            this.butNewgroup.Click += new System.EventHandler(this.butNewgroup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Testing Groups";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(92, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 2);
            this.label2.TabIndex = 12;
            // 
            // lsvGroups
            // 
            this.lsvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lsvGroups.FullRowSelect = true;
            this.lsvGroups.GridLines = true;
            this.lsvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvGroups.Location = new System.Drawing.Point(10, 20);
            this.lsvGroups.MultiSelect = false;
            this.lsvGroups.Name = "lsvGroups";
            this.lsvGroups.Size = new System.Drawing.Size(325, 203);
            this.lsvGroups.TabIndex = 11;
            this.lsvGroups.UseCompatibleStateImageBehavior = false;
            this.lsvGroups.View = System.Windows.Forms.View.Details;
            this.lsvGroups.SelectedIndexChanged += new System.EventHandler(this.lsvGroups_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Group Name";
            this.colName.Width = 311;
            // 
            // txtAreaname
            // 
            this.txtAreaname.Location = new System.Drawing.Point(110, 13);
            this.txtAreaname.Name = "txtAreaname";
            this.txtAreaname.Size = new System.Drawing.Size(282, 20);
            this.txtAreaname.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Testing Area Name:";
            // 
            // chkuseindemograph
            // 
            this.chkuseindemograph.AutoSize = true;
            this.chkuseindemograph.Location = new System.Drawing.Point(110, 39);
            this.chkuseindemograph.Name = "chkuseindemograph";
            this.chkuseindemograph.Size = new System.Drawing.Size(179, 17);
            this.chkuseindemograph.TabIndex = 17;
            this.chkuseindemograph.Text = "Use In Demograph Methodology";
            this.chkuseindemograph.UseVisualStyleBackColor = true;
            this.chkuseindemograph.CheckedChanged += new System.EventHandler(this.chkuseindemograph_CheckedChanged);
            // 
            // lblcategory
            // 
            this.lblcategory.AutoSize = true;
            this.lblcategory.Location = new System.Drawing.Point(23, 65);
            this.lblcategory.Name = "lblcategory";
            this.lblcategory.Size = new System.Drawing.Size(52, 13);
            this.lblcategory.TabIndex = 18;
            this.lblcategory.Text = "Category:";
            // 
            // cobCategory
            // 
            this.cobCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobCategory.FormattingEnabled = true;
            this.cobCategory.Location = new System.Drawing.Point(110, 62);
            this.cobCategory.Name = "cobCategory";
            this.cobCategory.Size = new System.Drawing.Size(282, 21);
            this.cobCategory.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(15, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(530, 255);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lsvGroups);
            this.tabPage1.Controls.Add(this.butDeletegroup);
            this.tabPage1.Controls.Add(this.butNewgroup);
            this.tabPage1.Controls.Add(this.butEditgoup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(522, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Testing Groups";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(522, 229);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Instruments";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(522, 229);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Supplies Quantification";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TestAreaPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cobCategory);
            this.Controls.Add(this.lblcategory);
            this.Controls.Add(this.chkuseindemograph);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAreaname);
            this.Controls.Add(this.label1);
            this.Name = "TestAreaPane";
            this.Size = new System.Drawing.Size(565, 368);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDeletegroup;
        private System.Windows.Forms.Button butEditgoup;
        private System.Windows.Forms.Button butNewgroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ListView lsvGroups;
        private System.Windows.Forms.TextBox txtAreaname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkuseindemograph;
        private System.Windows.Forms.Label lblcategory;
        private System.Windows.Forms.ComboBox cobCategory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}
