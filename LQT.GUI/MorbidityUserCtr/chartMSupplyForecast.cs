
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
    public partial class chartMSupplyForecast : LQT.GUI.UserCtr.BaseUserControl
    {
        private IList<MorbiditySupplyProcurement> _morbiditySP;
        private int _ForecastId;
        private int _Platform;
      
        public chartMSupplyForecast(int _forecastId,int _platform)
        {
            _ForecastId = _forecastId;
            _Platform = _platform;

            InitializeComponent();
        }

        private void chartSiteCategory_Load(object sender, EventArgs e)
        {
            //return;
           

            _morbiditySP = DataRepository.GetMorbiditySPByForecastIdPlatformId(_ForecastId, _Platform);
            if (_morbiditySP.Count > 0)
            {
                if(_morbiditySP[0].PlatformEnum.ToString()=="6")
                    chart1.Titles[0].Text = "HIV-Rapid Test Supply Forecast";
                else
                    chart1.Titles[0].Text = _morbiditySP[0].PlatformEnum.ToString() + " Supply Forecast";


                double[] yval = new double[_morbiditySP.Count];
                string[] xval = new string[_morbiditySP.Count];
                double TotalPrice = 0;

                List<string> productCategories = new List<string>();

                int i = 0;
                foreach (MorbiditySupplyProcurement mp in _morbiditySP)
                {
                    TotalPrice = TotalPrice + mp.TotalCost;
                    MasterProduct product = DataRepository.GetProductById(mp.ProductId);

                    if (!productCategories.Contains(product.ProductType.TypeName))
                    {
                        productCategories.Add(product.ProductType.TypeName);
                    }


                    xval[i] = product.ProductName;
                    yval[i] = mp.QuantityToPurchase;
                    i++;
                }


                chart1.Series["morbiditySP"].Points.DataBindXY(xval, yval);

                //Series2

                //double[] yvals = new double[productCategories.Count];
                //string[] xvals = new string[productCategories.Count];
                //int j = 0;
                //foreach (string Pcategories in productCategories)
                //{
                //    xvals[j] = Pcategories;

                //    foreach (MorbiditySupplyProcurement mp in _morbiditySP)
                //    {
                //        MasterProduct product = DataRepository.GetProductById(mp.ProductId);

                //        if (product.ProductType.TypeName == Pcategories)
                //        {
                //            yvals[j] = mp.QuantityToPurchase + yvals[j];
                //        }

                //    }
                //    j++;
                //}
                //chart1.Series["Series2"].Points.DataBindXY(xvals, yvals);
            }

        }
    }
}
