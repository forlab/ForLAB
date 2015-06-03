
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
	/// MorbidityForecast object for NHibernate mapped table 'MorbidityForecast'.
	/// </summary>
    public class MorbidityForecast
    {

        private int _id;
        private string _title;
        private DateTime _dateOfQuantification;
        private string _descritpion;
        private DateTime _satartDate;
        private string _status;
        private int _startBudgetPeriod;
        private int _endBudgetPeriod;
        private int _optInitialPatientData;
        private int _optPatientTreatmentTarget;
        private int _optEverStartedPatientTarget;
        private int _optArtPatinetTarget;
        private int _optPreTreatmentPatinetTarget;
        private double _timeZeroPatientOnTreatment;
        private double _timeZeroPatientOnPreTreatment;
        private double _everSTimeZeroPatientOnTreatment;
        private double _everSTimeZeroPatientOnPreTreatment;
        private int _noofEverStartedPatientOnTreatment;
        private int _noofEverStartedPatientOnPreTreatment;
        private string _typeofAlgorithm;
        private DateTime _dateModified;
        private bool _useRegionAsCat;
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
        private IList<MorbidityCategory> _morbidityCategories;
        private double[,] _patientNumbers = new double[13,3];


        #region Constructors

        public MorbidityForecast()
        {
            this._id = -1;
            this._useRegionAsCat = false;
            this._status = ForecastStatusEnum.OPEN.ToString();
        }


        #endregion

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Title
        {
            get { return _title; }
            set
            {
                if (value != null && value.Length > 128)
                    throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
                _title = value;
            }
        }

        public virtual DateTime DateOfQuantification
        {
            get { return _dateOfQuantification; }
            set { _dateOfQuantification = value; }
        }

        public virtual string Descritpion
        {
            get { return _descritpion; }
            set
            {
                if (value != null && value.Length > 1024)
                    throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
                _descritpion = value;
            }
        }

        public virtual DateTime SatartDate
        {
            get { return _satartDate; }
            set { _satartDate = value; }
        }

        //
        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public virtual ForecastStatusEnum StatusEnum
        {
            get
            {
                if (Status == null)
                    return ForecastStatusEnum.OPEN;
                return (ForecastStatusEnum)Enum.Parse(typeof(ForecastStatusEnum), _status);
            }
        }
        //

        public virtual int StartBudgetPeriod
        {
            get { return _startBudgetPeriod; }
            set { _startBudgetPeriod = value; }
        }

        public virtual MonthNameEnum StartBudgetPeriodEnum
        {
            get
            {
                return (MonthNameEnum)Enum.ToObject(typeof(MonthNameEnum), _startBudgetPeriod);
            }
        }
        public virtual int EndBudgetPeriod
        {
            get { return _endBudgetPeriod; }
            set { _endBudgetPeriod = value; }
        }

        public virtual MonthNameEnum EndBudgetPeriodEnum
        {
            get
            {
                return (MonthNameEnum)Enum.ToObject(typeof(MonthNameEnum), _endBudgetPeriod);
            }
        }

        public virtual int OptInitialPatientData
        {
            get { return _optInitialPatientData; }
            set { _optInitialPatientData = value; }
        }

        public virtual int OptPatientTreatmentTarget
        {
            get { return _optPatientTreatmentTarget; }
            set { _optPatientTreatmentTarget = value; }
        }
        
        public virtual OptPatientTreatmentTargetEnum PatientTreatmentTargetEnum
        {
            get
            {
                return (OptPatientTreatmentTargetEnum)Enum.ToObject(typeof(OptPatientTreatmentTargetEnum), _optPatientTreatmentTarget);
            }
        }

        public virtual int OptEverStartedPatientTarget
        {
            get { return _optEverStartedPatientTarget; }
            set { _optEverStartedPatientTarget = value; }
        }
        
        public virtual OptEverStartedPatientTargetEnum EverStartedPatientTargetEnum
        {
            get
            {
                return (OptEverStartedPatientTargetEnum)Enum.ToObject(typeof(OptEverStartedPatientTargetEnum), _optEverStartedPatientTarget);
            }
        }

        public virtual int OptArtPatinetTarget
        {
            get { return _optArtPatinetTarget; }
            set { _optArtPatinetTarget = value; }
        }

        public virtual OptArtPatinetTargetEnum ArtPatinetTargetEnum
        {
            get
            {
                return (OptArtPatinetTargetEnum)Enum.ToObject(typeof(OptArtPatinetTargetEnum), _optArtPatinetTarget);
            }
        }

        public virtual int OptPreTreatmentPatinetTarget
        {
            get { return _optPreTreatmentPatinetTarget; }
            set { _optPreTreatmentPatinetTarget = value; }
        }

        public virtual OptPreTreatmentPatinetTargetEnum PreTreatmentPatinetTargetEnum
        {
            get
            {
                return (OptPreTreatmentPatinetTargetEnum)Enum.ToObject(typeof(OptPreTreatmentPatinetTargetEnum), _optPreTreatmentPatinetTarget);
            }
        }
        public virtual double TimeZeroPatientOnTreatment
        {
            get { return _timeZeroPatientOnTreatment; }
            set { _timeZeroPatientOnTreatment = value; }
        }

        public virtual double TimeZeroPatientOnPreTreatment
        {
            get { return _timeZeroPatientOnPreTreatment; }
            set { _timeZeroPatientOnPreTreatment = value; }
        }
        public virtual double EverSTimeZeroPatientOnTreatment
        {
            get { return _everSTimeZeroPatientOnTreatment; }
            set { _everSTimeZeroPatientOnTreatment = value; }
        }

        public virtual double EverSTimeZeroPatientOnPreTreatment
        {
            get { return _everSTimeZeroPatientOnPreTreatment; }
            set { _everSTimeZeroPatientOnPreTreatment = value; }
        }
        public virtual int NoofEverStartedPatientOnTreatment
        {
            get { return _noofEverStartedPatientOnTreatment; }
            set { _noofEverStartedPatientOnTreatment = value; }
        }

        public virtual int NoofEverStartedPatientOnPreTreatment
        {
            get { return _noofEverStartedPatientOnPreTreatment; }
            set { _noofEverStartedPatientOnPreTreatment = value; }
        }

        public virtual string TypeofAlgorithm
        {
            get { return _typeofAlgorithm; }
            set
            {
                if (value != null && value.Length > 16)
                    throw new ArgumentOutOfRangeException("Invalid value for TypeofAlgorithm", value, value.ToString());
                _typeofAlgorithm = value;
            }
        }
        public virtual AlgorithmType TypeofAlgorithmEnum
        {
            get 
            {
                if (TypeofAlgorithm == null)
                    return AlgorithmType.Serial;
                return (AlgorithmType)Enum.Parse(typeof(AlgorithmType), TypeofAlgorithm); 
            }
        }

        public virtual DateTime DateModified
        {
            get { return _dateModified; }
            set { _dateModified = value; }
        }

        public virtual bool UseRegionAsCat
        {
            get { return _useRegionAsCat; }
            set { _useRegionAsCat = value; }
        }

        public virtual double NTPTRecentMonth
        {
            get { return _nTPTRecentMonth; }
            set { _nTPTRecentMonth = value; }
        }

        public virtual double NTPTJanuary
        {
            get { return _nTPTJanuary; }
            set { _nTPTJanuary = value; }
        }

        public virtual double NTPTFebruary
        {
            get { return _nTPTFebruary; }
            set { _nTPTFebruary = value; }
        }

        public virtual double NTPTMarch
        {
            get { return _nTPTMarch; }
            set { _nTPTMarch = value; }
        }

        public virtual double NTPTApril
        {
            get { return _nTPTApril; }
            set { _nTPTApril = value; }
        }

        public virtual double NTPTMay
        {
            get { return _nTPTMay; }
            set { _nTPTMay = value; }
        }

        public virtual double NTPTJune
        {
            get { return _nTPTJune; }
            set { _nTPTJune = value; }
        }

        public virtual double NTPTJuly
        {
            get { return _nTPTJuly; }
            set { _nTPTJuly = value; }
        }

        public virtual double NTPTAugust
        {
            get { return _nTPTAugust; }
            set { _nTPTAugust = value; }
        }

        public virtual double NTPTSeptember
        {
            get { return _nTPTSeptember; }
            set { _nTPTSeptember = value; }
        }

        public virtual double NTPTOctober
        {
            get { return _nTPTOctober; }
            set { _nTPTOctober = value; }
        }

        public virtual double NTPTNovember
        {
            get { return _nTPTNovember; }
            set { _nTPTNovember = value; }
        }

        public virtual double NTPTDecember
        {
            get { return _nTPTDecember; }
            set { _nTPTDecember = value; }
        }

        public virtual double NTPTPercentOfChildren
        {
            get { return _nTPTPercentOfChildren; }
            set { _nTPTPercentOfChildren = value; }
        }

        public virtual double NTTRecentMonth
        {
            get { return _nTTRecentMonth; }
            set { _nTTRecentMonth = value; }
        }

        public virtual double NTTJanuary
        {
            get { return _nTTJanuary; }
            set { _nTTJanuary = value; }
        }

        public virtual double NTTFebruary
        {
            get { return _nTTFebruary; }
            set { _nTTFebruary = value; }
        }

        public virtual double NTTMarch
        {
            get { return _nTTMarch; }
            set { _nTTMarch = value; }
        }

        public virtual double NTTApril
        {
            get { return _nTTApril; }
            set { _nTTApril = value; }
        }

        public virtual double NTTMay
        {
            get { return _nTTMay; }
            set { _nTTMay = value; }
        }

        public virtual double NTTJune
        {
            get { return _nTTJune; }
            set { _nTTJune = value; }
        }

        public virtual double NTTJuly
        {
            get { return _nTTJuly; }
            set { _nTTJuly = value; }
        }

        public virtual double NTTAugust
        {
            get { return _nTTAugust; }
            set { _nTTAugust = value; }
        }

        public virtual double NTTSeptember
        {
            get { return _nTTSeptember; }
            set { _nTTSeptember = value; }
        }

        public virtual double NTTOctober
        {
            get { return _nTTOctober; }
            set { _nTTOctober = value; }
        }

        public virtual double NTTNovember
        {
            get { return _nTTNovember; }
            set { _nTTNovember = value; }
        }

        public virtual double NTTDecember
        {
            get { return _nTTDecember; }
            set { _nTTDecember = value; }
        }

        public virtual double NTTPercentOfChildren
        {
            get { return _nTTPercentOfChildren; }
            set { _nTTPercentOfChildren = value; }
        }

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

        public virtual IList<MorbidityCategory> MorbidityCategories
        {
            get
            {
                if (_morbidityCategories == null)
                {
                    _morbidityCategories = new List<MorbidityCategory>();
                }
                return _morbidityCategories;
            }
            set { _morbidityCategories = value; }
        }

        #endregion

        public virtual MorbidityCategory GetCategoryById(int id)
        {
            foreach (MorbidityCategory cat in MorbidityCategories)
            {
                if (cat.Id == id)
                    return cat;
            }
            return null;
        }

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
        public virtual void CalculatePatientNumbersSites(IList<ARTSite> artsites)
        {
            //_patientNumbers[total, adults, pediatric]

            _patientNumbers[0, 0] = 0;
            _patientNumbers[1, 0] = 0;
            _patientNumbers[2, 0] = 0;
            _patientNumbers[3, 0] = 0;
            _patientNumbers[4, 0] = 0;
            _patientNumbers[5, 0] = 0;
            _patientNumbers[6, 0] = 0;
            _patientNumbers[7, 0] = 0;
            _patientNumbers[8, 0] = 0;
            _patientNumbers[9, 0] = 0;
            _patientNumbers[10, 0] = 0;
            _patientNumbers[11, 0] = 0;
            _patientNumbers[12, 0] = 0;

            double pediatricWav = 0;

            foreach (ARTSite site in artsites)
            {
                _patientNumbers[0, 0] += site.TimeZeroPatientOnTreatment;
                _patientNumbers[1, 0] += site.NTTJanuary;
                _patientNumbers[2, 0] += site.NTTFebruary;
                _patientNumbers[3, 0] += site.NTTMarch;
                _patientNumbers[4, 0] += site.NTTApril;
                _patientNumbers[5, 0] += site.NTTMay;
                _patientNumbers[6, 0] += site.NTTJune;
                _patientNumbers[7, 0] += site.NTTJuly;
                _patientNumbers[8, 0] += site.NTTAugust;
                _patientNumbers[9, 0] += site.NTTSeptember;
                _patientNumbers[10, 0] += site.NTTOctober;
                _patientNumbers[11, 0] += site.NTTNovember;
                _patientNumbers[12, 0] += site.NTTDecember;

                pediatricWav += (site.NTTPercentOfChildren / 100) * site.TimeZeroPatientOnTreatment;

            }

            pediatricWav = (pediatricWav / _patientNumbers[0, 0]) / 100;
            
            _patientNumbers[0, 1] = _patientNumbers[0, 0] * (1 - pediatricWav);
            _patientNumbers[1, 1] = _patientNumbers[1, 0] * (1 - pediatricWav);
            _patientNumbers[2, 1] = _patientNumbers[2, 0] * (1 - pediatricWav);
            _patientNumbers[3, 1] = _patientNumbers[3, 0] * (1 - pediatricWav);
            _patientNumbers[4, 1] = _patientNumbers[4, 0] * (1 - pediatricWav);
            _patientNumbers[5, 1] = _patientNumbers[5, 0] * (1 - pediatricWav);
            _patientNumbers[6, 1] = _patientNumbers[6, 0] * (1 - pediatricWav);
            _patientNumbers[7, 1] = _patientNumbers[7, 0] * (1 - pediatricWav);
            _patientNumbers[8, 1] = _patientNumbers[8, 0] * (1 - pediatricWav);
            _patientNumbers[9, 1] = _patientNumbers[9, 0] * (1 - pediatricWav);
            _patientNumbers[10, 1] = _patientNumbers[10, 0] * (1 - pediatricWav);
            _patientNumbers[11, 1] = _patientNumbers[11, 0] * (1 - pediatricWav);
            _patientNumbers[12, 1] = _patientNumbers[12, 0] * (1 - pediatricWav);

            _patientNumbers[0, 2] = _patientNumbers[0, 0] * pediatricWav;
            _patientNumbers[1, 2] = _patientNumbers[1, 0] * pediatricWav;
            _patientNumbers[2, 2] = _patientNumbers[2, 0] * pediatricWav;
            _patientNumbers[3, 2] = _patientNumbers[3, 0] * pediatricWav;
            _patientNumbers[4, 2] = _patientNumbers[4, 0] * pediatricWav;
            _patientNumbers[5, 2] = _patientNumbers[5, 0] * pediatricWav;
            _patientNumbers[6, 2] = _patientNumbers[6, 0] * pediatricWav;
            _patientNumbers[7, 2] = _patientNumbers[7, 0] * pediatricWav;
            _patientNumbers[8, 2] = _patientNumbers[8, 0] * pediatricWav;
            _patientNumbers[9, 2] = _patientNumbers[9, 0] * pediatricWav;
            _patientNumbers[10, 2] = _patientNumbers[10, 0] * pediatricWav;
            _patientNumbers[11, 2] = _patientNumbers[11, 0] * pediatricWav;
            _patientNumbers[12, 2] = _patientNumbers[12, 0] * pediatricWav;
        }

        public virtual double[,] GetCalculatedPatientNumbersSites()
        {
            return _patientNumbers;
        }
    }

}
