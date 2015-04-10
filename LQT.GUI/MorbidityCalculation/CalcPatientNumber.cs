
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
    public class CalcPatientNumber : BaseCalc
    {
        public double ArtAdulTargetOnMonth0{get; set;}
        public double ArtPedTargetOnMonth0 { get; set; }
        public double PreArtAdulTargetOnMonth0 { get; set; }
        public double PreArtPedTargetOnMonth0 { get; set; }

        public double AdultsMonthlyAttritionRateInTreatment { get; set; }
        public double PediatricsMonthlyAttritionRateinTreatment { get; set; }

        public double AdultsMonthlyAttritionRateInPreART { get; set; }
        public double PediatricsMonthlyAttritionRateinPreART { get; set; }
        public double AdultMonthlyMigrationtoTreatment { get; set; }
        public double PedMonthlyMigrationtoTreatment { get; set; }
        public double AdultCombinedMonthlyRate { get; set; }
        public double PedCombinedMonthlyRate { get; set; }
        public double TestingEfficiency { get; set; }
        public bool UseTestingE { get; set; }

        private Dictionary<int, CalculatedSitePatientNumber> _calcPatientNos;
        private bool _isCalculationDone = false;

        public CalcPatientNumber(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target)
            : base(site, forecast, periodinfo, target)
        {
            _calcPatientNos = new Dictionary<int, CalculatedSitePatientNumber>();

            if (site.NTTPercentOfChildren > 0)
            {
                ArtPedTargetOnMonth0 = site.GetNTTMonthValue(0) * (site.NTTPercentOfChildren / 100d);
                ArtAdulTargetOnMonth0 = site.GetNTTMonthValue(0) - ArtPedTargetOnMonth0;

                for (int i = 1; i <= 12; i++)
                {
                    CalculatedSitePatientNumber calcPatientNo = new CalculatedSitePatientNumber();
                    calcPatientNo.Month = i;
                    calcPatientNo.ArtPedMonthlyTarget = site.GetNTTMonthValue(i) * (site.NTTPercentOfChildren / 100d);
                    calcPatientNo.ArtAdultMonthlyTarget = site.GetNTTMonthValue(i) - calcPatientNo.ArtPedMonthlyTarget;
                    _calcPatientNos.Add(i, calcPatientNo);
                }
            }
            else
            {
                ArtPedTargetOnMonth0 = periodinfo.DefultMonthValue[0];
                ArtAdulTargetOnMonth0 = site.GetNTTMonthValue(0) - ArtPedTargetOnMonth0;

                for (int i = 1; i <= 12; i++)
                {
                    CalculatedSitePatientNumber calcPatientNo = new CalculatedSitePatientNumber();
                    calcPatientNo.Month = i;
                    calcPatientNo.ArtPedMonthlyTarget =periodinfo.DefultMonthValue[i];
                    calcPatientNo.ArtAdultMonthlyTarget = site.GetNTTMonthValue(i) - calcPatientNo.ArtPedMonthlyTarget;
                    _calcPatientNos.Add(i, calcPatientNo);
                }
            }

            //Pre-ART Target Breakdown (as entered by the user)
            if (site.NTPTPercentOfChildren > 0)
            {
                PreArtPedTargetOnMonth0 = site.GetNTPTMonthValue(0) * (site.NTPTPercentOfChildren / 100d);
                PreArtAdulTargetOnMonth0 = site.GetNTPTMonthValue(0) - PreArtPedTargetOnMonth0;

                for (int i = 1; i <= 12; i++)
                {
                    _calcPatientNos[i].PreArtPedMonthlyTarget = site.GetNTPTMonthValue(i) * (site.NTPTPercentOfChildren / 100d);
                    _calcPatientNos[i].PreArtAdultMonthlyTarget = site.GetNTPTMonthValue(i) - _calcPatientNos[i].PreArtPedMonthlyTarget;
                }
            }
            else
            {
                PreArtPedTargetOnMonth0 =periodinfo.DefultMonthValue[0];
                PreArtAdulTargetOnMonth0 = site.GetNTPTMonthValue(0) - PreArtPedTargetOnMonth0;

                for (int i = 1; i <= 12; i++)
                {
                    _calcPatientNos[i].PreArtPedMonthlyTarget = periodinfo.DefultMonthValue[i];
                    _calcPatientNos[i].PreArtAdultMonthlyTarget = site.GetNTPTMonthValue(i) - _calcPatientNos[i].PreArtPedMonthlyTarget;
                }
            }

            
            AdultsMonthlyAttritionRateInTreatment = Math.Round(1d - (Math.Pow(1d - (site.AITAnnualPatientAttrition / 100d), 1d / 12d)), 4, MidpointRounding.ToEven);
            AdultsMonthlyAttritionRateInPreART = Math.Round(1d - (Math.Pow(1d - (site.AIPAnualPatientAttrition / 100d), 1d / 12d)), 4, MidpointRounding.ToEven);
            
            AdultMonthlyMigrationtoTreatment = Math.Round(1d - (Math.Pow(1d - (site.AIPAnnualMigration / 100d), 1d / 12d)), 4, MidpointRounding.ToEven);            
            AdultCombinedMonthlyRate = AdultsMonthlyAttritionRateInPreART + AdultMonthlyMigrationtoTreatment;

            PediatricsMonthlyAttritionRateinTreatment = Math.Round(1d - Math.Pow((1d - (site.PITAnnualPatientAttrition / 100d)), (1d / 12d)), 4, MidpointRounding.ToEven);
            PediatricsMonthlyAttritionRateinPreART =Math.Round( 1 - (Math.Pow(1d - (site.PIPAnualPatientAttrition / 100d), 1d / 12d)), 4, MidpointRounding.ToEven);
            PedMonthlyMigrationtoTreatment = Math.Round(1 - (Math.Pow(1d - (site.PIPAnnualMigration / 100d), 1d / 12d)), 4, MidpointRounding.ToEven);
            PedCombinedMonthlyRate = PediatricsMonthlyAttritionRateinPreART + PedMonthlyMigrationtoTreatment;

            //CurrentPatientsAtSiteInTreatment = site.TimeZeroPatientOnTreatment;
            //CurrentPatientsAtSiteInPreArt = site.TimeZeroPatientOnPreTreatment;
            CurrentAdultinTreatment = site.TimeZeroPatientOnTreatment * (1d - (site.NTTPercentOfChildren / 100d));
            CurrentPediatricinTreatment = site.TimeZeroPatientOnTreatment * (site.NTTPercentOfChildren / 100d);
            CurrentAdultinPreArt = site.TimeZeroPatientOnPreTreatment * (1d - (site.NTPTPercentOfChildren / 100d));
            CurrentPediatricinPreArt = site.TimeZeroPatientOnPreTreatment * (site.NTPTPercentOfChildren / 100d);

            TestingEfficiency = Math.Round((site.AdultTestingEfficiency / 100d), 4, MidpointRounding.ToEven);
            UseTestingE = forecast.PreTreatmentPatinetTargetEnum == Core.Util.OptPreTreatmentPatinetTargetEnum.TestingEfficiency;

        }

        /// <summary>
        /// Calculated patient numbers
        /// </summary>
        public Dictionary<int, CalculatedSitePatientNumber> CalculatedPatientNumbers
        {
            get
            {
                if (!_isCalculationDone)
                    DoCalculation();
                return _calcPatientNos; 
            }
        }

        public void DoCalculation()
        {
            CalculateAdultARTTargets();
            CalculatePediatricARTTargets();
            CalculateAdultPreArtTargets();
            CalculatePediatricPreArtTargets();
            CalculatePatientMigration();
        }

        #region TOTAL ART Targets

        private void CalculateAdultARTTargets()
        {
            if (TargetSelected == 1)
            {
                double[,] preExist = new double[12, 3]; //0=> Pre-Existing Patients, 1=> Patients Lost, 2=> Incremental Increase


                preExist[0, 0] = ArtAdulTargetOnMonth0 * (1 - AdultsMonthlyAttritionRateInTreatment);
                preExist[0, 1] = ArtAdulTargetOnMonth0 - preExist[0, 0];
                preExist[0, 2] = _calcPatientNos[1].ArtAdultMonthlyTarget - ArtAdulTargetOnMonth0;

                for (int i = 1; i < 12; i++)
                {
                    preExist[i, 0] = preExist[i - 1, 0] * (1 - AdultsMonthlyAttritionRateInTreatment);
                    preExist[i, 1] = preExist[i - 1, 0] - preExist[i, 0];
                    preExist[i, 2] = _calcPatientNos[i + 1].ArtAdultMonthlyTarget - _calcPatientNos[i].ArtAdultMonthlyTarget;
                }

                double[,] cohort = new double[12, 12];
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        if (x == i)
                        {
                            double t = 0;
                            for (int z = 0; z < x; z++)
                            {
                                t += (cohort[z, x - 1] - cohort[z, x]);
                            }
                            cohort[i, i] = preExist[x, 1] + preExist[x, 2] + t;
                            _calcPatientNos[i + 1].ArtNewAdultPatients = cohort[i, i];
                        }
                        else if (i > x)
                        {
                            cohort[i, x] = 0;
                        }
                        else
                        {
                            cohort[i, x] = cohort[i, x - 1] * (1 - AdultsMonthlyAttritionRateInTreatment);
                        }
                    }
                }
            }
            else
            {
                _calcPatientNos[1].ArtNewAdultPatients = _calcPatientNos[1].ArtAdultMonthlyTarget - ArtAdulTargetOnMonth0;
                for (int i = 2; i <= 12; i++)
                {
                    _calcPatientNos[i].ArtNewAdultPatients = _calcPatientNos[i].ArtAdultMonthlyTarget - _calcPatientNos[i - 1].ArtAdultMonthlyTarget;
                }
            }
        }

        private void CalculatePediatricARTTargets()
        {
            if (TargetSelected == 1)
            {
                double[,] preExist = new double[12, 3];

                preExist[0, 0] = ArtPedTargetOnMonth0 * (1 - PediatricsMonthlyAttritionRateinTreatment);
                preExist[0, 1] = ArtPedTargetOnMonth0 - preExist[0, 0];
                preExist[0, 2] = _calcPatientNos[1].ArtPedMonthlyTarget - ArtPedTargetOnMonth0;

                for (int i = 1; i < 12; i++)
                {
                    preExist[i, 0] = preExist[i - 1, 0] * (1 - PediatricsMonthlyAttritionRateinTreatment);
                    preExist[i, 1] = preExist[i - 1, 0] - preExist[i, 0];
                    preExist[i, 2] = _calcPatientNos[i + 1].ArtPedMonthlyTarget - _calcPatientNos[i].ArtPedMonthlyTarget;
                }

                double[,] cohort = new double[12, 12];
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        if (x == i)
                        {
                            double t = 0;
                            for (int z = 0; z < x; z++)
                            {
                                t += (cohort[z, x - 1] - cohort[z, x]);
                            }
                            cohort[i, i] = preExist[x, 1] + preExist[x, 2] + t;
                            _calcPatientNos[i + 1].ArtNewPedPatients = cohort[i, i];
                        }
                        else if (i > x)
                        {
                            cohort[i, x] = 0;
                        }
                        else
                        {
                            cohort[i, x] = cohort[i, x - 1] * (1 - PediatricsMonthlyAttritionRateinTreatment);
                        }
                    }
                }
            }
            else
            {
                _calcPatientNos[1].ArtNewPedPatients = _calcPatientNos[1].ArtPedMonthlyTarget - ArtPedTargetOnMonth0;
                for (int i = 2; i <= 12; i++)
                {
                    _calcPatientNos[i].ArtNewPedPatients = _calcPatientNos[i].ArtPedMonthlyTarget - _calcPatientNos[i - 1].ArtPedMonthlyTarget;
                }
            }
        }

        #endregion

        #region TOTAL Pre-ART Targets

        private void CalculateAdultPreArtTargets()
        {
            if (TargetSelected == 1)
            {
                double[,] preExist = new double[12, 3];
                preExist[0, 0] = PreArtAdulTargetOnMonth0 * (1 - AdultCombinedMonthlyRate);
                preExist[0, 1] = PreArtAdulTargetOnMonth0 - preExist[0, 0];
                preExist[0, 2] = _calcPatientNos[1].PreArtAdultMonthlyTarget - PreArtAdulTargetOnMonth0;

                for (int i = 1; i < 12; i++)
                {
                    preExist[i, 0] = preExist[i - 1, 0] * (1 - AdultCombinedMonthlyRate);
                    preExist[i, 1] = preExist[i - 1, 0] - preExist[i, 0];
                    preExist[i, 2] = _calcPatientNos[i + 1].PreArtAdultMonthlyTarget - _calcPatientNos[i].PreArtAdultMonthlyTarget;
                }

                double[,] cohort = new double[12, 12];
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        if (x == i)
                        {
                            double t = 0;
                            for (int z = 0; z < x; z++)
                            {
                                t += (cohort[z, x - 1] - cohort[z, x]);
                            }
                            cohort[i, x] = preExist[x, 1] + preExist[x, 2] + t;
                            _calcPatientNos[i + 1].PreartNewAdultPatients = cohort[i, x];
                        }
                        else if (i > x)
                        {
                            cohort[i, x] = 0;
                        }
                        else
                        {
                            cohort[i, x] = cohort[i, x - 1] * (1 - AdultCombinedMonthlyRate);
                        }
                    }
                }
            }
            else
            {
                _calcPatientNos[1].PreartNewAdultPatients = _calcPatientNos[1].PreArtAdultMonthlyTarget - PreArtAdulTargetOnMonth0;
                for (int i = 2; i <= 12; i++)
                {
                    _calcPatientNos[i].PreartNewAdultPatients = _calcPatientNos[i].PreArtAdultMonthlyTarget - _calcPatientNos[i - 1].PreArtAdultMonthlyTarget;
                }
            }
        }

        private void CalculatePediatricPreArtTargets()
        {
            if (TargetSelected == 1)
            {
                double[,] preExist = new double[12, 3];
                preExist[0, 0] = PreArtPedTargetOnMonth0 * (1 - PedCombinedMonthlyRate);
                preExist[0, 1] = PreArtPedTargetOnMonth0 - preExist[0, 0];
                preExist[0, 2] = _calcPatientNos[1].PreArtPedMonthlyTarget - PreArtPedTargetOnMonth0;

                for (int i = 1; i < 12; i++)
                {
                    preExist[i, 0] = preExist[i - 1, 0] * (1 - PedCombinedMonthlyRate);
                    preExist[i, 1] = preExist[i - 1, 0] - preExist[i, 0];
                    preExist[i, 2] = _calcPatientNos[i + 1].PreArtPedMonthlyTarget - _calcPatientNos[i].PreArtPedMonthlyTarget;
                }

                double[,] cohort = new double[12, 12];
                for (int i = 0; i < 12; i++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        if (x == i)
                        {
                            double t = 0;
                            for (int z = 0; z < x; z++)
                            {
                                t += (cohort[z, x - 1] - cohort[z, x]);
                            }
                            cohort[i, x] = preExist[x, 1] + preExist[x, 2] + t;
                            _calcPatientNos[i + 1].PreArtNewPedPatients = cohort[i, x];
                        }
                        else if (i > x)
                        {
                            cohort[i, x] = 0;
                        }
                        else
                        {
                            cohort[i, x] = cohort[i, x - 1] * (1 - PedCombinedMonthlyRate);
                        }
                    }
                }
            }
            else
            {
                _calcPatientNos[1].PreArtNewPedPatients = _calcPatientNos[1].PreArtPedMonthlyTarget - PreArtPedTargetOnMonth0;
                for (int i = 2; i <= 12; i++)
                {
                    _calcPatientNos[i].PreArtNewPedPatients = _calcPatientNos[i].PreArtPedMonthlyTarget - _calcPatientNos[i - 1].PreArtPedMonthlyTarget;
                }
            }
        }
        #endregion

        #region Patient Targets Adjusted for Migration

        private void CalculatePatientMigration()
        {
            //-----------------------------adult section----------------------------------

            double adultInTrea = ArtSite.TimeZeroPatientOnTreatment * (1 - (ArtSite.NTTPercentOfChildren / 100d));
            double pedInTrea = ArtSite.TimeZeroPatientOnTreatment * (ArtSite.NTTPercentOfChildren / 100d);
            double adultInPre = ArtSite.TimeZeroPatientOnPreTreatment * (1 - (ArtSite.NTPTPercentOfChildren / 100d));
            double pedInPre = ArtSite.TimeZeroPatientOnPreTreatment * (ArtSite.NTPTPercentOfChildren / 100d);

            _calcPatientNos[1].ArtAdultPreExistingPatients = adultInTrea - (adultInTrea * AdultsMonthlyAttritionRateInTreatment);
            DistributAdultExistingPatients();

            _calcPatientNos[1].AdultMigratingintoARTfromPreART = adultInPre * AdultMonthlyMigrationtoTreatment;
            _calcPatientNos[1].AdultEnteringARTfromoutsidePreART = _calcPatientNos[1].ArtNewAdultPatients - _calcPatientNos[1].AdultMigratingintoARTfromPreART < 0 ? 0 : _calcPatientNos[1].ArtNewAdultPatients - _calcPatientNos[1].AdultMigratingintoARTfromPreART;
            _calcPatientNos[1].AdultHIVdiagnosesRequired = TestingEfficiency > 0 ? _calcPatientNos[1].AdultEnteringARTfromoutsidePreART / TestingEfficiency : 0;

            if (UseTestingE)
                _calcPatientNos[1].AdultEnteringpreARTeachmonth = _calcPatientNos[1].AdultHIVdiagnosesRequired - _calcPatientNos[1].AdultEnteringARTfromoutsidePreART;
            else
                _calcPatientNos[1].AdultEnteringpreARTeachmonth = _calcPatientNos[1].PreartNewAdultPatients;

            _calcPatientNos[1].AdultAdjustedpreARTtargets = adultInPre + _calcPatientNos[1].AdultEnteringpreARTeachmonth;

            _calcPatientNos[1].PreArtAdultPreExistingPatients = adultInPre - _calcPatientNos[1].AdultMigratingintoARTfromPreART - (adultInPre * AdultsMonthlyAttritionRateInPreART);
            _calcPatientNos[1].SetPreArtAdultPatientsEntering(1, _calcPatientNos[1].AdultEnteringpreARTeachmonth);

            _calcPatientNos[1].SetArtAdultPatientsEntering(1, _calcPatientNos[1].AdultMigratingintoARTfromPreART + _calcPatientNos[1].AdultEnteringARTfromoutsidePreART);
            DistributAdultPatientsEntering(1);

            //---------------------------------pediatric section----------------------------

            _calcPatientNos[1].ArtPediatricPreExistingPatients = pedInTrea - (pedInTrea * PediatricsMonthlyAttritionRateinTreatment);
            DistributPediatricExistingPatients();

            _calcPatientNos[1].PediatricMigratingintoARTfromPreART = pedInPre * PedMonthlyMigrationtoTreatment;
            _calcPatientNos[1].PediatricEnteringARTfromoutsidePreART = _calcPatientNos[1].ArtNewPedPatients - _calcPatientNos[1].PediatricMigratingintoARTfromPreART < 0 ? 0 : _calcPatientNos[1].ArtNewPedPatients - _calcPatientNos[1].PediatricMigratingintoARTfromPreART;
            _calcPatientNos[1].PediatricHIVdiagnosesRequired = TestingEfficiency > 0 ? _calcPatientNos[1].PediatricEnteringARTfromoutsidePreART / TestingEfficiency : 0;

            if (UseTestingE)
                _calcPatientNos[1].PediatricEnteringpreARTeachmonth = _calcPatientNos[1].PediatricHIVdiagnosesRequired - _calcPatientNos[1].PediatricEnteringARTfromoutsidePreART;
            else
                _calcPatientNos[1].PediatricEnteringpreARTeachmonth = _calcPatientNos[1].PreArtNewPedPatients;
            _calcPatientNos[1].PediatricAdjustedpreARTtargets = pedInPre + _calcPatientNos[1].PediatricEnteringpreARTeachmonth;

            _calcPatientNos[1].PreArtPediatricPreExistingPatients = pedInPre - _calcPatientNos[1].PediatricMigratingintoARTfromPreART - (pedInPre * PediatricsMonthlyAttritionRateinPreART);
            _calcPatientNos[1].SetPreArtPediatricPatientsEntering(1, _calcPatientNos[1].PediatricEnteringpreARTeachmonth);
            _calcPatientNos[1].SetArtPediatricPatientsEntering(1, _calcPatientNos[1].PediatricMigratingintoARTfromPreART + _calcPatientNos[1].PediatricEnteringARTfromoutsidePreART);
            DistributPediatricPatientsEntering(1);

            for (int i = 2; i <= 12; i++)
            {
                double total, pedtotal;
                total = pedtotal = 0;

                for (int x = 1; x <= i; x++)
                {
                    if (x == 1)
                    {
                        total = (_calcPatientNos[i - 1].PreArtAdultPreExistingPatients * AdultMonthlyMigrationtoTreatment);
                        _calcPatientNos[i].PreArtAdultPreExistingPatients = _calcPatientNos[i - 1].PreArtAdultPreExistingPatients -
                                (_calcPatientNos[i - 1].PreArtAdultPreExistingPatients * AdultMonthlyMigrationtoTreatment) -
                                (_calcPatientNos[i - 1].PreArtAdultPreExistingPatients * AdultsMonthlyAttritionRateInPreART);

                        pedtotal += (_calcPatientNos[i - 1].PreArtPediatricPreExistingPatients * PedMonthlyMigrationtoTreatment);
                        _calcPatientNos[i].PreArtPediatricPreExistingPatients = _calcPatientNos[i - 1].PreArtPediatricPreExistingPatients -
                                    (_calcPatientNos[i - 1].PreArtPediatricPreExistingPatients * PedMonthlyMigrationtoTreatment) -
                                    (_calcPatientNos[i - 1].PreArtPediatricPreExistingPatients * PediatricsMonthlyAttritionRateinPreART);
                    }
                    else
                    {
                        total += (_calcPatientNos[i - 1].GetPreArtAdultPatientsEntering(x - 1) * AdultMonthlyMigrationtoTreatment);
                        _calcPatientNos[i].SetPreArtAdultPatientsEntering(x - 1, _calcPatientNos[i - 1].GetPreArtAdultPatientsEntering(x - 1)
                            - (_calcPatientNos[i - 1].GetPreArtAdultPatientsEntering(x - 1) * AdultMonthlyMigrationtoTreatment) -
                            (_calcPatientNos[i - 1].GetPreArtAdultPatientsEntering(x - 1) * AdultsMonthlyAttritionRateInPreART));

                        pedtotal += (_calcPatientNos[i - 1].GetPreArtPediatricPatientsEntering(x - 1) * PedMonthlyMigrationtoTreatment);

                        _calcPatientNos[i].SetPreArtPediatricPatientsEntering(x - 1, _calcPatientNos[i - 1].GetPreArtPediatricPatientsEntering(x - 1) -
                            (_calcPatientNos[i - 1].GetPreArtPediatricPatientsEntering(x - 1) * PedMonthlyMigrationtoTreatment) -
                            (_calcPatientNos[i - 1].GetPreArtPediatricPatientsEntering(x - 1) * PediatricsMonthlyAttritionRateinPreART));
                    }
                }

                _calcPatientNos[i].AdultMigratingintoARTfromPreART = total;
                _calcPatientNos[i].AdultEnteringARTfromoutsidePreART = _calcPatientNos[i].ArtNewAdultPatients - _calcPatientNos[i].AdultMigratingintoARTfromPreART < 0 ? 0 : _calcPatientNos[i].ArtNewAdultPatients - _calcPatientNos[i].AdultMigratingintoARTfromPreART;
                _calcPatientNos[i].AdultHIVdiagnosesRequired = _calcPatientNos[i].AdultEnteringARTfromoutsidePreART / TestingEfficiency;

                if (UseTestingE)
                    _calcPatientNos[i].AdultEnteringpreARTeachmonth = _calcPatientNos[i].AdultHIVdiagnosesRequired - _calcPatientNos[i].AdultEnteringARTfromoutsidePreART;
                else
                    _calcPatientNos[i].AdultEnteringpreARTeachmonth = _calcPatientNos[i].PreartNewAdultPatients;

                _calcPatientNos[i].AdultAdjustedpreARTtargets = _calcPatientNos[i - 1].AdultAdjustedpreARTtargets + _calcPatientNos[i].AdultEnteringpreARTeachmonth;

                _calcPatientNos[i].SetPreArtAdultPatientsEntering(i, _calcPatientNos[i].AdultEnteringpreARTeachmonth);
                _calcPatientNos[i].SetArtAdultPatientsEntering(i, _calcPatientNos[i].AdultMigratingintoARTfromPreART + _calcPatientNos[i].AdultEnteringARTfromoutsidePreART);
                DistributAdultPatientsEntering(i);

                //-----------Pediatric
                _calcPatientNos[i].PediatricMigratingintoARTfromPreART = pedtotal;
                _calcPatientNos[i].PediatricEnteringARTfromoutsidePreART = _calcPatientNos[i].ArtNewPedPatients - _calcPatientNos[i].PediatricMigratingintoARTfromPreART < 0 ? 0 : _calcPatientNos[i].ArtNewPedPatients - _calcPatientNos[i].PediatricMigratingintoARTfromPreART;
                _calcPatientNos[i].PediatricHIVdiagnosesRequired = _calcPatientNos[i].PediatricEnteringARTfromoutsidePreART / TestingEfficiency;

                if (UseTestingE)
                    _calcPatientNos[i].PediatricEnteringpreARTeachmonth = _calcPatientNos[i].PediatricHIVdiagnosesRequired - _calcPatientNos[i].PediatricEnteringARTfromoutsidePreART;
                else
                    _calcPatientNos[i].PediatricEnteringpreARTeachmonth = _calcPatientNos[i].PreArtNewPedPatients;

                _calcPatientNos[i].PediatricAdjustedpreARTtargets = _calcPatientNos[i - 1].PediatricAdjustedpreARTtargets + _calcPatientNos[i].PediatricEnteringpreARTeachmonth;

                _calcPatientNos[i].SetPreArtPediatricPatientsEntering(i, _calcPatientNos[i].PediatricEnteringpreARTeachmonth);
                _calcPatientNos[i].SetArtPediatricPatientsEntering(i, _calcPatientNos[i].PediatricMigratingintoARTfromPreART + _calcPatientNos[i].PediatricEnteringARTfromoutsidePreART);
                DistributPediatricPatientsEntering(i);
            }
        }

        private void DistributAdultExistingPatients()
        {
            for (int i = 2; i <= 12; i++)
            {
                _calcPatientNos[i].ArtAdultPreExistingPatients = _calcPatientNos[i - 1].ArtAdultPreExistingPatients - (_calcPatientNos[i - 1].ArtAdultPreExistingPatients * AdultsMonthlyAttritionRateInTreatment);
            }
        }

        private void DistributAdultPatientsEntering(int month)
        {
            for (int i = month + 1; i <= 12; i++)
            {
                _calcPatientNos[i].SetArtAdultPatientsEntering(month, _calcPatientNos[i - 1].GetArtAdultPatientsEntering(month) - (_calcPatientNos[i - 1].GetArtAdultPatientsEntering(month) * AdultsMonthlyAttritionRateInTreatment));
            }
        }

        private void DistributPediatricExistingPatients()
        {
            for (int i = 2; i <= 12; i++)
            {
                _calcPatientNos[i].ArtPediatricPreExistingPatients = _calcPatientNos[i - 1].ArtPediatricPreExistingPatients - (_calcPatientNos[i - 1].ArtPediatricPreExistingPatients * PediatricsMonthlyAttritionRateinTreatment);
            }
        }
        private void DistributPediatricPatientsEntering(int month)
        {
            for (int i = month + 1; i <= 12; i++)
            {
                _calcPatientNos[i].SetArtPediatricPatientsEntering(month, _calcPatientNos[i - 1].GetArtPediatricPatientsEntering(month) - (_calcPatientNos[i - 1].GetArtPediatricPatientsEntering(month) * PediatricsMonthlyAttritionRateinTreatment));
            }
        }


        #endregion
    }
}
