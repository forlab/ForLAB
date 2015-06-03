
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class OptRecentData : BaseMorbidityControl
    {
        private LQTCheckBox _activeCheckBox;
        private MorbidityForecast _forecast;
        private bool _edited = false;

        public OptRecentData(MorbidityForecast forecast)
        {
            this._forecast = forecast;
            InitializeComponent();

            if (forecast.OptInitialPatientData > 0)
            {
                if (forecast.OptInitialPatientData == 1)
                {
                    lqtCheckBox1.Checked = true;
                    _activeCheckBox = lqtCheckBox1;
                }
                else
                {
                    lqtCheckBox2.Checked = true;
                    _activeCheckBox = lqtCheckBox2;
                }
            }
            else
            {
                OnNextButtonStatusChanged(false);
            }

            lqtCheckBox1.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
            lqtCheckBox2.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
        }

        public override string Title
        {
            get { return "Initial Patient Data"; }
        }
        public override string Description
        {
            get
            {
                //"Choose the Method that You Would Like to Load Patient Data"
                string desc = "<p> Before you can forecast patient demand during the upcoming time period, "
                 + "you must set a baseline patient level in 'Time Zero' using known numbers of patients "
                + "on treatment and on pre-treatment at each site. To do that, you can either enter data "
                + "from the last month prior to the start of the forecast, or data from another month that"
                + "will be used to estimate the number of patients in 'Time Zero'. </p>";

                desc += "<p>1. Most Recent Data </br>It is recommended to use site-level data from the last month prior to the "
                + "start of the forecast, if it is available.</p>";

                desc += "<p>2. Older Data </br>If site-level data is not available from the last month prior to the start of the forecast, "
            + "then it is recommended to use the most recent data available.</p>";

                return desc;
            }
        }
        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.SiteSelection;
            }
        }
        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                if (_forecast.OptInitialPatientData == 1)
                    return MorbidityCtrEnum.FromRecentData;
                else if (_forecast.OptInitialPatientData == 2)
                    return MorbidityCtrEnum.FromOldData;

                return MorbidityCtrEnum.Nothing;
            }
        }

        public override bool EnableNextButton()
        {
            return _forecast.OptInitialPatientData > 0;
        }

        private void LQTCheckBoxClick(object sender, LQTCheckBoxEvenArgs e)
        {
            if (_activeCheckBox != null)
                _activeCheckBox.Checked = false;
            _forecast.OptInitialPatientData = Convert.ToInt32( e.Tag);
            _activeCheckBox = (LQTCheckBox)sender;
            _edited = true;
            OnNextButtonStatusChanged(EnableNextButton());
        }

        public override bool DoSomthingBeforeUnload()
        {
            if (_edited)
            {
                DataRepository.SaveOrUpdateMorbidityForecast(_forecast);
            }
            return true;
        }
    }
}
