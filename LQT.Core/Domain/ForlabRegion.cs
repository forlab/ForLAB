
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI) 
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
	/// Region object for NHibernate mapped table 'Region'.
	/// </summary>
	public class ForlabRegion 
	{
		#region Member Variables
		
		private int _id;
		private string _regionName;
		private string _shortName;
        private IList _sites;

		#endregion

		#region Constructors

		public ForlabRegion() 
		{
			this._id = -1;
            this._sites = new ArrayList();
		}

		
		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

        public virtual string RegionName
		{
			get { return _regionName; }
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for RegionName", value, value.ToString());
				_regionName = value;
			}
		}

        public virtual string ShortName
		{
			get { return _shortName; }
			set
			{
				if ( value != null && value.Length > 8)
					throw new ArgumentOutOfRangeException("Invalid value for ShortName", value, value.ToString());
				_shortName = value;
			}
		}

        public virtual IList Sites
        {
            get { return _sites; }
            set { _sites = value; }
        }

		#endregion
		
       
	}

}
