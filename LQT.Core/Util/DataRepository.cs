
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

namespace LQT.Core.Util
{
    public class DataRepository
    {
        public static event EventHandler OnFResultSaved;
        public static event EventHandler OnFResultDeleted;

        public DataRepository()
        {
        }

        public static void CloseSession()
        {
            NHibernateHelper.CloseSession();
        }

        public static void FlushSession()
        {
            NHibernateHelper.FlushSession();
        }

        #region Location...........................................................................
        
        public static IList<ForlabRegion> GetAllRegion()
        {
            return DaoFactory.GetDaoFactory().CreateRegionDao().GetAll();
        }

        public static ForlabRegion  GetRegionById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateRegionDao().GetById(id);
        }

        public static void SaveOrUpdateRegion(ForlabRegion region)
        {
            DaoFactory.GetDaoFactory().CreateRegionDao().SaveOrUpdate(region);
        }

        public static void DeleteRegion(ForlabRegion t)
        {
            DaoFactory.GetDaoFactory().CreateRegionDao().Delete(t);
        }
        public static ForlabRegion GetRegionByName(string rname)
        {
            return DaoFactory.GetDaoFactory().CreateRegionDao().GetRegionByName(rname);
        }
        public static IList<ForlabSite> GetAllSite()
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetAll();
        }
        public static IList<ForlabSite> GetAllSiteByRegionId(int regionid)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetAllSiteByRegionId(regionid);
        }

        public static ForlabSite GetSiteById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetById(id);
        }

        public static ForlabSite GetSiteByName(string sname, int regionid)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetSiteByName(sname, regionid);
        }
        public static void SaveOrUpdateSite(ForlabSite site)
        {
            DaoFactory.GetDaoFactory().CreateSiteDao().SaveOrUpdate(site);
        }

        public static void DeleteSite(ForlabSite t)
        {
            DaoFactory.GetDaoFactory().CreateSiteDao().Delete(t);
        }

        public static IList<ForlabSite> SearchSite(string sql)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().ListUsingQuery(sql);
        }
        #endregion

        #region Testing-Area, Testing-group and Test related Data Access...........................

        public static IList<TestingArea> GetAllTestingArea()
        {
            return DaoFactory.GetDaoFactory().CreateTestingAreaDao().GetAll();
        }

        public static TestingArea GetTestingAreaById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateTestingAreaDao().GetById(id);
        }

        public static void SaveOrUpdateTestingArea(TestingArea tarea)
        {
            DaoFactory.GetDaoFactory().CreateTestingAreaDao().SaveOrUpdate(tarea);
        }

        public static void DeleteTestingArea(TestingArea t)
        {
            DaoFactory.GetDaoFactory().CreateTestingAreaDao().Delete(t);
        }

        public static IList<TestingGroup> GetAllTestingGroup()
        {
            return DaoFactory.GetDaoFactory().CreateTestingGroupDao().GetAll();
        }

        public static TestingGroup GetTestingGroupById(int groupid)
        {
            return DaoFactory.GetDaoFactory().CreateTestingGroupDao().GetById(groupid);
        }

        public static void SaveOrUpdateTestingGroup(TestingGroup tgroup)
        {
            DaoFactory.GetDaoFactory().CreateTestingGroupDao().SaveOrUpdate(tgroup);
        }

        public static void DeleteTestingGroup(TestingGroup g)
        {
            DaoFactory.GetDaoFactory().CreateTestingGroupDao().Delete(g);
        }

        public static IList<Test> GetAllTests()
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetAll();
        }
        public static IList<Test> GetAllTestsByAreaId(int areaid)
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetAllTestsByAreaId(areaid);
        }

        public static IList<Test> GetAllTestsByGroupId(int groupid)
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetAllTestsByGroupId(groupid);
        }

        public static Test GetTestById(int testid)
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetById(testid);
        }

        public static void SaveOrUpdateTest(Test test)
        {
            DaoFactory.GetDaoFactory().CreateTestDao().SaveOrUpdate(test);
        }

        public static void DeleteTest(Test t)
        {
            DaoFactory.GetDaoFactory().CreateTestDao().Delete(t);
        }

        public static IList<TestingArea> GetTestingAreaByDemography(Boolean inDemo)
        {
            return DaoFactory.GetDaoFactory().CreateTestingAreaDao().GetTestingAreaByDemography(inDemo);
        }
        public static IList GetProductUsageByInsIdAndPlatform(int instrumentid, string platform)
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetProductUsageByInsIdAndPlatform(instrumentid, platform);
        }
        #endregion

        #region product, instrument related data access............................................
        
        public static IList<Instrument> GetAllInstrument()
        {
            return DaoFactory.GetDaoFactory().CreateInstrumentDao().GetAll();
        }

        public static Instrument GetInstrumentById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateInstrumentDao().GetById(id);
        }

        public static void SaveOrUpdateInstrument(Instrument inst)
        {
            DaoFactory.GetDaoFactory().CreateInstrumentDao().SaveOrUpdate(inst);
        }

        public static void DeleteInstrument(Instrument t)
        {
            DaoFactory.GetDaoFactory().CreateInstrumentDao().Delete(t);
        }

        public static IList<Instrument> GetListOfInstrumentByTestingArea(int testingAreaId)
        {
            return DaoFactory.GetDaoFactory().CreateInstrumentDao().GetListOfInstrumentByTestingArea(testingAreaId);
        }
        public static IList<Instrument> GetListOfInstrumentByTestingArea(string classofTest)
        {
            return DaoFactory.GetDaoFactory().CreateInstrumentDao().GetListOfInstrumentByTestingArea(classofTest);
        }
        public static IList<MasterProduct> GetAllProduct()
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetAll();
        }

        public static int GetTotalCountOfProducts(int typeId)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetTotalCountOfProducts(typeId);
        }

        public static IList<MasterProduct> GetPagingProducts(int typeId, int firstResult, int maxResult)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetPagingProducts(typeId, firstResult, maxResult);
        }

        public static IList<MasterProduct> GetAllProductByType(int typeid)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetAllProductByType(typeid);
        }

        public static IList<MasterProduct> GetAllProductByClassOfTest(string classofTest)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetAllProductByClassOfTest(classofTest);
        }
        public static IList<MasterProduct> GetAllProductByClassOfTest(string classofTest, string rapidtestGroup)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetAllProductByClassOfTest(classofTest, rapidtestGroup);
        }
        public static MasterProduct GetProductByName(string pname)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetProductByName(pname);
        }
        public static MasterProduct GetProductById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetById(id);
        }

        public static void SaveOrUpdateProduct(MasterProduct pro)
        {
            DaoFactory.GetDaoFactory().CreateProductDao().SaveOrUpdate(pro);
        }

        public static void DeleteProduct(MasterProduct t)
        {
            DaoFactory.GetDaoFactory().CreateProductDao().Delete(t);
        }

        public static IList<MasterProduct> SearchProduct(string sql)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().ListUsingQuery(sql);
        }
        public static IList<ProductType> GetAllProductType()
        {
            return DaoFactory.GetDaoFactory().CreateProductTypeDao().GetAll();
        }

        public static ProductType GetProductTypeById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateProductTypeDao().GetById(id);
        }

        public static void SaveOrUpdateProductType(ProductType pt)
        {
            DaoFactory.GetDaoFactory().CreateProductTypeDao().SaveOrUpdate(pt);
        }

        public static void DeleteProductType(ProductType t)
        {
            DaoFactory.GetDaoFactory().CreateProductTypeDao().Delete(t);
        }

        public decimal GetProductPrice(int proid, DateTime fromdate)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetProductPrice(proid, fromdate);
        }
        #endregion

        public static IList<ForecastInfo> GetAllForecastInfo()
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().GetAll();
        }
        
        public static IList<ForecastInfo> GetForecastInfoByMethodology(string metho)
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().GetForecastInfoByMethodology(metho);
        }

        public static IList<ForecastInfo> GetForecastInfoByDatausage(string metho, string dusage)
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().GetForecastInfoByDatausage(metho, dusage);
        }
        public static ForecastInfo GetForecastInfoById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().GetById(id);
        }

        public static void SaveOrUpdateForecastInfo(ForecastInfo info)
        {
            DaoFactory.GetDaoFactory().CreateForecastInfoDao().SaveOrUpdate(info);
        }

        public static void DeleteForecastInfo(ForecastInfo t)
        {
            DaoFactory.GetDaoFactory().CreateForecastInfoDao().Delete(t);
        }
        public static int FSTotalProductCount(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().FSTotalProductCount(id);
        }

        public static int FCTotalProductCount(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().FCTotalProductCount(id);
        }
        public static int FSTotalTestCount(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().FSTotalTestCount(id);
        }

        public static int FCTotalTestCount(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastInfoDao().FCTotalTestCount(id);
        }
        public static IList<ForecastSiteProduct> GetFSiteProductByProId(int fsiteid, int proid, SortDirection sd)
        {
            return DaoFactory.GetDaoFactory().CreateForecastSiteProductDao().GetFSiteProductByProId(fsiteid, proid,sd);
        }

        public static decimal[] GetFSiteProAmountUsed(int fsiteid, int proid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastSiteProductDao().GetFSiteProAmountUsed(fsiteid, proid);
        }

        public static IList<ForecastCategoryProduct> GetFCategoryProductByProId(int fcatid, int proid, SortDirection sd)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryProductDao().GetFCategoryProductByProId(fcatid, proid,sd);
        }

        public static decimal[] GetFCategoryProAmountUsed(int fcatid, int proid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryProductDao().GetFCategoryProAmountUsed(fcatid, proid);
        }

        public static IList<ForecastSiteTest> GetFSiteTestByTestId(int ftid, int testid, SortDirection sd)
        {
            return DaoFactory.GetDaoFactory().CreateForecastSiteTestDao().GetFSiteTestByTestId(ftid, testid,sd);
        }

        public static decimal[] GetFSiteTestAdjusted(int ftid, int testid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastSiteTestDao().GetFSiteTestAdjusted(ftid, testid);
        }

        public static IList<ForecastCategoryTest> GetFCategoryTestByTestId(int fcid, int testid, SortDirection sd)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryTestDao().GetFCategoryTestByTestId(fcid, testid,sd);
        }

        public static decimal[] GetFCategoryTestAdjusted(int fcid, int testid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryTestDao().GetFCategoryTestAdjusted(fcid, testid);
        }
        //public static IList<ForecastSite> GetAllForecasSite()
        //{
        //    return DaoFactory.GetDaoFactory()().GetAll();
        //}

        //public static  GetById(int id)
        //{
        //    return DaoFactory.GetDaoFactory()().GetById(id);
        //}

        public static void SaveOrUpdateForecastSite(ForecastSite fsite)
        {
            DaoFactory.GetDaoFactory().CreateForecastSiteDao().SaveOrUpdate(fsite);
        }

        public static void DeleteForecastSite(ForecastSite t)
        {
            DaoFactory.GetDaoFactory().CreateForecastSiteDao().Delete(t);
        }

        public static IList<FTable> GetAllFTable()
        {
            return DaoFactory.GetDaoFactory().CreateFTableDao().GetAll();
        }

        public static IList<FTable> GetFTableByFinfoId(int finfoid)
        {
            return DaoFactory.GetDaoFactory().CreateFTableDao().GetFTableByFinfoId(finfoid);
        }
        public static FTable GetFTableById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateFTableDao().GetById(id);
        }

        public static void SaveOrUpdateFTable(FTable ft)
        {
            DaoFactory.GetDaoFactory().CreateFTableDao().SaveOrUpdate(ft);
        }

        public static void DeleteFTable(FTable t)
        {
            DaoFactory.GetDaoFactory().CreateFTableDao().Delete(t);
        }

        public static IList<MasterProduct> GetFTableProducts(int finfoid)
        {
            return DaoFactory.GetDaoFactory().CreateFTableDao().GetFTableProducts(finfoid);
        }

        public static IList GetFResult(int finfoid, int proid)
        {
            return DaoFactory.GetDaoFactory().CreateFTableDao().GetFResult(finfoid, proid);
        }
        public static IList RptForecastTestSummary(int finfoid)
        {
            return DaoFactory.GetDaoFactory().CreateFTableDao().RptForecastTestSummary(finfoid);
        }

        public static ForecastCategory GetForecastCategoryById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryDao().GetById(id);
        }

        public static ForecastCategory GetForecastCategoryByName(int fcastid, string cname)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryDao().GetForecastCategoryByName(fcastid, cname);
        }

        public static void SaveOrUpdateForecastCategory(ForecastCategory fcategory)
        {
            DaoFactory.GetDaoFactory().CreateForecastCategoryDao().SaveOrUpdate(fcategory);
        }

        public static TestingArea GetTestingAreaByName(string name)
        {
            return  DaoFactory.GetDaoFactory().CreateTestingAreaDao().GetTestingAreaByName(name);
        }

        public static TestingGroup GetTestingGroupByName(int areaid, string name)
        {
            return DaoFactory.GetDaoFactory().CreateTestingGroupDao().GetTestingGroupByName(areaid, name);
        }

        public static Test GetTestByName(string name)
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetTestByName(name);
        }

        public static Test GetTestByNameAndTestArea(string name, int areaid)
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetTestByNameAndTestArea(name, areaid);
        }

        public static Instrument GetInstrumentByName(string name)
        {
            return DaoFactory.GetDaoFactory().CreateInstrumentDao().GetInstrumentByName(name);
        }

        public static Instrument GetInstrumentByNameAndTestingArea(string name, int testingAreaId)
        {
            return DaoFactory.GetDaoFactory().CreateInstrumentDao().GetInstrumentByNameAndTestingArea(name, testingAreaId);
        }

        public static ProductType GetProductTypeByName(string name)
        {
            return DaoFactory.GetDaoFactory().CreateProductTypeDao().GetProductTypeByName(name);
        }

        public static SiteCategory GetSiteCategoryById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateSiteCategoryDao().GetById(id);
        }

        public static SiteCategory GetSiteCategoryByName(string scname)
        {
            return DaoFactory.GetDaoFactory().CreateSiteCategoryDao().GetSiteCategoryByName(scname);
        }

        public static IList<SiteCategory> GetListOfAllSiteCategory()
        {
            return DaoFactory.GetDaoFactory().CreateSiteCategoryDao().GetAll();
        }
        public static void SaveOrUpdateSiteCategory(SiteCategory sc)
        {
            DaoFactory.GetDaoFactory().CreateSiteCategoryDao().SaveOrUpdate(sc);
        }
        public static void DeleteSiteCategory(SiteCategory sc)
        {
            DaoFactory.GetDaoFactory().CreateSiteCategoryDao().Delete(sc);
        }

        public static void BatchSaveForecastedResult(IList<ForecastedResult> list)
        {

            IForecastedResultDao ifdao = DaoFactory.GetDaoFactory().CreateForecastedResultDao();
            try
            {
                ifdao.OpenBatchTransaction();
                foreach (ForecastedResult fr in list)
                {
                    ifdao.BatchSave(fr);
                    if (OnFResultSaved != null)
                    {
                        OnFResultSaved(null, new EventArgs());
                    }
                }
            }
            catch(Exception ex)
            {
                ifdao.RolebackBatchTransaction();
                throw ex;
            }
        }

        public static void BatchDeleteForecastedResult(IList<ForecastedResult> list)
        {
            IForecastedResultDao ifdao = DaoFactory.GetDaoFactory().CreateForecastedResultDao();
            try
            {
                ifdao.OpenBatchTransaction();
                foreach (ForecastedResult fr in list)
                {
                    ifdao.BatchDelete(fr);
                    if (OnFResultDeleted != null)
                    {
                        OnFResultDeleted(null, new EventArgs());
                    }
                }
            }
            catch
            {
                ifdao.RolebackBatchTransaction();
            }
        }

        public static void DeleteAllFResult(int finfoid)
        {
            DaoFactory.GetDaoFactory().CreateForecastedResultDao().DeleteAllFResult(finfoid);
        }

        public static IList GetBeyondMaxTPutResult(int finfoid,int monthinperiod)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetBeyondMaxTPutResult(finfoid,monthinperiod);
        }

        public static IList<ForecastSiteTest> GetHistoricalTest(string period, string fMethodology, string dataUsage, int testId, int siteId, DateTime startDate, int noHistoryRecord)
        {
            return DaoFactory.GetDaoFactory().CreateForecastSiteTestDao().GetHistoricalTest(period, fMethodology, dataUsage, testId, siteId, startDate, noHistoryRecord);
        }
        public static void BatchSaveForecastSiteTest(IList<ForecastSiteTest> list)
        {
            DaoFactory.GetDaoFactory().CreateForecastSiteTestDao().BatchSaveForecastSiteTest(list);
        }

        ///

        public static IList<ForecastSiteProduct> GetHistoricalProduct(string period, string fMethodology, string dataUsage, int productId, int siteId, DateTime startDate, int noHistoryRecord)
        {
            return DaoFactory.GetDaoFactory().CreateForecastSiteProductDao().GetHistoricalProduct(period, fMethodology, dataUsage, productId, siteId, startDate, noHistoryRecord);
        }

        public static void BatchSaveForecastSiteProduct(IList<ForecastSiteProduct> list)
        {
            DaoFactory.GetDaoFactory().CreateForecastSiteProductDao().BatchSaveForecastSiteProduct(list);
        }

        public static IList<MAPEResult> GetSiteMAPEByProduct(int fid, int fsid, int pid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetSiteMAPEByProduct( fid,  fsid,  pid);
        }
        public static  IList<MAPEResult> GetSiteMAPEByTest(int fid, int fsid, int tid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetSiteMAPEByTest( fid,  fsid,  tid);
        }

        public static IList<MAPEResult>  GetCategoryMAPEByProduct(int fid, int cid, int pid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetCategoryMAPEByProduct(fid, cid, pid);
        }
        public static IList<MAPEResult> GetCategoryMAPEByTest(int fid, int cid, int tid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetCategoryMAPEByTest(fid, cid, tid);
        }

        public static IList<MAPEResult> GetMAPESummaryByProduct(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetMAPESummaryByProduct(fid);
        }

        public static IList<MAPEResult> GetMAPESummaryByTest(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetMAPESummaryByTest(fid);
        }

        

        #region morbidity forecast

        public static IList<MorbidityForecast> GetAllMorbidityForecast()
        {
            return DaoFactory.GetDaoFactory().CreateMorbidityForecastDao().GetAll();
        }

        public static MorbidityForecast GetMorbidityForecastById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateMorbidityForecastDao().GetById(id);
        }

        public static void SaveOrUpdateMorbidityForecast(MorbidityForecast forecast)
        {
            DaoFactory.GetDaoFactory().CreateMorbidityForecastDao().SaveOrUpdate(forecast);
        }

        public static void DeleteMorbidityForecast(MorbidityForecast t)
        {
            DaoFactory.GetDaoFactory().CreateMorbidityForecastDao().Delete(t);
        }

        #endregion

        #region ARTSite

        public static IList<ARTSite> GetAllARTSite(int forecastid)
        {
            return DaoFactory.GetDaoFactory().CreateARTSiteDao().GetAllARTSite(forecastid);
        }


        public static ARTSite GetARTSiteById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateARTSiteDao().GetById(id);
        }

        public static void SaveOrUpdateARTSite(ARTSite artsite)
        {
            DaoFactory.GetDaoFactory().CreateARTSiteDao().SaveOrUpdate(artsite);
        }

        public static void DeleteARTSite(ARTSite artsite)
        {
            DaoFactory.GetDaoFactory().CreateARTSiteDao().Delete(artsite);
        }

        public static void BatchSaveARTSite(IList<ARTSite> list)
        {
            IARTSiteDao idao = DaoFactory.GetDaoFactory().CreateARTSiteDao();

            try
            {
                idao.OpenBatchTransaction();
                foreach (ARTSite site in list)
                {
                    idao.BatchSave(site);
                }
                idao.CommitBatchTransaction();
            }
            catch (Exception ex)
            {
                idao.RolebackBatchTransaction();
                throw ex;
            }
        }

        public static void BatchDeleteARTSite(IList<ARTSite> list)
        {
            IARTSiteDao idao = DaoFactory.GetDaoFactory().CreateARTSiteDao();

            try
            {
                idao.OpenBatchTransaction();
                foreach (ARTSite site in list)
                {
                    idao.BatchDelete(site);
                }
                idao.CommitBatchTransaction();
            }
            catch (Exception ex)
            {
                idao.RolebackBatchTransaction();
                throw ex;
            }
        }
        #endregion

        #region Rapid Test Setting


        public static IList<RapidTestSpec> GetAllRapidTestSpec()
        {
            return DaoFactory.GetDaoFactory().CreateRapidTestSpecDao().GetAll();
        }
        
        public static RapidTestSpec GetRapidTestSpecById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateRapidTestSpecDao().GetById(id);
        }

        public static void SaveOrUpdateRapidTestSpec(RapidTestSpec rapidtest)
        {
            DaoFactory.GetDaoFactory().CreateRapidTestSpecDao().SaveOrUpdate(rapidtest);
        }

        public static void DeleteARTSite(RapidTestSpec rapidtest)
        {
            DaoFactory.GetDaoFactory().CreateRapidTestSpecDao().Delete(rapidtest);
        }
        public static IList<RapidTestSpec> GetRapidTestSpecByTestGroup(string atype)
        {
            return DaoFactory.GetDaoFactory().CreateRapidTestSpecDao().GetRapidTestSpecByTestGroup(atype);
        }

        public IList<Instrument> GetInstrumentByCategory(string category)
        {
            return DaoFactory.GetDaoFactory().CreateTestingAreaDao().GetDistinctInstrumentByCategory(category);
        }

         #endregion

       

        #region morbidity Supply/ Procurement

        public static IList<MorbiditySupplyProcurement> GetAllMorbiditySupplyProcurement()
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().GetAll();
        }

        public static MorbiditySupplyProcurement GetMorbiditySupplyProcurementById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().GetById(id);
        }

        public static void SaveOrUpdateMorbiditySupplyProcurement(MorbiditySupplyProcurement msp)
        {
            DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().SaveOrUpdate(msp);
        }

        public static void DeleteMorbiditySupplyProcurement(MorbiditySupplyProcurement msp)
        {
            DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().Delete(msp);
        }

        public static IList<MorbiditySupplyProcurement> GetMorbiditySupplyForecastSummery(int MforecastId)
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().GetMorbiditySupplyForecastSummery(MforecastId);
        }

        public static void MorbiditySupplyProcurementBatchSave(IList<MorbiditySupplyProcurement> msp)
        {
             DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().BatchSaveMorbiditySupplyProcurement(msp);
        }

        public static IList<MorbiditySupplyForecast> GetAllMorbiditySupplyForecast()
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyForecastDao().GetAll();
        }

        public static MorbiditySupplyForecast GetMorbiditySupplyForecastById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyForecastDao().GetById(id);
        }

        public static void SaveOrUpdateMorbiditySupplyForecast(MorbiditySupplyForecast msf)
        {
            DaoFactory.GetDaoFactory().CreateMorbiditySupplyForecastDao().SaveOrUpdate(msf);
        }

        public static void DeleteMorbiditySupplyForecast(MorbiditySupplyForecast msf)
        {
            DaoFactory.GetDaoFactory().CreateMorbiditySupplyForecastDao().Delete(msf);
        }

        public static IList<MorbiditySupplyProcurement> GetMorbiditySPByForecastId(int forecastId)
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().GetMorbiditySPByForecastId(forecastId);
        }

        public static IList<MorbiditySupplyProcurement> GetMorbiditySPByForecastIdPlatformId(int forecastId, int platformId)
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().GetMorbiditySPByForecastIdPlatformId(forecastId, platformId);
        }

        #endregion

        #region protocol
        public static IList<Protocol> GetAllProtocol()
        {
            return DaoFactory.GetDaoFactory().CreateProtocolDao().GetAll();
        }

        public static void SaveOrUpdateProtocol(Protocol P)
        {
            DaoFactory.GetDaoFactory().CreateProtocolDao().SaveOrUpdate(P);
        }

        public static Protocol GetProtocolById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateProtocolDao().GetById(id);
        }

        public static void DeleteProtocol(Protocol P)
        {
            DaoFactory.GetDaoFactory().CreateProtocolDao().Delete(P);
        }

        #endregion

        #region Panel
        public static IList<ProtocolPanel> GetAllProtocolPanel()
        {
            return DaoFactory.GetDaoFactory().CreateProtocolPanelDao().GetAll();
        }

        public static void SaveOrUpdateProtocolPanel(ProtocolPanel P)
        {
            DaoFactory.GetDaoFactory().CreateProtocolPanelDao().SaveOrUpdate(P);
        }

        public static ProtocolPanel GetProtocolPanelById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateProtocolPanelDao().GetById(id);
        }

        public static void DeleteProtocolPanel(ProtocolPanel P)
        {
            DaoFactory.GetDaoFactory().CreateProtocolPanelDao().Delete(P);
        }

        #endregion

        public static IList<Test> GetTestByPlatform(string platform)
        {
            return DaoFactory.GetDaoFactory().CreateTestDao().GetTestByPlatform(platform);
        }

        public static PatientsNoofTest GetPatientsNoofTestSummery(int fid)
        {
            return DaoFactory.GetDaoFactory().CreatePatientsNoofTestDao().GetPatientsNoofTestSummary(fid);
        }

        public static HIVRapidNumberofTest GetHIVRapidNumberofTestSummary(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateHIVRapidNumberofTestDao().GetHIVRapidNumberofTestSummary(fid);
        }

        public static HemaandViralNumberofTest GetHematologySummary(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateHemaandViralNumberofTestDao().GetHematologyTestNumberSummary(fid);
        }

        public static HemaandViralNumberofTest GetViralLoadSummary(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateHemaandViralNumberofTestDao().GetViralLoadTestNumberSummary(fid);
        }

        public static CD4TestNumber GetCD4TestNumberSummary(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateCD4TestNumberDao().GetCD4TestNumberSummary(fid);
        }

        public static ChemandOtherNumberofTest GetChemistryTestSummary(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateChemandOtherNumberofTestDao().GetChemistryTestSummary(fid);
        }

        public static ChemandOtherNumberofTest GetOtherTestSummary(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateChemandOtherNumberofTestDao().GetOtherTestSummary(fid);
        }

        public static ForlabParameter GetForlabParameterByParamName(string pname)
        {
            return DaoFactory.GetDaoFactory().CreateForlabParameterDao().GetForlabParameterByParamName(pname);
        }

        public static void SaveOrUpdateForlabParameter(ForlabParameter forlab)
        {
            DaoFactory.GetDaoFactory().CreateForlabParameterDao().SaveOrUpdate(forlab);
        }
        #region Inventory Assumption
        
        public static InventoryAssumption GetInventoryAssumptionById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateInventoryAssumptionDao().GetById(id);
        }

        public static void SaveOrUpdateInventoryAssumption(InventoryAssumption inv)
        {
            DaoFactory.GetDaoFactory().CreateInventoryAssumptionDao().SaveOrUpdate(inv);
        }

        public static void DeleteInventoryAssumption(InventoryAssumption inv)
        {
            DaoFactory.GetDaoFactory().CreateInventoryAssumptionDao().Delete(inv);
        }
        public static InventoryAssumption GetInventoryAssumptionByForecastId(int forecastId)
        {
            return DaoFactory.GetDaoFactory().CreateInventoryAssumptionDao().GetInventoryAssumptionByForecastId(forecastId);
        }
         
        #endregion

        public static void DeleteAllSupplyForecastSummery(int MforecastId)
        {
            DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().DeleteAllSupplyForecastSummery(MforecastId);
        }

        public static IList<MorbiditySupplyProcurement> GetSupplyProcurementByForecastId(int MforecastId)
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyProcurementDao().GetSupplyProcurementByForecastId(MforecastId);
        }

        public static Protocol GetProtocolByPlatform(int Platformid)
        {
            return DaoFactory.GetDaoFactory().CreateProtocolDao().GetProtocolByPlatform(Platformid);
        }

        #region Morbidity test

        public static IList<MorbidityTest> GetAllMorbidityTestByClass(string classofTest) 
        {
            return DaoFactory.GetDaoFactory().CreateMorbidityTestDao().GetAllMorbidityTestByClass(classofTest);
        }

        public static MorbidityTest GetMorbidityTestById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateMorbidityTestDao().GetById(id);
        }

        public static void SaveOrUpdateMorbidityTest(MorbidityTest mtest)
        {
            DaoFactory.GetDaoFactory().CreateMorbidityTestDao().SaveOrUpdate(mtest);
        }
        public static void DeleteMorbidityTest(MorbidityTest mtest)
        {
            DaoFactory.GetDaoFactory().CreateMorbidityTestDao().Delete(mtest);
        }

        //end test
        public static IList<QuantifyMenu> GetAllQuantifyMenuByClass(string classofTest) 
        {
            return DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().GetAllQuantifyMenuByClass(classofTest);
        }
        public static IList<QuantifyMenu> GetGeneralQuantifyMenuByClass(string classofTest)
        {
            return DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().GetGeneralQuantifyMenuByClass(classofTest);
        }
        public static IList<QuantifyMenu> GetAllGeneralQuantifyMenus()
        {
            return DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().GetAllGeneralQuantifyMenus();
        }
        public static IList<QuantifyMenu> GetAllQuantifyMenuByInstrument(int instrumentid)
        {
            return DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().GetAllQuantifyMenuByInstrument(instrumentid);
        }
        public static QuantifyMenu GetQuantifyMenuByProductId(int productId)
        {
            return DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().GetQuantifyMenuByProductId(productId);
        }

        public static QuantifyMenu GetQuantifyMenuById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().GetById(id);
        }

        public static void SaveOrUpdateQuantifyMenu( QuantifyMenu mtest)
        {
            DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().SaveOrUpdate(mtest);
        }
        public static void DeleteQuantifyMenu(QuantifyMenu mtest)
        {
            DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().Delete(mtest);
        }
        //end  Quantify Menu

        public static IList<QuantificationMetric> GetAllQuantificationMetricByClass(string classofTest)
        {
            return DaoFactory.GetDaoFactory().CreateQuantificationMetricDao().GetAllQuantificationMetricByClass(classofTest);
        }
        public static QuantificationMetric GetQuantificationMetricById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateQuantificationMetricDao().GetById(id);
        }

        public static void SaveOrUpdateQuantificationMetric(QuantificationMetric mtest)
        {
            DaoFactory.GetDaoFactory().CreateQuantificationMetricDao().SaveOrUpdate(mtest);
        }

        public static void DeleteQuantificationMetric(QuantificationMetric mtest)
        {
            DaoFactory.GetDaoFactory().CreateQuantificationMetricDao().Delete(mtest);
        }
        #endregion

        public static bool GetRefSiteBySiteId(int siteId, string platform)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetRefSiteBySiteId(siteId, platform);
        }


        public static IList<ForlabSite> GetReferingSiteByPlatform(int siteid, int platform)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetReferingSiteByPlatform(siteid, platform);
        }

        public static IList<ForlabSite> GetReferingSiteByPlatform(string platform)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetReferingSiteByPlatform(platform);
        }

        public static IList<ForlabSite> GetAllSiteByRegionandPlatform(int regionid, string platform)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetAllSiteByRegionandPlatform(regionid, platform);
        }

        public static void deleteReferingSite(int siteId, string platform)
        {
            DaoFactory.GetDaoFactory().CreateSiteDao().deleteReferingSite(siteId, platform);
        }
        
        public static ForlabSite GetSiteByName(string sitename)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetSiteByName(sitename);
        }

        public static IList<QuantifyMenu> GetAllQuantifyMenus()
        {
            return DaoFactory.GetDaoFactory().CreateQuantifyMenuDao().GetAll();
        }

        public static IList<int> GetListOfReferedSites(int siteId, string platform)
        {
            return DaoFactory.GetDaoFactory().CreateSiteDao().GetListOfReferedSites(siteId, platform);
        }
        public static IList GetSummaryOfTotalCost(int forecastid)
        {
            return DaoFactory.GetDaoFactory().CreateMorbiditySupplyForecastDao().GetSummaryOfTotalCost(forecastid);
        }

        public static IList GetChemistryTestSummarys(int forecastid)
        {
            return DaoFactory.GetDaoFactory().CreateChemandOtherNumberofTestDao().GetChemistryTestSummarys(forecastid);
        }

        public static IList GetOtherTestSummarys(int forecastid)
        {
            return DaoFactory.GetDaoFactory().CreateChemandOtherNumberofTestDao().GetOtherTestSummarys(forecastid);
        }
        public static IList GetUniqueFType(int forecastId, int productType)
        {
            return DaoFactory.GetDaoFactory().CreateForecastedResultDao().GetUniqueFType(forecastId, productType);
        }

        public static IList<ForecastCategoryInstrument>GetFCInstrumentByFinfoId(int fid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryInstrumentDao().GetFCInstrumentByFinfoId(fid);
        }

        public static void SaveOrUpdateForecastCategoryInstrument(ForecastCategoryInstrument forecastCategoryInstrument)
        {
            DaoFactory.GetDaoFactory().CreateForecastCategoryInstrumentDao().SaveOrUpdate(forecastCategoryInstrument);
        }

        public static IList<ForecastCategoryInstrument> GetAllForecastCategoryInstrument()
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryInstrumentDao().GetAll();
        }

        public static ForecastCategoryInstrument GetForecastCategoryInstrumentById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryInstrumentDao().GetById(id);
        }

        public static void DeleteForecastCategoryInstrument(ForecastCategoryInstrument t)
        {
            DaoFactory.GetDaoFactory().CreateForecastCategoryInstrumentDao().Delete(t);
        }
        public static ForecastCategoryInstrument GetFCInstrumentById(int id)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryInstrumentDao().GetFCInstrumentById(id);
        }

        public static ForecastCategoryInstrument GetFCInstrumentByInstrumentId(int iid)
        {
            return DaoFactory.GetDaoFactory().CreateForecastCategoryInstrumentDao().GetFCInstrumentByInstrumentId(iid);
        }

        public static IList<QuantificationMetric> GetListOfAllQuantificationMetrics()
        {
            return DaoFactory.GetDaoFactory().CreateQuantificationMetricDao().GetListOfAllQuantificationMetrics();
        }

        public static MasterProduct GetProductByTypeandName(string pname,string ptname)
        {
            return DaoFactory.GetDaoFactory().CreateProductDao().GetProductByTypeandName(pname,ptname);
        }

    }
}
