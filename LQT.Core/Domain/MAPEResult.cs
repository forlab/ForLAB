
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LQT.Core.Domain
{
   public class MAPEResult
    {
        #region Member Variables

       private DateTime _durationDateTime;
       private decimal _forecastValue;
       private decimal _historicalValue;
       private decimal _mapeValue;
       private decimal _mapePercentage;
        private string _status;
        private string _productName;
        private string _testName;
        private int _testId;
        private int _productId;
        private string _duration;

        #endregion

        # region Constructors

        public MAPEResult()
        {
           
        }

        #endregion

        #region Public Properties
        public virtual int TestId
        {
            get { return _testId; }
            set { _testId = value; }
        }

        public virtual int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
              

        public virtual DateTime DurationDateTime
        {
            get { return _durationDateTime; }
            set { _durationDateTime = value; }
        }

        public virtual string TestName
        {
            get { return _testName; }
            set { _testName = value; }
        }
        public virtual string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public virtual decimal ForecastValue
        {
            get { return _forecastValue; }
            set { _forecastValue = value; }
        }

        public virtual decimal HistoricalValue
        {
            get { return _historicalValue; }
            set { _historicalValue = value; }
        }

        public virtual decimal MapeValue
        {
            get { return Convert.ToDecimal(_mapePercentage.ToString("#0.00"))/100; }
            set { _mapeValue=value; }
        }

        public virtual decimal MapePercentage
        {
            get {
                
                return Convert.ToDecimal(_mapePercentage.ToString("#0.00"));
                //_mapePercentage;
            }
            set { _mapePercentage = value; }
        }

        public virtual string Status
        {
            get { return _status; }
            set { _status = value; }
        }

       public virtual string Percentage
       {
           get{ 
               
               return String.Format("{0:0.00}%", MapePercentage);
           }
       }

       public virtual string Duration
       {
           get { return _duration; }
           set { _duration = value; }
       }
    
        #endregion
    }
}
