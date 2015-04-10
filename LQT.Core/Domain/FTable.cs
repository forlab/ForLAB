
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
using System.Collections.Generic;
using LQT.Core.Util;

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// FTable object for NHibernate mapped table 'FTable'.
	/// </summary>
	public class FTable 
	{
		#region Member Variables
		
		private int _id;
		private int _forecastId;
		private int _forecastSiteId;
        private int _siteId;
        private int _categoryId;
		private decimal _price;
        private string _groupTitle;
        private string _methodology;
        private string _dataUsage;
        
        private Test _test;
		private MasterProduct _product;
		private IList<FTableRow> _tableRows;
		private IList<FResult> _fResults;

		#endregion

		#region Constructors

		public FTable() 
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

		public virtual int ForecastSiteId
		{
			get { return _forecastSiteId; }
			set { _forecastSiteId = value; }
		}
        public virtual int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }
        
		public virtual decimal Price
		{
			get { return _price; }
			set { _price = value; }
		}

        public virtual int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public virtual string GroupTitle
        {
            get { return _groupTitle; }
            set { _groupTitle = value; }
        }
        public virtual string Methodology
        {
            get { return _methodology; }
            set
            {
                _methodology = value;
            }
        }
        public virtual MethodologyEnum FMethodologyEnum
        {
            get { return (MethodologyEnum)Enum.Parse(typeof(MethodologyEnum), _methodology); }
        }

        public virtual string DataUsage
        {
            get { return _dataUsage; }
            set
            {
                _dataUsage = value;
            }
        }
        public virtual DataUsageEnum DatausageEnum
        {
            get { return (DataUsageEnum)Enum.Parse(typeof(DataUsageEnum), _dataUsage); }
        }
		public virtual MasterProduct Product
		{
			get { return _product; }
			set { _product = value; }
		}
        
        public virtual Test Test
        {
            get { return _test; }
            set { _test = value; }
        }

		public virtual IList<FTableRow> TableRows
		{
			get
			{
				if (_tableRows==null)
				{
					_tableRows = new List<FTableRow>();
				}
				return _tableRows;
			}
			set { _tableRows = value; }
		}

		public virtual IList<FResult> FResults
		{
			get
			{
				if (_fResults==null)
				{
					_fResults = new List<FResult>();
				}
				return _fResults;
			}
			set { _fResults = value; }
		}

        
		#endregion
		
       
	}

}
