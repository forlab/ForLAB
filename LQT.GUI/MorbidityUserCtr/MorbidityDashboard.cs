
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
