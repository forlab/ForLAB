
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

namespace LQT.GUI.MorbidityCalculation
{
    public class MorbidityCalcContainer
    {
        public MorbidityCalcContainer(int siteid)
        {
            SiteId = siteid;
        }

        public int SiteId { get; private set; }
        public CalcCD4Test CD4Calculation { get; set; }
        public CalcChemistryTest ChemistryCalculation { get; set; }
        public CalcConsumable ConsumableCalculation { get; set; }
        public CalcHematology HematologyCalculation { get; set; }
        public CalcOtherTest OtherTestCalculation { get; set; }
        public CalcViralLoad ViralLoadCalculation { get; set; }

        public IList<int> CD4ReferedSites  { get; set; }
        public IList<int> ChemReferedSites { get; set; }
        public IList<int> HemaReferedSites { get; set; }
        public IList<int> ViraReferedSites { get; set; }
    }
}
