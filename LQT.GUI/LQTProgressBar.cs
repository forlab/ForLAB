
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
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
