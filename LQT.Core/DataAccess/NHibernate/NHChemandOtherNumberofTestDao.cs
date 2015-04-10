
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Domain;
using NHibernate;
using LQT.Core.Util;
using NHibernate.Transform;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHChemandOtherNumberofTestDao : NHibernateDao<ChemandOtherNumberofTest>, IChemandOtherNumberofTestDao
    {
        public ChemandOtherNumberofTest GetChemistryTestSummary(int forecastId)
        {
            string sql = " SELECT ForecastId, SUM(TestBasedOnProtocols) AS TestBasedOnProtocols, SUM(SymptomDirectedTests) AS SymptomDirectedTests, SUM(RepeatedDuetoClinicalReq) AS RepeatedDuetoClinicalReq, ";
            sql += " SUM(InvalidTestandWastage) AS InvalidTestandWastage, SUM(BufferStock) AS BufferStock, SUM(ReagentstoRunControls) AS ReagentstoRunControls ";
            sql += " FROM  ChemandOtherNumberofTest Where ForecastId=:forecastId and Platform =2 ";
            sql += " GROUP BY ForecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                AddScalar("ForecastId", NHibernateUtil.Int32).
                              AddScalar("TestBasedOnProtocols", NHibernateUtil.Double).
                              AddScalar("SymptomDirectedTests", NHibernateUtil.Double).
                              AddScalar("RepeatedDuetoClinicalReq", NHibernateUtil.Double).
                              AddScalar("InvalidTestandWastage", NHibernateUtil.Double).
                              AddScalar("BufferStock", NHibernateUtil.Double).
                              AddScalar("ReagentstoRunControls", NHibernateUtil.Double)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(ChemandOtherNumberofTest)));

            sqlQuery.SetInt32("forecastId", forecastId);

            ChemandOtherNumberofTest result = (ChemandOtherNumberofTest)sqlQuery.UniqueResult();

            if (result != null)
                return result;
            return null;
        }

        public ChemandOtherNumberofTest GetOtherTestSummary(int forecastId)
        {
            string sql = " SELECT ForecastId, SUM(TestBasedOnProtocols) AS TestBasedOnProtocols, SUM(SymptomDirectedTests) AS SymptomDirectedTests, SUM(RepeatedDuetoClinicalReq) AS RepeatedDuetoClinicalReq, ";
            sql += " SUM(InvalidTestandWastage) AS InvalidTestandWastage, SUM(BufferStock) AS BufferStock, SUM(ReagentstoRunControls) AS ReagentstoRunControls ";
            sql += " FROM  ChemandOtherNumberofTest Where ForecastId=:forecastId and Platform =5 ";
            sql += " GROUP BY ForecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                AddScalar("ForecastId", NHibernateUtil.Int32).
                              AddScalar("TestBasedOnProtocols", NHibernateUtil.Double).
                              AddScalar("SymptomDirectedTests", NHibernateUtil.Double).
                              AddScalar("RepeatedDuetoClinicalReq", NHibernateUtil.Double).
                              AddScalar("InvalidTestandWastage", NHibernateUtil.Double).
                              AddScalar("BufferStock", NHibernateUtil.Double).
                              AddScalar("ReagentstoRunControls", NHibernateUtil.Double)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(ChemandOtherNumberofTest)));

            sqlQuery.SetInt32("forecastId", forecastId);

            ChemandOtherNumberofTest result = (ChemandOtherNumberofTest)sqlQuery.UniqueResult();

            if (result != null)
                return result;
            return null;
        }

        public IList GetChemistryTestSummarys(int forecastid)
        {
            return GetTestSummarys(forecastid, ClassOfMorbidityTestEnum.Chemistry);
        }

        public IList GetOtherTestSummarys(int forecastid)
        {
            return GetTestSummarys(forecastid, ClassOfMorbidityTestEnum.OtherTest);
        }

        private IList GetTestSummarys(int forecastid, ClassOfMorbidityTestEnum platform)
        {
            string sql = "SELECT  TestName, sum(TestBasedOnProtocols) as TBP, sum(SymptomDirectedTests) as SD, sum(RepeatedDuetoClinicalReq)as RDC,";
            sql += " sum(InvalidTestandWastage)as ITW, sum(BufferStock) as BS, sum(ReagentstoRunControls)as RRC";
            sql += String.Format(" FROM ChemandOtherNumberofTest  where ForecastId = {0} and Platform = {1}  group by TestName order by TestName", forecastid, (int)platform);

            ISession session = NHibernateHelper.OpenSession();
            return session.CreateSQLQuery(sql)
                .AddScalar("TestName", NHibernateUtil.String)
                .AddScalar("TBP", NHibernateUtil.Double)
                .AddScalar("SD", NHibernateUtil.Double)
                .AddScalar("RDC", NHibernateUtil.Double)
                .AddScalar("ITW", NHibernateUtil.Double)
                .AddScalar("BS", NHibernateUtil.Double)
                .AddScalar("RRC", NHibernateUtil.Double)
                .List();
        }
    }
}
