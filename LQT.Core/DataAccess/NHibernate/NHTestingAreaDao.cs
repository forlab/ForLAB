
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
    public class NHTestingAreaDao : NHibernateDao<TestingArea>, ITestingAreaDao
    {
       
        public TestingArea GetTestingAreaByName(string name)
        {
            string hql = "from TestingArea a where a.AreaName = :aname";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("aname", name);
            
            IList<TestingArea> result = q.List<TestingArea>();

            if (result.Count > 0)
                return result[0];

            return null;
        }

        public IList<TestingArea> GetTestingAreaByDemography(Boolean inDemo)
        {
            string hql = "from TestingArea a where a.UseInDemography = :inDemo";
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetBoolean("inDemo", inDemo);
            IList<TestingArea> result = q.List<TestingArea>();

            return result;
        }

        public IList<Instrument> GetDistinctInstrumentByCategory(string category)
        {
            string hql = "from Instrument I where I.TestingArea.Id = from TestingArea a where a.Category = :category";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("category", category);

            IList<Instrument> result = q.List<Instrument>();

            return result;
        }
    }
}
