
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
using NHibernate;
using LQT.Core.Util;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHInstrumentDao : NHibernateDao<Instrument>, IInstrumentDao
    {
        public Instrument GetInstrumentByName(string name)
        {
            string hql = "from Instrument i where i.InstrumentName = :iname";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("iname", name);

            IList<Instrument> result = q.List<Instrument>();

            if (result.Count > 0)
                return result[0];

            return null;
        }

        public Instrument GetInstrumentByNameAndTestingArea(string name, int testingAreaId)
        {
            string hql = "from Instrument i where i.InstrumentName = :iname and i.TestingArea.Id = :testingAreaId";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("iname", name);
            q.SetInt32("testingAreaId", testingAreaId);

            IList<Instrument> result = q.List<Instrument>();

            if (result.Count > 0)
                return result[0];

            return null;
        }

        public IList<Instrument> GetListOfInstrumentByTestingArea(int testingAreaId)
        {
            string hql = "from Instrument i where i.TestingArea.Id = :testingAreaId";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("testingAreaId", testingAreaId);

            return q.List<Instrument>();
        }

        public IList<Instrument> GetListOfInstrumentByTestingArea(string classofTest)
        {
            string hql = "from Instrument i where i.TestingArea.Category = :category";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("category", classofTest);

            return q.List<Instrument>();
        }
    }
}
