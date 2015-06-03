
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
    public class NHMorbiditySupplyForecastDao: NHibernateDao<MorbiditySupplyForecast>, IMorbiditySupplyForecastDao
    {
        public IList GetSummaryOfTotalCost(int forecastid)
        {
            string sql = " SELECT Platform, sum(FinalQuantity * UnitCost) as amount  FROM MorbiditySupplyForecast";
            sql += String.Format(" where MForecastId = {0}  group by Platform", forecastid);

            ISession session = NHibernateHelper.OpenSession();
            return session.CreateSQLQuery(sql)
                 .AddScalar("Platform", NHibernateUtil.Int32)
                 .AddScalar("amount", NHibernateUtil.Double)
                 .List();
        }
    }
}
