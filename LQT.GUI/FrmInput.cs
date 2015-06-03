
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LQT.GUI
{
    public partial class FrmInput : Form
    {
        public FrmInput()
        {
            InitializeComponent();
        }

        public FrmInput(string text, string title)
            : this()
        {
            textBox1.Text = text;
            dateTimePicker1.Visible = false;
            lblTitle.Text = title;
        }

        public FrmInput(DateTime date, string title)
            : this()
        {
            dateTimePicker1.Value = date;
            textBox1.Visible = false;
            lblTitle.Text = title;
        }

        public string GetTextValue()
        {
            return textBox1.Text;
        }

        public DateTime GetDateTimeValue()
        {
            return dateTimePicker1.Value;
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
