
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
using LQT.Core.DataAccess;
using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.Location
{
    public partial class FrmSiteCat : Form
    {
        private SiteCategory _scategory;

        public FrmSiteCat(SiteCategory scategory)
        {
            _scategory = scategory;

            InitializeComponent();

            if (_scategory.Id > 0)
                txtName.Text = _scategory.CategoryName;
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            if (DataRepository.GetSiteCategoryByName(txtName.Text.Trim()) != null)
            {
                MessageBox.Show("The Site Category Name already exists.");
                return;
            }
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Category name must not be empty.", "Site Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _scategory.CategoryName = txtName.Text.Trim();
                DataRepository.SaveOrUpdateSiteCategory(_scategory);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Error: unable to save site category.", "Site Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
