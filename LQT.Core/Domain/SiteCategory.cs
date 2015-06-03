
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
    public class SiteCategory
    {
        #region Member Variables

        private int _id;
        private string _categoryName;
        
        #endregion

        #region Constructors

        public SiteCategory() 
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

        public virtual string CategoryName
        {
            get { return _categoryName; }
            set
            {
                if (value != null && value.Length > 64)
                    throw new ArgumentOutOfRangeException("Invalid value for CategoryName", value, value.ToString());
                _categoryName = value;
            }
        }

        #endregion
    }
}
