
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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Util;
using LQT.Core;
using System.IO;
using LQT.GUI.Reports;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace LQT.GUI.ReportParameterUserCtr
{
    public partial class RegionListParam : RptBaseUserControl
    {
        public RegionListParam()
        {
            InitializeComponent();
        }

        private void chknoofsite_CheckedChanged(object sender, EventArgs e)
        {
            if (chknoofsite.Checked)
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }

        private void btnviewreport_Click(object sender, EventArgs e)
        {
            int noofsite = 0;
            string logic = string.Empty;

            if (chknoofsite.Checked)
            {
                if (txtnoofsite.Text != string.Empty)
                    noofsite = int.Parse(txtnoofsite.Text);
                if (comlogic.Text != string.Empty)
                    logic = comlogic.Text;
            }

            SqlParameter rpNoofsite = new SqlParameter();
            rpNoofsite.ParameterName = "noofsite";
            rpNoofsite.Value = noofsite;

            SqlParameter rplogic = new SqlParameter();
            rplogic.ParameterName = "logic";
            rplogic.Value = logic;

            sqlParams.Clear();
            sqlParams.Add(rpNoofsite);
            sqlParams.Add(rplogic);

            DataSet _rDataSet=ReportRepository.GetDataSet(sqlConnection,sqlParams,"spRegionList");
            if(chknoofsite.Checked)
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptRegionWithSiteCount)));
            else
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptRegion)));

            FrmReportViewer frmRV = new FrmReportViewer(filinfo, _rDataSet, param);
            frmRV.Dock = DockStyle.Fill;
            frmRV.ShowDialog();
        }
    }
}
