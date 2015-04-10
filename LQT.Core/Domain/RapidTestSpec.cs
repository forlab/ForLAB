
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
	/// RapidTestSpec object for NHibernate mapped table 'RapidTestSpec'.
	/// </summary>
	public class RapidTestSpec
		{

            private int _id;
            private string _testGroup;
            private double _usageRate;
            private int _productOrder;
            private double _serialTestSensitivity;
            private double _serialTestSpecificity;
            private double _parallelTestSensitivity;
            private double _parallelTestSpecificity;
            private MasterProduct _productId;
		
		
		#region Constructors

		public RapidTestSpec() 
		{
			this._id = -1;
		}

		#endregion

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string TestGroup
        {
            get { return _testGroup; }
            set
            {
                if (value != null && value.Length > 16)
                    throw new ArgumentOutOfRangeException("Invalid value for TestGroup", value, value.ToString());
                _testGroup = value;
            }
        }

        public virtual TestingSpecificationGroup TestGroupEnum
        {
            get
            {
                return (TestingSpecificationGroup)Enum.Parse(typeof(TestingSpecificationGroup), TestGroup);
            }
        }
        public virtual double UsageRate
        {
            get { return _usageRate; }
            set { _usageRate = value; }
        }

        public virtual int ProductOrder
        {
            get { return _productOrder; }
            set { _productOrder = value; }
        }

        public virtual double SerialTestSensitivity
        {
            get { return _serialTestSensitivity; }
            set { _serialTestSensitivity = value; }
        }

        public virtual double SerialTestSpecificity
        {
            get { return _serialTestSpecificity; }
            set { _serialTestSpecificity = value; }
        }

        public virtual double ParallelTestSensitivity
        {
            get { return _parallelTestSensitivity; }
            set { _parallelTestSensitivity = value; }
        }

        public virtual double ParallelTestSpecificity
        {
            get { return _parallelTestSpecificity; }
            set { _parallelTestSpecificity = value; }
        }

        public virtual MasterProduct Product
        {
            get { return _productId; }
            set { _productId = value; }
        }


        #endregion

        public virtual double SerialFalseNegative
        {
            get { return Math.Round((1 - (SerialTestSensitivity / 100)) * 100, 1); }
        }

        public virtual double SerialFalsePositive
        {
            get { return Math.Round((1 - (SerialTestSpecificity / 100)) * 100, 1); }
        }

        public virtual double ParallelFalseNegative
        {
            get { return Math.Round((1 - (ParallelTestSensitivity / 100)) * 100, 1); }
        }

        public virtual double ParallelFalsePositive
        {
            get { return Math.Round((1 - (ParallelTestSpecificity / 100)) * 100, 1); }
        }
        public virtual int GetProductId()
        {
            if (_productId != null)
                return _productId.Id;
            return 0;
        }

        public virtual int GetProductPackSize()
        {
            if (_productId != null)
            {
                ProductPrice activeprod = _productId.GetActiveProductPrice(DateTime.Now);

                return activeprod != null ? activeprod.PackSize : 0;
            }
            return 0;
        }
	}

}
