
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
    public partial class OptTreatmentTarget : BaseMorbidityControl
    {
        private LQTCheckBox _activeCheckBox;
        private MorbidityForecast _forecast;
        private bool _edited = false;

        public OptTreatmentTarget(MorbidityForecast forecast)
        {
            this._forecast = forecast;
            InitializeComponent();

            if (forecast.OptPatientTreatmentTarget > 0)
            {
                if (forecast.OptPatientTreatmentTarget == 1)
                {
                    chbOntreatment.Checked = true;
                    _activeCheckBox = chbOntreatment;
                }
                else
                {
                    chbEverstarted.Checked = true;
                    _activeCheckBox = chbEverstarted;
                }
            }
            else
            {
                OnNextButtonStatusChanged(false);
            }

            chbOntreatment.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
            chbEverstarted.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
        }
        public override string Title
        {
            get { return "Patient Treatment Targets"; }
        }
        public override string Description
        {
            get
            {
                string desc = "As you prepare to enter your patient treatment targets,";
                desc += "you need to select whether you will set your targets according to the number of patients that ";
                desc += "are ON TREATMENT at the end of the forecast period, or the number of patients that have EVER ";
                desc += "STARTED ON TREATMENT by the end of the forecast period. Different countries often track the number ";
                desc += "of patients on treatment in different ways, depending on what data is available. Due to high levels ";
                desc += "of attrition and death, it is often difficult to estimate how many patients remain on treatment ";
                desc += "at any given time. The number of patients that have ever started on treatment will not take into ";
                desc += "account attrition and death, whereas the number of patients actually on treatment will. In order ";
                desc += "to reach a given target of patients on treatment, the system must add enough patients over the ";
                desc += "course of the forecast period to outweigh the patients lost due to attrition and death.";
                desc += "<br><p>NOTE: If you plan to enter targets for the number of patients that have ever started ";
                desc += "on treatment, then you will need to take the additional step of entering the number ";
                desc += "of patients ever started on treatment in 'Time Zero' as well.</p>";

                return desc;
            }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                if (_forecast.OptInitialPatientData == 1)
                    return MorbidityCtrEnum.FromRecentData;
                else
                    return MorbidityCtrEnum.FromOldData;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                if (_forecast.OptPatientTreatmentTarget == 1)
                    return MorbidityCtrEnum.OptArtPatientTarget;
                else if (_forecast.OptPatientTreatmentTarget == 2)
                    return MorbidityCtrEnum.OpEverStartedPatientTarget;

                return MorbidityCtrEnum.Nothing;
            }
        }

        public override bool EnableNextButton()
        {
            return _forecast.OptPatientTreatmentTarget > 0;
        }

        private void LQTCheckBoxClick(object sender, LQTCheckBoxEvenArgs e)
        {
            if (_activeCheckBox != null)
                _activeCheckBox.Checked = false;
            _forecast.OptPatientTreatmentTarget = Convert.ToInt32(e.Tag);
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
