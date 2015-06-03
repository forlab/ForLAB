
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
	/// ForecastSiteProduct object for NHibernate mapped table 'ForecastSiteProduct'.
	/// </summary>
    public class ForecastSiteProduct : BaseDataUsage, IBaseDataUsage, System.IComparable
	{
		#region Member Variables

		private ForecastSite _forecastSite;
        private static String _sortExpression = "DurationDateTime";
        private static SortDirection _sortDirection = SortDirection.Descending;

		#endregion

		#region Constructors

		public ForecastSiteProduct() 
		{

		}

		
		#endregion

		#region Public Properties


		public virtual ForecastSite ForecastSite
		{
			get { return _forecastSite; }
			set { _forecastSite = value; }
		}

        public static String SortExpression
        {
            get { return _sortExpression; }
            set { _sortExpression = value; }
        }

        public static SortDirection SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }

		#endregion

        #region IComparable Methods

        public  int CompareTo(object obj)
        {
            if (!(obj is ForecastSiteProduct))
                throw new InvalidCastException("This object is not of type ForecastSiteProduct");

            int relativeValue;
            switch (SortExpression)
            {
                case "Id":
                    relativeValue = this.Id.CompareTo(((ForecastSiteProduct)obj).Id);
                    break;
                case "DurationDateTime":
                    relativeValue = (this.DurationDateTime != null) ? this.DurationDateTime.Value.CompareTo(((ForecastSiteProduct)obj).DurationDateTime) : -1;
                    break;
                default:
                    goto case "Id";
            }
            if (ForecastSiteProduct.SortDirection == SortDirection.Ascending)
                relativeValue *= -1;
            return relativeValue;
        }
        #endregion
       
	}

}
