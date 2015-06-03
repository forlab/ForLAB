
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
using LQT.GUI.MorbidityUserCtr;

namespace LQT.GUI
{
    public partial class FrmMorbiditySupplyForecastAdj : Form
    {
        private MorbidityForecast _forecast;
        private ProductQuantityInStock p;
        public FrmMorbiditySupplyForecastAdj(MorbidityForecast m)
        {
            _forecast = m;
            InitializeComponent();
        }

        private void FrmMorbiditySupplyForecastAdj_Load(object sender, EventArgs e)
        {
             p = new ProductQuantityInStock(_forecast);
            p.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(p);
        }

        private void FrmMorbiditySupplyForecastAdj_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (p.edited)
            //{
                this.DialogResult = DialogResult.OK;
                p.DoSomthingBeforeUnload();
            //}
            //else
            //{
            //    p.edited = false;
              //  this.DialogResult = DialogResult.Cancel;
            //}
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            //p.edited = false;
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            p.DoSomthingBeforeUnload();
        }
    }
}
