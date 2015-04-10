
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

namespace LQT.GUI
{
    public struct BackupOperationStatus
    {
        public BackupOperationStatus(bool pSucceeded, Exception pRaisedException, string pOutputFile, long pOutputFileSize, long pBackupFileSize)
        {
            Succeeded = pSucceeded;
            RaisedException = pRaisedException;
            OutputFile = pOutputFile;
            OutputFileSize = pOutputFileSize;
            BackupFileSize = pBackupFileSize;
        }

        public bool Succeeded;
        public Exception RaisedException;
        public string OutputFile;
        public long OutputFileSize;
        public long BackupFileSize;
    }

    public struct Script
    {
        public string current;
        public string expected;
        public string scriptName;
    }

    public struct ExecuteScriptResult
    {
        public ExecuteScriptResult(bool pSuccessfull, int pQueriesCount, string pErrorMessage, string pFailedQuery)
        {
            successfull = pSuccessfull;
            queriesCount = pQueriesCount;
            errorMessage = pErrorMessage;
            failedQuery = pFailedQuery;
        }

        public bool successfull;
        public int queriesCount;
        public string errorMessage;
        public string failedQuery;
    }

}
