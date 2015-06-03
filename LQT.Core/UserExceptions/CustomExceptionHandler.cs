
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

namespace LQT.Core.UserExceptions
{
    public struct ExceptionStatus
    {
        public Exception ex;
        public string message;
    }

    public class CustomExceptionHandler
    {
        public static ExceptionStatus ShowExceptionText(Exception ex)
        {
            ExceptionStatus exceptionStatus = new ExceptionStatus();

            exceptionStatus.ex = ex;
            exceptionStatus.message = ex is LQTUserException ?
                ex.ToString() : "Error while trying to read or write into the database, please contact your IT administrator";

            return exceptionStatus;
        }

        public static ExceptionStatus ShowExceptionText(string message, Exception ex)
        {
            ExceptionStatus exceptionStatus = new ExceptionStatus();

            exceptionStatus.ex = ex;
            exceptionStatus.message = message;

            return exceptionStatus;
        }
    }
}
