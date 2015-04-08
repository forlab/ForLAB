
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
    public class MasterConsumable
    {
        #region Member Variables

        private int _id;
        private TestingArea _testingArea;
        private Test _test;
        private IList<ConsumableUsage> _consumablesUsages;

        #endregion

        public MasterConsumable() 
		{
			this._id = -1;
		}

        #region Public Properties

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }
       
        public virtual TestingArea TestingArea
        {
            get { return _testingArea; }
            set { _testingArea = value; }
        }

        public virtual Test Test
        {
            get { return _test; }
            set { _test = value; }
        }

        public virtual IList<ConsumableUsage> ConsumableUsages
        {
            get
            {
                if (_consumablesUsages == null)
                {
                    _consumablesUsages = new List<ConsumableUsage>();
                }
                return _consumablesUsages;
            }
            set { _consumablesUsages = value; }
        }

     
        #endregion

        public virtual IList<ConsumableUsage> GetPerTestUsage()
        {
            IList<ConsumableUsage> result = new List<ConsumableUsage>();
            foreach (ConsumableUsage cu in ConsumableUsages)
            {
                if (cu.PerTest == true)
                {
                    result.Add(cu);
                }
            }
            return result;
        }
        public virtual IList<ConsumableUsage> GetPerPeriodUsage()
        {
            IList<ConsumableUsage> result = new List<ConsumableUsage>();
            foreach (ConsumableUsage cu in ConsumableUsages)
            {
                if (cu.PerPeriod == true)
                {
                    result.Add(cu);
                }
            }
            return result;
        }

        public virtual IList<ConsumableUsage> GetPerInstrumentUsage()
        {
            IList<ConsumableUsage> result = new List<ConsumableUsage>();
            foreach (ConsumableUsage cu in ConsumableUsages)
            {
                if (cu.PerInstrument == true)
                {
                    result.Add(cu);
                }
            }
            return result;
        }
        public virtual ConsumableUsage GetConsumableUsage(int id)
        {
            foreach (ConsumableUsage cu in ConsumableUsages)
            {
                if (cu.Id == id)
                    return cu;
            }
            return null;
        }
        public virtual bool IsExsistUsageRatePerTest(int proId)
        {
            foreach (ConsumableUsage cu in ConsumableUsages)
            {
                if (cu.PerTest== true && cu.Product.Id == proId)
                    return true;
            }
            return false;
        }

        public virtual bool IsExsistUsageRatePerPeriod(int proId)
        {
            foreach (ConsumableUsage cu in ConsumableUsages)
            {
                if (cu.PerPeriod == true && cu.Product.Id == proId)
                    return true;
            }
            return false;
        }

        public virtual bool IsExsistUsageRatePerInst(int inst, int proId)
        {
            foreach (ConsumableUsage cu in ConsumableUsages)
            {
                if (cu.PerInstrument == true && cu.Product.Id == proId && cu.Instrument.Id==inst)
                    return true;
            }
            return false;
        }
    }
}
