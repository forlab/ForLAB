
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

namespace LQT.Core.Util
{
       public class ArtSiteCalculated
        {
           private IList<MorbiditySupplyForecast> _testReagents;
            private ArtSiteCalculated()
            {
            }

            public ArtSiteCalculated(int siteid)
            {
                this._siteId = siteid;
                this._testReagents = new List<MorbiditySupplyForecast>();
            }

            private int _siteId;
            public int SiteId
            {
                get { return _siteId; }
            }

            private string _sitename;
            public string SiteName
            {
                get { return _sitename; }
                set { _sitename = value; }
            }

            private PatientsNoofTest _patientNotest;
            public PatientsNoofTest PatinetNoOfTest
            {
                get { return _patientNotest; }
                set { _patientNotest = value; }
            }

            private object _calcPatientNos;
            public object PatientNumbers
            {
                get { return _calcPatientNos; }
                set { _calcPatientNos = value; }
            }

           
            public IList<MorbiditySupplyForecast> TestReagents
            {
                get { return _testReagents; }
                set { _testReagents = value; }
            }

            private HIVRapidNumberofTest _rapidNumaberOfTest;
            public HIVRapidNumberofTest RapidNumberofTest
            {
                get { return _rapidNumaberOfTest; }
                set { _rapidNumaberOfTest = value; }
            }

            private CD4TestNumber _cd4testNumber;
            public CD4TestNumber CD4TestNumber
            {
                get { return _cd4testNumber; }
                set { _cd4testNumber = value; }
            }

            private HemaandViralNumberofTest _vltestNumber;
            public HemaandViralNumberofTest ViralLodTestNumber
            {
                get { return _vltestNumber; }
                set { _vltestNumber = value; }
            }

            private HemaandViralNumberofTest _hemtestNumber;
            public HemaandViralNumberofTest HematologyTestNumber
            {
                get { return _hemtestNumber; }
                set { _hemtestNumber = value; }
            }

            private IList<ChemandOtherNumberofTest> _chemtestNumber;
            public IList<ChemandOtherNumberofTest> ChemistryTestNumber
            {
                get { return _chemtestNumber; }
                set { _chemtestNumber = value; }
            }
            private IList<ChemandOtherNumberofTest> _othtestNumber;
            public IList<ChemandOtherNumberofTest> OtherTestNumber
            {
                get { return _othtestNumber; }
                set { _othtestNumber = value; }
            }

        }
   
}
