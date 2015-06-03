
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
	/// <summary>
	/// InventoryAssumption object for NHibernate mapped table 'InventoryAssumptions'.
	/// </summary>
	public class InventoryAssumption
		{
		
		private int _id;
		private double _rapidTestScreening;
		private double _rapidTestConfirmatery;
		private double _rapidTestTibreaker;
		private double _cD4;
		private double _chemistry;
		private double _himatology;
		private double _viralLoad;
		private double _otherTests;
		private int _securityStock;
		private MorbidityForecast _morbidityForecast;
		
		
		#region Constructors

		public InventoryAssumption() 
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

		public virtual double RapidTestScreening
		{
			get { return _rapidTestScreening; }
			set { _rapidTestScreening = value; }
		}

		public virtual double RapidTestConfirmatery
		{
			get { return _rapidTestConfirmatery; }
			set { _rapidTestConfirmatery = value; }
		}

		public virtual double RapidTestTibreaker
		{
			get { return _rapidTestTibreaker; }
			set { _rapidTestTibreaker = value; }
		}

		public virtual double CD4
		{
			get { return _cD4; }
			set { _cD4 = value; }
		}

		public virtual double Chemistry
		{
			get { return _chemistry; }
			set { _chemistry = value; }
		}

		public virtual double Himatology
		{
			get { return _himatology; }
			set { _himatology = value; }
		}

		public virtual double ViralLoad
		{
			get { return _viralLoad; }
			set { _viralLoad = value; }
		}

		public virtual double OtherTests
		{
			get { return _otherTests; }
			set { _otherTests = value; }
		}

		public virtual int SecurityStock
		{
			get { return _securityStock; }
			set { _securityStock = value; }
		}

		public virtual MorbidityForecast MorbidityForecast
		{
			get { return _morbidityForecast; }
			set { _morbidityForecast = value; }
		}

        
		#endregion
	}

}
