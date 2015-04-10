
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
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Asset;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListProductPane : BaseUserControl
    {
        //private int _selectedProId = 0;
        private MasterProduct _selectedProId = null;
        private int _proTypeId;
        private int _totalNoOfPro = 0;
        private int _pageNo = 0;
        private double _totalPages = 0d;
        private double _pageSize = 30d;


        public ListProductPane(int protypeid)
        {
            this._proTypeId = protypeid;

            InitializeComponent();
            PopProduct();
        }

        public override string GetControlTitle
        {
            get
            {
                if (_proTypeId > 0)
                    return  String.Format("Products-> {0}" ,DataRepository.GetProductTypeById(_proTypeId).TypeName);
                return "Products-> All";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopProduct();
        }

        private void SetNavButtonState()
        {
            if (_totalNoOfPro == 0)
            {
                butFirst.Enabled = butPriv.Enabled = false;
                butLast.Enabled = butNext.Enabled = false;
                listView1.Items.Clear();
            }
            else
            {
                if (_pageNo == 0)
                {
                    butFirst.Enabled = butPriv.Enabled = false;
                    if (_totalPages == 1)
                        butLast.Enabled = butNext.Enabled = false;
                    else
                        butLast.Enabled = butNext.Enabled = true;
                }
                else if (_pageNo == (_totalPages - 1))
                {
                    butFirst.Enabled = butPriv.Enabled = true;
                    butLast.Enabled = butNext.Enabled = false;
                }
                else
                {
                    butFirst.Enabled = butPriv.Enabled = true;
                    butLast.Enabled = butNext.Enabled = true;
                }
            }
        }

        private void PopProduct()
        {
            _totalNoOfPro =  DataRepository.GetTotalCountOfProducts(_proTypeId);
            
            _totalPages = Math.Ceiling(_totalNoOfPro / _pageSize);

            if (_pageNo > 0 && _pageNo == _totalPages)
                _pageNo--;
            _selectedProId = null;

            txtPageno.Text = _totalPages == 0 ? "0" : (_pageNo + 1).ToString();
            lblPages.Text = _totalPages.ToString();

            BindProductToListView();
            SetNavButtonState();            
        }

        private void BindProductToListView()
        {
            IList<MasterProduct> result = DataRepository.GetPagingProducts(_proTypeId, (int)(_pageNo * _pageSize), (int)_pageSize);
            
            listView1.BeginUpdate();
            listView1.Items.Clear();
            
            SelectedItemChanged(listView1);

            ProductPrice pp = null;
            foreach (MasterProduct r in result)
            {
                ListViewItem li = new ListViewItem(r.ProductName) { Tag = r };
                li.SubItems.Add(r.ProductType.TypeName);
                li.SubItems.Add(r.SerialNo);
                li.SubItems.Add(r.BasicUnit);
                pp = r.GetActiveProductPrice(DateTime.Now);
                li.SubItems.Add(pp.PackSize.ToString());
                string Price = String.Format("{0:0.##}", pp.Price).ToString();
                li.SubItems.Add(Price);
                li.SubItems.Add(r.MinimumPackSize.ToString());

                if (_selectedProId != null && r.Id == _selectedProId.Id)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }

            listView1.EndUpdate();
        }

        //private MasterProduct GetSelectedProduct()
        //{
        //    return  DataRepository.GetProductById(_selectedProId);
        //}
        //private MasterProduct GetSelectedProduct(int Id)
        //{
        //    return DataRepository.GetProductById(Id);
        //}

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        //private void listView1_Click(object sender, EventArgs e)
        //{

        //}

        //private void listView1_Resize(object sender, EventArgs e)
        //{
        //    //listView1.Columns[1].Width = listView1.Width - 305;
        //}

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductForm frm = new ProductForm(new MasterProduct() { ProductType = DataRepository.GetProductTypeById(_proTypeId) }, MdiParentForm);
            frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //int id = (int)listView1.SelectedItems[0].Tag;
                MasterProduct mp = listView1.SelectedItems[0].Tag as MasterProduct;
                //if (id != _selectedProId)
                if (_selectedProId == null)
                    _selectedProId = mp;
                else if (mp.Id != _selectedProId.Id)
                    _selectedProId = mp; // id;                   
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            ProductForm frm = new ProductForm(_selectedProId, MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            int delProCount = 0;
            string productName = null;

            if (MessageBox.Show("Are you sure you want to delete selected Product/s ?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    try
                    {
                        DataRepository.DeleteProduct((MasterProduct)listView1.SelectedItems[i].Tag);
                        delProCount++;
                    }
                    catch
                    {
                        if (productName == null)
                            productName = ((MasterProduct)listView1.SelectedItems[i].Tag).ProductName + Environment.NewLine;
                        else
                            productName += ", " + ((MasterProduct)listView1.SelectedItems[i].Tag).ProductName + Environment.NewLine;
                    }
                }

                if (productName != null)
                {
                    MessageBox.Show("Some of Products listed below could not delete. " + Environment.NewLine + productName, "Delete selected Product(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (delProCount > 0)
                    MdiParentForm.ShowStatusBarInfo(delProCount + " Product/s deleted successfully.");

                _selectedProId = null;
                //DataRepository.CloseSession();
                PopProduct();
                return true;
            }

            return false;
        }

        private void navButton_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            string tag = but.Tag.ToString();

            if (tag == "FP")
            {
                _pageNo = 0;
            }
            if (tag == "PP")
            {
                _pageNo--;
            }
            if (tag == "NP")
            {
                _pageNo++;
            }
            if (tag == "LP")
            {
                _pageNo = (int)_totalPages - 1;
            }
            
            txtPageno.Text = (_pageNo + 1).ToString();

            BindProductToListView();
            SetNavButtonState();
        }
    }
}
