
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

namespace LQT.Core.Domain
{
    public class Consumption
    {
        private decimal _total;
        private int _noconsumption;

        public Consumption(int noc, decimal totalc)
        {
            _noconsumption = noc;
            _total = totalc;
        }

        public int NoConsumption
        {
            get { return _noconsumption; }
        }
        public decimal TotalConsumption
        {
            get { return _total; }
        }
    }
}
