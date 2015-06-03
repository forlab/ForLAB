
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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace LQT.GUI
{
    public partial class LQTProgressBar : Label
    {
        private int _value, _step, _maximum = 100, _minimum = 0;
        //EventLog myLog = new EventLog();

        public LQTProgressBar()
        {
            InitializeComponent();
           // myLog.Source = "ForLABLog1";
        }
        public void PerformStep()
        {
            //myLog.WriteEntry("-- performstep--");
            //myLog.WriteEntry("-- value--"+_value+"--step--"+_step);
            int tempValue = _value + _step;
            //myLog.WriteEntry("--tempValue--" + tempValue);
            if (tempValue > _maximum)
                tempValue = _maximum;
            else if (tempValue < _minimum)
                tempValue = _minimum;

          
            _value = tempValue;
           // myLog.WriteEntry("--Value--" + _value);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawPrgressBarBorder(e.Graphics);
            DrawProgressBar(e.Graphics);
            base.OnPaint(e);
        }

        private void DrawProgressBar(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(0, 88, 56));
            float percent = (float)(_value - _minimum) / (_maximum - _minimum);
            g.FillRectangle(brush, ClientRectangle.Left + 2, ClientRectangle.Top + 2, (int)((ClientRectangle.Width - 4) * percent), ClientRectangle.Height - 4);
        }

        private void DrawPrgressBarBorder(Graphics g)
        {
            ControlPaint.DrawBorder(g, ClientRectangle, Color.FromArgb(0, 88, 56), ButtonBorderStyle.Solid);
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }
    }
}
