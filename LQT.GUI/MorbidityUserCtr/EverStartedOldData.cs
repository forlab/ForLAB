
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
    public partial class EverStartedOldData : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        private double? _sumofOldDataPatientOnTreatment;
        private double? _sumofOldDataPatientOnPreTreatment;

        public EverStartedOldData(MorbidityForecast forecast, IList<ARTSite> artsite)
        {
            _forecast = forecast;
            _artSites = artsite;
            InitializeComponent();

            lqtListView1.AddNoneEditableColumn(0);
            lqtListView1.AddNoneEditableColumn(1);
            lqtListView1.AddNoneEditableColumn(4);
            lqtListView1.AddNoneEditableColumn(5);
            lqtListView1.AddNoneEditableColumn(6);
            lqtListView1.AddNoneEditableColumn(7);
            lqtListView1.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lqtListView1_SubitemTextChanged);
            BindArtSites();

            txtTreatment.Text = _forecast.EverSTimeZeroPatientOnTreatment > 0 ? _forecast.EverSTimeZeroPatientOnTreatment.ToString() : "";
            txtPretreatment.Text = _forecast.EverSTimeZeroPatientOnPreTreatment > 0 ? _forecast.EverSTimeZeroPatientOnPreTreatment.ToString() : "";
            txtTreatment.LostFocus += new EventHandler(txtTreatment_LostFocus);
            txtPretreatment.LostFocus += new EventHandler(txtPretreatment_LostFocus);
        }

        private void lqtListView1_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            ARTSite site = (ARTSite)li.Tag;
            double newvalue;
            bool isNum = false;
            switch (e.ColumnIndex)
            {
                case 2:
                      isNum = double.TryParse(li.SubItems[2].Text, out newvalue);//b
                     if (isNum)//b
                     {
                         if (site.EverSPatientOnTreatment != newvalue)
                         {
                             SetOnTreatmentAllocation(site, newvalue);
                             RefreshListView();
                         }
                     }
                    break;
                case 3:
                      isNum = double.TryParse(li.SubItems[3].Text, out newvalue);//b
                     if (isNum)//b
                     {
                         if (site.EverSPatientOnPreTreatment != newvalue)
                         {
                             SetOnPreTreatmentAllocation(site, newvalue);
                             RefreshListView();
                         }
                     }
                    break;
            }
            _edited = true;
        }

        public override string Title
        {
            get { return "EVER STARTED Patient Numbers by Site"; }
        }
        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.OpEverStartedPatientTarget;
            }
        }
        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.OptArtPatientTarget;
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
                //Enter Patient Data from the Most Recent Month You HaveData Available
                string des = "<p><h4>Total Patients</h4> You must enter the total number of patients on treatment and in pre-treatment "
                + "across all sites for the last month prior to the start of the forecast</p>";

                des += "<p><h4>Patients on Treatment and Pre-Treatment</h4> In the two columns, enter the number"
                    + "of patients on treatment and on pre-treatment at each site for the most recent month you have available.</br>";

                des += "The model will then automatically use the percent allocation of patients across sites "
                    + "from the older data to estimate the number of patients at each site for 'Time Zero.' </p>";

                return des;
            }
        }

        private void BindArtSites()
        {
            lqtListView1.Items.Clear();
            lqtListView1.BeginUpdate();

            foreach (ARTSite site in _artSites)
            {
                ListViewItem item = new ListViewItem(site.MorbidityCategory.CategoryName) { Tag = site };

                item.SubItems.Add(site.Site.SiteName);

                item.SubItems.Add(site.EverSPatientOnTreatment.ToString());
                item.SubItems.Add(site.EverSPatientOnPreTreatment.ToString());
                item.SubItems.Add(site.EverSPatientOnTreatmentPercent.ToString());
                item.SubItems.Add(site.EverSPatientOnPreTreatmentPercent.ToString());
                item.SubItems.Add(site.EverSTimeZeroPatientOnTreatment.ToString());
                item.SubItems.Add(site.EverSTimeZeroPatientOnPreTreatment.ToString());

                lqtListView1.Items.Add(item);
            }

            lqtListView1.EndUpdate();
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


        private void txtTreatment_LostFocus(object sender, EventArgs e)
        {
            int count = string.IsNullOrEmpty(txtTreatment.Text) ? 0 : int.Parse(txtTreatment.Text);
            if (count != _forecast.EverSTimeZeroPatientOnTreatment)
            {
                _forecast.EverSTimeZeroPatientOnTreatment = count;
                SetAllOnTreatmentAllocation();
                RefreshListView();
                _edited = true;
            }
        }

        private void txtPretreatment_LostFocus(object sender, EventArgs e)
        {
            int count = string.IsNullOrEmpty(txtPretreatment.Text) ? 0 : int.Parse(txtPretreatment.Text);
            if (count != _forecast.EverSTimeZeroPatientOnPreTreatment)
            {
                _forecast.EverSTimeZeroPatientOnPreTreatment = count;
                SetAllOnPreTreatmentAllocation();
                RefreshListView();
                _edited = true;
            }
        }

        private void OnlyDigt_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void PerformAddition()
        {
            _sumofOldDataPatientOnTreatment = 0;
            _sumofOldDataPatientOnPreTreatment = 0;
            foreach (ARTSite site in _artSites)
            {
                _sumofOldDataPatientOnTreatment += site.EverSPatientOnTreatment;
                _sumofOldDataPatientOnPreTreatment += site.EverSPatientOnPreTreatment;
            }
        }

        private double? SumOfOldDataPatientOnTreatment
        {
            get
            {
                if (!_sumofOldDataPatientOnTreatment.HasValue)
                {
                    PerformAddition();
                }
                return _sumofOldDataPatientOnTreatment;
            }
        }

        private double? SumOfOldDataPatientOnPreTreatment
        {
            get
            {
                if (!_sumofOldDataPatientOnPreTreatment.HasValue)
                {
                    PerformAddition();
                }
                return _sumofOldDataPatientOnPreTreatment;
            }
        }
        private void SetAllOnTreatmentAllocation()
        {
            foreach (ARTSite site in _artSites)
            {
                site.SetOldDataPercenAlocationOnTreatment(SumOfOldDataPatientOnTreatment.Value, _forecast.EverSTimeZeroPatientOnTreatment);
            }
        }
        private void SetAllOnPreTreatmentAllocation()
        {
            foreach (ARTSite site in _artSites)
            {
                site.SetOldDataPercenAlocationOnPreTreatment(SumOfOldDataPatientOnPreTreatment.Value, _forecast.EverSTimeZeroPatientOnPreTreatment);
            }
        }
        private void SetOnTreatmentAllocation(ARTSite site, double newvalue)
        {
            double total = SumOfOldDataPatientOnTreatment.Value;
            total = (total - site.EverSPatientOnTreatment) + newvalue;
            site.EverSPatientOnTreatment = newvalue;
            _sumofOldDataPatientOnTreatment = total;
            SetAllOnTreatmentAllocation();
        }
        private void SetOnPreTreatmentAllocation(ARTSite site, double newvalue)
        {
            double total = SumOfOldDataPatientOnPreTreatment.Value;
            total = (total - site.EverSPatientOnPreTreatment) + newvalue;
            site.EverSPatientOnPreTreatment = newvalue;
            _sumofOldDataPatientOnPreTreatment = total;
            SetAllOnPreTreatmentAllocation();
        }

        private void RefreshListView()
        {
            foreach (ListViewItem li in lqtListView1.Items)
            {
                ARTSite site = (ARTSite)li.Tag;

                li.SubItems[4].Text = site.EverSPatientOnTreatmentPercent.ToString();
                li.SubItems[5].Text = site.EverSPatientOnPreTreatmentPercent.ToString();
                li.SubItems[6].Text = site.EverSTimeZeroPatientOnTreatment.ToString();
                li.SubItems[7].Text = site.EverSTimeZeroPatientOnPreTreatment.ToString();
            }
        }
    }
}
