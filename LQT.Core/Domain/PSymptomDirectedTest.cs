
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
using LQT.Core.Util;

namespace LQT.Core.Domain
{	
	/// <summary>
	/// SymptomDirectedTest object for NHibernate mapped table 'Symptom-DirectedTest'.
	/// </summary>
	public class PSymptomDirectedTest
		{
		
		private int _id;
        private double _adultInTreatmeant;
        private double _pediatricInTreatmeant;
        private double _adultPreART;
        private double _pediatricPreART;
        private string _chemTestName;
        private string _otherTestName;
		private Protocol _protocol;
		private Test _test;
		
		
		#region Constructors

		public PSymptomDirectedTest() 
		{
			this._id = -1;
		}

		

		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

        public virtual string ChemTestName
        {
            get { return _chemTestName; }
            set { _chemTestName = value; }
        }

        public virtual ChemistryTestNameEnum ChemTestNameToEnum
        {
            get { return (ChemistryTestNameEnum)Enum.Parse(typeof(ChemistryTestNameEnum), _chemTestName); }
        }

        public virtual string OtherTestName
        {
            get { return _otherTestName; }
            set { _otherTestName = value; }
        }

        public virtual OtherTestNameEnum OtherTestNameToEnum
        {
            get { return (OtherTestNameEnum)Enum.Parse(typeof(OtherTestNameEnum), _otherTestName); }
        }
        public virtual double AdultInTreatmeant
		{
			get { return _adultInTreatmeant; }
			set { _adultInTreatmeant = value; }
		}

        public virtual double PediatricInTreatmeant
		{
			get { return _pediatricInTreatmeant; }
			set { _pediatricInTreatmeant = value; }
		}

        public virtual double AdultPreART
		{
			get { return _adultPreART; }
			set { _adultPreART = value; }
		}

        public virtual double PediatricPreART
		{
			get { return _pediatricPreART; }
			set { _pediatricPreART = value; }
		}

		public virtual Protocol Protocol
		{
			get { return _protocol; }
			set { _protocol = value; }
		}

		public virtual Test Test
		{
			get { return _test; }
			set { _test = value; }
		}

        
		#endregion

        public virtual double SumOfSymptomDirected()
        {
            return _adultInTreatmeant + _adultPreART + _pediatricInTreatmeant + _pediatricPreART;
        }
	}

}
