
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
using System.Collections.Generic;
using LQT.Core.Util;

namespace LQT.Core.Domain
{
	#region ForecastedResult

	/// <summary>
	/// ForecastedResult object for NHibernate mapped table 'ForecastedResult'.
	/// </summary>
	public class ForecastedResult : System.IComparable
		{
		#region Member Variables
		
		protected int _id;
		protected int _forecastId;
		protected int _productId;
		protected int _testId;
		protected DateTime _durationDateTime;
		protected decimal _forecastValue;
		protected decimal _totalValue;		
		protected int _siteId;		
		protected int _categoryId;		
		protected string _duration;
		private bool _isHistory;
		protected decimal _historicalValue;
		protected int _packQty;
		protected decimal _packPrice;
		protected int _productTypeId;
		protected string _productType;
		protected bool _serviceConverted;
		protected string _tesingArea;
		protected static String _sortExpression = "Id";
		protected static SortDirection _sortDirection = SortDirection.Ascending;

		#endregion

		#region Constructors

		public ForecastedResult() 
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

		public virtual int ForecastId
		{
			get { return _forecastId; }
			set { _forecastId = value; }
		}

		public virtual int ProductId
		{
			get { return _productId; }
			set { _productId = value; }
		}

		public virtual int TestId
		{
			get { return _testId; }
			set { _testId = value; }
		}

		public virtual DateTime DurationDateTime
		{
			get { return _durationDateTime; }
			set { _durationDateTime = value; }
		}

		public virtual decimal ForecastValue
		{
			get { return _forecastValue; }
			set { _forecastValue = value; }
		}

		public virtual decimal TotalValue
		{
			get { return _totalValue; }
			set { _totalValue = value; }
		}

		public virtual int SiteId
		{
			get { return _siteId; }
			set { _siteId = value; }
		}

		public virtual int CategoryId
		{
			get { return _categoryId; }
			set { _categoryId = value; }
		}

		public virtual string Duration
		{
			get { return _duration; }
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for Duration", value, value.ToString());
				_duration = value;
			}
		}

		public virtual bool IsHistory
		{
			get { return _isHistory; }
			set { _isHistory = value; }
		}

		public virtual decimal HistoricalValue
		{
			get { return _historicalValue; }
			set { _historicalValue = value; }
		}

		public virtual int PackQty
		{
			get { return _packQty; }
			set { _packQty = value; }
		}

		public virtual decimal PackPrice
		{
			get { return _packPrice; }
			set { _packPrice = value; }
		}

		public virtual int ProductTypeId
		{
			get { return _productTypeId; }
			set { _productTypeId = value; }
		}

		public virtual string ProductType
		{
			get { return _productType; }
			set { _productType = value; }
		}

		public virtual bool ServiceConverted
		{
			get { return _serviceConverted; }
			set { _serviceConverted = value; }
		}

		public virtual string TestingArea
		{
			get { return _tesingArea; }
			set { _tesingArea = value; }
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

		public int CompareTo(object obj)
		{
			if (!(obj is ForecastedResult))
				throw new InvalidCastException("This object is not of type ForecastedResult");
			
			int relativeValue;
			switch (SortExpression)
			{
				case "Id":
					relativeValue = this.Id.CompareTo(((ForecastedResult)obj).Id);
					break;
				case "DurationDateTime":
					relativeValue = this.DurationDateTime.CompareTo(((ForecastedResult)obj).DurationDateTime);
					break;
				default:
					goto case "Id";
			}
			if (ForecastedResult.SortDirection == SortDirection.Ascending)
				relativeValue *= -1;
			return relativeValue;
		}
		#endregion
	}

	#endregion
}
