
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
