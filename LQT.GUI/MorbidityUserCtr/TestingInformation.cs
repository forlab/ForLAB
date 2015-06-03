
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
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class TestingInformation : BaseMorbidityControl
    {
        // private SiteListView _sListView;
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        public TestingInformation(MorbidityForecast forecast, IList<ARTSite> artsites)
        {
            this._forecast = forecast;
            this._artSites = artsites;
            InitializeComponent();

            lstSites.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lstSites_SubitemTextChanged);

            BindForecast();
            BindArtSites();
        }

        private void lstSites_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            ARTSite site = (ARTSite)li.Tag;
            double Num;//b
            bool isNum = double.TryParse(li.SubItems[e.ColumnIndex].Text, out Num);//b
            if (isNum)//b
            {
                double newvalue = double.Parse(li.SubItems[e.ColumnIndex].Text);


                if (e.ColumnIndex == 2)
                {
                    site.AdultTestingPopulation = newvalue;
                }
                else if (e.ColumnIndex == 3)
                {
                    site.PediatricTestingPopulation = newvalue;
                }
                else if (e.ColumnIndex == 4)
                {
                    site.AdultDepartWoutFollowup = newvalue;
                }
                else if (e.ColumnIndex == 5)
                {
                    site.PediatricDepartWoutFollowup = newvalue;
                }
                else if (e.ColumnIndex == 6)
                {
                    site.DiagnosesReceiveCD4 = newvalue;
                }
                _edited = true;
            }
        }

        private void TEtextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null)
                return;

            double newvalue;
            int tag = Convert.ToInt32(txt.Tag);

            if (double.TryParse(txt.Text, out newvalue))
            {
                if (tag == 0)
                    _forecast.AdultTestingPopulation = newvalue;
                else if (tag == 1)
                    _forecast.PediatricTestingPopulation = newvalue;
                else if (tag == 2)
                    _forecast.AdultDepartWoutFollowup = newvalue;
                else if (tag == 3)
                    _forecast.PediatricDepartWoutFollowup = newvalue;
                else if (tag == 4)
                    _forecast.DiagnosesReceiveCD4 = newvalue;
                _edited = true;
            }
        }
        public override string Title
        {
            get { return "Testing Information"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.PatientNumbersSites;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.AdultPatientBehavior;
            }
        }

        public override bool EnableNextButton()
        {
            return true;
        }

        public override string Description
        {
            get
            {
                string desc = "Input statistics relating to HIV prevalence and patient testing trends";
                desc += "<br>% Adult HIV+ <br> For each site, input the percentage of adults tested for HIV that receive a positive test result.";
                desc += "<br>% Pediatric HIV+ <br> For each site, input the percentage of children tested for HIV ";
                desc += "that receive a positive test result.";
                desc += "<br>% Pediatric Loss-To-Follow-Up <br> For each site, input the percentage of children with positive HIV test ";
                desc += "results that fail to follow up for care after diagnosis. ";
                desc += "<br>% HIV+ CD4 Testing <br> For each site, input the percentage of HIV-positive follow-up patients who ";
                desc += "are administered a CD4 test to screen for eligibility for treatment initiation. In many cases, this will be 100%.</br>";

                desc += "<div style=\"font-size: 10px; font-style: italic; color: #008000; border-style: solid; border-width: 1px\"> <b>Keys</b><ul>";
                desc += "<li>[A.T.P]&nbsp;: % Adult Testing Population HIV Positive</li>";
                desc += "<li>[P.T.P]&nbsp;: % Pediatric Testing Population HIV Positive</li>";
                desc += "<li>[A.D.D.W.F]&nbsp;: % of HIV+ Adult diagnoses to depart w/out follow-up</li>";
                desc += "<li>[P.D.D.W.F]&nbsp;: % of HIV+ Pediatric diagnoses to depart w/out follow-up</li>";
                desc += "<li>[D.T.F.W.R]&nbsp;: % of HIV+ Diagnoses That Follow Up Which Receive CD4</li></ul></div>";
                return desc;
            }
        }

        private void BindForecast()
        {
            txtAtp.Text = _forecast.AdultTestingPopulation.ToString();
            txtPtp.Text = _forecast.PediatricTestingPopulation.ToString();
            txtAddwf.Text = _forecast.AdultDepartWoutFollowup.ToString();
            txtPddwf.Text = _forecast.PediatricDepartWoutFollowup.ToString();
            txtDtfwr.Text = _forecast.DiagnosesReceiveCD4.ToString();
        }

        private void BindArtSites()
        {
            lstSites.Items.Clear();
            lstSites.BeginUpdate();

            foreach (ARTSite site in _artSites)
            {
                ListViewItem li = new ListViewItem(site.MorbidityCategory.CategoryName) { Tag = site };
                li.UseItemStyleForSubItems = false;

                li.SubItems.Add(site.Site.SiteName);
                li.SubItems.Add(site.AdultTestingPopulation.ToString(), Color.Black, Color.PeachPuff, lstSites.Font);
                li.SubItems.Add(site.PediatricTestingPopulation.ToString(), Color.Black, Color.BurlyWood, lstSites.Font);
                li.SubItems.Add(site.AdultDepartWoutFollowup.ToString(), Color.Black, Color.LightSalmon, lstSites.Font);
                li.SubItems.Add(site.PediatricDepartWoutFollowup.ToString(), Color.Black, Color.Tan, lstSites.Font);
                li.SubItems.Add(site.DiagnosesReceiveCD4.ToString(), Color.Black, Color.NavajoWhite, lstSites.Font);

                lstSites.Items.Add(li);
            }

            lstSites.EndUpdate();
        }

        private void butApplyall_Click(object sender, EventArgs e)
        {
            foreach (ARTSite site in _artSites)
            {
                site.AdultTestingPopulation = _forecast.AdultTestingPopulation;
                site.PediatricTestingPopulation = _forecast.PediatricTestingPopulation;
                site.AdultDepartWoutFollowup = _forecast.AdultDepartWoutFollowup;
                site.PediatricDepartWoutFollowup = _forecast.PediatricDepartWoutFollowup;
                site.DiagnosesReceiveCD4 = _forecast.DiagnosesReceiveCD4;
            }

            BindArtSites();
            _edited = true;
        }

        public override bool DoSomthingBeforeUnload()
        {
            if (_edited)
            {
                DataRepository.BatchSaveARTSite(_artSites);
                DataRepository.SaveOrUpdateMorbidityForecast(_forecast);
                MorbidityForm.ReInitMorbidityFrm();
            }
            return true;
        }
    }
}
