
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
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Location;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListSitePane : BaseUserControl
    {
        private int _selectedSiteId = 0;
        private int _regionid;


        public ListSitePane(int regionid)
        {
            this._regionid = regionid;

            InitializeComponent();
            PopSites();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Sites";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopSites();
        }

        private void PopSites()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            IList<ForlabSite> result = new List<ForlabSite>();

            if (_regionid > 0)
                result = DataRepository.GetAllSiteByRegionId(_regionid);
            else
                result = DataRepository.GetAllSite();

            foreach (ForlabSite s in result)
            {
                ListViewItem li = new ListViewItem(s.SiteName) { Tag = s.Id };
                li.SubItems.Add(s.Region.RegionName);
                string str = s.SiteCategory != null ? s.SiteCategory.CategoryName : "";
                li.SubItems.Add(str);

                li.SubItems.Add(s.WorkingDays.ToString());
                if (s.SiteLevel != null)//b
                    li.SubItems.Add(s.SiteLevel.ToString());//b
                else
                    li.SubItems.Add("");
                li.SubItems.Add(s.GetLastOpenDate.ToShortDateString());
                if (s.GetLastClosedDate != null)
                    li.SubItems.Add(s.GetLastClosedDate.Value.ToShortDateString());
                else
                    li.SubItems.Add("");

                if (s.Id == _selectedSiteId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }

            listView1.EndUpdate();


        }



        private ForlabSite GetSelectedSite()
        {
            return DataRepository.GetSiteById(_selectedSiteId);
        }
        private ForlabSite GetSelectedSite(int Id)
        {
            return DataRepository.GetSiteById(Id);
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            //listView1.Columns[0].Width = listView1.Width - 5;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SiteForm frm = new SiteForm(new ForlabSite() { Region = DataRepository.GetRegionById(_regionid) }, MdiParentForm);
            frm.ShowDialog();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                if (id != _selectedSiteId)
                {
                    _selectedSiteId = id;

                }
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            SiteForm frm = new SiteForm(GetSelectedSite(), MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            int delSiteCount = 0;
            if (MessageBox.Show("Are you sure you want to delete this Site?", "Delete Site", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    try
                    {
                        DataRepository.DeleteSite(GetSelectedSite(int.Parse(listView1.SelectedItems[i].Tag.ToString())));
                        delSiteCount++;
                    }
                    catch (Exception ex)
                    {
                        DataRepository.CloseSession();
                        new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry you could not delete Site. " + GetSelectedSite(int.Parse(listView1.SelectedItems[i].Tag.ToString())).SiteName }).ShowDialog();
                    }
                    //finally
                    //{
                    //    DataRepository.CloseSession();
                    //}
                }
                MdiParentForm.ShowStatusBarInfo(delSiteCount+" Site/s deleted successfully.");
                _selectedSiteId = 0;
                PopSites();
                return true;

            }

            return false;
        }


    }
}
