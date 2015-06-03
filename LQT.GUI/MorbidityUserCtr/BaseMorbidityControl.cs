
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Util;
using LQT.GUI.Quantification;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class BaseMorbidityControl : UserControl
    {
        public event EventHandler<NextButtonStatusEventArgs> NextButtonStatusChanged;
        ////private 
        //public BaseMorbidityControl()
        //{
        //    InitializeComponent();
        //}

        public virtual string Title
        {
            get { return null; }
        }
        
        public virtual string Description
        {
            get { return ""; }
        }

        private MorbidityForm _morbidityForm;
        public MorbidityForm MorbidityForm
        {
            get { return _morbidityForm; }
            set { _morbidityForm = value; }
        }
        
        public virtual MorbidityCtrEnum PriviousCtr
        {
            get { return MorbidityCtrEnum.Nothing; }
        }

        public virtual MorbidityCtrEnum NextCtr
        {
            get { return MorbidityCtrEnum.Nothing; }
        }

        public virtual bool EnableNextButton()
        {
            return true;
        }

        public virtual bool DoSomthingBeforeUnload()
        {
            return true;
        }

        public virtual void OnNextButtonStatusChanged(bool status)
        {
            if (NextButtonStatusChanged != null)
            {
                NextButtonStatusChanged(this, new NextButtonStatusEventArgs(status));
            }
        }

    }

    public class NextButtonStatusEventArgs : EventArgs
    {
        private bool _boolValue;

        public NextButtonStatusEventArgs(bool value)
        {
            _boolValue = value;
        }

        public bool BoolValue
        {
            get { return _boolValue; }
        }
    }
}
