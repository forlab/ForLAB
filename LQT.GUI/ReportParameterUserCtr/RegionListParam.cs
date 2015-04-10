
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
