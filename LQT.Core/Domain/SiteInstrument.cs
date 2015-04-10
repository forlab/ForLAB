
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

