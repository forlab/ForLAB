
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
using System.Linq;
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class PlatformQuantifyMenu
    {
        private int _instrumentId;
        private int _QMenuTest;
        private int _QMenuTotalControl;
        private int _QMenuPerTest;
        private int _QMenuDaily;
        private int _QMenuWeekly;
        private int _QMenuMonthly;
        private int _QMenuQuarterly;
        private int _QMenuPerInstrument;
        private int _QMenuPerDay;
        public int TotalPatientSamplesRunOnIns { get; set; }

        public PlatformQuantifyMenu(int insid)
        {
            _instrumentId = insid;
        }

        public int InstrumentId
        {
            get { return _instrumentId; }
        }

        public int GetQuantifyMenuId(TestingDurationEnum duration)
        {
            int result = 0;
            switch (duration)
            {
                case TestingDurationEnum.TotalControl:
                    result = _QMenuTotalControl;
                    break;
                case TestingDurationEnum.Daily:
                    result = _QMenuDaily;
                    break;
                case TestingDurationEnum.Monthly:
                    result = _QMenuMonthly;
                    break;
                case TestingDurationEnum.PerTest:
                    result = _QMenuPerTest;
                    break;
                case TestingDurationEnum.Quarterly:
                    result = _QMenuQuarterly;
                    break;
                case TestingDurationEnum.Weekly:
                    result = _QMenuWeekly;
                    break;
            }
            return result;
        }

        public void SetQuantifyMenuId(TestingDurationEnum duration,int value)
        {
            switch (duration)
            {
                case TestingDurationEnum.TotalControl:
                    _QMenuTotalControl = value;
                    break;
                case TestingDurationEnum.Daily:
                    _QMenuDaily = value;
                    break;
                case TestingDurationEnum.Monthly:
                    _QMenuMonthly = value;
                    break;
                case TestingDurationEnum.PerTest:
                    _QMenuPerTest = value;
                    break;
                case TestingDurationEnum.Quarterly:
                    _QMenuQuarterly = value;
                    break;
                case TestingDurationEnum.Weekly:
                    _QMenuWeekly = value;
                    break;
            }
        }
        public int GetQuantifyMenuId(TestTypeEnum testtype)
        {
            int result = 0;
            switch (testtype)
            {
                case TestTypeEnum.Test:
                    result = _QMenuTest;
                    break;
                case TestTypeEnum.PerInstrument:
                    result = _QMenuPerInstrument;
                    break;
                case TestTypeEnum.PerDay:
                    result = _QMenuPerDay;
                    break;
            }
            return result;
        }

        public void SetQuantifyMenuId(TestTypeEnum testtype,int value)
        {
            switch (testtype)
            {
                case TestTypeEnum.Test:
                    _QMenuTest = value;
                    break;
                case TestTypeEnum.PerInstrument:
                    _QMenuPerInstrument = value;
                    break;
                case TestTypeEnum.PerDay:
                    _QMenuPerDay = value;
                    break;
            }
        }
    }
}
