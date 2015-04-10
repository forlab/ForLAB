
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

namespace LQT.Core.Util
{
    public class ForecastResultSummary
    {
        private decimal _forecastValue;
        private DateTime _forecastDateTime;
        private string _productType;

        public virtual decimal ForecastValue
        {
            get { return _forecastValue; }
            set { _forecastValue = value; }
        }

        public virtual DateTime ForecastDateTime
        {
            get { return _forecastDateTime; }
            set { _forecastDateTime = value; }
        }

        public virtual string ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }
    }
}
