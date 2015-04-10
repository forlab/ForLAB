
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.GUI.MorbidityUserCtr;

namespace LQT.GUI
{
    public partial class FrmMorbiditySupplyForecastAdj : Form
    {
        private MorbidityForecast _forecast;
        private ProductQuantityInStock p;
        public FrmMorbiditySupplyForecastAdj(MorbidityForecast m)
        {
            _forecast = m;
            InitializeComponent();
        }

        private void FrmMorbiditySupplyForecastAdj_Load(object sender, EventArgs e)
        {
             p = new ProductQuantityInStock(_forecast);
            p.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(p);
        }

        private void FrmMorbiditySupplyForecastAdj_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (p.edited)
            //{
                this.DialogResult = DialogResult.OK;
                p.DoSomthingBeforeUnload();
            //}
            //else
            //{
            //    p.edited = false;
              //  this.DialogResult = DialogResult.Cancel;
            //}
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            //p.edited = false;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            p.DoSomthingBeforeUnload();
        }
    }
}
