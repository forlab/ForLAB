
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
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
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class TestingEfficiency : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        public TestingEfficiency(MorbidityForecast forecast, IList<ARTSite> artsites)
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
                    site.AdultTestingEfficiency = newvalue;
                }
                else if (e.ColumnIndex == 3)
                {
                    site.PediatricTestingEfficiency = newvalue;
                }
                else if (e.ColumnIndex == 4)
                {
                    site.PediatricsPreExistingPatients = newvalue;
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
                    _forecast.AdultTestingEfficiency = newvalue;
                else if (tag == 1)
                    _forecast.PediatricTestingEfficiency = newvalue;
                else if (tag == 2)
                    _forecast.PediatricsPreExistingPatients = newvalue;
                _edited = true;
            }
        }

        public override string Title
        {
            get { return "Testing Efficiency"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.OptPreTreatmentPatientTargets;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.TestingInformation;
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
                string desc = "Testing efficiency is defined as the percentage of HIV-positive patients who qualify for initiating ART ";
                desc +="(either by CD4 count or percentage, or by clinical staging in the absence of CD4 testing). It can be unique ";
                desc +="to a specific country or site, and can be used to estimate how many patients will be receiving pre-treatment ";
                desc +="care assuming a given level of patients receiving treatment. This estimate will also take into consideration ";
                desc +="overall prevalence rates of HIV in the country or sites in question. Although this method can produce a useful ";
                desc += "estimate, it is only recommended if you do not have more substantial data at the site level.";
                return desc;
            }
        }

        private void BindForecast()
        {
            txtAte.Text = _forecast.AdultTestingEfficiency.ToString();
            txtPte.Text = _forecast.PediatricTestingEfficiency.ToString();
            txtPediatric.Text = _forecast.PediatricsPreExistingPatients.ToString();
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
                li.SubItems.Add(site.AdultTestingEfficiency.ToString(), lstSites.ForeColor, Color.SpringGreen, lstSites.Font);
                li.SubItems.Add(site.PediatricTestingEfficiency.ToString(), lstSites.ForeColor, Color.MediumSeaGreen, lstSites.Font);
                li.SubItems.Add(site.PediatricsPreExistingPatients.ToString(), lstSites.ForeColor, Color.MediumAquamarine, lstSites.Font);

                lstSites.Items.Add(li);
            }

            lstSites.EndUpdate();
        }

        private void butApplyall_Click(object sender, EventArgs e)
        {
            foreach (ARTSite site in _artSites)
            {
                site.AdultTestingEfficiency = _forecast.AdultTestingEfficiency;
                site.PediatricTestingEfficiency = _forecast.PediatricTestingEfficiency;
                site.PediatricsPreExistingPatients = _forecast.PediatricsPreExistingPatients;
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
