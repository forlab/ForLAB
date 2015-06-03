
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
using System.Collections.Generic;
using LQT.Core.Util;

namespace LQT.Core.Domain
{	
	/// <summary>
	/// QuantifyMenu object for NHibernate mapped table 'QuantifyMenu'.
	/// </summary>
	public class QuantifyMenu
		{
		
		private int _id;
		private int _instrumentId;
        private int _prodcutId;
		private string _classOfTest;
		private string _title;
		private string _testType;
		private string _duration;
        private string _chemTestName;
		private MorbidityTest _morbidityTets;
		private IList<QuantificationMetric> _quantificationMetrics;
		
		
		#region Constructors

        public QuantifyMenu()
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

        public virtual int ProductId
        {
            get { return _prodcutId; }
            set { _prodcutId = value; }
        }

		public virtual int InstrumentId
		{
			get { return _instrumentId; }
			set { _instrumentId = value; }
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
		public virtual string Title
		{
			get { return _title; }
			set
			{
				if ( value != null && value.Length > 156)
					throw new ArgumentOutOfRangeException("Invalid value for Title", value, value.ToString());
				_title = value;
			}
		}

        public virtual string DisplayTitle
        {
            get { return _title.Replace('_', ' '); }
        }

		public virtual string TestType
		{
			get { return _testType; }
			set
			{
				if ( value != null && value.Length > 32)
					throw new ArgumentOutOfRangeException("Invalid value for TestType", value, value.ToString());
				_testType = value;
			}
		}
        
        public virtual TestTypeEnum TestTypeToEnum
        {
            get { return (TestTypeEnum)Enum.Parse(typeof(TestTypeEnum), TestType); }
        }

		public virtual string Duration
		{
			get { return _duration; }
			set
			{
				if ( value != null && value.Length > 16)
					throw new ArgumentOutOfRangeException("Invalid value for Duration", value, value.ToString());
				_duration = value;
			}
		}
        public virtual TestingDurationEnum DurationToEnum
        {
            get { return (TestingDurationEnum)Enum.Parse(typeof(TestingDurationEnum), Duration); }
        }
		public virtual MorbidityTest MorbidityTest
		{
			get { return _morbidityTets; }
			set { _morbidityTets = value; }
		}

        public virtual string ChemTestName
        {
            get { return _chemTestName; }
            set { _chemTestName = value; }
        }
        
        public virtual ChemistryTestNameEnum ChemTestNameToEnum
        {
            get { return (ChemistryTestNameEnum)Enum.Parse(typeof(ChemistryTestNameEnum), ChemTestName); }
        }

		public virtual IList<QuantificationMetric> QuantificationMetrics
		{
			get
			{
				if (_quantificationMetrics==null)
				{
					_quantificationMetrics = new List<QuantificationMetric>();
				}
				return _quantificationMetrics;
			}
			set { _quantificationMetrics = value; }
		}

        public virtual IList<int> GetSelectedProductId()
        {
            IList<int> proids = new List<int>();
            foreach (QuantificationMetric p in QuantificationMetrics)
            {
                proids.Add(p.Product.Id);
            }
            return proids;
        }

        public virtual bool IsProductSelected(int productid)
        {
            foreach (QuantificationMetric p in QuantificationMetrics)
            {
                if (p.Product.Id == productid)
                    return true;
            }
            return false;
        }
		#endregion
	}

}
