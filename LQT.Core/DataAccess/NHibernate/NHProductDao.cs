
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
    public class NHProductDao : NHibernateDao<MasterProduct>, IProductDao
    {
        public IList<MasterProduct> GetAllProductByType(int typeid)
        {  
            string hql = "from MasterProduct p where p.ProductType.Id = :tid";
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("tid", typeid);

            return q.List<MasterProduct>();
        }

        public IList<MasterProduct> GetAllProductByClassOfTest(string classofTest)
        {

            string hql = "from MasterProduct p where p.ProductType.ClassOfTest = :ctest";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("ctest", classofTest);

            return q.List<MasterProduct>();
        }

        public IList<MasterProduct> GetAllProductByClassOfTest(string classofTest, string rapidtestGroup)
        {

            string hql = "from MasterProduct p where p.RapidTestGroup = :tgroup and p.ProductType.ClassOfTest = :ctest";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("tgroup", rapidtestGroup);
            q.SetString("ctest", classofTest);

            return q.List<MasterProduct>();
        }

        public MasterProduct GetProductByName(string pname)
        {
            string hql = "from MasterProduct p where p.ProductName = :pname";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("pname", pname);

            object obj = q.UniqueResult();
            if (obj != null)
                return (MasterProduct)obj;
            return null;
        }

        public decimal GetProductPrice(int proid, DateTime fromdate)
        {
            string sql ="SELECT p1.Price as cprice FROM ProductPrice p1 WHERE p1.FromDate = ";
            sql +="(SELECT MAX(p2.FromDate) FROM ProductPrice p2 WHERE p2.ProductId = ";
            sql += String.Format("p1.ProductId AND p2.FromDate <= {0} AND p2.ProductId = {1})", fromdate, proid);

            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(sql)
                .AddScalar("cprice", NHibernateUtil.Decimal)
                .List();
            if (result != null)
                return (decimal)result[0];
            return 0;
        }

        public int GetTotalCountOfProducts(int typeid)
        {
            if (typeid == 0)
                return GetTotalCountOfProducts();

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery("select count(*) from MasterProduct p where p.ProductType.Id = :tid");
            q.SetInt32("tid", typeid);
            object result = q.UniqueResult();

            return result != null ? Convert.ToInt32(result) : 0;
        }

        private int GetTotalCountOfProducts()
        {
            ISession session = NHibernateHelper.OpenSession();
            object result = session.CreateQuery("select count(*) from MasterProduct").UniqueResult();

            return result != null ? Convert.ToInt32(result) : 0;
        }

        public IList<MasterProduct> GetPagingProducts(int typeId, int firstResult, int maxResult)
        {
            string hql = "from MasterProduct p order by p.ProductName asc";
            if (typeId > 0)
                hql = String.Format("from MasterProduct p where p.ProductType.Id = {0} order by p.ProductName asc", typeId);

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql)
                      .SetFirstResult(firstResult)
                      .SetMaxResults(maxResult);

            return q.List<MasterProduct>();
        }

        public MasterProduct GetProductByTypeandName(string pname,string ptname)
        {
            string hql = "from MasterProduct p where p.ProductName = :pname and p.ProductType.TypeName=:ptname";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("pname", pname);
            q.SetString("ptname", ptname);

            object obj = q.UniqueResult();
            if (obj != null)
                return (MasterProduct)obj;
            return null;
        }
    }
}
