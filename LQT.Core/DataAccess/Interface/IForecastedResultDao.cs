
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
