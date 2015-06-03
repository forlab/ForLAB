
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
using LQT.Core.Util;

namespace LQT.Core.Domain
{

    /// <summary>
    /// ForecastInfo object for NHibernate mapped table 'ForecastInfo'.
    /// </summary>
    public class ForecastInfo
    {
        #region Member Variables

        private int _id;
        private string _forecastNo;
        private string _methodology;
        private string _dataUsage;
        private string _period;
        private int _monthInPeriod;
        private string _status;
        private int _extension;
        private DateTime? _forecastDate;
        private string _scopeOfTheForecast;
        private DateTime _startDate;
        private string _note;
        private int _lastNo;
        private int _actualCount;
        private int _rOrder;
        private string _method;
        private decimal _westage;
        private decimal _scaleup;
        private DateTime _lastUpdated;
    
        private IList<ForecastSite> _forecastSites;
        private IList<ForecastCategory> _forecastCategories;

        private string _slowMovingPerod;

        #endregion

        #region Constructors

        public ForecastInfo()
        {
            this._id = -1;
            this._lastUpdated = DateTime.Now;
            this._forecastSites = new List<ForecastSite>();
            this._status = ForecastStatusEnum.OPEN.ToString();
            this._method = ForecastingMethodEnum.Linear.ToString();
        }


        #endregion

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string ForecastNo
        {
            get { return _forecastNo; }
            set
            {
                if (value != null && value.Length > 32)
                    throw new ArgumentOutOfRangeException("Invalid value for ForecastNo", value, value.ToString());
                _forecastNo = value;
            }
        }

        public virtual string Methodology
        {
            get { return _methodology; }
            set
            {
                if (value != null && value.Length > 32)
                    throw new ArgumentOutOfRangeException("Invalid value for Methodology", value, value.ToString());
                _methodology = value;
            }
        }

        public virtual MethodologyEnum FMethodologeyEnum
        {
            get { return (MethodologyEnum)Enum.Parse(typeof(MethodologyEnum), _methodology); }
        }

        public virtual string DataUsage
        {
            get { return _dataUsage; }
            set
            {
                if (value != null && value.Length > 16)
                    throw new ArgumentOutOfRangeException("Invalid value for DataUsage", value, value.ToString());
                _dataUsage = value;
            }
        }

        public virtual DataUsageEnum DatausageEnum
        {
            get
            {
                return (DataUsageEnum)Enum.Parse(typeof(DataUsageEnum), _dataUsage);
            }
        }

        public virtual string Period
        {
            get { return _period; }
            set { _period = value; }
        }
        public virtual int MonthInPeriod
        {
            get { return _monthInPeriod; }
            set { _monthInPeriod = value; }
        }
        public virtual ForecastPeriodEnum PeriodEnum
        {
            get
            {
                return (ForecastPeriodEnum)Enum.Parse(typeof(ForecastPeriodEnum), _period);
            }
        }

        public virtual int Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public virtual string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        public virtual ForecastingMethodEnum ForecastMethodEnum
        {
            get
            {
                return (ForecastingMethodEnum)Enum.Parse(typeof(ForecastingMethodEnum), _method);
            }
        }


        public virtual int ActualCount
        {
            get { return _actualCount; }
            set { _actualCount = value; }
        }

        public virtual decimal Westage
        {
            get { return _westage; }
            set { _westage = value; }
        }

        public virtual decimal Scaleup
        {
            get { return _scaleup; }
            set { _scaleup = value; }
        }

        public virtual DateTime? ForecastDate
        {
            get { return _forecastDate; }
            set { _forecastDate = value; }
        }

