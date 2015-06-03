
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
    public class NHTestingGroupDao : NHibernateDao<TestingGroup>, ITestingGroupDao
    {       

        public TestingGroup GetTestingGroupByName(int areaid, string name)
        {
            TestingGroup t = new TestingGroup();
            
            string hql = "from TestingGroup g where g.TestingArea.Id = :aid and g.GroupName = :gname";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("gname", name);
            q.SetInt32("aid", areaid);

            IList<TestingGroup> result = q.List<TestingGroup>();

            if (result.Count > 0)
                return result[0];

            return null;
        }
                
    }
}
