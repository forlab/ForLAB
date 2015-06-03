
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

namespace LQT.Core.Domain
{	
	/// <summary>
	/// MordidityCategorySite object for NHibernate mapped table 'MordidityCategorySite'.
	/// </summary>
	public class ARTSite
    {
        #region properties

        private int _id;
		private bool _forecastVCT;
		private bool _forecastCD4;
		private bool _forecastChemistry;
		private bool _forecastHematology;
		private bool _forecastViralLoad;
		private bool _forecastOtherTest;
		private bool _forecastConsumable;
        private double _timeZeroPatientOnTreatment;
        private double _timeZeroPatientOnPreTreatment;
        private double _oldDataPatientOnTreatment;
        private double _oldDataPatientOnPreTreatment;
        private double _oldDataPatientOnTreatmentPercent;
        private double _oldDataPatientOnPreTreatmentPercent;
        private double _everSTimeZeroPatientOnTreatment;
        private double _everSTimeZeroPatientOnPreTreatment;
        private double _everSPatientOnTreatment;
        private double _everSPatientOnTreatmentPercent;
        private double _everSPatientOnPreTreatment;
        private double _everSPatientOnPreTreatmentPercent;
        private double _nTPTRecentMonth;
        private double _nTPTJanuary;
        private double _nTPTFebruary;
        private double _nTPTMarch;
        private double _nTPTApril;
        private double _nTPTMay;
        private double _nTPTJune;
        private double _nTPTJuly;
        private double _nTPTAugust;
        private double _nTPTSeptember;
        private double _nTPTOctober;
        private double _nTPTNovember;
        private double _nTPTDecember;
        private double _nTPTPercentOfChildren;
        private double _nTPTGrowthTarget;
        private bool _nTPTApplyLinerGrowth;
        private double _nTTRecentMonth;
        private double _nTTJanuary;
        private double _nTTFebruary;
        private double _nTTMarch;
        private double _nTTApril;
        private double _nTTMay;
        private double _nTTJune;
        private double _nTTJuly;
        private double _nTTAugust;
        private double _nTTSeptember;
        private double _nTTOctober;
        private double _nTTNovember;
        private double _nTTDecember;
        private double _nTTPercentOfChildren;
        private double _nTTGrowthTarget;
        private bool _nTTApplyLinerGrowth;
        private double _adultTestingPopulation;
        private double _pediatricTestingPopulation;
        private double _adultDepartWoutFollowup;
        private double _pediatricDepartWoutFollowup;
        private double _diagnosesReceiveCD4;
        private double _aITAnnualPatientAttrition;
        private double _aITExistingPatientBloodDraws;
        private double _aITNewPatientBloodDraws;
        private double _aIPAnualPatientAttrition;
        private double _aIPAnnualMigration;
        private double _aIPExistingPatientBloodDraws;
        private double _aIPNewPatientBloodDraws;
        private double _pITAnnualPatientAttrition;
        private double _pITExistingPatientBloodDraws;
        private double _pITNewPatientBloodDraws;
        private double _pIPAnualPatientAttrition;
        private double _pIPAnnualMigration;
        private double _pIPExistingPatientBloodDraws;
        private double _pIPNewPatientBloodDraws;
        private double _adultTestingEfficiency;
        private double _pediatricTestingEfficiency;
        private double _pediatricsPreExistingPatients;
        private double _scrTest1Percent;
        private int _scrTest1;
        private double _scrTest2Percent;
        private int _scrTest2;
        private double _scrTest3Percent;
        private int _scrTest3;
        private double _conTest1Percent;
        private int _conTest1;
        private double _conTest2Percent;
        private int _conTest2;
        private double _conTest3Percent;
        private int _conTest3;
        private double _tieTest1Percent;
        private int _tieTest1;
        private double _tieTest2Percent;
        private int _tieTest2;
        private double _tieTest3Percent;
        private int _tieTest3;
		private MorbidityCategory _morbidityCategory;
		private ForlabSite _site;

