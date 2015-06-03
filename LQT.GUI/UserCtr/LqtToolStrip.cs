
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LQT.GUI.UserCtr
{
    public partial class LqtToolStrip : UserControl
    {
        public event EventHandler SaveAndCloseClick;
        public event EventHandler SaveAndNewClick;

        public LqtToolStrip()
        {
            InitializeComponent();
        }

        private void tsbSaveandclose_Click(object sender, EventArgs e)
        {
            if (SaveAndCloseClick != null)
            {
                SaveAndCloseClick(sender, e);
            }
        }

        private void tsbSaveandnew_Click(object sender, EventArgs e)
        {
            if (SaveAndNewClick != null)
            {
                SaveAndNewClick(sender, e);
            }
        }

        public void EnableSaveButton()
        {
            this.tsbSaveandclose.Enabled = true;
            this.tsbSaveandnew.Enabled = true;
        }

        public void DisableSaveButton()
        {
            this.tsbSaveandclose.Enabled = false;
            this.tsbSaveandnew.Enabled = false;
        }

        public void DisableSaveAndNewButton()
        {
            this.tsbSaveandnew.Enabled = false;
        }
    }
}
