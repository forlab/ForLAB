
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
    public class TestsAndControls
    {
        private TestsAndControls()
        {
        }

        public TestsAndControls(int month)
        {
            Month = month;
        }

        public int Month { get; private set; }

        public double TestsonInstrumentForecastPeriod { get; set; }
        public double TestsonInstrumentBufferStock { get; set; }
        public double SampleReferredTestsForecastPeriod { get; set; }
        public double SampleReferredTestsBufferStock { get; set; }

        public double ControlsPerNoOfTests { get; set; }
        public double ControlsPerDay { get; set; }
        public double ControlsPerWeek { get; set; }
        public double ControlsPerMonth { get; set; }
        public double ControlsPerQuarter { get; set; }

        public double ControlsPerNoOfTestsBuffer { get; set; }
        public double ControlsPerDayBuffer { get; set; }
        public double ControlsPerWeekBuffer { get; set; }
        public double ControlsPerMonthBuffer { get; set; }
        public double ControlsPerQuarterBuffer { get; set; }

        public double TotalControls
        {
            get
            {
                double result = ControlsPerNoOfTests + ControlsPerNoOfTestsBuffer;
                result += ControlsPerDay + ControlsPerDayBuffer;
                result += ControlsPerMonth + ControlsPerMonthBuffer;
                result += ControlsPerQuarter + ControlsPerQuarterBuffer;
                result += ControlsPerWeek + ControlsPerWeekBuffer;
                return result;
            }
        }
        public double TotalControlsFP
        {
            get
            {
                double result = ControlsPerNoOfTests;
                result += ControlsPerDay;
                result += ControlsPerMonth;
                result += ControlsPerQuarter;
                result += ControlsPerWeek;
                return result;
            }
        }
        public double TotalControlsBS
        {
            get
            {
                double result = ControlsPerNoOfTestsBuffer + ControlsPerDayBuffer;
                result += ControlsPerMonthBuffer + ControlsPerQuarterBuffer + ControlsPerWeekBuffer;
                return result;
            }
        }

        public double SampleReferredControlsPerNoOfTests { get; set; }
        public double SampleReferredControlsPerNoOfTestsBuffer { get; set; }
        public double SampleReferredTotalControls
        {
            get { return SampleReferredControlsPerNoOfTests + SampleReferredControlsPerNoOfTestsBuffer; }
        }

    }
}
