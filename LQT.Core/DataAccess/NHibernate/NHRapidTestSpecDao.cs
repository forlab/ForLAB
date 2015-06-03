
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
    public class NHRapidTestSpecDao : NHibernateDao<RapidTestSpec>, IRapidTestSpecDao
    {
        public IList<RapidTestSpec> GetRapidTestSpecByTestGroup(string testgroup)
        {

            string hql = "from RapidTestSpec r where r.TestGroup = :tgroup order by r.ProductOrder asc";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("tgroup", testgroup);

            return q.List<RapidTestSpec>();

        }

    }
}