        public virtual string ScopeOfTheForecast
        {
            get { return _scopeOfTheForecast; }
            set
            {
                if (value != null && value.Length > 24)
                    throw new ArgumentOutOfRangeException("Invalid value for ScopeOfTheForecast", value, value.ToString());
                _scopeOfTheForecast = value;
            }
        }

        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public virtual ForecastStatusEnum StatusEnum
        {
            get
            {
                return (ForecastStatusEnum)Enum.Parse(typeof(ForecastStatusEnum), _status);
            }
        }
        public virtual DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public virtual string Note
        {
            get { return _note; }
            set
            {
                if (value != null && value.Length > 256)
                    throw new ArgumentOutOfRangeException("Invalid value for Note", value, value.ToString());
                _note = value;
            }
        }

        public virtual int ROrder
        {
            get { return _rOrder; }
            set { _rOrder = value; }
        }
        public virtual DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set { _lastUpdated = value; }
        }

        public virtual IList<ForecastSite> ForecastSites
        {
            get
            {
                if (_forecastSites == null)
                {
                    _forecastSites = new List<ForecastSite>();
                }
                return _forecastSites;
            }
            set { _forecastSites = value; }
        }

        public virtual IList<ForecastCategory> ForecastCategories
        {
            get
            {
                if (_forecastCategories == null)
                {
                    _forecastCategories = new List<ForecastCategory>();
                }
                return _forecastCategories;
            }
            set { _forecastCategories = value; }
        }

       public virtual string SlowMovingPeriod
        {
            get { return _slowMovingPerod; }
            set { _slowMovingPerod = value; }
        }

        #endregion

        public virtual ForecastSite GetForecastSite(int id)
        {
            foreach (ForecastSite s in _forecastSites)
            {
                if (s.Id == id)
                    return s;
            }

            return null;
        }

        public virtual ForecastSite GetForecastSiteBySiteId(int siteid)
        {
            foreach (ForecastSite s in ForecastSites)
            {
                if (s.Site.Id == siteid)
                    return s;
            }

            return null;
        }

        public virtual IList<ForecastSite> GetReportedForecastSite()
        {
            IList<ForecastSite> result = new List<ForecastSite>();
            foreach (ForecastSite s in _forecastSites)
            {
                if (s.ReportedSiteId == 0)
                    result.Add(s);
            }

            return result;
        }

        public virtual IList<ForecastSite> GetNoneReportedForecastSite(int repsiteid)
        {
            IList<ForecastSite> result = new List<ForecastSite>();
            foreach (ForecastSite s in _forecastSites)
            {
                if (s.ReportedSiteId == repsiteid)
                    result.Add(s);
            }

            return result;
        }


        public virtual bool SiteIsSelected(int siteid)
        {
            foreach (ForecastSite s in _forecastSites)
            {
                if (s.Site.Id == siteid)
                    return true;
            }

            return false;
        }

        public virtual IList<int> GetSelectedSiteId()
        {
            IList<int> proids = new List<int>();
            foreach (ForecastSite s in ForecastSites)
            {
                proids.Add(s.Site.Id);
            }
            return proids;
        }

        public virtual ForecastCategory GetForecastCategory(int id)
        {
            foreach (ForecastCategory c in ForecastCategories)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }

        public virtual ForecastCategory GetForecastCategorybyname(string catname)
        {
            foreach (ForecastCategory c in ForecastCategories)
            {
                if (c.CategoryName == catname)
                    return c;
            }
            return null;
        }

