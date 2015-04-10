
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

namespace LQT.GUI.MorbidityUserCtr
{
    partial class OptPreTreatmentPatientTargets
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbAllsite = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.chbSelectsite = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbSitegrowth = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.chbNationaltarget = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbTestingeff = new LQT.GUI.MorbidityUserCtr.LQTCheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 40);
            this.label3.TabIndex = 19;
            this.label3.Text = "4-Enter specific Pre-Treatment targets \r\n    for each site";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label3, "This option is recommended when specific data is available for all sites");
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 40);
            this.label4.TabIndex = 18;
            this.label4.Text = "3-Enter National Pre-Treatment Targets\r\n    But enter specific targets for some s" +
                "ites";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label4, "Thes options are recommended when data is available for some sites\r\nor when new s" +
                    "ites may see faster growth than mature sites");
            // 
            // chbAllsite
            // 
            this.chbAllsite.BackColor = System.Drawing.Color.Transparent;
            this.chbAllsite.Checked = false;
            this.chbAllsite.Location = new System.Drawing.Point(95, 239);
            this.chbAllsite.Margin = new System.Windows.Forms.Padding(0);
            this.chbAllsite.Name = "chbAllsite";
            this.chbAllsite.Size = new System.Drawing.Size(33, 33);
            this.chbAllsite.TabIndex = 17;
            this.chbAllsite.Tag = "4";
            this.toolTip1.SetToolTip(this.chbAllsite, "This option is recommended when specific data is available for all sites");
            // 
            // chbSelectsite
            // 
            this.chbSelectsite.BackColor = System.Drawing.Color.Transparent;
            this.chbSelectsite.Checked = false;
            this.chbSelectsite.Location = new System.Drawing.Point(95, 186);
            this.chbSelectsite.Margin = new System.Windows.Forms.Padding(0);
            this.chbSelectsite.Name = "chbSelectsite";
            this.chbSelectsite.Size = new System.Drawing.Size(33, 33);
            this.chbSelectsite.TabIndex = 16;
            this.chbSelectsite.Tag = "3";
            this.toolTip1.SetToolTip(this.chbSelectsite, "Thes options are recommended when data is available for some sites\r\nor when new s" +
                    "ites may see faster growth than mature sites");
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 40);
            this.label2.TabIndex = 15;
            this.label2.Text = "2-Enter National Pre-Treatment Targets\r\n    But grow some sites at a different ra" +
                "te";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label2, "Thes options are recommended when data is available for some sites\r\nor when new s" +
                    "ites may see faster growth than mature sites");
            // 
            // chbSitegrowth
            // 
            this.chbSitegrowth.BackColor = System.Drawing.Color.Transparent;
            this.chbSitegrowth.Checked = false;
            this.chbSitegrowth.Location = new System.Drawing.Point(96, 133);
            this.chbSitegrowth.Margin = new System.Windows.Forms.Padding(0);
            this.chbSitegrowth.Name = "chbSitegrowth";
            this.chbSitegrowth.Size = new System.Drawing.Size(33, 33);
            this.chbSitegrowth.TabIndex = 13;
            this.chbSitegrowth.Tag = "2";
            this.toolTip1.SetToolTip(this.chbSitegrowth, "Thes options are recommended when data is available for some sites\r\nor when new s" +
                    "ites may see faster growth than mature sites");
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 40);
            this.label1.TabIndex = 14;
            this.label1.Text = "1-Enter National Pre-Treatment Targets\r\n";
            this.toolTip1.SetToolTip(this.label1, "This option is recommended when no site-level data is available");
            // 
            // chbNationaltarget
            // 
            this.chbNationaltarget.BackColor = System.Drawing.Color.Transparent;
            this.chbNationaltarget.Checked = false;
            this.chbNationaltarget.Location = new System.Drawing.Point(96, 78);
            this.chbNationaltarget.Margin = new System.Windows.Forms.Padding(0);
            this.chbNationaltarget.Name = "chbNationaltarget";
            this.chbNationaltarget.Size = new System.Drawing.Size(33, 33);
            this.chbNationaltarget.TabIndex = 12;
            this.chbNationaltarget.Tag = "1";
            this.toolTip1.SetToolTip(this.chbNationaltarget, "This option is recommended when no site-level data is available");
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 40);
            this.label5.TabIndex = 21;
            this.label5.Text = "5-No Pre-Treatment Targets are available.\r\n    Use Testing Efficiency to estimate" +
                "";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbTestingeff
            // 
            this.chbTestingeff.BackColor = System.Drawing.Color.Transparent;
            this.chbTestingeff.Checked = false;
            this.chbTestingeff.Location = new System.Drawing.Point(95, 296);
            this.chbTestingeff.Margin = new System.Windows.Forms.Padding(0);
            this.chbTestingeff.Name = "chbTestingeff";
            this.chbTestingeff.Size = new System.Drawing.Size(33, 33);
            this.chbTestingeff.TabIndex = 20;
            this.chbTestingeff.Tag = "5";
            this.toolTip1.SetToolTip(this.chbTestingeff, "This option is recommended when specific data is available for all sites");
            // 
            // OptPreTreatmentPatientTargets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chbTestingeff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbAllsite);
            this.Controls.Add(this.chbSelectsite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbSitegrowth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbNationaltarget);
            this.Name = "OptPreTreatmentPatientTargets";
            this.Size = new System.Drawing.Size(554, 410);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private LQTCheckBox chbAllsite;
        private LQTCheckBox chbSelectsite;
        private System.Windows.Forms.Label label2;
        private LQTCheckBox chbSitegrowth;
        private System.Windows.Forms.Label label1;
        private LQTCheckBox chbNationaltarget;
        private System.Windows.Forms.Label label5;
        private LQTCheckBox chbTestingeff;
    }
}
