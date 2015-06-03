
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
