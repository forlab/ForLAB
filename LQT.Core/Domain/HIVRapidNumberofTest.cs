
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

