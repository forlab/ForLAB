
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
using LQT.Core.Util;

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// ProductType object for NHibernate mapped table 'Fr_ProductType'.
	/// </summary>
	public class ProductType 
	{
		#region Member Variables
		
		private int _id;
		private string _typeName;
		private string _description;
		private IList _products;
        private Boolean _useInDemography;
        private string _classOfTest;

		#endregion

		#region Constructors

		public ProductType() 
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

        public virtual string TypeName
		{
			get { return _typeName; }
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for TypeName", value, value.ToString());
				_typeName = value;
			}
		}

        public virtual string Description
		{
			get { return _description; }
			set
			{
				if ( value != null && value.Length > 256)
					throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
				_description = value;
			}
		}

        public virtual string ClassOfTest
        {
            get { return _classOfTest; }
            set { _classOfTest = value; }
        }
        public virtual ClassOfMorbidityTestEnum ClassOfTestToEnum
        {
            get { return (ClassOfMorbidityTestEnum)Enum.Parse(typeof(ClassOfMorbidityTestEnum), ClassOfTest); }
        }
        public virtual IList Products
		{
			get
			{
				if (_products==null)
				{
					_products = new ArrayList();
				}
				return _products;
			}
			set { _products = value; }
		}
        /// <summary>
        /// Use in demograpy
        /// </summary>
        public virtual Boolean UseInDemography
        {
            get { return _useInDemography; }
            set { _useInDemography = value; }
        }

        
		#endregion
		
       
	}

}
