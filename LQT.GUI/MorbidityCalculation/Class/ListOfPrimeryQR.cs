
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
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class ListOfPrimeryQR
    {
        private IList<PrimeryQuantifyedReagent> _listofPQR;
        private IDictionary<int, QuantifyedReagent> _listofSupplies;
        private int _platform;

        private ListOfPrimeryQR()
        {
        }

        public ListOfPrimeryQR(ClassOfMorbidityTestEnum platform)
        {
            _platform = (int)platform;
            _listofPQR = new List<PrimeryQuantifyedReagent>();
            _listofSupplies = new Dictionary<int, QuantifyedReagent>();

        }

        public void AddPrimeryQR(PrimeryQuantifyedReagent pqr)
        {
            _listofPQR.Add(pqr);
        }

        public int Platform
        {
            get { return _platform; }
        }

        public IDictionary<int, QuantifyedReagent> GetSuppliesForecasted()
        {
            foreach (PrimeryQuantifyedReagent pr in _listofPQR)
            {
                if (_listofSupplies.ContainsKey(pr.ProductId))
                {
                    _listofSupplies[pr.ProductId].QuantityNeeded = _listofSupplies[pr.ProductId].QuantityNeeded + pr.Value;
                }
                else
                {
                    QuantifyedReagent qr = new QuantifyedReagent(_platform, pr.ProductId, pr.MinimumQuantity);
                    qr.UnitCost = pr.UnitCost;
                    qr.Unit = pr.Unit;
                    qr.PackSize = pr.PackSize;
                    qr.QuantityNeeded = pr.Value;
                    _listofSupplies.Add(pr.ProductId, qr);
                }
            }
            return _listofSupplies;
        }
    }
}
