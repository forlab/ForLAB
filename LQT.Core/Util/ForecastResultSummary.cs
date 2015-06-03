
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
