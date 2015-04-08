
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
using System.Collections;
using System.Collections.Generic;
using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class BaseCalc
    {
        private BaseCalc()
        {
        }

        protected BaseCalc(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target, RapidTestAlgorithm rtestAlgorithm)
        {
            ArtSite = site;
            Forecast = forecast;
            PeriodInfo = periodinfo;
            TargetSelected = target;
            RTestAlgorithm = rtestAlgorithm;
        }

        protected BaseCalc(ARTSite site, MorbidityForecast forecast, BudgetPeriodInfo periodinfo, int target)
        {
            ArtSite = site;
            Forecast = forecast;
            PeriodInfo = periodinfo;
            TargetSelected = target;
            RTestAlgorithm = null;
        }

        public int TargetSelected { get; private set; }
        public ARTSite ArtSite { get; private set; }
        public MorbidityForecast Forecast { get; private set; }
        public BudgetPeriodInfo PeriodInfo { get; private set; }
        public RapidTestAlgorithm RTestAlgorithm { get; private set; } 

        public InventoryAssumption InvAssumption { get; set; }
        public double CurrentAdultinTreatment { get; set; }
        public double CurrentPediatricinTreatment { get; set; }
        public double CurrentAdultinPreArt { get; set; }
        public double CurrentPediatricinPreArt { get; set; }

        private Protocol _otherTestProtocol;
        public Protocol OtherTestProtocol 
        {
            get
            {
                if (_otherTestProtocol == null)
                    _otherTestProtocol = new Protocol();
                return _otherTestProtocol;
            }
            set { _otherTestProtocol = value; }
        }
        
        private Protocol _chemTestProtocol;
        public Protocol ChemTestProtocol
        {
            get
            {
                if (_chemTestProtocol == null)
                    _chemTestProtocol = new Protocol();
                return _chemTestProtocol;
            }
            set { _chemTestProtocol = value; }
        }
        private Protocol _cd4TestProtocol;
        public Protocol CD4TestProtocol
        {
            get
            {
                if (_cd4TestProtocol == null)
                    _cd4TestProtocol = new Protocol();
                return _cd4TestProtocol;
            }
            set { _cd4TestProtocol = value; }
        }

        private Protocol _hemTestProtocol;
        public Protocol HemTestProtocol
        {
            get
            {
                if (_hemTestProtocol == null)
                    _hemTestProtocol = new Protocol();
                return _hemTestProtocol;
            }
            set { _hemTestProtocol = value; }
        }

        private Protocol _vlTestProtocol;
        public Protocol VLTestProtocol
        {
            get
            {
                if (_vlTestProtocol == null)
                    _vlTestProtocol = new Protocol();
                return _vlTestProtocol;
            }
            set { _vlTestProtocol = value; }
        }

        protected ListOfPrimeryQR _lstPrimaryQuanReagents;        
        public IList<MorbiditySupplyForecast> QuantifyedReagents()
        {
            IList<MorbiditySupplyForecast> result = new List<MorbiditySupplyForecast>();
            foreach (QuantifyedReagent sp in _lstPrimaryQuanReagents.GetSuppliesForecasted().Values)
            {
                MorbiditySupplyForecast mf = new MorbiditySupplyForecast();
                mf.MForecastId = Forecast.Id;
                mf.SiteId = ArtSite.Site.Id;
                mf.Platform = sp.Platform;
                mf.ProductId = sp.ProductId;
                mf.QuantityNeeded = sp.QuantityNeeded;
                mf.FinalQuantity = Math.Ceiling(sp.FinalValue);
                mf.UnitCost = sp.UnitCost;
                mf.PackSize = sp.PackSize;
                mf.Unit = sp.Unit;
                result.Add(mf);
            }
            return result;
        }

        protected IList<QMenuWithValue> _listOfQMenuWithValue = new List<QMenuWithValue>();
        public QMenuWithValue GetQMenuWithValueByQuantifyMenuId(int qmenuid)
        {
            foreach (QMenuWithValue q in _listOfQMenuWithValue)
            {
                if (q.QuantifyMenuId == qmenuid)
                    return q;
            }
            return null;
        }
    }
}
