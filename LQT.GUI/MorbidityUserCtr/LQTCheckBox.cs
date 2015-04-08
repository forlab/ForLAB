
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

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class LQTCheckBox : UserControl
    {
        public event EventHandler<LQTCheckBoxEvenArgs> LQTCheckBoxClick;
        private bool _check;
        
        public LQTCheckBox()
        {
            InitializeComponent();
            
            Checked = false;
        }

        public bool Checked
        {
            get { return _check; }
            set 
            {
                _check = value;
                LoadPicture();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_check)
                return;
            Checked = true;
            if (LQTCheckBoxClick != null)
            {
                LQTCheckBoxClick(this, new LQTCheckBoxEvenArgs(_check, Tag));
            }
        }

        private void LoadPicture()
        {
            pictureBox1.BackgroundImage = checkUncheckImageList.Images[_check? 0 : 1];
            //pictureBox1.Invalidate();
        }

    }

    public class LQTCheckBoxEvenArgs : EventArgs
    {
        private bool _checked;
        private object _tag;

        public LQTCheckBoxEvenArgs(bool boolvalue, object tag)
        {
            _checked = boolvalue;
            _tag = tag;
        }

        public bool Checked
        {
            get { return _checked; }
        }

        public object Tag
        {
            get { return _tag; }
        }
    }
}
