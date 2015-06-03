
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
