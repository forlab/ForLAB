
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
