
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
using LQT.Core.Util;

namespace LQT.GUI.MorbidityCalculation
{
    public class MOutputCD4
    {
        private int _month;

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        #region CD4 Testing Protocol: Positive Rapid Tests

        private double _adultReceivingCD4Test;
        public double AdultReceivingCD4Test
        {
            get { return _adultReceivingCD4Test; }
            set { _adultReceivingCD4Test = value; }
        }
        private double _pedReceivingCD4Test;
        public double PedReceivingCD4Test
        {
            get { return _pedReceivingCD4Test; }
            set { _pedReceivingCD4Test = value; }
        }

        public double TotalReceivingCD4Test()
        {
            return _adultReceivingCD4Test + _pedReceivingCD4Test;
        }

        #endregion

        #region CD4 Tests Conducted: By Patient Group

        private double _existingAdultPatientsinTreatment;
        private double _existingAdultPatientsinPreArt;
        private double _newAdultPatientstoTreatment;
        private double _newAdultPatientstoPreArt;

        private double _existingPedPatientsinTreatment;
        private double _existingPedPatientsinPreArt;
        private double _newPedPatientstoTreatment;
        private double _newPedPatientstoPreArt;

        public double ExistingAdultPatientsinTreatment
        {
            get { return _existingAdultPatientsinTreatment; }
            set { _existingAdultPatientsinTreatment = value; }
        }
        public double ExistingAdultPatientsinPreArt
        {
            get { return _existingAdultPatientsinPreArt; }
            set { _existingAdultPatientsinPreArt = value; }
        }
        public double NewAdultPatientstoTreatment
        {
            get { return _newAdultPatientstoTreatment; }
            set { _newAdultPatientstoTreatment = value; }
        }
        public double NewAdultPatientstoPreArt
        {
            get { return _newAdultPatientstoPreArt; }
            set { _newAdultPatientstoPreArt = value; }
        }

        public double ExistingPedPatientsinTreatment
        {
            get { return _existingPedPatientsinTreatment; }
            set { _existingPedPatientsinTreatment = value; }
        }
        public double ExistingPedPatientsinPreArt
        {
            get { return _existingPedPatientsinPreArt; }
            set { _existingPedPatientsinPreArt = value; }
        }
        public double NewPedPatientstoTreatment
        {
            get { return _newPedPatientstoTreatment; }
            set { _newPedPatientstoTreatment = value; }
        }
        public double NewPedPatientstoPreArt
        {
            get { return _newPedPatientstoPreArt; }
            set { _newPedPatientstoPreArt = value; }
        }

        public double TestConductedAdultIntreatment()
        {
            return _existingAdultPatientsinTreatment + _newAdultPatientstoTreatment;
        }

        public double TestConductedPedIntreatment()
        {
            return _existingPedPatientsinTreatment + _newPedPatientstoTreatment;
        }
        private double TestConductedAdultInpreArt()
        {
            return _existingAdultPatientsinPreArt + _newAdultPatientstoPreArt;
        }
        public double TestConductedPedInpreArt()
        {
            return _existingPedPatientsinPreArt + _newPedPatientstoPreArt;
        }

        public double ExistingPatientsinTreatment()
        {
            return ExistingAdultPatientsinTreatment + ExistingPedPatientsinTreatment;
        }
        public double ExistingPatientsinPreART()
        {
            return ExistingAdultPatientsinPreArt + ExistingPedPatientsinPreArt;
        }

        public double NewPatientstoTreatment()
        {
            return NewAdultPatientstoTreatment + NewPedPatientstoTreatment;
        }
        public double NewPatientstoPreART()
        {
            return NewAdultPatientstoPreArt + NewPedPatientstoPreArt;
        }

        private double _symptomDirectedTests;
        public double SymptomDirectedTests
        {
            get { return _symptomDirectedTests; }
            set { _symptomDirectedTests = value; }
        }

        public double TestFromProtocols()
        {
            return TestConductedAdultIntreatment() + TestConductedAdultInpreArt() + TestConductedPedIntreatment() + TestConductedPedInpreArt();
        }

        private double _repeatsDuetoClinicianRequest;
        public double RepeatDuetoClinicianRequest
        {
            get { return _repeatsDuetoClinicianRequest; }
            set { _repeatsDuetoClinicianRequest = value; }
        }

        public double TotalTestConducted()
        {
            return TotalReceivingCD4Test() + TestFromProtocols() + SymptomDirectedTests + RepeatDuetoClinicianRequest;
        }

        private double _testsBasedonProtocols;
        public double TestsBasedonProtocols
        {
            get { return _testsBasedonProtocols; }
            set { _testsBasedonProtocols = value; }
        }

        private double _additionalTestsdueToWastage;
        public double AdditionalTestsdueToWastage
        {
            get { return _additionalTestsdueToWastage; }
            set { _additionalTestsdueToWastage = value; }
        }
        public double TotalTestsBasedonProtocols()
        {
            return TestsBasedonProtocols + AdditionalTestsdueToWastage;
        }

        private double _testsforBufferStock;
        public double TestsforBufferStock
        {
            get { return _testsforBufferStock; }
            set { _testsforBufferStock = value; }
        }

        private double _additionalTestsdueToWastageBuffer;
        public double AdditionalTestsdueToWastageForBuffer
        {
            get { return _additionalTestsdueToWastageBuffer; }
            set { _additionalTestsdueToWastageBuffer = value; }
        }

        public double TotalTestsforBufferStock()
        {
            return TestsforBufferStock + AdditionalTestsdueToWastageForBuffer;
        }

        public double TotalCD4TestsReferred()
        {
            return TotalTestsBasedonProtocols() + TotalTestsforBufferStock();
        }

        private double _testsReceivedFromReferringSites;
        public double TestsReceivedFromReferringSites
        {
            get { return _testsReceivedFromReferringSites; }
            set { _testsReceivedFromReferringSites = value; }
        }

        private double _testsonInstrumentForecastPeriodFromReferringSites;
        public double TestsonInstrumentForecastPeriodFromReferringSites
        {
            get { return _testsonInstrumentForecastPeriodFromReferringSites; }
            set { _testsonInstrumentForecastPeriodFromReferringSites = value; }
        }

        private double _testsonInstrumentBufferStockFromReferringSites;
        public double TestsonInstrumentBufferStockFromReferringSites
        {
            get { return _testsonInstrumentBufferStockFromReferringSites; ;}
            set { _testsonInstrumentBufferStockFromReferringSites = value; }
        }

        #endregion

    }

   

 
}
