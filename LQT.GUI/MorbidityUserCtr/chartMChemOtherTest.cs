
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
    public partial class chartMChemOtherTest : LQT.GUI.UserCtr.BaseUserControl
    {
        private ChemandOtherNumberofTest _h;
        private int _ForecastId;
        private int _type;

        public chartMChemOtherTest()
        {
            InitializeComponent();
        }

        public chartMChemOtherTest(int _forecastId, int type)
        {
            _ForecastId = _forecastId;
            _type = type;
            InitializeComponent();
        }

        private void chartMChemViralTest_Load(object sender, EventArgs e)
        {
            if (_type == 2)//chem
            {
                chart1.Titles[0].Text = "Chemistry Tests Distribution";
                _h = DataRepository.GetChemistryTestSummary(_ForecastId);
                if (_h != null)
                {
                    double total = _h.TestBasedOnProtocols + _h.SymptomDirectedTests + _h.RepeatedDuetoClinicalReq + _h.InvalidTestandWastage;

                    double[] yval = { (_h.TestBasedOnProtocols / total), (_h.SymptomDirectedTests / total), (_h.RepeatedDuetoClinicalReq / total), (_h.InvalidTestandWastage / total) };
                    string[] xval = { "Tests Based On Protocols", "Symptom-Directed Tests", "Repeated Due to Clinical Req.", "Invalid Test and Wastage" };


                    chart1.Series["Series2"].Points.DataBindXY(xval, yval);
                }
            }
            if (_type == 5)//other
            {
                chart1.Titles[0].Text = "Other Tests Distribution";
                _h = DataRepository.GetOtherTestSummary(_ForecastId);
                if (_h != null)
                {
                    double total = _h.TestBasedOnProtocols + _h.SymptomDirectedTests + _h.RepeatedDuetoClinicalReq + _h.InvalidTestandWastage;

                    double[] yval = { (_h.TestBasedOnProtocols / total), (_h.SymptomDirectedTests / total), (_h.RepeatedDuetoClinicalReq / total), (_h.InvalidTestandWastage / total) };
                    string[] xval = { "Tests Based On Protocols", "Symptom-Directed Tests", "Repeated Due to Clinical Req.", "Invalid Test and Wastage" };


                    chart1.Series["Series2"].Points.DataBindXY(xval, yval);
                }
            }

            
        }
    }
}
