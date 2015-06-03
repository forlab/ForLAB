
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
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.GUI.Location;
//using LQT.GUI.Quantification;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class InvAssumption : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private InventoryAssumption _invAssumption;
        private bool _edited = false;

        public InvAssumption(MorbidityForecast forecast, InventoryAssumption invAss)
        {
            this._forecast = forecast;
            this._invAssumption = invAss;

            InitializeComponent();

            BindInvAssumption();
        }

        public override string Title
        {
            get { return "Ordering and Inventory Assumptions"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                if (_forecast.TypeofAlgorithmEnum == AlgorithmType.Serial)
                    return MorbidityCtrEnum.RapidTestSerial;

                return MorbidityCtrEnum.RapidTestParallel;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.CheckupForm;
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
                string desc = "Ordering and Inventory Assumptions <br> Indicate what additional assumptions you make about how much quantities to order";
                return desc;
            }
        }

        private void BindInvAssumption()
        {
            txtSecurityStock.Text = _invAssumption.SecurityStock.ToString();
            txtScreening.Text = _invAssumption.RapidTestScreening.ToString();
            txtConfirmatory.Text = _invAssumption.RapidTestConfirmatery.ToString();
            txtTibreaker.Text = _invAssumption.RapidTestTibreaker.ToString();
            txtCd4.Text = _invAssumption.CD4.ToString();
            txtChemistry.Text = _invAssumption.Chemistry.ToString();
            txtHematology.Text = _invAssumption.Himatology.ToString();
            txtViralload.Text = _invAssumption.ViralLoad.ToString();
            txtOthertest.Text = _invAssumption.OtherTests.ToString();
        }

        private void SaveInvAssumption()
        {
            _invAssumption.SecurityStock = int.Parse(txtSecurityStock.Text);
            _invAssumption.RapidTestScreening = double.Parse(txtScreening.Text);
            _invAssumption.RapidTestConfirmatery = double.Parse(txtConfirmatory.Text);
            _invAssumption.RapidTestTibreaker = double.Parse(txtTibreaker.Text);
            _invAssumption.CD4 = double.Parse(txtCd4.Text);
            _invAssumption.Chemistry = double.Parse(txtChemistry.Text);
            _invAssumption.Himatology = double.Parse(txtHematology.Text);
            _invAssumption.ViralLoad = double.Parse(txtViralload.Text);
            _invAssumption.OtherTests = double.Parse(txtOthertest.Text);

            DataRepository.SaveOrUpdateInventoryAssumption(_invAssumption);
        }

        public override bool DoSomthingBeforeUnload()
        {
            if (_edited)
            {
                SaveInvAssumption();
            }
            return true;
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            //_edited = true;
        }

        private void OnlyDigt_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
                _edited = true;
            }
            else
                e.Handled = true;
        }
    }
}
