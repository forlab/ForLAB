
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

namespace LQT.Core.Domain
{
    /// <summary>
    /// SiteInstrument object for NHibernate mapped table 'SiteInstrument'.
    /// </summary>
    public class SiteInstrument
    {
        #region Member Variables

        private int _id;
        private Instrument _instrument;
        private ForlabSite _site;
        private int _quantity;
        private decimal _testRunPercentage;

        #endregion

        #region Constructors

        public SiteInstrument() 
        {
            this._id = -1;
        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Instrument Instrument
        {
            get { return _instrument; }
            set { _instrument = value; }
        }

        public ForlabSite Site
        {
            get { return _site; }
            set { _site = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal TestRunPercentage
        {
            get { return _testRunPercentage; }
            set { _testRunPercentage = value; }

        }

        #endregion

        
    }
}

