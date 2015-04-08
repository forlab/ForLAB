
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
	#region PatientsNoofTest

	/// <summary>
	/// PatientsNoofTest object for NHibernate mapped table 'PatientsNoofTest'.
	/// </summary>
	public class PatientsNoofTest 
		{
		#region Member Variables
		
		private int _id;
        private int _forecastId;
        private int _siteId;
        private double _pITMonth1;
        private double _pITMonth2;
        private double _pITMonth3;
        private double _pITMonth4;
        private double _pITMonth5;
        private double _pITMonth6;
        private double _pITMonth7;
        private double _pITMonth8;
        private double _pITMonth9;
        private double _pITMonth10;
        private double _pITMonth11;
        private double _pITMonth12;
        private double _pPARTMonth1;
        private double _pPARTMonth2;
        private double _pPARTMonth3;
        private double _pPARTMonth4;
        private double _pPARTMonth5;
        private double _pPARTMonth6;
        private double _pPARTMonth7;
        private double _pPARTMonth8;
        private double _pPARTMonth9;
        private double _pPARTMonth10;
        private double _pPARTMonth11;
        private double _pPARTMonth12;


		#endregion

		#region Constructors

		public PatientsNoofTest()
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

        public virtual double PITMonth1
		{
			get { return _pITMonth1; }
			set { _pITMonth1 = value; }
		}

        public virtual double PITMonth2
		{
			get { return _pITMonth2; }
			set { _pITMonth2 = value; }
		}

        public virtual double PITMonth3
		{
			get { return _pITMonth3; }
			set { _pITMonth3 = value; }
		}

        public virtual double PITMonth4
		{
			get { return _pITMonth4; }
			set { _pITMonth4 = value; }
		}

        public virtual double PITMonth5
		{
			get { return _pITMonth5; }
			set { _pITMonth5 = value; }
		}

        public virtual double PITMonth6
		{
			get { return _pITMonth6; }
			set { _pITMonth6 = value; }
		}

        public virtual double PITMonth7
		{
			get { return _pITMonth7; }
			set { _pITMonth7 = value; }
		}

        public virtual double PITMonth8
		{
			get { return _pITMonth8; }
			set { _pITMonth8 = value; }
		}

        public virtual double PITMonth9
		{
			get { return _pITMonth9; }
			set { _pITMonth9 = value; }
		}

        public virtual double PITMonth10
		{
			get { return _pITMonth10; }
			set { _pITMonth10 = value; }
		}

        public virtual double PITMonth11
		{
			get { return _pITMonth11; }
			set { _pITMonth11 = value; }
		}

        public virtual double PITMonth12
		{
			get { return _pITMonth12; }
			set { _pITMonth12 = value; }
		}

        public virtual double PPARTMonth1
		{
			get { return _pPARTMonth1; }
			set { _pPARTMonth1 = value; }
		}

        public virtual double PPARTMonth2
		{
			get { return _pPARTMonth2; }
			set { _pPARTMonth2 = value; }
		}

        public virtual double PPARTMonth3
		{
			get { return _pPARTMonth3; }
			set { _pPARTMonth3 = value; }
		}

        public virtual double PPARTMonth4
		{
			get { return _pPARTMonth4; }
			set { _pPARTMonth4 = value; }
		}

        public virtual double PPARTMonth5
		{
			get { return _pPARTMonth5; }
			set { _pPARTMonth5 = value; }
		}

        public virtual double PPARTMonth6
		{
			get { return _pPARTMonth6; }
			set { _pPARTMonth6 = value; }
		}

        public virtual double PPARTMonth7
		{
			get { return _pPARTMonth7; }
			set { _pPARTMonth7 = value; }
		}

        public virtual double PPARTMonth8
		{
			get { return _pPARTMonth8; }
			set { _pPARTMonth8 = value; }
		}

        public virtual double PPARTMonth9
		{
			get { return _pPARTMonth9; }
			set { _pPARTMonth9 = value; }
		}

        public virtual double PPARTMonth10
		{
			get { return _pPARTMonth10; }
			set { _pPARTMonth10 = value; }
		}

        public virtual double PPARTMonth11
		{
			get { return _pPARTMonth11; }
			set { _pPARTMonth11 = value; }
		}

        public virtual double PPARTMonth12
		{
			get { return _pPARTMonth12; }
			set { _pPARTMonth12 = value; }
		}

      
		#endregion

        public virtual void SetArtPatinetNumber(int month, double dvalue)
        {
             double value =dvalue;
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

        public virtual void SetPreArtPatinetNumber(int month, double value)
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
	}

	#endregion
}

