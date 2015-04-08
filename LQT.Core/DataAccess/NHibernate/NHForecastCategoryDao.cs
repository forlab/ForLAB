
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
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using System.Collections;


namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForecastCategoryDao : NHibernateDao<ForecastCategory>, IForecastCategoryDao
    {
        public ForecastCategory GetForecastCategoryByName(int fcastid, string cname)
        {
            string hql = "from ForecastCategory c where c.ForecastInfo.Id = :fcastid and c.CategoryName = :cname";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("cname", cname);
            q.SetInt32("fcastid", fcastid);

            IList<ForecastCategory> result = q.List<ForecastCategory>();

            if (result.Count > 0)
                return result[0];

            return null;
        }

        public IList<ForecastCategory> GetFCategory(int fid)
        {
            //string hql = "from ForecastCategory c where c.ForecastInfo.Id = :fid ";

            //ISession session = NHibernateHelper.OpenSession();
            //IQuery q = session.CreateQuery(hql);
            //q.SetInt32("fid", fid);

            //IList<ForecastCategory> result = q.List<ForecastCategory>();

            //if (result.Count > 0)
            //    return result;

            //return null;



            string sql = string.Format("SELECT * FROM ForecastCategory INNER JOIN ForecastInfo ON ForecastCategory.ForecastId =ForecastInfo.ForecastID"
                    + " WHERE (dbo.ForecastCategory.ForecastId ={0})", fid);

            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(sql).
                              AddScalar("CategoryId", NHibernateUtil.Int32).List();

            IList<ForecastCategory> cat = new List<ForecastCategory>();
            foreach (int i in result)
            {
                ForecastCategory c = DataRepository.GetForecastCategoryById(i);
                cat.Add(c);
            }

            return cat;
        }
        
    }
}
