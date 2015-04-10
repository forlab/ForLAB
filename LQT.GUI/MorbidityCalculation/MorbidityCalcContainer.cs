
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
    public class MorbidityCalcContainer
    {
        public MorbidityCalcContainer(int siteid)
        {
            SiteId = siteid;
        }

        public int SiteId { get; private set; }
        public CalcCD4Test CD4Calculation { get; set; }
        public CalcChemistryTest ChemistryCalculation { get; set; }
        public CalcConsumable ConsumableCalculation { get; set; }
        public CalcHematology HematologyCalculation { get; set; }
        public CalcOtherTest OtherTestCalculation { get; set; }
        public CalcViralLoad ViralLoadCalculation { get; set; }

        public IList<int> CD4ReferedSites  { get; set; }
        public IList<int> ChemReferedSites { get; set; }
        public IList<int> HemaReferedSites { get; set; }
        public IList<int> ViraReferedSites { get; set; }
    }
}
