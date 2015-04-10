
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

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Asset
{
    public partial class ProductTypeForm : Form
    {
        private ProductType _proType;
        private Form _mdiparent;
        private bool _error = false;

        public event EventHandler CreateOrEditProduct;
        private bool _enableCtr;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="proType"></param>
        /// <param name="mdiparent"></param>
        public ProductTypeForm(ProductType proType, Form mdiparent)
        {
            this._proType = proType;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);
            popCategory();
            LoadProductTypeCtr();

        }

        private void LoadProductTypeCtr()
        {
            //  tableLayoutPanel2.Controls.Clear();//b
            //_rPane = new ProductTypePane(_proType, true);
            //_rPane.CreateOrEditProduct += new EventHandler(OnCreateOrEditProduct);
            //_rPane.Dock = DockStyle.Fill;
            // tableLayoutPanel2.Controls.Add(_rPane);//b
            CreateOrEditProduct += new EventHandler(OnCreateOrEditProduct);
            _enableCtr = true;
            SetControlState();
            popCategory();
            BindProductType();
            
        }
        public void popCategory()
        {
            cobCategory.DataSource = LqtUtil.EnumToArray<ClassOfMorbidityTestEnum>();
            cobCategory.SelectedIndex = -1;
        }
        private bool ShowCategory
        {
            set
            {
                lblcategory.Visible = value;
                cobCategory.Visible = value;
            }
        }
        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();

                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                DataRepository.CloseSession();
                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();

                _proType = new ProductType();
                LoadProductTypeCtr();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        void lqtToolStrip1_SaveAndCloseClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                DataRepository.CloseSession();
                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();
                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void OnCreateOrEditProduct(object sender, EventArgs e)
        {
            CreateOrUpdateEventArgs cuargs = (CreateOrUpdateEventArgs)e;
            InitializeProductForm((MasterProduct)cuargs.GetCreatedOrUpdateObject);
        }

        private void InitializeProductForm(MasterProduct pro)
        {
            ProductForm frm = new ProductForm(pro, _mdiparent);
            frm.ShowDialog();
            RebindProductType(_proType);
        }

        private void SetControlState()
        {
            this.txtName.Enabled = _enableCtr;
            this.txtDescription.Enabled = _enableCtr;
            this.butNewpro.Enabled = _enableCtr;
            this.lsvGroups.Enabled = _enableCtr;
            this.chkuseindemograph.Enabled = _enableCtr;

            this.txtName.Text = "";
            this.txtDescription.Text = "";
            this.chkuseindemograph.Checked = false;
        }

        private void BindProductType()
        {
            if (_proType.Id > 0)
            {
                this.txtName.Text = _proType.TypeName;
                this.txtDescription.Text = _proType.Description;
                this.chkuseindemograph.Checked = _proType.UseInDemography;
                this.butNewpro.Enabled = true;
                ShowCategory = _proType.UseInDemography;
                if (_proType.ClassOfTest != null)
                    cobCategory.Text = _proType.ClassOfTest;
            }
            else
            {
                this.butNewpro.Enabled = false;
                ShowCategory = false;
            }

            DisplayProducts();
        }

        private void DisplayProducts()
        {
            lsvGroups.BeginUpdate();
            lsvGroups.Items.Clear();

            foreach (MasterProduct pro in _proType.Products)
            {
                ListViewItem listViewItem = new ListViewItem(pro.ProductName)
                {
                    Tag = pro.Id
                };
                listViewItem.SubItems.Add(pro.SerialNo);
                listViewItem.SubItems.Add(pro.Specification);
                listViewItem.SubItems.Add(pro.BasicUnit);
                //listViewItem.SubItems.Add(pro.PackagingSize);

                lsvGroups.Items.Add(listViewItem);
            }
            lsvGroups.EndUpdate();
        }

        public void RebindProductType(ProductType ptype)
        {
            this._proType = ptype;
            BindProductType();
        }

        public LQTUserMessage SaveOrUpdateObject()
        {
            if (txtName.Text.Trim() == string.Empty)
                throw new LQTUserException("Type name must not be empty.");
            else if (DataRepository.GetProductTypeByName(txtName.Text.Trim()) != null &&
               _proType.Id <= 0)
                throw new LQTUserException("Product Type already exists.");
            DataRepository.CloseSession();//b
            _proType.TypeName = this.txtName.Text.Trim();
            _proType.Description = this.txtDescription.Text;
            _proType.UseInDemography = this.chkuseindemograph.Checked;
            if (_proType.UseInDemography)
                _proType.ClassOfTest = cobCategory.SelectedItem.ToString();
            else
                _proType.ClassOfTest = null;

            DataRepository.SaveOrUpdateProductType(_proType);

            return new LQTUserMessage("Product Type was saved or updated successfully.");
        }

        public MasterProduct GetSelectedProduct()
        {
            if (lsvGroups.SelectedItems.Count == 0)
                return null;

            int proId = (int)lsvGroups.SelectedItems[0].Tag;
            return DataRepository.GetProductById(proId);
        }


        private void butNewpro_Click(object sender, EventArgs e)
        {
            if (CreateOrEditProduct != null)
            {
                MasterProduct pro = new MasterProduct();
                pro.ProductType = _proType;
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(pro);
                CreateOrEditProduct(this, eArgs);

                _proType = DataRepository.GetProductTypeById(pro.ProductType.Id);//b
            }

            DisplayProducts();//b
        }

        private void butEditpro_Click(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0 && _error == false)//b
            {
                if (CreateOrEditProduct != null)
                {
                    MasterProduct pro = GetSelectedProduct();//b
                    CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(pro);//b

                    //  CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(GetSelectedProduct());
                    CreateOrEditProduct(this, eArgs);
                    _proType = DataRepository.GetProductTypeById(pro.ProductType.Id);//b
                }
                DisplayProducts();
            }


        }

        private void butDeletepro_Click(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0 && _error == false)//b
            {
                MasterProduct pro = this.GetSelectedProduct();
                if (pro != null && MessageBox.Show("Are you sure you want to delete this Product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        //_proType.Products.Remove(pro);
                        DataRepository.DeleteProduct(pro);
                        DataRepository.CloseSession();//b
                        _proType = DataRepository.GetProductTypeById(pro.ProductType.Id);//b
                    }
                    catch (Exception ex)
                    {
                        _error = true;
                        // throw new LQTUserException(ex.Message);
                        FrmShowError frm = new FrmShowError(new ExceptionStatus() { message = "Product could not be deleted.", ex = ex });
                        frm.ShowDialog();
                        LQTUserMessage msg = SaveOrUpdateObject();//added b
                        this.Close();
                    }
                }
                DisplayProducts();
            }

        }

        private void lsvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0)
            {
                this.butEditpro.Enabled = true;
                this.butDeletepro.Enabled = true;

            }
            else
            {
                this.butEditpro.Enabled = false;
                this.butDeletepro.Enabled = false;
            }


        }

        private void chkuseindemograph_CheckedChanged(object sender, EventArgs e)
        {
            ShowCategory = chkuseindemograph.Checked;
        }

    }
}
