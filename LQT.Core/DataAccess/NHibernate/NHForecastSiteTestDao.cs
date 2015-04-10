
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
using System.Collections;
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using NHibernate.Transform;


namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForecastSiteTestDao : NHibernateDao<ForecastSiteTest>, IForecastSiteTestDao
    {
        public IList<ForecastSiteTest> GetFSiteTestByTestId(int ftid, int testid, SortDirection sd)
        {
            string sort = "asc";
            if (sd == SortDirection.Descending)
                sort = "desc";

            string hql = "from ForecastSiteTest t where t.ForecastSite.Id = :sid and t.Test.Id = :tid order by t.DurationDateTime " + sort;;

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("sid", ftid);
            q.SetInt32("tid", testid);

            return q.List<ForecastSiteTest>(); 
        }

        public decimal[] GetFSiteTestAdjusted(int ftid, int testid)
        {
            string hql = String.Format("select t.Adjusted as aused from ForecastSiteTest t where t.ForecastSiteId = {0} and t.TestId = {1}", ftid, testid);
            hql += " order by t.Id desc";
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

        public IList<ForecastSiteTest> GetHistoricalTest(string period, string fMethodology, string dataUsage, int testId, int siteId, DateTime startDate, int noHistoryRecord)
        {
            string noOfRecord = string.Empty;

            string sql = " ";

            if (noHistoryRecord > 0)
                sql += "SELECT TOP " + noHistoryRecord.ToString() + " ";
            else
                sql += " SELECT ";

            sql += " fsitetest.DurationDateTime,fsitetest.CDuration, ";
            sql += " fsitetest.AmountUsed,fsitetest.StockOut,fsitetest.Adjusted ";

            sql += " FROM  ForecastInfo as finfo INNER JOIN ";
            sql += " ForecastSite as fsite ON finfo.ForecastID = fsite.ForecastInfoId RIGHT OUTER JOIN ";
            sql += " ForecastSiteTest as fsitetest ON fsite.Id = fsitetest.ForecastSiteID ";
            sql += " where finfo.Period=:fperiod and finfo.Methodology= :fmetho and finfo.DataUsage= :dusage and ";
            sql += "fsitetest.TestID= :tid and fsite.SiteId= :sid and fsitetest.DurationDateTime < :sdate";
            sql += " GROUP BY fsitetest.DurationDateTime,fsitetest.CDuration, ";
            sql += " fsitetest.AmountUsed,fsitetest.StockOut,fsitetest.Adjusted ";
            sql += " ORDER BY fsitetest.DurationDateTime DESC";

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
                              SetResultTransformer(Transformers.AliasToBean(typeof(ForecastSiteTest)));
            sqlQuery.SetString("fmetho", fMethodology);
            sqlQuery.SetString("dusage", dataUsage);
            sqlQuery.SetInt32("tid", testId);
            sqlQuery.SetInt32("sid", siteId);
            sqlQuery.SetDateTime("sdate", startDate);
            sqlQuery.SetString("fperiod", period);

            IList<ForecastSiteTest> result = sqlQuery.List<ForecastSiteTest>();

            if (result != null)
                return result;
            return null;

        }


        public void BatchSaveForecastSiteTest(IList<ForecastSiteTest> list)
        {
            ISession session = NHibernateHelper.OpenSession();
            using (ITransaction trans = session.BeginTransaction())
            {
                foreach (ForecastSiteTest fr in list)
                {
                    session.SaveOrUpdate(fr);
                }
                session.Flush();
                trans.Commit();
            }
        }

    }
}
