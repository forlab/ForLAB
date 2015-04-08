
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

namespace LQT.Core.Domain
{
    public class ConsumableUsage
    {
        #region Member Variables

        private int _id;
        private MasterConsumable _consumable;
        private Boolean _perTest;
        private Boolean _perPeriod;
        private Boolean _perInstrument;
        private int _noOfTest;
        private MasterProduct _product;
        private decimal _productUsageRate;
        private string _period;
        private Instrument _instrument;

        #endregion

        public ConsumableUsage() 
		{
			this._id = -1;
		}

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual MasterConsumable MasterConsumable
        {
            get { return _consumable; }
            set { _consumable = value; }
        }

        public virtual Boolean PerTest
        {
            get { return _perTest; }
            set { _perTest = value; }
        }

        public virtual Boolean PerPeriod
        {
            get { return _perPeriod; }
            set { _perPeriod = value; }
        }

        public virtual Boolean PerInstrument
        {
            get { return _perInstrument; }
            set { _perInstrument = value; }
        }

        public virtual int NoOfTest
        {
            get { return _noOfTest; }
            set { _noOfTest = value; }
        }
       
        public virtual MasterProduct Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public virtual decimal ProductUsageRate
        {
            get { return _productUsageRate; }
            set { _productUsageRate = value; }
        }
       
        public virtual string Period
        {
            get { return _period; }
            set { _period = value; }
        }

        public virtual Instrument Instrument
        {
            get { return _instrument; }
            set { _instrument = value; }
        }

        #endregion
    
    }
}
