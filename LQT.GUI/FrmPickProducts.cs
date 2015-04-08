
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
    public partial class FrmPickProducts : Form
    {
        public IList<MasterProduct> _prevSelectedProduct;
        public IList<MasterProduct> _newSelectedProduct;
        public IList<MasterProduct> _products;

        public FrmPickProducts(IList<MasterProduct> prevSelectedProduct)
        {
            _prevSelectedProduct = prevSelectedProduct;
            InitializeComponent();
            PopProductType();
            BindProducts();
        }

        private void PopProductType()
        {
            comproducttype.DataSource = DataRepository.GetAllProductType();
            comproducttype.Items.Insert(0, "--All--");
            comproducttype.SelectedIndex = 0;

            if (comproducttype.SelectedIndex == 0)
                _products = DataRepository.GetAllProduct();
            else
                _products = DataRepository.GetAllProductByType((int)comproducttype.SelectedValue);

        }

        private void BindProducts()
        {
            lvProductAll.BeginUpdate();
            lvProductAll.Items.Clear();

            foreach (MasterProduct p in _products)
            {
                if (!IsProductSelected(p.Id))
                {
                    ListViewItem li = new ListViewItem(p.ProductName) { Tag = p};

                    li.SubItems.Add(p.SerialNo);
                    li.SubItems.Add(p.BasicUnit);
                   // li.SubItems.Add(p.PackagingSize.ToString());
                    li.SubItems.Add(p.Specification);

                    lvProductAll.Items.Add(li);
                }
            }

            lvProductAll.EndUpdate();
        }

        private bool IsProductSelected(int proid)
        {
            foreach (MasterProduct p in _prevSelectedProduct)
            {
                if (p.Id == proid)
                    return true;
            }
            return false;
        }

        private void butSelect_Click(object sender, EventArgs e)
        {

            int len = lvProductAll.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                _newSelectedProduct.Add((MasterProduct)lvProductAll.SelectedItems[i].Tag);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
   
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void comproducttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comproducttype.SelectedIndex == 0)
                _products = DataRepository.GetAllProduct();
            else
                _products = DataRepository.GetAllProductByType((int)comproducttype.SelectedValue);

            BindProducts();
        }
    }
}
