
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
