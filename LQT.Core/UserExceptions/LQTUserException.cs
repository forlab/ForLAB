
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
