
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
