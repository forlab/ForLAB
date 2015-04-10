
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
