
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
