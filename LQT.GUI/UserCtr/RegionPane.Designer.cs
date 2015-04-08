namespace LQT.GUI.UserCtr
{
    partial class RegionPane
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
            this.lblSites = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtShortname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lsvGroups = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butDeletesite = new System.Windows.Forms.Button();
            this.butEditsite = new System.Windows.Forms.Button();
            this.butNewsite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Region Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Short Name:";
            // 
            // lblSites
            // 
            this.lblSites.AutoSize = true;
            this.lblSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSites.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSites.Location = new System.Drawing.Point(3, 72);
            this.lblSites.Name = "lblSites";
            this.lblSites.Size = new System.Drawing.Size(35, 13);
            this.lblSites.TabIndex = 2;
            this.lblSites.Text = "Sites";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 11);
            this.txtName.MaxLength = 64;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtShortname
            // 
            this.txtShortname.Location = new System.Drawing.Point(81, 37);
            this.txtShortname.MaxLength = 8;
            this.txtShortname.Name = "txtShortname";
            this.txtShortname.Size = new System.Drawing.Size(100, 20);
            this.txtShortname.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(30, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(493, 1);
            this.label4.TabIndex = 5;
            // 
            // lsvGroups
            // 
            this.lsvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvGroups.FullRowSelect = true;
            this.lsvGroups.GridLines = true;
            this.lsvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvGroups.Location = new System.Drawing.Point(81, 94);
            this.lsvGroups.MultiSelect = false;
            this.lsvGroups.Name = "lsvGroups";
            this.lsvGroups.Size = new System.Drawing.Size(441, 197);
            this.lsvGroups.TabIndex = 12;
            this.lsvGroups.UseCompatibleStateImageBehavior = false;
            this.lsvGroups.View = System.Windows.Forms.View.Details;
            this.lsvGroups.SelectedIndexChanged += new System.EventHandler(this.lsvGroups_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Site Name";
            this.colName.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Currently Open";
            this.columnHeader1.Width = 88;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Opening Date";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Closing Date";
            this.columnHeader3.Width = 103;
            // 
            // butDeletesite
            // 
            this.butDeletesite.Enabled = false;
            this.butDeletesite.Location = new System.Drawing.Point(528, 152);
            this.butDeletesite.Name = "butDeletesite";
            this.butDeletesite.Size = new System.Drawing.Size(75, 23);
            this.butDeletesite.TabIndex = 19;
            this.butDeletesite.Text = "Delete";
            this.butDeletesite.UseVisualStyleBackColor = true;
            this.butDeletesite.Click += new System.EventHandler(this.butDeletesite_Click);
            // 
            // butEditsite
            // 
            this.butEditsite.Enabled = false;
            this.butEditsite.Location = new System.Drawing.Point(528, 123);
            this.butEditsite.Name = "butEditsite";
            this.butEditsite.Size = new System.Drawing.Size(75, 23);
            this.butEditsite.TabIndex = 18;
            this.butEditsite.Text = "Edit...";
            this.butEditsite.UseVisualStyleBackColor = true;
            this.butEditsite.Click += new System.EventHandler(this.butEditsite_Click);
            // 
            // butNewsite
            // 
            this.butNewsite.Location = new System.Drawing.Point(528, 94);
            this.butNewsite.Name = "butNewsite";
            this.butNewsite.Size = new System.Drawing.Size(75, 23);
            this.butNewsite.TabIndex = 17;
            this.butNewsite.Text = "New...";
            this.butNewsite.UseVisualStyleBackColor = true;
            this.butNewsite.Click += new System.EventHandler(this.butNewsite_Click);
            // 
            // RegionPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.butDeletesite);
            this.Controls.Add(this.butEditsite);
            this.Controls.Add(this.butNewsite);
            this.Controls.Add(this.lsvGroups);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtShortname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSites);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegionPane";
            this.Size = new System.Drawing.Size(616, 303);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSites;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtShortname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lsvGroups;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button butDeletesite;
        private System.Windows.Forms.Button butEditsite;
        private System.Windows.Forms.Button butNewsite;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
