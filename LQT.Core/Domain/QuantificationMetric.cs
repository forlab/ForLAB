
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
