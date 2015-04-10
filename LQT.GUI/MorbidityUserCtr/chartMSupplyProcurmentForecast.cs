
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
    public partial class chartMSupplyProcurmentForecast : LQT.GUI.UserCtr.BaseUserControl
    {
        private IList<MorbiditySupplyProcurement> _morbiditySP;
        private int _ForecastId;
       

        public chartMSupplyProcurmentForecast(int _forecastId)
        {
            _ForecastId = _forecastId;
          

            InitializeComponent();
        }

        private void chartSiteCategory_Load(object sender, EventArgs e)
        {

            _morbiditySP = DataRepository.GetMorbiditySPByForecastId(_ForecastId);
            chart1.Titles[0].Text = " Supply Procurement Forecast";
            ClassOfMorbidityTestEnum[] platforms = LqtUtil.EnumToArray<ClassOfMorbidityTestEnum>();

            double[] yval = new double[platforms.Length];
            string[] xval = new string[platforms.Length];
          
            int i = 0;
            foreach (ClassOfMorbidityTestEnum m in platforms)
            {
                xval[i] = m.ToString();

                foreach (MorbiditySupplyProcurement mp in _morbiditySP)
                {
                    if (m == mp.PlatformEnum)
                    {
                        yval[i] = mp.TotalCost + yval[i];
                    }
                }
                i++;
            }


            chart1.Series["morbiditySP"].Points.DataBindXY(xval, yval);
           
     


        }
    }
}
