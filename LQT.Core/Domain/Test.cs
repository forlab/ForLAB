
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

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// Test object for NHibernate mapped table 'Fr_Test'.
	/// </summary>
	public class Test 
	{
		#region Member Variables
		
		private int _id;
		private string _testName;		
		private TestingArea _testingArea;
		private TestingGroup _testingGroup;
        private IList<ProductUsage> _productUsages;
        private string _testType;
        private string _testingDuration;

		#endregion

		#region Constructors

		public Test() 
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

        public virtual string TestName
		{
			get { return _testName; }
			set
			{
				if ( value != null && value.Length > 128)
					throw new ArgumentOutOfRangeException("Invalid value for TestName", value, value.ToString());
				_testName = value;
			}
		}

        public virtual TestingArea TestingArea
		{
			get { return _testingArea; }
			set { _testingArea = value; }
		}

        public virtual TestingGroup TestingGroup
		{
			get { return _testingGroup; }
			set { _testingGroup = value; }
		}

        public virtual IList<ProductUsage> ProductUsages
        {
            get
            {
                if (_productUsages == null)
                {
                    _productUsages = new List<ProductUsage>();
                }
                return _productUsages;
            }
            set { _productUsages = value; }
        }

        public virtual string TestType
        {
            get { return _testType; }
            set { _testType = value; }
        }

        public virtual string TestingDuration
        {
            get { return _testingDuration; }
            set { _testingDuration = value; }
        }
		#endregion
		
        public virtual ProductUsage GetProductUsage(int id)
        {
            foreach (ProductUsage p in ProductUsages)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        public virtual bool IsExsistProductUsage(int insid, int proId)
        {
             foreach (ProductUsage p in ProductUsages)
            {
                if (p.Instrument.Id== insid && p.Product.Id == proId)
                    return true;
            }
            return false;
        }

        public virtual IList<ProductUsage> GetProductUsageByInstrumentId(int instid)
        {
            IList<ProductUsage> result = new List<ProductUsage>();
            foreach (ProductUsage p in ProductUsages)
            {
                if (p.Instrument.Id == instid)
                {
                    result.Add(p);
                }
            }
            return result;
        }
   	}

}
