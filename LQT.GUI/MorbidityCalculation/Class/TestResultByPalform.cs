
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
using System.Linq;
using System.Text;

namespace LQT.GUI.MorbidityCalculation
{
    public class TestResultByPalform
    {
        public int InstrumentId { get; set; }
        public double Tests { get; set; }
        public double TotalControls { get; set; }
        public double ControlsPerTests { get; set; }
        public double DailyControls { get; set; }
        public double WeeklyControls { get; set; }
        public double MonthlyControls { get; set; }
        public double QuarterlyControls { get; set; }
        public double NoOfInstruments { get; set; }
        public double ReferringSiteTests { get; set; }
        public double ReferringSiteTotalControls { get; set; }
        public double ReferringSiteControlsPerTests { get; set; }

    }
}
