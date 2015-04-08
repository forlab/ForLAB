
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
