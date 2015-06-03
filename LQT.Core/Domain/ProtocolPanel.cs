
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
	/// ProtocolPanel object for NHibernate mapped table 'ProtocolPanel'.
	/// </summary>
	public class ProtocolPanel
		{
		
		private int _id;
		private string _panelName;
        private double _aITNewPatient = 0d;
        private double _aITPreExisting = 0d;
        private double _aITTestperYear = 0d;
        private int _aITMonth1;
        private int _aITMonth2;
        private int _aITMonth3;
        private int _aITMonth4;
        private int _aITMonth5;
        private int _aITMonth6;
        private int _aITMonth7;
        private int _aITMonth8;
        private int _aITMonth9;
        private int _aITMonth10;
        private int _aITMonth11;
        private int _aITMonth12;
        private double _pITNewPatient = 0d;
        private double _pITPreExisting = 0d;
        private double _pITTestperYear = 0d;
        private int _pITMonth1;
        private int _pITMonth2;
        private int _pITMonth3;
        private int _pITMonth4;
        private int _pITMonth5;
        private int _pITMonth6;
        private int _pITMonth7;
        private int _pITMonth8;
        private int _pITMonth9;
        private int _pITMonth10;
        private int _pITMonth11;
        private int _pITMonth12;
        private double _aPARTNewPatient = 0d;
        private double _aPARTPreExisting = 0d;
        private double _aPARTestperYear = 0d;
        private int _aPARTMonth1;
        private int _aPARTMonth2;
        private int _aPARTMonth3;
        private int _aPARTMonth4;
        private int _aPARTMonth5;
        private int _aPARTMonth6;
        private int _aPARTMonth7;
        private int _aPARTMonth8;
        private int _aPARTMonth9;
        private int _aPARTMonth10;
        private int _aPARTMonth11;
        private int _aPARTMonth12;
        private double _pPARTNewPatient = 0d;
        private double _pPARTPreExisting = 0d;
        private double _pPARTTestperYear = 0d;
        private int _pPARTMonth1;
        private int _pPARTMonth2;
        private int _pPARTMonth3;
        private int _pPARTMonth4;
        private int _pPARTMonth5;
        private int _pPARTMonth6;
        private int _pPARTMonth7;
        private int _pPARTMonth8;
        private int _pPARTMonth9;
        private int _pPARTMonth10;
        private int _pPARTMonth11;
        private int _pPARTMonth12;
		private Protocol _protocol;

		private IList _panelPanelTests;
		
		
		#region Constructors

		public ProtocolPanel() 
		{
			this._id = -1;
		}

		public ProtocolPanel( string panelName, Protocol protocol )
		{
			this._panelName = panelName;
			this._protocol = protocol;
		}

		#endregion

		#region Public Properties

		public virtual int Id
		{
			get {return _id;}
			set {_id = value;}
		}

		public virtual string PanelName
		{
			get { return _panelName; }
			set
			{
				if ( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for PanelName", value, value.ToString());
				_panelName = value;
			}
		}

        public virtual double AITNewPatient
        {
            get { return _aITNewPatient; }
            set { _aITNewPatient = value; }
        }

        public virtual double AITPreExisting
        {
            get { return _aITPreExisting; }
            set { _aITPreExisting = value; }
        }

        public virtual double AITTestperYear
        {
            get { return _aITTestperYear; }
            set { _aITTestperYear = value; }
        }

        public virtual int AITMonth1
        {
            get { return _aITMonth1; }
            set { _aITMonth1 = value; }
        }

        public virtual int AITMonth2
        {
            get { return _aITMonth2; }
            set { _aITMonth2 = value; }
        }

        public virtual int AITMonth3
        {
            get { return _aITMonth3; }
            set { _aITMonth3 = value; }
        }

        public virtual int AITMonth4
        {
            get { return _aITMonth4; }
            set { _aITMonth4 = value; }
        }

        public virtual int AITMonth5
        {
            get { return _aITMonth5; }
            set { _aITMonth5 = value; }
        }

        public virtual int AITMonth6
        {
            get { return _aITMonth6; }
            set { _aITMonth6 = value; }
        }

        public virtual int AITMonth7
        {
            get { return _aITMonth7; }
            set { _aITMonth7 = value; }
        }

        public virtual int AITMonth8
        {
            get { return _aITMonth8; }
            set { _aITMonth8 = value; }
        }

        public virtual int AITMonth9
        {
            get { return _aITMonth9; }
            set { _aITMonth9 = value; }
        }

        public virtual int AITMonth10
        {
            get { return _aITMonth10; }
            set { _aITMonth10 = value; }
        }

        public virtual int AITMonth11
        {
            get { return _aITMonth11; }
            set { _aITMonth11 = value; }
        }

        public virtual int AITMonth12
        {
            get { return _aITMonth12; }
            set { _aITMonth12 = value; }
        }

        public virtual double PITNewPatient
        {
            get { return _pITNewPatient; }
            set { _pITNewPatient = value; }
        }

        public virtual double PITPreExisting
        {
            get { return _pITPreExisting; }
            set { _pITPreExisting = value; }
        }

        public virtual double PITTestperYear
        {
            get { return _pITTestperYear; }
            set { _pITTestperYear = value; }
        }

        public virtual int PITMonth1
        {
            get { return _pITMonth1; }
            set { _pITMonth1 = value; }
        }

        public virtual int PITMonth2
        {
            get { return _pITMonth2; }
            set { _pITMonth2 = value; }
        }

        public virtual int PITMonth3
        {
            get { return _pITMonth3; }
            set { _pITMonth3 = value; }
        }

        public virtual int PITMonth4
        {
            get { return _pITMonth4; }
            set { _pITMonth4 = value; }
        }

        public virtual int PITMonth5
        {
            get { return _pITMonth5; }
            set { _pITMonth5 = value; }
        }

        public virtual int PITMonth6
        {
            get { return _pITMonth6; }
            set { _pITMonth6 = value; }
        }

        public virtual int PITMonth7
        {
            get { return _pITMonth7; }
            set { _pITMonth7 = value; }
        }

        public virtual int PITMonth8
        {
            get { return _pITMonth8; }
            set { _pITMonth8 = value; }
        }

        public virtual int PITMonth9
        {
            get { return _pITMonth9; }
            set { _pITMonth9 = value; }
        }

        public virtual int PITMonth10
        {
            get { return _pITMonth10; }
            set { _pITMonth10 = value; }
        }

        public virtual int PITMonth11
        {
            get { return _pITMonth11; }
            set { _pITMonth11 = value; }
        }

        public virtual int PITMonth12
        {
            get { return _pITMonth12; }
            set { _pITMonth12 = value; }
        }

        public virtual double APARTNewPatient
        {
            get { return _aPARTNewPatient; }
            set { _aPARTNewPatient = value; }
        }

        public virtual double APARTPreExisting
        {
            get { return _aPARTPreExisting; }
            set { _aPARTPreExisting = value; }
        }

        public virtual double APARTestperYear
        {
            get { return _aPARTestperYear; }
            set { _aPARTestperYear = value; }
        }

        public virtual int APARTMonth1
        {
            get { return _aPARTMonth1; }
            set { _aPARTMonth1 = value; }
        }

        public virtual int APARTMonth2
        {
            get { return _aPARTMonth2; }
            set { _aPARTMonth2 = value; }
        }

        public virtual int APARTMonth3
        {
            get { return _aPARTMonth3; }
            set { _aPARTMonth3 = value; }
        }

        public virtual int APARTMonth4
        {
            get { return _aPARTMonth4; }
            set { _aPARTMonth4 = value; }
        }

        public virtual int APARTMonth5
        {
            get { return _aPARTMonth5; }
            set { _aPARTMonth5 = value; }
        }

        public virtual int APARTMonth6
        {
            get { return _aPARTMonth6; }
            set { _aPARTMonth6 = value; }
        }

        public virtual int APARTMonth7
        {
            get { return _aPARTMonth7; }
            set { _aPARTMonth7 = value; }
        }

        public virtual int APARTMonth8
        {
            get { return _aPARTMonth8; }
            set { _aPARTMonth8 = value; }
        }

        public virtual int APARTMonth9
        {
            get { return _aPARTMonth9; }
            set { _aPARTMonth9 = value; }
        }

        public virtual int APARTMonth10
        {
            get { return _aPARTMonth10; }
            set { _aPARTMonth10 = value; }
        }

        public virtual int APARTMonth11
        {
            get { return _aPARTMonth11; }
            set { _aPARTMonth11 = value; }
        }

        public virtual int APARTMonth12
        {
            get { return _aPARTMonth12; }
            set { _aPARTMonth12 = value; }
        }

        public virtual double PPARTNewPatient
        {
            get { return _pPARTNewPatient; }
            set { _pPARTNewPatient = value; }
        }

        public virtual double PPARTPreExisting
        {
            get { return _pPARTPreExisting; }
            set { _pPARTPreExisting = value; }
        }

        public virtual double PPARTTestperYear
        {
            get { return _pPARTTestperYear; }
            set { _pPARTTestperYear = value; }
        }

        public virtual int PPARTMonth1
        {
            get { return _pPARTMonth1; }
            set { _pPARTMonth1 = value; }
        }

        public virtual int PPARTMonth2
        {
            get { return _pPARTMonth2; }
            set { _pPARTMonth2 = value; }
        }

        public virtual int PPARTMonth3
        {
            get { return _pPARTMonth3; }
            set { _pPARTMonth3 = value; }
        }

        public virtual int PPARTMonth4
        {
            get { return _pPARTMonth4; }
            set { _pPARTMonth4 = value; }
        }

        public virtual int PPARTMonth5
        {
            get { return _pPARTMonth5; }
            set { _pPARTMonth5 = value; }
        }

        public virtual int PPARTMonth6
        {
            get { return _pPARTMonth6; }
            set { _pPARTMonth6 = value; }
        }

        public virtual int PPARTMonth7
        {
            get { return _pPARTMonth7; }
            set { _pPARTMonth7 = value; }
        }

        public virtual int PPARTMonth8
        {
            get { return _pPARTMonth8; }
            set { _pPARTMonth8 = value; }
        }

        public virtual int PPARTMonth9
        {
            get { return _pPARTMonth9; }
            set { _pPARTMonth9 = value; }
        }

        public virtual int PPARTMonth10
        {
            get { return _pPARTMonth10; }
            set { _pPARTMonth10 = value; }
        }

        public virtual int PPARTMonth11
        {
            get { return _pPARTMonth11; }
            set { _pPARTMonth11 = value; }
        }

        public virtual int PPARTMonth12
        {
            get { return _pPARTMonth12; }
            set { _pPARTMonth12 = value; }
        }

		public virtual Protocol Protocol
		{
			get { return _protocol; }
			set { _protocol = value; }
		}

		public virtual IList PanelTests
		{
			get
			{
				if (_panelPanelTests==null)
				{
					_panelPanelTests = new ArrayList();
				}
				return _panelPanelTests;
			}
			set { _panelPanelTests = value; }
		}

        public virtual double AdultInTreatmentDistribution
        {
            get
            {
                return (AITTestperYear / 12) * (AITPreExisting / 100d);
            }
        }

        public virtual double PediatricInTreatmentDistribution
        {
            get
            {
                return (PITTestperYear / 12) * (PITPreExisting / 100d);
            }
        }

        public virtual double AdultPreARTDistribution
        {
            get
            {
                return (APARTestperYear / 12) * (APARTestperYear/100d);
            }
        }

        public virtual double PediatricPreARTDistribution
        {
            get
            {
                return (PPARTTestperYear / 12) * (PPARTPreExisting / 100d);
            }
        }

		#endregion

        public virtual int AdultArtTestGivenInMonth(int month)
        {
            int result = 0;
            switch (month)
            {
                case 1:
                    result = _aITMonth1;
                    break;
                case 2:
                    result = _aITMonth2;
                    break;
                case 3:
                    result = _aITMonth3;
                    break;
                case 4:
                    result = _aITMonth4;
                    break;
                case 5:
                    result = _aITMonth5;
                    break;
                case 6:
                    result = _aITMonth6;
                    break;
                case 7:
                    result = _aITMonth7;
                    break;
                case 8:
                    result = _aITMonth8;
                    break;
                case 9:
                    result = _aITMonth9;
                    break;
                case 10:
                    result = _aITMonth10;
                    break;
                case 11:
                    result = _aITMonth11;
                    break;
                case 12:
                    result = _aITMonth12;
                    break;

            }
            return result;
        }
        public virtual void SetAdultArtTestGivenInMonth(int month, int value)
        {
            switch (month)
            {
                case 1:
                    _aITMonth1 = value;
                    break;
                case 2:
                    _aITMonth2 = value;
                    break;
                case 3:
                    _aITMonth3 = value;
                    break;
                case 4:
                    _aITMonth4 = value;
                    break;
                case 5:
                    _aITMonth5 = value;
                    break;
                case 6:
                    _aITMonth6 = value;
                    break;
                case 7:
                    _aITMonth7 = value;
                    break;
                case 8:
                    _aITMonth8 = value;
                    break;
                case 9:
                    _aITMonth9 = value;
                    break;
                case 10:
                    _aITMonth10 = value;
                    break;
                case 11:
                    _aITMonth11 = value;
                    break;
                case 12:
                    _aITMonth12 = value;
                    break;

            }
        }

        public virtual int AdultPreArtTestGivenInMonth(int month)
        {
            int result = 0;
            switch (month)
            {
                case 1:
                    result = _aPARTMonth1;
                    break;
                case 2:
                    result = _aPARTMonth2;
                    break;
                case 3:
                    result = _aPARTMonth3;
                    break;
                case 4:
                    result = _aPARTMonth4;
                    break;
                case 5:
                    result = _aPARTMonth5;
                    break;
                case 6:
                    result = _aPARTMonth6;
                    break;
                case 7:
                    result = _aPARTMonth7;
                    break;
                case 8:
                    result = _aPARTMonth8;
                    break;
                case 9:
                    result = _aPARTMonth9;
                    break;
                case 10:
                    result = _aPARTMonth10;
                    break;
                case 11:
                    result = _aPARTMonth11;
                    break;
                case 12:
                    result = _aPARTMonth12;
                    break;

            }
            return result;
        }
        public virtual void SetAdultPreArtTestGivenInMonth(int month,int value)
        {
            switch (month)
            {
                case 1:
                    _aPARTMonth1 = value;
                    break;
                case 2:
                    _aPARTMonth2 = value;
                    break;
                case 3:
                    _aPARTMonth3 = value;
                    break;
                case 4:
                    _aPARTMonth4 = value;
                    break;
                case 5:
                    _aPARTMonth5 = value;
                    break;
                case 6:
                    _aPARTMonth6 = value;
                    break;
                case 7:
                    _aPARTMonth7 = value;
                    break;
                case 8:
                    _aPARTMonth8 = value;
                    break;
                case 9:
                    _aPARTMonth9 = value;
                    break;
                case 10:
                    _aPARTMonth10 = value;
                    break;
                case 11:
                    _aPARTMonth11 = value;
                    break;
                case 12:
                    _aPARTMonth12 = value;
                    break;

            }
        }

        public virtual int PediatricArtTestGivenInMonth(int month)
        {
            int result = 0;
            switch (month)
            {
                case 1:
                    result = _pITMonth1;
                    break;
                case 2:
                    result = _pITMonth2;
                    break;
                case 3:
                    result = _pITMonth3;
                    break;
                case 4:
                    result = _pITMonth4;
                    break;
                case 5:
                    result = _pITMonth5;
                    break;
                case 6:
                    result = _pITMonth6;
                    break;
                case 7:
                    result = _pITMonth7;
                    break;
                case 8:
                    result = _pITMonth8;
                    break;
                case 9:
                    result = _pITMonth9;
                    break;
                case 10:
                    result = _pITMonth10;
                    break;
                case 11:
                    result = _pITMonth11;
                    break;
                case 12:
                    result = _pITMonth12;
                    break;

            }
            return result;
        }
        public virtual void SetPediatricArtTestGivenInMonth(int month, int value)
        {
            switch (month)
            {
                case 1:
                    _pITMonth1 = value;
                    break;
                case 2:
                    _pITMonth2 = value;
                    break;
                case 3:
                    _pITMonth3 = value;
                    break;
                case 4:
                    _pITMonth4 = value;
                    break;
                case 5:
                    _pITMonth5 = value;
                    break;
                case 6:
                    _pITMonth6 = value;
                    break;
                case 7:
                    _pITMonth7 = value;
                    break;
                case 8:
                    _pITMonth8 = value;
                    break;
                case 9:
                    _pITMonth9 = value;
                    break;
                case 10:
                    _pITMonth10 = value;
                    break;
                case 11:
                    _pITMonth11 = value;
                    break;
                case 12:
                    _pITMonth12 = value;
                    break;

            }
        }
        
        public virtual int PediatricPreArtTestGivenInMonth(int month)
        {
            int result = 0;
            switch (month)
            {
                case 1:
                    result = _pPARTMonth1;
                    break;
                case 2:
                    result = _pPARTMonth2;
                    break;
                case 3:
                    result = _pPARTMonth3;
                    break;
                case 4:
                    result = _pPARTMonth4;
                    break;
                case 5:
                    result = _pPARTMonth5;
                    break;
                case 6:
                    result = _pPARTMonth6;
                    break;
                case 7:
                    result = _pPARTMonth7;
                    break;
                case 8:
                    result = _pPARTMonth8;
                    break;
                case 9:
                    result = _pPARTMonth9;
                    break;
                case 10:
                    result = _pPARTMonth10;
                    break;
                case 11:
                    result = _pPARTMonth11;
                    break;
                case 12:
                    result = _pPARTMonth12;
                    break;

            }
            return result;
        }
        public virtual void SetPediatricPreArtTestGivenInMonth(int month, int value)
        {
            switch (month)
            {
                case 1:
                    _pPARTMonth1 = value;
                    break;
                case 2:
                    _pPARTMonth2 = value;
                    break;
                case 3:
                    _pPARTMonth3 = value;
                    break;
                case 4:
                    _pPARTMonth4 = value;
                    break;
                case 5:
                    _pPARTMonth5 = value;
                    break;
                case 6:
                    _pPARTMonth6 = value;
                    break;
                case 7:
                    _pPARTMonth7 = value;
                    break;
                case 8:
                    _pPARTMonth8 = value;
                    break;
                case 9:
                    _pPARTMonth9 = value;
                    break;
                case 10:
                    _pPARTMonth10 = value;
                    break;
                case 11:
                    _pPARTMonth11 = value;
                    break;
                case 12:
                    _pPARTMonth12 = value;
                    break;

            }

        }

        public virtual PanelTest GetPanelTestById(int id)
        {
            foreach (PanelTest pt in PanelTests)
            {
                if (pt.Id == id)
                    return pt;
            }
            return null;
        }

        public virtual bool IsChemTestSelected(ChemistryTestNameEnum testname)
        {
            foreach (PanelTest pt in PanelTests)
            {
                if (pt.ChemTestNameToEnum == testname)
                    return true;

            }
            return false;
        }

        public virtual PanelTest GetChemPanelTest(ChemistryTestNameEnum testname)
        {
            foreach (PanelTest pt in PanelTests)
            {
                if (pt.ChemTestNameToEnum == testname)
                    return pt;

            }
            return null;
        }

        public virtual bool IsOtherTestSelected(OtherTestNameEnum testname)
        {
            foreach (PanelTest pt in PanelTests)
            {
                if (pt.OtherTestNameToEnum == testname)
                    return true;

            }
            return false;
        }

        public virtual PanelTest GetOtherPanelTest(OtherTestNameEnum testname)
        {
            foreach (PanelTest pt in PanelTests)
            {
                if (pt.OtherTestNameToEnum == testname)
                    return pt;

            }
            return null;
        }
	}

}
