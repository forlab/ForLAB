
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
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Location;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListSiteCatPane : BaseUserControl
    {
                private int _selectedRegionId = 0;
        //private RegionPane _regionPane;

                public ListSiteCatPane()
        {
            InitializeComponent();
            BindSiteCategorys();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Site Category";
            }
        }

        public override void ReloadUserCtrContents()
        {
            BindSiteCategorys();
        }

        private void BindSiteCategorys()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (SiteCategory sc in DataRepository.GetListOfAllSiteCategory())
            {
                ListViewItem li = new ListViewItem(sc.CategoryName) { Tag = sc.Id };
                li.SubItems.Add(sc.CategoryName);
                if (sc.Id == _selectedRegionId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }
            
            listView1.EndUpdate();

        
        }


        private SiteCategory GetSelectedRegion()
        {
            return DataRepository.GetSiteCategoryById(_selectedRegionId);
        }
        private SiteCategory GetSelectedRegion(int Id)
        {
            return DataRepository.GetSiteCategoryById(Id);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
          //  listView1.Columns[1].Width = listView1.Width - 305;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSiteCat frm = new FrmSiteCat(new SiteCategory());
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BindSiteCategorys();
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                if (id != _selectedRegionId)
                {
                    _selectedRegionId = id;
                }
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            if (listView1.SelectedItems.Count > 0)
            {

                FrmSiteCat frm = new FrmSiteCat(DataRepository.GetSiteCategoryById((int)listView1.SelectedItems[0].Tag));
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BindSiteCategorys();
                }
            }
        }

        public override bool DeleteSelectedItem()
        {
            int delSiteCatCount = 0;
            if (MessageBox.Show("Are you sure you want to delete this Site Category?", "Delete Site Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {

                    try
                    {
                        DataRepository.DeleteSiteCategory(GetSelectedRegion(int.Parse(listView1.SelectedItems[i].Tag.ToString())));
                        delSiteCatCount++;
                    }
                    catch (Exception ex)
                    {
                        DataRepository.CloseSession();
                        new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry you could not delete this Site Category. "+(GetSelectedRegion(int.Parse(listView1.SelectedItems[i].Tag.ToString()))).CategoryName }).ShowDialog();
                    }
                }
                MdiParentForm.ShowStatusBarInfo(delSiteCatCount + "  Site Category/s deleted successfully.");
                    _selectedRegionId = 0;
                    DataRepository.CloseSession();
                    BindSiteCategorys();
                    MdiParentForm.BuildNavigationMenu();
                    return true;
                
                
            }

            return false;
        }

      
    }
}