        public virtual bool CanRemoveDataUsage(int fsiteorcatid,int prodortestid,int currentIndex,out string _removeErrorMessage)
        {
            IList<ForecastSiteProduct> fsp;
            IList<ForecastSiteTest> fst;
            IList<ForecastCategoryProduct> fcp;
            IList<ForecastCategoryTest> fct;
            bool result=false;
            _removeErrorMessage = "";
            if (FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                switch (DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                       fsp = DataRepository.GetFSiteProductByProId(fsiteorcatid,prodortestid, SortDirection.Descending);
                       if (fsp.Count >= 4)
                            if (currentIndex == 0 || currentIndex == (fsp.Count - 1))
                                result= true;
                            else
                                _removeErrorMessage = "Can Not Delete Record in middle";
                       else
                           _removeErrorMessage = "Can Not Delete Record, Minimum 3 record is required";

                        break;
                    case DataUsageEnum.DATA_USAGE3:
                       fcp = DataRepository.GetFCategoryProductByProId(fsiteorcatid,prodortestid, SortDirection.Descending);
                       if (fcp.Count >= 4)
                           if (currentIndex == 0 || currentIndex == (fcp.Count - 1))
                               result = true;
                           else
                               _removeErrorMessage = "Can Not Delete Record in middle";
                       else
                           _removeErrorMessage = "Can Not Delete Record, Minimum 3 record is required";
                        
                        break;
                }
            }
            else
            {
                switch (DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                       fst = DataRepository.GetFSiteTestByTestId(fsiteorcatid,prodortestid, SortDirection.Descending);
                       if (fst.Count >= 4)
                           if (currentIndex == 0 || currentIndex == (fst.Count - 1))
                                result= true;
                           else
                               _removeErrorMessage = "Can Not Delete Record in middle";
                       else
                           _removeErrorMessage = "Can Not Delete Record, Minimum 3 record is required";

                        break;
                    case DataUsageEnum.DATA_USAGE3:
                       fct = DataRepository.GetFCategoryTestByTestId(fsiteorcatid,prodortestid, SortDirection.Descending);
                       if (fct.Count >= 4)
                           if (currentIndex == 0 || currentIndex == (fct.Count - 1))
                                result= true;
                           else
                               _removeErrorMessage = "Can Not Delete Record in middle";
                       else
                           _removeErrorMessage = "Can Not Delete Record, Minimum 3 record is required";

                        break;
                }
            }

            return result;
        }

        public virtual IList GetListOfDataUsages(int siteOrcatid, params int[] pindex)
        {
            IList list = null;
            int index = 0;
            
            if (pindex !=null)
            {
                index = pindex[0];
            }

            if (FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                switch (DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        if (siteOrcatid > 0)
                            list = (IList)GetForecastSite(siteOrcatid).SiteProducts;
                        else
                            list = (IList)ForecastSites[index].SiteProducts;
                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        if (siteOrcatid > 0)
                            list = (IList)GetForecastCategory(siteOrcatid).CategoryProducts;
                        else
                            list = (IList)ForecastCategories[index].CategoryProducts;
                        break;
                }
            }
            else
            {
                switch (DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        if (siteOrcatid > 0)
                            list = (IList)GetForecastSite(siteOrcatid).SiteTests;
                        else
                            list = (IList)ForecastSites[index].SiteTests;
                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        if (siteOrcatid > 0)
                            list = (IList)GetForecastCategory(siteOrcatid).CategoryTests;
                        else
                            list = (IList)ForecastCategories[index].CategoryTests;
                        break;
                }
            }
            return list;
        }

        public virtual DateTime GetMaxForecastDate()
        {
            int am = _extension;

            switch (PeriodEnum)
            {
                case ForecastPeriodEnum.Bimonthly:
                    am = am * 2;
                    break;
                case ForecastPeriodEnum.Quarterly:
                    am *= 3;
                    break;
                case ForecastPeriodEnum.Yearly:
                    am *= 12;
                    break;
            }

            return StartDate.AddMonths(am);
        }

        public virtual IList GetForecastCategoryPro(int proid, int siteOrcatid)
        {
            foreach (ForecastCategory c in ForecastCategories)
            {
               if(c.Id==siteOrcatid)
                    return (IList)c.GetFCProduct(proid);
            }
            return null;
        }
        public virtual IList GetForecastSitePro(int proid, int siteOrcatid)
        {
            foreach (ForecastSite s in ForecastSites)
            {
                if (s.Id == siteOrcatid)
                    return (IList)s.GetFSProduct(proid);
            }
            return null;
        }

    }

}
