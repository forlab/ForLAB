
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
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
