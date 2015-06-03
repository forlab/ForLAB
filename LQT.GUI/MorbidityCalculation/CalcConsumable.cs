
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
using System.Collections;
using System.Collections.Generic;

using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class CalcConsumable : BaseCalc
    {       
        private double _adultArtNewPatientBloodDraws;
        private double _adultArtExistingPatientBloodDraws;
        private double _adultPreArtNewPatientBloodDraws;
        private double _adultPreArtExistingPatientBloodDraws;

        private double _pedArtNewPatientBloodDraws;
        private double _pedArtExistingPatientBloodDraws;
        private double _pedPreArtNewPatientBloodDraws;
        private double _pedPreArtExistingPatientBloodDraws;
        //private double _useLastMonthSupplyAs1MonthBuffer;

        private double _adultTotalBufferBeyondForecastPeriod;
        private double _pedTotalBufferBeyondForecastPeriod;
        //private double _totalBufferBeyondForecastPeriod;
        private double _PositiveDiagnosesToReceiveCD4BeyondForecastPeriod;
        private double _PositiveDiagnosesBeyondForecastPeriod;
  
        private IDictionary<int, MOutputConsumable> _othMonthlyOutputs = new Dictionary<int, MOutputConsumable>();
        private PlatformQuantifyObject _platformObject;
        
        public CalcConsumable(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target)
            : base(site, forecast, periodinfo, target)
        {
            _lstPrimaryQuanReagents = new ListOfPrimeryQR(ClassOfMorbidityTestEnum.Consumable);
        }

        public Dictionary<int, CalculatedSitePatientNumber> CalculatedPatientNos { get; set; }
        public IDictionary<int, MOutputRapidTest> RapidTestOutputs { get; set; }
        public IDictionary<int, MOutputCD4> CD4MonthlyOutputs { get; set; }

        public CalcRapidTest RapidTestCalculator { get; set; }
        public CalcCD4Test CD4TestCalculator { get; set; }
        public CalcChemistryTest ChemistryTestCalculator { get; set; }
        public CalcHematology HematologyTestCalculator { get; set; }
        public CalcViralLoad ViralTestCalculator { get; set; }
               

        public PlatformQuantifyObject ConsumablePlatformQuantifyObject
        {
            set { _platformObject = value; }
        }
        public void DoCalculation()
        {
            CalculateOtherTest();
        }
            
        private void CalculateOtherTest()
        {
            _adultArtNewPatientBloodDraws = ArtSite.AITNewPatientBloodDraws;
            _adultArtExistingPatientBloodDraws = ArtSite.AITExistingPatientBloodDraws;
            _adultPreArtNewPatientBloodDraws = ArtSite.AIPNewPatientBloodDraws;
            _adultPreArtExistingPatientBloodDraws = ArtSite.AIPExistingPatientBloodDraws;

            _pedArtNewPatientBloodDraws = ArtSite.PITNewPatientBloodDraws;
            _pedArtExistingPatientBloodDraws = ArtSite.PITExistingPatientBloodDraws;
            _pedPreArtNewPatientBloodDraws = ArtSite.PIPNewPatientBloodDraws;
            _pedPreArtExistingPatientBloodDraws = ArtSite.PIPExistingPatientBloodDraws;
                       

            for (int i = 1; i <= 12; i++)
            {
                MOutputConsumable otherOut = new MOutputConsumable();
                otherOut.Month = i;
                otherOut.AdultArtExistingPatientBloodDraws = (CalculatedPatientNos[i].ArtAdultPreExistingPatients * (_adultArtExistingPatientBloodDraws / 12d));
                otherOut.AdultArtNewPatientBloodDraws = (CalculatedPatientNos[i].TotalArtAdultPatientsEntering() * (_adultArtNewPatientBloodDraws / 12d));
                otherOut.AdultPreArtExistingPatientBloodDraws = (CalculatedPatientNos[i].PreArtAdultPreExistingPatients * (_adultPreArtExistingPatientBloodDraws / 12d));
                otherOut.AdultPreArtNewPatientBloodDraws = (CalculatedPatientNos[i].TotalPreArtAdultPatientsEntering() * (_adultPreArtNewPatientBloodDraws / 12d));

                otherOut.PediatricArtExistingPatientBloodDraws = (CalculatedPatientNos[i].ArtPediatricPreExistingPatients * (_pedArtExistingPatientBloodDraws / 12d));
                otherOut.PediatricArtNewPatientBloodDraws = (CalculatedPatientNos[i].TotalArtPediatricPatientsEntering() * (_pedArtNewPatientBloodDraws / 12d));
                otherOut.PediatricPreArtExistingPatientBloodDraws = (CalculatedPatientNos[i].PreArtPediatricPreExistingPatients * (_pedPreArtExistingPatientBloodDraws / 12d));
                otherOut.PediatricPreArtNewPatientBloodDraws = (CalculatedPatientNos[i].TotalPreArtPediatricPatientsEntering() * (_pedPreArtNewPatientBloodDraws / 12d));

                if ((i + 1 >= PeriodInfo.BeginsOnmonth) && (i + 1 <= PeriodInfo.EndOnMonth))
                {
                    otherOut.TotalAdultBloodDrawsBeyondForecastPeriod = otherOut.GetSumOfAdultBloodDraws();
                    otherOut.TotalPediatricBloodDrawsBeyondForecastPeriod = otherOut.GetSumOfPediatricBloodDraws();
                    otherOut.TotalBloodDrawsBeyondForecastPeriod = otherOut.GetSumOfAdultBloodDraws() + otherOut.GetSumOfPediatricBloodDraws();
                }
                else
                {
                    otherOut.TotalAdultBloodDrawsBeyondForecastPeriod = 0;
                    otherOut.TotalPediatricBloodDrawsBeyondForecastPeriod = 0;
                    otherOut.TotalBloodDrawsBeyondForecastPeriod = 0;
                }

                if ((i + 1 >= PeriodInfo.FirstMonth) && (i + 1 <= PeriodInfo.LastMonth))
                {
                    otherOut.TotalAdultBloodDraws = otherOut.GetSumOfAdultBloodDraws();
                    otherOut.TotalPediatricBloodDraws = otherOut.GetSumOfPediatricBloodDraws();

                    otherOut.PositiveDiagnoses = RapidTestOutputs[i].AdultsPositiveDiagnoses + RapidTestOutputs[i].PediatricsPositiveDiagnoses;
                    otherOut.PositiveDiagnosesToReceiveCD4 = CD4MonthlyOutputs[i].TotalReceivingCD4Test();
                    otherOut.PositiveDiagnosesBufferStock = 0;
                    otherOut.PositiveDiagnosesToReceiveCD4BufferStock = 0;
                }
                else
                {
                    otherOut.TotalAdultBloodDraws = 0;
                    otherOut.TotalPediatricBloodDraws = 0;

                    otherOut.PositiveDiagnoses = 0;
                    otherOut.PositiveDiagnosesToReceiveCD4 = 0;
                    otherOut.PositiveDiagnosesBufferStock = RapidTestOutputs[i].AdultsPositiveDiagnoses + RapidTestOutputs[i].PediatricsPositiveDiagnoses;
                    otherOut.PositiveDiagnosesToReceiveCD4BufferStock = CD4MonthlyOutputs[i].TotalReceivingCD4Test();
                }
                _othMonthlyOutputs.Add(i, otherOut);
            }
                      
            _adultTotalBufferBeyondForecastPeriod = _othMonthlyOutputs[12].GetSumOfAdultBloodDraws() * PeriodInfo.NumberofBufferMonthsBeyondForecast;
            _pedTotalBufferBeyondForecastPeriod = _othMonthlyOutputs[12].GetSumOfPediatricBloodDraws() * PeriodInfo.NumberofBufferMonthsBeyondForecast;
            _PositiveDiagnosesBeyondForecastPeriod = (RapidTestOutputs[12].AdultsPositiveDiagnoses + RapidTestOutputs[12].PediatricsPositiveDiagnoses) * PeriodInfo.NumberofBufferMonthsBeyondForecast;
            _PositiveDiagnosesToReceiveCD4BeyondForecastPeriod = CD4MonthlyOutputs[12].TotalReceivingCD4Test() * PeriodInfo.NumberofBufferMonthsBeyondForecast;

            QMenuWithValue qvalue;
            //DOES THIS SITE RECEIVE CONSUMMABLE SUPPLIES?
            if (ArtSite.ForecastConsumable)
            {
                foreach (QuantifyMenu qm in _platformObject.GeneralQuantifyMenus)
                {
                    double value = 0;
                    if (qm.Title == GeneralQuantifyMenuEnum.Total_Positive_Diagnoses.ToString())
                        value = TotalPositiveDiagnoses();
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Positive_Diagnoses_to_Receive_CD4.ToString())
                        value = TotalPositiveDiagnosestoReceiveCD4();
                    else if (qm.Title == GeneralQuantifyMenuEnum.Total_Blood_Draws.ToString())
                        value = TOTALBloodDraws();
                    else if (qm.Title == GeneralQuantifyMenuEnum.Blood_Draws_Adult.ToString())
                        value = TotalAdultBloodDraws();
                    else if (qm.Title == GeneralQuantifyMenuEnum.Blood_Draws_Pediatric.ToString())
                        value = TotalPediatricBloodDraws();
                    else if (qm.Title == GeneralQuantifyMenuEnum.PerDay_PerSite.ToString())
                        value = PeriodInfo.WorkingDaysinBudgetPeriod;
                    else if (qm.Title == GeneralQuantifyMenuEnum.PerWeek_PerSite.ToString())
                        value = PeriodInfo.WeeksinBudgetPeriod;
                    else if (qm.Title == GeneralQuantifyMenuEnum.PerMonth_PerSite.ToString())
                        value = PeriodInfo.NumberofMonthsinBudgetPeriod;
                    else if (qm.Title == GeneralQuantifyMenuEnum.PerQuarter_PerSite.ToString())
                        value = PeriodInfo.QuartersinBudgetPeriod;
                    else if (qm.Title == GeneralQuantifyMenuEnum.PerYear_PerSite.ToString())
                        value = 1;
                    else
                    {
                        qvalue = null;
                        switch (qm.ClassOfTestToEnum)
                        {
                            case ClassOfMorbidityTestEnum.CD4:
                                qvalue = CD4TestCalculator.GetQMenuWithValueByQuantifyMenuId(qm.Id);                                
                                break;
                            case ClassOfMorbidityTestEnum.Chemistry:
                                qvalue = ChemistryTestCalculator.GetQMenuWithValueByQuantifyMenuId(qm.Id);
                                break;
                            case ClassOfMorbidityTestEnum.Hematology:
                                qvalue = HematologyTestCalculator.GetQMenuWithValueByQuantifyMenuId(qm.Id);
                                break;
                            case ClassOfMorbidityTestEnum.ViralLoad:
                                qvalue = ViralTestCalculator.GetQMenuWithValueByQuantifyMenuId(qm.Id);
                                break;
                            case ClassOfMorbidityTestEnum.RapidTest:
                                qvalue = RapidTestCalculator.GetQMenuWithValueByQuantifyMenuId(qm.Id);
                                break;
                        }
                        if (qvalue != null)
                            value = qvalue.SiteValue;
                    }

                    if (value > 0)
                    {
                        QMenuWithValue qval = new QMenuWithValue();
                        qval.QuantifyMenuId = qm.Id;
                        qval.SiteValue = value;
                        qval.ReferalSiteValue = 0;
                        _listOfQMenuWithValue.Add(qval);
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
                        pqr.Value = testperpack > 0 ? qm.SiteValue / testperpack : 0;
                        pqr.MinimumQuantity = r.Product.MinimumPackSize;
                        _lstPrimaryQuanReagents.AddPrimeryQR(pqr);
                    }
                }
            }

        }

        public double TotalAdultBloodDraws()
        {
            double result = 0;
            foreach (MOutputConsumable om in _othMonthlyOutputs.Values)
            {
                result += om.TotalAdultBloodDraws + om.TotalAdultBloodDrawsBeyondForecastPeriod;
            }
            return result;
        }

        public double TotalPediatricBloodDraws()
        {
            double result = 0;
            foreach (MOutputConsumable om in _othMonthlyOutputs.Values)
            {
                result += om.TotalPediatricBloodDraws + om.TotalPediatricBloodDrawsBeyondForecastPeriod;
            }
            return result;
        }

        public double TOTALBloodDraws()
        {
            double result = 0;
            foreach (MOutputConsumable om in _othMonthlyOutputs.Values)
            {
                result += om.TotalBloodDrawsBeyondForecastPeriod;
            }
            return result;
        }

        public double TotalPositiveDiagnoses()
        {
            double result = 0;
            foreach (MOutputConsumable om in _othMonthlyOutputs.Values)
            {
                result += om.PositiveDiagnoses + om.PositiveDiagnosesBufferStock;
            }
            return result;
        }

        public double TotalPositiveDiagnosestoReceiveCD4()
        {
            double result = 0;
            foreach (MOutputConsumable om in _othMonthlyOutputs.Values)
            {
                result += om.PositiveDiagnosesToReceiveCD4 + om.PositiveDiagnosesToReceiveCD4BufferStock;
            }
            return result;
        }

    }
}
