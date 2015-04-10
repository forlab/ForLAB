
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

namespace LQT.GUI
{
    public partial class FrmPriceinput : Form
    {
        private ProductPrice _proprice;
        
        public ProductPrice GetProductPrice
        {
            get { return _proprice; }
        }

        public FrmPriceinput()
        {
            InitializeComponent();
            _proprice = new ProductPrice();
        }

        public FrmPriceinput(ProductPrice pprice)
        {
            InitializeComponent();
            _proprice = pprice;
            BindPrice();
        }

        private void BindPrice()
        {
            txtPrice.Text = _proprice.Price.ToString();
            txtPacksize.Text = _proprice.PackSize.ToString();
            dtpAsofdate.Value = _proprice.FromDate;
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Price must not be empty", "Price Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPacksize.Text))
            {
                MessageBox.Show("Pack Size must not be empty", "Price Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _proprice.Price = decimal.Parse(txtPrice.Text);
            _proprice.PackSize = int.Parse(txtPacksize.Text);
            _proprice.FromDate = dtpAsofdate.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void txtPacksize_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8)|| (x == 46)) 
            {
                if (x == 46 && txtPrice.Text == string.Empty)
                    e.Handled = true;
                else if (x == 46 && txtPrice.Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
