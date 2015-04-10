
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
