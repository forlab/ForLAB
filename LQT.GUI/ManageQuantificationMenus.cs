
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

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI
{
    public class ManageQuantificationMenus
    {
        public static string BuildTestName(string insname, ClassOfMorbidityTestEnum classOfTest)
        {
            string tname = "";
            switch (classOfTest)
            {
                case ClassOfMorbidityTestEnum.CD4:
                    tname = String.Format("CD4 Tests-{0}", insname);
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    tname = String.Format("Total patient samples run on {0}", insname);
                    break;
                case ClassOfMorbidityTestEnum.Hematology:
                    tname = String.Format("Hematology Tests-{0}", insname);
                    break;
                case ClassOfMorbidityTestEnum.OtherTest:
                    tname = String.Format("Total {0}", insname);
                    break;
                case ClassOfMorbidityTestEnum.ViralLoad:
                    tname = String.Format("Viral Load Tests-{0}", insname);
                    break;
            }
            return tname;
        }

        public static void CreateQuantifyMenus(MorbidityTest morbidityTest)
        {
            QuantifyMenu qmenuTest = CreateNewQMenu(morbidityTest);
            qmenuTest.Title = BuildTestName(morbidityTest.Instrument.InstrumentName, morbidityTest.ClassOfTestEnum);
            if (morbidityTest.ClassOfTestEnum != ClassOfMorbidityTestEnum.Chemistry)
            {
                qmenuTest.TestType = TestTypeEnum.Test.ToString();
                morbidityTest.QuantifyMenus.Add(qmenuTest);
            }
            else
            {
                qmenuTest.TestType = TestTypeEnum.SamplesRunOn.ToString();
                morbidityTest.QuantifyMenus.Add(qmenuTest);
                CreateChemistryTestQM(morbidityTest);
            }

            QuantifyMenu qmenuCon = CreateNewQMenu(morbidityTest);
            qmenuCon.Title = String.Format("{0} Controls - {1}", morbidityTest.ClassOfTest, morbidityTest.Instrument.InstrumentName);
            qmenuCon.TestType = TestTypeEnum.ControlTest.ToString();
            qmenuCon.Duration = TestingDurationEnum.TotalControl.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuCon);

            QuantifyMenu qmenuPertest = CreateNewQMenu(morbidityTest);
            qmenuPertest.Title = String.Format("{0} Controls Per Test-{1}", morbidityTest.ClassOfTest, morbidityTest.Instrument.InstrumentName);
            qmenuPertest.TestType = TestTypeEnum.ControlTest.ToString();
            qmenuPertest.Duration = TestingDurationEnum.PerTest.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuPertest);

            QuantifyMenu qmenuDaily = CreateNewQMenu(morbidityTest);
            qmenuDaily.Title = String.Format("{0} Daily Controls-{1}", GetTestShortName(morbidityTest.ClassOfTestEnum), morbidityTest.Instrument.InstrumentName);
            qmenuDaily.TestType = TestTypeEnum.ControlTest.ToString();
            qmenuDaily.Duration = TestingDurationEnum.Daily.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuDaily);

            QuantifyMenu qmenuWeekly = CreateNewQMenu(morbidityTest);
            qmenuWeekly.Title = String.Format("{0} Weekly Controls-{1}", GetTestShortName(morbidityTest.ClassOfTestEnum), morbidityTest.Instrument.InstrumentName);
            qmenuWeekly.TestType = TestTypeEnum.ControlTest.ToString();
            qmenuWeekly.Duration = TestingDurationEnum.Weekly.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuWeekly);

            QuantifyMenu qmenuMonth = CreateNewQMenu(morbidityTest);
            qmenuMonth.Title = String.Format("{0} Monthly Controls-{1}", GetTestShortName(morbidityTest.ClassOfTestEnum), morbidityTest.Instrument.InstrumentName);
            qmenuMonth.TestType = TestTypeEnum.ControlTest.ToString();
            qmenuMonth.Duration = TestingDurationEnum.Monthly.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuMonth);

            QuantifyMenu qmenuQua = CreateNewQMenu(morbidityTest);
            qmenuQua.Title = String.Format("{0} Quarterly Controls-{1}", GetTestShortName(morbidityTest.ClassOfTestEnum), morbidityTest.Instrument.InstrumentName);
            qmenuQua.TestType = TestTypeEnum.ControlTest.ToString();
            qmenuQua.Duration = TestingDurationEnum.Quarterly.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuQua);

            QuantifyMenu qmenuPerins = CreateNewQMenu(morbidityTest);
            qmenuPerins.Title = String.Format("Per Instrument-{0}", morbidityTest.Instrument.InstrumentName);
            qmenuPerins.TestType = TestTypeEnum.PerInstrument.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuPerins);

            QuantifyMenu qmenuPerday = CreateNewQMenu(morbidityTest);
            qmenuPerday.Title = String.Format("Per Day-{0}", morbidityTest.Instrument.InstrumentName);
            qmenuPerday.TestType = TestTypeEnum.PerDay.ToString();
            morbidityTest.QuantifyMenus.Add(qmenuPerday);

        }

        private static void CreateChemistryTestQM(MorbidityTest _morbidityTest)
        {
            ChemistryTestNameEnum[] chem = LqtUtil.EnumToArray<ChemistryTestNameEnum>();
            for (int i = 0; i < chem.Length; i++)
            {
                QuantifyMenu qmenuTest = CreateNewQMenu(_morbidityTest);
                qmenuTest.ChemTestName = chem[i].ToString();
                qmenuTest.Title = String.Format("{0} Tests - {1}", chem[i], _morbidityTest.Instrument.InstrumentName);
                qmenuTest.TestType = TestTypeEnum.Test.ToString();
                _morbidityTest.QuantifyMenus.Add(qmenuTest);
            }
        }

        private static QuantifyMenu CreateNewQMenu(MorbidityTest morbidityTest)
        {
            QuantifyMenu qmenu = new QuantifyMenu();
            qmenu.ClassOfTest = morbidityTest.ClassOfTest;
            qmenu.InstrumentId = morbidityTest.Instrument.Id;
            qmenu.MorbidityTest = morbidityTest;

            return qmenu;
        }

        private static string GetTestShortName(ClassOfMorbidityTestEnum ttype)
        {
            string result = "";
            switch (ttype)
            {
                case ClassOfMorbidityTestEnum.CD4:
                    result = "CD4";
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    result = "Chem";
                    break;
                case ClassOfMorbidityTestEnum.Hematology:
                    result = "Hem";
                    break;
                case ClassOfMorbidityTestEnum.ViralLoad:
                    result = "VL";
                    break;
            }
            return result;
        }
    }
}
