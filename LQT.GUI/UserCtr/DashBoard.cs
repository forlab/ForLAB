
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace LQT.GUI.UserCtr
{
    public partial class DashBoard : LQT.GUI.UserCtr.BaseUserControl
    {
        private BaseUserControl _currentUserCtr;
        
        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            BulildDashBoard();
        }

        private void BulildDashBoard()
        {
            this._currentUserCtr = new ChartSiteperRegion();

            LoadCurrentUserCtr();

            this._currentUserCtr = new ChartTestperArea();

            LoadCurrentUserCtr();

            this._currentUserCtr = new ProductNoperCat();

            LoadCurrentUserCtr();

            this._currentUserCtr = new chartSiteCategory();

            LoadCurrentUserCtr();

            this._currentUserCtr = new ChartSiteLevelperRegion();

            LoadCurrentUserCtr();

            this._currentUserCtr = new chartInstrumentDistribution();

            LoadCurrentUserCtr();
        }

        private void LoadCurrentUserCtr()
        {

           
            //_currentUserCtr.MdiParentForm = this;
           // _currentUserCtr.Dock = DockStyle.None;
            _currentUserCtr.Width = 404;
            _currentUserCtr.Height = 283;
            //_currentUserCtr.OnDoubleClick += new EventHandler(_currentUserCtr_OnDoubleClick);
            this.flowLayoutPanel.Controls.Add(_currentUserCtr);

        }
        private void _currentUserCtr_OnDoubleClick(object sender, EventArgs e)
        {
            if (sender is UserControl)
            {
                UserControl uc = (UserControl)sender;
               //this.flowLayoutPanel.Controls.Clear();

               // if (uc.Name == "ChartSiteperRegion")
               // {
               //     this._CurrCtr = new ChartSiteperRegion();
               // }
            
              
               // _CurrCtr.Dock = DockStyle.Fill;

               // this.flowLayoutPanel.Controls.Add(_CurrCtr);
            }

        }

    }
}
