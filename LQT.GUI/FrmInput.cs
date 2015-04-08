
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
