namespace LQT.GUI.UserCtr
{
    partial class Protocolpane
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txttestsrepeated = new System.Windows.Forms.TextBox();
            this.txtsymptomdirected = new System.Windows.Forms.TextBox();
            this.txtprotocolcategory = new System.Windows.Forms.TextBox();
            this.lblsystemdirected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butDeletepanel = new System.Windows.Forms.Button();
            this.butEditpanel = new System.Windows.Forms.Button();
            this.butNewpanel = new System.Windows.Forms.Button();
            this.lsvpanel = new LQT.GUI.LQTListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvsysmpDirected = new LQT.GUI.LQTListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(47, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(577, 1);
            this.label6.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Panel";
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(112, 44);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(513, 50);
            this.txtdescription.TabIndex = 7;
            // 
            // txttestsrepeated
            // 
            this.txttestsrepeated.Location = new System.Drawing.Point(525, 18);
            this.txttestsrepeated.Name = "txttestsrepeated";
            this.txttestsrepeated.Size = new System.Drawing.Size(100, 20);
            this.txttestsrepeated.TabIndex = 6;
            // 
            // txtsymptomdirected
            // 
            this.txtsymptomdirected.Location = new System.Drawing.Point(524, 100);
            this.txtsymptomdirected.Name = "txtsymptomdirected";
            this.txtsymptomdirected.Size = new System.Drawing.Size(100, 20);
            this.txtsymptomdirected.TabIndex = 5;
            // 
            // txtprotocolcategory
            // 
            this.txtprotocolcategory.Location = new System.Drawing.Point(112, 18);
            this.txtprotocolcategory.MaxLength = 64;
            this.txtprotocolcategory.Name = "txtprotocolcategory";
            this.txtprotocolcategory.ReadOnly = true;
            this.txtprotocolcategory.Size = new System.Drawing.Size(159, 20);
            this.txtprotocolcategory.TabIndex = 4;
            // 
            // lblsystemdirected
            // 
            this.lblsystemdirected.AutoSize = true;
            this.lblsystemdirected.Location = new System.Drawing.Point(308, 103);
            this.lblsystemdirected.Name = "lblsystemdirected";
            this.lblsystemdirected.Size = new System.Drawing.Size(166, 13);
            this.lblsystemdirected.TabIndex = 3;
            this.lblsystemdirected.Text = "% Symptom-Directed Tests /Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Protocol Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "%Tests repeated due to clinician request:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            // 
            // butDeletepanel
            // 
            this.butDeletepanel.Enabled = false;
            this.butDeletepanel.Location = new System.Drawing.Point(557, 193);
            this.butDeletepanel.Name = "butDeletepanel";
            this.butDeletepanel.Size = new System.Drawing.Size(67, 23);
            this.butDeletepanel.TabIndex = 22;
            this.butDeletepanel.Text = "Delete";
            this.butDeletepanel.UseVisualStyleBackColor = true;
            this.butDeletepanel.Click += new System.EventHandler(this.butDeletepanel_Click);
            // 
            // butEditpanel
            // 
            this.butEditpanel.Enabled = false;
            this.butEditpanel.Location = new System.Drawing.Point(557, 164);
            this.butEditpanel.Name = "butEditpanel";
            this.butEditpanel.Size = new System.Drawing.Size(67, 23);
            this.butEditpanel.TabIndex = 21;
            this.butEditpanel.Text = "Edit...";
            this.butEditpanel.UseVisualStyleBackColor = true;
            this.butEditpanel.Click += new System.EventHandler(this.butEditpanel_Click);
            // 
            // butNewpanel
            // 
            this.butNewpanel.Location = new System.Drawing.Point(557, 135);
            this.butNewpanel.Name = "butNewpanel";
            this.butNewpanel.Size = new System.Drawing.Size(67, 23);
            this.butNewpanel.TabIndex = 20;
            this.butNewpanel.Text = "New...";
            this.butNewpanel.UseVisualStyleBackColor = true;
            this.butNewpanel.Click += new System.EventHandler(this.butNewpanel_Click);
            // 
            // lsvpanel
            // 
            this.lsvpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvpanel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lsvpanel.FullRowSelect = true;
            this.lsvpanel.GridLines = true;
            this.lsvpanel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvpanel.Location = new System.Drawing.Point(112, 135);
            this.lsvpanel.MultiSelect = false;
            this.lsvpanel.Name = "lsvpanel";
            this.lsvpanel.Size = new System.Drawing.Size(441, 97);
            this.lsvpanel.TabIndex = 23;
            this.lsvpanel.UseCompatibleStateImageBehavior = false;
            this.lsvpanel.View = System.Windows.Forms.View.Details;
            this.lsvpanel.SelectedIndexChanged += new System.EventHandler(this.lsvpanel_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Panel Name";
            this.colName.Width = 392;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(44, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(577, 1);
            this.label4.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(9, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(189, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Symptom-Directed Test/Year";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvsysmpDirected);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 147);
            this.panel1.TabIndex = 26;
            // 
            // lvsysmpDirected
            // 
            this.lvsysmpDirected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvsysmpDirected.FullRowSelect = true;
            this.lvsysmpDirected.GridLines = true;
            this.lvsysmpDirected.Location = new System.Drawing.Point(109, 27);
            this.lvsysmpDirected.Name = "lvsysmpDirected";
            this.lvsysmpDirected.Size = new System.Drawing.Size(513, 114);
            this.lvsysmpDirected.TabIndex = 26;
            this.lvsysmpDirected.UseCompatibleStateImageBehavior = false;
            this.lvsysmpDirected.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Test";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Adult In Treatment";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Pediatric in Treatment";
            this.columnHeader3.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Adult Pre-ART";
            this.columnHeader4.Width = 82;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pediatric Pre-ART";
            this.columnHeader5.Width = 97;
            // 
            // Protocolpane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsvpanel);
            this.Controls.Add(this.butDeletepanel);
            this.Controls.Add(this.butEditpanel);
            this.Controls.Add(this.butNewpanel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.txttestsrepeated);
            this.Controls.Add(this.txtsymptomdirected);
            this.Controls.Add(this.txtprotocolcategory);
            this.Controls.Add(this.lblsystemdirected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Protocolpane";
            this.Size = new System.Drawing.Size(637, 390);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblsystemdirected;
        private System.Windows.Forms.TextBox txtprotocolcategory;
        private System.Windows.Forms.TextBox txtsymptomdirected;
        private System.Windows.Forms.TextBox txttestsrepeated;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butDeletepanel;
        private System.Windows.Forms.Button butEditpanel;
        private System.Windows.Forms.Button butNewpanel;
        private LQTListView lsvpanel;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private LQTListView lvsysmpDirected;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
