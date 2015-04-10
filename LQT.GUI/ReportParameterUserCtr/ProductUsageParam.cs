
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
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
    public partial class ProductUsageParam : RptBaseUserControl
    {
        public ProductUsageParam()
        {
            InitializeComponent();
           
            PopProductType();
            PopTestingAreas();
        }

        private void PopProductType()
        {
            IList ProductTypeList = DataRepository.GetAllProductType().ToList();
            ReportRepository.AddItem(ProductTypeList, typeof(ProductType), "Id", "TypeName", "< Select Option >");
            comCategory.DataSource = ProductTypeList;
        }

       

        private void PopTestingAreas()
        {
            IList TestingAreaList = DataRepository.GetAllTestingArea().ToList();
            ReportRepository.AddItem(TestingAreaList, typeof(TestingArea), "Id", "AreaName", "< Select Option >");
            comTestarea.DataSource = TestingAreaList;
        }

        private void btnViewreport_Click(object sender, EventArgs e)
        {
           
            int producttype = 0;
            int testingarea = 0;


            if (comTestarea.SelectedValue.ToString() != "-1")
                testingarea = int.Parse(comTestarea.SelectedValue.ToString());

            if (comCategory.SelectedValue.ToString() != "-1")
                producttype = int.Parse(comCategory.SelectedValue.ToString());


            SqlParameter rpproducttype = new SqlParameter();
            rpproducttype.ParameterName = "producttype";
            rpproducttype.Value = producttype;

            SqlParameter rptestingarea = new SqlParameter();
            rptestingarea.ParameterName = "testingarea";
            rptestingarea.Value = testingarea;

           

            sqlParams.Clear();
            
            sqlParams.Add(rpproducttype);
            sqlParams.Add(rptestingarea);

            DataSet _rDataSet = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spProductUsageList");

            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptProductUsageList)));

            FrmReportViewer frmRV = new FrmReportViewer(filinfo, _rDataSet, param);
            frmRV.Dock = DockStyle.Fill;
            frmRV.ShowDialog();
        }

       
    }
}
