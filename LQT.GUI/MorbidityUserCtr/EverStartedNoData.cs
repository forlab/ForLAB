
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
    public partial class EverStartedNoData : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        //private bool _edited = false;
        private double? _sumofTimeZeroPatientOnTreatment;
        private double? _sumofTimeZeroPatientOnPreTreatment;

        public EverStartedNoData(MorbidityForecast forecast, IList<ARTSite> artsite)
        {
            _forecast = forecast;
            _artSites = artsite;

            InitializeComponent();

            txtTreatment.Text = _forecast.EverSTimeZeroPatientOnTreatment > 0 ? _forecast.EverSTimeZeroPatientOnTreatment.ToString() : "";
            txtPretreatment.Text = _forecast.EverSTimeZeroPatientOnPreTreatment > 0 ? _forecast.EverSTimeZeroPatientOnPreTreatment.ToString() : "";
            txtTreatment.LostFocus += new EventHandler(txtTreatment_LostFocus);
            txtPretreatment.LostFocus += new EventHandler(txtPretreatment_LostFocus);
        }

        private void txtTreatment_LostFocus(object sender, EventArgs e)
        {
            int count = string.IsNullOrEmpty(txtTreatment.Text) ? 0 : int.Parse(txtTreatment.Text);
            if (count != _forecast.EverSTimeZeroPatientOnTreatment)
            {
                _forecast.EverSTimeZeroPatientOnTreatment = count;
                SetAllOnTreatmentAllocation();
                //_edited = true;
            }
        }

        private void txtPretreatment_LostFocus(object sender, EventArgs e)
        {
            int count = string.IsNullOrEmpty(txtPretreatment.Text) ? 0 : int.Parse(txtPretreatment.Text);
            if (count != _forecast.EverSTimeZeroPatientOnPreTreatment)
            {
                _forecast.EverSTimeZeroPatientOnPreTreatment = count;
                SetAllOnPreTreatmentAllocation();
                //_edited = true;
            }
        }

        private void PerformAddition()
        {
            _sumofTimeZeroPatientOnTreatment = 0;
            _sumofTimeZeroPatientOnPreTreatment= 0;
            foreach (ARTSite site in _artSites)
            {
                _sumofTimeZeroPatientOnTreatment += site.EverSPatientOnTreatment;
                _sumofTimeZeroPatientOnPreTreatment += site.EverSPatientOnPreTreatment;
            }
        }

        private double? SumOfOldDataPatientOnTreatment
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

        private double? SumOfOldDataPatientOnPreTreatment
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
            _sumofTimeZeroPatientOnTreatment = total;
            SetAllOnTreatmentAllocation();
        }
        private void SetOnPreTreatmentAllocation(ARTSite site, double newvalue)
        {
            double total = SumOfOldDataPatientOnPreTreatment.Value;
            total = (total - site.EverSPatientOnPreTreatment) + newvalue;
            site.EverSPatientOnPreTreatment = newvalue;
            _sumofTimeZeroPatientOnPreTreatment = total;
            SetAllOnPreTreatmentAllocation();
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

    }
}
