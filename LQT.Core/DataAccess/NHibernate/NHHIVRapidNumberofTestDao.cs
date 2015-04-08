
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
