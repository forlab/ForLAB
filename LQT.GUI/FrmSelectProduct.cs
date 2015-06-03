
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
    public partial class FrmSelectProduct : Form
    {
        public IList<int> SelectedProductIds;
        private IList<int> _selectedPro;
        private IList<MasterProduct> _products;

        public FrmSelectProduct(IList<int> selectedpro, IList<MasterProduct> products)
        {
            _selectedPro = selectedpro;
            _products = products;

            InitializeComponent();
            SelectedProductIds = new List<int>();
            BindProducts();
        }

        private void BindProducts()
        {
            lvProductAll.BeginUpdate();
            lvProductAll.Items.Clear();

            foreach (MasterProduct p in _products)
            {
                if (!IsProductSelected( p.Id))
                {
                    ListViewItem li = new ListViewItem(p.ProductName) { Tag = p.Id };

                    li.SubItems.Add(p.SerialNo);
                    li.SubItems.Add(p.BasicUnit);
                    //li.SubItems.Add(p.PackagingSize.ToString());
                    li.SubItems.Add(p.Specification);

                    lvProductAll.Items.Add(li);
                }
            }

            lvProductAll.EndUpdate();

        }

        private bool IsProductSelected(int proid)
        {
            foreach (int id in _selectedPro)
            {
                if (id == proid)
                    return true;
            }
            return false;
        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            int len = lvProductAll.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                SelectedProductIds.Add((int)lvProductAll.SelectedItems[i].Tag);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        public int NoRPeriod()
        {
            if (txtNoperiod.Text == "")
                return 3;
            int no = int.Parse(txtNoperiod.Text);

            return no > 3 ? no : 3;
        }

        private void txtNoperiod_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
