
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
    public class NHForecastCategoryInstrumentDao : NHibernateDao<ForecastCategoryInstrument>, IForecastCategoryInstrumentDao
    {
        public IList<ForecastCategoryInstrument> GetFCInstrumentByFinfoId(int fid)
        {
           
            string hql = "from ForecastCategoryInstrument p where p.ForecastId = :fid" ;

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("fid", fid);

            return q.List<ForecastCategoryInstrument>();
        }

        public ForecastCategoryInstrument GetFCInstrumentById(int id)
        {
          
            string hql = "from ForecastCategoryInstrument p where p.Id = :id";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("id", id);
            object obj = q.UniqueResult();
            if (obj != null)
                return (ForecastCategoryInstrument)obj;
            return null;
        }






        public ForecastCategoryInstrument GetFCInstrumentByInstrumentId(int iid)
        {

            string hql = "from ForecastCategoryInstrument p where pInstrument.Id = :iid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("iid", iid);
            object obj = q.UniqueResult();
            if (obj != null)
                return (ForecastCategoryInstrument)obj;
            return null;
        }
    }
}
