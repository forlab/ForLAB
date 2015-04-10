
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
    public partial class RapidTestParallel : BaseMorbidityControl
    {
        private IList<ARTSite> _artSites;
        private MorbidityForecast _forecast;
        private bool _edited = false;

        IList<RapidTestSpec> screening;
        IList<RapidTestSpec> conf;
        IList<RapidTestSpec> tieb;

        public RapidTestParallel(MorbidityForecast forecast, IList<ARTSite> artsite)
        {
            _forecast = forecast;
            _artSites = artsite;
            InitializeComponent();

            lqtListView1.AddNoneEditableColumn(0);
            lqtListView1.AddNoneEditableColumn(1);
            lqtListView1.AddNoneEditableColumn(3);
            lqtListView1.AddNoneEditableColumn(4);
            lqtListView1.AddNoneEditableColumn(6);
            lqtListView1.AddNoneEditableColumn(7);
            lqtListView1.AddNoneEditableColumn(9);
            lqtListView1.AddNoneEditableColumn(10);
            lqtListView1.AddNoneEditableColumn(12);
            lqtListView1.AddNoneEditableColumn(14);
            lqtListView1.AddNoneEditableColumn(16);
            
            lqtListView1.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lqtListView1_SubitemTextChanged);
            BindArtSites();
        }

        private void lqtListView1_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            ARTSite site = (ARTSite)li.Tag;
            double Num;//b
            bool isNum = double.TryParse(li.SubItems[e.ColumnIndex].Text, out Num);//b
            if (isNum)//b
            {
                if (e.ColumnIndex == 2)
                {
                    site.ScrTest1Percent = double.Parse(li.SubItems[2].Text);
                    site.ScrTest1 = screening[0].Product != null ? screening[0].Product.Id : 0;
                    site.ConTest1 = conf[0].Product != null ? conf[0].Product.Id : 0;
                }
                if (e.ColumnIndex == 5)
                {
                    site.ScrTest2Percent = double.Parse(li.SubItems[5].Text);
                    site.ScrTest2 = screening[1].Product != null ? screening[1].Product.Id : 0;
                    site.ConTest2 = conf[1].Product != null ? conf[1].Product.Id : 0;
                }
                if (e.ColumnIndex == 8)
                {
                    site.ScrTest3Percent = double.Parse(li.SubItems[8].Text);
                    site.ScrTest3 = screening[2].Product != null ? screening[2].Product.Id : 0;
                    site.ConTest3 = conf[2].Product != null ? conf[2].Product.Id : 0;
                }

                if (e.ColumnIndex == 11)
                {
                    site.TieTest1Percent = double.Parse(li.SubItems[11].Text);
                    site.TieTest1 = tieb[0].Product != null ? tieb[0].Product.Id : 0;
                }
                if (e.ColumnIndex == 13)
                {
                    site.TieTest2Percent = double.Parse(li.SubItems[13].Text);
                    site.TieTest2 = tieb[2].Product != null ? tieb[1].Product.Id : 0;
                }
                if (e.ColumnIndex == 15)
                {
                    site.TieTest3Percent = double.Parse(li.SubItems[15].Text);
                    site.TieTest3 = tieb[2].Product != null ? tieb[2].Product.Id : 0;
                }
                _edited = true;
            }
        }

        public override string Title
        {
            get { return "Parallel Rapid Test Algorithm by Site"; }
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

        private void BindArtSites()
        {
            screening = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Screening.ToString());
            conf = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Confirmatory.ToString());
            tieb = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Tie_Breaker.ToString());
            string pname = "";
            lqtListView1.Items.Clear();
            lqtListView1.BeginUpdate();

            foreach (ARTSite site in _artSites)
            {
                ListViewItem item = new ListViewItem(site.MorbidityCategory.CategoryName) { Tag = site };

                item.SubItems.Add(site.Site.SiteName);

                item.SubItems.Add(site.ScrTest1Percent.ToString());
                pname = screening.Count > 0 && screening[0].Product != null ? screening[0].Product.ProductName : "";
                item.SubItems.Add(pname);
                pname = conf.Count > 0 && conf[0].Product != null ? conf[0].Product.ProductName : "";
                item.SubItems.Add(pname);

                item.SubItems.Add(site.ScrTest2Percent.ToString());
                pname = screening.Count > 1 && screening[1].Product != null ? screening[1].Product.ProductName : "";
                item.SubItems.Add(pname, Color.Black, Color.Chartreuse, lqtListView1.Font);
                
                pname = conf.Count > 1 && conf[1].Product != null ? conf[1].Product.ProductName : "";
                item.SubItems.Add(pname);

                item.SubItems.Add(site.ScrTest3Percent.ToString());
                pname = screening.Count > 2 && screening[2].Product != null ? screening[2].Product.ProductName : "";
                item.SubItems.Add(pname);
                pname = conf.Count > 2 && conf[2].Product != null ? conf[2].Product.ProductName : "";
                item.SubItems.Add(pname);

                item.SubItems.Add(site.TieTest1Percent.ToString());
                pname = tieb.Count > 0 && tieb[0].Product != null ? tieb[0].Product.ProductName : "";
                item.SubItems.Add(pname);
                item.SubItems.Add(site.TieTest2Percent.ToString());
                pname = tieb.Count > 1 && tieb[1].Product != null ? tieb[1].Product.ProductName : "";
                item.SubItems.Add(pname);
                item.SubItems.Add(site.TieTest3Percent.ToString());
                pname = tieb.Count > 2 && tieb[2].Product != null ? tieb[2].Product.ProductName : "";
                item.SubItems.Add(pname);

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
    }
}
