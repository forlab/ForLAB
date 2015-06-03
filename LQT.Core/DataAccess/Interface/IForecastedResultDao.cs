
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

namespace LQT.Core.DataAccess.Interface 
{
    public interface IForecastedResultDao: IDao<ForecastedResult>
    {
        void OpenBatchTransaction();
        void CommitBatchTransaction();
        void RolebackBatchTransaction();
        void BatchSave(ForecastedResult fr);
        void BatchDelete(ForecastedResult fr);
        void DeleteAllFResult(int finfoid);
        IList GetBeyondMaxTPutResult(int finfoid, int monthinperiod);

        IList<MAPEResult> GetSiteMAPEByTest(int fid, int fsid, int tid);
        IList<MAPEResult> GetSiteMAPEByProduct(int fid, int fsid, int pid);
        IList<MAPEResult> GetCategoryMAPEByProduct(int fid, int cid, int pid);
        IList<MAPEResult> GetCategoryMAPEByTest(int fid, int cid, int tid);
        IList<MAPEResult> GetMAPESummaryByProduct(int fid);
        IList<MAPEResult> GetMAPESummaryByTest(int fid);

        IList GetUniqueFType(int ForecastId, int ProductType);
    }
}
