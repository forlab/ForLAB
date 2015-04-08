
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

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// TestingGroup object for NHibernate mapped table 'Fr_TestingGroup'.
	/// </summary>
	public class TestingGroup 
	{
		#region Member Variables
		
		private int _id;
		private string _groupName;
		private int _status;
		private TestingArea _testingArea;
        private IList _tests;

        private static string DEFAULT_GROUP_NAME = "Others";
		
        #endregion

		#region Constructors

		public TestingGroup() 
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

        public virtual string GroupName
		{
			get { return _groupName; }
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for GroupName", value, value.ToString());
				_groupName = value;
			}
		}

        public virtual int Status
		{
			get { return _status; }
			set { _status = value; }
		}

        public virtual TestingArea TestingArea
		{
			get { return _testingArea; }
			set { _testingArea = value; }
		}

        public virtual IList Tests
        {
            get
            {
                if (_tests == null)
                {
                    _tests = new ArrayList();
                }
                return _tests;
            }
            set { _tests = value; }
        }

        public static string GetDefaultGroupName
        {
            get { return DEFAULT_GROUP_NAME; }
        }

		#endregion
		     
	}

}
