
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
    public class NHPatientsNoofTestDao : NHibernateDao<PatientsNoofTest>, IPatientsNoofTestDao
    {
        public PatientsNoofTest GetPatientsNoofTestSummary(int forecastId)
        {
            string sql = " SELECT ForecastId, SUM(PITMonth1) AS PITMonth1, SUM(PITMonth2) AS PITMonth2, SUM(PITMonth3) AS PITMonth3,SUM(PITMonth4) AS PITMonth4, ";
            sql += " SUM(PITMonth5) AS PITMonth5, SUM(PITMonth6) AS PITMonth6, SUM(PITMonth7) AS PITMonth7, SUM(PITMonth8) AS PITMonth8, SUM(PITMonth9) AS PITMonth9,  ";
            sql += " SUM(PITMonth10) AS PITMonth10, SUM(PITMonth11) AS PITMonth11, SUM(PITMonth12) AS PITMonth12, SUM(PPARTMonth1) AS PPARTMonth1,  ";
            sql += " SUM(PPARTMonth2) AS PPARTMonth2, SUM(PPARTMonth3) AS PPARTMonth3, SUM(PPARTMonth4) AS PPARTMonth4, SUM(PPARTMonth5) AS PPARTMonth5,  ";
            sql += " SUM(PPARTMonth6) AS PPARTMonth6, SUM(PPARTMonth7) AS PPARTMonth7, SUM(PPARTMonth8) AS PPARTMonth8, SUM(PPARTMonth9) AS PPARTMonth9,  ";
            sql += " SUM(PPARTMonth10) AS PPARTMonth10, SUM(PPARTMonth11) AS PPARTMonth11, SUM(PPARTMonth12) AS PPARTMonth12 ";
            sql += " FROM  PatientsNoofTest Where ForecastId = :forecastId ";
            sql += " GROUP BY ForecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                AddScalar("ForecastId", NHibernateUtil.Int32).
                              AddScalar("PITMonth1", NHibernateUtil.Double).
                              AddScalar("PITMonth2", NHibernateUtil.Double).
                              AddScalar("PITMonth3", NHibernateUtil.Double).
                              AddScalar("PITMonth4", NHibernateUtil.Double).
                              AddScalar("PITMonth5", NHibernateUtil.Double).
                              AddScalar("PITMonth6", NHibernateUtil.Double).
                              AddScalar("PITMonth7", NHibernateUtil.Double).
                              AddScalar("PITMonth8", NHibernateUtil.Double).
                              AddScalar("PITMonth9", NHibernateUtil.Double).
                              AddScalar("PITMonth10", NHibernateUtil.Double).
                              AddScalar("PITMonth11", NHibernateUtil.Double).
                              AddScalar("PITMonth12", NHibernateUtil.Double).
                              AddScalar("PITMonth12", NHibernateUtil.Double).
                              AddScalar("PPARTMonth1", NHibernateUtil.Double).
                              AddScalar("PPARTMonth2", NHibernateUtil.Double).
                              AddScalar("PPARTMonth3", NHibernateUtil.Double).
                              AddScalar("PPARTMonth4", NHibernateUtil.Double).
                              AddScalar("PPARTMonth5", NHibernateUtil.Double).
                              AddScalar("PPARTMonth6", NHibernateUtil.Double).
                              AddScalar("PPARTMonth7", NHibernateUtil.Double).
                              AddScalar("PPARTMonth8", NHibernateUtil.Double).
                              AddScalar("PPARTMonth9", NHibernateUtil.Double).
                              AddScalar("PPARTMonth10", NHibernateUtil.Double).
                              AddScalar("PPARTMonth11", NHibernateUtil.Double).
                              AddScalar("PPARTMonth12", NHibernateUtil.Double)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(PatientsNoofTest)));

            sqlQuery.SetInt32("forecastId", forecastId);

            return (PatientsNoofTest)sqlQuery.UniqueResult();
        }
    }
}
