
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

namespace LQT.GUI
{
    public partial class FrmSelectTestArea : Form
    {
        public IList<TestingArea> _selectedTestingAreas;
       // private IList<SiteService> _selectedSiteTAs;

        //public FrmSelectTestArea(IList<SiteService> selectedServices)
        //{
        //    InitializeComponent();
        //    _selectedTestingAreas = new List<TestingArea>();
        //    BindTestingAreas();
        //}

        //private void BindTestingAreas()
        //{
        //    lvTestingArea.BeginUpdate();
        //    lvTestingArea.Items.Clear();

        //    foreach (TestingArea ta in DataRepository.GetAllTestingArea())
        //    {
        //        if (!IsTASelected(ta.Id))
        //        {
        //            ListViewItem li = new ListViewItem(ta.AreaName) { Tag = ta };
        //            lvTestingArea.Items.Add(li);
        //        }
        //    }

        //    lvTestingArea.EndUpdate();

        //}

        //private bool IsTASelected(int testAreaID)
        //{
        //    if (_selectedSiteTAs != null)
        //    {
        //        foreach (SiteService sserv in _selectedSiteTAs)
        //        {
        //            if (sserv.TestingArea.Id == testAreaID)
        //                return true;
        //        }
        //    }
        //    return false;
        //}

        private void butSelect_Click(object sender, EventArgs e)
        {
            int len = lvTestingArea.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                _selectedTestingAreas.Add((TestingArea)lvTestingArea.SelectedItems[i].Tag);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public int TestingDayPerM()
        {
            if (txttestingdayinMM.Text == "")
                return 26;
            int no = int.Parse(txttestingdayinMM.Text);


            return no > 26 || no<=0 ? 26 : no;
        }

        private void txttestingdayinMM_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
