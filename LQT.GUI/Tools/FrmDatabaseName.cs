
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LQT.GUI.Tools
{
    public partial class FrmDatabaseName : Form
    {
        private bool _badDatabaseName;
        private string _name;
        private bool _includeDefaultData;

        public string Result
        {
            get { return _name; }
        }

        public bool IncludeDefaultData
        {
            get { return _includeDefaultData; }
        }

        public FrmDatabaseName()
        {
            InitializeComponent();
        }

        private void textBoxDatabaseName_TextChanged(object sender, EventArgs e)
        {
            _badDatabaseName = false;
            textBoxDatabaseName.BackColor = Color.White;
            if (string.IsNullOrEmpty(textBoxDatabaseName.Text))
            {
                _badDatabaseName = true;
                textBoxDatabaseName.BackColor = Color.Red;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (_badDatabaseName)
                MessageBox.Show("Error in database name", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _name = textBoxDatabaseName.Text;
                _includeDefaultData = chkDefaultPData.Checked;
                Close();
            }
        }

        private void textBoxDatabaseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave.PerformClick();
            }
        }
    }
}
