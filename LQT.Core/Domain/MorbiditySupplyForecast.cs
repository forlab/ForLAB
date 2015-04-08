
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
using System.Linq;
using System.Text;
using LQT.Core.Util;

namespace LQT.Core.Domain
{
    public class MorbiditySupplyForecast
    {
        #region Member Variables

        private int _id;
        private int _mForecastId;
        private int _siteId;
        private int _platform;
        private int _productId;
        private double _quantityNeeded;
        private double _finalQuantity;
        private decimal _unitCost;
        private int _packSize;
        private string _unit;

        #endregion

        #region Constructors

        public MorbiditySupplyForecast()
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

        public virtual int MForecastId
        {
            get { return _mForecastId; }
            set { _mForecastId = value; }
        }

        public virtual int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        public virtual int Platform
        {
            get { return _platform; }
            set { _platform = value; }
        }

        public virtual int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public virtual double QuantityNeeded
        {
            get { if (double.IsNaN(_quantityNeeded)) { return 0; } else { return _quantityNeeded; }; }
            set
            { 
                _quantityNeeded = value; 
            }
        }

        public virtual double FinalQuantity
        {
            get {

                if (double.IsNaN(_finalQuantity)) { return 0; } else { return _finalQuantity; };
            }
            set { _finalQuantity = value; }
        }
        
        public virtual decimal UnitCost 
        {
            get { return _unitCost; }
            set { _unitCost = value; }
        }
        
        public virtual string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        
        public virtual int PackSize
        {
            get { return _packSize; }
            set { _packSize = value; }
        }

        public virtual ClassOfMorbidityTestEnum PlatformEnum
        {
            get
            {
                return (ClassOfMorbidityTestEnum)Enum.ToObject(typeof(ClassOfMorbidityTestEnum), _platform);
            }
        }

        #endregion
    }
}
