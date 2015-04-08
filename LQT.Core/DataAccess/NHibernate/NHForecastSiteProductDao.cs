
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
using System.Collections;
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using NHibernate.Transform;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForecastSiteProductDao : NHibernateDao<ForecastSiteProduct>, IForecastSiteProductDao
    {
        public IList<ForecastSiteProduct> GetFSiteProductByProId(int fsiteid, int proid, SortDirection sd)
        {
            string sort = "asc";
            if (sd == SortDirection.Descending)
                sort = "desc";

            string hql = "from ForecastSiteProduct p where p.ForecastSite.Id = :sid and p.Product.Id = :pid order by p.DurationDateTime " + sort;

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("sid", fsiteid);
            q.SetInt32("pid", proid);

            return q.List<ForecastSiteProduct>(); 
        }

        public IList<ForecastSiteProduct> GetFSiteSummarybyFSid(int fsiteid,SortDirection sd)
        {
            try
            {
                string sort = "asc";
                if (sd == SortDirection.Descending)
                    sort = "desc";
                string sql = " SELECT SUM(ForecastSiteProduct.Adjusted) AS Adjusted, ForecastSiteProduct.DurationDateTime, ProductType.TypeName "
                           + " FROM  MasterProduct INNER JOIN ProductType ON MasterProduct.ProductTypeId = ProductType.TypeID INNER JOIN "
                           + " ForecastSiteProduct ON MasterProduct.ProductID = ForecastSiteProduct.ProductID WHERE (ForecastSiteProduct.ForecastSiteID = :fsiteid) "
                           + " GROUP BY ProductType.TypeName, ForecastSiteProduct.DurationDateTime ORDER BY ForecastSiteProduct.DurationDateTime " + sort;

                ISession session = NHibernateHelper.OpenSession();
                IQuery sqlQuery = session.CreateSQLQuery(sql).
                                  AddScalar("Adjusted", NHibernateUtil.Decimal).
                                  AddScalar("DurationDateTime", NHibernateUtil.DateTime).
                                 // AddScalar("ProductType", NHibernateUtil.String).
                                  SetResultTransformer(Transformers.AliasToBean(typeof(ForecastSiteProduct)));
                sqlQuery.SetInt32("fsiteid", fsiteid);

                IList<ForecastSiteProduct> result = sqlQuery.List<ForecastSiteProduct>();
                if (result != null)
                    return result;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public decimal[] GetFSiteProAmountUsed(int fsiteid, int proid)
        {
            string hql = String.Format("select p.Adjusted as aused from ForecastSiteProduct p where p.ForecastSiteId = {0} and p.ProductId = {1}", fsiteid, proid);
            hql += " order by p.Id desc";
            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(hql)
            .AddScalar("aused", NHibernateUtil.Decimal)
            .List();

            decimal[] temp = new decimal[result.Count];
            int i = 0;
            foreach (decimal o in result)
            {
                temp[i] = o; // (decimal)o[0];
                i++;
            }

            return temp;
        }

        public IList<ForecastSiteProduct> GetHistoricalProduct(string period, string fMethodology, string dataUsage, int productId, int siteId, DateTime startDate, int noHistoryRecord)
        {

            string sql = " ";

            if (noHistoryRecord > 0)
                sql += "SELECT TOP " + noHistoryRecord.ToString() + " ";
            else
                sql += " SELECT ";

            sql += " fsiteproduct.DurationDateTime,fsiteproduct.CDuration, ";
            sql += " fsiteproduct.AmountUsed,fsiteproduct.StockOut,fsiteproduct.Adjusted ";

            sql += " FROM  ForecastInfo as finfo INNER JOIN ";
            sql += " ForecastSite as fsite ON finfo.ForecastID = fsite.ForecastInfoId RIGHT OUTER JOIN ";
            sql += " ForecastSiteProduct as fsiteproduct ON fsite.Id = fsiteproduct.ForecastSiteID ";
            sql += " where finfo.Period=:fperiod and finfo.Methodology= :fmetho and finfo.DataUsage= :dusage and ";
            sql += "fsiteproduct.ProductID= :pid and fsite.SiteId= :sid and fsiteproduct.DurationDateTime < :sdate";
            sql += " GROUP BY fsiteproduct.DurationDateTime,fsiteproduct.CDuration, ";
            sql += " fsiteproduct.AmountUsed,fsiteproduct.StockOut,fsiteproduct.Adjusted ";
            sql += " ORDER BY fsiteproduct.DurationDateTime DESC";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                // AddScalar("ForecastSiteID", NHibernateUtil.Int32).
                // AddScalar("TestID", NHibernateUtil.Int32).
                // AddScalar("Id", NHibernateUtil.Int32).
                              AddScalar("CDuration", NHibernateUtil.String).
                              AddScalar("AmountUsed", NHibernateUtil.Decimal).
                              AddScalar("StockOut", NHibernateUtil.Int32).
                              AddScalar("Adjusted", NHibernateUtil.Decimal).
                              AddScalar("DurationDateTime", NHibernateUtil.DateTime).
                              SetResultTransformer(Transformers.AliasToBean(typeof(ForecastSiteProduct)));
            sqlQuery.SetString("fmetho", fMethodology);
            sqlQuery.SetString("dusage", dataUsage);
            sqlQuery.SetInt32("pid", productId);
            sqlQuery.SetInt32("sid", siteId);
            sqlQuery.SetDateTime("sdate", startDate);
            sqlQuery.SetString("fperiod", period);

            IList<ForecastSiteProduct> result = sqlQuery.List<ForecastSiteProduct>();

            if (result != null)
                return result;
            return null;
        }

        public void BatchSaveForecastSiteProduct(IList<ForecastSiteProduct> list)
        {
            ISession session = NHibernateHelper.OpenSession();
            using (ITransaction trans = session.BeginTransaction())
            {
                foreach (ForecastSiteProduct fr in list)
                {
                    session.SaveOrUpdate(fr);
                }
                session.Flush();
                trans.Commit();
            }
        }
    
    }
}
