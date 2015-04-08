using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Reflection;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.GUI.Quantification;
using LQT.Core.Reports;


namespace LQT.GUI.MorbidityUserCtr
{
    public partial class Assumptions : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        
        private int _activeMenuId = 1;
        private string TempFile = Path.GetTempFileName();

        public Assumptions(MorbidityForecast forecast)
        {
            this._forecast = forecast;

            InitializeComponent();

            BindHeader();
            LoadPatientAssumptionReport(_activeMenuId);
        }

        public override string Title
        {
            get { return "Forecast Result Key Assumptions"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.InvAssumption;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.Nothing;
            }
        }

        public override bool EnableNextButton()
        {
            return false;
        }

        public override string Description
        {
            get
            {
                string desc = "Results Calculate the supplies needed for the entire national quantification <br>";
                desc += "The Laboratory Quantification Model is designed to use the data inputs to calculate how many tests will ";
                desc += "be performed at each site and how many testing supplies are required at each site, one site at a time. ";
                desc += "It then aggregates the results from each site, and produces outputs to be viewed by the user.";
                return desc;
            }
        }

        private void SetBackColorOfMenus(int selectedKey)
        {
            foreach (Control c in panMenus.Controls)
            {
                if (c is LinkLabel)
                {
                    LinkLabel l = (LinkLabel)c;
                    if (Convert.ToInt32(l.Tag) == selectedKey)
                    {
                        l.BackColor = Color.Blue;
                    }
                    else
                    {
                        l.BackColor = Color.SteelBlue;
                    }
                }
            }
        }

        private void Menu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel l = (LinkLabel)sender;
            int selectedId = Convert.ToInt32(l.Tag);

            if (_activeMenuId != selectedId)
            {
                SetBackColorOfMenus(selectedId);
                _activeMenuId = selectedId;
                LoadPatientAssumptionReport(_activeMenuId);
            }
        }

        private void BindHeader()
        {
            int endyear = _forecast.SatartDate.Year;
            if (_forecast.StartBudgetPeriod >= _forecast.EndBudgetPeriod)
                endyear = endyear + 1;
            else if (((_forecast.StartBudgetPeriod + _forecast.EndBudgetPeriod) - 1) > 12)
                endyear = _forecast.SatartDate.Year + 1;

            lblDate.Text = String.Format("{0} {1} to {2} {3}", _forecast.StartBudgetPeriodEnum, _forecast.SatartDate.Year, _forecast.EndBudgetPeriodEnum, endyear);
            lblTitle.Text = _forecast.Title + ", created on " + _forecast.DateOfQuantification.ToShortDateString();

            IList result = DataRepository.GetSummaryOfTotalCost(_forecast.Id);
            double total = 0;
            foreach (object[] o in result)
            {
                total += Convert.ToDouble(o[1]);
            }
            lblTotal.Text = "$" + total.ToString();
        }

        private void LoadPatientAssumptionReport(int reportId)
        {
            string html = (new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("LQT.GUI.RptAssumption.htm"))).ReadToEnd();

            string detail = "";
            if(reportId == 1)
                detail = RptMorbidityReportFactory.GeneratePatientAssumption(_forecast);
            else if(reportId == 2)
                detail = RptMorbidityReportFactory.GenerateCD4Assumption(_forecast);
            else if (reportId == 3)
                detail = RptMorbidityReportFactory.GenerateChemistryAssumption(_forecast);
            else if (reportId == 4)
                detail = RptMorbidityReportFactory.GenerateHematologyAssumption(_forecast);
            else if (reportId == 5)
                detail = RptMorbidityReportFactory.GenerateViralLoadAssumption(_forecast);
            else if (reportId == 6)
                detail = RptMorbidityReportFactory.GenerateOtherTestAssumption(_forecast);
            else if (reportId == 7)
                detail = RptMorbidityReportFactory.GenerateRapidTestAssumption(_forecast);

            html = html.Replace("{detail}", detail);
            File.WriteAllText(TempFile, html);

            webBrowser1.Navigate(TempFile);
            webBrowser1.Refresh();
        }
        
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            File.Delete(TempFile);
        }

       
    }
}
