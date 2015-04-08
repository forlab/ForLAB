
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
    public partial class FromRecentData : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;
        private double? _sumofTimeZeroPatientOnTreatment;
        private double? _sumofTimeZeroPatientOnPreTreatment;

        public FromRecentData(MorbidityForecast forecast, IList<ARTSite> artsite)
        {
            _forecast = forecast;
            _artSites = artsite;

            InitializeComponent();
            lqtListView1.AddNoneEditableColumn(0);
            lqtListView1.AddNoneEditableColumn(1);
            lqtListView1.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lqtListView1_SubitemTextChanged);
            BindArtSites();
        }

        private void lqtListView1_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            ARTSite site = (ARTSite)li.Tag;
            int newvalue;

            if (e.ColumnIndex == 2)                
            {
                if (int.TryParse(li.SubItems[2].Text, out newvalue))//b
                {
                     SetOnTreatmentAllocation(site, newvalue);
                }
            }
            else
            {
                 if (int.TryParse(li.SubItems[3].Text, out newvalue))
                 {
                     SetOnPreTreatmentAllocation(site, newvalue);
                 }
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
                string des ="Enter Patient Data from the Last Month Prior to the Start of the Forecast </br>";
                des += "<p>Patients on Treatment and Pre-TreatmentIn the two columns of white cells, "
                + "enter the number of patients on treatment and on pre-treatment at each site for 'Time Zero.'</p>";
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

        private void PerformAddition()
        {
            _sumofTimeZeroPatientOnTreatment = 0;
            _sumofTimeZeroPatientOnPreTreatment = 0;
            foreach (ARTSite site in _artSites)
            {
                _sumofTimeZeroPatientOnTreatment += site.TimeZeroPatientOnTreatment;
                _sumofTimeZeroPatientOnPreTreatment += site.TimeZeroPatientOnPreTreatment;
            }
        }

        private double? SumOfTimeZeroPatientOnTreatment
        {
            get
            {
                if (!_sumofTimeZeroPatientOnTreatment.HasValue)
                {
                    PerformAddition();
                }
                return _sumofTimeZeroPatientOnTreatment;
            }
        }

        private double? SumOfTimeZeroPatientOnPreTreatment
        {
            get
            {
                if (!_sumofTimeZeroPatientOnPreTreatment.HasValue)
                {
                    PerformAddition();
                }
                return _sumofTimeZeroPatientOnPreTreatment;
            }
        }

        private void SetOnTreatmentAllocation(ARTSite site, int newvalue)
        {
            double total = SumOfTimeZeroPatientOnTreatment.Value;
            total = (total - site.TimeZeroPatientOnTreatment) + newvalue;
            site.TimeZeroPatientOnTreatment = newvalue;
            _sumofTimeZeroPatientOnTreatment = total;
            _forecast.TimeZeroPatientOnTreatment = _sumofTimeZeroPatientOnTreatment.Value;
        }

        private void SetOnPreTreatmentAllocation(ARTSite site, int newvalue)
        {
            double total = SumOfTimeZeroPatientOnPreTreatment.Value;
            total = (total - site.TimeZeroPatientOnPreTreatment) + newvalue;
            site.TimeZeroPatientOnPreTreatment = newvalue;
            _sumofTimeZeroPatientOnPreTreatment = total;
            _forecast.TimeZeroPatientOnPreTreatment = _sumofTimeZeroPatientOnPreTreatment.Value;
        }
    }
}
