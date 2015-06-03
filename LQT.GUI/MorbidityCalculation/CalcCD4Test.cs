
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
    public class CalcCD4Test : BaseCalc
    {
        private double _cd4AdultToFollowUpAfterDiagnosis;
        private double _cd4PediatricToFollowUpAfterDiagnosis;
        private double _cd4ThoseFollowUpToReciveCD4;
        private double _patientsRequiringOneSymptomDirectedTest;
        private double _cd4RepeatsduetoClinicianRequest;
        private double _cdAdditionalTestsDuetoWastage;
        private double _testsReceivedFromReferringSitesBeyondForecast = 0;
        private ProtocolPanel _cd4Panel;

        private IDictionary<int, MOutputCD4> _cd4MonthlyOutputs = new Dictionary<int, MOutputCD4>();
        private IList<PlatformTestsAndControls> _cd4PlatformTests = new List<PlatformTestsAndControls>();
        private PlatformQuantifyObject _platformObject;
        
        

        public CalcCD4Test(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target)
            : base(site, forecast, periodinfo, target)
        {
            _lstPrimaryQuanReagents = new ListOfPrimeryQR(ClassOfMorbidityTestEnum.CD4);
        }
        
        public Dictionary<int, CalculatedSitePatientNumber> CalculatedPatientNos { get; set; }
        public IDictionary<int, MOutputRapidTest> RapidTestOutputs { get; set; }
        
        public PlatformQuantifyObject CD4PlatformQuantifyObject
        {
            set { _platformObject = value; }
        }

        public IDictionary<int, MOutputCD4> GetCD4TestOutputs
        {
            get { return _cd4MonthlyOutputs; }
        }

        public void DoCalculation()
        {
            CalcInstrumentDetailsAndControls();
            DoQuantification();
        }

        public void CalculateTestConducted()
        {
            CalculateCD4TestConducted();
        }

        private void CalculateCD4TestConducted()
        {
            _cd4AdultToFollowUpAfterDiagnosis = 1 - (ArtSite.AdultDepartWoutFollowup / 100d);
            _cd4PediatricToFollowUpAfterDiagnosis = 1 - (ArtSite.PediatricDepartWoutFollowup / 100d);
            _cd4ThoseFollowUpToReciveCD4 = (ArtSite.DiagnosesReceiveCD4 / 100d);

            _patientsRequiringOneSymptomDirectedTest = (CD4TestProtocol.SymptomDirectedAmt / 100d);
            _cd4RepeatsduetoClinicianRequest = (CD4TestProtocol.TestReapeated / 100d);
            _cdAdditionalTestsDuetoWastage = (InvAssumption.CD4 / 100d);

            if (CD4TestProtocol.ProtocolPanels.Count > 0)
                _cd4Panel = (ProtocolPanel)CD4TestProtocol.ProtocolPanels[0];
            else
                _cd4Panel = new ProtocolPanel();

            for (int i = 1; i <= 12; i++)
            {
                MOutputCD4 cd4out = new MOutputCD4();
                cd4out.Month = i;
                cd4out.AdultReceivingCD4Test = RapidTestOutputs[i].AdultsPositiveDiagnoses * _cd4AdultToFollowUpAfterDiagnosis * _cd4ThoseFollowUpToReciveCD4;
                cd4out.PedReceivingCD4Test = RapidTestOutputs[i].PediatricsPositiveDiagnoses * _cd4PediatricToFollowUpAfterDiagnosis * _cd4ThoseFollowUpToReciveCD4;

                cd4out.ExistingAdultPatientsinTreatment = CalculatedPatientNos[i].ArtAdultPreExistingPatients * (_cd4Panel.AITTestperYear / 12d);
                cd4out.ExistingPedPatientsinTreatment = CalculatedPatientNos[i].ArtPediatricPreExistingPatients * (_cd4Panel.PITTestperYear / 12d);
                cd4out.ExistingAdultPatientsinPreArt = CalculatedPatientNos[i].PreArtAdultPreExistingPatients * (_cd4Panel.APARTestperYear / 12d);
                cd4out.ExistingPedPatientsinPreArt = CalculatedPatientNos[i].PreArtPediatricPreExistingPatients * (_cd4Panel.PPARTTestperYear / 12d);

                for (int x = 1, y = i; x <= i; x++, y--)
                {
                    cd4out.NewAdultPatientstoTreatment += CalculatedPatientNos[i].GetArtAdultPatientsEntering(x) * _cd4Panel.AdultArtTestGivenInMonth(y);
                    cd4out.NewPedPatientstoTreatment += CalculatedPatientNos[i].GetArtPediatricPatientsEntering(x) * _cd4Panel.PediatricArtTestGivenInMonth(y);
                    cd4out.NewAdultPatientstoPreArt += CalculatedPatientNos[i].GetPreArtAdultPatientsEntering(x) * _cd4Panel.AdultPreArtTestGivenInMonth(y);
                    cd4out.NewPedPatientstoPreArt += CalculatedPatientNos[i].GetPreArtPediatricPatientsEntering(x) * _cd4Panel.PediatricPreArtTestGivenInMonth(y);
                }

                _cd4MonthlyOutputs.Add(i, cd4out);
            }

            double patientEnterPerMonth = 0;
            double symptomDirectedTestsAtstartYear = CurrentAdultinTreatment + CurrentPediatricinTreatment + CurrentAdultinPreArt + CurrentPediatricinPreArt;
            symptomDirectedTestsAtstartYear = (symptomDirectedTestsAtstartYear * _patientsRequiringOneSymptomDirectedTest) / 12d;

            int pmonth, buffmonth;
            for (int i = 1; i <= 12; i++)
            {
                patientEnterPerMonth = CalculatedPatientNos[i].GetArtAdultPatientsEntering(i) + CalculatedPatientNos[i].GetArtPediatricPatientsEntering(i);
                patientEnterPerMonth += CalculatedPatientNos[i].GetPreArtAdultPatientsEntering(i) + CalculatedPatientNos[i].GetPreArtPediatricPatientsEntering(i);
                patientEnterPerMonth = (patientEnterPerMonth * _patientsRequiringOneSymptomDirectedTest) / 12d;

                _cd4MonthlyOutputs[i].SymptomDirectedTests += symptomDirectedTestsAtstartYear + patientEnterPerMonth;

                for (int x = i + 1; x <= 12; x++)
                {
                    _cd4MonthlyOutputs[x].SymptomDirectedTests += patientEnterPerMonth;
                }
                double v1, v2;
                v1 = _cd4MonthlyOutputs[i].TotalReceivingCD4Test();
                v2 = _cd4MonthlyOutputs[i].TestFromProtocols();

                _cd4MonthlyOutputs[i].RepeatDuetoClinicianRequest = (_cd4MonthlyOutputs[i].TotalReceivingCD4Test() + _cd4MonthlyOutputs[i].TestFromProtocols() + _cd4MonthlyOutputs[i].SymptomDirectedTests) * _cd4RepeatsduetoClinicianRequest;
                                
                pmonth = buffmonth = 0;
                if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                    pmonth = 1;
                if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                    buffmonth = 1;

                _cd4MonthlyOutputs[i].TestsBasedonProtocols = _cd4MonthlyOutputs[i].TotalTestConducted() * pmonth;
                _cd4MonthlyOutputs[i].TestsforBufferStock = _cd4MonthlyOutputs[i].TotalTestConducted() * buffmonth;

                _cd4MonthlyOutputs[i].AdditionalTestsdueToWastage = (_cd4MonthlyOutputs[i].TestsBasedonProtocols / (1 - _cdAdditionalTestsDuetoWastage)) - _cd4MonthlyOutputs[i].TestsBasedonProtocols;
                _cd4MonthlyOutputs[i].AdditionalTestsdueToWastageForBuffer = (_cd4MonthlyOutputs[i].TestsforBufferStock / (1 - _cdAdditionalTestsDuetoWastage)) - _cd4MonthlyOutputs[i].TestsforBufferStock;

            }
        }

        /// <summary>
        /// sample referral
        /// </summary>
        /// <param name="result"></param>
        public void SetTestsReceivedFromReferringSites(double[] result)
        {
            int pmonth, buffmonth;
            for (int i = 1; i <= 12; i++)
            {
                _cd4MonthlyOutputs[i].TestsReceivedFromReferringSites = result[i - 1];
                pmonth = buffmonth = 0;
                if ((i+1) < PeriodInfo.BeginsOnmonth)
                    pmonth = 1;
                if ((i+1) >= PeriodInfo.BeginsOnmonth && (i+1) <= PeriodInfo.EndOnMonth)
                    buffmonth = 1;

                _cd4MonthlyOutputs[i].TestsonInstrumentForecastPeriodFromReferringSites = result[i - 1] * pmonth;
                _cd4MonthlyOutputs[i].TestsonInstrumentBufferStockFromReferringSites = result[i - 1] * buffmonth;
            }

            _testsReceivedFromReferringSitesBeyondForecast = result[12];
        }
          
        private void CalcInstrumentDetailsAndControls()
        {
            int noofControls;
            int noofTestdays = ArtSite.Site.CD4TestingDaysPerMonth;
            double testRunpercent = 0d;
            double controlTest = 0d;

            foreach (SiteInstrument ins in ArtSite.Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.CD4))
            {
                PlatformTestsAndControls cd4Plat = new PlatformTestsAndControls();
                cd4Plat.InstrumentId = ins.Instrument.Id;
                cd4Plat.Quantity = ins.Quantity;
                testRunpercent = Convert.ToDouble(ins.TestRunPercentage) / 100d;

                int currentQuarter = PeriodInfo.FirstMonth;

                for (int i = 1; i <= 12; i++)
                {
                    TestsAndControls ctc = new TestsAndControls(i);

                    ctc.TestsonInstrumentForecastPeriod = _cd4MonthlyOutputs[i].TestsBasedonProtocols * testRunpercent;
                    ctc.TestsonInstrumentBufferStock = _cd4MonthlyOutputs[i].TestsforBufferStock * testRunpercent;

                    noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
                    if (noofControls > 0)
                    {
                        ctc.ControlsPerNoOfTests = (ctc.TestsonInstrumentForecastPeriod / noofControls);
                        ctc.ControlsPerNoOfTestsBuffer = (ctc.TestsonInstrumentBufferStock / noofControls);
                    }

                    noofControls = ins.Instrument.DailyCtrlTest;
                    controlTest = ((noofControls / (1d - _cdAdditionalTestsDuetoWastage)) * ins.Quantity) * noofTestdays;
                    if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        ctc.ControlsPerDay = controlTest;
                    if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        ctc.ControlsPerDayBuffer = controlTest;

                    noofControls = ins.Instrument.WeeklyCtrlTest;
                    controlTest = ((noofControls / (1 - _cdAdditionalTestsDuetoWastage)) * ins.Quantity) * 4;
                    if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        ctc.ControlsPerWeek = controlTest;
                    if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        ctc.ControlsPerWeekBuffer = controlTest;

                    noofControls = ins.Instrument.MonthlyCtrlTest;
                    controlTest = ((noofControls / (1 - _cdAdditionalTestsDuetoWastage)) * ins.Quantity) * 1;
                    if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                        ctc.ControlsPerMonth = controlTest;
                    if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                        ctc.ControlsPerMonthBuffer = controlTest;

                    noofControls = ins.Instrument.QuarterlyCtrlTest;
                    controlTest = ((noofControls / (1 - _cdAdditionalTestsDuetoWastage)) * ins.Quantity);
                    if (i == currentQuarter)
                    {
                        currentQuarter += 3;
                        if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                            ctc.ControlsPerQuarter = controlTest;
                        if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                            ctc.ControlsPerQuarterBuffer = controlTest;
                    }

                    //Samples Referred from Elsewhere
                    ctc.SampleReferredTestsForecastPeriod = _cd4MonthlyOutputs[i].TestsonInstrumentForecastPeriodFromReferringSites * testRunpercent;
                    ctc.SampleReferredTestsBufferStock = _cd4MonthlyOutputs[i].TestsonInstrumentBufferStockFromReferringSites * testRunpercent;

                    noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
                    if (noofControls > 0)
                    {
                        ctc.SampleReferredControlsPerNoOfTests = ctc.SampleReferredTestsForecastPeriod / noofControls;
                        ctc.SampleReferredControlsPerNoOfTestsBuffer = ctc.SampleReferredTestsBufferStock / noofControls;
                    }

                    cd4Plat.AddTestAndControl(ctc);
                }

                cd4Plat.AddTestAndControl(DoByondForcastCalc(ins, noofTestdays, currentQuarter));
                _cd4PlatformTests.Add(cd4Plat);
            }
        }

        private double BufferTestBeyondForecast()
        {
            return _cd4MonthlyOutputs[12].TotalTestConducted() * PeriodInfo.NumberofBufferMonthsBeyondForecast;
        }

        public double SubtotalBufferTestBeyondForecast()
        {
            double sum = BufferTestBeyondForecast();
            return sum + ((sum / (1 - _cdAdditionalTestsDuetoWastage)) - sum);
        }

        private TestsAndControls DoByondForcastCalc(SiteInstrument ins, int noofTestdays, int currentQuarter)
        {
            double testRunpercent = Convert.ToDouble(ins.TestRunPercentage) / 100d;
            TestsAndControls ctc = new TestsAndControls(13);

                ctc.TestsonInstrumentForecastPeriod = 0;
                ctc.TestsonInstrumentBufferStock = SubtotalBufferTestBeyondForecast() * testRunpercent;

                //Samples Referred from Elsewhere
                ctc.SampleReferredTestsForecastPeriod = 0;
                ctc.SampleReferredTestsBufferStock = _testsReceivedFromReferringSitesBeyondForecast * testRunpercent;

            double noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
            if (noofControls > 0)
            {
                ctc.ControlsPerNoOfTests = 0;
                ctc.ControlsPerNoOfTestsBuffer = (ctc.TestsonInstrumentBufferStock / noofControls);
            }

            noofControls = ins.Instrument.DailyCtrlTest;
            double controlTest = ((noofControls / (1 - _cdAdditionalTestsDuetoWastage)) * testRunpercent) * noofTestdays;
            ctc.ControlsPerDay = 0;
            ctc.ControlsPerDayBuffer = controlTest * PeriodInfo.NumberofBufferMonthsBeyondForecast;

            noofControls = ins.Instrument.WeeklyCtrlTest;
            controlTest = ((noofControls / (1 - _cdAdditionalTestsDuetoWastage)) * testRunpercent) * 4;
            ctc.ControlsPerWeek = 0;
            ctc.ControlsPerWeekBuffer = controlTest * PeriodInfo.NumberofBufferMonthsBeyondForecast;

            noofControls = ins.Instrument.MonthlyCtrlTest;
            controlTest = ((noofControls / (1 - _cdAdditionalTestsDuetoWastage)) * testRunpercent) * 1;
            ctc.ControlsPerMonth = 0;
            ctc.ControlsPerMonthBuffer = controlTest * PeriodInfo.NumberofBufferMonthsBeyondForecast;

            noofControls = ins.Instrument.QuarterlyCtrlTest;
            controlTest = ((noofControls / (1 - _cdAdditionalTestsDuetoWastage)) * testRunpercent);

            int quarter = 0;
            if (currentQuarter == 12)
                quarter = 2;
            else if (currentQuarter == 11)
                quarter = 1;
            else if (currentQuarter == 10)
                quarter = 0;

            ctc.ControlsPerQuarter = 0;
            ctc.ControlsPerQuarterBuffer = Math.Round((PeriodInfo.NumberofBufferMonthsBeyondForecast - quarter) / 3d) * controlTest;

            noofControls = ins.Instrument.MaxTestBeforeCtrlTest;
            if (noofControls > 0)
            {
                ctc.SampleReferredControlsPerNoOfTests = 0;
                ctc.SampleReferredControlsPerNoOfTestsBuffer = ctc.SampleReferredTestsBufferStock / noofControls;
            }

            return ctc;
        }

        private void DoQuantification()
        {
            //DOES THIS SITE RECEIVE Chemistry SUPPLIES?
            if (ArtSite.ForecastCD4)
            {
                int allChemQMid = 0;
                double value, allChemInsQty = 0;
                double referralValue;
                foreach (QuantifyMenu qm in _platformObject.GeneralQuantifyMenus)
                {
                    value = 0;
                    referralValue = 0;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_CD4_Tests.ToString())
                    {
                        value = GetTotalCD4TestForSite(); 
                        referralValue = GetTotalCD4TestForReferral();
                    }
                    else if (qm.Title == GeneralQuantifyMenuEnum.Per_Instrument_All_CD4_Instruments.ToString())
                        allChemQMid = qm.Id;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Per_Day_All_CD4_Instruments.ToString() && _cd4PlatformTests.Count > 0)
                        value = ArtSite.Site.CD4TestingDaysPerMonth * (PeriodInfo.NumberofBufferMonthsBeyondForecast + PeriodInfo.NumberofMonthsinBudgetPeriod);

                    if (value > 0)
                    {
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = qm.Id;
                        qval.SiteValue = value;                        
                        qval.ReferalSiteValue = referralValue;
                        _listOfQMenuWithValue.Add(qval);
                    }
                }

                TestingDurationEnum[] tduration = LqtUtil.EnumToArray<TestingDurationEnum>();

                foreach (PlatformTestsAndControls cpt in _cd4PlatformTests)
                {
                    allChemInsQty += cpt.Quantity;

                    PlatformQuantifyMenu pqm = (PlatformQuantifyMenu)_platformObject.GetPlatformQuantifyMenuByInsId(cpt.InstrumentId);
                    if (pqm != null)
                    {
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = pqm.GetQuantifyMenuId(TestTypeEnum.Test);
                        qval.SiteValue = cpt.TotalSumOfTestOnInstrument();
                        qval.ReferalSiteValue = cpt.TotalSumOfSampleReferredTestOnInstrumanet();
                        _listOfQMenuWithValue.Add(qval);

                        qval = new QMenuWithValue();
                        qval.QuantifyMenuId = pqm.GetQuantifyMenuId(TestTypeEnum.PerInstrument);
                        qval.SiteValue = cpt.Quantity;
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);

                        qval = new QMenuWithValue();
                        qval.QuantifyMenuId = pqm.GetQuantifyMenuId(TestTypeEnum.PerDay);
                        qval.SiteValue = ArtSite.Site.CD4TestingDaysPerMonth * (PeriodInfo.NumberofBufferMonthsBeyondForecast + PeriodInfo.NumberofMonthsinBudgetPeriod);
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);

                        for (int i = 0; i < tduration.Length; i++)
                        {
                            qval = new QMenuWithValue();
                            qval.QuantifyMenuId = pqm.GetQuantifyMenuId(tduration[i]);
                            qval.SiteValue = cpt.GetSumOfControlsByDuration(tduration[i]);
                            if (tduration[i] == TestingDurationEnum.TotalControl || tduration[i] == TestingDurationEnum.PerTest)
                                qval.ReferalSiteValue = cpt.SampleReferredTotalControls();
                            else
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

                        double testperpack = pqr.PackSize / r.UsageRate;
                        double valueofmetric = r.CollectionSupplieAppliedTo == CollectionSupplieAppliedToEnum.Collection.ToString() ? qm.SiteValue : qm.TotalValue;
                        if (ArtSite.Site.CD4RefSite > 0 && r.CollectionSupplieAppliedTo == CollectionSupplieAppliedToEnum.Testing.ToString())
                            valueofmetric = 0;
                        pqr.Value = testperpack > 0 ? valueofmetric / testperpack : 0;
                        pqr.MinimumQuantity = r.Product.MinimumPackSize;
                        _lstPrimaryQuanReagents.AddPrimeryQR(pqr);
                    }
                }
            }
        }

        private double GetTotalCD4TestForSite()
        {
            double result = 0;

            if (ArtSite.Site.CD4RefSite == 0)
            {
                foreach (PlatformTestsAndControls cpt in _cd4PlatformTests)
                {
                    result += cpt.TotalSumOfTestOnInstrument();
                }

            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    result += _cd4MonthlyOutputs[i].TotalCD4TestsReferred();
                }
            }
            return result;
        }

        private double GetTotalCD4TestForReferral()
        {
            double result = 0;
            foreach (PlatformTestsAndControls cpt in _cd4PlatformTests)
            {
                result += cpt.TotalSumOfSampleReferredTestOnInstrumanet();
            }

            return result;
        }

        private CD4TestNumber _cdtestNumber;
        public CD4TestNumber GetCD4TestNumber()
        {
            _cdtestNumber = new CD4TestNumber();
            _cdtestNumber.ForecastId = Forecast.Id;
            _cdtestNumber.SiteId = ArtSite.Site.Id;
            if (ArtSite.ForecastCD4)
            {
                for (int i = 1; i <= 12; i++)
                {
                    _cdtestNumber.ExistingPIT += _cd4MonthlyOutputs[i].ExistingPatientsinTreatment();
                    _cdtestNumber.ExistingPIPreART += _cd4MonthlyOutputs[i].ExistingPatientsinPreART();
                    _cdtestNumber.CD4BaseLineTest += _cd4MonthlyOutputs[i].TotalReceivingCD4Test();
                    _cdtestNumber.NewPatienttoTreatment += _cd4MonthlyOutputs[i].NewPatientstoTreatment();
                    _cdtestNumber.NewPatientstoPreART += _cd4MonthlyOutputs[i].NewPatientstoPreART();
                    _cdtestNumber.SymptomDirectedTest += _cd4MonthlyOutputs[i].SymptomDirectedTests;
                    _cdtestNumber.RepeatsdutoClinicalRequest += _cd4MonthlyOutputs[i].RepeatDuetoClinicianRequest;
                    _cdtestNumber.Wastage += _cd4MonthlyOutputs[i].AdditionalTestsdueToWastage;
                }

                foreach (PlatformTestsAndControls ptc in _cd4PlatformTests)
                {
                    _cdtestNumber.ReagentstoRunControls += ptc.TotalControlsFP() + ptc.SumOfSampleReferredControlsPerNoOfTests();
                    _cdtestNumber.BufferStockandControls += ptc.TotalControlsBP() + ptc.SumOfSampleReferredControlsPerNoOfTestsBuffer();
                }
            }
            return _cdtestNumber;
        }

     
    }
}
