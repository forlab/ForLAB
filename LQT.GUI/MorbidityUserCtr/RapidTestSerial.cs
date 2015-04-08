
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
    public partial class RapidTestSerial : BaseMorbidityControl
    {
        private IList<ARTSite> _artSites;
        private MorbidityForecast _forecast;
        private bool _edited = false;

        public RapidTestSerial(MorbidityForecast forecast, IList<ARTSite> artsite)
        {
            _forecast = forecast;
            _artSites = artsite;
            InitializeComponent();

            lqtListView1.AddNoneEditableColumn(0);
            lqtListView1.AddNoneEditableColumn(1);
            lqtListView1.AddNoneEditableColumn(3);
            lqtListView1.AddNoneEditableColumn(5);
            lqtListView1.AddNoneEditableColumn(7);
            lqtListView1.AddNoneEditableColumn(9);
            lqtListView1.AddNoneEditableColumn(11);
            lqtListView1.AddNoneEditableColumn(13);
            lqtListView1.AddNoneEditableColumn(15);
            lqtListView1.AddNoneEditableColumn(17);
            lqtListView1.AddNoneEditableColumn(19);

            lqtListView1.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lqtListView1_SubitemTextChanged);
            BindArtSites(true);
        }
        
        private void lqtListView1_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            ARTSite site = (ARTSite)li.Tag;
            int index = e.ColumnIndex;
            double Num;//b
            bool isNum = double.TryParse(li.SubItems[index].Text, out Num);//b
            if (isNum)//b
            {
                if (e.ColumnIndex == 2)
                    site.ScrTest1Percent = double.Parse(li.SubItems[index].Text);
                if (e.ColumnIndex == 4)
                    site.ScrTest2Percent = double.Parse(li.SubItems[index].Text);
                if (e.ColumnIndex == 6)
                    site.ScrTest3Percent = double.Parse(li.SubItems[index].Text);

                if (e.ColumnIndex == 8)
                    site.ConTest1Percent = double.Parse(li.SubItems[index].Text);
                if (e.ColumnIndex == 10)
                    site.ConTest2Percent = double.Parse(li.SubItems[index].Text);
                if (e.ColumnIndex == 12)
                    site.ConTest3Percent = double.Parse(li.SubItems[index].Text);

                if (e.ColumnIndex == 14)
                    site.TieTest1Percent = double.Parse(li.SubItems[index].Text);
                if (e.ColumnIndex == 16)
                    site.TieTest2Percent = double.Parse(li.SubItems[index].Text);
                if (e.ColumnIndex == 18)
                    site.TieTest3Percent = double.Parse(li.SubItems[index].Text);

                _edited = true;

            }
        }

        private void BindDefaultVlues(IList<RapidTestSpec> screening, IList<RapidTestSpec> conf, IList<RapidTestSpec> tieb )
        {
            lblS1.Text = screening.Count > 0 && screening[0].Product != null ? screening[0].Product.ProductName : "--";
            lblS2.Text = screening.Count > 1 && screening[1].Product != null ? screening[1].Product.ProductName : "--";
            lblS3.Text = screening.Count > 2 && screening[2].Product != null ? screening[2].Product.ProductName : "--";

            lblC1.Text = conf.Count > 0 && conf[0].Product != null ? conf[0].Product.ProductName : "--";
            lblC2.Text = conf.Count > 1 && conf[1].Product != null ? conf[1].Product.ProductName : "--";
            lblC3.Text = conf.Count > 2 && conf[2].Product != null ? conf[2].Product.ProductName : "--";

            lblT1.Text = tieb.Count > 0 && tieb[0].Product != null ? tieb[0].Product.ProductName : "--";
            lblT2.Text = tieb.Count > 1 && tieb[1].Product != null ? tieb[1].Product.ProductName : "--";
            lblT3.Text = tieb.Count > 2 && tieb[2].Product != null ? tieb[2].Product.ProductName : "--";
        }

        private void ApplyDefaultValues()
        {
            double tempV;
            foreach (ListViewItem li in lqtListView1.Items)
            {
                ARTSite site = (ARTSite)li.Tag;

                if (!string.IsNullOrEmpty(txtS1.Text) && double.TryParse(txtS1.Text, out tempV))
                    site.ScrTest1Percent = tempV;
                if (!string.IsNullOrEmpty(txtS2.Text) && double.TryParse(txtS2.Text, out tempV))
                    site.ScrTest2Percent = tempV;
                if (!string.IsNullOrEmpty(txtS3.Text) && double.TryParse(txtS3.Text, out tempV))
                    site.ScrTest3Percent = tempV;

                if (!string.IsNullOrEmpty(txtC1.Text) && double.TryParse(txtC1.Text, out tempV))
                    site.ConTest1Percent = tempV;
                if (!string.IsNullOrEmpty(txtC2.Text) && double.TryParse(txtC2.Text, out tempV))
                    site.ConTest2Percent = tempV;
                if (!string.IsNullOrEmpty(txtC3.Text) && double.TryParse(txtC3.Text, out tempV))
                    site.ConTest3Percent = tempV;

                if (!string.IsNullOrEmpty(txtT1.Text) && double.TryParse(txtT1.Text, out tempV))
                    site.TieTest1Percent = tempV;
                if (!string.IsNullOrEmpty(txtT2.Text) && double.TryParse(txtT2.Text, out tempV))
                    site.TieTest2Percent = tempV;
                if (!string.IsNullOrEmpty(txtT3.Text) && double.TryParse(txtT3.Text, out tempV))
                    site.TieTest3Percent = tempV;
            }
            _edited = true;
        }


        public override string Title
        {
            get { return "Serial Rapid Test Algorithm by Site"; }
        }
        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.PediatricPatientBehavior;
            }
        }
        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.InvAssumption;
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
                string des = "Enter the percentage of Screening, Confirmatory and Tie-break test for each site. </br>";
                des += "<p>The percentage inputted for each category must add up to 100% for each site.</p>";
                return des;
            }
        }

        private void BindArtSites(bool bindDV)
        {
            IList<RapidTestSpec> screening = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Screening.ToString());
            IList<RapidTestSpec> conf = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Confirmatory.ToString());
            IList<RapidTestSpec> tieb = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Tie_Breaker.ToString());

            if (bindDV)
                BindDefaultVlues(screening, conf, tieb);

            string pname = "";
            lqtListView1.Items.Clear();
            lqtListView1.BeginUpdate();

            foreach (ARTSite site in _artSites)
            {
                ListViewItem item = new ListViewItem(site.MorbidityCategory.CategoryName) { Tag = site };
                item.UseItemStyleForSubItems = false;

                item.SubItems.Add(site.Site.SiteName);

                item.SubItems.Add(site.ScrTest1Percent.ToString(), Color.Black, SystemColors.GradientInactiveCaption, lqtListView1.Font);
                pname = screening.Count > 0 && screening[0].Product != null? screening[0].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, SystemColors.GradientInactiveCaption, lqtListView1.Font);
                item.SubItems.Add(site.ScrTest2Percent.ToString(), Color.Black, Color.CadetBlue, lqtListView1.Font);
                pname = screening.Count > 1 && screening[1].Product != null ? screening[1].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.CadetBlue, lqtListView1.Font);
                item.SubItems.Add(site.ScrTest3Percent.ToString(), Color.Black, SystemColors.GradientActiveCaption, lqtListView1.Font);
                pname = screening.Count > 2 && screening[2].Product != null ? screening[2].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, SystemColors.GradientActiveCaption, lqtListView1.Font);

                item.SubItems.Add(site.ConTest1Percent.ToString(), Color.Black, Color.PeachPuff, lqtListView1.Font);
                pname = conf.Count > 0 && conf[0].Product != null ? conf[0].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.PeachPuff, lqtListView1.Font);
                item.SubItems.Add(site.ConTest2Percent.ToString(), Color.Black, Color.BurlyWood, lqtListView1.Font);
                pname = conf.Count > 1 && conf[1].Product != null ? conf[1].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.BurlyWood, lqtListView1.Font);
                item.SubItems.Add(site.ConTest3Percent.ToString(), Color.Black, Color.LightSalmon, lqtListView1.Font);
                pname = conf.Count > 2 && conf[2].Product != null ? conf[2].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.LightSalmon, lqtListView1.Font);

                item.SubItems.Add(site.TieTest1Percent.ToString(), Color.Black, Color.SpringGreen, lqtListView1.Font);
                pname = tieb.Count > 0 && tieb[0].Product != null ? tieb[0].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.SpringGreen, lqtListView1.Font);
                item.SubItems.Add(site.TieTest2Percent.ToString(), Color.Black, Color.MediumSeaGreen, lqtListView1.Font);
                pname = tieb.Count > 1 && tieb[1].Product != null ? tieb[1].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.MediumSeaGreen, lqtListView1.Font);
                item.SubItems.Add(site.TieTest3Percent.ToString(), Color.Black, Color.MediumAquamarine, lqtListView1.Font);
                pname = tieb.Count > 2 && tieb[2].Product != null ? tieb[2].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.MediumAquamarine, lqtListView1.Font);

                lqtListView1.Items.Add(item);
            }
            lqtListView1.EndUpdate();

        }

        public override bool DoSomthingBeforeUnload()
        {
            if (_edited)
            {
                DataRepository.BatchSaveARTSite(_artSites);
                MorbidityForm.ReInitMorbidityFrm();
            }
            return true;
        }

        private void butApplyall_Click(object sender, EventArgs e)
        {
            ApplyDefaultValues();
            BindArtSites(false);
        }
    }
}
