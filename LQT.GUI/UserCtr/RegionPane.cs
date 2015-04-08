using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Location;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class RegionPane : BaseUserControl
    {
        public event EventHandler CreateOrEditSite;
        private bool _enableCtr;
        private ForlabRegion _region;

        public RegionPane(ForlabRegion region)
            : this(region, false)
        {
        }

        private bool ShowCommandButtons
        {
            set
            {
                butDeletesite.Visible = value;
                butEditsite.Visible = value;
                butNewsite.Visible = value;
            }
        }


        public RegionPane(ForlabRegion region, bool enableCtr)
        {
            this._region = region;
            this._enableCtr = enableCtr;
            InitializeComponent();
            SetControlState();
            BindRegion();
        }

        private void SetControlState()
        {
            this.txtName.Enabled = _enableCtr;
            this.txtShortname.Enabled = _enableCtr;
            this.butNewsite.Enabled = _enableCtr;
            this.lsvGroups.Enabled = _enableCtr;
            this.ShowCommandButtons = _enableCtr;
        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
            if (txtName.Text.Trim() == string.Empty)
                throw new LQTUserException("Region Name must not be empty.");
            else if (DataRepository.GetRegionByName(txtName.Text.Trim()) != null &&
                _region.Id <= 0)
                throw new LQTUserException("The Region Name already exists.");
            
            _region.RegionName = this.txtName.Text;
            _region.ShortName = this.txtShortname.Text;

            DataRepository.SaveOrUpdateRegion(_region);

            return new LQTUserMessage("Region was saved or updated successfully.");
        }

        public void RebindRegion(ForlabRegion region)
        {
            this._region = region;
            BindRegion();
        }

        private void BindRegion()
        {
            if (_region.Id > 0)
            {
                this.txtName.Text = _region.RegionName;
                this.txtShortname.Text = _region.ShortName;

                if (_enableCtr)
                {
                    this.butNewsite.Enabled = true;
                }
            }
            else  if (_enableCtr)                
            {

                this.butNewsite.Enabled = false;
            }

            DisplaySites();
        }

        private void DisplaySites()
        {
            lsvGroups.BeginUpdate();
            lsvGroups.Items.Clear();

            foreach (ForlabSite  site in _region.Sites)
            {
                ListViewItem listViewItem = new ListViewItem(site.SiteName)
                {
                    Tag = site.Id
                };
                string str = site.CurrentlyOpen ? "Yes" : "No";
                listViewItem.SubItems.Add(str);
                listViewItem.SubItems.Add(site.GetLastOpenDate.ToShortDateString());
                str = site.GetLastClosedDate != null ? site.GetLastClosedDate.Value.ToShortDateString() : "";
                listViewItem.SubItems.Add(str);

                lsvGroups.Items.Add(listViewItem);
            }
            lsvGroups.EndUpdate();
        }

        public ForlabSite GetSelectedSite()
        {
            if (lsvGroups.SelectedItems.Count == 0)
                return null;

            int siteId = (int)lsvGroups.SelectedItems[0].Tag;
            return DataRepository.GetSiteById(siteId);
        }


        private void butNewsite_Click(object sender, EventArgs e)
        {
            if (CreateOrEditSite != null)
            {
                ForlabSite site = new ForlabSite();
                site.Region = _region;
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(site);
                CreateOrEditSite(this, eArgs);
            }

            DisplaySites();
        }

        private void butEditsite_Click(object sender, EventArgs e)
        {
            if (CreateOrEditSite != null)
            {
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(GetSelectedSite());
                CreateOrEditSite(this, eArgs);
            }

            DisplaySites();
        }

        private void butDeletesite_Click(object sender, EventArgs e)
        {
            ForlabSite site = this.GetSelectedSite();
            if (site != null && 
                MessageBox.Show("Are you sure you want to delete this site?", "Delete Site", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
            {
                try
                {
                    DataRepository.DeleteSite(site);
                }
                catch (Exception ex)
                {
                    FrmShowError frm = new FrmShowError(new ExceptionStatus() { message = "Site could not be deleted.", ex = ex });
                    frm.ShowDialog();
                }
            }

            DisplaySites();
        }

        private void lsvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0)
            {
                this.butEditsite.Enabled = true;
                this.butDeletesite.Enabled = true;
            }
            else
            {
                this.butEditsite.Enabled = false;
                this.butDeletesite.Enabled = false;
            }
        }
    }
}
