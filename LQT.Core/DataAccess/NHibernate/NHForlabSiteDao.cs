
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
using LQT.Core.Domain;
using LQT.Core.DataAccess.Interface;
using LQT.Core.Util;

using NHibernate;
using NHibernate.Transform;
using System.Collections;


using System.Linq;
using System.Text.RegularExpressions;



namespace LQT.Core.DataAccess.NHibernate
{
    public class NHForlabSiteDao : NHibernateDao<ForlabSite>, IForlabSiteDao
    {
        public IList<ForlabSite> GetAllSiteByRegionId(int regionid)
        {
            string hql = "from ForlabSite s where s.Region.Id = :rid";

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetInt32("rid", regionid);

            return q.List<ForlabSite>();
        }

        public ForlabSite GetSiteByName(string sname, int regionid)
        {
            string hql = "from ForlabSite r where r.SiteName = :sname and r.Region.Id = :rid";
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("sname", sname);
            q.SetInt32("rid", regionid);
            object obj = q.UniqueResult();
            if (obj != null)
                return (ForlabSite)obj;
            return null;
        }

        public IList<ForlabSite> GetReferingSiteByPlatform(string platform)
        {
            //string sql = string.Format(" SELECT * from ForlabSite where {0}RefSite <> 0 ",  platform);

            //ISession session = NHibernateHelper.OpenSession();
            //IList<ForlabSite> result = session.CreateSQLQuery(sql).List<ForlabSite>();
            //session.Flush();
            //return result;
            string forcd4 = System.Text.RegularExpressions.Regex.Replace("Flow Cytometry", @"\s+", "");
            string forchemistry = System.Text.RegularExpressions.Regex.Replace("Bio Chemistry", @"\s+", "");
            string forchemistry2 = System.Text.RegularExpressions.Regex.Replace("Clinical Chemistry", @"\s+", "");
            string forviralload = System.Text.RegularExpressions.Regex.Replace("PCR", @"\s+", "");

            if (System.Text.RegularExpressions.Regex.Replace(platform, @"\s+", "").ToLower() == forcd4.ToLower())
                platform = "CD4";
            if (System.Text.RegularExpressions.Regex.Replace(platform, @"\s+", "").ToLower() == forchemistry.ToLower())
                platform = "Chemistry";
            if (System.Text.RegularExpressions.Regex.Replace(platform, @"\s+", "").ToLower() == forchemistry2.ToLower())
                platform = "Chemistry";
            if (System.Text.RegularExpressions.Regex.Replace(platform, @"\s+", "").ToLower() == forviralload.ToLower())
                platform = "Viral Load";

            string hql = string.Format("from ForlabSite s where s.{0}RefSite <> 0 ", platform);

            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);

            return q.List<ForlabSite>();
        }

        public IList<ForlabSite> GetReferingSiteByPlatform(int siteId, int platform)
        {
            string sql = string.Format(" SELECT SiteId,RefSiteId,Platform from SiteReferal where RefSiteId={0} and Platform={1}", siteId, platform);

            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(sql).
                              AddScalar("SiteId", NHibernateUtil.Int32).List();
            session.Flush();

            IList<ForlabSite> ReferingSites = new List<ForlabSite>();
            foreach (int i in result)
            {
                ForlabSite s = DataRepository.GetSiteById(i);
                ReferingSites.Add(s);
            }

            return ReferingSites;
        }

        public bool GetRefSiteBySiteId(int siteId, string platform)
        {
            string sql = string.Format(" SELECT count(SiteId) as scount from Site where {0}RefSite = {1}", platform, siteId);

            ISession session = NHibernateHelper.OpenSession();
            object obj = session.CreateSQLQuery(sql).AddScalar("scount", NHibernateUtil.Int32).UniqueResult();

            return obj != null ? Convert.ToInt32(obj) > 0 : false;
        }

        public static string RemoveWhitespace(string input)
        {
            // return new string(input.ToCharArray()
            //   .Where(c => !Char.IsWhiteSpace(c))
            //   .ToArray());
            return Regex.Replace(input, @"\s+", "");
        }

