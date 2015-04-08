
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
