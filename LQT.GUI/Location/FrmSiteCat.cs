
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
