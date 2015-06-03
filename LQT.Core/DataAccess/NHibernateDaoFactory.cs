
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
using LQT.Core.DataAccess.Interface;
using LQT.Core.DataAccess.NHibernate;

namespace LQT.Core.DataAccess
{
    public class NHibernateDaoFactory : DaoFactory
	{
		public NHibernateDaoFactory()
		{
		}

        public override ITestDao CreateTestDao()
        {
            return new NHTestDao();
        }

        public override ITestingAreaDao CreateTestingAreaDao()
        {
            return new NHTestingAreaDao();
        }

        public override ITestingGroupDao CreateTestingGroupDao()
        {
            return new NHTestingGroupDao();
        }

        public override IForlabRegionDao CreateRegionDao()
        {
            return new NHForlabRegionDao();
        }

        public override IForlabSiteDao CreateSiteDao()
        {
            return new NHForlabSiteDao();
        }

        public override IInstrumentDao CreateInstrumentDao()
        {
            return new NHInstrumentDao();
        }

        public override IProductDao CreateProductDao()
        {
            return new NHProductDao();
        }

        public override IProductTypeDao CreateProductTypeDao()
        {
            return new NHProductTypeDao();
        }

        public override IForecastInfoDao CreateForecastInfoDao()
        {
            return new NHForecastInfoDao();
        }

        public override IForecastCategoryDao CreateForecastCategoryDao()
        {
            return new NHForecastCategoryDao();
        }

        public override IForecastSiteDao CreateForecastSiteDao()
        {
            return new NHForecastSiteDao();
        }

        public override IForecastSiteProductDao CreateForecastSiteProductDao()
        {
            return new NHForecastSiteProductDao();
        }

        public override IForecastCategoryProductDao CreateForecastCategoryProductDao()
        {
            return new NHForecastCategoryProductDao();
        }
        public override IForecastSiteTestDao CreateForecastSiteTestDao()
        {
            return new NHForecastSiteTestDao();
        }

        public override IForecastCategoryTestDao CreateForecastCategoryTestDao()
        {
            return new NHForecastCategoryTestDao();
        }
        public override IFTableDao CreateFTableDao()
        {
            return new NHFTableDao();
        }
        public override ISiteCategoryDao CreateSiteCategoryDao()
        {
            return new NHSiteCategoryDao();
        }
        public override IForecastedResultDao CreateForecastedResultDao()
        {
            return new NHForecastedResultDao();
        }

        public override IMorbidityForecastDao CreateMorbidityForecastDao()
        {
            return new NHMorbidityForecastDao();
        }

                
        public override IARTSiteDao CreateARTSiteDao()
        {
            return new NHARTSiteDao();
        }
        public override IMorbiditySupplyProcurementDao CreateMorbiditySupplyProcurementDao()
        {
            return new NHMorbiditySupplyProcurementDao();
        }

        public override IMorbiditySupplyForecastDao CreateMorbiditySupplyForecastDao()
        {
            return new NHMorbiditySupplyForecastDao();
        }

        public override IProtocolDao CreateProtocolDao()
        {
            return new NHProtocolDao();
        }

        public override IProtocolPanelDao CreateProtocolPanelDao()
        {
            return new NHProtocolPanelDao();
        }

        public override IPatientsNoofTestDao CreatePatientsNoofTestDao()
        {
            return new NHPatientsNoofTestDao();
        }

        public override IHIVRapidNumberofTestDao CreateHIVRapidNumberofTestDao()
        {
            return new NHHIVRapidNumberofTestDao();
        }

        public override IHemaandViralNumberofTestDao CreateHemaandViralNumberofTestDao()
        {
            return new NHHemaandViralNumberofTestDao();
        }

        public override ICD4TestNumberDao CreateCD4TestNumberDao()
        {
            return new NHCD4TestNumberDao();
        }

        public override IChemandOtherNumberofTestDao CreateChemandOtherNumberofTestDao()
        {
            return new NHChemandOtherNumberofTestDao();
        }

        public override IForlabParameterDao CreateForlabParameterDao()
        {
            return new NHForlabParameterDao();
        }

        public override IInventoryAssumptionDao CreateInventoryAssumptionDao()
        {
            return new NHInventoryAssumptionDao();
        }
        public override IRapidTestSpecDao CreateRapidTestSpecDao()
        {
            return new NHRapidTestSpecDao();
        }

        public override IMorbidityTestDao CreateMorbidityTestDao()
        {
            return new NHMorbidityTestDao();
        }

        public override IQuantifyMenuDao CreateQuantifyMenuDao()
        {
            return new NHQuantifyMenuDao();
        }
        public override IQuantificationMetricDao CreateQuantificationMetricDao()
        {
            return new NHQuantificationMetricDao();
        }

        public override IForecastCategoryInstrumentDao CreateForecastCategoryInstrumentDao()
        {
            return new NHForecastCategoryInstrumentDao();
        }

    }
}
