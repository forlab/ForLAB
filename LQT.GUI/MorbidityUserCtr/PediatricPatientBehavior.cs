
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
    public partial class PediatricPatientBehavior : BaseMorbidityControl
    {
       private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        public PediatricPatientBehavior(MorbidityForecast forecast, IList<ARTSite> artsites)
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
                    site.PITAnnualPatientAttrition = newvalue;
                }
                else if (e.ColumnIndex == 3)
                {
                    site.PITExistingPatientBloodDraws = newvalue;
                }
                else if (e.ColumnIndex == 4)
                {
                    site.PITNewPatientBloodDraws = newvalue;
                }
                else if (e.ColumnIndex == 5)
                {
                    site.PIPAnualPatientAttrition = newvalue;
                }
                else if (e.ColumnIndex == 6)
                {
                    site.PIPAnnualMigration = newvalue;
                }
                else if (e.ColumnIndex == 7)
                {
                    site.PIPExistingPatientBloodDraws = newvalue;
                }
                else if (e.ColumnIndex == 8)
                {
                    site.PIPNewPatientBloodDraws = newvalue;
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
                    _forecast.PITAnnualPatientAttrition = newvalue;
                else if (tag == 1)
                    _forecast.PITExistingPatientBloodDraws = newvalue;
                else if (tag == 2)
                    _forecast.PITNewPatientBloodDraws = newvalue;
                else if (tag == 3)
                    _forecast.PIPAnualPatientAttrition = newvalue;
                else if (tag == 4)
                    _forecast.PIPAnnualMigration = newvalue;
                else if (tag == 5)
                    _forecast.PIPExistingPatientBloodDraws = newvalue;
                else if (tag == 6)
                    _forecast.PIPNewPatientBloodDraws = newvalue;
                _edited = true;
            }
        }

        public override string Title
        {
            get { return "Pediatric Patient Behavior"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.AdultPatientBehavior;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                if (_forecast.TypeofAlgorithmEnum == AlgorithmType.Serial)
                    return MorbidityCtrEnum.RapidTestSerial;

                return MorbidityCtrEnum.RapidTestParallel;
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
                desc += "New Patient Blood Draws <br>For each site, input the number of blood draws that each NEW patient ON PRE-ART receives per year.</br>";
                desc += "<div style=\"font-size: 10px; font-style: italic; color: #008000; border-style: solid; border-width: 1px\"><b>Keys</b></br>";
                desc += "--------Pediatrics in Treatment(PT)--------<ul>";
                desc += "<li>PT- A.P.A&nbsp; : Annual % Patient Attrition</li>";
                desc += "<li>PT- A.B.D/E.P/Yr&nbsp; : Avg # Blood Draws/Existing Patient/Yr</li>";
                desc += "<li>PT- A.B.D/N.P/Yr&nbsp; : Avg # Blood Draws/New Patient/Yr</li></ul>";
                desc += "--------Pediatrics in Pre-ART (PPA)--------<ul>";
                desc += "<li>PPA- A.P.A&nbsp; : Annual % Patient Attrition</li>";
                desc += "<li>PPA- A.M.T&nbsp; : Annual % Migration into treatment</li>";
                desc += "<li>PPA- A.B.D/E.P/Yr&nbsp; : Avg # Blood Draws/Existing Patient/Yr</li>";
                desc += "<li>PPA- A.B.D/N.P/yr&nbsp; : Avg # Blood Draws/New Patient/Yr</li></ul></div>";
                return desc;
            }
        }

        private void BindForecast()
        {
            txtPTapa.Text = _forecast.PITAnnualPatientAttrition.ToString();
            txtPTabdep.Text = _forecast.PITExistingPatientBloodDraws.ToString();
            txtPTabdnp.Text = _forecast.PITNewPatientBloodDraws.ToString();
            txtPPAapa.Text = _forecast.PIPAnualPatientAttrition.ToString();
            txtPPAamt.Text = _forecast.PIPAnnualMigration.ToString();
            txtPPAabdep.Text = _forecast.PIPExistingPatientBloodDraws.ToString();
            txtPPAabdnp.Text = _forecast.PIPNewPatientBloodDraws.ToString();
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
                li.SubItems.Add(site.PITAnnualPatientAttrition.ToString(), Color.Black, Color.SpringGreen, lstSites.Font);
                li.SubItems.Add(site.PITExistingPatientBloodDraws.ToString(), Color.Black, Color.MediumSeaGreen, lstSites.Font);
                li.SubItems.Add(site.PITNewPatientBloodDraws.ToString(), Color.Black, Color.MediumAquamarine, lstSites.Font);
                li.SubItems.Add(site.PIPAnualPatientAttrition.ToString(), Color.Black, Color.PeachPuff, lstSites.Font);
                li.SubItems.Add(site.PIPAnnualMigration.ToString(), Color.Black, Color.BurlyWood, lstSites.Font);
                li.SubItems.Add(site.PIPExistingPatientBloodDraws.ToString(), Color.Black, Color.LightSalmon, lstSites.Font);
                li.SubItems.Add(site.PIPNewPatientBloodDraws.ToString(), Color.Black, Color.Tan, lstSites.Font);
                
                lstSites.Items.Add(li);
            }

            lstSites.EndUpdate();
        }

        private void butApplyall_Click(object sender, EventArgs e)
        {
            foreach (ARTSite site in _artSites)
            {
                site.PITAnnualPatientAttrition = _forecast.PITAnnualPatientAttrition;
                site.PITExistingPatientBloodDraws = _forecast.PITExistingPatientBloodDraws;
                site.PITNewPatientBloodDraws = _forecast.PITNewPatientBloodDraws;
                site.PIPAnualPatientAttrition = _forecast.PIPAnualPatientAttrition;
                site.PIPAnnualMigration = _forecast.PIPAnnualMigration;
                site.PIPExistingPatientBloodDraws = _forecast.PIPExistingPatientBloodDraws;
                site.PIPNewPatientBloodDraws = _forecast.PIPNewPatientBloodDraws;
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
