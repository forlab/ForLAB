
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
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
