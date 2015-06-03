
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
    public class ProductPrice
    {
        #region Member Variables

        protected int _id;
        protected decimal _price;
        protected int _packSize;
        protected DateTime _fromDate;
        protected MasterProduct _product;

        #endregion

        #region Constructors

        public ProductPrice() 
        {
            this._id = -1;
            this._fromDate = DateTime.Now;
        }

        #endregion

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public virtual int PackSize
        {
            get { return _packSize; }
            set { _packSize = value; }
        }

        public virtual DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        public virtual MasterProduct Product
        {
            get { return _product; }
            set { _product = value; }
        }

        #endregion
    }
}
