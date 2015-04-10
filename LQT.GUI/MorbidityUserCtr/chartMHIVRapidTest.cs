
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
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class chartMHIVRapidTest : LQT.GUI.UserCtr.BaseUserControl
    {
        private HIVRapidNumberofTest _h;
        private int _ForecastId;

        public chartMHIVRapidTest()
        {
            InitializeComponent();
        }

        public chartMHIVRapidTest(int _forecastId)
        {
            _ForecastId = _forecastId;
            InitializeComponent();
        }

        private void chartMHIVRapidTest_Load(object sender, EventArgs e)
        {
            _h = DataRepository.GetHIVRapidNumberofTestSummary(_ForecastId);

            double total=_h.Screening+_h.Confirmatory+_h.TieBreaker;
            
           
              //double[] yval1 = 
           string[] xval = { "Screening", "Confirmatory", "Tie-Breaker" };
            if (total > 0)
            {
                double[] yval = { (_h.Screening / total), (_h.Confirmatory / total), (_h.TieBreaker / total) };
                chart1.Series["Series2"].Points.DataBindXY(xval, yval);
           
            }
            else
            {

                chart1.Series["Series2"].Points.DataBindXY(xval, new double[]{ 0, 0, 0});
           
            }
           
            

            
           

            
        }
    }
}
