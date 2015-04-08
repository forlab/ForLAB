
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
	/// ForlabParameter object for NHibernate mapped table 'ForlabParameters'.
	/// </summary>
	public class ForlabParameter
		{
		
		private string _id;
		private string _parmValue;
		
		public ForlabParameter() 
		{
			this._id = "-1";
		}

		public ForlabParameter( string parmValue )
		{
			this._parmValue = parmValue;
		}

		#region Public Properties

		public virtual string Id
		{
			get {return _id;}
			set
			{
				if ( value != null && value.Length > 64)
					throw new ArgumentOutOfRangeException("Invalid value for Id", value, value.ToString());
				_id = value;
			}
		}

		public virtual string ParmValue
		{
			get { return _parmValue; }
			set
			{
				if ( value != null && value.Length > 128)
					throw new ArgumentOutOfRangeException("Invalid value for ParmValue", value, value.ToString());
				_parmValue = value;
			}
		}

        
		#endregion
	}

}
