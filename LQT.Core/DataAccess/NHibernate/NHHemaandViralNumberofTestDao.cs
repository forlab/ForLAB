
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
using System.Linq;
using System.Text;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Domain;
using NHibernate;
using NHibernate.Transform;
using LQT.Core.Util;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHHemaandViralNumberofTestDao : NHibernateDao<HemaandViralNumberofTest>, IHemaandViralNumberofTestDao
    {
        public HemaandViralNumberofTest GetHematologyTestNumberSummary(int forecastId)
        {
            string sql = " SELECT ForecastId, SUM(TestBasedOnProtocols) AS TestBasedOnProtocols, SUM(SymptomDirectedTests) AS SymptomDirectedTests, SUM(RepeatedDuetoClinicalReq) AS RepeatedDuetoClinicalReq ";
            sql += " ,SUM(InvalidTestandWastage) AS InvalidTestandWastage, SUM(BufferStockandControls) AS BufferStockandControls, SUM(ReagentstoRunControls) AS ReagentstoRunControls ";
            sql += " FROM  dbo.HemaandViralNumberofTest Where ForecastId=:forecastId and Platform=3";
            sql += " GROUP BY ForecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                AddScalar("ForecastId", NHibernateUtil.Int32).
                              AddScalar("TestBasedOnProtocols", NHibernateUtil.Double).
                              AddScalar("SymptomDirectedTests", NHibernateUtil.Double).
                              AddScalar("RepeatedDuetoClinicalReq", NHibernateUtil.Double).
                                AddScalar("InvalidTestandWastage", NHibernateUtil.Double).
                              AddScalar("BufferStockandControls", NHibernateUtil.Double).
                              AddScalar("ReagentstoRunControls", NHibernateUtil.Double)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(HemaandViralNumberofTest)));

            sqlQuery.SetInt32("forecastId", forecastId);

            HemaandViralNumberofTest result = (HemaandViralNumberofTest)sqlQuery.UniqueResult();

            if (result != null)
                return result;
            return null;
        }

        public HemaandViralNumberofTest GetViralLoadTestNumberSummary(int forecastId)
        {
            string sql = " SELECT ForecastId, SUM(TestBasedOnProtocols) AS TestBasedOnProtocols, SUM(SymptomDirectedTests) AS SymptomDirectedTests, SUM(RepeatedDuetoClinicalReq) AS RepeatedDuetoClinicalReq ";
            sql += " ,SUM(InvalidTestandWastage) AS InvalidTestandWastage, SUM(BufferStockandControls) AS BufferStockandControls, SUM(ReagentstoRunControls) AS ReagentstoRunControls ";
            sql += " FROM  dbo.HemaandViralNumberofTest Where ForecastId=:forecastId and Platform=4";
            sql += " GROUP BY ForecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                AddScalar("ForecastId", NHibernateUtil.Int32).
                              AddScalar("TestBasedOnProtocols", NHibernateUtil.Double).
                              AddScalar("SymptomDirectedTests", NHibernateUtil.Double).
                              AddScalar("RepeatedDuetoClinicalReq", NHibernateUtil.Double).
                                AddScalar("InvalidTestandWastage", NHibernateUtil.Double).
                              AddScalar("BufferStockandControls", NHibernateUtil.Double).
                              AddScalar("ReagentstoRunControls", NHibernateUtil.Double)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(HemaandViralNumberofTest)));

            sqlQuery.SetInt32("forecastId", forecastId);

            HemaandViralNumberofTest result = (HemaandViralNumberofTest)sqlQuery.UniqueResult();

            if (result != null)
                return result;
            return null;
        }
    }
}
