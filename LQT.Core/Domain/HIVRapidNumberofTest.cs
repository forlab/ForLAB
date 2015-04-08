
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
	#region HIVRapidNumberofTest

	/// <summary>
	/// HIVRapidNumberofTest object for NHibernate mapped table 'HIVRapidNumberofTest'.
	/// </summary>
	public class HIVRapidNumberofTest 
		{
		#region Member Variables
		
		private int _id;
        private int _forecastId;
        private int _siteId;
        private double _screening;
        private double _confirmatory;
        private double _tieBreaker;
		

		#endregion

		#region Constructors

		public HIVRapidNumberofTest() 
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

        public virtual double Screening
		{
			get {  if(double.IsNaN(_screening)){ return 0; }else{return _screening;} ; }
			set { _screening = value; }
		}

        public virtual double Confirmatory
		{
            get { if (double.IsNaN(_confirmatory)) { return 0; } else { return _confirmatory; }; }
			set { _confirmatory = value; }
		}

        public virtual double TieBreaker
		{
            get { if (double.IsNaN(_tieBreaker)) { return 0; } else { return _tieBreaker; }; }
			set { _tieBreaker = value; }
		}

       
		#endregion
		
       
	}

	#endregion
}

