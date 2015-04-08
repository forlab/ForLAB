
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

namespace LQT.GUI.Quantification
{
    partial class ServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceForm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.butSave = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comslowmovingperiod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboscope = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtplastmodifieddate = new System.Windows.Forms.DateTimePicker();
            this.dtpstart = new LQT.GUI.DurationPicker();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comPeriod = new System.Windows.Forms.ComboBox();
            this.dtpForecastDate = new System.Windows.Forms.DateTimePicker();
            this.txtScope = new System.Windows.Forms.TextBox();
            this.txtForecastNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.grbDatausage = new System.Windows.Forms.GroupBox();
            this.rdbUsage3 = new System.Windows.Forms.RadioButton();
            this.rdbUsage2 = new System.Windows.Forms.RadioButton();
            this.rdbUsage1 = new System.Windows.Forms.RadioButton();
            this.txtDatausage = new System.Windows.Forms.TextBox();
            this.tabConsumption = new System.Windows.Forms.TabPage();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbDatausage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.butSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(856, 30);
            this.panel4.TabIndex = 1;
            // 
            // butSave
            // 
            this.butSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSave.Location = new System.Drawing.Point(722, 0);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(132, 28);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Save Forecast Info";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 33);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(856, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabConsumption);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 36);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(856, 510);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBox4);
            this.tabGeneral.Controls.Add(this.groupBox1);
            this.tabGeneral.Controls.Add(this.splitter2);
            this.tabGeneral.Controls.Add(this.grbDatausage);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(848, 484);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Tag = "GENERAL";
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(463, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(382, 363);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Service Statistics Forecasting Methodology";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(20, 24);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(345, 296);
            this.textBox8.TabIndex = 3;
            this.textBox8.Text = resources.GetString("textBox8.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comslowmovingperiod);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboscope);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtplastmodifieddate);
            this.groupBox1.Controls.Add(this.dtpstart);
            this.groupBox1.Controls.Add(this.txtExtension);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comPeriod);
            this.groupBox1.Controls.Add(this.dtpForecastDate);
            this.groupBox1.Controls.Add(this.txtScope);
            this.groupBox1.Controls.Add(this.txtForecastNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 363);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forecast Infromation";
            // 
            // comslowmovingperiod
            // 
            this.comslowmovingperiod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comslowmovingperiod.FormattingEnabled = true;
            this.comslowmovingperiod.Location = new System.Drawing.Point(143, 289);
            this.comslowmovingperiod.Name = "comslowmovingperiod";
            this.comslowmovingperiod.Size = new System.Drawing.Size(227, 21);
            this.comslowmovingperiod.TabIndex = 21;
            this.comslowmovingperiod.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(235, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Reporting Period For Slow Moving Tests";
            this.label8.Visible = false;
            // 
            // cboscope
            // 
            this.cboscope.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboscope.FormattingEnabled = true;
            this.cboscope.Items.AddRange(new object[] {
            "CUSTOM",
            "NATIONAL",
            "GLOBAL"});
            this.cboscope.Location = new System.Drawing.Point(143, 65);
            this.cboscope.Name = "cboscope";
            this.cboscope.Size = new System.Drawing.Size(121, 21);
            this.cboscope.TabIndex = 18;
            this.cboscope.SelectedIndexChanged += new System.EventHandler(this.cboscope_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Last Modified Date:";
            // 
            // dtplastmodifieddate
            // 
            this.dtplastmodifieddate.Enabled = false;
            this.dtplastmodifieddate.Location = new System.Drawing.Point(143, 243);
            this.dtplastmodifieddate.Name = "dtplastmodifieddate";
            this.dtplastmodifieddate.Size = new System.Drawing.Size(230, 20);
            this.dtplastmodifieddate.TabIndex = 16;
            // 
            // dtpstart
            // 
            this.dtpstart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpstart.Location = new System.Drawing.Point(143, 130);
            this.dtpstart.Margin = new System.Windows.Forms.Padding(0);
            this.dtpstart.Name = "dtpstart";
            this.dtpstart.Size = new System.Drawing.Size(230, 24);
            this.dtpstart.TabIndex = 14;
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(143, 170);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(100, 20);
            this.txtExtension.TabIndex = 12;
            this.txtExtension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExtension_KeyPress_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Reporting Period:";
            // 
            // comPeriod
            // 
            this.comPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPeriod.FormattingEnabled = true;
            this.comPeriod.Location = new System.Drawing.Point(143, 95);
            this.comPeriod.Name = "comPeriod";
            this.comPeriod.Size = new System.Drawing.Size(230, 21);
            this.comPeriod.TabIndex = 10;
            this.comPeriod.SelectedIndexChanged += new System.EventHandler(this.comPeriod_SelectedIndexChanged);
            // 
            // dtpForecastDate
            // 
            this.dtpForecastDate.Enabled = false;
            this.dtpForecastDate.Location = new System.Drawing.Point(143, 207);
            this.dtpForecastDate.Name = "dtpForecastDate";
            this.dtpForecastDate.Size = new System.Drawing.Size(230, 20);
            this.dtpForecastDate.TabIndex = 7;
            // 
            // txtScope
            // 
            this.txtScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScope.Location = new System.Drawing.Point(273, 66);
            this.txtScope.Name = "txtScope";
            this.txtScope.Size = new System.Drawing.Size(100, 20);
            this.txtScope.TabIndex = 6;
            this.txtScope.Visible = false;
            // 
            // txtForecastNo
            // 
            this.txtForecastNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtForecastNo.Location = new System.Drawing.Point(143, 27);
            this.txtForecastNo.Name = "txtForecastNo";
            this.txtForecastNo.Size = new System.Drawing.Size(230, 20);
            this.txtForecastNo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Forecasting Period:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forecast Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scope of the Forecast:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forecast ID:";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Window;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Enabled = false;
            this.splitter2.Location = new System.Drawing.Point(3, 366);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(842, 3);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // grbDatausage
            // 
            this.grbDatausage.Controls.Add(this.rdbUsage3);
            this.grbDatausage.Controls.Add(this.rdbUsage2);
            this.grbDatausage.Controls.Add(this.rdbUsage1);
            this.grbDatausage.Controls.Add(this.txtDatausage);
            this.grbDatausage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbDatausage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDatausage.Location = new System.Drawing.Point(3, 369);
            this.grbDatausage.Name = "grbDatausage";
            this.grbDatausage.Size = new System.Drawing.Size(842, 112);
            this.grbDatausage.TabIndex = 1;
            this.grbDatausage.TabStop = false;
            this.grbDatausage.Text = "Service Statistics Data Usage";
            // 
            // rdbUsage3
            // 
            this.rdbUsage3.AutoSize = true;
            this.rdbUsage3.Location = new System.Drawing.Point(15, 73);
            this.rdbUsage3.Name = "rdbUsage3";
            this.rdbUsage3.Size = new System.Drawing.Size(248, 17);
            this.rdbUsage3.TabIndex = 12;
            this.rdbUsage3.Text = "Service data available for site category";
            this.rdbUsage3.UseVisualStyleBackColor = true;
            this.rdbUsage3.CheckedChanged += new System.EventHandler(this.rdbUsage3_CheckedChanged);
            // 
            // rdbUsage2
            // 
            this.rdbUsage2.AutoSize = true;
            this.rdbUsage2.Location = new System.Drawing.Point(15, 50);
            this.rdbUsage2.Name = "rdbUsage2";
            this.rdbUsage2.Size = new System.Drawing.Size(252, 17);
            this.rdbUsage2.TabIndex = 11;
            this.rdbUsage2.Text = "Service data available for reported sites";
            this.rdbUsage2.UseVisualStyleBackColor = true;
            this.rdbUsage2.CheckedChanged += new System.EventHandler(this.rdbUsage2_CheckedChanged);
            // 
            // rdbUsage1
            // 
            this.rdbUsage1.AutoSize = true;
            this.rdbUsage1.Checked = true;
            this.rdbUsage1.Location = new System.Drawing.Point(15, 27);
            this.rdbUsage1.Name = "rdbUsage1";
            this.rdbUsage1.Size = new System.Drawing.Size(218, 17);
            this.rdbUsage1.TabIndex = 10;
            this.rdbUsage1.TabStop = true;
            this.rdbUsage1.Text = "Service data available for all sites";
            this.rdbUsage1.UseVisualStyleBackColor = true;
            this.rdbUsage1.CheckedChanged += new System.EventHandler(this.rdbUsage1_CheckedChanged);
            // 
            // txtDatausage
            // 
            this.txtDatausage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDatausage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatausage.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatausage.ForeColor = System.Drawing.Color.Navy;
            this.txtDatausage.Location = new System.Drawing.Point(307, 22);
            this.txtDatausage.Multiline = true;
            this.txtDatausage.Name = "txtDatausage";
            this.txtDatausage.ReadOnly = true;
            this.txtDatausage.Size = new System.Drawing.Size(517, 68);
            this.txtDatausage.TabIndex = 9;
            // 
            // tabConsumption
            // 
            this.tabConsumption.Location = new System.Drawing.Point(4, 22);
            this.tabConsumption.Name = "tabConsumption";
            this.tabConsumption.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsumption.Size = new System.Drawing.Size(848, 484);
            this.tabConsumption.TabIndex = 1;
            this.tabConsumption.Tag = "CONSUMPTION";
            this.tabConsumption.Text = "Service Statistics";
            this.tabConsumption.UseVisualStyleBackColor = true;
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 549);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ServiceForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quantification Process";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsumptionForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConsumptionForm_FormClosed);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDatausage.ResumeLayout(false);
            this.grbDatausage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox grbDatausage;
        private System.Windows.Forms.RadioButton rdbUsage3;
        private System.Windows.Forms.RadioButton rdbUsage2;
        private System.Windows.Forms.RadioButton rdbUsage1;
        private System.Windows.Forms.TextBox txtDatausage;
        private System.Windows.Forms.TabPage tabConsumption;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comPeriod;
        private System.Windows.Forms.DateTimePicker dtpForecastDate;
        private System.Windows.Forms.TextBox txtScope;
        private System.Windows.Forms.TextBox txtForecastNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter2;
        private DurationPicker dtpstart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtplastmodifieddate;
        private System.Windows.Forms.ComboBox cboscope;
        private System.Windows.Forms.ComboBox comslowmovingperiod;
        private System.Windows.Forms.Label label8;
    }
}
