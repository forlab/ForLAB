
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
using System.Linq;
using System.Text;

namespace LQT.GUI.MorbidityCalculation
{
    public class QuantifyedReagent
    {
        private int _platform;
        private int _productId;
        private double _quantityNeeded;
        private double _finalValue;
        private int _minimumQuantity;

        private QuantifyedReagent()
        {
        }

        public QuantifyedReagent(int platform, int productid, int minimumQty)
        {
            _platform = platform;
            _productId = productid;
            _minimumQuantity = minimumQty;
        }
        
        public decimal UnitCost { get; set; }
        public string Unit { get; set; }
        public int PackSize { get; set; }

        public int Platform
        {
            get { return _platform; }
        }

        public int ProductId
        {
            get { return _productId; }
        }

        public double QuantityNeeded
        {
            get { return _quantityNeeded; }
            set
            {
                _quantityNeeded = value;
                if (_quantityNeeded < _minimumQuantity)
                    _finalValue = _minimumQuantity;
                else
                    _finalValue = _quantityNeeded;
            }
        }

        public int MinimumQuantity
        {
            get { return _minimumQuantity; }
        }

        public double FinalValue
        {
            get { return _finalValue; }
        }
    }
}
