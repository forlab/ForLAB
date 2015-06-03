
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
    public partial class chartMCD4Test : LQT.GUI.UserCtr.BaseUserControl
    {
        private CD4TestNumber _cd;
        private int _ForecastId;

        public chartMCD4Test()
        {
            InitializeComponent();
        }

        public chartMCD4Test(int _forecastId)
        {
            _ForecastId = _forecastId;
            InitializeComponent();
        }

        private void chartMCD4Test_Load(object sender, EventArgs e)
        {
        
            _cd = DataRepository.GetCD4TestNumberSummary(_ForecastId);

            double total = _cd.CD4BaseLineTest + _cd.SymptomDirectedTest + _cd.RepeatsdutoClinicalRequest + _cd.Wastage;

            double[] yval = { (_cd.CD4BaseLineTest / total), (_cd.SymptomDirectedTest / total), (_cd.RepeatsdutoClinicalRequest / total), (_cd.Wastage / total) };
            string[] xval = { "BaseLine Tests", "Symptom-Directed Tests", "Reapeated Due to Clinical Req.","Wastage" };


            chart1.Series["Series2"].Points.DataBindXY(xval, yval);

            
        }
    }
}
