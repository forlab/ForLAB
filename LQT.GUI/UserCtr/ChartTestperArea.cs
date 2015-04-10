
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

namespace LQT.GUI.UserCtr
{
    public partial class ChartTestperArea : LQT.GUI.UserCtr.BaseUserControl
    {
        private IList<TestingArea> _testArea;
        public ChartTestperArea()
        {
            InitializeComponent();
        }

        private void ChartTestperArea_Load(object sender, EventArgs e)
        {
            //no tests per area
            _testArea = DataRepository.GetAllTestingArea();
            int[] testcount = new int[_testArea.Count];
            string[] areas = new string[_testArea.Count];
            for (int i = 0; i < _testArea.Count; i++)
            {
                areas[i] = _testArea[i].AreaName;
                int groupTestCount = 0;
                for (int j = 0; j < _testArea[i].TestingGroups.Count; j++)
                {
                    groupTestCount = _testArea[i].TestingGroups[j].Tests.Count + groupTestCount;
                }
                testcount[i] = groupTestCount;
            }

            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = true;
            chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;

            chart1.Series["testperarea"]["PointWidth"] = "0.4";
            chart1.Series["testperarea"].Points.DataBindXY(areas, testcount);
        }

       

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
