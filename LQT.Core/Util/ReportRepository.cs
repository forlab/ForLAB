
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
using System.Collections;
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.DataAccess;
using LQT.Core.DataAccess.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace LQT.Core.Util
{
    public class ReportRepository
    {
        public static DataSet _rDataSet;
        //public static SqlParameterCollection Sqlparams;

        public static void AddItem(IList list, Type type, string valueMember,string displayMember, string displayText)
        {
            Object obj = Activator.CreateInstance(type);
            PropertyInfo displayProperty = type.GetProperty(displayMember);
            displayProperty.SetValue(obj, displayText, null);
            PropertyInfo valueProperty = type.GetProperty(valueMember);
            valueProperty.SetValue(obj, -1, null);
            list.Insert(0, obj);
        }

        public static DataSet GetDataSet(SqlConnection cn, List<SqlParameter> Sqlparams, string spName)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 300000;
            AddParameters(cmd, Sqlparams);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, spName);
            return _rDataSet;
        }

        public static void AddParameters(SqlCommand cmd,List<SqlParameter> Sqlparams)
        {

            foreach (SqlParameter param in Sqlparams)
            {
               
                cmd.Parameters.Add(param);
            }
        }
    }
}
