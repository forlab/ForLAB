
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
