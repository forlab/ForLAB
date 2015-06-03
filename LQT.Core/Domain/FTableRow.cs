
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
	/// FTableRow object for NHibernate mapped table 'FTableRow'.
	/// </summary>
	public class FTableRow 
	{
		#region Member Variables
		
		private int _id;
		private int _instance;
		private decimal _value;
		private decimal _forecast;
		private bool _holdout;
		private decimal _error;
		private decimal _absoluteError;
		private decimal _percentError;
		private decimal _absolutePercentError;
		private string _duration;
		private FTable _fTable;

		#endregion

		#region Constructors

		public FTableRow() 
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

		public virtual decimal Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public virtual decimal Forecast
		{
			get { return _forecast; }
			set { _forecast = value; }
		}

		public virtual bool Holdout
		{
			get { return _holdout; }
			set { _holdout = value; }
		}

		public virtual decimal Error
		{
			get { return _error; }
			set { _error = value; }
		}

		public virtual decimal AbsoluteError
		{
			get { return _absoluteError; }
			set { _absoluteError = value; }
		}

		public virtual decimal PercentError
		{
			get { return _percentError; }
			set { _percentError = value; }
		}

		public virtual decimal AbsolutePercentError
		{
			get { return _absolutePercentError; }
			set { _absolutePercentError = value; }
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

		public virtual FTable FTable
		{
			get { return _fTable; }
			set { _fTable = value; }
		}

        
		#endregion
		
       
	}

}
