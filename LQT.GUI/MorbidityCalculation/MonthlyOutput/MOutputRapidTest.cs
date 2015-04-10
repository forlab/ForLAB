
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
using System.Linq;
using System.Text;

namespace LQT.GUI.MorbidityCalculation
{
    public class MOutputRapidTest
    {
        private int _month;
        public MOutputRapidTest(int month)
        {
            this._month = month;
        }
        public int Month
        {
            get { return _month; }
        }

        public double HIVAdultsThatDonotFollowup { get; set; }
        public double HIVPediatrcisThatDonotFollowup { get; set; }
        public double PrevalenceOfAdultTestingPop{get;set;}
        public double PrevalenceOfPediatricTestingPop{get;set;}


        public double AdultsEnteringTreatment {
            get; 
            set; 
        }
        public double PediatricsEnteringTreatment { get; set; }
        
        public double AdultsEnteringPreART { get; set; }
        public double PediatricsEnteringPreART { get; set; }

        public double AdultsGoingIntoPreARTorART
        {
            get { return AdultsEnteringTreatment + AdultsEnteringPreART; }
        }
        public double PediatricsGoingIntoPreARTorART
        {
            get { return PediatricsEnteringTreatment + PediatricsEnteringPreART; }
        }
        public double AdultsDepartAfterPositiveDiagnosis 
        {
            get { return AdultsGoingIntoPreARTorART / (1 - HIVAdultsThatDonotFollowup) * HIVAdultsThatDonotFollowup; }
        }
        public double PediatricsDepartAfterPositiveDiagnosis 
        {
            get { return PediatricsGoingIntoPreARTorART / (1 - HIVPediatrcisThatDonotFollowup) * HIVPediatrcisThatDonotFollowup; }
        }

        public double AdultsPositiveDiagnoses
        {
            get { return AdultsEnteringTreatment + AdultsEnteringPreART + AdultsDepartAfterPositiveDiagnosis; }
        }
        public double PediatricsPositiveDiagnoses
        {
            get { return PediatricsEnteringTreatment + PediatricsEnteringPreART + PediatricsDepartAfterPositiveDiagnosis; }
        }

        public double AdultsNegativeDiagnoses
        {
            get { return ((1 - PrevalenceOfAdultTestingPop) * AdultsPositiveDiagnoses) / PrevalenceOfAdultTestingPop; }
        }

        public double PediatricsNegativeDiagnoses
        {
            get { return ((1 - PrevalenceOfPediatricTestingPop) * PediatricsPositiveDiagnoses) / PrevalenceOfPediatricTestingPop; }
        }

        public double TotalAdultsTested
        {
            get { return AdultsPositiveDiagnoses + AdultsNegativeDiagnoses; }
        }
        public double TotalPediatricsTested
        {
            get { return PediatricsPositiveDiagnoses + PediatricsNegativeDiagnoses; }
        }

        public double TotalPatientsToScreen
        {
            get { 

                //return TotalAdultsTested + TotalPediatricsTested;  on may 16
                return (Double.NaN.Equals(TotalAdultsTested) ? 0 : TotalAdultsTested) + (Double.NaN.Equals(TotalPediatricsTested) ? 0 : TotalPediatricsTested);
            }
        }
        public double HIVPositivePopulation
        {
            get{return AdultsPositiveDiagnoses +PediatricsPositiveDiagnoses;}
        }
        public double HIVNegativePopulation
        {
            get { return AdultsNegativeDiagnoses + PediatricsNegativeDiagnoses; }
        }

    }
}
