
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

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHARTSiteDao: NHibernateDao<ARTSite>, IARTSiteDao
    {
        private ITransaction _tansaction;
        private ISession _session;
        
        public void OpenBatchTransaction()
        {
            _session = NHibernateHelper.OpenSession();
            _tansaction = _session.BeginTransaction();
        }

        public void CommitBatchTransaction()
        {
            _session.Flush();
            _tansaction.Commit();
            _session.Close();
            _session = null;
            _tansaction = null;
        }

        public void RolebackBatchTransaction()
        {
            _tansaction.Rollback();
            _session = null;
            _tansaction = null;
        }
        
        public void BatchSave(ARTSite artsite)
        {
            _session.SaveOrUpdate(artsite);
        }

        public void BatchDelete(ARTSite artsite)
        {
            _session.Delete(artsite);
        }

        public IList<ARTSite> GetAllARTSite(int forecastid)
        {
            string sql = "from ARTSite s where s.MorbidityCategory.MorbidityForecast.Id = :forecastid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(sql);
            q.SetInt32("forecastid", forecastid);

            return q.List<ARTSite>();
        }
    }
}
