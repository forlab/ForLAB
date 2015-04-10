
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
using Microsoft.Reporting.WinForms;

namespace LQT.GUI.ReportParameterUserCtr
{
    public partial class MorbidityNoofTestReportParam : LQT.GUI.ReportParameterUserCtr.RptBaseUserControl
    {
        public MorbidityNoofTestReportParam()
        {
            InitializeComponent();
            PopForecastInfo();
        }

        private void PopForecastInfo()
        {
         
            IList demographyForecastInfo = DataRepository.GetAllMorbidityForecast().ToList();
            ReportRepository.AddItem(demographyForecastInfo, typeof(MorbidityForecast), "Id", "Title", "< Select Option >");
            cobdemography.DataSource = demographyForecastInfo;

           
        }

        public override string GetControlTitle
        {
            get
            {
                return "Morbidity Forecast No. of Test Summary Report";
            }
        }

        private void btnviewreport_Click(object sender, EventArgs e)
        {

           
            int DforecastId = 0;

          
            if (cobdemography.SelectedValue.ToString() != "-1")
                DforecastId = int.Parse(cobdemography.SelectedValue.ToString());


            ReportParameter pDForecastId = new ReportParameter("ForecastId", DforecastId.ToString());

          
            param.Add(pDForecastId);
            

            SqlParameter rpMForecastId = new SqlParameter();
            rpMForecastId.ParameterName = "ForecastId";
            rpMForecastId.Value = DforecastId;

            sqlParams.Clear();
            sqlParams.Add(rpMForecastId);


            DataSet _rDataSet = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spCD4TestNumberForecast");


            SqlParameter rpMForecastId1 = new SqlParameter();
            rpMForecastId1.ParameterName = "ForecastId";
            rpMForecastId1.Value = DforecastId;
            sqlParams.Clear();
            sqlParams.Add(rpMForecastId1);
            DataSet _rDataSet1 = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spHIVRapidTestNumberForecast");


            SqlParameter rpMForecastId2 = new SqlParameter();
            rpMForecastId2.ParameterName = "ForecastId";
            rpMForecastId2.Value = DforecastId;
            sqlParams.Clear();
            sqlParams.Add(rpMForecastId2);
            DataSet _rDataSet2 = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spChemandOtherNumberofTestforecast");



            SqlParameter rpMForecastId3 = new SqlParameter();
            rpMForecastId3.ParameterName = "ForecastId";
            rpMForecastId3.Value = DforecastId;
            sqlParams.Clear();
            sqlParams.Add(rpMForecastId3);
            DataSet _rDataSet3 = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spHemaandViralNumberofTest");

            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.Forecastresulttestbyregion)));

            FrmReportViewer frmRV = new FrmReportViewer(filinfo, _rDataSet, _rDataSet1, _rDataSet2, _rDataSet3, param);
            frmRV.Dock = DockStyle.Fill;
            frmRV.ShowDialog();
        }

        
    }
}
