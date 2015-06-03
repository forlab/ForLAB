
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
using System.Collections;


namespace LQT.Core.Domain
{
	#region HemaandViralNumberofTest

	/// <summary>
	/// HemaandViralNumberofTest object for NHibernate mapped table 'HemaandViralNumberofTest'.
	/// </summary>
	public class HemaandViralNumberofTest
		{
		#region Member Variables
		
		private int _id;
        private int _platform;
        private int _forecastId;
        private int _siteId;
        private double _testBasedOnProtocols;
        private double _symptomDirectedTests;
        private double _repeatedDuetoClinicalReq;
        private double _invalidTestandWastage;
        private double _bufferStockandControls;
        private double _reagentstoRunControls;
	
		#endregion

		#region Constructors

		public HemaandViralNumberofTest() {
            this._id = -1;
        }

		

		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

        public virtual int Platform
		{
			get { return _platform; }
			set { _platform = value; }
		}

        public virtual int ForecastId
		{
			get { return _forecastId; }
			set { _forecastId = value; }
		}

        public virtual int SiteId
		{
			get { return _siteId; }
			set { _siteId = value; }
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

        public virtual double BufferStockandControls
		{
			get { return _bufferStockandControls; }
			set { _bufferStockandControls = value; }
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

