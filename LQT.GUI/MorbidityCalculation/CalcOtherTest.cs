
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
    public class CalcOtherTest : BaseCalc
    {
        private double _othrRepeatsduetoClinicianRequest;
        private double _othAdditionalTestsDuetoWastage;

        private IDictionary<int, QuantifyedReagent> _chemReagents = new Dictionary<int, QuantifyedReagent>();
        private IDictionary<int, MOutputOtherTest> _othMonthlyOutputs = new Dictionary<int, MOutputOtherTest>();

        private PlatformQuantifyObject _platformObject;
        

        public CalcOtherTest(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target)
            : base(site, forecast, periodinfo, target)
        {
            _lstPrimaryQuanReagents = new ListOfPrimeryQR(ClassOfMorbidityTestEnum.OtherTest);
        }

        public Dictionary<int, CalculatedSitePatientNumber> CalculatedPatientNos { get; set; }
        public PlatformQuantifyObject OtherTestPlatformQuantifyObject
        {
            set { _platformObject = value; }
        }
        public CalcConsumable CalculatedConsumable { get; set; }

        public void DoCalculation()
        {
            CalculateOtherTest();
            DoQuantification();
        }

        private void CalculateOtherTest()
        {
            _othrRepeatsduetoClinicianRequest = (OtherTestProtocol.TestReapeated / 100d);
            _othAdditionalTestsDuetoWastage = (InvAssumption.OtherTests / 100d);

            for (int i = 1; i <= 12; i++)
            {
                MOutputOtherTest otherOut = new MOutputOtherTest();
                otherOut.Month = i;

                foreach (PSymptomDirectedTest sdt in OtherTestProtocol.SymptomDirectedTests)
                {
                    OtherSymptomDirectedTest csdt = new OtherSymptomDirectedTest();
                    csdt.TestName = sdt.OtherTestNameToEnum;
                    csdt.AdultSymptomDirectTest = (CurrentAdultinTreatment * (sdt.AdultInTreatmeant/100d)) / 12d;
                    csdt.PedSymptomDirectTest = (CurrentPediatricinTreatment * (sdt.PediatricInTreatmeant/100d)) / 12d;
                    csdt.PreArtAdultSymptomDirectTest = (CurrentAdultinPreArt * (sdt.AdultPreART/100d)) / 12d;
                    csdt.PreArtPedSymptomDirectTest = (CurrentPediatricinPreArt * (sdt.PediatricPreART / 100d)) / 12d;
                    csdt.RepeatPercent = _othrRepeatsduetoClinicianRequest;

                    otherOut.OtherSymptomDirectedTest.Add(csdt);
                }

                foreach (ProtocolPanel panel in OtherTestProtocol.ProtocolPanels)
                {
                    OtherTestByPannel othpanel = new OtherTestByPannel();

                    othpanel.ExistingAdultPatientsinTreatment = CalculatedPatientNos[i].ArtAdultPreExistingPatients * panel.AdultInTreatmentDistribution;
                    othpanel.ExistingPedPatientsinTreatment = CalculatedPatientNos[i].ArtPediatricPreExistingPatients * panel.PediatricInTreatmentDistribution;
                    othpanel.ExistingAdultPatientsinPreArt = CalculatedPatientNos[i].PreArtAdultPreExistingPatients * panel.AdultPreARTDistribution;
                    othpanel.ExistingPedPatientsinPreArt = CalculatedPatientNos[i].PreArtPediatricPreExistingPatients * panel.PediatricPreARTDistribution;

                    for (int x = 1, y = i; x <= i; x++, y--)
                    {
                        othpanel.NewAdultPatientstoTreatment += CalculatedPatientNos[i].GetArtAdultPatientsEntering(x) * panel.AdultArtTestGivenInMonth(y) * (panel.AITNewPatient/100d);
                        othpanel.NewPedPatientstoTreatment += CalculatedPatientNos[i].GetArtPediatricPatientsEntering(x) * panel.AdultPreArtTestGivenInMonth(y) * (panel.PITNewPatient/100d);
                        othpanel.NewAdultPatientstoPreArt += CalculatedPatientNos[i].GetPreArtAdultPatientsEntering(x) * panel.PediatricArtTestGivenInMonth(y) * (panel.APARTNewPatient/100d);
                        othpanel.NewPedPatientstoPreArt += CalculatedPatientNos[i].GetPreArtPediatricPatientsEntering(x) * panel.PediatricPreArtTestGivenInMonth(y) * (panel.PPARTNewPatient / 100d);
                    }

                    OtherTestNameEnum[] othtest = LqtUtil.EnumToArray<OtherTestNameEnum>();

                    for (int x = 0; x < othtest.Length;x++ ) //PSymptomDirectedTest sdt in OtherTestProtocol.SymptomDirectedTests
                    {
                        double tconducted = 0d;
                        if (panel.IsOtherTestSelected(othtest[x]))
                        {
                            tconducted = othpanel.TotalTestsForRegimen();
                        }
                        othpanel.SetOtherTestValue(othtest[x], tconducted);
                        otherOut.GetOtherSymptomDirectedTestById(othtest[x]).TestConducted += tconducted;
                    }
                    otherOut.OtherTestByPanel.Add(othpanel);
                }

                _othMonthlyOutputs.Add(i, otherOut);
            }

            double adultPatientEnterPerMonth = 0d;
            double pedPatientEnterPerMonth = 0d;
            double preAdultPatientEnterPerMonth = 0d;
            double prePedPatientEnterPerMonth = 0d;

            foreach (PSymptomDirectedTest sdt in OtherTestProtocol.SymptomDirectedTests)
            {
                for (int i = 1; i <= 12; i++)
                {
                    OtherSymptomDirectedTest csdt = _othMonthlyOutputs[i].GetOtherSymptomDirectedTestById(sdt.OtherTestNameToEnum);
                    adultPatientEnterPerMonth = (CalculatedPatientNos[i].GetArtAdultPatientsEntering(i) * (sdt.AdultInTreatmeant / 100d)) / 12d;
                    csdt.AdultSymptomDirectTest += adultPatientEnterPerMonth;
                    pedPatientEnterPerMonth = (CalculatedPatientNos[i].GetArtPediatricPatientsEntering(i) * (sdt.PediatricInTreatmeant / 100d)) / 12d;
                    csdt.PedSymptomDirectTest += pedPatientEnterPerMonth;

                    preAdultPatientEnterPerMonth = (CalculatedPatientNos[i].GetPreArtAdultPatientsEntering(i) * (sdt.AdultPreART / 100d)) / 12d;
                    csdt.PreArtAdultSymptomDirectTest += preAdultPatientEnterPerMonth;
                    prePedPatientEnterPerMonth = (CalculatedPatientNos[i].GetPreArtPediatricPatientsEntering(i) * (sdt.PediatricPreART / 100d)) / 12d;
                    csdt.PreArtPedSymptomDirectTest += prePedPatientEnterPerMonth;

                    for (int x = i + 1; x <= 12; x++)
                    {
                        OtherSymptomDirectedTest ct = _othMonthlyOutputs[x].GetOtherSymptomDirectedTestById(sdt.OtherTestNameToEnum);
                        ct.AdultSymptomDirectTest += adultPatientEnterPerMonth;
                        ct.PedSymptomDirectTest += pedPatientEnterPerMonth;
                        ct.PreArtAdultSymptomDirectTest += preAdultPatientEnterPerMonth;
                        ct.PreArtPedSymptomDirectTest += prePedPatientEnterPerMonth;
                    }

                    if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        csdt.TotalTest = csdt.GetCalculatedTotalTest();
                    if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        csdt.TestsforBufferStock = csdt.GetCalculatedTotalTest();

                    csdt.AdditionalTestsdueToWastage = csdt.TotalTest * _othAdditionalTestsDuetoWastage;
                    csdt.AdditionalTestsdueToWastageBeyondForecast = csdt.TestsforBufferStock * _othAdditionalTestsDuetoWastage;
                }
            }

            for (int i = 1; i <= 12; i++)
            {
                if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                    _othMonthlyOutputs[i].TotalOtherSamplesWithinForecastPeriod = _othMonthlyOutputs[i].GetSumOfTotalOtherSamples();
                else
                    _othMonthlyOutputs[i].TotalOtherSamplesWithinForecastPeriod = 0d;
                if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                    _othMonthlyOutputs[i].TotalOtherSamplesWithinBufferStock = _othMonthlyOutputs[i].GetSumOfTotalOtherSamples();
                else
                    _othMonthlyOutputs[i].TotalOtherSamplesWithinBufferStock = 0d;
            }

           
        }

        private double TotalSamplesBeyoundForecast()
        {
            return _othMonthlyOutputs[12].GetSumOfTotalOtherSamples() * PeriodInfo.NumberofBufferMonthsBeyondForecast;
        }

        private double BufferTestBeyondForecast(OtherTestNameEnum test)
        {
            return _othMonthlyOutputs[12].GetSumOfOtherTest(test) * PeriodInfo.NumberofBufferMonthsBeyondForecast;
        }

        private double SubtotalBufferTestBeyondForecast(OtherTestNameEnum test)
        {
            double sum = BufferTestBeyondForecast(test);
            return sum + (sum * _othAdditionalTestsDuetoWastage);
        }
               
        private void DoQuantification()
        {
            //DOES THIS SITE RECEIVE Chemistry SUPPLIES?
            if (ArtSite.ForecastOtherTest)
            {
                double value;

                foreach (QuantifyMenu qm in _platformObject.GeneralQuantifyMenus)
                {
                    value = 0;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Syphilis_RPR_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.Syphilis_RPR);
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_TB_AFB_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.TB_AFB);
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Hepatitis_HBsAG_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.Hepatitis_HBsAG);
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Hepatitis_Anti_HCV_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.Hepatitis_Anti_HCV);
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_TB_Culture_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.TB_Culture);
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_TB_DST_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.TB_DST);
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_PAP_Smear_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.PAP_Smear);
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Genotype_Resistance_Testing_Test.ToString())
                        value = GetSumofTest(OtherTestNameEnum.Genotype_Resistance_Testing);
                    if (value > 0)
                    {
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = qm.Id;
                        qval.SiteValue = value;
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);
                    }
                }

                double testperpack;
                foreach (QMenuWithValue qm in _listOfQMenuWithValue)
                {
                    IList<QuantificationMetric> list = _platformObject.GetQuanMetricByQuanMenuId(qm.QuantifyMenuId);
                    foreach (QuantificationMetric r in list)
                    {
                        PrimeryQuantifyedReagent pqr = new PrimeryQuantifyedReagent();
                        pqr.ProductId = r.Product.Id;
                        pqr.UnitCost = r.Product.GetActiveProductPrice(DateTime.Now).Price;
                        pqr.PackSize = r.Product.GetActiveProductPrice(DateTime.Now).PackSize;
                        pqr.Unit = r.Product.BasicUnit;

                        testperpack = r.Product.GetActiveProductPrice(DateTime.Now).PackSize / r.UsageRate;
                        pqr.Value = testperpack > 0 ? qm.TotalValue / testperpack : 0;
                        pqr.MinimumQuantity = r.Product.MinimumPackSize;
                        _lstPrimaryQuanReagents.AddPrimeryQR(pqr);
                    }
                }
            }
        }

        private double GetSumofTest(OtherTestNameEnum testname)
        {
            double result = 0d;
            for (int i = 1; i <= 12; i++)
            {
                result += _othMonthlyOutputs[i].GetOtherSymptomDirectedTestById(testname).TestsReferredtoAnotherFacility;
                
            }
            result += SubtotalBufferTestBeyondForecast(testname);
            return result;
        }

        private IList<ChemandOtherNumberofTest> _othtestNumber;
        public IList<ChemandOtherNumberofTest> GetOtherTestNumber()
        {
            _othtestNumber = new List<ChemandOtherNumberofTest>();
            if (ArtSite.ForecastOtherTest)
            {
                foreach (PSymptomDirectedTest sdt in OtherTestProtocol.SymptomDirectedTests)
                {
                    ChemandOtherNumberofTest ct = new ChemandOtherNumberofTest();
                    ct.ForecastId = Forecast.Id;
                    ct.SiteId = ArtSite.Site.Id;
                    ct.Platform = (int)ClassOfMorbidityTestEnum.OtherTest;
                    //ct.TestId = sdt.Test.Id;
                    ct.TestName = sdt.OtherTestName;

                    for (int i = 1; i <= 12; i++)
                    {
                        OtherSymptomDirectedTest csdt = _othMonthlyOutputs[i].GetOtherSymptomDirectedTestById(sdt.OtherTestNameToEnum);
                        ct.InvalidTestandWastage += csdt.AdditionalTestsdueToWastage;
                        
                        if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        {
                            ct.TestBasedOnProtocols += csdt.TestConducted; //_othMonthlyOutputs[i].GetSumOfOtherTest(sdt.OtherTestNameToEnum); 
                            ct.SymptomDirectedTests += csdt.TotalSymptomDirectTest();
                            ct.RepeatedDuetoClinicalReq += (csdt.TestConducted + csdt.TotalSymptomDirectTest()) *_othrRepeatsduetoClinicianRequest;
                        }

                        ct.BufferStock += csdt.SubtotalOfTestForBufferStock;
                    }

                    _othtestNumber.Add(ct);
                }
            }
            return _othtestNumber;
        }
    }
}
