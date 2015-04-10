
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

namespace LQT.GUI.MorbidityCalculation
{
    public class CalculatedSitePatientNumber
    {
        private int _month;

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        #region Adult / Pediatric Breakdown

        private double _artAdultMonthlyTarget;
        public double ArtAdultMonthlyTarget
        {
            get { return _artAdultMonthlyTarget; }
            set { _artAdultMonthlyTarget = value; }
        }
        private double _artPedMonthlyTarget;
        public double ArtPedMonthlyTarget
        {
            get { return _artPedMonthlyTarget; }
            set { _artPedMonthlyTarget = value; }
        }
        private double _preartAdultMonthlyTarget;
        public double PreArtAdultMonthlyTarget
        {
            get { return _preartAdultMonthlyTarget; }
            set { _preartAdultMonthlyTarget = value; }
        }
        private double _preartPedMonthlyTarget;
        public double PreArtPedMonthlyTarget
        {
            get { return _preartPedMonthlyTarget; }
            set { _preartPedMonthlyTarget = value; }
        }
        private double _artNewAdultPatients;
        public double ArtNewAdultPatients
        {
            get { return _artNewAdultPatients; }
            set { _artNewAdultPatients = value; }
        }
        private double _artNewPedPatients;
        public double ArtNewPedPatients
        {
            get { return _artNewPedPatients; }
            set { _artNewPedPatients = value; }
        }
        private double _preartNewAdultPatients;
        public double PreartNewAdultPatients
        {
            get { return _preartNewAdultPatients; }
            set { _preartNewAdultPatients = value; }
        }
        private double _preartNewPedPatients;
        public double PreArtNewPedPatients
        {
            get { return _preartNewPedPatients; }
            set { _preartNewPedPatients = value; }
        }

        #endregion

        #region Adult Targets Adjusted for Migration

        private double _adultEnteringpreARTeachmonth;
        private double _adultAdjustedpreARTtargets;
        private double _adultMigratingintoARTfromPreART;
        private double _adultEnteringARTfromoutsidePreART;
        private double _adultHIVdiagnosesRequired;
        private double _adultEnteringTreatmentEachMonth;

        public double AdultEnteringpreARTeachmonth
        {
            get { return _adultEnteringpreARTeachmonth; }
            set { _adultEnteringpreARTeachmonth = value; }
        }
        public double AdultAdjustedpreARTtargets
        {
            get { return _adultAdjustedpreARTtargets; }
            set { _adultAdjustedpreARTtargets = value; }
        }
        public double AdultMigratingintoARTfromPreART
        {
            get { return _adultMigratingintoARTfromPreART; }
            set { _adultMigratingintoARTfromPreART = value; }
        }
        public double AdultEnteringARTfromoutsidePreART
        {
            get { return _adultEnteringARTfromoutsidePreART; }
            set { _adultEnteringARTfromoutsidePreART = value; }
        }
        public double AdultHIVdiagnosesRequired
        {
            get { return _adultHIVdiagnosesRequired; }
            set { _adultHIVdiagnosesRequired = value; }
        }
        public double AdultEnteringTreatmentEachMonth
        {
            get { return _adultEnteringTreatmentEachMonth; }
            set { _adultEnteringTreatmentEachMonth = value; }
        }
        #endregion

        #region Pediatic Targets Adjusted for Migration

        private double _pedEnteringpreARTeachmonth;
        private double _pedAdjustedpreARTtargets;
        private double _pedMigratingintoARTfromPreART;
        private double _pedEnteringARTfromoutsidePreART;
        private double _pedHIVdiagnosesRequired;
        private double _pedEnteringTreatmentEachMonth;

