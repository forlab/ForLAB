
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
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;


namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForecastInfoDao : NHibernateDao<ForecastInfo>, IForecastInfoDao
    {

        public IList<ForecastInfo> GetForecastInfoByMethodology(string methodology)
        {
            string hql = "from ForecastInfo f where f.Methodology = :metho";
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("metho", methodology);

            return q.List<ForecastInfo>();
        }

        public IList<ForecastInfo> GetForecastInfoByDatausage(string methodology, string datausage)
        {
            string hql = "from ForecastInfo f where f.Methodology = :metho and f.DataUsage = :dusage";
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("metho", methodology);
            q.SetString("dusage", datausage);

            return q.List<ForecastInfo>();
        }

        public int FSTotalProductCount(int id)
        {
            string hql = "select count(*) as tc from (SELECT P.ProductID AS pid FROM ForecastSite AS S INNER JOIN";
            hql += String.Format(" ForecastSiteProduct AS P ON S.Id = P.ForecastSiteID WHERE  S.ForecastInfoId = {0}", id);
            hql += " GROUP BY P.ProductID)as pcount";

            ISession session = NHibernateHelper.OpenSession();
            object obj = session.CreateSQLQuery(hql)
                .AddScalar("tc", NHibernateUtil.Int32)
                .UniqueResult();
            if (obj != null)
                return (Int32)obj;
            return 0;
        }

        public int FSTotalTestCount(int id)
        {
            string hql = "select count(*) as tc from (SELECT P.TestID AS pid FROM ForecastSite AS S INNER JOIN";
            hql += String.Format(" ForecastSiteTest AS P ON S.Id = P.ForecastSiteID WHERE  S.ForecastInfoId = {0}", id);
            hql += " GROUP BY P.TestID)as pcount";

            ISession session = NHibernateHelper.OpenSession();
            object obj = session.CreateSQLQuery(hql)
                .AddScalar("tc", NHibernateUtil.Int32)
                .UniqueResult();
            if (obj != null)
                return (Int32)obj;
            return 0;
        }

        public int FCTotalProductCount(int id)
        {
            string hql = "select count(*) as tc from (SELECT P.ProductID AS pid FROM ForecastCategory AS S INNER JOIN";
            hql += String.Format(" ForecastCategoryProduct AS P ON S.CategoryId = P.CategoryId WHERE  S.ForecastId = {0}", id);
            hql += " GROUP BY P.ProductID)as pcount";

            ISession session = NHibernateHelper.OpenSession();
            object obj = session.CreateSQLQuery(hql)
                .AddScalar("tc", NHibernateUtil.Int32)
                .UniqueResult();
            if (obj != null)
                return (Int32)obj;
            return 0;
        }

        public int FCTotalTestCount(int id)
        {
            string hql = "select count(*) as tc from (SELECT P.TestID AS pid FROM ForecastCategory AS S INNER JOIN";
            hql += String.Format(" ForecastCategoryTest AS P ON S.CategoryId = P.CategoryId WHERE  S.ForecastId = {0}", id);
            hql += " GROUP BY P.TestID)as pcount";
            
            ISession session = NHibernateHelper.OpenSession();
            object obj = session.CreateSQLQuery(hql)
                .AddScalar("tc", NHibernateUtil.Int32)
                .UniqueResult();
            if (obj != null)
                return (Int32)obj;
            return 0;
        }
    }
}
