using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Asset;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ProductTypePane : BaseUserControl
    {
        public event EventHandler CreateOrEditProduct;
        private bool _enableCtr;
        private ProductType _proType;

        public ProductTypePane(ProductType ptype)
            : this(ptype, false)
        {
        }

        public ProductTypePane(ProductType ptype, bool enableCtr)
        {
            this._proType = ptype;
            this._enableCtr = enableCtr;

            InitializeComponent();
            SetControlState();
            BindProductType();
        }

        private void SetControlState()
        {
            this.txtName.Enabled = _enableCtr;
            this.txtDescription.Enabled = _enableCtr;
            this.butNewpro.Enabled = _enableCtr;
            this.lsvGroups.Enabled = _enableCtr;
            this.chkuseindemograph.Enabled = _enableCtr;
        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
            if (txtName.Text.Trim() == string.Empty)
                throw new LQTUserException("Type name must not be empty.");

            _proType.TypeName = this.txtName.Text;
            _proType.Description = this.txtDescription.Text;
            _proType.UseInDemography = this.chkuseindemograph.Checked;
            DataRepository.SaveOrUpdateProductType(_proType);

            return new LQTUserMessage("Product Type was saved or updated successfully.");
        }

        public void RebindProductType(ProductType ptype)
        {
            this._proType = ptype;
            BindProductType();
        }

        private void BindProductType()
        {
            if (_proType.Id > 0)
            {
                this.txtName.Text = _proType.TypeName;
                this.txtDescription.Text = _proType.Description;
                this.chkuseindemograph.Checked = _proType.UseInDemography;
                if (_enableCtr)
                {
                    this.butNewpro.Enabled = true;
                }
            }
            else  if (_enableCtr)                
            {
                this.butNewpro.Enabled = false;
            }

            DisplayProducts();
        }

        private void DisplayProducts()
        {
            lsvGroups.BeginUpdate();
            lsvGroups.Items.Clear();

            foreach (MasterProduct  pro in _proType.Products)
            {
                ListViewItem listViewItem = new ListViewItem(pro.ProductName)
                {
                    Tag = pro.Id
                };
                listViewItem.SubItems.Add(pro.SerialNo);
                listViewItem.SubItems.Add(pro.BasicUnit);
                //listViewItem.SubItems.Add(pro.PackagingSize);

                lsvGroups.Items.Add(listViewItem);
            }
            lsvGroups.EndUpdate();
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
            }
        }

        private void butEditpro_Click(object sender, EventArgs e)
        {
            if (CreateOrEditProduct != null)
            {
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(GetSelectedProduct());
                CreateOrEditProduct(this, eArgs);
            }
        }

        private void butDeletepro_Click(object sender, EventArgs e)
        {
            MasterProduct pro = this.GetSelectedProduct();
            if (pro != null && MessageBox.Show("Are you sure you want to delete this Product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteProduct(pro);
                }
                catch (Exception ex)
                {
                    throw new LQTUserException(ex.Message);
                }
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

    }
}