        public double PediatricEnteringpreARTeachmonth
        {
            get { return _pedEnteringpreARTeachmonth; }
            set { _pedEnteringpreARTeachmonth = value; }
        }
        public double PediatricAdjustedpreARTtargets
        {
            get { return _pedAdjustedpreARTtargets; }
            set { _pedAdjustedpreARTtargets = value; }
        }
        public double PediatricMigratingintoARTfromPreART
        {
            get { return _pedMigratingintoARTfromPreART; }
            set { _pedMigratingintoARTfromPreART = value; }
        }
        public double PediatricEnteringARTfromoutsidePreART
        {
            get { return _pedEnteringARTfromoutsidePreART; }
            set { _pedEnteringARTfromoutsidePreART = value; }
        }
        public double PediatricHIVdiagnosesRequired
        {
            get { return _pedHIVdiagnosesRequired; }
            set { _pedHIVdiagnosesRequired = value; }
        }
        public double PediatricEnteringTreatmentEachMonth
        {
            get { return _pedEnteringTreatmentEachMonth; }
            set { _pedEnteringTreatmentEachMonth = value; }
        }
        #endregion

        #region adult in treatment Patient Cohorts

        private double _artAdultpreExistingPatients;
        private double _artAdultpatientsEnteringMonth1 = 0;
        private double _artAdultpatientsEnteringMonth2 = 0;
        private double _artAdultpatientsEnteringMonth3 = 0;
        private double _artAdultpatientsEnteringMonth4 = 0;
        private double _artAdultpatientsEnteringMonth5 = 0;
        private double _artAdultpatientsEnteringMonth6 = 0;
        private double _artAdultpatientsEnteringMonth7 = 0;
        private double _artAdultpatientsEnteringMonth8 = 0;
        private double _artAdultpatientsEnteringMonth9 = 0;
        private double _artAdultpatientsEnteringMonth10 = 0;
        private double _artAdultpatientsEnteringMonth11 = 0;
        private double _artAdultpatientsEnteringMonth12 = 0;

        public double ArtAdultPreExistingPatients
        {
            get { return _artAdultpreExistingPatients; }
            set { _artAdultpreExistingPatients = value; }
        }

        public double GetArtAdultPatientsEntering(int month)
        {
            double result = 0;
            switch (month)
            {
                case 1:
                    result = _artAdultpatientsEnteringMonth1;
                    break;
                case 2:
                    result = _artAdultpatientsEnteringMonth2;
                    break;
                case 3:
                    result = _artAdultpatientsEnteringMonth3;
                    break;
                case 4:
                    result = _artAdultpatientsEnteringMonth4;
                    break;
                case 5:
                    result = _artAdultpatientsEnteringMonth5;
                    break;
                case 6:
                    result = _artAdultpatientsEnteringMonth6;
                    break;
                case 7:
                    result = _artAdultpatientsEnteringMonth7;
                    break;
                case 8:
                    result = _artAdultpatientsEnteringMonth8;
                    break;
                case 9:
                    result = _artAdultpatientsEnteringMonth9;
                    break;
                case 10:
                    result = _artAdultpatientsEnteringMonth10;
                    break;
                case 11:
                    result = _artAdultpatientsEnteringMonth11;
                    break;
                case 12:
                    result = _artAdultpatientsEnteringMonth12;
                    break;
            }
            return result;
        }

        public void SetArtAdultPatientsEntering(int month, double value)
        {
            switch (month)
            {
                case 1:
                    _artAdultpatientsEnteringMonth1 = value;
                    break;
                case 2:
                    _artAdultpatientsEnteringMonth2 = value;
                    break;
                case 3:
                    _artAdultpatientsEnteringMonth3 = value;
                    break;
                case 4:
                    _artAdultpatientsEnteringMonth4 = value;
                    break;
                case 5:
                    _artAdultpatientsEnteringMonth5 = value;
                    break;
                case 6:
                    _artAdultpatientsEnteringMonth6 = value;
                    break;
                case 7:
                    _artAdultpatientsEnteringMonth7 = value;
                    break;
                case 8:
                    _artAdultpatientsEnteringMonth8 = value;
                    break;
                case 9:
                    _artAdultpatientsEnteringMonth9 = value;
                    break;
                case 10:
                    _artAdultpatientsEnteringMonth10 = value;
                    break;
                case 11:
                    _artAdultpatientsEnteringMonth11 = value;
                    break;
                case 12:
                    _artAdultpatientsEnteringMonth12 = value;
                    break;
            }
        }

        /// <summary>
        ///  returns the sum of new adult patients entering in this month
        /// </summary>
        /// <returns></returns>
        public double TotalArtAdultPatientsEntering()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += GetArtAdultPatientsEntering(i);
            }

