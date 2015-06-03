
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
	#region CD4TestNumber

	/// <summary>
	/// CD4TestNumber object for NHibernate mapped table 'CD4TestNumber'.
	/// </summary>
	public class CD4TestNumber
		{
		#region Member Variables
		
		private int _id;
        private int _forecastId;
        private int _siteId;
        private double _existingPIT;
        private double _existingPIPreART;
        private double _cD4BaseLineTest;
        private double _newPatienttoTreatment;
        private double _newPatientstoPreART;
        private double _symptomDirectedTest;
        private double _repeatsdutoClinicalRequest;
        private double _wastage;
        private double _reagentstoRunControls;
        private double _bufferStockandControls;

		#endregion

		#region Constructors

		public CD4TestNumber() {
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

        public virtual int SiteId
		{
			get { return _siteId; }
			set { _siteId = value; }
		}

        public virtual double ExistingPIT
		{
			get { return _existingPIT; }
			set { _existingPIT = value; }
		}

        public virtual double ExistingPIPreART
		{
			get { return _existingPIPreART; }
			set { _existingPIPreART = value; }
		}

        public virtual double CD4BaseLineTest
		{
			get { return _cD4BaseLineTest; }
			set { _cD4BaseLineTest = value; }
		}

        public virtual double NewPatienttoTreatment
		{
			get { return _newPatienttoTreatment; }
			set { _newPatienttoTreatment = value; }
		}

        public virtual double NewPatientstoPreART
		{
			get { return _newPatientstoPreART; }
			set { _newPatientstoPreART = value; }
		}

        public virtual double SymptomDirectedTest
		{
			get { return _symptomDirectedTest; }
			set { _symptomDirectedTest = value; }
		}

        public virtual double RepeatsdutoClinicalRequest
		{
			get { return _repeatsdutoClinicalRequest; }
			set { _repeatsdutoClinicalRequest = value; }
		}

        public virtual double Wastage
		{
			get { return _wastage; }
			set { _wastage = value; }
		}

        public virtual double ReagentstoRunControls
		{
			get { return _reagentstoRunControls; }
			set { _reagentstoRunControls = value; }
		}

        public virtual double BufferStockandControls
		{
			get { return _bufferStockandControls; }
			set { _bufferStockandControls = value; }
		}

		#endregion
		
        
	}

	#endregion
}

