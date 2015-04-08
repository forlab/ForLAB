
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
using System.Collections;
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using NHibernate.Transform;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForecastedResultDao :NHibernateDao<ForecastedResult>, IForecastedResultDao
    {
        private ITransaction _tansaction;
        private ISession _session;

        public void OpenBatchTransaction()
        {
            _session = NHibernateHelper.OpenSession();
            _tansaction = _session.BeginTransaction();
        }
        public void CommitBatchTransaction()
        {
            _session.Flush();
            _tansaction.Commit();
            _session.Close();
            _session = null;
            _tansaction = null;
        }
        public void RolebackBatchTransaction()
        {
            _tansaction.Rollback();
            _session = null;
            _tansaction = null;
        }
        public void BatchSave(ForecastedResult fr)
        {
            _session.SaveOrUpdate(fr);
        }

        public void BatchDelete(ForecastedResult fr)
        {
            _session.Delete(fr);
        }

        public void DeleteAllFResult(int finfoid)
        {
            string sql = String.Format("FROM ForecastedResult r WHERE r.ForecastId = {0}", finfoid);
            ISession session = NHibernateHelper.OpenSession();

            using (ITransaction trans = session.BeginTransaction())
            {
                session.Delete(sql); // CreateQuery(sql).List();
                
                session.Flush();
                trans.Commit();
            }
        }

        public IList GetBeyondMaxTPutResult(int finfoid, int monthinperiod)
        {
            string sql = "SELECT Test.TestName as tname, (select SiteName from Site where SiteId = fr.SiteId) as Sname, ";
            sql += " fr.Duration as dur, fr.ForecastValue as fv, ";
            sql += String.Format("({0} * dbo.fnGetMaxThroughPutOfSite(fr.SiteId, Test.TestingAreaID)) as MaxV", monthinperiod);
            sql += " FROM ForecastedResult AS fr 	INNER JOIN 	Test ON fr.TestId = Test.TestID INNER JOIN ";
            sql += " TestingArea AS ta ON Test.TestingAreaID = ta.TestingAreaID ";
            sql += String.Format("where fr.ForecastID = {0} and fr.ForecastValue >({1} * dbo.fnGetMaxThroughPutOfSite(fr.SiteId, Test.TestingAreaID))", finfoid, monthinperiod);

            ISession session = NHibernateHelper.OpenSession();
            return session.CreateSQLQuery(sql)                    
                    .AddScalar("sname", NHibernateUtil.String)
                    .AddScalar("tname", NHibernateUtil.String)
                    .AddScalar("dur", NHibernateUtil.String)
                    .AddScalar("fv", NHibernateUtil.Int32)
                    .AddScalar("MaxV", NHibernateUtil.Int32)
                    .List();
        }


        public IList<MAPEResult> GetSiteMAPEByTest(int fid, int fsid, int tid)
        {
            string sql=" SELECT dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.ForecastValue,dbo.ForecastedResult.HistoricalValue, ";
                   sql+=" (dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue) as MapeValue, ";
                   sql+=" isnull(((dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue)/nullif(dbo.ForecastedResult.HistoricalValue,0))*100,100) as MapePercentage ";
                   sql += " FROM dbo.ForecastedResult LEFT OUTER JOIN  dbo.ForecastSite ON dbo.ForecastedResult.SiteId = dbo.ForecastSite.SiteId ";
                   sql += " AND dbo.ForecastedResult.ForecastId = dbo.ForecastSite.ForecastInfoId ";
                   sql += " where dbo.ForecastSite.ForecastInfoId=:finfoid and (dbo.ForecastSite.Id =:fsiteid) AND (dbo.ForecastedResult.TestId =:testid) and dbo.ForecastedResult.IsHistory=:ishistory ";
                   sql += " order by dbo.ForecastedResult.ProductId,dbo.ForecastedResult.DurationDateTime asc ";
            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
            AddScalar("DurationDateTime", NHibernateUtil.DateTime).
            AddScalar("ForecastValue", NHibernateUtil.Decimal).
            AddScalar("HistoricalValue", NHibernateUtil.Decimal).
            AddScalar("MapeValue", NHibernateUtil.Decimal).
            AddScalar("MapePercentage", NHibernateUtil.Decimal).
            SetResultTransformer(Transformers.AliasToBean(typeof(MAPEResult)));

            sqlQuery.SetInt32("finfoid", fid);
            sqlQuery.SetInt32("fsiteid", fsid);
            sqlQuery.SetInt32("testid", tid);
            sqlQuery.SetBoolean("ishistory", true);


            IList<MAPEResult> result = sqlQuery.List<MAPEResult>();
            return result;
        }

        public IList<MAPEResult> GetSiteMAPEByProduct(int fid, int fsid, int pid)
        {

            string sql = " SELECT dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.ForecastValue,dbo.ForecastedResult.HistoricalValue, ";
            sql += " (dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue) as MapeValue,";
            sql +=  " isnull(((dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue)/nullif(dbo.ForecastedResult.HistoricalValue,0))*100,100) as MapePercentage ";
            sql += " FROM dbo.ForecastedResult LEFT OUTER JOIN  dbo.ForecastSite ON dbo.ForecastedResult.SiteId = dbo.ForecastSite.SiteId ";
            sql += " AND dbo.ForecastedResult.ForecastId = dbo.ForecastSite.ForecastInfoId ";
            sql += " where dbo.ForecastSite.ForecastInfoId=:finfoid and (dbo.ForecastSite.Id =:fsiteid) AND (dbo.ForecastedResult.ProductId =:prodid) and dbo.ForecastedResult.IsHistory=1";
            sql += " order by dbo.ForecastedResult.ProductId,dbo.ForecastedResult.DurationDateTime asc ";
            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
            AddScalar("DurationDateTime", NHibernateUtil.DateTime).
            AddScalar("ForecastValue", NHibernateUtil.Decimal).
            AddScalar("HistoricalValue", NHibernateUtil.Decimal).
            AddScalar("MapeValue", NHibernateUtil.Decimal).
            AddScalar("MapePercentage", NHibernateUtil.Decimal).
            SetResultTransformer(Transformers.AliasToBean(typeof(MAPEResult)));

            sqlQuery.SetInt32("finfoid", fid);
            sqlQuery.SetInt32("fsiteid", fsid);
            sqlQuery.SetInt32("prodid", pid);
           // sqlQuery.SetBoolean("ishistory", true);


            IList<MAPEResult> result = sqlQuery.List<MAPEResult>();
            return result;
        }

        public IList<MAPEResult> GetCategoryMAPEByProduct(int fid, int cid, int pid)
        {

            string sql = " SELECT dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.ForecastValue,dbo.ForecastedResult.HistoricalValue, ";
            sql += " (dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue) as MapeValue, ";
            sql += " isnull(((dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue)/nullif(dbo.ForecastedResult.HistoricalValue,0))*100,100) as MapePercentage ";
            sql += " FROM dbo.ForecastedResult ";
            sql += " where dbo.ForecastedResult.ForecastId=:finfoid and  (dbo.ForecastedResult.CategoryId =:catid) and (dbo.ForecastedResult.ProductId =:prodid) and dbo.ForecastedResult.IsHistory=:ishistory";
            sql += " order by dbo.ForecastedResult.ProductId,dbo.ForecastedResult.DurationDateTime asc ";
            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
            AddScalar("DurationDateTime", NHibernateUtil.DateTime).
            AddScalar("ForecastValue", NHibernateUtil.Decimal).
            AddScalar("HistoricalValue", NHibernateUtil.Decimal).
            AddScalar("MapeValue", NHibernateUtil.Decimal).
            AddScalar("MapePercentage", NHibernateUtil.Decimal).
            SetResultTransformer(Transformers.AliasToBean(typeof(MAPEResult)));

            sqlQuery.SetInt32("finfoid", fid);
            sqlQuery.SetInt32("catid", cid);
            sqlQuery.SetInt32("prodid", pid);
            sqlQuery.SetBoolean("ishistory", true);


            IList<MAPEResult> result = sqlQuery.List<MAPEResult>();
            return result;
        }

        public IList<MAPEResult> GetCategoryMAPEByTest(int fid, int cid, int tid)
        {
            string sql = " SELECT dbo.ForecastedResult.DurationDateTime,dbo.ForecastedResult.ForecastValue,dbo.ForecastedResult.HistoricalValue, ";
            sql += " (dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue) as MapeValue, ";
            sql += " isnull(((dbo.ForecastedResult.HistoricalValue-dbo.ForecastedResult.ForecastValue)/nullif(dbo.ForecastedResult.HistoricalValue,0))*100,100) as MapePercentage ";
            sql += " FROM dbo.ForecastedResult ";
            sql += " where  dbo.ForecastedResult.ForecastId=:finfoid and  (dbo.ForecastedResult.CategoryId =:catid) and (dbo.ForecastedResult.TestId =:testid) and dbo.ForecastedResult.IsHistory=:ishistory ";
            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
            AddScalar("DurationDateTime", NHibernateUtil.DateTime).
            AddScalar("ForecastValue", NHibernateUtil.Decimal).
            AddScalar("HistoricalValue", NHibernateUtil.Decimal).
            AddScalar("MapeValue", NHibernateUtil.Decimal).
            AddScalar("MapePercentage", NHibernateUtil.Decimal).
            SetResultTransformer(Transformers.AliasToBean(typeof(MAPEResult)));

            sqlQuery.SetInt32("finfoid", fid);
            sqlQuery.SetInt32("catid", cid);
            sqlQuery.SetInt32("testid", tid);
            sqlQuery.SetBoolean("ishistory", true);


            IList<MAPEResult> result = sqlQuery.List<MAPEResult>();
            return result;
        }

        public IList<MAPEResult> GetMAPESummaryByProduct(int fid)
        {

            string sql = " SELECT dbo.ForecastedResult.ProductId,(select MasterProduct.ProductName from dbo.MasterProduct where dbo.MasterProduct.ProductID=dbo.ForecastedResult.ProductId) as ProductName , ";
            sql += " dbo.ForecastedResult.DurationDateTime,sum(dbo.ForecastedResult.ForecastValue) as ForecastValue, ";
            sql += " sum(dbo.ForecastedResult.HistoricalValue) as HistoricalValue, ";
            sql += " (sum(dbo.ForecastedResult.HistoricalValue)-sum(dbo.ForecastedResult.ForecastValue)) as MapeValue, ";
            sql += " isnull(((sum(dbo.ForecastedResult.HistoricalValue)-sum(dbo.ForecastedResult.ForecastValue))/nullif(sum(dbo.ForecastedResult.HistoricalValue),0))*100,100) as MapePercentage ";
            sql += " FROM dbo.ForecastedResult where dbo.ForecastedResult.ForecastId=:finfoid and dbo.ForecastedResult.IsHistory=1 ";
            sql += " group by dbo.ForecastedResult.ProductId,dbo.ForecastedResult.DurationDateTime ";
            sql += " order by dbo.ForecastedResult.ProductId,dbo.ForecastedResult.DurationDateTime asc ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                 AddScalar("ProductId", NHibernateUtil.Int32).
                AddScalar("ProductName",NHibernateUtil.String).
            AddScalar("DurationDateTime", NHibernateUtil.DateTime).
            AddScalar("ForecastValue", NHibernateUtil.Decimal).
            AddScalar("HistoricalValue", NHibernateUtil.Decimal).
            AddScalar("MapeValue", NHibernateUtil.Decimal).
            AddScalar("MapePercentage", NHibernateUtil.Decimal).
            
            SetResultTransformer(Transformers.AliasToBean(typeof(MAPEResult)));

            sqlQuery.SetInt32("finfoid", fid);
           


            IList<MAPEResult> result = sqlQuery.List<MAPEResult>();
            return result;
        }

        public IList<MAPEResult> GetMAPESummaryByTest(int fid)
        {

            string sql = " SELECT dbo.ForecastedResult.TestId,(select  Test.TestName from dbo.Test where dbo.Test.TestID=dbo.ForecastedResult.TestId) as TestName , ";
            sql += " dbo.ForecastedResult.DurationDateTime,sum(dbo.ForecastedResult.ForecastValue) as ForecastValue, ";
            sql += " sum(dbo.ForecastedResult.HistoricalValue) as HistoricalValue, ";
            sql += " (sum(dbo.ForecastedResult.HistoricalValue)-sum(dbo.ForecastedResult.ForecastValue)) as MapeValue, ";
            sql += " isnull(((sum(dbo.ForecastedResult.HistoricalValue)-sum(dbo.ForecastedResult.ForecastValue))/nullif(sum(dbo.ForecastedResult.HistoricalValue),0))*100,100) as MapePercentage ";
            sql += " FROM dbo.ForecastedResult where dbo.ForecastedResult.ForecastId=:finfoid and dbo.ForecastedResult.IsHistory=1 ";
            sql += " group by dbo.ForecastedResult.TestId,dbo.ForecastedResult.DurationDateTime ";
            sql += " order by dbo.ForecastedResult.TestId,dbo.ForecastedResult.DurationDateTime asc ";

            ISession session = NHibernateHelper.OpenSession();
            IQuery sqlQuery = session.CreateSQLQuery(sql).
                 AddScalar("TestId", NHibernateUtil.Int32).
            AddScalar("DurationDateTime", NHibernateUtil.DateTime).
            AddScalar("ForecastValue", NHibernateUtil.Decimal).
            AddScalar("HistoricalValue", NHibernateUtil.Decimal).
            AddScalar("MapeValue", NHibernateUtil.Decimal).
            AddScalar("MapePercentage", NHibernateUtil.Decimal).
            AddScalar("TestName", NHibernateUtil.String).
            SetResultTransformer(Transformers.AliasToBean(typeof(MAPEResult)));

            sqlQuery.SetInt32("finfoid", fid);
           

            IList<MAPEResult> result = sqlQuery.List<MAPEResult>();
            return result;
        }
       
        public IList GetUniqueFType(int ForecastId,int ProductType)
        {
            
            string sql = "";
            if (ProductType != 0)
            {
                sql = string.Format("SELECT DISTINCT dbo.ProductType.TypeName , dbo.ProductType.TypeID FROM dbo.ProductType INNER JOIN " +
                    "dbo.ForecastedResult ON dbo.ProductType.TypeID = dbo.ForecastedResult.ProductTypeId " +
                    "WHERE dbo.ForecastedResult.ForecastId ={0}", ForecastId);

                ISession session = NHibernateHelper.OpenSession();
                return session.CreateSQLQuery(sql).
                                 AddScalar("TypeName", NHibernateUtil.String).
                                 AddScalar("TypeId", NHibernateUtil.Int32).List();
            }
            else 
            {
                sql = string.Format("SELECT DISTINCT dbo.TestingArea.AreaName , dbo.Test.TestingAreaID AS TypeId " +
                        "FROM dbo.ForecastedResult INNER JOIN dbo.Test ON dbo.ForecastedResult.TestId = dbo.Test.TestID INNER JOIN " +
                        "dbo.TestingArea ON dbo.Test.TestingAreaID = dbo.TestingArea.TestingAreaID " +
                        "WHERE dbo.ForecastedResult.ForecastId = {0}", ForecastId);
                     ISession session = NHibernateHelper.OpenSession();
                        return session.CreateSQLQuery(sql).
                                 AddScalar("AreaName", NHibernateUtil.String).
                                 AddScalar("TypeId", NHibernateUtil.Int32).List();
            }
             
        }

    }
}
