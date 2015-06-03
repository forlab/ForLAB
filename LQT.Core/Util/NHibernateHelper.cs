
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
