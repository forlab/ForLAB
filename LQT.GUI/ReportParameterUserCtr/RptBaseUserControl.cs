
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
using System.Drawing;
using System.Windows.Forms;

using LQT.Core.Util;
using System.IO;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace LQT.GUI.ReportParameterUserCtr
{
    public partial class RptBaseUserControl :System.Windows.Forms.UserControl
    {
        public FileInfo filinfo = null;
        private LqtMainWindowForm _mdiparent;
        public SqlConnection sqlConnection=ConnectionManager.GetInstance().GetSqlConnection();
        public List<ReportParameter> param = new List<ReportParameter>();
        public List<SqlParameter> sqlParams = new List<SqlParameter>();
        private int _DefaultReportId = 0;

        public RptBaseUserControl()
        {
            InitializeComponent();
        }
                
        public LqtMainWindowForm MdiParentForm
        {
            get { return _mdiparent; }
            set { _mdiparent = value; }
        }

        public virtual int DefaultReportId
        {
            get { return _DefaultReportId; }
            set { _DefaultReportId = value; }
        }
                
        public virtual string GetControlTitle
        {
            get { return ""; }
        }

        public void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}
