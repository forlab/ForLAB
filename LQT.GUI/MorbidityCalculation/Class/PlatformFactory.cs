
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

using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class PlatformFactory
    {
        private PlatformQuantifyObject _cd4Platform;
        private PlatformQuantifyObject _chemPlatform;
        private PlatformQuantifyObject _hemPlatform;
        private PlatformQuantifyObject _vlPlatform;
        private PlatformQuantifyObject _otherPlatform;
        private PlatformQuantifyObject _rapidPlatform;
        private PlatformQuantifyObject _conPlatform;

        public PlatformFactory()
        {
            InitPlatformObject();
        }

        public PlatformQuantifyObject CD4Platform
        {
            get { return _cd4Platform; }
        }
        public PlatformQuantifyObject ChemistryPlatform
        {
            get { return _chemPlatform; }
        }
        public PlatformQuantifyObject HematologyPlatform
            {
                get { return _hemPlatform; }
        }
        public PlatformQuantifyObject ViralloadPlatform
            {
                get { return _vlPlatform; }
        }
        public PlatformQuantifyObject OtherTestPlatform
            {
                get { return _otherPlatform; }
        }
        public PlatformQuantifyObject RapidTestPlatform
        {
            get { return _rapidPlatform; }
        }
        public PlatformQuantifyObject ConsumablePlatform
            {
                get { return _conPlatform; }
        }

        private void InitPlatformObject()
        {
            _cd4Platform = new PlatformQuantifyObject(GetListOfPQM(DataRepository.GetAllMorbidityTestByClass(ClassOfMorbidityTestEnum.CD4.ToString())), 
                            DataRepository.GetAllQuantificationMetricByClass(ClassOfMorbidityTestEnum.CD4.ToString()),
                            DataRepository.GetGeneralQuantifyMenuByClass(ClassOfMorbidityTestEnum.CD4.ToString()));

            _hemPlatform = new PlatformQuantifyObject(GetListOfPQM(DataRepository.GetAllMorbidityTestByClass(ClassOfMorbidityTestEnum.Hematology.ToString())),
                            DataRepository.GetAllQuantificationMetricByClass(ClassOfMorbidityTestEnum.Hematology.ToString()),
                            DataRepository.GetGeneralQuantifyMenuByClass(ClassOfMorbidityTestEnum.Hematology.ToString()));

            _vlPlatform = new PlatformQuantifyObject(GetListOfPQM(DataRepository.GetAllMorbidityTestByClass(ClassOfMorbidityTestEnum.ViralLoad.ToString())),
                            DataRepository.GetAllQuantificationMetricByClass(ClassOfMorbidityTestEnum.ViralLoad.ToString()),
                            DataRepository.GetGeneralQuantifyMenuByClass(ClassOfMorbidityTestEnum.ViralLoad.ToString()));

            _chemPlatform = new PlatformQuantifyObject(GetListOfChemistryPQM(DataRepository.GetAllMorbidityTestByClass(ClassOfMorbidityTestEnum.Chemistry.ToString())),
                            DataRepository.GetAllQuantificationMetricByClass(ClassOfMorbidityTestEnum.Chemistry.ToString()),
                            DataRepository.GetGeneralQuantifyMenuByClass(ClassOfMorbidityTestEnum.Chemistry.ToString()));

            _otherPlatform = new PlatformQuantifyObject(null, DataRepository.GetAllQuantificationMetricByClass(ClassOfMorbidityTestEnum.OtherTest.ToString()),
                            DataRepository.GetGeneralQuantifyMenuByClass(ClassOfMorbidityTestEnum.OtherTest.ToString()));

            _conPlatform = new PlatformQuantifyObject(null, DataRepository.GetAllQuantificationMetricByClass(ClassOfMorbidityTestEnum.Consumable.ToString()),
                            DataRepository.GetAllGeneralQuantifyMenus());

            _rapidPlatform = new PlatformQuantifyObject(null, DataRepository.GetAllQuantificationMetricByClass(ClassOfMorbidityTestEnum.RapidTest.ToString()),
                            DataRepository.GetAllQuantifyMenuByClass(ClassOfMorbidityTestEnum.RapidTest.ToString()));
        }

        private IList<PlatformQuantifyMenu> GetListOfPQM(IList<MorbidityTest> list)
        {
            IList<PlatformQuantifyMenu> listofPQM = new List<PlatformQuantifyMenu>();

            foreach (MorbidityTest mt in list)
            {
                PlatformQuantifyMenu pqm = new PlatformQuantifyMenu(mt.Instrument.Id);
                foreach (QuantifyMenu qm in mt.QuantifyMenus)
                {
                    if (qm.TestTypeToEnum == TestTypeEnum.Test)
                        pqm.SetQuantifyMenuId(TestTypeEnum.Test, qm.Id);
                    else if (qm.TestTypeToEnum == TestTypeEnum.PerDay)
                        pqm.SetQuantifyMenuId(TestTypeEnum.PerDay, qm.Id);
                    else if (qm.TestTypeToEnum == TestTypeEnum.PerInstrument)
                        pqm.SetQuantifyMenuId(TestTypeEnum.PerInstrument, qm.Id);
                    else if (qm.TestTypeToEnum == TestTypeEnum.ControlTest)
                    {
                        pqm.SetQuantifyMenuId(qm.DurationToEnum, qm.Id);
                    }
                }
                listofPQM.Add(pqm);   
            }
            return listofPQM;
        }

        private IList<PlatformQuantifyMenu> GetListOfChemistryPQM(IList<MorbidityTest> list)
        {
            IList<PlatformQuantifyMenu> listofPQM = new List<PlatformQuantifyMenu>();

            foreach (MorbidityTest mt in list)
            {
                CTestPlatformQuantifyMenu pqm = new CTestPlatformQuantifyMenu(mt.Instrument.Id);
                foreach (QuantifyMenu qm in mt.QuantifyMenus)
                {
                    if (qm.TestTypeToEnum == TestTypeEnum.Test)
                        pqm.SetChemQuantifyMenuId(qm.ChemTestNameToEnum, qm.Id);
                    else if (qm.TestTypeToEnum == TestTypeEnum.PerDay)
                        pqm.SetQuantifyMenuId(TestTypeEnum.PerDay, qm.Id);
                    else if (qm.TestTypeToEnum == TestTypeEnum.PerInstrument)
                        pqm.SetQuantifyMenuId(TestTypeEnum.PerInstrument, qm.Id);
                    else if (qm.TestTypeToEnum == TestTypeEnum.ControlTest)
                        pqm.SetQuantifyMenuId(qm.DurationToEnum, qm.Id);
                    else if(qm.TestTypeToEnum == TestTypeEnum.SamplesRunOn)
                        pqm.TotalPatientSamplesRunOnIns = qm.Id;
                }
                listofPQM.Add(pqm);
            }
            return listofPQM;
        }

        
    }
}
