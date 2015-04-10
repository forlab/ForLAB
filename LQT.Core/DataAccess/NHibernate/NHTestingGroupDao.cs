
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
