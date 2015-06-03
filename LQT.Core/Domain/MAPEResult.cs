
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
