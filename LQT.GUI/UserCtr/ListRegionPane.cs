
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
    public partial class ListRegionPane : BaseUserControl
    {
        private int _selectedRegionId = 0;
        //private RegionPane _regionPane;

        public ListRegionPane()
        {
            InitializeComponent();
            PopRegions();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Regions/Districts/Provinces";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopRegions();
        }

        private void PopRegions()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ForlabRegion r in DataRepository.GetAllRegion())
            {
                ListViewItem li = new ListViewItem(r.RegionName) { Tag = r.Id };
                li.SubItems.Add(r.ShortName);

                if (r.Id == _selectedRegionId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }
            
            listView1.EndUpdate();

            if (_selectedRegionId > 0)
            {
              //  LoadRegionPane();
            }
            else if (listView1.Items.Count > 0)
            {
                _selectedRegionId = (int)listView1.Items[0].Tag;
               // LoadRegionPane();
            }
            else
            {
                splitContainer1.Panel2.Controls.Clear();
              //  this._regionPane = null;
            }
        }

        //private void LoadRegionPane()
        //{
        //    if (_regionPane != null)
        //    {
        //        _regionPane.RebindRegion(GetSelectedRegion());
        //    }
        //    //else
        //    //{
        //    //    splitContainer1.Panel2.Controls.Clear();
        //    //    _regionPane = new RegionPane(GetSelectedRegion());

        //    //    _regionPane.Dock = DockStyle.Fill;
        //    //    splitContainer1.Panel2.Controls.Add(_regionPane);
        //    //}
        //}

        private ForlabRegion GetSelectedRegion()
        {
            return DataRepository.GetRegionById(_selectedRegionId);
        }
        private ForlabRegion GetSelectedRegion(int id)
        {
            return DataRepository.GetRegionById(id);
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            listView1.Columns[1].Width = listView1.Width - 305;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegionForm frm = new RegionForm(new ForlabRegion(), MdiParentForm);
            frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
               
                    int id = (int)listView1.SelectedItems[0].Tag;
                    if (id != _selectedRegionId)
                    {
                        _selectedRegionId = id;
                        // LoadRegionPane();
                    }
                
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            RegionForm frm = new RegionForm(GetSelectedRegion(), MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            int delRegionCount = 0;
            if (MessageBox.Show("Are you sure you want to delete this Region/District/Province?", "Delete Region/District/Province", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                    //DataRepository.DeleteRegion(GetSelectedRegion());
                     for (int i = 0; i < listView1.SelectedItems.Count; i++)
                     {
                         try
                         {
                             DataRepository.DeleteRegion(GetSelectedRegion(int.Parse(listView1.SelectedItems[i].Tag.ToString())));
                             delRegionCount++;
                         }
                         catch (Exception ex)
                         {
                             DataRepository.CloseSession();
                             new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry you could not delete Region/District/Province  " + GetSelectedRegion(int.Parse(listView1.SelectedItems[i].Tag.ToString())).RegionName }).ShowDialog();
                         }
                     }
                    MdiParentForm.ShowStatusBarInfo(delRegionCount+" Region/District/Province deleted successfully.");
                    _selectedRegionId = 0;
                    DataRepository.CloseSession();
                    PopRegions();
                    MdiParentForm.BuildNavigationMenu();
                    return true;
                }
            return false;
        }
    }
}
