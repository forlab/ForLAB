
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
using System.Collections;

namespace LQT.GUI.MorbidityCalculation
{
    public class BudgetPeriodInfo
    {
        //default value on the excel commented out for now
        //new double[] { 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170 };
        private double[] _defultMonthValue = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 

        public double[] DefultMonthValue
        {
            get { return _defultMonthValue; }
        }

        public int FirstMonth { get; set; } 
        public int LastMonth { get; set; }
        public int BufferStoks{ get; set; }
        public int BeginsOnmonth { get; set; }
        public int EndOnMonth { get; set; }

        public int NumberofMonthsinBudgetPeriod { get; set; }
        public int WorkingDaysinBudgetPeriod { get; set; }
        public int WeeksinBudgetPeriod { get; set; }
        public int QuartersinBudgetPeriod { get; set; }
        public int NumberofBufferMonthsBeyondForecast { get; set; }
    }
}
