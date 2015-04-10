
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
