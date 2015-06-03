
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