            return result;
        }

        /// <summary>
        /// returns the sum of new adult patients entering in this month plus pre-existing patients
        /// </summary>
        /// <returns></returns>
        public double TotalAdultInTreatment()
        {
            return ArtAdultPreExistingPatients + TotalArtAdultPatientsEntering();
        }

        #endregion

        #region adult in pre-art Patient Cohorts

        private double _preArtAdultpreExistingPatients;
        private double _preArtAdultpatientsEnteringMonth1 = 0;
        private double _preArtAdultpatientsEnteringMonth2 = 0;
        private double _preArtAdultpatientsEnteringMonth3 = 0;
        private double _preArtAdultpatientsEnteringMonth4 = 0;
        private double _preArtAdultpatientsEnteringMonth5 = 0;
        private double _preArtAdultpatientsEnteringMonth6 = 0;
        private double _preArtAdultpatientsEnteringMonth7 = 0;
        private double _preArtAdultpatientsEnteringMonth8 = 0;
        private double _preArtAdultpatientsEnteringMonth9 = 0;
        private double _preArtAdultpatientsEnteringMonth10 = 0;
        private double _preArtAdultpatientsEnteringMonth11 = 0;
        private double _preArtAdultpatientsEnteringMonth12 = 0;

        public double PreArtAdultPreExistingPatients
        {
            get { return _preArtAdultpreExistingPatients; }
            set { _preArtAdultpreExistingPatients = value; }
        }

        public double GetPreArtAdultPatientsEntering(int month)
        {
            double result = 0;
            switch (month)
            {
                case 1:
                    result = _preArtAdultpatientsEnteringMonth1;
                    break;
                case 2:
                    result = _preArtAdultpatientsEnteringMonth2;
                    break;
                case 3:
                    result = _preArtAdultpatientsEnteringMonth3;
                    break;
                case 4:
                    result = _preArtAdultpatientsEnteringMonth4;
                    break;
                case 5:
                    result = _preArtAdultpatientsEnteringMonth5;
                    break;
                case 6:
                    result = _preArtAdultpatientsEnteringMonth6;
                    break;
                case 7:
                    result = _preArtAdultpatientsEnteringMonth7;
                    break;
                case 8:
                    result = _preArtAdultpatientsEnteringMonth8;
                    break;
                case 9:
                    result = _preArtAdultpatientsEnteringMonth9;
                    break;
                case 10:
                    result = _preArtAdultpatientsEnteringMonth10;
                    break;
                case 11:
                    result = _preArtAdultpatientsEnteringMonth11;
                    break;
                case 12:
                    result = _preArtAdultpatientsEnteringMonth12;
                    break;
            }
            return result;
        }

        public void SetPreArtAdultPatientsEntering(int month, double value)
        {
            switch (month)
            {
                case 1:
                    _preArtAdultpatientsEnteringMonth1 = value;
                    break;
                case 2:
                    _preArtAdultpatientsEnteringMonth2 = value;
                    break;
                case 3:
                    _preArtAdultpatientsEnteringMonth3 = value;
                    break;
                case 4:
                    _preArtAdultpatientsEnteringMonth4 = value;
                    break;
                case 5:
                    _preArtAdultpatientsEnteringMonth5 = value;
                    break;
                case 6:
                    _preArtAdultpatientsEnteringMonth6 = value;
                    break;
                case 7:
                    _preArtAdultpatientsEnteringMonth7 = value;
                    break;
                case 8:
                    _preArtAdultpatientsEnteringMonth8 = value;
                    break;
                case 9:
                    _preArtAdultpatientsEnteringMonth9 = value;
                    break;
                case 10:
                    _preArtAdultpatientsEnteringMonth10 = value;
                    break;
                case 11:
                    _preArtAdultpatientsEnteringMonth11 = value;
                    break;
                case 12:
                    _preArtAdultpatientsEnteringMonth12 = value;
                    break;
            }
        }

        /// <summary>
        ///  returns the sum of new pre-art adult patients entering in this month
        /// </summary>
        /// <returns></returns>
        public double TotalPreArtAdultPatientsEntering()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += GetPreArtAdultPatientsEntering(i);
            }

            return result;
        }
        public double TotalAdultInPreART()
        {
            return PreArtAdultPreExistingPatients + TotalPreArtAdultPatientsEntering();
        }
        #endregion

        #region pediatric in treatment Patient Cohorts

        private double _artPedpreExistingPatients;
        private double _artPedpatientsEnteringMonth1 = 0;
        private double _artPedpatientsEnteringMonth2 = 0;
        private double _artPedpatientsEnteringMonth3 = 0;
        private double _artPedpatientsEnteringMonth4 = 0;
        private double _artPedpatientsEnteringMonth5 = 0;
        private double _artPedpatientsEnteringMonth6 = 0;
        private double _artPedpatientsEnteringMonth7 = 0;
        private double _artPedpatientsEnteringMonth8 = 0;
        private double _artPedpatientsEnteringMonth9 = 0;
        private double _artPedpatientsEnteringMonth10 = 0;
        private double _artPedpatientsEnteringMonth11 = 0;
        private double _artPedpatientsEnteringMonth12 = 0;

        public double ArtPediatricPreExistingPatients
        {
            get { return _artPedpreExistingPatients; }
            set { _artPedpreExistingPatients = value; }
        }

        public double GetArtPediatricPatientsEntering(int month)
        {
            double result = 0;
            switch (month)
            {
                case 1:
                    result = _artPedpatientsEnteringMonth1;
                    break;
                case 2:
                    result = _artPedpatientsEnteringMonth2;
                    break;
                case 3:
                    result = _artPedpatientsEnteringMonth3;
                    break;
                case 4:
                    result = _artPedpatientsEnteringMonth4;
                    break;
                case 5:
                    result = _artPedpatientsEnteringMonth5;
                    break;
                case 6:
                    result = _artPedpatientsEnteringMonth6;
                    break;
                case 7:
                    result = _artPedpatientsEnteringMonth7;
                    break;
                case 8:
                    result = _artPedpatientsEnteringMonth8;
                    break;
                case 9:
                    result = _artPedpatientsEnteringMonth9;
                    break;
                case 10:
                    result = _artPedpatientsEnteringMonth10;
                    break;
                case 11:
                    result = _artPedpatientsEnteringMonth11;
                    break;
                case 12:
                    result = _artPedpatientsEnteringMonth12;
                    break;
            }
            return result;
        }

        public void SetArtPediatricPatientsEntering(int month, double value)
        {
            switch (month)
            {
                case 1:
                    _artPedpatientsEnteringMonth1 = value;
                    break;
                case 2:
                    _artPedpatientsEnteringMonth2 = value;
                    break;
                case 3:
                    _artPedpatientsEnteringMonth3 = value;
                    break;
                case 4:
                    _artPedpatientsEnteringMonth4 = value;
                    break;
                case 5:
                    _artPedpatientsEnteringMonth5 = value;
                    break;
                case 6:
                    _artPedpatientsEnteringMonth6 = value;
                    break;
                case 7:
                    _artPedpatientsEnteringMonth7 = value;
                    break;
                case 8:
                    _artPedpatientsEnteringMonth8 = value;
                    break;
                case 9:
                    _artPedpatientsEnteringMonth9 = value;
                    break;
                case 10:
                    _artPedpatientsEnteringMonth10 = value;
                    break;
                case 11:
                    _artPedpatientsEnteringMonth11 = value;
                    break;
                case 12:
                    _artPedpatientsEnteringMonth12 = value;
                    break;
            }
        }

        /// <summary>
        ///  returns the sum of new pediatric patients entering in this month
        /// </summary>
        /// <returns></returns>
        public double TotalArtPediatricPatientsEntering()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += GetArtPediatricPatientsEntering(i);
            }

            return result;
        }

        public double TotalPedInTreatment()
        {
            return ArtPediatricPreExistingPatients + TotalArtPediatricPatientsEntering();
        }
        #endregion

        #region pediatric in pre-art Patient Cohorts

        private double _preArtPedpreExistingPatients;
        private double _preArtPedpatientsEnteringMonth1 = 0;
        private double _preArtPedpatientsEnteringMonth2 = 0;
        private double _preArtPedpatientsEnteringMonth3 = 0;
        private double _preArtPedpatientsEnteringMonth4 = 0;
        private double _preArtPedpatientsEnteringMonth5 = 0;
        private double _preArtPedpatientsEnteringMonth6 = 0;
        private double _preArtPedpatientsEnteringMonth7 = 0;
        private double _preArtPedpatientsEnteringMonth8 = 0;
        private double _preArtPedpatientsEnteringMonth9 = 0;
        private double _preArtPedpatientsEnteringMonth10 = 0;
        private double _preArtPedpatientsEnteringMonth11 = 0;
        private double _preArtPedpatientsEnteringMonth12 = 0;

        public double PreArtPediatricPreExistingPatients
        {
            get { return _preArtPedpreExistingPatients; }
            set { _preArtPedpreExistingPatients = value; }
        }

        public double GetPreArtPediatricPatientsEntering(int month)
        {
            double result = 0;
            switch (month)
            {
                case 1:
                    result = _preArtPedpatientsEnteringMonth1;
                    break;
                case 2:
                    result = _preArtPedpatientsEnteringMonth2;
                    break;
                case 3:
                    result = _preArtPedpatientsEnteringMonth3;
                    break;
                case 4:
                    result = _preArtPedpatientsEnteringMonth4;
                    break;
                case 5:
                    result = _preArtPedpatientsEnteringMonth5;
                    break;
                case 6:
                    result = _preArtPedpatientsEnteringMonth6;
                    break;
                case 7:
                    result = _preArtPedpatientsEnteringMonth7;
                    break;
                case 8:
                    result = _preArtPedpatientsEnteringMonth8;
                    break;
                case 9:
                    result = _preArtPedpatientsEnteringMonth9;
                    break;
                case 10:
                    result = _preArtPedpatientsEnteringMonth10;
                    break;
                case 11:
                    result = _preArtPedpatientsEnteringMonth11;
                    break;
                case 12:
                    result = _preArtPedpatientsEnteringMonth12;
                    break;
            }
            return result;
        }

        public void SetPreArtPediatricPatientsEntering(int month, double value)
        {
            switch (month)
            {
                case 1:
                    _preArtPedpatientsEnteringMonth1 = value;
                    break;
                case 2:
                    _preArtPedpatientsEnteringMonth2 = value;
                    break;
                case 3:
                    _preArtPedpatientsEnteringMonth3 = value;
                    break;
                case 4:
                    _preArtPedpatientsEnteringMonth4 = value;
                    break;
                case 5:
                    _preArtPedpatientsEnteringMonth5 = value;
                    break;
                case 6:
                    _preArtPedpatientsEnteringMonth6 = value;
                    break;
                case 7:
                    _preArtPedpatientsEnteringMonth7 = value;
                    break;
                case 8:
                    _preArtPedpatientsEnteringMonth8 = value;
                    break;
                case 9:
                    _preArtPedpatientsEnteringMonth9 = value;
                    break;
                case 10:
                    _preArtPedpatientsEnteringMonth10 = value;
                    break;
                case 11:
                    _preArtPedpatientsEnteringMonth11 = value;
                    break;
                case 12:
                    _preArtPedpatientsEnteringMonth12 = value;
                    break;
            }
        }

        /// <summary>
        ///  returns the sum of new pre-art pediatric patients entering in this month
        /// </summary>
        /// <returns></returns>
        public double TotalPreArtPediatricPatientsEntering()
        {
            double result = 0;
            for (int i = 1; i <= 12; i++)
            {
                result += GetPreArtPediatricPatientsEntering(i);
            }

            return result;
        }
        public double TotalPedInPreART()
        {
            return PreArtPediatricPreExistingPatients + TotalPreArtPediatricPatientsEntering();
        }
        #endregion

        public double TotalPatinetInTreatment()
        {
            return TotalAdultInTreatment() + TotalPedInTreatment();
        }
        public double TotalPatientInPreART()
        {
            return TotalAdultInPreART() + TotalPedInPreART();
        }
    }
}
