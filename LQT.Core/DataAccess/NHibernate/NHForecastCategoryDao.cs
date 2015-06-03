
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
