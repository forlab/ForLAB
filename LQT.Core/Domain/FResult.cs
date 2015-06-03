
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
	/// FResult object for NHibernate mapped table 'FResult'.
	/// </summary>
	public class FResult 
	{
		#region Member Variables
		
		private int _id;
		private int _instance;
		private decimal _forecast;
		private string _duration;
		private decimal _cost;
		private FTable _fTable;

		#endregion

		#region Constructors

		public FResult() 
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

		public virtual int Instance
		{
			get { return _instance; }
			set { _instance = value; }
		}

		public virtual decimal Forecast
		{
			get { return _forecast; }
			set { _forecast = value; }
		}

		public virtual string Duration
		{
			get { return _duration; }
			set
			{
				if ( value != null && value.Length > 24)
					throw new ArgumentOutOfRangeException("Invalid value for Duration", value, value.ToString());
				_duration = value;
			}
		}

		public virtual decimal Cost
		{
			get { return _cost; }
			set { _cost = value; }
		}

		public virtual FTable FTable
		{
			get { return _fTable; }
			set { _fTable = value; }
		}

		
		#endregion
		
	   
	}

}
