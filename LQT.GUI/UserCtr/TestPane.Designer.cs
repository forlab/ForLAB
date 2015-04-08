namespace LQT.GUI.UserCtr
{
    partial class TestPane
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
            this.comTestarea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTestname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.butRemove = new System.Windows.Forms.Button();
            this.comProduct = new System.Windows.Forms.ComboBox();
            this.comInstrument = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listView1 = new LQT.GUI.LQTListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.comTestType = new System.Windows.Forms.ComboBox();
            this.lbltestingduration = new System.Windows.Forms.Label();
            this.comTestingDuration = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comProductUsedIn = new System.Windows.Forms.ComboBox();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comTestarea
            // 
            this.comTestarea.DisplayMember = "AreaName";
            this.comTestarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTestarea.FormattingEnabled = true;
            this.comTestarea.Location = new System.Drawing.Point(97, 44);
            this.comTestarea.Name = "comTestarea";
            this.comTestarea.Size = new System.Drawing.Size(311, 21);
            this.comTestarea.TabIndex = 30;
            this.comTestarea.Tag = "";
            this.comTestarea.ValueMember = "Id";
            this.comTestarea.SelectedIndexChanged += new System.EventHandler(this.comTestarea_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Testing Area:";
            // 
            // txtTestname
            // 
            this.txtTestname.Location = new System.Drawing.Point(97, 14);
            this.txtTestname.MaximumSize = new System.Drawing.Size(311, 25);
            this.txtTestname.MinimumSize = new System.Drawing.Size(311, 25);
            this.txtTestname.Name = "txtTestname";
            this.txtTestname.Size = new System.Drawing.Size(311, 20);
            this.txtTestname.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Test Name:";
            // 
            // comGroup
            // 
            this.comGroup.DisplayMember = "GroupName";
            this.comGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGroup.Location = new System.Drawing.Point(97, 75);
            this.comGroup.Name = "comGroup";
            this.comGroup.Size = new System.Drawing.Size(311, 21);
            this.comGroup.TabIndex = 32;
            this.comGroup.Tag = "";
            this.comGroup.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Testing Group:";
            // 
            // butAdd
            // 
            this.butAdd.Enabled = false;
            this.butAdd.Location = new System.Drawing.Point(558, 13);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(66, 22);
            this.butAdd.TabIndex = 36;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butRemove
            // 
            this.butRemove.Enabled = false;
            this.butRemove.Location = new System.Drawing.Point(558, 36);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(68, 22);
            this.butRemove.TabIndex = 37;
            this.butRemove.Text = "Remove";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // comProduct
            // 
            this.comProduct.DisplayMember = "ProductName";
            this.comProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProduct.FormattingEnabled = true;
            this.comProduct.Location = new System.Drawing.Point(350, 19);
            this.comProduct.Name = "comProduct";
            this.comProduct.Size = new System.Drawing.Size(202, 21);
            this.comProduct.TabIndex = 39;
            this.comProduct.ValueMember = "Id";
            // 
            // comInstrument
            // 
            this.comInstrument.DisplayMember = "InstrumentName";
            this.comInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comInstrument.FormattingEnabled = true;
            this.comInstrument.Location = new System.Drawing.Point(91, 19);
            this.comInstrument.Name = "comInstrument";
            this.comInstrument.Size = new System.Drawing.Size(217, 21);
            this.comInstrument.TabIndex = 38;
            this.comInstrument.ValueMember = "Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(314, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Pro.";
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
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(11, 73);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(615, 185);
            this.listView1.TabIndex = 42;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Instrument";
            this.columnHeader1.Width = 183;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product";
            this.columnHeader2.Width = 166;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rate";
            this.columnHeader3.Width = 127;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Test Type:";
            // 
            // comTestType
            // 
            this.comTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTestType.FormattingEnabled = true;
            this.comTestType.Location = new System.Drawing.Point(97, 106);
            this.comTestType.Name = "comTestType";
            this.comTestType.Size = new System.Drawing.Size(311, 21);
            this.comTestType.TabIndex = 44;
            this.comTestType.SelectedIndexChanged += new System.EventHandler(this.comTestType_SelectedIndexChanged);
            // 
            // lbltestingduration
            // 
            this.lbltestingduration.AutoSize = true;
            this.lbltestingduration.Location = new System.Drawing.Point(3, 140);
            this.lbltestingduration.Name = "lbltestingduration";
            this.lbltestingduration.Size = new System.Drawing.Size(88, 13);
            this.lbltestingduration.TabIndex = 45;
            this.lbltestingduration.Text = "Testing Duration:";
            // 
            // comTestingDuration
            // 
            this.comTestingDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTestingDuration.FormattingEnabled = true;
            this.comTestingDuration.Location = new System.Drawing.Point(97, 137);
            this.comTestingDuration.Name = "comTestingDuration";
            this.comTestingDuration.Size = new System.Drawing.Size(311, 21);
            this.comTestingDuration.TabIndex = 46;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comProductUsedIn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comInstrument);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butRemove);
            this.groupBox1.Controls.Add(this.comProduct);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 264);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Usage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Product Used In:";
            // 
            // comProductUsedIn
            // 
            this.comProductUsedIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProductUsedIn.FormattingEnabled = true;
            this.comProductUsedIn.Location = new System.Drawing.Point(91, 46);
            this.comProductUsedIn.Name = "comProductUsedIn";
            this.comProductUsedIn.Size = new System.Drawing.Size(217, 21);
            this.comProductUsedIn.TabIndex = 44;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Used In";
            this.columnHeader4.Width = 124;
            // 
            // TestPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comTestingDuration);
            this.Controls.Add(this.lbltestingduration);
            this.Controls.Add(this.comTestType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comTestarea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTestname);
            this.Controls.Add(this.label1);
            this.Name = "TestPane";
            this.Size = new System.Drawing.Size(644, 437);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comTestarea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTestname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comGroup;
        private System.Windows.Forms.Label label2;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butRemove;
        private System.Windows.Forms.ComboBox comProduct;
        private System.Windows.Forms.ComboBox comInstrument;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private LQTListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comTestType;
        private System.Windows.Forms.Label lbltestingduration;
        private System.Windows.Forms.ComboBox comTestingDuration;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comProductUsedIn;
        private System.Windows.Forms.Label label3;
    }
}
