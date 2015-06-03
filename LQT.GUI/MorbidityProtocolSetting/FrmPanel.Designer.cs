
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

namespace LQT.GUI.MorbidityProtocolSetting
{
    partial class FrmPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtpanelName = new System.Windows.Forms.TextBox();
            this.lstTest = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbxSample = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.900523F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.09948F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(823, 0);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Panel Name:";
            // 
            // txtpanelName
            // 
            this.txtpanelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpanelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanelName.Location = new System.Drawing.Point(97, 20);
            this.txtpanelName.Name = "txtpanelName";
            this.txtpanelName.Size = new System.Drawing.Size(542, 23);
            this.txtpanelName.TabIndex = 98;
            // 
            // lstTest
            // 
            this.lstTest.CheckBoxes = true;
            this.lstTest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTest.GridLines = true;
            this.lstTest.Location = new System.Drawing.Point(3, 19);
            this.lstTest.Name = "lstTest";
            this.lstTest.Size = new System.Drawing.Size(794, 62);
            this.lstTest.TabIndex = 100;
            this.lstTest.UseCompatibleStateImageBehavior = false;
            this.lstTest.View = System.Windows.Forms.View.List;
            this.lstTest.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstTest_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 100;
            // 
            // gbxSample
            // 
            this.gbxSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSample.Location = new System.Drawing.Point(8, 156);
            this.gbxSample.Name = "gbxSample";
            this.gbxSample.Size = new System.Drawing.Size(800, 200);
            this.gbxSample.TabIndex = 101;
            this.gbxSample.TabStop = false;
            this.gbxSample.Text = "Patient protocol as number of blood samples drawn for tests in a given month";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstTest);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 84);
            this.groupBox2.TabIndex = 102;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select tests to include";
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(645, 14);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 33);
            this.butOk.TabIndex = 103;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(730, 14);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 33);
            this.butCancel.TabIndex = 104;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // FrmPanel
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(823, 366);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxSample);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpanelName);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(829, 390);
            this.MinimizeBox = false;
            this.Name = "FrmPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protocol Panel";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //  private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpanelName;
        private System.Windows.Forms.ListView lstTest;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox gbxSample;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
    }
}
