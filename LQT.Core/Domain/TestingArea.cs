
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
