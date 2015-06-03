
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
