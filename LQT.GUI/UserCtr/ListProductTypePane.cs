
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
using LQT.GUI.Asset;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListProductTypePane : BaseUserControl
    {
        private int _selectedTypeId = 0;
       

        public ListProductTypePane()
        {
            InitializeComponent();
            PopProductType();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Product Type";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopProductType();
        }

        private void PopProductType()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ProductType r in DataRepository.GetAllProductType())
            {
                ListViewItem li = new ListViewItem(r.TypeName) { Tag = r.Id };
                li.SubItems.Add(r.UseInDemography.ToString());
                li.SubItems.Add(r.Description);

                if (r.Id == _selectedTypeId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }

            listView1.EndUpdate();

           
        }

       

        private ProductType GetSelectedProductType()
        {
            return DataRepository.GetProductTypeById(_selectedTypeId);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            listView1.Columns[2].Width = listView1.Width - 307;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductTypeForm frm = new ProductTypeForm(new ProductType(), MdiParentForm);
            frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                if (id != _selectedTypeId)
                {
                    _selectedTypeId = id;
                   
                }
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            ProductTypeForm frm = new ProductTypeForm(GetSelectedProductType(), MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            if (MessageBox.Show("Are you sure you want to delete this Product Type?", "Delete Product type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteProductType(GetSelectedProductType());
                    MdiParentForm.ShowStatusBarInfo("Product Type was deleted successfully.");
                    _selectedTypeId = 0;
                    PopProductType();
                    MdiParentForm.BuildNavigationMenu();
                    return true;
                }
                catch (Exception ex)
                {
                    //DataRepository.CloseSession();
                    new FrmShowError(new ExceptionStatus() { ex=ex, message="Sorry, you could not delete Product Type."}).ShowDialog();
                }
                finally
                {
                    DataRepository.CloseSession();
                }
            }

            return false;
        }
    }
}
