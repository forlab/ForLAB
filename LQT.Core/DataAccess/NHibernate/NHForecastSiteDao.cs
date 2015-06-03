
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
    public class NHForecastSiteDao : NHibernateDao<ForecastSite>, IForecastSiteDao
    {
        public IList<ForlabSite> GetFSite(int fid)
        {

            string sql = string.Format("SELECT * FROM Site INNER JOIN ForecastSite ON ForecastSite.SiteId =Site.SiteID" 
                        +" WHERE (dbo.ForecastSite.ForecastInfoId ={0})",fid);

            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(sql).
                              AddScalar("SiteID", NHibernateUtil.Int32).List();

            IList<ForlabSite> Sites = new List<ForlabSite>();
            foreach (int i in result)
            {
                ForlabSite s = DataRepository.GetSiteById(i);
                Sites.Add(s);
            }

            return Sites;

           
        }

    }
}
