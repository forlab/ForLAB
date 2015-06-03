
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
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI
{
    public partial class FrmSelectSheet : Form
    {
        public string SelectedSheet { get { return lvSheetAll.SelectedItems[0].Text; } }

        public FrmSelectSheet(List<string> sheetNames)
        {
            InitializeComponent();

            lvSheetAll.Items.Clear();

            foreach (string sheetName in sheetNames)
                lvSheetAll.Items.Add(sheetName);
        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lvSheetAll_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lvSheetAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            butSelect.Enabled = (lvSheetAll.SelectedItems.Count > 0);
        }
    }
}
