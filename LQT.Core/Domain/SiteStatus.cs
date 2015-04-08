
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LQT.Core.Domain
{
    public class SiteStatus
    {
        protected int _id;
        protected DateTime _openedFrom;
        protected DateTime? _closedOn;
        protected ForlabSite _site;

        public SiteStatus()
        {
            this._id = -1;
        }
        
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime OpenedFrom
        {
            get { return _openedFrom; }
            set { _openedFrom = value; }
        }

        public DateTime? ClosedOn
        {
            get { return _closedOn; }
            set { _closedOn = value; }
        }

        public ForlabSite Site
        {
            get { return _site; }
            set { _site = value; }
        }
    }
}
