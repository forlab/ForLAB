
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
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class CalcChemistryTest : BaseCalc
    {
        private double _chemRepeatsduetoClinicianRequest;
        private double _chemAdditionalTestsDuetoWastage;
        private double TotalPatientSamples = 0;
        private double TotalControls = 0;
        private double TotalALT = 0;
        private double TotalAST = 0;
        private double TotalCHO = 0;
        private double TotalGLC = 0;
        private double TotalCRE = 0;
        private double TotalTG = 0;
        private double TotalGGT = 0;
        private double TotalALP = 0;
        private double TotalAMY = 0;
        private double TotalCO2 = 0;
        private double TotalElectrolyte = 0;
        private double TotalUrea = 0;

        private IDictionary<int, MOutputChemistryTest> _chemMonthlyOutputs = new Dictionary<int, MOutputChemistryTest>();
        private IList<ChemistryPlatformTests> _chemPlatformTests = new List<ChemistryPlatformTests>();
        private PlatformQuantifyObject _platformObject;
        private ClassOfChemistryTests _testsReceivedFromReferringSitesBeyondForecast;

        public CalcChemistryTest(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target)
            : base(site, forecast, periodinfo, target)
        {
            _lstPrimaryQuanReagents = new ListOfPrimeryQR(ClassOfMorbidityTestEnum.Chemistry);
        }
        
        public Dictionary<int, CalculatedSitePatientNumber> CalculatedPatientNos { get; set; }
        public PlatformQuantifyObject ChemistryPlatformQuantifyObject
        {
            set { _platformObject = value; }
        }

        public IDictionary<int, MOutputChemistryTest> GetChemistryTestOutputs
        {
            get { return _chemMonthlyOutputs; }
        }

        public void DoCalculation()
        {
            CalcInstrumentDetailsAndControls();
            DoQuantification();
        }

        public void CalculateTestConducted()
        {
            CalculateChemistryTestConducted();
        }

        private void CalculateChemistryTestConducted()
        {
            _chemRepeatsduetoClinicianRequest = (ChemTestProtocol.TestReapeated / 100d);
            _chemAdditionalTestsDuetoWastage = (InvAssumption.Chemistry / 100d);

            for (int i = 1; i <= 12; i++)
            {
                MOutputChemistryTest chemOut = new MOutputChemistryTest();
                chemOut.Month = i;

                foreach (PSymptomDirectedTest sdt in ChemTestProtocol.SymptomDirectedTests)
                {
                    ChemistrySymptomDirectedTest csdt = new ChemistrySymptomDirectedTest();
                    csdt.TestName = sdt.ChemTestNameToEnum;
                    csdt.AdultSymptomDirectTest = (CurrentAdultinTreatment * (sdt.AdultInTreatmeant / 100d)) / 12d;
                    csdt.PedSymptomDirectTest = (CurrentPediatricinTreatment * (sdt.PediatricInTreatmeant / 100d)) / 12d;
                    csdt.PreArtAdultSymptomDirectTest = (CurrentAdultinPreArt * (sdt.AdultPreART / 100d)) / 12d;
                    csdt.PreArtPedSymptomDirectTest = (CurrentPediatricinPreArt * (sdt.PediatricPreART / 100d)) / 12d;
                    csdt.RepeatPercent = _chemRepeatsduetoClinicianRequest;

                    chemOut.ChemSymptomDirectedTest.Add(csdt);
                }

                foreach (ProtocolPanel panel in ChemTestProtocol.ProtocolPanels)
                {
                    ChemistryTestByPannel chemp = new ChemistryTestByPannel();

                    chemp.ExistingAdultPatientsinTreatment = CalculatedPatientNos[i].ArtAdultPreExistingPatients * panel.AdultInTreatmentDistribution;
                    chemp.ExistingPedPatientsinTreatment = CalculatedPatientNos[i].ArtPediatricPreExistingPatients * panel.PediatricInTreatmentDistribution; // ((pediatricsinTreatment / 12d) * preExistingPatientsonPanel);
                    chemp.ExistingAdultPatientsinPreArt = CalculatedPatientNos[i].PreArtAdultPreExistingPatients * panel.AdultPreARTDistribution;
                    chemp.ExistingPedPatientsinPreArt = CalculatedPatientNos[i].PreArtPediatricPreExistingPatients * panel.PediatricPreARTDistribution;

                    for (int x = 1, y = i; x <= i; x++, y--)
                    {
                        chemp.NewAdultPatientstoTreatment += CalculatedPatientNos[i].GetArtAdultPatientsEntering(x) * panel.AdultArtTestGivenInMonth(y) * (panel.AITNewPatient/100d);
                        chemp.NewPedPatientstoTreatment += CalculatedPatientNos[i].GetArtPediatricPatientsEntering(x) * panel.PediatricArtTestGivenInMonth(y) * (panel.PITNewPatient/100d);
                        chemp.NewAdultPatientstoPreArt += CalculatedPatientNos[i].GetPreArtAdultPatientsEntering(x) * panel.AdultPreArtTestGivenInMonth(y) * (panel.APARTNewPatient/100d);
                        chemp.NewPedPatientstoPreArt += CalculatedPatientNos[i].GetPreArtPediatricPatientsEntering(x) * panel.PediatricPreArtTestGivenInMonth(y) * (panel.PPARTNewPatient/100d);
                    }

                    ChemistryTestNameEnum[] chemtest = LqtUtil.EnumToArray<ChemistryTestNameEnum>();

                    for (int z = 0; z < chemtest.Length; z++)
                    {
                        double tconducted = 0d;
                        if (panel.IsChemTestSelected(chemtest[z]))
                        {
                            tconducted = chemp.TotalTestsForRegimen();
                        }
                        chemp.SetChemTestValue(chemtest[z], tconducted);
                        if (chemOut.GetChemSymptomDirectedTestById(chemtest[z]) != null)
                            chemOut.GetChemSymptomDirectedTestById(chemtest[z]).TestConducted += tconducted;
                    }
                    chemOut.ChemTestByPanel.Add(chemp);
                }

                _chemMonthlyOutputs.Add(i, chemOut);
            }

            double adultPatientEnterPerMonth = 0d;
            double pedPatientEnterPerMonth = 0d;
            double preAdultPatientEnterPerMonth = 0d;
            double prePedPatientEnterPerMonth = 0d;

            foreach (PSymptomDirectedTest sdt in ChemTestProtocol.SymptomDirectedTests)
            {
                for (int i = 1; i <= 12; i++)
                {
                    ChemistrySymptomDirectedTest csdt = _chemMonthlyOutputs[i].GetChemSymptomDirectedTestById(sdt.ChemTestNameToEnum);
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
                        ChemistrySymptomDirectedTest ct = _chemMonthlyOutputs[x].GetChemSymptomDirectedTestById(sdt.ChemTestNameToEnum);
                        ct.AdultSymptomDirectTest += adultPatientEnterPerMonth;
                        ct.PedSymptomDirectTest += pedPatientEnterPerMonth;
                        ct.PreArtAdultSymptomDirectTest += preAdultPatientEnterPerMonth;
                        ct.PreArtPedSymptomDirectTest += prePedPatientEnterPerMonth;
                    }

                    if (1 >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        csdt.TestBasedonProtocol = csdt.GetCalculatedTotalTest();
                    if (1 >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        csdt.TestsforBufferStock = csdt.GetCalculatedTotalTest();

                    csdt.AdditionalTestsdueToWastage = csdt.TestBasedonProtocol * _chemAdditionalTestsDuetoWastage;
                    csdt.AdditionalTestsdueToWastageBeyondForecast = csdt.TestsforBufferStock * _chemAdditionalTestsDuetoWastage;
                }
            }

            for (int i = 2; i <= 13; i++)
            {
                if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                    _chemMonthlyOutputs[i - 1].TotalChemistrySamplesWithinForecastPeriod = _chemMonthlyOutputs[i - 1].GetSumOfTotalChemistrySamples();
                else
                    _chemMonthlyOutputs[i - 1].TotalChemistrySamplesWithinForecastPeriod = 0d;
                if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                    _chemMonthlyOutputs[i - 1].TotalChemistrySamplesWithinBufferStock = _chemMonthlyOutputs[i - 1].GetSumOfTotalChemistrySamples();
                else
                    _chemMonthlyOutputs[i - 1].TotalChemistrySamplesWithinBufferStock = 0d;
            }

        }
        /// <summary>
        /// sample referral
        /// </summary>
        /// <param name="result"></param>
        public void SetTestsReceivedFromReferringSites(ClassOfChemistryTests[] result)
        {
            ChemistryTestNameEnum[] chemTests = LqtUtil.EnumToArray<ChemistryTestNameEnum>();

            for (int i = 1; i <= 12; i++)
            {
                for (int x = 0; x < chemTests.Length; x++)
                {
                    ChemistrySymptomDirectedTest csdt = _chemMonthlyOutputs[i].GetChemSymptomDirectedTestById(chemTests[x]);
                    if ((i + 1) >= PeriodInfo.FirstMonth && (i + 1) <= PeriodInfo.LastMonth)
                        csdt.TestsonInstrumentForecastPeriodFromReferringSites = result[i - 1].GetChemTestValue(chemTests[x]);

                    if ((i + 1) > PeriodInfo.LastMonth)
                        csdt.TestsonInstrumentBufferStockFromReferringSites = result[i - 1].GetChemTestValue(chemTests[x]);
                }

                if ((i + 1) >= PeriodInfo.FirstMonth && (i + 1) <= PeriodInfo.LastMonth)
                    _chemMonthlyOutputs[i].TotalSampleForecastPeriodRecivedFromReferrSites = result[i - 1].TotalSamples;
                if ((i + 1) > PeriodInfo.LastMonth)
                    _chemMonthlyOutputs[i].TotalSampleBufferStockRecivedFromReferrSites = result[i - 1].TotalSamples;
            }

            _testsReceivedFromReferringSitesBeyondForecast = result[12];
        }

        private void CalcInstrumentDetailsAndControls()
        {
            int noofControls;
            int noofTestdays = ArtSite.Site.ChemistryTestingDaysPerMonth;
            double testRunpercent;
            double controlTest = 0;

            foreach (SiteInstrument ins in ArtSite.Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.Chemistry))
            {
                ChemistryPlatformTests chemPlat = new ChemistryPlatformTests();
                chemPlat.InstrumentId = ins.Instrument.Id;
                chemPlat.Quantity = ins.Quantity;
                testRunpercent = Convert.ToDouble(ins.TestRunPercentage) / 100d;

                int currentQuarter = PeriodInfo.FirstMonth;

                for (int i = 1; i <= 12; i++)
                {
                    ChemistryTestsAndControls ctc = new ChemistryTestsAndControls(i);
                    foreach (ChemistrySymptomDirectedTest csdt in _chemMonthlyOutputs[i].ChemSymptomDirectedTest)
                    {
                        ChemistryTestOnInstrument cti = new ChemistryTestOnInstrument();
                        cti.TestName = csdt.TestName;
                        cti.TestsonInstrumentForecastPeriod = csdt.SubtotalOfTestBasedonProtocol* testRunpercent;
                        cti.TestsonInstrumentBufferStock = csdt.SubtotalOfTestForBufferStock * testRunpercent;

                        //Samples Referred from Elsewhere
                        cti.SampleReferredTestsForecastPeriod = csdt.TestsonInstrumentForecastPeriodFromReferringSites * testRunpercent;
                        cti.SampleReferredTestsBufferStock = csdt.TestsonInstrumentBufferStockFromReferringSites * testRunpercent;

                        ctc.ChemTestsOnInstrument.Add(cti);
                    }

                    noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
                    if (noofControls > 0)
                    {
                        ctc.ControlsPerNoOfTests = (_chemMonthlyOutputs[i].TotalChemistrySamplesWithinForecastPeriod / noofControls);
                        ctc.ControlsPerNoOfTestsBuffer = (_chemMonthlyOutputs[i].TotalChemistrySamplesWithinBufferStock / noofControls);
                    }

                    noofControls = ins.Instrument.DailyCtrlTest;
                    controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * ins.Quantity) * noofTestdays;
                    if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        ctc.ControlsPerDay = controlTest;
                    if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        ctc.ControlsPerDayBuffer = controlTest;

                    noofControls = ins.Instrument.WeeklyCtrlTest;
                    controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * ins.Quantity) * 4;
                    if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        ctc.ControlsPerWeek = controlTest;
                    if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        ctc.ControlsPerWeekBuffer = controlTest;

                    noofControls = ins.Instrument.MonthlyCtrlTest;
                    controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * ins.Quantity) * 1;
                    if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        ctc.ControlsPerMonth = controlTest;
                    if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        ctc.ControlsPerMonthBuffer = controlTest;

                    noofControls = ins.Instrument.QuarterlyCtrlTest;
                    controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * ins.Quantity);
                    if (i == currentQuarter)
                    {
                        currentQuarter += 3;
                        if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                            ctc.ControlsPerQuarter = controlTest;
                        if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                            ctc.ControlsPerQuarterBuffer = controlTest;
                    }

                    ctc.TotalSamplesFP = _chemMonthlyOutputs[i].TotalChemistrySamplesWithinForecastPeriod * testRunpercent;
                    ctc.TotalSamplesBS = _chemMonthlyOutputs[i].TotalChemistrySamplesWithinBufferStock * testRunpercent;

                    ctc.SampleReferredTotalSamplesFP = _chemMonthlyOutputs[i].TotalSampleForecastPeriodRecivedFromReferrSites * testRunpercent;
                    ctc.SampleReferredTotalSamplesBS = _chemMonthlyOutputs[i].TotalSampleBufferStockRecivedFromReferrSites * testRunpercent;

                    noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
                    if (noofControls > 0)
                    {
                        ctc.SampleReferredControlsPerNoOfTests = _chemMonthlyOutputs[i].TotalSampleForecastPeriodRecivedFromReferrSites / noofControls;
                        ctc.SampleReferredControlsPerNoOfTestsBuffer = _chemMonthlyOutputs[i].TotalSampleBufferStockRecivedFromReferrSites / noofControls;
                    }
                    chemPlat.AddTestAndControl(ctc);
                }

                chemPlat.AddTestAndControl(DoByondForcastCalc(ins, noofTestdays, currentQuarter));
                _chemPlatformTests.Add(chemPlat);
            }
        }

        public double TotalChemistrySamplesBeyoundForecast()
        {
            return _chemMonthlyOutputs[12].GetSumOfTotalChemistrySamples() * PeriodInfo.NumberofBufferMonthsBeyondForecast;
        }

        public double BufferTestBeyondForecast(ChemistryTestNameEnum test)
        {
            return _chemMonthlyOutputs[12].GetSumOfChemTest(test) * PeriodInfo.NumberofBufferMonthsBeyondForecast;
        }

        public double SubtotalBufferTestBeyondForecast(ChemistryTestNameEnum test)
        {
            double sum = BufferTestBeyondForecast(test);
            return sum + (sum * _chemAdditionalTestsDuetoWastage);
        }

        private ChemistryTestsAndControls DoByondForcastCalc(SiteInstrument ins, int noofTestdays, int currentQuarter)
        {
            double testRunpercent = Convert.ToDouble(ins.TestRunPercentage) / 100d;
            ChemistryTestsAndControls ctc = new ChemistryTestsAndControls(13);
            foreach (ChemistrySymptomDirectedTest csdt in _chemMonthlyOutputs[12].ChemSymptomDirectedTest)
            {
                ChemistryTestOnInstrument cti = new ChemistryTestOnInstrument();
                cti.TestName = csdt.TestName;
                cti.TestsonInstrumentForecastPeriod = 0;
                cti.TestsonInstrumentBufferStock = SubtotalBufferTestBeyondForecast(csdt.TestName) * testRunpercent;

                //Samples Referred from Elsewhere
                cti.SampleReferredTestsForecastPeriod = 0;
                cti.SampleReferredTestsBufferStock = _testsReceivedFromReferringSitesBeyondForecast.GetChemTestValue(csdt.TestName) * testRunpercent; 

                ctc.ChemTestsOnInstrument.Add(cti);
            }

            double noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
            if (noofControls > 0)
            {
                ctc.ControlsPerNoOfTests = 0;
                ctc.ControlsPerNoOfTestsBuffer = (TotalChemistrySamplesBeyoundForecast() / noofControls);
            }

            noofControls = ins.Instrument.DailyCtrlTest;
            double controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * testRunpercent) * noofTestdays;
            ctc.ControlsPerDay = 0;
            ctc.ControlsPerDayBuffer = controlTest * PeriodInfo.NumberofBufferMonthsBeyondForecast;

            noofControls = ins.Instrument.WeeklyCtrlTest;
            controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * testRunpercent) * 4;
            ctc.ControlsPerWeek = 0;
            ctc.ControlsPerWeekBuffer = controlTest * PeriodInfo.NumberofBufferMonthsBeyondForecast;

            noofControls = ins.Instrument.MonthlyCtrlTest;
            controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * testRunpercent) * 1;
            ctc.ControlsPerMonth = 0;
            ctc.ControlsPerMonthBuffer = controlTest * PeriodInfo.NumberofBufferMonthsBeyondForecast;

            noofControls = ins.Instrument.QuarterlyCtrlTest;
            controlTest = ((noofControls / (1 - _chemAdditionalTestsDuetoWastage)) * testRunpercent);

            int quarter = 0;
            if (currentQuarter == 12)
                quarter = 2;
            else if (currentQuarter == 11)
                quarter = 1;
            else if (currentQuarter == 10)
                quarter = 0;

            ctc.ControlsPerQuarter = 0;
            ctc.ControlsPerQuarterBuffer = ((PeriodInfo.NumberofBufferMonthsBeyondForecast - quarter) / 3) * controlTest;

            ctc.TotalSamplesFP = 0;
            ctc.TotalSamplesBS = TotalChemistrySamplesBeyoundForecast() * testRunpercent;

            ctc.SampleReferredTotalSamplesFP = 0;
            ctc.SampleReferredTotalSamplesBS = _testsReceivedFromReferringSitesBeyondForecast.TotalSamples * testRunpercent;

            ctc.SampleReferredControlsPerNoOfTests = 0;
            noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
            if (noofControls > 0)
            {   
                ctc.SampleReferredControlsPerNoOfTestsBuffer = ctc.SampleReferredTotalSamplesBS / noofControls;
            }
            return ctc;
        }

        private void DoQuantification()
        {
            //DOES THIS SITE RECEIVE Chemistry SUPPLIES?
            if (ArtSite.ForecastChemistry)
            {
                InitTotalValues();
                int allChemQMid = 0;
                double value, allChemInsQty = 0;
                foreach (QuantifyMenu qm in _platformObject.GeneralQuantifyMenus)
                {
                    value = 0;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Chemistry_Patient_Samples_Run_On_All_Instruments.ToString())
                        value = TotalPatientSamples;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Chemistry_controls_for_all_instruments.ToString())
                        value = TotalControls;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_ALP_Tests_on_all_instruments.ToString())
                        value = TotalALP;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_ALT_Tests_on_all_instruments.ToString())
                        value = TotalALT;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_AMY_Tests_on_all_instruments.ToString())
                        value = TotalAMY;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_AST_Tests_on_all_instruments.ToString())
                        value = TotalAST;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_CHO_Tests_on_all_instruments.ToString())
                        value = TotalCHO;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_CO2_Tests_on_all_instruments.ToString())
                        value = TotalCO2;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_CRE_Tests_on_all_instruments.ToString())
                        value = TotalCRE;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Electrolyte_Panel_tests_on_all_instruments.ToString())
                        value = TotalElectrolyte;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_GGT_Tests_on_all_instruments.ToString())
                        value = TotalGGT;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_GLC_Tests_on_all_instruments.ToString())
                        value = TotalGLC;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_TG_Tests_on_all_instruments.ToString())
                        value = TotalTG;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Urea_tests_on_all_instruments.ToString())
                        value = TotalUrea;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Per_Instrument_All_Chemistry_Instruments.ToString())
                        allChemQMid = qm.Id;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Per_Day_All_Chemistry_Instruments.ToString() && _chemPlatformTests.Count > 0)
                        value = ArtSite.Site.ChemistryTestingDaysPerMonth * (PeriodInfo.NumberofBufferMonthsBeyondForecast + PeriodInfo.NumberofMonthsinBudgetPeriod);

                    if (value > 0)
                    {
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = qm.Id;
                        qval.SiteValue = value;
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);
                    }
                }

                ChemistryTestNameEnum[] chemTests = LqtUtil.EnumToArray<ChemistryTestNameEnum>();
                TestingDurationEnum[] tduration = LqtUtil.EnumToArray<TestingDurationEnum>();

                foreach(ChemistryPlatformTests cpt in _chemPlatformTests)
                {
                    allChemInsQty += cpt.Quantity;

                    CTestPlatformQuantifyMenu pqm = (CTestPlatformQuantifyMenu)_platformObject.GetPlatformQuantifyMenuByInsId(cpt.InstrumentId);
                    if (pqm != null)
                    {
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = pqm.TotalPatientSamplesRunOnIns;
                        qval.SiteValue = cpt.TotalSmaples();
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);

                        qval = new QMenuWithValue();
                        qval.QuantifyMenuId = pqm.GetQuantifyMenuId(TestTypeEnum.PerInstrument);
                        qval.SiteValue = cpt.Quantity;
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);

                        qval = new QMenuWithValue();
                        qval.QuantifyMenuId = pqm.GetQuantifyMenuId(TestTypeEnum.PerDay);
                        qval.SiteValue = ArtSite.Site.ChemistryTestingDaysPerMonth * (PeriodInfo.NumberofBufferMonthsBeyondForecast + PeriodInfo.NumberofMonthsinBudgetPeriod);
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);

                        for (int i = 0; i < chemTests.Length; i++)
                        {
                            if (ParameterIncluded(chemTests[i]))
                            {
                                qval = new QMenuWithValue();
                                qval.QuantifyMenuId = pqm.GetChemQuantifyMenuId(chemTests[i]);
                                qval.SiteValue = cpt.TotalTestsOnInstrument(chemTests[i]);
                                qval.ReferalSiteValue = 0;
                                _listOfQMenuWithValue.Add(qval);
                            }
                        }

                        for (int i = 0; i < tduration.Length; i++)
                        {
                            qval = new QMenuWithValue();
                            qval.QuantifyMenuId = pqm.GetQuantifyMenuId(tduration[i]);
                            qval.SiteValue = cpt.GetSumOfControlsByDuration(tduration[i]);
                            qval.ReferalSiteValue = 0;
                            _listOfQMenuWithValue.Add(qval);
                        }
                    }
                }

                //Per Instrument - All Chemistry Instruments
                QMenuWithValue qv = new QMenuWithValue();
                qv.QuantifyMenuId = allChemQMid;
                qv.SiteValue = allChemInsQty;
                qv.ReferalSiteValue = 0;
                _listOfQMenuWithValue.Add(qv);

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

                        double testperpack = r.Product.GetActiveProductPrice(DateTime.Now).PackSize / r.UsageRate;
                        double valueofmetric = r.CollectionSupplieAppliedTo == CollectionSupplieAppliedToEnum.Collection.ToString() ? qm.SiteValue : qm.TotalValue;
                        if (ArtSite.Site.ChemistryRefSite > 0 && r.CollectionSupplieAppliedTo == CollectionSupplieAppliedToEnum.Testing.ToString())
                            valueofmetric = 0;
                        pqr.Value = testperpack > 0 ? valueofmetric / testperpack : 0;
                        pqr.MinimumQuantity = r.Product.MinimumPackSize;
                        _lstPrimaryQuanReagents.AddPrimeryQR(pqr);
                    }
                }
            }
        }

        private void InitTotalValues()
        {
            if (ArtSite.Site.ChemistryRefSite == 0)
            {
                foreach (ChemistryPlatformTests cpt in _chemPlatformTests)
                {
                    TotalPatientSamples += cpt.TotalSmaples();
                    TotalControls += cpt.TotalControls();

                    if (ParameterIncluded(ChemistryTestNameEnum.ALT))
                        TotalALT += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.ALT);
                    if (ParameterIncluded(ChemistryTestNameEnum.AST))
                        TotalAST += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.AST);
                    if (ParameterIncluded(ChemistryTestNameEnum.CHO))
                        TotalCHO += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.CHO);
                    if (ParameterIncluded(ChemistryTestNameEnum.GLC))
                        TotalGLC += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.GLC);
                    if (ParameterIncluded(ChemistryTestNameEnum.CRE))
                        TotalCRE += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.CRE);
                    if (ParameterIncluded(ChemistryTestNameEnum.TG))
                        TotalTG += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.TG);
                    if (ParameterIncluded(ChemistryTestNameEnum.GGT))
                        TotalGGT += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.GGT);
                    if (ParameterIncluded(ChemistryTestNameEnum.ALP))
                        TotalALP += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.ALP);
                    if (ParameterIncluded(ChemistryTestNameEnum.AMY))
                        TotalAMY += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.AMY);
                    if (ParameterIncluded(ChemistryTestNameEnum.CO2))
                        TotalCO2 += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.CO2);
                    if (ParameterIncluded(ChemistryTestNameEnum.Electrolyte_Panel))
                        TotalElectrolyte += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.Electrolyte_Panel);
                    if (ParameterIncluded(ChemistryTestNameEnum.Urea))
                        TotalUrea += cpt.TotalTestsOnInstrument(ChemistryTestNameEnum.Urea);
                }

            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    MOutputChemistryTest moc = _chemMonthlyOutputs[i];
                    TotalPatientSamples += moc.TotalChemistrySamplesWithinForecastPeriod + moc.TotalChemistrySamplesWithinBufferStock;
                    TotalALT += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.ALT).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.ALT).TestsforBufferStock;
                    TotalAST += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.AST).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.AST).TestsforBufferStock;
                    TotalCHO += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.CHO).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.CHO).TestsforBufferStock;
                    TotalGLC += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.GLC).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.GLC).TestsforBufferStock;
                    TotalCRE += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.CRE).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.CRE).TestsforBufferStock;
                    TotalTG += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.TG).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.TG).TestsforBufferStock;
                    TotalGGT += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.GGT).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.GGT).TestsforBufferStock;
                    TotalALP += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.ALP).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.ALP).TestsforBufferStock;
                    TotalAMY += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.AMY).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.AMY).TestsforBufferStock;
                    TotalCO2 += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.CO2).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.CO2).TestsforBufferStock;
                    TotalElectrolyte += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.Electrolyte_Panel).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.Electrolyte_Panel).TestsforBufferStock;
                    TotalUrea += moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.Urea).TestBasedonProtocol + moc.GetChemSymptomDirectedTestById(ChemistryTestNameEnum.Urea).TestsforBufferStock;
                }
            }
        }

        private bool ParameterIncluded(ChemistryTestNameEnum testname)
        {
            foreach (ProtocolPanel pp in ChemTestProtocol.ProtocolPanels)
            {
                if (pp.IsChemTestSelected(testname))
                    return true;
            }

            PSymptomDirectedTest psdt = ChemTestProtocol.GetSymptomDirectedTestByTestName(testname);
            if (psdt != null)
                return psdt.SumOfSymptomDirected() > 0;

            return false;
        }

        private IList<ChemandOtherNumberofTest> _chemtestNumber;
        public IList<ChemandOtherNumberofTest> GetChemistryTestNumber()
        {
            _chemtestNumber = new List<ChemandOtherNumberofTest>();
            if (ArtSite.ForecastChemistry)
            {
                foreach (PSymptomDirectedTest sdt in ChemTestProtocol.SymptomDirectedTests)
                {
                    ChemandOtherNumberofTest ct = new ChemandOtherNumberofTest();
                    ct.ForecastId = Forecast.Id;
                    ct.SiteId = ArtSite.Site.Id;
                    ct.Platform = (int)ClassOfMorbidityTestEnum.Chemistry;
                    //ct.TestId = sdt.Test.Id;
                    ct.TestName = sdt.ChemTestName;

                    for (int i = 1; i <= 12; i++)
                    {
                        ChemistrySymptomDirectedTest csdt = _chemMonthlyOutputs[i].GetChemSymptomDirectedTestById(sdt.ChemTestNameToEnum);
                        ct.InvalidTestandWastage += csdt.AdditionalTestsdueToWastage;
                        ct.RepeatedDuetoClinicalReq += csdt.RepeatedDuetoClinicianRequest();
                        ct.SymptomDirectedTests += csdt.TotalSymptomDirectTest();
                        ct.TestBasedOnProtocols += _chemMonthlyOutputs[i].GetSumOfChemTest(sdt.ChemTestNameToEnum);
                        //ct.TestBasedOnProtocols += csdt.TestBasedonProtocol;
                    }

                    foreach (ChemistryPlatformTests ptc in  _chemPlatformTests)
                    {
                        if (ct.TestBasedOnProtocols > 0)
                        {
                            ct.ReagentstoRunControls += ptc.TotalControlsFP() + ptc.SampleReferredTotalControlsFP();
                            ct.BufferStock += ptc.TotalControlsBP() + ptc.SampleReferredTotalControlsBP();
                        }
                        else
                        {
                            ct.ReagentstoRunControls = 0;
                            ct.BufferStock += ptc.TotalControlsBP();
                        }
                    }
                    _chemtestNumber.Add(ct);
                }
            }
            return _chemtestNumber;
        }

    }
}
