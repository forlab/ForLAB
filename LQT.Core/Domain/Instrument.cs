
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
	
	/// <summary>
	/// Instrument object for NHibernate mapped table 'Fr_Instrument'.
	/// </summary>
	public class Instrument 
	{
		#region Member Variables
		
		private int _id;
		private string _instrumentName;
		private int _maxThroughPut;
        private int _monthMaxTPut;
        private TestingArea _testingArea;
        private int _dailyCtrlTest;
        private int _maxTestBeforeCtrlTest;
        private int _weeklyCtrlTest;
        private int _monthlyCtrlTest;
        private int _quarterlyCtrlTest;


		#endregion

		#region Constructors

		public Instrument() 
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

        public virtual string InstrumentName
		{
			get { return _instrumentName; }
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for InstrumentName", value, value.ToString());
				_instrumentName = value;
			}
		}

        public virtual int MaxThroughPut
		{
			get { return _maxThroughPut; }
			set { _maxThroughPut = value; }
		}
        public virtual int MonthMaxTPut
        {
			get
			{
				return _maxThroughPut * 22;
				//_monthMaxTPut;
			}
			set { _monthMaxTPut = _maxThroughPut * 22; }
        }

        public virtual TestingArea TestingArea
        {
            get { return _testingArea; }
            set { _testingArea = value; }
        }

        public virtual int DailyCtrlTest
        {
            get { return _dailyCtrlTest; }
            set { _dailyCtrlTest = value; }
        }

        public virtual int MaxTestBeforeCtrlTest
        {
            get { return _maxTestBeforeCtrlTest; }
            set { _maxTestBeforeCtrlTest = value; }
        }

        public virtual int WeeklyCtrlTest
        {
            get { return _weeklyCtrlTest; }
            set { _weeklyCtrlTest = value; }
        }

        public virtual int MonthlyCtrlTest
        {
            get { return _monthlyCtrlTest; }
            set { _monthlyCtrlTest = value; }
        }

        public virtual int QuarterlyCtrlTest
        {
            get { return _quarterlyCtrlTest; }
            set { _quarterlyCtrlTest = value; }
        }
		#endregion
		
       
	}

}
