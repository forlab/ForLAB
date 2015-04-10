
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
    public class CalcRapidTest : BaseCalc
    {
        private double _adultsThatdonotFollowup;
        private double _pediatrcisThatdonotFollowup;
        private double _prevalenceofAdultTestingPop;
        private double _prevalenceofPediatricTestingPop;
        private double _wastageScreening;
        private double _wastageConfirmatory;
        private double _wastageTiebreaker;
        
        private double[,] _totalPositiveDiagnoses = new double[12, 10];
        private double[,] _totalPositiveToscreen = new double[12, 5];
        private double[,] _screeningTests = new double[13, 3];
        private double[,] _confirmateryTests = new double[13, 3];
        private double[,] _tiebreakerTests = new double[13, 3];

        private HIVRapidNumberofTest _rapidNumaberOfTest;
        private IDictionary<int, MOutputRapidTest> _rapidTestOutputs = new Dictionary<int, MOutputRapidTest>();
        private PlatformQuantifyObject _platformObject;
        

        public CalcRapidTest(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target, RapidTestAlgorithm rtestAlgorithm)
            : base(site, forecast, periodinfo, target,rtestAlgorithm)
        {
            _lstPrimaryQuanReagents = new ListOfPrimeryQR(ClassOfMorbidityTestEnum.RapidTest);
        }

        public Dictionary<int, CalculatedSitePatientNumber> CalculatedPatientNos { get; set; }
        public PlatformQuantifyObject RapidTestPlatformQuantifyObject
        {
            set { _platformObject = value; }
        }
        public IDictionary<int, MOutputRapidTest> RapidTestOutputs
        {
            get { return _rapidTestOutputs; }
        }
        public void DoCalculation()
        {
             InitRapidTestVar();

            if (Forecast.TypeofAlgorithm == AlgorithmType.Serial.ToString())
                CalculateSerialAlgorithm();
            else
                CalculateParallelAlgorithm();

            DoSumationOfRapidTest();
            DoQuantification();
        }

        private void InitRapidTestVar()
        {
            _adultsThatdonotFollowup = (ArtSite.AdultDepartWoutFollowup / 100d);
            _pediatrcisThatdonotFollowup = (ArtSite.PediatricDepartWoutFollowup / 100d);
            _prevalenceofAdultTestingPop = (ArtSite.AdultTestingPopulation / 100d);
            _prevalenceofPediatricTestingPop = (ArtSite.PediatricTestingPopulation / 100d);

            _wastageScreening = (InvAssumption.RapidTestScreening / 100d);
            _wastageConfirmatory = (InvAssumption.RapidTestConfirmatery / 100d);
            _wastageTiebreaker = (InvAssumption.RapidTestTibreaker / 100d);
        }

        private void CalculateSerialAlgorithm()
        {
            double totalHIVPostoContinue, totalHIVNegativetoContinue;
            double HIVPostoContinueTiebreaker, HIVNegativetoContinueTiebreaker;
            for (int i = 0; i < 12; i++)
            {
                MOutputRapidTest rapidout = new MOutputRapidTest(i + 1);
                rapidout.HIVAdultsThatDonotFollowup = _adultsThatdonotFollowup;
                rapidout.HIVPediatrcisThatDonotFollowup = _pediatrcisThatdonotFollowup;
                rapidout.PrevalenceOfAdultTestingPop = _prevalenceofAdultTestingPop;
                rapidout.PrevalenceOfPediatricTestingPop = _prevalenceofPediatricTestingPop;

                rapidout.AdultsEnteringTreatment = CalculatedPatientNos[i + 1].AdultEnteringARTfromoutsidePreART;
                rapidout.AdultsEnteringPreART = CalculatedPatientNos[i + 1].AdultEnteringpreARTeachmonth;
                rapidout.PediatricsEnteringTreatment = CalculatedPatientNos[i + 1].PediatricEnteringARTfromoutsidePreART;
                rapidout.PediatricsEnteringPreART = CalculatedPatientNos[i + 1].PediatricEnteringpreARTeachmonth;

                _screeningTests[i, 0] = rapidout.TotalPatientsToScreen * (ArtSite.ScrTest1Percent / 100d);
                _screeningTests[i, 1] = rapidout.TotalPatientsToScreen * (ArtSite.ScrTest2Percent / 100d);
                _screeningTests[i, 2] = rapidout.TotalPatientsToScreen * (ArtSite.ScrTest3Percent / 100d);

                totalHIVPostoContinue = (ArtSite.ScrTest1Percent/100d) * rapidout.HIVPositivePopulation * RTestAlgorithm.ScreeningTestSensitivty(1);
                totalHIVPostoContinue += (ArtSite.ScrTest2Percent/100d) * rapidout.HIVPositivePopulation * RTestAlgorithm.ScreeningTestSensitivty(2);
                totalHIVPostoContinue += (ArtSite.ScrTest3Percent / 100d) * rapidout.HIVPositivePopulation * RTestAlgorithm.ScreeningTestSensitivty(3);

                totalHIVNegativetoContinue = (ArtSite.ScrTest1Percent / 100d) * rapidout.HIVNegativePopulation * RTestAlgorithm.ScreeningTestFalsePositive(1);
                totalHIVNegativetoContinue += (ArtSite.ScrTest2Percent / 100d) * rapidout.HIVNegativePopulation * RTestAlgorithm.ScreeningTestFalsePositive(2);
                totalHIVNegativetoContinue += (ArtSite.ScrTest3Percent / 100d) * rapidout.HIVNegativePopulation * RTestAlgorithm.ScreeningTestFalsePositive(3);

                _confirmateryTests[i, 0] = (totalHIVPostoContinue + totalHIVNegativetoContinue) * (ArtSite.ConTest1Percent / 100d);
                _confirmateryTests[i, 1] = (totalHIVPostoContinue + totalHIVNegativetoContinue) * (ArtSite.ConTest2Percent / 100d);
                _confirmateryTests[i, 2] = (totalHIVPostoContinue + totalHIVNegativetoContinue) * (ArtSite.ConTest3Percent / 100d);

                HIVPostoContinueTiebreaker = (ArtSite.ConTest1Percent / 100d) * totalHIVPostoContinue * RTestAlgorithm.ConfirmatoryTestFalseNegative(1);
                HIVPostoContinueTiebreaker += (ArtSite.ConTest2Percent/100d) * totalHIVPostoContinue * RTestAlgorithm.ConfirmatoryTestFalseNegative(2);
                HIVPostoContinueTiebreaker += (ArtSite.ConTest3Percent/100d) * totalHIVPostoContinue * RTestAlgorithm.ConfirmatoryTestFalseNegative(3);
                
                HIVNegativetoContinueTiebreaker  = (ArtSite.ConTest1Percent/100d) * totalHIVNegativetoContinue * RTestAlgorithm.ConfirmatoryTestSpecificity(1);
                HIVNegativetoContinueTiebreaker += (ArtSite.ConTest2Percent/100d) * totalHIVNegativetoContinue * RTestAlgorithm.ConfirmatoryTestSpecificity(2);
                HIVNegativetoContinueTiebreaker += (ArtSite.ConTest3Percent / 100d) * totalHIVNegativetoContinue * RTestAlgorithm.ConfirmatoryTestSpecificity(3);
                
                _tiebreakerTests[i, 0] = (HIVPostoContinueTiebreaker + HIVNegativetoContinueTiebreaker) * (ArtSite.TieTest1Percent / 100d);
                _tiebreakerTests[i, 1] = (HIVPostoContinueTiebreaker + HIVNegativetoContinueTiebreaker) * (ArtSite.TieTest2Percent / 100d);
                _tiebreakerTests[i, 2] = (HIVPostoContinueTiebreaker + HIVNegativetoContinueTiebreaker) * (ArtSite.TieTest3Percent / 100d);

                _rapidTestOutputs.Add(i + 1, rapidout);
            }

            AdjustRapidTestBufferStock();
        }

        private void CalculateParallelAlgorithm()
        {
            double[,] proToNextstage = new double[3, 2];
            double proc, an, pn;

            for (int i = 1; i <= 3; i++)
            {
                proc = an = pn = 0;

                proc = RTestAlgorithm.ScreeningTestSensitivty(i) * RTestAlgorithm.ConfirmatoryTestSensitivty(i);
                an += RTestAlgorithm.BothPositiveProceed ? proc * _prevalenceofAdultTestingPop : 0;
                pn += RTestAlgorithm.BothPositiveProceed ? proc * _prevalenceofPediatricTestingPop : 0; 

                proc = RTestAlgorithm.ScreeningTestSensitivty(i) * RTestAlgorithm.ConfirmatoryTestFalseNegative(i);
                an += RTestAlgorithm.DiscordantProceed ? proc * _prevalenceofAdultTestingPop : 0;
                pn += RTestAlgorithm.DiscordantProceed ? proc * _prevalenceofPediatricTestingPop : 0;

                proc = RTestAlgorithm.ScreeningTestFalseNegative(i) * RTestAlgorithm.ConfirmatoryTestSensitivty(i);
                an += RTestAlgorithm.DiscordantProceed ? proc * _prevalenceofAdultTestingPop : 0;
                pn += RTestAlgorithm.DiscordantProceed ? proc * _prevalenceofPediatricTestingPop : 0;

                proc = RTestAlgorithm.ScreeningTestFalseNegative(i) * RTestAlgorithm.ConfirmatoryTestFalseNegative(i);
                an += RTestAlgorithm.BothNegativeProceed ? proc * _prevalenceofAdultTestingPop : 0;
                pn += RTestAlgorithm.BothNegativeProceed ? proc * _prevalenceofPediatricTestingPop : 0;

                proc = RTestAlgorithm.ScreeningTestSpecificity(i) * RTestAlgorithm.ConfirmatoryTestSpecificity(i);
                an += RTestAlgorithm.BothNegativeProceed ? proc * (1 - _prevalenceofAdultTestingPop) : 0;
                pn += RTestAlgorithm.BothNegativeProceed ? proc * (1 - _prevalenceofPediatricTestingPop) : 0;

                proc = RTestAlgorithm.ScreeningTestSpecificity(i) * RTestAlgorithm.ConfirmatoryTestFalsePositive(i);
                an += RTestAlgorithm.DiscordantProceed ? proc * (1 - _prevalenceofAdultTestingPop) : 0;
                pn += RTestAlgorithm.DiscordantProceed ? proc * (1 - _prevalenceofPediatricTestingPop) : 0;

                proc = RTestAlgorithm.ScreeningTestFalsePositive(i) * RTestAlgorithm.ConfirmatoryTestSpecificity(i);
                an += RTestAlgorithm.DiscordantProceed ? proc * (1 - _prevalenceofAdultTestingPop) : 0;
                pn += RTestAlgorithm.DiscordantProceed ? proc * (1 - _prevalenceofPediatricTestingPop) : 0;

                proc = RTestAlgorithm.ScreeningTestFalsePositive(i) * RTestAlgorithm.ConfirmatoryTestFalsePositive(i);
                an += RTestAlgorithm.BothPositiveProceed ? proc * (1 - _prevalenceofAdultTestingPop) : 0;
                pn += RTestAlgorithm.BothPositiveProceed ? proc * (1 - _prevalenceofPediatricTestingPop) : 0;

                proToNextstage[i - 1, 0] = an;
                proToNextstage[i - 1, 1] = pn;
            }

            string[,] product = new string[9, 2];
            product[0, 0] = ArtSite.ScrTest1.ToString();
            product[1, 0] = ArtSite.ConTest1.ToString();
            product[2, 0] = ArtSite.ScrTest2.ToString();
            product[3, 0] = ArtSite.ConTest2.ToString();
            product[4, 0] = ArtSite.ScrTest3.ToString();
            product[5, 0] = ArtSite.ConTest3.ToString();

            product[6, 0] = ArtSite.TieTest1.ToString();
            product[7, 0] = ArtSite.TieTest2.ToString();
            product[8, 0] = ArtSite.TieTest3.ToString();
            
            double s1, n1, s2, n2;

            for (int i = 0; i < 12; i++)
            {
                MOutputRapidTest rapidout = new MOutputRapidTest(i + 1);
                rapidout.HIVAdultsThatDonotFollowup = _adultsThatdonotFollowup;
                rapidout.HIVPediatrcisThatDonotFollowup = _pediatrcisThatdonotFollowup;
                rapidout.PrevalenceOfAdultTestingPop = _prevalenceofAdultTestingPop;
                rapidout.PrevalenceOfPediatricTestingPop = _prevalenceofPediatricTestingPop;

                rapidout.AdultsEnteringTreatment = CalculatedPatientNos[i + 1].AdultEnteringARTfromoutsidePreART;
                rapidout.AdultsEnteringPreART = CalculatedPatientNos[i + 1].AdultEnteringpreARTeachmonth;
                rapidout.PediatricsEnteringTreatment = CalculatedPatientNos[i + 1].PediatricEnteringARTfromoutsidePreART;
                rapidout.PediatricsEnteringPreART = CalculatedPatientNos[i + 1].PediatricEnteringpreARTeachmonth;

                _rapidTestOutputs.Add(i + 1, rapidout);

                s1 = rapidout.TotalAdultsTested * (ArtSite.ScrTest1Percent / 100d);     // _totalPositiveToscreen[i, 1] * (ArtSite.ScrTest1Percent / 100d);
                n1 = s1 * proToNextstage[0, 0];
                s2 = rapidout.TotalPediatricsTested * (ArtSite.ScrTest1Percent / 100d); // _totalPositiveToscreen[i, 2] * (ArtSite.ScrTest1Percent / 100d);
                n2 = s2 * proToNextstage[0, 1];

                product[0, 1] = (s1 + s2).ToString();
                product[1, 1] = (s1 + s2).ToString();

                s1 = rapidout.TotalAdultsTested * (ArtSite.ScrTest2Percent / 100d);      //_totalPositiveToscreen[i, 1] * (ArtSite.ScrTest2Percent / 100d);
                n1 += s1 * proToNextstage[1, 0];
                s2 = rapidout.TotalPediatricsTested * (ArtSite.ScrTest2Percent / 100d);  //_totalPositiveToscreen[i, 2] * (ArtSite.ScrTest2Percent / 100d);
                n2 += s2 * proToNextstage[1, 1];
                
                product[2, 1] = (s1 + s2).ToString();
                product[3, 1] = (s1 + s2).ToString();

                s1 = rapidout.TotalAdultsTested * (ArtSite.ScrTest3Percent / 100d);      //_totalPositiveToscreen[i, 1] * (ArtSite.ScrTest3Percent / 100d);
                n1 += s1 * proToNextstage[2, 0];
                s2 = rapidout.TotalPediatricsTested * (ArtSite.ScrTest3Percent / 100d);  //_totalPositiveToscreen[i, 2] * (ArtSite.ScrTest3Percent / 100d);
                n2 += s2 * proToNextstage[2, 1];
                
                product[4, 1] = (s1 + s2).ToString();
                product[5, 1] = (s1 + s2).ToString();

                product[6, 1] = (n1 + n2).ToString();
                product[7, 1] = (n1 + n2).ToString();
                product[8, 1] = (n1 + n2).ToString();

                _screeningTests[i, 0] = SumByProductId(ArtSite.ScrTest1, product, 0, 5);
                _screeningTests[i, 1] = SumByProductId(ArtSite.ScrTest2, product, 0, 5);
                _screeningTests[i, 2] = SumByProductId(ArtSite.ScrTest3, product, 0, 5);

                _confirmateryTests[i, 0] = SumByProductId(ArtSite.ConTest1, product, 0, 5);
                _confirmateryTests[i, 1] = SumByProductId(ArtSite.ConTest2, product, 0, 5);
                _confirmateryTests[i, 2] = SumByProductId(ArtSite.ConTest3, product, 0, 5);

                _tiebreakerTests[i, 0] = (ArtSite.TieTest1Percent/100d)* SumByProductId(ArtSite.TieTest1, product, 6, 8);
                _tiebreakerTests[i, 1] = (ArtSite.TieTest2Percent / 100d) * SumByProductId(ArtSite.TieTest2, product, 6, 8);
                _tiebreakerTests[i, 2] = (ArtSite.TieTest3Percent / 100d) * SumByProductId(ArtSite.TieTest3, product, 6, 8);
            }
            AdjustRapidTestBufferStock();
        }

        private void AdjustRapidTestBufferStock()
        {
            for (int i = 1; i <= 12; i++)
            {
                int pmonth = 0;
                int buffmonth = 0;
                if (i >= PeriodInfo.FirstMonth && i <= PeriodInfo.LastMonth)
                    pmonth = 1;
                if (i >= PeriodInfo.BeginsOnmonth && i <= PeriodInfo.EndOnMonth)
                    buffmonth = 1;

                _screeningTests[i, 0] = (_screeningTests[i, 0] * pmonth) + (_screeningTests[i, 0] * buffmonth);
                _screeningTests[i, 1] = (_screeningTests[i, 1] * pmonth) + (_screeningTests[i, 1] * buffmonth);
                _screeningTests[i, 2] = (_screeningTests[i, 2] * pmonth) + (_screeningTests[i, 2] * buffmonth);

                _confirmateryTests[i, 0] = (_confirmateryTests[i, 0] * pmonth) + (_confirmateryTests[i, 0] * buffmonth);
                _confirmateryTests[i, 1] = (_confirmateryTests[i, 1] * pmonth) + (_confirmateryTests[i, 1] * buffmonth);
                _confirmateryTests[i, 2] = (_confirmateryTests[i, 2] * pmonth) + (_confirmateryTests[i, 2] * buffmonth);

                _tiebreakerTests[i, 0] = (_tiebreakerTests[i, 0] * pmonth) + (_tiebreakerTests[i, 0] * buffmonth);
                _tiebreakerTests[i, 1] = (_tiebreakerTests[i, 1] * pmonth) + (_tiebreakerTests[i, 1] * buffmonth);
                _tiebreakerTests[i, 2] = (_tiebreakerTests[i, 2] * pmonth) + (_tiebreakerTests[i, 2] * buffmonth);
            }

            int beyondF = PeriodInfo.EndOnMonth > 13 ? PeriodInfo.EndOnMonth - 13 : 0;

            _screeningTests[12, 0] = _screeningTests[11, 0] * beyondF;
            _screeningTests[12, 1] = _screeningTests[11, 1] * beyondF;
            _screeningTests[12, 2] = _screeningTests[11, 2] * beyondF;

            _confirmateryTests[12, 0] = _confirmateryTests[11, 0] * beyondF;
            _confirmateryTests[12, 1] = _confirmateryTests[11, 1] * beyondF;
            _confirmateryTests[12, 2] = _confirmateryTests[11, 2] * beyondF;

            _tiebreakerTests[12, 0] = _tiebreakerTests[11, 0] * beyondF;
            _tiebreakerTests[12, 1] = _tiebreakerTests[11, 1] * beyondF;
            _tiebreakerTests[12, 2] = _tiebreakerTests[11, 2] * beyondF;

        }

        private void DoQuantification()
        {
            //DOES THIS SITE RECEIVE Chemistry SUPPLIES?
            if (ArtSite.ForecastVCT)
            {
                double value;
                foreach (QuantifyMenu qm in _platformObject.GeneralQuantifyMenus)
                {
                    value = 0;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Rapid_Tests.ToString())
                        value = _s1 + _s2 + _s3 + _c1 + _c2 + _c3 + _t1 + _t2 + _t3;
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Screenings.ToString())
                        value = _s1 + _s2 + _s3;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Confirmatory_Tests.ToString())
                        value = _c1 + _c2 + _c3;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Tie_Breaker_Tests.ToString())
                        value = _t1 + _t2 + _t3;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Screenings_Plus_Confirmatory.ToString())
                        value = _s1 + _s2 + _s3 + _c1 + _c2 + _c3;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Screenings_Plus_Tie_Breaker.ToString())
                        value = _s1 + _s2 + _s3 + _t1 + _t2 + _t3;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Confirmatory_Plus_Tie_Breaker.ToString())
                        value = _c1 + _c2 + _c3 + _t1 + _t2 + _t3;

                    if (value > 0)
                    {
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = qm.Id;
                        qval.SiteValue = value;
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);
                    }
                }

                for (int i = 1; i <= 3; i++)
                {
                    int prodcutId = RTestAlgorithm.GetProductId(TestingSpecificationGroup.Screening, i);
                    if (prodcutId > 0)
                    {
                        QuantifyMenu pqm = _platformObject.GetQuantifyMenuByProductId(prodcutId);
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = pqm.Id;
                        qval.ReferalSiteValue = 0;

                        if (i == 1)
                            qval.SiteValue = _s1;
                        else if (i == 2)
                            qval.SiteValue = _s2;
                        else
                            qval.SiteValue = _s3;
                        _listOfQMenuWithValue.Add(qval);
                    }

                    prodcutId = RTestAlgorithm.GetProductId(TestingSpecificationGroup.Confirmatory, i);
                    if (prodcutId > 0)
                    {
                        QuantifyMenu pqmC = _platformObject.GetQuantifyMenuByProductId(prodcutId);
                        QMenuWithValue qvalC = new QMenuWithValue();
                        qvalC.QuantifyMenuId = pqmC.Id;
                        qvalC.ReferalSiteValue = 0;

                        if (i == 1)
                            qvalC.SiteValue = _c1;
                        else if (i == 2)
                            qvalC.SiteValue = _c2;
                        else
                            qvalC.SiteValue = _c3;
                        _listOfQMenuWithValue.Add(qvalC);
                    }

                    prodcutId = RTestAlgorithm.GetProductId(TestingSpecificationGroup.Tie_Breaker, i);
                    if (prodcutId > 0)
                    {
                        QuantifyMenu pqmT = _platformObject.GetQuantifyMenuByProductId(prodcutId);
                        QMenuWithValue qvalT = new QMenuWithValue();
                        qvalT.QuantifyMenuId = pqmT.Id;
                        qvalT.ReferalSiteValue = 0;

                        if (i == 1)
                            qvalT.SiteValue = _t1;
                        else if (i == 2)
                            qvalT.SiteValue = _t2;
                        else
                            qvalT.SiteValue = _t3;
                        _listOfQMenuWithValue.Add(qvalT);
                    }
                }
                
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
                        if (ArtSite.Site.CD4RefSite > 0 && r.CollectionSupplieAppliedTo == CollectionSupplieAppliedToEnum.Testing.ToString())
                            valueofmetric = 0;
                        pqr.Value = testperpack > 0 ? valueofmetric / testperpack : 0;
                        pqr.MinimumQuantity = r.Product.MinimumPackSize;
                        _lstPrimaryQuanReagents.AddPrimeryQR(pqr);
                    }
                }
            }
        }

       double _s1, _s2, _s3, _c1, _c2, _c3, _t1, _t2, _t3;

       private void DoSumationOfRapidTest()
       {
           _s1 = _s2 = _s3 = _c1 = _c2 = _c3 = _t1 = _t2 = _t3 = 0;
           for (int i = 0; i <= 12; i++)
           {
               _s1 += _screeningTests[i, 0];
               _s2 += _screeningTests[i, 1];
               _s3 += _screeningTests[i, 2];

               _c1 += _confirmateryTests[i, 0];
               _c2 += _confirmateryTests[i, 1];
               _c3 += _confirmateryTests[i, 2];

               _t1 += _tiebreakerTests[i, 0];
               _t2 += _tiebreakerTests[i, 1];
               _t3 += _tiebreakerTests[i, 2];
           }

           _s1 = _s1 + ((_s1 / (1 - _wastageScreening)) - _s1);
           _s2 = _s2 + ((_s2 / (1 - _wastageScreening)) - _s2);
           _s3 = _s3 + ((_s3 / (1 - _wastageScreening)) - _s3);

           _c1 = _c1 + ((_c1 / (1 - _wastageConfirmatory)) - _c1);
           _c2 = _c2 + ((_c2 / (1 - _wastageConfirmatory)) - _c2);
           _c3 = _c3 + ((_c3 / (1 - _wastageConfirmatory)) - _c3);

           _t1 = _t1 + ((_t1 / (1 - _wastageTiebreaker)) - _t1);
           _t2 = _t2 + ((_t2 / (1 - _wastageTiebreaker)) - _t2);
           _t3 = _t3 + ((_t3 / (1 - _wastageTiebreaker)) - _t3);

       }


       public HIVRapidNumberofTest RapidNumberofTest()
       {
           if (_rapidNumaberOfTest == null)
           {
               _rapidNumaberOfTest = new HIVRapidNumberofTest();
               _rapidNumaberOfTest.ForecastId = Forecast.Id;
               _rapidNumaberOfTest.SiteId = ArtSite.Site.Id;
               _rapidNumaberOfTest.Screening = _s1 + _s2 + _s3;
               _rapidNumaberOfTest.Confirmatory = _c1 + _c2 + _c3;
               _rapidNumaberOfTest.TieBreaker = _t1 + _t2 + _t3;
           }

           return _rapidNumaberOfTest;
       }

        private double SumByProductId(int id, string[,] pvalue, int startpos, int endpos)
       {
           if (id == 0)
               return 0;

           double result = 0;
           for (int i = startpos; i <= endpos; i++)
           {
               if (int.Parse(pvalue[i, 0]) == id)
               {
                   result += double.Parse(pvalue[i, 1]);
               }
           }

           return result;
       }

    }
}
