
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

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// ForecastCategorySite object for NHibernate mapped table 'ForecastCategorySite'.
	/// </summary>
	public class ForecastCategorySite 
	{
		#region Member Variables
		
		private int _id;
		private ForlabSite _site;
		private ForecastCategory _category;

		#endregion

		#region Constructors

		public ForecastCategorySite() 
		{
			this._id = -1;
		}

		
		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual ForlabSite Site
		{
			get { return _site; }
			set { _site = value; }
		}

		public virtual ForecastCategory Category
		{
			get { return _category; }
			set { _category = value; }
		}

        
		#endregion
		
       
	}

}
