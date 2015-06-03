
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

namespace LQT.Core.Domain
{	
	/// <summary>
	/// MorbidityCategory object for NHibernate mapped table 'MorbidityCategory'.
	/// </summary>
    public class MorbidityCategory
    {

        private int _id;
        private string _categoryName;
        private MorbidityForecast _morbidityForecast;
        //private IList<ARTSite> _artSites;
        private int _regionid;

        #region Constructors

        public MorbidityCategory()
        {
            this._id = -1;
        }

        #endregion

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (value != null && value.Length > 64)
                    throw new ArgumentOutOfRangeException("Invalid value for CategoryName", value, value.ToString());
                _categoryName = value;
            }
        }

        public virtual MorbidityForecast MorbidityForecast
        {
            get { return _morbidityForecast; }
            set { _morbidityForecast = value; }
        }

        public virtual int RegionId
        {
            get { return _regionid; }
            set { _regionid = value; }
        }
        //public virtual IList<ARTSite> ARTSites
        //{
        //    get
        //    {
        //        if (_artSites == null)
        //        {
        //            _artSites = new List<ARTSite>();
        //        }
        //        return _artSites;
        //    }
        //    set { _artSites = value; }
        //}


        //public virtual ARTSite GetARTSiteById(int id)
        //{
        //    foreach (ARTSite s in ARTSites)
        //    {
        //        if (s.Id == id)
        //            return s;
        //    }

        //    return null;
        //}

        //public virtual IList<int> GetSelectedSiteId()
        //{
        //    IList<int> proids = new List<int>();
        //    foreach (ARTSite s in ARTSites)
        //    {
        //        proids.Add(s.Site.Id);
        //    }
        //    return proids;
        //}

        #endregion
    }

}
