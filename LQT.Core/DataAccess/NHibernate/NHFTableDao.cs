
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


namespace LQT.Core.DataAccess.NHibernate
{
    public class NHFTableDao : NHibernateDao<FTable>, IFTableDao
    {
        public IList<MasterProduct> GetFTableProducts(int finfoid)
        {
            string sql = "select  distinct t.Product  from FTable t where t.ForecastId = :fid";
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(sql);
            q.SetInt32("fid", finfoid);

            return q.List<MasterProduct>();
        }

        public IList GetFResult(int finfoid, int proid)
        {
            string sql = "select  r.Duration as dur, sum(r.Forecast) as qty, sum(r.Cost) as cost";
            sql += " from FTable as t inner join FResult as r on t.Id = r.FTableId";
            sql += String.Format(" where t.ForecastId = {0} and t.ProductId = {1} group by  r.Duration", finfoid, proid);

            ISession session = NHibernateHelper.OpenSession();
            return session.CreateSQLQuery(sql)
                .AddScalar("dur", NHibernateUtil.String)
                .AddScalar("qty", NHibernateUtil.Decimal)
                .AddScalar("cost", NHibernateUtil.Decimal)
                .List();
        }

        public IList RptForecastTestSummary(int finfoid)
        {
            string sql = "SELECT R.Duration as dur, U.ProductId as id, ";
            sql += " (SELECT ProductName FROM MasterProduct WHERE ProductID = U.ProductId)as pname,";
            sql += " sum(R.Forecast* U.Trate)as tusage ,";
            sql += " (SELECT PackagingSize FROM   MasterProduct WHERE ProductID = U.ProductId) as packs,";
            sql += " (SELECT Price FROM MasterProduct WHERE ProductID = U.ProductId) as price";
            sql += " FROM FTable AS T INNER JOIN  FResult AS R ON T.Id = R.FTableId";
            sql += " INNER JOIN (SELECT ProductId, TestId, SUM(Rate) AS Trate FROM ProductUsage";
            sql += String.Format(" GROUP BY TestId, ProductId) AS U ON U.TestId = T.TestId where T.ForecastId = {0}", finfoid);
            sql += " group by R.Duration, U.ProductId order by U.ProductId";

            ISession session = NHibernateHelper.OpenSession();
            return session.CreateSQLQuery(sql)
                .AddScalar("dur", NHibernateUtil.String)
                .AddScalar("id", NHibernateUtil.Int32)
                .AddScalar("pname", NHibernateUtil.String)
                .AddScalar("tusage", NHibernateUtil.Decimal)                
                .AddScalar("packs", NHibernateUtil.Int32)
                .AddScalar("price", NHibernateUtil.Decimal)
                .List();
        }

        public IList<FTable> GetFTableByFinfoId(int finfoid)
        {
            string sql = "from FTable t where t.ForecastId = :fid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(sql);
            q.SetInt32("fid", finfoid);

            return q.List<FTable>();
        }
    }
}
