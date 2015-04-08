
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
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI
{
    public partial class FrmSelectSite : Form
    {
        public IList<int> SelectedSiteIds;
        private IList<int> _selectedSiteids;
        private IList<ForlabSite> _sites;
        private bool _filiterByregion = false;
        private int _regionid;
        public IList<ForlabSite> SelectedSites;

        public FrmSelectSite(IList<int> selectedids, IList<ForlabSite> sites)
        {
            _selectedSiteids = selectedids;
            _sites = sites;
            SelectedSites = new List<ForlabSite>();
            InitializeComponent();
            SelectedSiteIds = new List<int>();
            BindSites();
        }

        public FrmSelectSite(IList<int> selectedids, IList<ForlabSite> sites, int regionid)
        {
            _selectedSiteids = selectedids;
            _sites = sites;
            _filiterByregion = true;
            _regionid = regionid;
            SelectedSites = new List<ForlabSite>();

            InitializeComponent();
            SelectedSiteIds = new List<int>();
            BindSites();
        }
        private void BindSites()
        {
            lvSiteAll.BeginUpdate();
            lvSiteAll.Items.Clear();

            foreach (ForlabSite s in _sites)
            {
                if (_filiterByregion)
                {
                    if (!IsSiteSelected(s.Id) && s.Region.Id == _regionid)
                    {
                        ListViewItem li = new ListViewItem(s.Region.RegionName) { Tag = s};
                        li.SubItems.Add(s.SiteName);

                        lvSiteAll.Items.Add(li);
                    }
                }
                else
                {
                    if (!IsSiteSelected(s.Id))
                    {
                        ListViewItem li = new ListViewItem(s.Region.RegionName) { Tag = s };
                        li.SubItems.Add(s.SiteName);

                        lvSiteAll.Items.Add(li);
                    }
                }
            }

            lvSiteAll.EndUpdate();

        }

        private bool IsSiteSelected(int siteid)
        {
            foreach (int id in _selectedSiteids)
            {
                if (id == siteid)
                    return true;
            }
            return false;
        }

        private void lvSiteAll_Resize(object sender, EventArgs e)
        {

        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            int len = lvSiteAll.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                ForlabSite site =(ForlabSite)lvSiteAll.SelectedItems[i].Tag;
                SelectedSiteIds.Add(site.Id);
                SelectedSites.Add(site);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void butSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvSiteAll.Items.Count; i++)
            {
                lvSiteAll.Items[i].Selected = true;
                lvSiteAll.Select();
            }
            int len = lvSiteAll.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                ForlabSite site = (ForlabSite)lvSiteAll.SelectedItems[i].Tag;
                SelectedSiteIds.Add(site.Id);
                SelectedSites.Add(site);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
