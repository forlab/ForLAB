
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
