
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
using System.Linq;
using System.Text;

namespace LQT.Core.Util
{
    public class LQTUserMessage
    {
        private readonly string _message;
        private readonly bool _isthereError;

        public LQTUserMessage(string message)
            : this(message, false)
        {
        }

        public LQTUserMessage(string message, bool isthereError)
        {
            _message = message;
            _isthereError = isthereError;
        }
        public string Message
        {
            get { return _message; }
        }

        public bool IsThereError
        {
            get { return _isthereError; }
        }
    }
}
