
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
    public partial class ComparisionReportParam : LQT.GUI.ReportParameterUserCtr.RptBaseUserControl
    {
        public ComparisionReportParam()
        {
            InitializeComponent();
            PopForecastInfo();
        }

        private void PopForecastInfo()
        {

            IList ServiceForecastInfo = DataRepository.GetForecastInfoByMethodology(MethodologyEnum.SERVICE_STATISTIC.ToString()).ToList();
            ReportRepository.AddItem(ServiceForecastInfo, typeof(ForecastInfo), "Id", "ForecastNo", "< Select Option >");
            cobservice.DataSource = ServiceForecastInfo;

            IList ConsumptionForecastInfo = DataRepository.GetForecastInfoByMethodology(MethodologyEnum.CONSUMPTION.ToString()).ToList();
            ReportRepository.AddItem(ConsumptionForecastInfo, typeof(ForecastInfo), "Id", "ForecastNo", "< Select Option >");
            cobconsumption.DataSource = ConsumptionForecastInfo;

            IList demographyForecastInfo = DataRepository.GetAllMorbidityForecast().ToList();
            ReportRepository.AddItem(demographyForecastInfo, typeof(MorbidityForecast), "Id", "Title", "< Select Option >");
            cobdemography.DataSource = demographyForecastInfo;

           
        }

        public override string GetControlTitle
        {
            get
            {
                return "Forecast Comparison Report";
            }
        }

        private void btnviewreport_Click(object sender, EventArgs e)
        {

            int SforecastId = -1;
            int CforecastId = -1;
            int DforecastId = -1;

            if (cobservice.SelectedValue.ToString() != "-1")
                SforecastId = int.Parse(cobservice.SelectedValue.ToString());

            if (cobconsumption.SelectedValue.ToString() != "-1")
                CforecastId = int.Parse(cobconsumption.SelectedValue.ToString());

            if (cobdemography.SelectedValue.ToString() != "-1")
                DforecastId = int.Parse(cobdemography.SelectedValue.ToString());

            ReportParameter pSForecastId = new ReportParameter("SForecastId", SforecastId.ToString());
            ReportParameter pCForecastId = new ReportParameter("CForecastId", CforecastId.ToString());
            ReportParameter pDForecastId = new ReportParameter("MForecastId", DforecastId.ToString());

            param.Add(pSForecastId);
            param.Add(pCForecastId);
            param.Add(pDForecastId);
            

            SqlParameter rpMForecastId = new SqlParameter();
            rpMForecastId.ParameterName = "MForecastId";
            rpMForecastId.Value = DforecastId;

            SqlParameter rpSForecastId = new SqlParameter();
            rpSForecastId.ParameterName = "SForecastId";
            rpSForecastId.Value = SforecastId;

            SqlParameter rpCForecastId = new SqlParameter();
            rpCForecastId.ParameterName = "CForecastId";
            rpCForecastId.Value = CforecastId;

            sqlParams.Clear();
            sqlParams.Add(rpMForecastId);
            sqlParams.Add(rpSForecastId);
            sqlParams.Add(rpCForecastId);

            DataSet _rDataSet = ReportRepository.GetDataSet(sqlConnection, sqlParams, "spGetForecastComparision");
            filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.forecastcomparision)));

            FrmReportViewer frmRV = new FrmReportViewer(filinfo, _rDataSet, param);
            frmRV.Dock = DockStyle.Fill;
            frmRV.ShowDialog();
        }

        
    }
}
