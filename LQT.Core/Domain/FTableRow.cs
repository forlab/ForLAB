
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
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
