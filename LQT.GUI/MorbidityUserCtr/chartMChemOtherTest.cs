
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
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
