
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.Testing
{
    partial class TestingGroupFrom
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
            this.comTestarea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.lsvGroups = new System.Windows.Forms.ListView();
            this.txtAreaname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 31);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lqtToolStrip1
            // 
            this.lqtToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lqtToolStrip1.Location = new System.Drawing.Point(3, 3);
            this.lqtToolStrip1.Name = "lqtToolStrip1";
            this.lqtToolStrip1.Size = new System.Drawing.Size(484, 25);
            this.lqtToolStrip1.TabIndex = 0;
            // 
            // comTestarea
            // 
            this.comTestarea.DisplayMember = "AreaName";
            this.comTestarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTestarea.FormattingEnabled = true;
            this.comTestarea.Location = new System.Drawing.Point(83, 84);
            this.comTestarea.Name = "comTestarea";
            this.comTestarea.Size = new System.Drawing.Size(311, 21);
            this.comTestarea.TabIndex = 2;
            this.comTestarea.Tag = "";
            this.comTestarea.ValueMember = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Testing Area:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(14, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Tests";
            // 
            // colName
            // 
            this.colName.Text = "Test Name";
            this.colName.Width = 311;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(48, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 2);
            this.label2.TabIndex = 30;
            // 
            // lsvGroups
            // 
            this.lsvGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lsvGroups.FullRowSelect = true;
            this.lsvGroups.GridLines = true;
            this.lsvGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvGroups.Location = new System.Drawing.Point(83, 139);
            this.lsvGroups.MultiSelect = false;
            this.lsvGroups.Name = "lsvGroups";
            this.lsvGroups.Size = new System.Drawing.Size(395, 156);
            this.lsvGroups.TabIndex = 3;
            this.lsvGroups.UseCompatibleStateImageBehavior = false;
            this.lsvGroups.View = System.Windows.Forms.View.Details;
            // 
            // txtAreaname
            // 
            this.txtAreaname.Location = new System.Drawing.Point(83, 48);
            this.txtAreaname.MaximumSize = new System.Drawing.Size(311, 25);
            this.txtAreaname.MinimumSize = new System.Drawing.Size(311, 25);
            this.txtAreaname.Name = "txtAreaname";
            this.txtAreaname.Size = new System.Drawing.Size(311, 20);
            this.txtAreaname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Group Name:";
            // 
            // TestingGroupFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 312);
            this.Controls.Add(this.comTestarea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsvGroups);
            this.Controls.Add(this.txtAreaname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestingGroupFrom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing Group";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserCtr.LqtToolStrip lqtToolStrip1;
        private System.Windows.Forms.ComboBox comTestarea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lsvGroups;
        private System.Windows.Forms.TextBox txtAreaname;
        private System.Windows.Forms.Label label1;
        // private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

    }
}
