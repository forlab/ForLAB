
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
using System.Runtime.Serialization;
using System.Text;

namespace LQT.Core.UserExceptions
{
    [Serializable]
    public class LQTUserException : ApplicationException
    {
        private readonly string _message;

        protected LQTUserException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _message = info.GetString("Code");
        }

        public LQTUserException()
        {
            _message = String.Empty;
        }

        public LQTUserException(string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return _message;
        }
    }
}
