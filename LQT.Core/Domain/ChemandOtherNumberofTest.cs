
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
	#region ChemandOtherNumberofTest

	/// <summary>
	/// ChemandOtherNumberofTest object for NHibernate mapped table 'ChemandOtherNumberofTest'.
	/// </summary>
	public class ChemandOtherNumberofTest
    {
		#region Member Variables
		
		private int _id;
        private int _forecastId;
        private int _platform;
        private int _siteId;
        private int _testId;
        private string _testName;
        private double _testBasedOnProtocols;
        private double _symptomDirectedTests;
        private double _repeatedDuetoClinicalReq;
        private double _invalidTestandWastage;
        private double _bufferStock;
        private double _reagentstoRunControls;
		

		#endregion

		#region Constructors

		public ChemandOtherNumberofTest() {
            this._id = -1;
        }

		

		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

        public virtual int ForecastId
		{
			get { return _forecastId; }
			set { _forecastId = value; }
		}

        public virtual int Platform
		{
			get { return _platform; }
			set { _platform = value; }
		}

        public virtual int SiteId
		{
			get { return _siteId; }
			set { _siteId = value; }
		}

        public virtual int TestId
		{
			get { return _testId; }
			set { _testId = value; }
		}

        public virtual string TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }

        public virtual double TestBasedOnProtocols
		{
			get { return _testBasedOnProtocols; }
			set { _testBasedOnProtocols = value; }
		}

        public virtual double SymptomDirectedTests
		{
			get { return _symptomDirectedTests; }
			set { _symptomDirectedTests = value; }
		}

        public virtual double RepeatedDuetoClinicalReq
		{
			get { return _repeatedDuetoClinicalReq; }
			set { _repeatedDuetoClinicalReq = value; }
		}

        public virtual double InvalidTestandWastage
		{
			get { return _invalidTestandWastage; }
			set { _invalidTestandWastage = value; }
		}

        public virtual double BufferStock
		{
			get { return _bufferStock; }
			set { _bufferStock = value; }
		}

        public virtual double ReagentstoRunControls
		{
			get { return _reagentstoRunControls; }
			set { _reagentstoRunControls = value; }
		}

      
		#endregion
		
     
	}

	#endregion
}

