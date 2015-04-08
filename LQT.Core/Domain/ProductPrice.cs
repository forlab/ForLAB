
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
