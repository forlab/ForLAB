
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LQT.GUI
{
    public partial class CustomToolTip : UserControl
    {
        public CustomToolTip(string title, string description)
        {
            InitializeComponent();
            this.lblTitle.Text = title;
            this.lblDescription.Text = description;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Brush b = new LinearGradientBrush(ClientRectangle, Color.White, BackColor, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(b, ClientRectangle);
            }

            using (Pen p = new Pen(Color.FromArgb(118, 118, 118)))
            {
                Rectangle rect = ClientRectangle;
                rect.Width--;
                rect.Height--;
                e.Graphics.DrawRectangle(p, rect);
            }
        }
    }
}
