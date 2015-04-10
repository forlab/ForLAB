
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

using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.Asset
{
    public partial class FrmSearchProduct : Form
    {
        private Form _mdiparent;

        public FrmSearchProduct(Form mdiparent)
        {
            this._mdiparent = mdiparent;
            InitializeComponent();
        }

        private void PopCategory()
        {
            lsvCategory.BeginUpdate();
            lsvCategory.Items.Clear();

            foreach (ProductType t in DataRepository.GetAllProductType())
            {
                ListViewItem li = new ListViewItem(t.TypeName) { Tag = t.Id };
                lsvCategory.Items.Add(li);
            }

            lsvCategory.EndUpdate();
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            Size = new Size(550, 500);
            string sql = String.Format("from MasterProduct p where p.ProductName like '{0}%'", txtProductname.Text.Trim());

            if (rdbCategory.Checked)
            {
                if (lsvCategory.CheckedItems.Count > 0)
                {
                    string str = "";
                    foreach (ListViewItem li in lsvCategory.CheckedItems)
                    {
                        if (str != "")
                            str += ", " + (int)li.Tag;
                        else
                            str = li.Tag.ToString();
                    }

                    sql += " and p.ProductType.Id in (" + str + ")";
                }
            }
            else if (txtProductname.Text.Trim() == "")
            {
                sql = String.Format("from MasterProduct p");
            }

            BindProduct(sql);
        }

        private void butNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lsvCategory.CheckedItems)
            {
                li.Checked = false;
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lsvCategory.Items)
            {
                li.Checked = true;
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAll.Checked)
            {
                lsvCategory.BeginUpdate();
                lsvCategory.Items.Clear();
                lsvCategory.EndUpdate();
                butAll.Enabled = false;
                butNone.Enabled = false;
            }
        }

        private void rdbCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCategory.Checked)
            {
                PopCategory();
                butAll.Enabled = true;
                butNone.Enabled = true;
            }
        }

        private void BindProduct(string sql)
        {
            lsvProduct.BeginUpdate();
            lsvProduct.Items.Clear();

            IList<MasterProduct> result = DataRepository.SearchProduct(sql);
            
            foreach (MasterProduct r in result)
            {
                ListViewItem li = new ListViewItem(r.ProductName) { Tag = r.Id };
                li.SubItems.Add(r.ProductType.TypeName);
                li.SubItems.Add(r.SerialNo);
                li.SubItems.Add(r.BasicUnit);
                

                lsvProduct.Items.Add(li);
            }

            lsvProduct.EndUpdate();
        }

        private void FrmSearchProduct_Load(object sender, EventArgs e)
        {
            Size = new Size(550, 260);
        }

        private MasterProduct GetSelectedProduct()
        {
            int id = (int)lsvProduct.SelectedItems[0].Tag;
            return DataRepository.GetProductById(id);
        }

        private void lsvProduct_DoubleClick(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm(GetSelectedProduct(), _mdiparent, false);
            frm.ShowDialog();
        }
    }
}
