
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
