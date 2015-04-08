
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
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using System.Collections;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForecastSiteDao : NHibernateDao<ForecastSite>, IForecastSiteDao
    {
        public IList<ForlabSite> GetFSite(int fid)
        {

            string sql = string.Format("SELECT * FROM Site INNER JOIN ForecastSite ON ForecastSite.SiteId =Site.SiteID" 
                        +" WHERE (dbo.ForecastSite.ForecastInfoId ={0})",fid);

            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(sql).
                              AddScalar("SiteID", NHibernateUtil.Int32).List();

            IList<ForlabSite> Sites = new List<ForlabSite>();
            foreach (int i in result)
            {
                ForlabSite s = DataRepository.GetSiteById(i);
                Sites.Add(s);
            }

            return Sites;

           
        }

    }
}
