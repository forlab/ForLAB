
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
using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.Core.DataAccess.Interface
{
    public interface IForecastSiteProductDao :IDao<ForecastSiteProduct>
    {
        IList<ForecastSiteProduct> GetFSiteProductByProId(int fsiteid, int proid, SortDirection sd);
        decimal[] GetFSiteProAmountUsed(int fsiteid, int proid);
        IList<ForecastSiteProduct> GetHistoricalProduct(string period, string fMethodology, string dataUsage, int productId, int siteId, DateTime startDate, int noHistoryRecord);
        void BatchSaveForecastSiteProduct(IList<ForecastSiteProduct> list);
        IList<ForecastSiteProduct> GetFSiteSummarybyFSid(int fsiteid, SortDirection sd);
    }
}
