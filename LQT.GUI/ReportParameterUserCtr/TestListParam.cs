
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI) 
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
using LQT.Core.Domain;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using LQT.Core;
using LQT.GUI.Reports;

namespace LQT.GUI.ReportParameterUserCtr
{
    public partial class TestListParam : RptBaseUserControl
    {
        public TestListParam()
        {
            InitializeComponent();
           
            PopTestingAreas();
        }

       

        private void PopTestingAreas()
        {
            IList TestingAreaList = DataRepository.GetAllTestingArea().ToList();
            ReportRepository.AddItem(TestingAreaList, typeof(TestingArea), "Id", "AreaName", "< Select Option >");
            comTestarea.DataSource = TestingAreaList;
        }

        private void btnViewreport_Click(object sender, EventArgs e)
        {
            int testingarea = 0;

            if (comTestarea.SelectedValue.ToString() != "-1")
                testingarea = int.Parse(comTestarea.SelectedValue.ToString());

            SqlParameter rptestingarea = new SqlParameter();
            rptestingarea.ParameterName = "testingarea";
            rptestingarea.Value = testingarea;

            sqlParams.Clear();
            sqlParams.Add(rptestingarea);

            DataSet _rDataSet = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spTestList");
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptTestList)));

            FrmReportViewer frmRV = new FrmReportViewer(filinfo, _rDataSet, param);
            frmRV.Dock = DockStyle.Fill;
            frmRV.ShowDialog();
        }

       
    }
}
