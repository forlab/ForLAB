
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
using LQT.Core.Domain;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using LQT.Core;
using LQT.GUI.Reports;

namespace LQT.GUI.ReportParameterUserCtr
{
    public partial class SiteListParam : RptBaseUserControl
    {
        public SiteListParam()
        {
            InitializeComponent();
            PopRegion();
            PopSiteCategory();
            dtpdate.Format = DateTimePickerFormat.Custom;
            dtpdate.CustomFormat = "MMMM , yyyy";
        }

        private void PopRegion()
        {
            IList RegionList=DataRepository.GetAllRegion().ToList();
            ReportRepository.AddItem(RegionList, typeof(ForlabRegion), "Id", "RegionName", "< Select Option >");
            comRegion.DataSource = RegionList;
           
            
        }

        private void PopSiteCategory()
        {
            IList SiteCatList = DataRepository.GetListOfAllSiteCategory().ToList();
            ReportRepository.AddItem(SiteCatList, typeof(SiteCategory), "Id", "CategoryName", "< Select Option >");
            comCategory.DataSource = SiteCatList;
        }

        private void btnViewreport_Click(object sender, EventArgs e)
        {
            int region = 0;
            int category = 0;

           
            if (comRegion.SelectedValue.ToString() != "-1")
                region = int.Parse(comRegion.SelectedValue.ToString());
            if (comCategory.SelectedValue.ToString() != "-1")
                category = int.Parse(comCategory.SelectedValue.ToString());
           

            SqlParameter rpregion = new SqlParameter();
            rpregion.ParameterName = "region";
            rpregion.Value = region;

            SqlParameter rpcategory = new SqlParameter();
            rpcategory.ParameterName = "category";
            rpcategory.Value = category;

            sqlParams.Clear();
            sqlParams.Add(rpregion);
            sqlParams.Add(rpcategory);

            DataSet _rDataSet = ReportRepository.GetDataSet(sqlConnection, sqlParams,"spSiteList");
            if (chkworkingday.Checked)
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptSitewithworkingdays)));
            else
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptSite)));

            FrmReportViewer frmRV = new FrmReportViewer(filinfo, _rDataSet, param);
            frmRV.Dock = DockStyle.Fill;
            frmRV.ShowDialog();
        }

        private void comstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comstatus.Text == "Open" || comstatus.Text == "Close")
            {
                lbldate.Visible = true;
                dtpdate.Visible = true;
            }
            else
            {
                lbldate.Visible = false;
                dtpdate.Visible = false;
            }
        }
    }
}
