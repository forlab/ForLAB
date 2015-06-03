
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


namespace LQT.Core.Domain
{
    public interface IBaseDataUsage
    {
        int Id
        {
            get;
            set;
        }
        decimal AmountUsed
        {
            get;
            set;
        }

        string CDuration
        {
            get;
            set;
        }

        int StockOut
        {
            get;
            set;
        }

        decimal Adjusted
        {
            get;
            set;
        }

        Test Test
        {
            get;
            set;
        }

        MasterProduct Product
        {
            get;
            set;
        }
        DateTime? DurationDateTime
        {
            get;
            set;
        }

        int InstrumentDowntime
        {
            get;
            set;
        }
    }
}
