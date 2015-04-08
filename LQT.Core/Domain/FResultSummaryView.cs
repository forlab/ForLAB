
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

namespace LQT.Core.Domain
{ 
	public class FResultSummaryView
	{
		
		private string _productName = string.Empty;
		private string _serialNo = string.Empty;
		private int _forecastId = 0;
        private DateTime _durationDateTime;
		private int _packQty = 0;
		private int _packPrice = 0;
		private int _totalPackQty = 0;
		private int _totalPackPrice = 0;

		public string ProductName
		{
			get
			{
				return _productName;
			}
			set
			{
					_productName = value;
				
			}
		}

		public string SerialNo
		{
			get
			{
				return _serialNo;
			}
			set
			{
					_serialNo = value;
			}
		}

		public int ForecastId
		{
			get
			{
				return _forecastId;
			}
            set { _forecastId = value; }
		}

		public DateTime DurationDateTime
		{
			get
			{
				return _durationDateTime;
			}
			set
			{
					_durationDateTime = value;
			}
		}

		public int PackQty
		{
			get
			{
				return _packQty;
			}
			set
			{
					_packQty = value;
			}
		}

		public int PackPrice
		{
			get
			{
				return _packPrice;
			}
			set
			{
					_packPrice = value;
			}
		}

		public int TotalPackQty
		{
			get
			{
				return _totalPackQty;
			}
			set
			{
					_totalPackQty = value;
			}
		}

		public int TotalPackPrice
		{
			get
			{
				return _totalPackPrice;
			}
			set
			{
					_totalPackPrice = value;
			}
		}
 
	
	}
}
