
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI
{
    partial class FrmSelectSheet
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.butCancle = new System.Windows.Forms.Button();
            this.butSelect = new System.Windows.Forms.Button();
            this.lvSheetAll = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvSheetAll, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.21374F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.78626F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 489);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.butCancle);
            this.panel2.Controls.Add(this.butSelect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 53);
            this.panel2.TabIndex = 1;
            // 
            // butCancle
            // 
            this.butCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancle.Location = new System.Drawing.Point(259, 2);
            this.butCancle.Name = "butCancle";
            this.butCancle.Size = new System.Drawing.Size(75, 23);
            this.butCancle.TabIndex = 4;
            this.butCancle.Text = "Cancel";
            this.butCancle.UseVisualStyleBackColor = true;
            this.butCancle.Click += new System.EventHandler(this.butCancle_Click);
            // 
            // butSelect
            // 
            this.butSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSelect.Enabled = false;
            this.butSelect.Location = new System.Drawing.Point(178, 2);
            this.butSelect.Name = "butSelect";
            this.butSelect.Size = new System.Drawing.Size(75, 23);
            this.butSelect.TabIndex = 3;
            this.butSelect.Text = "Select";
            this.butSelect.UseVisualStyleBackColor = true;
            this.butSelect.Click += new System.EventHandler(this.butSelect_Click);
            // 
            // lvSheetAll
            // 
            this.lvSheetAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSheetAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSheetAll.FullRowSelect = true;
            this.lvSheetAll.GridLines = true;
            this.lvSheetAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSheetAll.HideSelection = false;
            this.lvSheetAll.Location = new System.Drawing.Point(3, 62);
            this.lvSheetAll.Name = "lvSheetAll";
            this.lvSheetAll.Size = new System.Drawing.Size(343, 424);
            this.lvSheetAll.TabIndex = 3;
            this.lvSheetAll.UseCompatibleStateImageBehavior = false;
            this.lvSheetAll.View = System.Windows.Forms.View.Details;
            this.lvSheetAll.SelectedIndexChanged += new System.EventHandler(this.lvSheetAll_SelectedIndexChanged);
            this.lvSheetAll.DoubleClick += new System.EventHandler(this.lvSheetAll_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sheet";
            this.columnHeader1.Width = 281;
            // 
            // FrmSelectSheet
            // 
            this.AcceptButton = this.butSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancle;
            this.ClientSize = new System.Drawing.Size(349, 489);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectSheet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Sheet";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvSheetAll;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button butCancle;
        private System.Windows.Forms.Button butSelect;

    }
}
