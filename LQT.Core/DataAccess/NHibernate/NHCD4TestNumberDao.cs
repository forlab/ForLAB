
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
using System.Linq;
using System.Text;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Domain;
using NHibernate;
using LQT.Core.Util;
using NHibernate.Transform;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHCD4TestNumberDao : NHibernateDao<CD4TestNumber>, ICD4TestNumberDao
    {

        public CD4TestNumber GetCD4TestNumberSummary(int forecastId)
        {
            string sql = "SELECT ForecastId, SUM(ExistingPIT) AS ExistingPIT, SUM(ExistingPIPreART) AS ExistingPIPreART, SUM(CD4BaseLineTest) AS CD4BaseLineTest, ";
            sql += " SUM(NewPatienttoTreatment) AS NewPatienttoTreatment, SUM(NewPatientstoPreART) AS NewPatientstoPreART, SUM(SymptomDirectedTest) AS SymptomDirectedTest, ";
            sql += " SUM(RepeatsdutoClinicalRequest) AS RepeatsdutoClinicalRequest, SUM(Wastage) AS Wastage, SUM(ReagentstoRunControls) AS ReagentstoRunControls,SUM(BufferStockandControls) AS BufferStockandControls ";
            sql += " FROM  CD4TestNumber GROUP BY ForecastId having ForecastId = :forecastId";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                AddScalar("ForecastId", NHibernateUtil.Int32).
                              AddScalar("ExistingPIT", NHibernateUtil.Double).
                              AddScalar("ExistingPIPreART", NHibernateUtil.Double).
                              AddScalar("CD4BaseLineTest", NHibernateUtil.Double).
                              AddScalar("NewPatienttoTreatment", NHibernateUtil.Double).
                              AddScalar("NewPatientstoPreART", NHibernateUtil.Double).
                              AddScalar("SymptomDirectedTest", NHibernateUtil.Double).
                              AddScalar("RepeatsdutoClinicalRequest", NHibernateUtil.Double).
                              AddScalar("Wastage", NHibernateUtil.Double).
                              AddScalar("ReagentstoRunControls", NHibernateUtil.Double).
                              AddScalar("BufferStockandControls", NHibernateUtil.Double)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(CD4TestNumber)));

            sqlQuery.SetInt32("forecastId", forecastId);

            return (CD4TestNumber)sqlQuery.UniqueResult();
        }
    }
}