        #endregion

        #region Constructors

        public ARTSite() 
		{
			this._id = -1;
            _forecastCD4 = true;
            _forecastChemistry = true;
            _forecastConsumable = true;
            _forecastHematology = true;
            _forecastOtherTest = true;
            _forecastVCT = true;
            _forecastViralLoad = true;
            _nTPTApplyLinerGrowth = false;
            _nTTApplyLinerGrowth = false;
		}


		#endregion
        		
		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

        #region Testing Services and Supplies
        
        public virtual bool ForecastVCT
		{
			get { return _forecastVCT; }
			set { _forecastVCT = value; }
		}

		public virtual bool ForecastCD4
		{
			get { return _forecastCD4; }
			set { _forecastCD4 = value; }
		}

		public virtual bool ForecastChemistry
		{
			get { return _forecastChemistry; }
			set { _forecastChemistry = value; }
		}

		public virtual bool ForecastHematology
		{
			get { return _forecastHematology; }
			set { _forecastHematology = value; }
		}

		public virtual bool ForecastViralLoad
		{
			get { return _forecastViralLoad; }
			set { _forecastViralLoad = value; }
		}

		public virtual bool ForecastOtherTest
		{
			get { return _forecastOtherTest; }
			set { _forecastOtherTest = value; }
		}

		public virtual bool ForecastConsumable
		{
			get { return _forecastConsumable; }
			set { _forecastConsumable = value; }
		}

        #endregion

        /// <summary>
        /// Current Patient Numbers by Site
        /// </summary>
        public virtual double TimeZeroPatientOnTreatment
        {
            get { return _timeZeroPatientOnTreatment; }
            set { _timeZeroPatientOnTreatment = value; }
        }

        /// <summary>
        /// Current Patient Numbers by Site
        /// </summary>
        public virtual double TimeZeroPatientOnPreTreatment
        {
            get { return _timeZeroPatientOnPreTreatment; }
            set { _timeZeroPatientOnPreTreatment = value; }
        }

        public virtual double OldDataPatientOnTreatment
        {
            get { return _oldDataPatientOnTreatment; }
            set { _oldDataPatientOnTreatment = value; }
        }

        public virtual double OldDataPatientOnPreTreatment
        {
            get { return _oldDataPatientOnPreTreatment; }
            set { _oldDataPatientOnPreTreatment = value; }
        }

        public virtual double OldDataPatientOnTreatmentPercent
        {
            get { return _oldDataPatientOnTreatmentPercent; }
            set { _oldDataPatientOnTreatmentPercent = value; }
        }

        public virtual double OldDataPatientOnPreTreatmentPercent
        {
            get { return _oldDataPatientOnPreTreatmentPercent; }
            set { _oldDataPatientOnPreTreatmentPercent = value; }
        }

        /// <summary>
        /// EVER STARTED Patient Numbers by Site
        /// </summary>
        public virtual double EverSTimeZeroPatientOnTreatment
        {
            get { return _everSTimeZeroPatientOnTreatment; }
            set { _everSTimeZeroPatientOnTreatment = value; }
        }

        /// <summary>
        /// EVER STARTED Patient Numbers by Site
        /// </summary>
        public virtual double EverSTimeZeroPatientOnPreTreatment
        {
            get { return _everSTimeZeroPatientOnPreTreatment; }
            set { _everSTimeZeroPatientOnPreTreatment = value; }
        }

        public virtual double EverSPatientOnTreatment
        {
            get { return _everSPatientOnTreatment; }
            set { _everSPatientOnTreatment = value; }
        }

        public virtual double EverSPatientOnTreatmentPercent
        {
            get { return _everSPatientOnTreatmentPercent; }
            set { _everSPatientOnTreatmentPercent = value; }
        }

        public virtual double EverSPatientOnPreTreatment
        {
            get { return _everSPatientOnPreTreatment; }
            set { _everSPatientOnPreTreatment = value; }
        }

