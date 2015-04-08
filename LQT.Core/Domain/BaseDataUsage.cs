
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


namespace LQT.Core.Domain
{
    public  class BaseDataUsage : IBaseDataUsage
    {
        private int _id;
        private decimal _amountUsed;
        private string _cDuration;
        private int _stockOut;
        private decimal _adjusted;
        private DateTime? _durationDatetime;
        private MasterProduct _masterProduct;
        private Test _test;
        private int _instrumentDowntime;
        

        public BaseDataUsage()
        {
            this._id = -1;
        }

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual decimal AmountUsed
        {
            get { return _amountUsed; }
            set { _amountUsed = value; }
        }

        public virtual string CDuration
        {
            get { return _cDuration; }
            set { _cDuration = value; }
        }

        public virtual int StockOut
        {
            get { return _stockOut; }
            set { _stockOut = value; }
        }

        public virtual int InstrumentDowntime
        {
            get { return _instrumentDowntime; }
            set { _instrumentDowntime = value; }
        }
        public virtual decimal Adjusted
        {
            get { return _adjusted; }
            set { _adjusted = value; 
            }
        }

        public virtual DateTime? DurationDateTime
        {
            get { return _durationDatetime; }
            set { _durationDatetime = value; }
        }

        public virtual Test Test
        {
            get { return _test; }
            set { _test = value; }
        }

        public virtual MasterProduct Product
        {
            get { return _masterProduct; }
            set { _masterProduct = value; }
        }
    }
}
