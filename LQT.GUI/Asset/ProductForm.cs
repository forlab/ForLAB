
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

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Asset
{
    public partial class ProductForm : Form
    {
        private MasterProduct _product;
        private Form _mdiparent;
        private bool _reloadCtr = true;

        private bool _enableCtr;

        public ProductForm(MasterProduct pro, Form mdiparent)
        {
            this._product = pro;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            LoadProductCtr();
        }

        public ProductForm(MasterProduct pro, Form mdiparent, bool reloadctr)
            : this(pro, mdiparent)
        {
            this._reloadCtr = reloadctr;
        }

        private void LoadProductCtr()
        {
            SetControlState();
            PopProductType();
            PopTestSpecification();
            BindProduct();
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message,true);
                //DataRepository.CloseSession();

                ProductType pt = _product.ProductType;

                _product = new MasterProduct();
                _product.ProductType = pt;

                LoadProductCtr();
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
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, _reloadCtr);
                //DataRepository.CloseSession();
                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void PopProductType()
        {
            comCategory.DataSource = DataRepository.GetAllProductType();

            if (comCategory.Items.Count > 0)
                comCategory.SelectedIndex = -1;
           
        }

        private void PopTestSpecification()
        {
            comSpecification.Items.Clear();
            comSpecification.Items.AddRange(Enum.GetNames(typeof(TestingSpecificationGroup)));
        }

        private void SetControlState()
        {
            this.txtName.Text = "";
            this.txtBasicunit.Text = "";
            this.txtNote.Text = "";
            this.txtSerialno.Text = "";
            this.txtSpecification.Text = "";
            this.txtminimumPacks.Text = "";
           
        }

        public LQTUserMessage SaveOrUpdateObject()
        {
            if (txtName.Text.Trim() == "")
                throw new LQTUserException("Product name must not be empty.");
            else if (DataRepository.GetProductByName(txtName.Text.Trim()) != null &&
                _product.Id <= 0)
                throw new LQTUserException("The Product Name already exists.");

            if (txtBasicunit.Text.Trim() == "")//b
                throw new LQTUserException("Basic Unit must not be empty.");

            if (txtminimumPacks.Text.Trim() == "")//b
                throw new LQTUserException("Package Size must not be empty.");
            if (_product.ProductPrices.Count <= 0)
            {
                throw new LQTUserException("Price must not be empty.");
            }

            _product.ProductName = this.txtName.Text.Trim();
            _product.BasicUnit = this.txtBasicunit.Text;
            _product.ProductNote = this.txtNote.Text;
            _product.SerialNo = this.txtSerialno.Text;
            _product.Specification = this.txtSpecification.Text;
            _product.MinimumPackSize = int.Parse(txtminimumPacks.Text);
           

            if (_product.ProductType == null)
                _product.ProductType = LqtUtil.GetComboBoxValue<ProductType>(comCategory);
            if(_product.ProductType.UseInDemography )
            {
                if (_product.ProductType.ClassOfTestToEnum == ClassOfMorbidityTestEnum.RapidTest)
                    _product.RapidTestGroup = comSpecification.Text;
                else
                    _product.RapidTestGroup = null;
            }
            else
                _product.RapidTestGroup = null;

            DataRepository.SaveOrUpdateProduct(_product);

            return new LQTUserMessage("Product was saved or updated successfully.");
        }

        private void BindProduct()
        {
            if (_product.ProductType != null)
            {
                comCategory.SelectedValue = _product.ProductType.Id;
                comCategory.Enabled = false;
            }

            if (_product.Id > 0)
            {
                this.txtName.Text = _product.ProductName;
                this.txtBasicunit.Text = _product.BasicUnit;
                this.txtNote.Text = _product.ProductNote;
                this.txtSerialno.Text = _product.SerialNo;
                this.txtSpecification.Text = _product.Specification;
                this.txtminimumPacks.Text = _product.MinimumPackSize.ToString();

               // if(_product.SlowMoving!=null)
               
                if (_product.ProductType.UseInDemography)
                {
                    if (_product.ProductType.ClassOfTestToEnum == ClassOfMorbidityTestEnum.RapidTest)
                        comSpecification.Text = _product.RapidTestGroup;
                }
            }
            BindPrices();
        }

        public void RebindProduct(MasterProduct pro)
        {
            this._product = pro;
            BindProduct();
        }

        private void BindPrices()
        {
            lsvPrice.BeginUpdate();
            lsvPrice.Items.Clear();

            foreach (ProductPrice pp in _product.ProductPrices)
            {
                ListViewItem li = new ListViewItem(String.Format("{0:0.##}", pp.Price).ToString()) { Tag = pp };
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtminimumPacks_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))// || (x == 46)) 
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductType pt= LqtUtil.GetComboBoxValue<ProductType>(comCategory);
            if (pt != null)
            {
                if (pt.UseInDemography)
                {
                    if (pt.ClassOfTestToEnum == ClassOfMorbidityTestEnum.RapidTest)
                    {
                        comSpecification.Enabled = true;
                        return;
                    }
                }
            }
            comSpecification.Enabled = false;
        }

    }
}
