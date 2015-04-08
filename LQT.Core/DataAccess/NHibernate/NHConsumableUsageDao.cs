
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
using NHibernate.Transform;
using System.Collections;

namespace LQT.Core.DataAccess.NHibernate
{

    public class NHConsumableUsageDao : NHibernateDao<ConsumableUsage>, IConsumableUsageDao
    {

        public IList<ConsumableUsage> GetAllUsageByConsumableId(int consumableid)
        {
            string hql = "from ConsumableUsage cu where cu.Consumable.Id = :cid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("cid", consumableid);

            return q.List<ConsumableUsage>();
        
        }

        public IList<ConsumableUsage> GetConsumableUsageByTestId(int testId)
        {

            string hql = "from ConsumableUsage cu where cu.MasterConsumable.Test.Id = :tid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("tid", testId);

            return q.List<ConsumableUsage>();


        }


    }
}
