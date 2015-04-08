
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
	/// ForecastCategorySite object for NHibernate mapped table 'ForecastCategorySite'.
	/// </summary>
	public class ForecastCategorySite 
	{
		#region Member Variables
		
		private int _id;
		private ForlabSite _site;
		private ForecastCategory _category;

		#endregion

		#region Constructors

		public ForecastCategorySite() 
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

		public virtual ForlabSite Site
		{
			get { return _site; }
			set { _site = value; }
		}

		public virtual ForecastCategory Category
		{
			get { return _category; }
			set { _category = value; }
		}

        
		#endregion
		
       
	}

}
