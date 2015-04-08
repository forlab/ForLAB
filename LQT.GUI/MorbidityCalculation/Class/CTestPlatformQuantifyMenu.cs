
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
    public class CTestPlatformQuantifyMenu : PlatformQuantifyMenu
    {
        private int _ALT;
        private int _AST;
        private int _CHO;
        private int _GLC;
        private int _CRE;
        private int _TG;
        private int _GGT;
        private int _ALP;
        private int _AMY;
        private int _CO2;
        private int _ElectrolytePanel;
        private int _Urea;

        public CTestPlatformQuantifyMenu(int insid) : base(insid)
        {
        }

        public void SetChemQuantifyMenuId(ChemistryTestNameEnum test, int value)
        {
            switch (test)
            {
                case ChemistryTestNameEnum.ALT:
                    _ALT = value;
                    break;
                case ChemistryTestNameEnum.ALP:
                    _ALP = value;
                    break;
                case ChemistryTestNameEnum.AMY:
                    _AMY = value;
                    break;
                case ChemistryTestNameEnum.AST:
                    _AST = value;
                    break;
                case ChemistryTestNameEnum.CHO:
                    _CHO = value;
                    break;
                case ChemistryTestNameEnum.CO2:
                    _CO2 = value;
                    break;
                case ChemistryTestNameEnum.CRE:
                    _CRE = value;
                    break;
                case ChemistryTestNameEnum.Electrolyte_Panel:
                    _ElectrolytePanel = value;
                    break;
                case ChemistryTestNameEnum.GGT:
                    _GGT = value;
                    break;
                case ChemistryTestNameEnum.GLC:
                    _GLC = value;
                    break;
                case ChemistryTestNameEnum.TG:
                    _TG = value;
                    break;
                case ChemistryTestNameEnum.Urea:
                    _Urea = value;
                    break;
            }
        }

        public int GetChemQuantifyMenuId(ChemistryTestNameEnum test)
        {
            int value = 0;
            switch (test)
            {
                case ChemistryTestNameEnum.ALT:
                    value = _ALT;
                    break;
                case ChemistryTestNameEnum.ALP:
                    value = _ALP;
                    break;
                case ChemistryTestNameEnum.AMY:
                    value = _AMY;
                    break;
                case ChemistryTestNameEnum.AST:
                    value = _AST;
                    break;
                case ChemistryTestNameEnum.CHO:
                    value = _CHO;
                    break;
                case ChemistryTestNameEnum.CO2:
                    value = _CO2;
                    break;
                case ChemistryTestNameEnum.CRE:
                    value = _CRE;
                    break;
                case ChemistryTestNameEnum.Electrolyte_Panel:
                    value = _ElectrolytePanel;
                    break;
                case ChemistryTestNameEnum.GGT:
                    value = _GGT;
                    break;
                case ChemistryTestNameEnum.GLC:
                    value = _GLC;
                    break;
                case ChemistryTestNameEnum.TG:
                    value = _TG;
                    break;
                case ChemistryTestNameEnum.Urea:
                    value = _Urea;
                    break;
            }
            return value;
        }

    }
}
