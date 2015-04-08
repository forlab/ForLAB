
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
