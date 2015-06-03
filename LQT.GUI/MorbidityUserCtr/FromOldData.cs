
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
    public partial class FromOldData : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        private double? _sumofOldDataPatientOnTreatment;
        private double? _sumofOldDataPatientOnPreTreatment;

        public FromOldData(MorbidityForecast forecast, IList<ARTSite> artsite)
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

            txtTreatment.Text = _forecast.TimeZeroPatientOnTreatment > 0 ? _forecast.TimeZeroPatientOnTreatment.ToString() : "";
            txtPretreatment.Text = _forecast.TimeZeroPatientOnPreTreatment > 0 ? _forecast.TimeZeroPatientOnPreTreatment.ToString() : "";
            txtTreatment.LostFocus += new EventHandler(txtTreatment_LostFocus);
            txtPretreatment.LostFocus +=new EventHandler(txtPretreatment_LostFocus);
        }

        private void lqtListView1_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            ARTSite site = (ARTSite)li.Tag;
            double newvalue;
            switch (e.ColumnIndex)
            {
                case 2:
                     if (double.TryParse(li.SubItems[2].Text, out newvalue))
                     {
                         if (site.OldDataPatientOnTreatment != newvalue)
                         {
                             SetOnTreatmentAllocation(site, newvalue);
                             RefreshListView();
                         }
                     }
                    break;
                case 3:
                    if (double.TryParse(li.SubItems[3].Text, out newvalue))//b
                     {
                         if (site.OldDataPatientOnPreTreatment != newvalue)
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
            get { return "Current Patient Numbers by Site"; }
        }
        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.OptRecentData;
            }
        }
        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.OptTreatmentTarget;
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
                    +  "of patients on treatment and on pre-treatment at each site for the most recent month you have available.</br>";

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

                item.SubItems.Add(site.OldDataPatientOnTreatment.ToString());
                item.SubItems.Add(site.OldDataPatientOnPreTreatment.ToString());
                item.SubItems.Add(site.OldDataPatientOnTreatmentPercent.ToString());
                item.SubItems.Add(site.OldDataPatientOnPreTreatmentPercent.ToString());
                item.SubItems.Add(site.TimeZeroPatientOnTreatment.ToString());
                item.SubItems.Add(site.TimeZeroPatientOnPreTreatment.ToString());

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
               MorbidityForm.ReInitMorbidityFrm();
            }
            return true;
        }
 

        private void txtTreatment_LostFocus(object sender, EventArgs e)
        {
            int count = string.IsNullOrEmpty(txtTreatment.Text) ? 0 : int.Parse(txtTreatment.Text);
            if (count != _forecast.TimeZeroPatientOnTreatment)
            {
                _forecast.TimeZeroPatientOnTreatment = count;
                SetAllOnTreatmentAllocation();
                RefreshListView();
                _edited = true;
            }
        }

        private void txtPretreatment_LostFocus(object sender, EventArgs e)
        {
            int count = string.IsNullOrEmpty(txtPretreatment.Text) ? 0 : int.Parse(txtPretreatment.Text);
            if (count != _forecast.TimeZeroPatientOnPreTreatment)
            {
                _forecast.TimeZeroPatientOnPreTreatment = count;
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
                _sumofOldDataPatientOnTreatment += site.OldDataPatientOnTreatment;
                _sumofOldDataPatientOnPreTreatment += site.OldDataPatientOnPreTreatment;
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
                site.SetOldDataPercenAlocationOnTreatment(SumOfOldDataPatientOnTreatment.Value, _forecast.TimeZeroPatientOnTreatment);
            }
        }
        private void SetAllOnPreTreatmentAllocation()
        {
            foreach (ARTSite site in _artSites)
            {
                site.SetOldDataPercenAlocationOnPreTreatment(SumOfOldDataPatientOnPreTreatment.Value, _forecast.TimeZeroPatientOnPreTreatment);
            }
        }
        private void SetOnTreatmentAllocation(ARTSite site, double newvalue)
        {
            double total = SumOfOldDataPatientOnTreatment.Value;
            total = (total - site.OldDataPatientOnTreatment) + newvalue;
            site.OldDataPatientOnTreatment = newvalue;
            _sumofOldDataPatientOnTreatment = total;
            SetAllOnTreatmentAllocation();
        }
        private void SetOnPreTreatmentAllocation(ARTSite site, double newvalue)
        {
            double total = SumOfOldDataPatientOnPreTreatment.Value;
            total = (total - site.OldDataPatientOnPreTreatment) + newvalue;
            site.OldDataPatientOnPreTreatment = newvalue;
            _sumofOldDataPatientOnPreTreatment = total;
            SetAllOnPreTreatmentAllocation();
        }

        private void RefreshListView()
        {
            foreach (ListViewItem li in lqtListView1.Items)
            {
                ARTSite site = (ARTSite)li.Tag;

                li.SubItems[4].Text = site.OldDataPatientOnTreatmentPercent.ToString();
                li.SubItems[5].Text = site.OldDataPatientOnPreTreatmentPercent.ToString();
                li.SubItems[6].Text = site.TimeZeroPatientOnTreatment.ToString();
                li.SubItems[7].Text = site.TimeZeroPatientOnPreTreatment.ToString();
            }
        }
    }
}
