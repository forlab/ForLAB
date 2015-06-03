
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
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using NHibernate.Expression;

namespace LQT.Core.DataAccess.NHibernate
{
    public class NHibernateDao<T> : IDao<T>
    {

        public void SaveOrUpdate(T t)
        {
            ISession session = NHibernateHelper.OpenSession();
            using (ITransaction trans = session.BeginTransaction())
            {
                session.SaveOrUpdate(t);
                session.Flush();
                trans.Commit();
            }
            //session.Flush();
        }

        public void Delete(T t)
        {
            ISession session = NHibernateHelper.OpenSession();

            using (ITransaction trans = session.BeginTransaction())
            {
                session.Delete(t);
                session.Flush();
                trans.Commit();
            }
            
        }

        public IList<T> GetAll()
        {
            return NHibernateHelper.OpenSession().CreateCriteria(typeof(T)).List<T>();
            //return GetByCriteria(null);
        }

        public IList<T> GetByCriteria(params string[] sortProperties)
        {
            ISession session = NHibernateHelper.OpenSession();
            ICriteria crit = session.CreateCriteria(typeof(T));
            if (sortProperties != null)
            {
                foreach (string sortProperty in sortProperties)
                {
                    crit.AddOrder(Order.Asc(sortProperty));
                }
            }

            return crit.List<T>();
        }

        public T GetById(int id)
        {
            ISession session = NHibernateHelper.OpenSession();
                return (T)session.Get(typeof(T), id);
            
        }

        public T Load(int id)
        {
            ISession session = NHibernateHelper.OpenSession();
                return (T)session.Load(typeof(T), id);
        }

        public List<T> ListUsingQuery(string hql, params object[] args)
        {
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            
            
            return (List<T>)q.List<T>();
        }

        public IList<T> ListUsingSQLQuery(string hql)
        {
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateSQLQuery(hql);

            return q.List<T>();
        }
    }
}
