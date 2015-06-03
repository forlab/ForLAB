
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
