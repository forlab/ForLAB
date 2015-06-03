
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
