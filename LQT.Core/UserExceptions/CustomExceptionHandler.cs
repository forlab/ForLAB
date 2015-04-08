
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
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
