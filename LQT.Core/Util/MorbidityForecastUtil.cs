
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
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

using LQT.Core.Domain;
using System.Data.OleDb;
using System.ComponentModel;
using System.Linq;
using NHibernate;
//using System.Transactions;

namespace LQT.Core.Util
{
    public class MorbidityForecastUtil
    {
        public delegate void SaveCalculatedMorbidityOutPutOnSite(int counter, PerformMorbidityCalculationArgs args);
        public static event SaveCalculatedMorbidityOutPutOnSite OnSaveCalculatedMorbidityEvent;

        public static void SaveMorbidityForecastOutput(IDictionary<int, ArtSiteCalculated> artsiteCalculated)
        {
            ISession session = NHibernateHelper.OpenSession();
            int count = 1;
            using (ITransaction trans = session.BeginTransaction())
            {
                foreach (ArtSiteCalculated s in artsiteCalculated.Values)
                {                   
                  if (OnSaveCalculatedMorbidityEvent != null)
                    {
                        OnSaveCalculatedMorbidityEvent(count, new PerformMorbidityCalculationArgs() { ArgumentType = 3, SiteName = s.SiteName });
                    }  
                    session.SaveOrUpdate(s.PatinetNoOfTest);
                    session.SaveOrUpdate(s.RapidNumberofTest);
                    session.SaveOrUpdate(s.CD4TestNumber);
                    session.SaveOrUpdate(s.ViralLodTestNumber);
                    session.SaveOrUpdate(s.HematologyTestNumber);
                    SaveChemistryTestNoForecast(s.ChemistryTestNumber,session);
                    SaveChemistryTestNoForecast(s.OtherTestNumber, session);
                    SaveMorbiditySupplyForecast(s.TestReagents, session);
                    
                    
                    count++;
                }
                session.Flush();
                trans.Commit();
            }
        }

        private static void SaveMorbiditySupplyForecast(IList<MorbiditySupplyForecast> supplys, ISession session)
        {
            foreach (MorbiditySupplyForecast supply in supplys)
            {
                session.SaveOrUpdate(supply);
            }
        }

        private static void SaveChemistryTestNoForecast(IList<ChemandOtherNumberofTest> chemTestNo, ISession session)
        {
            foreach (ChemandOtherNumberofTest supply in chemTestNo)
            {
                session.SaveOrUpdate(supply);
            }
        }



        public static void DeleteMorbidityForecast(int ForecastID)
        {
            string[] sql = {String.Format(" FROM CD4TestNumber where ForecastId={0}  ",ForecastID),
            String.Format(" FROM ChemandOtherNumberofTest where ForecastId={0} ", ForecastID),
            String.Format(" FROM HemaandViralNumberofTest where ForecastId={0} ", ForecastID),
            String.Format(" FROM HIVRapidNumberofTest where ForecastId={0} ", ForecastID),
            String.Format(" FROM PatientsNoofTest where ForecastId={0} ", ForecastID),
            String.Format(" FROM MorbiditySupplyForecast where MForecastId={0} ", ForecastID),
            String.Format(" FROM MorbiditySupplyProcurement where MForecastId={0} ", ForecastID)};

            ISession session = NHibernateHelper.OpenSession();
            using (ITransaction trans = session.BeginTransaction())
            {
                foreach (String sq in sql)
                {
                    session.Delete(sq);

                }

                session.Flush();
                trans.Commit();
            }
        }
        
    }

    public class PerformMorbidityCalculationArgs
    {
        public int ArgumentType { get; set; }
        public string SiteName { get; set; }
    }

}
