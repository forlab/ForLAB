
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
using NHibernate;
using NHibernate.Cfg;

namespace LQT.Core.Util
{
    public class NHibernateHelper
    {
        static ISessionFactory _nhibernateFactory = null;
        static ISession _session = null;
        static Configuration _nhibernateConfiguration = null;

        static NHibernateHelper()
        {
            RegisterCoreClasses();
        }
        
        private static void RegisterCoreClasses()
        {
            Configuration cfg = new Configuration(); //.Configure();

            cfg.Properties.Add(NHibernate.Cfg.Environment.Dialect, typeof(NHibernate.Dialect.MsSql2005Dialect).AssemblyQualifiedName);
            cfg.Properties.Add(NHibernate.Cfg.Environment.ConnectionDriver, typeof(NHibernate.Driver.SqlClientDriver).AssemblyQualifiedName);
            cfg.Properties.Add(NHibernate.Cfg.Environment.ConnectionProvider, typeof(NHibernate.Connection.DriverConnectionProvider).AssemblyQualifiedName);

            cfg.Properties.Add(NHibernate.Cfg.Environment.ConnectionString, GetConnectionString());
                //String.Format(@"Data Source={0};Database={1};User ID={2};Password={3};", app.Server, app.Database, app.Login, app.Password));
            //cfg.Properties.Add(NHibernate.Cfg.Environment.ConnectionString, @"Data Source=(local);Database=LQT;User ID=Ruser;Password=password;");

            _nhibernateConfiguration = cfg.AddAssembly(typeof(NHibernateHelper).Assembly);
            _nhibernateFactory = _nhibernateConfiguration.BuildSessionFactory();
            //_session = _nhibernateFactory.OpenSession();
        }

        private static string GetConnectionString()
        {
            if (AppSettings.IntegratedSecurity)
                return String.Format("database={0};server={1};Persist Security Info=False;Integrated Security=SSPI", AppSettings.DatabaseName, AppSettings.DatabaseServerName);
            else
                return String.Format("user id={0};password={1};data source={2};persist security info=False;initial catalog={3}", AppSettings.DatabaseLoginName, AppSettings.DatabasePassword, AppSettings.DatabaseServerName, AppSettings.DatabaseName);
        }

        public static ISessionFactory GetNHibernateFactory()
        {
            return _nhibernateFactory;
        }

        public static ISession OpenSession()
        {
            if (_session == null || !_session.IsOpen)
            {
                _session = _nhibernateFactory.OpenSession();
                _session.FlushMode = FlushMode.Never;
            }

            return _session;
        }

        public static void FlushSession()
        {
            _session.Flush();
        }

        public static void CloseSession()
        {
            _session.Close();
        }

    }
}
