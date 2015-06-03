
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
using System.Collections;

namespace LQT.Core.Domain
{	
	/// <summary>
	/// ProductUsage object for NHibernate mapped table 'ProductUsage'.
	/// </summary>
    public class ProductUsage
    {
        #region Member Variables

        private int _id;
        private decimal _rate;
        private MasterProduct _product;
        private Test _testId;
        private Instrument _instrumane;
        private string _productUsedIn;

        #endregion

        #region Constructors

        public ProductUsage()
        {
            this._id = -1;
        }


        #endregion

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual decimal Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public virtual MasterProduct Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public virtual Test Test
        {
            get { return _testId; }
            set { _testId = value; }
        }

        public virtual Instrument Instrument
        {
            get { return _instrumane; }
            set { _instrumane = value; }
        }

        public virtual string ProductUsedIn
        {
            get { return _productUsedIn; }
            set { _productUsedIn = value; }
        }

        #endregion


    }

}
