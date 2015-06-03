
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
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.Location
{
    public partial class FrmSearchSite : Form
    {
        private Form _mdiparent;

        public FrmSearchSite(Form mdiparent)
        {
            this._mdiparent = mdiparent;

            InitializeComponent();            
        }

        private void FrmSearchSite_Load(object sender, EventArgs e)
        {
            Size = new Size(550, 260);
        }

        private void PopRegions()
        {
            lsvRegion.BeginUpdate();
            lsvRegion.Items.Clear();

            foreach (ForlabRegion r in DataRepository.GetAllRegion())
            {
                ListViewItem li = new ListViewItem(r.RegionName) { Tag = r.Id };
                lsvRegion.Items.Add(li);
            }

            lsvRegion.EndUpdate();
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            Size = new Size(550, 500);
            string sql = String.Format( "from ForlabSite s where s.SiteName like '{0}%'", txtSitename.Text.Trim());

            if (rdbRegion.Checked)
            {
                if (lsvRegion.CheckedItems.Count > 0)
                {
                    string str = "";
                    foreach (ListViewItem li in lsvRegion.CheckedItems)
                    {
                        if (str != "")
                            str += ", " + (int)li.Tag;
                        else
                            str = li.Tag.ToString();
                    }

                    sql += " and s.Region.Id in (" + str + ")";
                }
            }
            else if (txtSitename.Text.Trim() == "")
            {
                sql = String.Format("from ForlabSite s");
            }

            BindSites(sql);
        }

        private void butNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lsvRegion.CheckedItems)
            {
                li.Checked = false;
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lsvRegion.Items)
            {
                li.Checked = true;
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAll.Checked)
            {
                lsvRegion.BeginUpdate();
                lsvRegion.Items.Clear();
                lsvRegion.EndUpdate();
                butAll.Enabled = false;
                butNone.Enabled = false;
            }
        }

        private void rdbRegion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRegion.Checked)
            {
                PopRegions();
                butAll.Enabled = true;
                butNone.Enabled = true;
            }
        }

        private void BindSites(string sql)
        {
            lsvSite.BeginUpdate();
            lsvSite.Items.Clear();

            IList<ForlabSite> result = DataRepository.SearchSite(sql);

            foreach (ForlabSite s in result)
            {
                ListViewItem li = new ListViewItem(s.SiteName) { Tag = s.Id };
                li.SubItems.Add(s.Region.RegionName);
                li.SubItems.Add(s.SiteCategory.CategoryName);
                string str = s.CurrentlyOpen ? "Open" : "Closed";
                li.SubItems.Add(str);

                lsvSite.Items.Add(li);
            }

            lsvSite.EndUpdate();
        }

        private ForlabSite GetSelectedSite()
        {
            int id = (int)lsvSite.SelectedItems[0].Tag;
            return DataRepository.GetSiteById(id);
        }

        private void lsvSite_DoubleClick(object sender, EventArgs e)
        {
            SiteForm frm = new SiteForm(GetSelectedSite(), _mdiparent, false);
            frm.ShowDialog();
        }
    }
}