        public IList<ForlabSite> GetAllSiteByRegionandPlatform(int regionid, string platform)
        {
            string sql = "";
            platform = System.Text.RegularExpressions.Regex.Replace(platform, @"\s+", "").ToLower();
            
            string forcd4 = System.Text.RegularExpressions.Regex.Replace("Flow Cytometry", @"\s+", "");
            string forchemistry = System.Text.RegularExpressions.Regex.Replace("Bio Chemistry", @"\s+", "");
            string forviralload = System.Text.RegularExpressions.Regex.Replace("PCR", @"\s+", "");
            string forchemistry2 = System.Text.RegularExpressions.Regex.Replace("Clinical Chemistry", @"\s+", "");
            if (regionid != -1)
            {

                sql = string.Format(" SELECT DISTINCT Site.* FROM TestingArea INNER JOIN Instrument ON " +
                    "TestingArea.TestingAreaID = Instrument.TestingAreaID INNER JOIN SiteInstrument ON " +
                    "SiteInstrument.InstrumentID = Instrument.InstrumentID INNER JOIN Site ON " +
                    "SiteInstrument.SiteID = Site.SiteID WHERE ");
                if (platform == RemoveWhitespace("CD4").ToLower() || platform == forcd4)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{2}%'  AND Site.RegionID = {0}", regionid, platform, forcd4);
                else if (platform == RemoveWhitespace("Chemistry").ToLower() || platform == forchemistry)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{2}%'  AND Site.RegionID = {0}", regionid, platform, forchemistry);
                else if (platform == RemoveWhitespace("Chemistry").ToLower() || platform == forchemistry2)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{2}%'  AND Site.RegionID = {0}", regionid, platform, forchemistry2);
                else if (platform == RemoveWhitespace("Viral Load").ToLower() || platform == forviralload)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{2}%'  AND Site.RegionID = {0}", regionid, platform, forviralload);
                else
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' AND Site.RegionID = {0}", regionid, platform);
            }
            else
            {
                sql = string.Format(" SELECT DISTINCT Site.* FROM TestingArea INNER JOIN Instrument ON " +
                 "TestingArea.TestingAreaID = Instrument.TestingAreaID INNER JOIN SiteInstrument ON " +
                 "SiteInstrument.InstrumentID = Instrument.InstrumentID INNER JOIN Site ON SiteInstrument.SiteID = Site.SiteID WHERE ");

                if (platform == RemoveWhitespace("CD4").ToLower() || platform == forcd4)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{0}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' ", platform, forcd4);
                else if (platform == RemoveWhitespace("Chemistry").ToLower() || platform == forchemistry)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{0}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' ", platform, forchemistry);
                else if (platform == RemoveWhitespace("Chemistry").ToLower() || platform == forchemistry2)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{0}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' ", platform, forchemistry2);
                else if (platform == RemoveWhitespace("Viral Load").ToLower() || platform == forviralload)
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{0}%' OR REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{1}%' ", platform, forviralload);
                else
                    sql += string.Format(" REPLACE(dbo.TestingArea.AreaName, ' ', '') Like'%{0}%' ", platform);


            }

            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(sql).
                              AddScalar("SiteId", NHibernateUtil.Int32).List();

            IList<ForlabSite> Sites = new List<ForlabSite>();
            foreach (int i in result)
            {
                ForlabSite s = DataRepository.GetSiteById(i);
                Sites.Add(s);
            }

            return Sites;
        }

        public void deleteReferingSite(int siteId, string platform)
        {
            string forcd4 = System.Text.RegularExpressions.Regex.Replace("Flow Cytometry", @"\s+", "");
            string forchemistry = System.Text.RegularExpressions.Regex.Replace("Bio Chemistry", @"\s+", "");
            string forviralload = System.Text.RegularExpressions.Regex.Replace("PCR", @"\s+", "");
            string forchemistry2 = System.Text.RegularExpressions.Regex.Replace("Clinical Chemistry", @"\s+", "");
            string sql = "";
            if (platform == "CD4" || platform == "FlowCytometry" || platform==forcd4)
            {
                sql = string.Format(" update site set CD4RefSite ='0' FROM Site WHERE SiteID={0}", siteId);
            }
            else if (platform == "Chemistry"||platform==forchemistry )
            {
                sql = string.Format(" update site set ChemistryRefSite ='0' FROM Site WHERE SiteID={0}", siteId);
            }
            else if (platform == "Chemistry" || platform == forchemistry2)
            {
                sql = string.Format(" update site set ChemistryRefSite ='0' FROM Site WHERE SiteID={0}", siteId);
            }
            else if (platform == "Hematology")
            {
                sql = string.Format(" update site set HematologyRefSite ='0' FROM Site WHERE SiteID={0}", siteId);
            }
            else if (platform == "Other")
            {
                sql = string.Format(" update site set OtherRefSite ='0' FROM Site WHERE SiteID={0}", siteId);
            }
            else if (platform == "ViralLoad"|| platform==forviralload)
            {
                sql = string.Format(" update site set ViralLoadRefSite ='0' FROM Site WHERE SiteID={0}", siteId);
            }


            ISession session = NHibernateHelper.OpenSession();
            IList result = session.CreateSQLQuery(sql).
                              AddScalar("SiteId", NHibernateUtil.Int32).List();

        }

        public ForlabSite GetSiteByName(string sname)
        {
            string hql = "from ForlabSite r where r.SiteName = :sname";
            ISession session = NHibernateHelper.OpenSession();
            IQuery q = session.CreateQuery(hql);
            q.SetString("sname", sname);

            object obj = q.UniqueResult();
            if (obj != null)
                return (ForlabSite)obj;
            return null;
        }

        public IList<int> GetListOfReferedSites(int siteId, string platform)
        {
            string sql = string.Format(" SELECT s.SiteId as sid from Site as s where s.{0}RefSite = {1}", platform, siteId);

            ISession session = NHibernateHelper.OpenSession();
            return session.CreateSQLQuery(sql)
                .AddScalar("sid", NHibernateUtil.Int32)
                .List<int>();
        }

        public IList<int> GetListOfSiteInstruments(int instrumentid)
        {
            string sql = string.Format("SELECT dbo.SiteInstrument.ID FROM dbo.SiteInstrument  where dbo.SiteInstrument.InstrumentID = {0}", instrumentid);

            ISession session = NHibernateHelper.OpenSession();
            return session.CreateSQLQuery(sql)
                .AddScalar("ID", NHibernateUtil.Int32)
                .List<int>();
        }


    }
}
