
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
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using NHibernate.Transform;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHMorbiditySupplyProcurementDao: NHibernateDao<MorbiditySupplyProcurement>, IMorbiditySupplyProcurementDao
    {

        public IList<MorbiditySupplyProcurement> GetMorbiditySupplyForecastSummery(int MForecastId)
        {

            string sql = " SELECT MForecastId, Platform,  SUM(FinalQuantity) AS QuantityNeeded,0 as QuantityInStock,ProductId, ";
            sql += " dbo.fnGetProductPrice(ProductId,(Select SatartDate from MorbidityForecast m where m.ForecastId=MForecastId)) as UnitCost, ";
            sql += " dbo.fnGetProductPacksize(ProductId,(Select SatartDate from dbo.MorbidityForecast m where m.ForecastId=MForecastId))as PackSize ";
            sql += " FROM  MorbiditySupplyForecast where MForecastId=:mForecastId ";
            sql += " GROUP BY MForecastId,Platform, ProductId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                              AddScalar("MForecastId", NHibernateUtil.Int32).
                              AddScalar("Platform", NHibernateUtil.Int32).
                              AddScalar("QuantityNeeded", NHibernateUtil.Double).
                              AddScalar("QuantityInStock", NHibernateUtil.Double).
                              AddScalar("ProductId", NHibernateUtil.Int32).
                              AddScalar("UnitCost", NHibernateUtil.Double).
                              AddScalar("PackSize", NHibernateUtil.Int32)
                              .SetResultTransformer(Transformers.AliasToBean(typeof(MorbiditySupplyProcurement)));

            sqlQuery.SetInt32("mForecastId", MForecastId);


            IList<MorbiditySupplyProcurement> result = sqlQuery.List<MorbiditySupplyProcurement>();

            if (result != null)
                return result;
            return null;
        }

        public void BatchSaveMorbiditySupplyProcurement(IList<MorbiditySupplyProcurement> list)
        {            
            ISession session = NHibernateHelper.OpenSession();
            using (ITransaction trans = session.BeginTransaction())
            {
                foreach (MorbiditySupplyProcurement msp in list)
                {
                    session.SaveOrUpdate(msp);
                }
                session.Flush();
                trans.Commit();
            }
        }


        public IList<MorbiditySupplyProcurement> GetMorbiditySPByForecastId(int forecastId)
        {
            string hql = " from MorbiditySupplyProcurement p where p.MForecastId = :forecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("forecastId", forecastId);

            return q.List<MorbiditySupplyProcurement>(); 
        }

        public IList<MorbiditySupplyProcurement> GetMorbiditySPByForecastIdPlatformId(int forecastId, int platformId)
        {
            string hql = " from MorbiditySupplyProcurement p where p.MForecastId = :forecastId and p.Platform=:platformId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("forecastId", forecastId);
            q.SetInt32("platformId", platformId);

            return q.List<MorbiditySupplyProcurement>(); 
        }

        public void DeleteAllSupplyForecastSummery(int MForecastId)
        {
            string sql = String.Format("FROM MorbiditySupplyProcurement msp WHERE msp.MForecastId = {0}", MForecastId);
            ISession session = NHibernateHelper.OpenSession();

            using (ITransaction trans = session.BeginTransaction())
            {
                session.Delete(sql);

                session.Flush();
                trans.Commit();
            }
        }

        public IList<MorbiditySupplyProcurement> GetSupplyProcurementByForecastId(int MforecastId)
        {
            string hql = " from MorbiditySupplyProcurement p where p.MForecastId = :forecastId ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("forecastId", MforecastId);
           

            return q.List<MorbiditySupplyProcurement>(); 
        }
    }
}
