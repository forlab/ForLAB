
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

using LQT.Core.UserExceptions;

namespace LQT.GUI
{
    public partial class FrmShowError : Form
    {
        private ExceptionStatus _exStatus;

        public FrmShowError(ExceptionStatus exstatus )
        {
            InitializeComponent();
            _exStatus = exstatus;
        }

        public FrmShowError(string errorMessage)
        {
            InitializeComponent();
            _exStatus = new ExceptionStatus();     
            _exStatus.message = errorMessage;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void butDetail_Click(object sender, EventArgs e)
        {
            if (!(bool)butDetail.Tag)
            {
                Size = new Size(550, 400);
                butDetail.Tag = true;
            }
            else
            {
                Size = new Size(550, 173);
                butDetail.Tag = false;
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShowError_Load(object sender, EventArgs e)
        {
            Size = new Size(550, 173);
            butDetail.Tag = false;
            lblMessage.Text = _exStatus.message;
            rtbDetail.Text  = _exStatus.ex != null ? _exStatus.ex.Message : "";
            rtbDetail.Text += _exStatus.ex != null ? "\n\n" + _exStatus.ex.StackTrace : "";
        }
    }
}
