
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
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class MOutputOtherTest
    {
        private int _month;

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        private IList<OtherTestByPannel> _othTestbyPanel;
        public IList<OtherTestByPannel> OtherTestByPanel
        {
            get
            {
                if (_othTestbyPanel == null)
                    _othTestbyPanel = new List<OtherTestByPannel>();
                return _othTestbyPanel;
            }
        }

        public OtherTestByPannel GetOtherTestByPanelId(int panelid)
        {
            foreach (OtherTestByPannel c in OtherTestByPanel)
            {
                if (c.PanelId == panelid)
                    return c;
            }
            return null;
        }

        private IList<OtherSymptomDirectedTest> _othSymptom;
        public IList<OtherSymptomDirectedTest> OtherSymptomDirectedTest
        {
            get
            {
                if (_othSymptom == null)
                    _othSymptom = new List<OtherSymptomDirectedTest>();
                return _othSymptom;
            }
        }

        public OtherSymptomDirectedTest GetOtherSymptomDirectedTestById(OtherTestNameEnum test)
        {
            foreach (OtherSymptomDirectedTest c in OtherSymptomDirectedTest)
            {
                if (c.TestName == test)
                    return c;
            }
            return null;
        }

        public double GetSumOfOtherTest(OtherTestNameEnum test)
        {
            double result =0d;
            foreach (OtherTestByPannel c in OtherTestByPanel)
            {
                result += c.GetOtherTestValue(test);
            }
            return result;
        }
       
        public double GetSumOfTotalOtherSamples()
        {
            double result = 0d;
            foreach (OtherTestByPannel c in OtherTestByPanel)
            {
                result += c.TotalTestsForRegimen();
            }

            double maxAdult = 0;
            double maxPreAdult = 0;
            double maxPed = 0;
            double maxPrePed = 0;
            double maxRepeat=0;
            foreach (OtherSymptomDirectedTest c in OtherSymptomDirectedTest)
            {
                if (c.AdultSymptomDirectTest> maxAdult)
                    maxAdult = c.TotalSymptomDirectTest();
                if (c.PreArtAdultSymptomDirectTest > maxPreAdult)
                    maxPreAdult = c.PreArtAdultSymptomDirectTest;
                if (c.PedSymptomDirectTest > maxPed)
                    maxPed = c.PedSymptomDirectTest;
                if (c.PreArtPedSymptomDirectTest > maxPrePed)
                    maxPrePed = c.PreArtPedSymptomDirectTest;
                if (c.RepeatedDuetoClinicianRequest() > maxRepeat)
                    maxRepeat = c.RepeatedDuetoClinicianRequest();
            }
            result += (maxAdult + maxPed + maxPreAdult + maxPrePed + maxRepeat);
            return result;
        }

        public double TotalOtherSamplesWithinForecastPeriod{get;set;}
        public double TotalOtherSamplesWithinBufferStock{get;set;}
        public double TotalOtherSamples
        {
            get
            {
                return TotalOtherSamplesWithinForecastPeriod + TotalOtherSamplesWithinBufferStock;
            }
        }

    }

    public class OtherTestByPannel
    {
        private double _existingAdultPatientsinTreatment;
        private double _existingAdultPatientsinPreArt;
        private double _newAdultPatientstoTreatment;
        private double _newAdultPatientstoPreArt;

        private double _existingPedPatientsinTreatment;
        private double _existingPedPatientsinPreArt;
        private double _newPedPatientstoTreatment;
        private double _newPedPatientstoPreArt;

        private int _panelId;
        private double _syphilisRPR;
        private double _TBAFB;
        private double _HepatitisHBsAG;
        private double _HepatitisAntiHCV;
        private double _TBCulture;
        private double _TBDST;
        private double _PAPSmear;
        private double _genotypeResistanceTesting;

        public int PanelId
        {
            get { return _panelId; }
            set { _panelId = value; }
        }

        public double ExistingAdultPatientsinTreatment
        {
            get { return _existingAdultPatientsinTreatment; }
            set { _existingAdultPatientsinTreatment = value; }
        }
        public double ExistingAdultPatientsinPreArt
        {
            get { return _existingAdultPatientsinPreArt; }
            set { _existingAdultPatientsinPreArt = value; }
        }
        public double NewAdultPatientstoTreatment
        {
            get { return _newAdultPatientstoTreatment; }
            set { _newAdultPatientstoTreatment = value; }
        }
        public double NewAdultPatientstoPreArt
        {
            get { return _newAdultPatientstoPreArt; }
            set { _newAdultPatientstoPreArt = value; }
        }

        public double ExistingPedPatientsinTreatment
        {
            get { return _existingPedPatientsinTreatment; }
            set { _existingPedPatientsinTreatment = value; }
        }
        public double ExistingPedPatientsinPreArt
        {
            get { return _existingPedPatientsinPreArt; }
            set { _existingPedPatientsinPreArt = value; }
        }
        public double NewPedPatientstoTreatment
        {
            get { return _newPedPatientstoTreatment; }
            set { _newPedPatientstoTreatment = value; }
        }
        public double NewPedPatientstoPreArt
        {
            get { return _newPedPatientstoPreArt; }
            set { _newPedPatientstoPreArt = value; }
        }

        public double TotalTestAdultIntreatment()
        {
            return _existingAdultPatientsinTreatment + _newAdultPatientstoTreatment;
        }

        public double TotalTestPedIntreatment()
        {
            return _existingPedPatientsinTreatment + _newPedPatientstoTreatment;
        }
        private double TotalTestAdultInpreArt()
        {
            return _existingAdultPatientsinPreArt + _newAdultPatientstoPreArt;
        }
        public double TotalTestPedInpreArt()
        {
            return _existingPedPatientsinPreArt + _newPedPatientstoPreArt;
        }

        public double TotalTestsForRegimen()
        {
            return TotalTestAdultIntreatment() + TotalTestAdultInpreArt() + TotalTestPedIntreatment() + TotalTestPedInpreArt();
        }

        public double GetOtherTestValue(OtherTestNameEnum test)
        {
            double result = 0d;
            switch (test)
            {
                case OtherTestNameEnum.Genotype_Resistance_Testing:
                    result = _genotypeResistanceTesting;
                    break;
                case OtherTestNameEnum.Hepatitis_Anti_HCV:
                    result = _HepatitisAntiHCV;
                    break;
                case OtherTestNameEnum.Hepatitis_HBsAG:
                    result = _HepatitisHBsAG;
                    break;
                case OtherTestNameEnum.PAP_Smear:
                    result = _PAPSmear;
                    break;
                case OtherTestNameEnum.Syphilis_RPR:
                    result = _syphilisRPR;
                    break;
                case OtherTestNameEnum.TB_AFB:
                    result = _TBAFB;
                    break;
                case OtherTestNameEnum.TB_Culture:
                    result = _TBCulture;
                    break;
                case OtherTestNameEnum.TB_DST:
                    result = _TBDST;
                    break;
            }
            return result;
        }

        public void SetOtherTestValue(OtherTestNameEnum test, double value)
        {
            switch (test)
            {
                case OtherTestNameEnum.Genotype_Resistance_Testing:
                    _genotypeResistanceTesting = value;
                    break;
                case OtherTestNameEnum.Hepatitis_Anti_HCV:
                    _HepatitisAntiHCV = value;
                    break;
                case OtherTestNameEnum.Hepatitis_HBsAG:
                    _HepatitisHBsAG = value;
                    break;
                case OtherTestNameEnum.PAP_Smear:
                    _PAPSmear = value;
                    break;
                case OtherTestNameEnum.Syphilis_RPR:
                    _syphilisRPR = value;
                    break;
                case OtherTestNameEnum.TB_AFB:
                    _TBAFB = value;
                    break;
                case OtherTestNameEnum.TB_Culture:
                    _TBCulture = value;
                    break;
                case OtherTestNameEnum.TB_DST:
                    _TBDST = value;
                    break;
            }
        }

        
    }

    public class OtherSymptomDirectedTest
    {
        private OtherTestNameEnum _testName;

        private double _adultSymptomDirectTest = 0d;
        private double _pedSymptomDirectTest = 0d;
        private double _preArtAdultSymptomDirectTest = 0d;
        private double _preArtPedSymptomDirectTest = 0d;

        //private double _repeatsDuetoClinicianRequest = 0d;
        private double _testConducted = 0d;
        private double _repeatPercent = 0d;
        private double _totalTest = 0d;
        
        private double _testsforBufferStock = 0d;       
        private double _additionalTestsdueToWastage = 0;
        private double _additionalTestsdueToWastageBeyondForecast = 0;
        private double _testsforBufferStockBeyondForecast = 0;
        private double _testsReceivedFromReferringSitesBeyondForecast = 0;

        public OtherTestNameEnum TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }

        public double AdultSymptomDirectTest
        {
            get { return _adultSymptomDirectTest; }
            set { _adultSymptomDirectTest = value; }
        }

        public double PedSymptomDirectTest
        {
            get { return _pedSymptomDirectTest; }
            set { _pedSymptomDirectTest = value; }
        }

        public double PreArtAdultSymptomDirectTest
        {
            get { return _preArtAdultSymptomDirectTest; }
            set { _preArtAdultSymptomDirectTest = value; }
        }

        public double PreArtPedSymptomDirectTest
        {
            get { return _preArtPedSymptomDirectTest; }
            set { _preArtPedSymptomDirectTest = value; }
        }

        public double TestConducted
        {
            get { return _testConducted; }
            set { _testConducted = value; }
        }

        public double RepeatPercent
        {
            get { return _repeatPercent; }
            set { _repeatPercent = value; }
        }

        public double RepeatedDuetoClinicianRequest()
        {
            return TestConducted * RepeatPercent;
        }

        public double TotalSymptomDirectTest()
        {
            return AdultSymptomDirectTest + PedSymptomDirectTest + PreArtAdultSymptomDirectTest + PreArtPedSymptomDirectTest;
        }

        public double SumOfSymptomDirectTestAndRDClinicianRequest()
        {
            return TotalSymptomDirectTest() + RepeatedDuetoClinicianRequest();
        }
        public double TotalTest
        {
            get { return _totalTest; }
            set { _totalTest = value; }
        }

        public double TestsforBufferStock
        {
            get { return _testsforBufferStock; }
            set { _testsforBufferStock = value; }
        }

        public double GetCalculatedTotalTest()
        {
            return TestConducted + TotalSymptomDirectTest() + RepeatedDuetoClinicianRequest();
        }

        public double AdditionalTestsdueToWastage
        {
            get { return _additionalTestsdueToWastage; }
            set {_additionalTestsdueToWastage = value; }
        }
        public double AdditionalTestsdueToWastageBeyondForecast
        {
            get { return _additionalTestsdueToWastageBeyondForecast; }
            set { _additionalTestsdueToWastageBeyondForecast = value; }
        }
        public double TestsforBufferStockBeyondForecast
        {
            get { return _testsforBufferStockBeyondForecast; }
            set { _testsforBufferStockBeyondForecast = value; }
        }
        public double TestsReceivedFromReferringSitesBeyondForecast
        {
            get { return _testsReceivedFromReferringSitesBeyondForecast; }
            set { _testsReceivedFromReferringSitesBeyondForecast = value; }
        }

        public double SubtotalOfTestBasedonProtocol
        {
            get { return TotalTest + AdditionalTestsdueToWastage; }
        }

        public double SubtotalOfTestForBufferStock
        {
            get { return TestsforBufferStock + AdditionalTestsdueToWastageBeyondForecast; }
        }

        public double TestsReferredtoAnotherFacility
        {
            get { return SubtotalOfTestBasedonProtocol + SubtotalOfTestForBufferStock; }
        }
    }

   
}
