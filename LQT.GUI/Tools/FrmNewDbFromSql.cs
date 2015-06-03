
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
using System.Text;
using System.Windows.Forms;

namespace LQT.GUI.Tools
{
    public partial class FrmNewDbFromSql : Form
    {
        private bool _badDatabaseName;
        private string _name;
        private string _filePath;

        public string Result
        {
            get { return _name; }
        }

        public string FilePath
        {
            get { return _filePath; }
        }

        public FrmNewDbFromSql()
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
                _filePath = txtFilePath.Text;
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

        private void butBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
            
        }
    }
}
