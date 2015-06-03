
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
    public partial class chartMPatientNo : LQT.GUI.UserCtr.BaseUserControl
    {
        private PatientsNoofTest _p;
        private int _ForecastId;

        public chartMPatientNo()
        {
            InitializeComponent();
        }
        public chartMPatientNo(int _forecastId)
        {
            _ForecastId = _forecastId;
            InitializeComponent();
        }

        private void chartMPatientNo_Load(object sender, EventArgs e)
        {
            _p = DataRepository.GetPatientsNoofTestSummery(_ForecastId);


            double[] yval = {Math.Round(_p.PITMonth1),Math.Round(_p.PITMonth2),Math.Round(_p.PITMonth3),Math.Round(_p.PITMonth4),Math.Round(_p.PITMonth5),Math.Round(_p.PITMonth6),Math.Round(_p.PITMonth7),Math.Round(_p.PITMonth8),Math.Round(_p.PITMonth9),Math.Round(_p.PITMonth10),Math.Round(_p.PITMonth11),Math.Round(_p.PITMonth12)};
            string[] xval = new string[12];
            for (int i = 0; i < 12; i++)
            {
                int y = i + 1;
                xval[i] = "Month " + y;
            }
            chart1.Series["Series1"].Points.DataBindXY(xval, yval);

            double[] yval1 = { Math.Round(_p.PPARTMonth1), Math.Round(_p.PPARTMonth2), Math.Round(_p.PPARTMonth3), Math.Round(_p.PPARTMonth4), Math.Round(_p.PPARTMonth5), Math.Round(_p.PPARTMonth6), Math.Round(_p.PPARTMonth7), Math.Round(_p.PPARTMonth8), Math.Round(_p.PPARTMonth9),Math.Round( _p.PPARTMonth10), Math.Round(_p.PPARTMonth11), Math.Round(_p.PPARTMonth12) };
            string[] xval1 = new string[12];
            for (int i = 0; i < 12; i++)
            {
                int y = i + 1;
                xval1[i] = "Month " + y;
            }
            chart1.Series["Series4"].Points.DataBindXY(xval1, yval1);
        }

       
    }
}
