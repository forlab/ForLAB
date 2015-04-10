
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
