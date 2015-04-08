
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
    public partial class OptPreTreatmentPatientTargets : BaseMorbidityControl
    {
        private LQTCheckBox _activeCheckBox;
        private MorbidityForecast _forecast;
        private bool _edited = false;

        public OptPreTreatmentPatientTargets(MorbidityForecast forecast)
        {
            this._forecast = forecast;

            InitializeComponent();

            if (forecast.OptPreTreatmentPatinetTarget > 0)
            {
                switch (forecast.PreTreatmentPatinetTargetEnum)
                {
                    case OptPreTreatmentPatinetTargetEnum.NationalTarget:
                        _activeCheckBox = chbNationaltarget;
                        break;
                    case OptPreTreatmentPatinetTargetEnum.SiteGrowth:
                        _activeCheckBox = chbSitegrowth;
                        break;
                    case OptPreTreatmentPatinetTargetEnum.SelectSite:
                        _activeCheckBox = chbSelectsite;
                        break;
                    case OptPreTreatmentPatinetTargetEnum.AllSite:
                        _activeCheckBox = chbAllsite;
                        break;
                    case OptPreTreatmentPatinetTargetEnum.TestingEfficiency:
                        _activeCheckBox = chbTestingeff;
                        break;
                }
                _activeCheckBox.Checked = true;
            }
            else
            {
                OnNextButtonStatusChanged(false);
            }

            chbAllsite.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
            chbNationaltarget.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
            chbSelectsite.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
            chbSitegrowth.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
            chbTestingeff.LQTCheckBoxClick += new EventHandler<LQTCheckBoxEvenArgs>(LQTCheckBoxClick);
        }
        
        public override string Title
        {
            get { return "Patient Pre-Treatment Targets"; }
        }

        public override string Description
        {
            get
            {
                
                string desc = "Choose the Method that You Would Like to Set Your Pre-ART Patient Targets <br>";
                desc +="To set targets for how many patients will be receiving care but not treatment ";
                desc += "(i.e. pre-ART) by the end of the forecast period";
                return desc;
            }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.PatientNumbersSites;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                MorbidityCtrEnum ctrenum = MorbidityCtrEnum.Nothing;
                switch (_forecast.PreTreatmentPatinetTargetEnum)
                {
                    case OptPreTreatmentPatinetTargetEnum.NationalTarget:
                    case OptPreTreatmentPatinetTargetEnum.SiteGrowth:
                    case OptPreTreatmentPatinetTargetEnum.SelectSite:
                        ctrenum = MorbidityCtrEnum.SiteTargetCalculatorPreART;
                        break;
                    case OptPreTreatmentPatinetTargetEnum.AllSite:
                        ctrenum = MorbidityCtrEnum.PreTxNumbersSites;
                        break;
                    case OptPreTreatmentPatinetTargetEnum.TestingEfficiency:
                        ctrenum = MorbidityCtrEnum.TestingEfficiency;
                        break;
                }

                return ctrenum;
            }
        }

        public override bool EnableNextButton()
        {
            return _forecast.OptPreTreatmentPatinetTarget > 0;
        }

        private void LQTCheckBoxClick(object sender, LQTCheckBoxEvenArgs e)
        {
            if (_activeCheckBox != null)
                _activeCheckBox.Checked = false;
            _forecast.OptPreTreatmentPatinetTarget = Convert.ToInt32(e.Tag);
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
