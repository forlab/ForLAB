
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
	/// ForlabParameter object for NHibernate mapped table 'ForlabParameters'.
	/// </summary>
	public class ForlabParameter
		{
		
		private string _id;
		private string _parmValue;
		
		public ForlabParameter() 
		{
			this._id = "-1";
		}

		public ForlabParameter( string parmValue )
		{
			this._parmValue = parmValue;
		}

		#region Public Properties

		public virtual string Id
		{
			get {return _id;}
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for Id", value, value.ToString());
				_id = value;
			}
		}

		public virtual string ParmValue
		{
			get { return _parmValue; }
			set
			{
				if ( value != null && value.Length > 128)
					throw new ArgumentOutOfRangeException("Invalid value for ParmValue", value, value.ToString());
				_parmValue = value;
			}
		}

        
		#endregion
	}

}
