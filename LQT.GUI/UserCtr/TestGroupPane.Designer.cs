namespace LQT.GUI.UserCtr
{
    partial class TestGroupPane
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
            this.butDeletetest = new System.Windows.Forms.Button();
            this.butEdittest = new System.Windows.Forms.Button();
            this.butNewtest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsvGroups = new System.Windows.Forms.ListView();
            this.txtAreaname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comTestarea = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // colName
            // 
            this.colName.Text = "Test Name";
            this.colName.Width = 311;
            // 
            // butDeletetest
            // 
            this.butDeletetest.Enabled = false;
            this.butDeletetest.Location = new System.Drawing.Point(398, 160);
            this.butDeletetest.Name = "butDeletetest";
            this.butDeletetest.Size = new System.Drawing.Size(75, 23);
            this.butDeletetest.TabIndex = 24;
            this.butDeletetest.Text = "Delete";
            this.butDeletetest.UseVisualStyleBackColor = true;
            this.butDeletetest.Click += new System.EventHandler(this.butDeletetest_Click);
            // 
            // butEdittest
            // 
            this.butEdittest.Enabled = false;
            this.butEdittest.Location = new System.Drawing.Point(398, 131);
            this.butEdittest.Name = "butEdittest";
            this.butEdittest.Size = new System.Drawing.Size(75, 23);
            this.butEdittest.TabIndex = 23;
            this.butEdittest.Text = "Edit...";
            this.butEdittest.UseVisualStyleBackColor = true;
            this.butEdittest.Click += new System.EventHandler(this.butEdittest_Click);
            // 
            // butNewtest
            // 
            this.butNewtest.Location = new System.Drawing.Point(398, 102);
            this.butNewtest.Name = "butNewtest";
            this.butNewtest.Size = new System.Drawing.Size(75, 23);
            this.butNewtest.TabIndex = 22;
            this.butNewtest.Text = "New...";
            this.butNewtest.UseVisualStyleBackColor = true;
            this.butNewtest.Click += new System.EventHandler(this.butNewtest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(10, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tests";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(44, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 2);
            this.label2.TabIndex = 20;
            // 
            // lsvGroups
            // 
            this.lsvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lsvGroups.FullRowSelect = true;
            this.lsvGroups.GridLines = true;
            this.lsvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvGroups.Location = new System.Drawing.Point(79, 102);
            this.lsvGroups.MultiSelect = false;
            this.lsvGroups.Name = "lsvGroups";
            this.lsvGroups.Size = new System.Drawing.Size(311, 156);
            this.lsvGroups.TabIndex = 19;
            this.lsvGroups.UseCompatibleStateImageBehavior = false;
            this.lsvGroups.View = System.Windows.Forms.View.Details;
            this.lsvGroups.SelectedIndexChanged += new System.EventHandler(this.lsvGroups_SelectedIndexChanged);
            // 
            // txtAreaname
            // 
            this.txtAreaname.Location = new System.Drawing.Point(79, 11);
            this.txtAreaname.MaximumSize = new System.Drawing.Size(311, 25);
            this.txtAreaname.MinimumSize = new System.Drawing.Size(311, 25);
            this.txtAreaname.Name = "txtAreaname";
            this.txtAreaname.Size = new System.Drawing.Size(311, 20);
            this.txtAreaname.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Group Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Testing Area:";
            // 
            // comTestarea
            // 
            this.comTestarea.DisplayMember = "AreaName";
            this.comTestarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTestarea.FormattingEnabled = true;
            this.comTestarea.Location = new System.Drawing.Point(79, 47);
            this.comTestarea.Name = "comTestarea";
            this.comTestarea.Size = new System.Drawing.Size(311, 21);
            this.comTestarea.TabIndex = 26;
            this.comTestarea.Tag = "";
            this.comTestarea.ValueMember = "Id";
            // 
            // TestGroupPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.comTestarea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butDeletetest);
            this.Controls.Add(this.butEdittest);
            this.Controls.Add(this.butNewtest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsvGroups);
            this.Controls.Add(this.txtAreaname);
            this.Controls.Add(this.label1);
            this.Name = "TestGroupPane";
            this.Size = new System.Drawing.Size(486, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button butDeletetest;
        private System.Windows.Forms.Button butEdittest;
        private System.Windows.Forms.Button butNewtest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvGroups;
        private System.Windows.Forms.TextBox txtAreaname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comTestarea;
    }
}
