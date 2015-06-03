
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
using NHibernate.Transform;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHHIVRapidNumberofTestDao:NHibernateDao<HIVRapidNumberofTest>,IHIVRapidNumberofTestDao
    {
        public HIVRapidNumberofTest GetHIVRapidNumberofTestSummary(int forecastId)
        {
            string sql = " SELECT  SUM(Screening) AS Screening, SUM(Confirmatory) AS Confirmatory, SUM(TieBreaker) AS TieBreaker ";
            sql += " FROM  HIVRapidNumberofTest Where ForecastId=:forecastId ";
           // sql += " GROUP BY ForecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                //AddScalar("ForecastId", NHibernateUtil.Int32).
                              AddScalar("Screening", NHibernateUtil.Double).
                              AddScalar("Confirmatory", NHibernateUtil.Double).
                              AddScalar("TieBreaker", NHibernateUtil.Double)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(HIVRapidNumberofTest)));

            sqlQuery.SetInt32("forecastId", forecastId);

            HIVRapidNumberofTest result = (HIVRapidNumberofTest)sqlQuery.UniqueResult();

            if (result != null)
                return result;
            return null;
        }
    }
}
