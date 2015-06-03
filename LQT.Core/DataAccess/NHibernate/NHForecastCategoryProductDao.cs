
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
using System.Collections;
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;


namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForecastCategoryProductDao : NHibernateDao<ForecastCategoryProduct>, IForecastCategoryProductDao
    {
        public IList<ForecastCategoryProduct> GetFCategoryProductByProId(int fcatid, int proid, SortDirection sd)
        {
            string sort = "asc";
            if (sd == SortDirection.Descending)
                sort = "desc";

            string hql = "from ForecastCategoryProduct p where p.Category.Id = :cid and p.Product.Id = :pid order by p.DurationDateTime " + sort;;

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("cid", fcatid);
            q.SetInt32("pid", proid);

            return q.List<ForecastCategoryProduct>(); 
        }

        public decimal[] GetFCategoryProAmountUsed(int fcatid, int proid)
        {
            string hql = String.Format("select p.Adjusted as aused from ForecastCategoryProduct p where p.CategoryId = {0} and p.ProductId = {1}", fcatid, proid);
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
    }
}
