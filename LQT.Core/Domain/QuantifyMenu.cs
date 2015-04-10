
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
