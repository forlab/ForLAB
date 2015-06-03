
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
	/// PanelTest object for NHibernate mapped table 'PanelTest'.
	/// </summary>
	public class PanelTest
		{
		
		private int _id;
        private string _chemTestName;
        private string _otherTestName;
		private ProtocolPanel _panel;
		private Test _testId;
		
		
		#region Constructors

		public PanelTest() 
		{
			this._id = -1;
		}

		public PanelTest( ProtocolPanel panel, Test testId )
		{
			this._panel = panel;
			this._testId = testId;
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

		public virtual ProtocolPanel Panel
		{
			get { return _panel; }
			set { _panel = value; }
		}

		public virtual Test TestId
		{
			get { return _testId; }
			set { _testId = value; }
		}

        
		#endregion

       
	}

}
