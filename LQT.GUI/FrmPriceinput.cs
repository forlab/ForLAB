
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
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
