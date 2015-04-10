
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
using LQT.Core.Util;
namespace LQT.Core.Domain
{	
	/// <summary>
	/// Protocol object for NHibernate mapped table 'Protocol'.
	/// </summary>
	public class Protocol
		{
		
		private int _id;
		private int _protocolType;

        private double _testReapeated = 0d;
        private double _symptomDirectedAmt = 0d;
        private string _descritpion;
		private IList _protocolPanels;
		private IList _symptomDirectedTests;
		
		
		#region Constructors

		public Protocol() 
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

		public virtual int ProtocolType
		{
			get { return _protocolType; }
			set { _protocolType = value; }
		}


        public virtual ClassOfMorbidityTestEnum ProtocolTypeEnum
        {
            get
            {
                return (ClassOfMorbidityTestEnum)Enum.ToObject(typeof(ClassOfMorbidityTestEnum), _protocolType);
            }
        }

		public virtual double TestReapeated
		{
			get { return _testReapeated; }
			set { _testReapeated = value; }
		}

		public virtual double SymptomDirectedAmt
		{
			get { return _symptomDirectedAmt; }
			set { _symptomDirectedAmt = value; }
		}

        public virtual string Descritpion
        {
            get { return _descritpion; }
            set
            {
                if (value != null && value.Length > 500)
                    throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());
                _descritpion = value;
            }
        }

		public virtual IList ProtocolPanels
		{
			get
			{
				if (_protocolPanels==null)
				{
					_protocolPanels = new ArrayList();
				}
				return _protocolPanels;
			}
			set { _protocolPanels = value; }
		}

		public virtual IList SymptomDirectedTests
		{
			get
			{
				if (_symptomDirectedTests==null)
				{
					_symptomDirectedTests = new ArrayList();
				}
				return _symptomDirectedTests;
			}
			set { _symptomDirectedTests = value; }
		}

        
		#endregion


        public virtual ProtocolPanel GetProtocolPanelById(int id)
        {
            foreach (ProtocolPanel ps in _protocolPanels)
            {
                if (ps.Id == id)
                    return ps;
            }
            return null;
        }

        public virtual PSymptomDirectedTest GetSymptomDirectedTestById(int id)
        {
            foreach (PSymptomDirectedTest sdt in _symptomDirectedTests)
            {
                if (sdt.Id == id)
                    return sdt;
            }
            return null;
        }

        public virtual PSymptomDirectedTest GetSymptomDirectedTestByTestName(ChemistryTestNameEnum testname)
        {
            foreach (PSymptomDirectedTest sdt in _symptomDirectedTests)
            {
                if (sdt.ChemTestNameToEnum == testname)
                    return sdt;
            }
            return null;
        }

        public virtual PSymptomDirectedTest GetSymptomDirectedTestByTestName(OtherTestNameEnum testname)
        {
            foreach (PSymptomDirectedTest sdt in _symptomDirectedTests)
            {
                if (sdt.OtherTestNameToEnum == testname)
                    return sdt;
            }
            return null;
        }
        //public virtual PSymptomDirectedTest 

	}

}
