
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
using Microsoft.Samples.Windows.Forms.TaskPane;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class MorbidityDashboard : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private UserControl _currentUserCtr;

        public MorbidityDashboard()
        {
            InitializeComponent();
        }

        public MorbidityDashboard(MorbidityForecast forecast)
        {
            this._forecast = forecast;
         
            InitializeComponent();
        }

        public override string Title
        {
            get { return "Forecast Result Dashboard"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.Nothing;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.Nothing;
            }
        }

        public override bool EnableNextButton()
        {
            return false;
        }

        public void LoadCharts()
        {
            this._currentUserCtr = new chartMSupplyProcurmentForecast(_forecast.Id);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 1);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 2);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 3);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 4);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMPatientNo(_forecast.Id);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHIVRapidTest(_forecast.Id);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHematologyTest(_forecast.Id, 3);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHematologyTest(_forecast.Id, 4);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMCD4Test(_forecast.Id);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMChemOtherTest(_forecast.Id, 2);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMChemOtherTest(_forecast.Id, 5);
            LoadCurrentUserCtr1();
        }

        private void LoadCurrentUserCtr()
        {
            //_currentUserCtr.MdiParentForm = this;
            // _currentUserCtr.Dock = DockStyle.None;
            // _currentUserCtr.Width = 404;
            //_currentUserCtr.Height = 283;
            //_currentUserCtr.OnDoubleClick += new EventHandler(_currentUserCtr_OnDoubleClick);
            this.flowLayoutPanel1.Controls.Add(_currentUserCtr);

        }

        private void LoadCurrentUserCtr1()
        {
            //_currentUserCtr.MdiParentForm = this;
            // _currentUserCtr.Dock = DockStyle.None;
            // _currentUserCtr.Width = 404;
            //_currentUserCtr.Height = 283;
            //_currentUserCtr.OnDoubleClick += new EventHandler(_currentUserCtr_OnDoubleClick);
            this.flowLayoutPanel2.Controls.Add(_currentUserCtr);

        }

        public void closeAllFrames()
        {
            foreach (TaskFrame tf in taskPane1.TaskFrames)
            {
                tf.IsExpanded = false;
            }
        }

        private void taskPane1_FrameExpanding(object sender, TaskPaneCancelEventArgs ce)
        {
            closeAllFrames();
        }
    }
}
