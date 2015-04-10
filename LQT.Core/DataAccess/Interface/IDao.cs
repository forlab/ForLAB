
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


namespace LQT.Core.DataAccess.Interface
{
    public interface IDao<T>
    {
        void SaveOrUpdate(T t);
        void Delete(T t);
        IList<T> GetAll();
        T GetById(int id);
        T Load(int id);
        List<T> ListUsingQuery(string hql, params object[] args);
        IList<T> ListUsingSQLQuery(string hql);
    }
}
