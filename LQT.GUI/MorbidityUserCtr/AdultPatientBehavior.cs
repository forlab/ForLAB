
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
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class AdultPatientBehavior : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        public AdultPatientBehavior(MorbidityForecast forecast, IList<ARTSite> artsites)
        {
            this._forecast = forecast;
            this._artSites = artsites;

            InitializeComponent();
            lstSites.AddNoneEditableColumn(0);
            lstSites.AddNoneEditableColumn(1);

            lstSites.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lstSites_SubitemTextChanged);

            BindForecast();
            BindArtSites();
        }
        private void lstSites_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            ARTSite site = (ARTSite)li.Tag;
            double newvalue;//b
            bool isNum = double.TryParse(li.SubItems[e.ColumnIndex].Text, out newvalue);//b
            if (isNum)//b
            {
                //double newvalue = double.Parse(li.SubItems[e.ColumnIndex].Text);

                if (e.ColumnIndex == 2)
                {
                    site.AITAnnualPatientAttrition = newvalue;
                }
                else if (e.ColumnIndex == 3)
                {
                    site.AITExistingPatientBloodDraws = newvalue;
                }
                else if (e.ColumnIndex == 4)
                {
                    site.AITNewPatientBloodDraws = newvalue;
                }
                else if (e.ColumnIndex == 5)
                {
                    site.AIPAnualPatientAttrition = newvalue;
                }
                else if (e.ColumnIndex == 6)
                {
                    site.AIPAnnualMigration = newvalue;
                }
                else if (e.ColumnIndex == 7)
                {
                    site.AIPExistingPatientBloodDraws = newvalue;
                }
                else if (e.ColumnIndex == 8)
                {
                    site.AIPNewPatientBloodDraws = newvalue;
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
                    _forecast.AITAnnualPatientAttrition = newvalue;
                else if (tag == 1)
                    _forecast.AITExistingPatientBloodDraws = newvalue;
                else if (tag == 2)
                    _forecast.AITNewPatientBloodDraws = newvalue;
                else if (tag == 3)
                    _forecast.AIPAnualPatientAttrition = newvalue;
                else if (tag == 4)
                    _forecast.AIPAnnualMigration = newvalue;
                else if (tag == 5)
                    _forecast.AIPExistingPatientBloodDraws = newvalue;
                else if (tag == 6)
                    _forecast.AIPNewPatientBloodDraws = newvalue;
                _edited = true;
            }
        }

        public override string Title
        {
            get { return "Adult Patient Behavior"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.TestingInformation;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.PediatricPatientBehavior;
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
                string desc = "% ART Attrition <br>For each site, input the percentage of adult HIV patients on treatment that ";
                desc += "terminate their treatment for any reason (including death) over the course of a year. <br>";
                desc += "Existing Patient Blood Draws <br>For each site, input the number of blood draws that each EXISTING ";
                desc += "patient ON TREATMENT receives per year. This information is critical in order to efficiently ";
                desc += "combine all applicable tests which occur at the same appointment into the same blood draw.  <br>";
                desc += "New Patient Blood Draws <br>For each site, input the number of blood draws that each NEW patient ";
                desc += "ON TREATMENT receives per year. <br>";
                desc += "patients% Pre-ART Attrition <br>For each site, input the percentage of adult HIV patients on pre-treatment ";
                desc += "care that terminate their care for any reason (including death). <br>";
                desc += "% ART Migration <br>For each site, input the percentage of adult HIV patients on pre-ART that migrate to ART ";
                desc += "over the course of a year. <br>";
                desc += "Existing Patient Blood Draws <br>For each site, input the number of blood draws that each EXISTING patient ";
                desc += "ON PRE-ART receives per year. <br>";
                desc += "New Patient Blood Draws <br>For each site, input the number of blood draws that each NEW patient ON PRE-ART receives per year.";
                desc += "<div style=\"font-size: 10px; font-style: italic; color: #008000; border-style: solid; border-width: 1px\"><b>Keys</b></br>";
                desc += "--------Adults in Treatment(AT)--------<ul>";
                desc += "<li>AT- A.P.A&nbsp; : Annual % Patient Attrition</li>";
                desc += "<li>AT- A.B.D/E.P/Yr&nbsp; : Avg # Blood Draws/Existing Patient/Yr</li>";
                desc += "<li>AT- A.B.D/N.P/Yr&nbsp; : Avg # Blood Draws/New Patient/Yr</li></ul>";
                desc += "--------Adults in Pre-ART (APA)--------<ul>";
                desc += "<li>APA- A.P.A&nbsp; : Annual % Patient Attrition</li>";
                desc += "<li>APA- A.M.T&nbsp; : Annual % Migration into treatment</li>";
                desc += "<li>APA- A.B.D/E.P/Yr&nbsp; : Avg # Blood Draws/Existing Patient/Yr</li>";
                desc += "<li>APA- A.B.D/N.P/yr&nbsp; : Avg # Blood Draws/New Patient/Yr</li></ul></div>";
                return desc;
            }
        }

        private void BindForecast()
        {
            txtPTapa.Text = _forecast.AITAnnualPatientAttrition.ToString();
            txtPTabdep.Text = _forecast.AITExistingPatientBloodDraws.ToString();
            txtPTabdnp.Text = _forecast.AITNewPatientBloodDraws.ToString();
            txtPPAapa.Text = _forecast.AIPAnualPatientAttrition.ToString();
            txtPPAamt.Text = _forecast.AIPAnnualMigration.ToString();
            txtPPAabdep.Text = _forecast.AIPExistingPatientBloodDraws.ToString();
            txtPPAabdnp.Text = _forecast.AIPNewPatientBloodDraws.ToString();
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
                li.SubItems.Add(site.AITAnnualPatientAttrition.ToString(), Color.Black, Color.SpringGreen, lstSites.Font);
                li.SubItems.Add(site.AITExistingPatientBloodDraws.ToString(), Color.Black, Color.MediumSeaGreen, lstSites.Font);
                li.SubItems.Add(site.AITNewPatientBloodDraws.ToString(), Color.Black, Color.MediumAquamarine, lstSites.Font);
                li.SubItems.Add(site.AIPAnualPatientAttrition.ToString(), Color.Black, Color.PeachPuff, lstSites.Font);
                li.SubItems.Add(site.AIPAnnualMigration.ToString(), Color.Black, Color.BurlyWood, lstSites.Font);
                li.SubItems.Add(site.AIPExistingPatientBloodDraws.ToString(), Color.Black, Color.LightSalmon, lstSites.Font);
                li.SubItems.Add(site.AIPNewPatientBloodDraws.ToString(), Color.Black, Color.Tan, lstSites.Font);

                lstSites.Items.Add(li);
            }

            lstSites.EndUpdate();
        }

        private void butApplyall_Click(object sender, EventArgs e)
        {
            foreach (ARTSite site in _artSites)
            {
                site.AITAnnualPatientAttrition = _forecast.AITAnnualPatientAttrition;
                site.AITExistingPatientBloodDraws = _forecast.AITExistingPatientBloodDraws;
                site.AITNewPatientBloodDraws = _forecast.AITNewPatientBloodDraws;
                site.AIPAnualPatientAttrition = _forecast.AIPAnualPatientAttrition;
                site.AIPAnnualMigration = _forecast.AIPAnnualMigration;
                site.AIPExistingPatientBloodDraws = _forecast.AIPExistingPatientBloodDraws;
                site.AIPNewPatientBloodDraws = _forecast.AIPNewPatientBloodDraws;
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
            }
            return true;
        }
    }
}
