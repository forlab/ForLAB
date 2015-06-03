
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
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;


namespace LQT.Core.DataAccess.NHibernate
{
    public class NHQuantifyMenuDao : NHibernateDao<QuantifyMenu>, IQuantifyMenuDao
    {       
       
        public IList<QuantifyMenu> GetAllQuantifyMenuByClass(string classofTest)
        {
            string hql = "from QuantifyMenu m where m.ClassOfTest = :ctest";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("ctest", classofTest);

            return q.List<QuantifyMenu>();
        }
        
        public IList<QuantifyMenu> GetGeneralQuantifyMenuByClass(string classofTest)
        {
            string hql = "from QuantifyMenu m where m.ClassOfTest = :ctest and m.TestType = :ttype";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("ctest", classofTest);
            q.SetString("ttype", TestTypeEnum.General.ToString());

            return q.List<QuantifyMenu>();
        }
        public IList<QuantifyMenu> GetAllGeneralQuantifyMenus()
        {
            string hql = "from QuantifyMenu m where m.TestType = :ttype";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("ttype", TestTypeEnum.General.ToString());

            return q.List<QuantifyMenu>();
        }
        public IList<QuantifyMenu> GetAllQuantifyMenuByInstrument(int instrumentId)
        {
            string hql = "from QuantifyMenu m where m.InstrumentId = :instid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("instid", instrumentId);

            return q.List<QuantifyMenu>();
        }

        public QuantifyMenu GetQuantifyMenuByProductId(int productId)
        {
            string hql = "from QuantifyMenu m where m.ProductId = :proid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("proid", productId);

            return q.UniqueResult<QuantifyMenu>();
        }

    }
}
