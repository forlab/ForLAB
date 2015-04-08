
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
using System.Collections.Generic;
using LQT.Core.Util;

namespace LQT.Core.Domain
{
	
	/// <summary>
	/// TestingArea object for NHibernate mapped table 'Fr_TestingArea'.
	/// </summary>
	public class TestingArea 
	{
		#region Member Variables
		
		private int _id;
		private string _areaName;
     	private IList<TestingGroup> _testingGroups;

        private static string DEFAULT_AREA_NAME = "Unkown Area";
        private Boolean _useInDemography;
        private string _category;

		#endregion

		#region Constructors

		public TestingArea() 
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

        public virtual string AreaName
		{
			get { return _areaName; }
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for AreaName", value, value.ToString());
				_areaName = value;
			}
		}

      
        public virtual IList<TestingGroup> TestingGroups
		{
			get
			{
				if (_testingGroups==null)
				{
					_testingGroups = new List<TestingGroup>();
				}
				return _testingGroups;
			}
			set { _testingGroups = value; }
		}

        public static string GetDefaultAreaName
        {
            get { return DEFAULT_AREA_NAME; }
        }

        public virtual Boolean UseInDemography
        {
            get { return _useInDemography; }
            set { _useInDemography = value; }
        }

        public virtual string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public virtual ClassOfMorbidityTestEnum ClassOfTestToEnum
        {
            get
            {
                return (ClassOfMorbidityTestEnum)Enum.Parse(typeof(ClassOfMorbidityTestEnum), Category);
            }
        }

		#endregion

        public virtual TestingGroup GetTestingGroupById(int gid)
        {
            foreach (TestingGroup g in TestingGroups)
            {
                if (g.Id == gid)
                    return g;
            }
            return null;
        }
       
	}

}
