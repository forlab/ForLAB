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
    public partial class ProductPane : BaseUserControl
    {
        private bool _enableCtr;
        private MasterProduct _product;

        public ProductPane(MasterProduct pro)
            : this(pro, false)
        {
        }

        public ProductPane(MasterProduct pro, bool enableCtr)
        {
            this._product = pro;
            this._enableCtr = enableCtr;

            InitializeComponent();
            SetControlState();
            PopProductType();
            BindProduct();
        }

        private void PopProductType()
        {
            comCategory.DataSource = DataRepository.GetAllProductType();
        }

        private void SetControlState()
        {
            this.txtName.Enabled = _enableCtr;
            this.comCategory.Enabled = _enableCtr;
            this.txtBasicunit.Enabled = _enableCtr;
            this.txtNote.Enabled = _enableCtr;
            this.txtSerialno.Enabled = _enableCtr;
            this.txtSpecification.Enabled = _enableCtr;
            this.butNewprice.Enabled = _enableCtr;
            this.lsvPrice.Enabled = _enableCtr;
            this.txtminimumPacks.Enabled = _enableCtr;
        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
            if (txtName.Text.Trim() == "")
                throw new LQTUserException("Product name must not be empty.");
            else if (DataRepository.GetProductByName(txtName.Text.Trim()) != null &&
                _product.Id <= 0)
                throw new LQTUserException("The Product Name already exists.");

            _product.ProductName = this.txtName.Text;
            _product.BasicUnit = this.txtBasicunit.Text;
            _product.ProductNote = this.txtNote.Text;
            _product.SerialNo = this.txtSerialno.Text;
            _product.Specification = this.txtSpecification.Text;
            _product.MinimumPackSize = int.Parse(txtminimumPacks.Text);

            if (_product.ProductType == null)
                _product.ProductType = LqtUtil.GetComboBoxValue<ProductType>(comCategory);

            DataRepository.SaveOrUpdateProduct(_product);

            return new LQTUserMessage("Product was saved or updated successfully.");
        }

        public void RebindProduct(MasterProduct pro)
        {
            this._product = pro;
            BindProduct();
        }

        private void BindProduct()
        {
            if (_product.ProductType != null)
            {
                comCategory.SelectedValue = _product.ProductType.Id;
            }

            if (_product.Id > 0)
            {
                this.txtName.Text = _product.ProductName;
                this.txtBasicunit.Text = _product.BasicUnit;
                this.txtNote.Text = _product.ProductNote;
                this.txtSerialno.Text = _product.SerialNo;
                this.txtSpecification.Text = _product.Specification;
                this.txtminimumPacks.Text = _product.MinimumPackSize.ToString();
            }
            BindPrices();
        }

        private void BindPrices()
        {
            lsvPrice.BeginUpdate();
            lsvPrice.Items.Clear();
            
            foreach (ProductPrice pp in _product.ProductPrices)
            {
                ListViewItem li = new ListViewItem(pp.Price.ToString()) { Tag = pp };
                li.SubItems.Add(pp.PackSize.ToString());
                li.SubItems.Add(pp.FromDate.ToShortDateString());
                lsvPrice.Items.Add(li);
            }

            lsvPrice.EndUpdate();
        }

        

        private void butNewprice_Click(object sender, EventArgs e)
        {
            FrmPriceinput frm = new FrmPriceinput();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _product.ProductPrices.Add(frm.GetProductPrice);
                BindPrices();
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (lsvPrice.SelectedItems.Count > 0)
            {
                ProductPrice pp = (ProductPrice)lsvPrice.SelectedItems[0].Tag;
                FrmPriceinput frm = new FrmPriceinput(pp);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //_product.ProductPrices.Add(frm.GetProductPrice);
                    BindPrices();
                }
            }
        }

        private void lsvPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPrice.SelectedItems.Count > 0)
                butEdit.Enabled = true;
            else
                butEdit.Enabled = false;
        }

    }
}
