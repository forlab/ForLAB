
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
using System.Windows.Forms;

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Location
{
    public partial class RegionForm : Form
    {
        private ForlabRegion _region;
        //  private RegionPane _rPane;//b
        private Form _mdiparent;
        public event EventHandler CreateOrEditSite;//b
        private bool _enableCtr;//b
        private bool _error=false;
 

        public RegionForm(ForlabRegion region, Form mdiparent)
        {
            this._region = region;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            LoadRegionCtr();//b
         
        }

        private void LoadRegionCtr()
        {

            // tableLayoutPanel2.Controls.Clear();

            //////b/3
            //_rPane = new RegionPane(_region, true);
            //_rPane.CreateOrEditSite += new EventHandler(OnCreateOrEditSite);
            //_rPane.Dock = DockStyle.Fill;
            ////b 4
            this.CreateOrEditSite += new EventHandler(OnCreateOrEditSite);
            this._enableCtr = true;
            SetControlState();
            BindRegion();
            // tableLayoutPanel2.Controls.Add(_rPane);
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                //LQTUserMessage msg = _rPane.SaveOrUpdateObject();//b
                LQTUserMessage msg = SaveOrUpdateObject();//added b
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message);
                DataRepository.CloseSession();
                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();
                _region = new ForlabRegion();
                LoadRegionCtr();
                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();
                
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        void lqtToolStrip1_SaveAndCloseClick(object sender, EventArgs e)
        {
            try
            {
                //LQTUserMessage msg = _rPane.SaveOrUpdateObject();//b
                LQTUserMessage msg = SaveOrUpdateObject();//added b
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                DataRepository.CloseSession();
                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();

                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void OnCreateOrEditSite(object sender, EventArgs e)
        {
            CreateOrUpdateEventArgs cuargs = (CreateOrUpdateEventArgs)e;
            InitializeSiteForm((ForlabSite)cuargs.GetCreatedOrUpdateObject);
        }

        private void InitializeSiteForm(ForlabSite site)
        {
            SiteForm frm = new SiteForm(site, _mdiparent);
            frm.ShowDialog();
            //_rPane.RebindRegion(_region);//b
            RebindRegion(_region);//added b
        }

        private void butNewsite_Click(object sender, EventArgs e)
        {
            if (CreateOrEditSite != null)
            {
                ForlabSite site = new ForlabSite();
                site.Region = _region;
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(site);
                CreateOrEditSite(this, eArgs);
                _region = DataRepository.GetRegionById(site.Region.Id);//b
               
            }

            DisplaySites();
    
        }

        private void butEditsite_Click(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0 && _error == false )//b
            {
                if (CreateOrEditSite != null)
                {
                    ForlabSite site = GetSelectedSite();//b
                    CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(site);//(GetSelectedSite());//b
                    CreateOrEditSite(this, eArgs);
                    _region = DataRepository.GetRegionById(site.Region.Id);//b
                }

                DisplaySites();
            }
            
             
        
        }

        private void butDeletesite_Click(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0&& _error == false) //b
            {
                ForlabSite site = this.GetSelectedSite();
                if (site != null &&
                    MessageBox.Show("Are you sure you want to delete this site?", "Delete Site", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataRepository.DeleteSite(site);
                        DataRepository.CloseSession();//b
                        _region = DataRepository.GetRegionById(site.Region.Id);//b
                    }
                    catch (Exception ex)
                    {
                        _error = true;
                        FrmShowError frm = new FrmShowError(new ExceptionStatus() { message = "Site could not be deleted.", ex = ex });
                        frm.ShowDialog();
                        LQTUserMessage msg = SaveOrUpdateObject();//added b
                        this.Close();
                    }
                }

                DisplaySites();
            }
            
     
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

        private void DisplaySites()
        {
           
                lsvGroups.BeginUpdate();
                lsvGroups.Items.Clear();


                foreach (ForlabSite site in  _region.Sites)
                {
                    ListViewItem listViewItem = new ListViewItem(site.SiteName)
                    {
                        Tag = site.Id
                    };
                    //string str;
                    string str = site.CurrentlyOpen ? "Yes" : "No";//b 2 add 3 lines
                    listViewItem.SubItems.Add(str);
                    //if (DataRepository.GetSiteById(site.Id) != null)
                    //{
                    //    listViewItem.SubItems.Add(site.CurrentlyOpen ? "Yes" : "No");
                    //}
                    listViewItem.SubItems.Add(site.GetLastOpenDate.ToShortDateString());
                    str = site.GetLastClosedDate != null ? site.GetLastClosedDate.Value.ToShortDateString() : "";
                    listViewItem.SubItems.Add(str);

                    lsvGroups.Items.Add(listViewItem);
                }
                lsvGroups.EndUpdate();
           
        }

        public LQTUserMessage SaveOrUpdateObject()
        {
            if (txtName.Text.Trim() == string.Empty)
                throw new LQTUserException("Region/District/Province name must not be empty.");
            else if (DataRepository.GetRegionByName(txtName.Text.Trim()) != null &&
                _region.Id <= 0)
                throw new LQTUserException("The Region/District/Province name already exists.");
            DataRepository.CloseSession();//b

            _region.RegionName = this.txtName.Text.Trim();
            _region.ShortName = this.txtShortname.Text;

            DataRepository.SaveOrUpdateRegion(_region);

            return new LQTUserMessage("Region/District/Province saved or updated successfully.");
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
            else if (_enableCtr)
            {

                this.butNewsite.Enabled = false;
            }

            DisplaySites();
        }

        public ForlabSite GetSelectedSite()
        {
            if (lsvGroups.SelectedItems.Count == 0)
                return null;

            int siteId = (int)lsvGroups.SelectedItems[0].Tag;
            return DataRepository.GetSiteById(siteId);
           
        }

        public void RegionPane(ForlabRegion region, bool enableCtr)
        {
            //this._region = region;
            this._enableCtr = enableCtr;
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
            this.txtName.Text = "";
            this.txtShortname.Text = "";
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

    }
}
