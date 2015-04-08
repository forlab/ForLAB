
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