        public virtual double EverSPatientOnPreTreatmentPercent
        {
            get { return _everSPatientOnPreTreatmentPercent; }
            set { _everSPatientOnPreTreatmentPercent = value; }
        }

        #region National Pre-ART Targets
        
        /// <summary>
        /// National Pre-ART Targets recent month
        /// </summary>
        public virtual double NTPTRecentMonth
        {
            get { return _nTPTRecentMonth; }
            set { _nTPTRecentMonth = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTJanuary
        {
            get { return _nTPTJanuary; }
            set { _nTPTJanuary = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTFebruary
        {
            get { return _nTPTFebruary; }
            set { _nTPTFebruary = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTMarch
        {
            get { return _nTPTMarch; }
            set { _nTPTMarch = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTApril
        {
            get { return _nTPTApril; }
            set { _nTPTApril = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTMay
        {
            get { return _nTPTMay; }
            set { _nTPTMay = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTJune
        {
            get { return _nTPTJune; }
            set { _nTPTJune = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTJuly
        {
            get { return _nTPTJuly; }
            set { _nTPTJuly = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTAugust
        {
            get { return _nTPTAugust; }
            set { _nTPTAugust = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTSeptember
        {
            get { return _nTPTSeptember; }
            set { _nTPTSeptember = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTOctober
        {
            get { return _nTPTOctober; }
            set { _nTPTOctober = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTNovember
        {
            get { return _nTPTNovember; }
            set { _nTPTNovember = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTDecember
        {
            get { return _nTPTDecember; }
            set { _nTPTDecember = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual double NTPTPercentOfChildren
        {
            get { return _nTPTPercentOfChildren; }
            set { _nTPTPercentOfChildren = value; }
        }

        //National Pre-ART Targets
        public virtual double NTPTGrowthTarget
        {
            get { return _nTPTGrowthTarget; }
            set { _nTPTGrowthTarget = value; }
        }

        /// <summary>
        /// National Pre-ART Targets
        /// </summary>
        public virtual bool NTPTApplyLinerGrowth
        {
            get { return _nTPTApplyLinerGrowth; }
            set { _nTPTApplyLinerGrowth = value; }
        }

        #endregion
        
        #region National Treatment Targets
        
        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTRecentMonth
        {
            get { return _nTTRecentMonth; }
            set { _nTTRecentMonth = value; }
        }
        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTJanuary
        {
            get { return _nTTJanuary; }
            set { _nTTJanuary = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTFebruary
        {
            get { return _nTTFebruary; }
            set { _nTTFebruary = value; }
        }
        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTMarch
        {
            get { return _nTTMarch; }
            set { _nTTMarch = value; }
        }
        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTApril
        {
            get { return _nTTApril; }
            set { _nTTApril = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTMay
        {
            get { return _nTTMay; }
            set { _nTTMay = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTJune
        {
            get { return _nTTJune; }
            set { _nTTJune = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTJuly
        {
            get { return _nTTJuly; }
            set { _nTTJuly = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTAugust
        {
            get { return _nTTAugust; }
            set { _nTTAugust = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTSeptember
        {
            get { return _nTTSeptember; }
            set { _nTTSeptember = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTOctober
        {
            get { return _nTTOctober; }
            set { _nTTOctober = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTNovember
        {
            get { return _nTTNovember; }
            set { _nTTNovember = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTDecember
        {
            get { return _nTTDecember; }
            set { _nTTDecember = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTPercentOfChildren
        {
            get { return _nTTPercentOfChildren; }
            set { _nTTPercentOfChildren = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual double NTTGrowthTarget
        {
            get { return _nTTGrowthTarget; }
            set { _nTTGrowthTarget = value; }
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        public virtual bool NTTApplyLinerGrowth
        {
            get { return _nTTApplyLinerGrowth; }
            set { _nTTApplyLinerGrowth = value; }
        }

        #endregion

        #region public property
        public virtual double AdultTestingPopulation
        {
            get { return _adultTestingPopulation; }
            set { _adultTestingPopulation = value; }
        }

        public virtual double PediatricTestingPopulation
        {
            get { return _pediatricTestingPopulation; }
            set { _pediatricTestingPopulation = value; }
        }

        public virtual double AdultDepartWoutFollowup
        {
            get { return _adultDepartWoutFollowup; }
            set { _adultDepartWoutFollowup = value; }
        }

        public virtual double PediatricDepartWoutFollowup
        {
            get { return _pediatricDepartWoutFollowup; }
            set { _pediatricDepartWoutFollowup = value; }
        }

        public virtual double DiagnosesReceiveCD4
        {
            get { return _diagnosesReceiveCD4; }
            set { _diagnosesReceiveCD4 = value; }
        }

        public virtual double AITAnnualPatientAttrition
        {
            get { return _aITAnnualPatientAttrition; }
            set { _aITAnnualPatientAttrition = value; }
        }

        public virtual double AITExistingPatientBloodDraws
        {
            get { return _aITExistingPatientBloodDraws; }
            set { _aITExistingPatientBloodDraws = value; }
        }

        public virtual double AITNewPatientBloodDraws
        {
            get { return _aITNewPatientBloodDraws; }
            set { _aITNewPatientBloodDraws = value; }
        }

        public virtual double AIPAnualPatientAttrition
        {
            get { return _aIPAnualPatientAttrition; }
            set { _aIPAnualPatientAttrition = value; }
        }

        public virtual double AIPAnnualMigration
        {
            get { return _aIPAnnualMigration; }
            set { _aIPAnnualMigration = value; }
        }

        public virtual double AIPExistingPatientBloodDraws
        {
            get { return _aIPExistingPatientBloodDraws; }
            set { _aIPExistingPatientBloodDraws = value; }
        }

        public virtual double AIPNewPatientBloodDraws
        {
            get { return _aIPNewPatientBloodDraws; }
            set { _aIPNewPatientBloodDraws = value; }
        }

        public virtual double PITAnnualPatientAttrition
        {
            get { return _pITAnnualPatientAttrition; }
            set { _pITAnnualPatientAttrition = value; }
        }

        public virtual double PITExistingPatientBloodDraws
        {
            get { return _pITExistingPatientBloodDraws; }
            set { _pITExistingPatientBloodDraws = value; }
        }

        public virtual double PITNewPatientBloodDraws
        {
            get { return _pITNewPatientBloodDraws; }
            set { _pITNewPatientBloodDraws = value; }
        }

        public virtual double PIPAnualPatientAttrition
        {
            get { return _pIPAnualPatientAttrition; }
            set { _pIPAnualPatientAttrition = value; }
        }

        public virtual double PIPAnnualMigration
        {
            get { return _pIPAnnualMigration; }
            set { _pIPAnnualMigration = value; }
        }

        public virtual double PIPExistingPatientBloodDraws
        {
            get { return _pIPExistingPatientBloodDraws; }
            set { _pIPExistingPatientBloodDraws = value; }
        }

        public virtual double PIPNewPatientBloodDraws
        {
            get { return _pIPNewPatientBloodDraws; }
            set { _pIPNewPatientBloodDraws = value; }
        }
        public virtual double AdultTestingEfficiency
        {
            get { return _adultTestingEfficiency; }
            set { _adultTestingEfficiency = value; }
        }

        public virtual double PediatricTestingEfficiency
        {
            get { return _pediatricTestingEfficiency; }
            set { _pediatricTestingEfficiency = value; }
        }

        public virtual double PediatricsPreExistingPatients
        {
            get { return _pediatricsPreExistingPatients; }
            set { _pediatricsPreExistingPatients = value; }
        }
        public virtual double ScrTest1Percent
        {
            get { return _scrTest1Percent; }
            set { _scrTest1Percent = value; }
        }

        public virtual int ScrTest1
        {
            get { return _scrTest1; }
            set { _scrTest1 = value; }
        }

        public virtual double ScrTest2Percent
        {
            get { return _scrTest2Percent; }
            set { _scrTest2Percent = value; }
        }

        public virtual int ScrTest2
        {
            get { return _scrTest2; }
            set { _scrTest2 = value; }
        }

        public virtual double ScrTest3Percent
        {
            get { return _scrTest3Percent; }
            set { _scrTest3Percent = value; }
        }

        public virtual int ScrTest3
        {
            get { return _scrTest3; }
            set { _scrTest3 = value; }
        }

        public virtual double ConTest1Percent
        {
            get { return _conTest1Percent; }
            set { _conTest1Percent = value; }
        }

        public virtual int ConTest1
        {
            get { return _conTest1; }
            set { _conTest1 = value; }
        }

        public virtual double ConTest2Percent
        {
            get { return _conTest2Percent; }
            set { _conTest2Percent = value; }
        }

        public virtual int ConTest2
        {
            get { return _conTest2; }
            set { _conTest2 = value; }
        }

        public virtual double ConTest3Percent
        {
            get { return _conTest3Percent; }
            set { _conTest3Percent = value; }
        }

        public virtual int ConTest3
        {
            get { return _conTest3; }
            set { _conTest3 = value; }
        }

        public virtual double TieTest1Percent
        {
            get { return _tieTest1Percent; }
            set { _tieTest1Percent = value; }
        }

        public virtual int TieTest1
        {
            get { return _tieTest1; }
            set { _tieTest1 = value; }
        }

        public virtual double TieTest2Percent
        {
            get { return _tieTest2Percent; }
            set { _tieTest2Percent = value; }
        }

        public virtual int TieTest2
        {
            get { return _tieTest2; }
            set { _tieTest2 = value; }
        }

        public virtual double TieTest3Percent
        {
            get { return _tieTest3Percent; }
            set { _tieTest3Percent = value; }
        }

        public virtual int TieTest3
        {
            get { return _tieTest3; }
            set { _tieTest3 = value; }
        }
		public virtual MorbidityCategory MorbidityCategory
		{
			get { return _morbidityCategory; }
			set { _morbidityCategory = value; }
		}

		public virtual ForlabSite Site
		{
			get { return _site; }
			set { _site = value; }
		}

		#endregion

        public virtual void SetOldDataPercenAlocationOnTreatment(double totalsum, double forecastTimeZeroPatient)
        {
            OldDataPatientOnTreatmentPercent = Math.Round((OldDataPatientOnTreatment * 100) / totalsum, 4);
            TimeZeroPatientOnTreatment = Math.Round((forecastTimeZeroPatient * OldDataPatientOnTreatmentPercent) / 100d, 4);
        }

        public virtual void SetOldDataPercenAlocationOnPreTreatment(double totalsum, double forecastTimeZeroPatient)
        {
            OldDataPatientOnPreTreatmentPercent = Math.Round((OldDataPatientOnPreTreatment * 100) / totalsum, 4);
            TimeZeroPatientOnPreTreatment = Math.Round((forecastTimeZeroPatient * OldDataPatientOnPreTreatmentPercent) / 100d, 4);
        }

        public virtual void ApplieNationalGrowthOnTreatment(double[,] patterOfgrowth)
        {
            double dif = (TimeZeroPatientOnTreatment + ((NTTGrowthTarget/100d) * TimeZeroPatientOnTreatment)) - TimeZeroPatientOnTreatment;
            NTTJanuary = TimeZeroPatientOnTreatment + (dif * patterOfgrowth[0, 1]);
            NTTFebruary = NTTJanuary + (dif * patterOfgrowth[1, 1]);
            NTTMarch = NTTFebruary + (dif * patterOfgrowth[2, 1]);
            NTTApril = NTTMarch + (dif * patterOfgrowth[3, 1]);
            NTTMay = NTTApril + (dif * patterOfgrowth[4, 1]);
            NTTJune = NTTMay + (dif * patterOfgrowth[5, 1]);
            NTTJuly = NTTJune + (dif * patterOfgrowth[6, 1]);
            NTTAugust = NTTJuly + (dif * patterOfgrowth[7, 1]);
            NTTSeptember = NTTAugust + (dif * patterOfgrowth[8, 1]);
            NTTOctober = NTTSeptember + (dif * patterOfgrowth[9, 1]);
            NTTNovember = NTTOctober + (dif * patterOfgrowth[10, 1]);
            NTTDecember = NTTNovember + (dif * patterOfgrowth[11, 1]);
        }

        public virtual void ApplieNationalGrowthOnPreTreatment(double[,] patterOfgrowth)
        {
            double dif = (TimeZeroPatientOnPreTreatment + ((NTPTGrowthTarget / 100d) * TimeZeroPatientOnPreTreatment)) - TimeZeroPatientOnPreTreatment;
            NTPTJanuary = TimeZeroPatientOnPreTreatment + (dif * patterOfgrowth[0, 1]);
            NTPTFebruary = NTPTJanuary + (dif * patterOfgrowth[1, 1]);
            NTPTMarch = NTPTFebruary + (dif * patterOfgrowth[2, 1]);
            NTPTApril = NTPTMarch + (dif * patterOfgrowth[3, 1]);
            NTPTMay = NTPTApril + (dif * patterOfgrowth[4, 1]);
            NTPTJune = NTPTMay + (dif * patterOfgrowth[5, 1]);
            NTPTJuly = NTPTJune + (dif * patterOfgrowth[6, 1]);
            NTPTAugust = NTPTJuly + (dif * patterOfgrowth[7, 1]);
            NTPTSeptember = NTPTAugust + (dif * patterOfgrowth[8, 1]);
            NTPTOctober = NTPTSeptember + (dif * patterOfgrowth[9, 1]);
            NTPTNovember = NTPTOctober + (dif * patterOfgrowth[10, 1]);
            NTPTDecember = NTPTNovember + (dif * patterOfgrowth[11, 1]);
        }

        public virtual void ApplieLinearGrowthOnTreatment()
        {
            double dif = (TimeZeroPatientOnTreatment + ((NTTGrowthTarget/100d) * TimeZeroPatientOnTreatment)) - TimeZeroPatientOnTreatment;
            NTTJanuary = TimeZeroPatientOnTreatment + (dif/12d);
            NTTFebruary = NTTJanuary + (dif / 12d);
            NTTMarch = NTTFebruary + (dif / 12d);
            NTTApril = NTTMarch + (dif / 12d);
            NTTMay = NTTApril + (dif / 12d);
            NTTJune = NTTMay + (dif / 12d);
            NTTJuly = NTTJune + (dif / 12d);
            NTTAugust = NTTJuly + (dif / 12d);
            NTTSeptember = NTTAugust + (dif / 12d);
            NTTOctober = NTTSeptember + (dif / 12d);
            NTTNovember = NTTOctober + (dif / 12d);
            NTTDecember = NTTNovember + (dif / 12d);
        }

        public virtual void ApplieLinearGrowthOnPreTreatment()
        {
            double dif = (TimeZeroPatientOnPreTreatment + ((NTPTGrowthTarget / 100d) * TimeZeroPatientOnPreTreatment)) - TimeZeroPatientOnPreTreatment;
            NTPTJanuary = TimeZeroPatientOnPreTreatment + (dif / 12d);
            NTPTFebruary = NTPTJanuary + (dif / 12d);
            NTPTMarch = NTPTFebruary + (dif / 12d);
            NTPTApril = NTPTMarch + (dif / 12d);
            NTPTMay = NTPTApril + (dif / 12d);
            NTPTJune = NTPTMay + (dif / 12d);
            NTPTJuly = NTPTJune + (dif / 12d);
            NTPTAugust = NTPTJuly + (dif / 12d);
            NTPTSeptember = NTPTAugust + (dif / 12d);
            NTPTOctober = NTPTSeptember + (dif / 12d);
            NTPTNovember = NTPTOctober + (dif / 12d);
            NTPTDecember = NTPTNovember + (dif / 12d);
        }

        /// <summary>
        /// National Treatment Targets
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public virtual double GetNTTMonthValue(int month)
        {
            double value = 0;
            switch (month)
            {
                case 0:
                    value = TimeZeroPatientOnTreatment;
                    break;
                case 1:
                    value = NTTJanuary;
                    break;
                case 2:
                    value = NTTFebruary;
                    break;
                case 3:
                    value = NTTMarch;
                    break;
                case 4:
                    value = NTTApril;
                    break;
                case 5:
                    value = NTTMay;
                    break;
                case 6:
                    value = NTTJune;
                    break;
                case 7:
                    value = NTTJuly;
                    break;
                case 8:
                    value = NTTAugust;
                    break;
                case 9:
                    value = NTTSeptember;
                    break;
                case 10:
                    value = NTTOctober;
                    break;
                case 11:
                    value = NTTNovember;
                    break;
                case 12:
                    value = NTTDecember;
                    break;
            }
            return value;
        }

        /// <summary>
        /// Set National Treatment Targets
        /// </summary>
        /// <param name="month"></param>
        /// <param name="value"></param>
        public virtual void SetNTTMonthValue(int month, double value)
        {
            switch (month)
            {
                case 0:
                    TimeZeroPatientOnTreatment = value;
                    break;
                case 1:
                    NTTJanuary = value;
                    break;
                case 2:
                    NTTFebruary = value;
                    break;
                case 3:
                    NTTMarch = value;
                    break;
                case 4:
                    NTTApril = value;
                    break;
                case 5:
                    NTTMay = value;
                    break;
                case 6:
                    NTTJune = value;
                    break;
                case 7:
                    NTTJuly = value;
                    break;
                case 8:
                    NTTAugust = value;
                    break;
                case 9:
                    NTTSeptember = value;
                    break;
                case 10:
                    NTTOctober = value;
                    break;
                case 11:
                    NTTNovember = value;
                    break;
                case 12:
                    NTTDecember = value;
                    break;
            }
        }

        /// <summary>
        /// Get National Pre-ART Targets
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public virtual double GetNTPTMonthValue(int month)
        {
            double value = 0;
            switch (month)
            {
                case 0:
                    value = TimeZeroPatientOnPreTreatment;
                    break;
                case 1:
                    value = NTPTJanuary;
                    break;
                case 2:
                    value = NTPTFebruary;
                    break;
                case 3:
                    value = NTPTMarch;
                    break;
                case 4:
                    value = NTPTApril;
                    break;
                case 5:
                    value = NTPTMay;
                    break;
                case 6:
                    value = NTPTJune;
                    break;
                case 7:
                    value = NTPTJuly;
                    break;
                case 8:
                    value = NTPTAugust;
                    break;
                case 9:
                    value = NTPTSeptember;
                    break;
                case 10:
                    value = NTPTOctober;
                    break;
                case 11:
                    value = NTPTNovember;
                    break;
                case 12:
                    value = NTPTDecember;
                    break;
            }
            return value;
        }

        /// <summary>
        /// Set National Pre-ART Targets
        /// </summary>
        /// <param name="month"></param>
        /// <param name="value"></param>
        public virtual void SetNTPTMonthValue(int month, double value)
        {
            switch (month)
            {
                case 0:
                    TimeZeroPatientOnPreTreatment = value;
                    break;
                case 1:
                    NTPTJanuary = value;
                    break;
                case 2:
                    NTPTFebruary = value;
                    break;
                case 3:
                    NTPTMarch = value;
                    break;
                case 4:
                    NTPTApril = value;
                    break;
                case 5:
                    NTPTMay = value;
                    break;
                case 6:
                    NTPTJune = value;
                    break;
                case 7:
                    NTPTJuly = value;
                    break;
                case 8:
                    NTPTAugust = value;
                    break;
                case 9:
                    NTPTSeptember = value;
                    break;
                case 10:
                    NTPTOctober = value;
                    break;
                case 11:
                    NTPTNovember = value;
                    break;
                case 12:
                    NTPTDecember = value;
                    break;
            }
        }

        public virtual int LargestPlatformCount()
        {
            int temp = 0;
            if (Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.CD4).Count > temp)
                temp = Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.CD4).Count;

            if (Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.Chemistry).Count > temp)
                temp = Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.Chemistry).Count;

            if (Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.Hematology).Count > temp)
                temp = Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.Hematology).Count;

            if (Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.RapidTest).Count > temp)
                temp = Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.RapidTest).Count;

            if (Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.ViralLoad).Count > temp)
                temp = Site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.ViralLoad).Count;
            return temp;
        }

        public virtual bool HasPlatform(ClassOfMorbidityTestEnum ctest)
        {
            return NoOfPlatform(ctest) > 0;
        }

        public virtual int NoOfPlatform(ClassOfMorbidityTestEnum ctest)
        {
            return Site.GetInstrumentByPlatform(ctest).Count;
        }

        public virtual bool TestWasSelected(ClassOfMorbidityTestEnum ctest)
        {
            bool result = false;
            switch (ctest)
            {
                case ClassOfMorbidityTestEnum.CD4:
                    result = ForecastCD4;
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    result = ForecastChemistry;
                    break;
                case ClassOfMorbidityTestEnum.Consumable:
                    result = ForecastConsumable;
                    break;
                case ClassOfMorbidityTestEnum.Hematology:
                    result = ForecastHematology;
                    break;
                case ClassOfMorbidityTestEnum.OtherTest:
                    result = ForecastOtherTest;
                    break;
                case ClassOfMorbidityTestEnum.RapidTest:
                    result = ForecastVCT;
                    break;
                case ClassOfMorbidityTestEnum.ViralLoad:
                    result = ForecastViralLoad;
                    break;
            }

            return result;
        }

        public virtual bool TestWasReffered(ClassOfMorbidityTestEnum ctest)
        {
            bool result = false;
            switch (ctest)
            {
                case ClassOfMorbidityTestEnum.CD4:
                    result = Site.CD4RefSite > 0;
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    result = Site.ChemistryRefSite > 0;
                    break;
                //case ClassOfMorbidityTestEnum.Consumable:
                //    result = Site.consRefSite > 0;
                //    break;
                case ClassOfMorbidityTestEnum.Hematology:
                    result = Site.HematologyRefSite > 0;
                    break;
                case ClassOfMorbidityTestEnum.OtherTest:
                    result = Site.OtherRefSite > 0;
                    break;
                //case ClassOfMorbidityTestEnum.RapidTest:
                //    result = Site.RefSite > 0;
                //    break;
                case ClassOfMorbidityTestEnum.ViralLoad:
                    result = Site.ViralLoadRefSite > 0;
                    break;
            }

            return result;
        }

        public virtual int TestRefferedSiteId(ClassOfMorbidityTestEnum ctest)
        {
            int result = 0;
            switch (ctest)
            {
                case ClassOfMorbidityTestEnum.CD4:
                    result = Site.CD4RefSite;
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    result = Site.ChemistryRefSite;
                    break;
                case ClassOfMorbidityTestEnum.Hematology:
                    result = Site.HematologyRefSite;
                    break;
                case ClassOfMorbidityTestEnum.OtherTest:
                    result = Site.OtherRefSite;
                    break;
                case ClassOfMorbidityTestEnum.ViralLoad:
                    result = Site.ViralLoadRefSite;
                    break;
            }

            return result;
        }
	}

}
