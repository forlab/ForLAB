
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
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class PlatformTestsAndControls
    {
        private IDictionary<int, TestsAndControls> _testsAndControls = new Dictionary<int, TestsAndControls>();
        public int InstrumentId { get; set; }
        public int Quantity { get; set; }

        public void AddTestAndControl(TestsAndControls ctc)
        {
            _testsAndControls.Add(ctc.Month, ctc);
        }

        public TestsAndControls GetTestAndControl(int month)
        {
            return _testsAndControls[month];
        }

        public double TotalSumOfTestOnInstrument()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].TestsonInstrumentForecastPeriod + _testsAndControls[i].TestsonInstrumentBufferStock;
            }

            return result;
        }

        public double SumOfTestForecastPeriod()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += _testsAndControls[i].TestsonInstrumentForecastPeriod;
            }

            return result;
        }
        public double SumOfTestBufferStock()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].TestsonInstrumentBufferStock;
            }

            return result;
        }

        public double SumOfSampleReferredTestForecastPeriod()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += _testsAndControls[i].SampleReferredTestsForecastPeriod;
            }

            return result;
        }
        public double SumOfSampleReferredTestBufferStock()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].SampleReferredTestsBufferStock;
            }

            return result;
        }

        public double TotalSumOfSampleReferredTestOnInstrumanet()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].SampleReferredTestsBufferStock + _testsAndControls[i].SampleReferredTestsForecastPeriod;
            }

            return result;
        }

        public double TotalControls()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].TotalControls;
            }

            return result;
        }
        public double TotalControlsFP()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += _testsAndControls[i].TotalControlsFP;
            }

            return result;
        }
        public double TotalControlsBP()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].TotalControlsBS;
            }

            return result;
        }

        public double SampleReferredTotalControls()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].SampleReferredTotalControls;
            }

            return result;
        }

        public double SumOfSampleReferredControlsPerNoOfTests()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += _testsAndControls[i].SampleReferredControlsPerNoOfTests;
            }

            return result;
        }
        public double SumOfSampleReferredControlsPerNoOfTestsBuffer()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].SampleReferredControlsPerNoOfTestsBuffer;
            }

            return result;
        }
        public double SumOfControlsPerNoOfTests()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].ControlsPerNoOfTests + _testsAndControls[i].ControlsPerNoOfTestsBuffer;
            }

            return result;
        }
        public double SumOfControlsPerDay()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].ControlsPerDay + _testsAndControls[i].ControlsPerDayBuffer;
            }

            return result;
        }
        public double SumOfControlsPerWeek()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].ControlsPerWeek + _testsAndControls[i].ControlsPerWeekBuffer;
            }

            return result;
        }
        public double SumOfControlsPerMonth()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].ControlsPerMonth + _testsAndControls[i].ControlsPerMonthBuffer;
            }

            return result;
        }
        public double SumOfControlsPerQuarter()
        {
            double result = 0;
            for (int i = 1; i <= 13; i++)
            {
                result += _testsAndControls[i].ControlsPerQuarter + _testsAndControls[i].ControlsPerQuarterBuffer;
            }

            return result;
        }

        public double GetSumOfControlsByDuration(TestingDurationEnum duration)
        {
            if (TestingDurationEnum.Daily == duration)
                return SumOfControlsPerDay();
            if (TestingDurationEnum.Monthly == duration)
                return SumOfControlsPerMonth();
            if (TestingDurationEnum.PerTest == duration)
                return SumOfControlsPerNoOfTests();
            if (TestingDurationEnum.Quarterly == duration)
                return SumOfControlsPerQuarter();
            if (TestingDurationEnum.Weekly == duration)
                return SumOfControlsPerWeek();
            if (TestingDurationEnum.TotalControl == duration)
                return TotalControls();
            return 0;
        }
    }
}
