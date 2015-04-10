
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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Location;
using LQT.Core.UserExceptions;
using System.Windows.Forms.DataVisualization.Charting;

namespace LQT.GUI
{
    public partial class ZoomedChart : Form
    {
        private Chart _currentchart;

        public ZoomedChart(Chart _chart)
        {
            _currentchart = _chart;
          //  _currentchart.ContextMenuStrip = null;
            _currentchart.Dock = DockStyle.Fill;
            this.Controls.Add(_currentchart);
            InitializeComponent();
        }

        private void ZoomedChart_Load(object sender, EventArgs e)
        {

        }
    }
}
