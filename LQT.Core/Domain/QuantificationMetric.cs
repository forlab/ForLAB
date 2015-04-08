
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
using LQT.Core.Util;

namespace LQT.Core.Domain
{	
	/// <summary>
	/// QuantificationMetric object for NHibernate mapped table 'QuantificationMetric'.
	/// </summary>
	public class QuantificationMetric
		{
		
		private int _id;
		private string _classOfTest;
		private double _usageRate;
		private string _collectionSupplieAppliedTo;
		private MasterProduct _product;
		private QuantifyMenu _quantifyMenu;
		
		
		#region Constructors

		public QuantificationMetric() 
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

		public virtual string ClassOfTest
		{
			get { return _classOfTest; }
			set
			{
				if ( value != null && value.Length > 16)
					throw new ArgumentOutOfRangeException("Invalid value for ClassOfTest", value, value.ToString());
				_classOfTest = value;
			}
		}
        public virtual ClassOfMorbidityTestEnum ClassOfTestToEnum
        {
            get { return (ClassOfMorbidityTestEnum)Enum.Parse(typeof(ClassOfMorbidityTestEnum), ClassOfTest); }
        }
		public virtual double UsageRate
		{
			get { return _usageRate; }
			set { _usageRate = value; }
		}

		public virtual string CollectionSupplieAppliedTo
		{
			get { return _collectionSupplieAppliedTo; }
			set
			{
				if ( value != null && value.Length > 16)
					throw new ArgumentOutOfRangeException("Invalid value for CollectionSupplieAppliedTo", value, value.ToString());
				_collectionSupplieAppliedTo = value;
			}
		}

		public virtual MasterProduct Product
		{
			get { return _product; }
			set { _product = value; }
		}

		public virtual QuantifyMenu QuantifyMenu
		{
			get { return _quantifyMenu; }
			set { _quantifyMenu = value; }
		}

        
		#endregion
	}

}
