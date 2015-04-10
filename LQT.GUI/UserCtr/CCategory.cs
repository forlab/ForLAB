
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
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI.UserCtr
{
    public partial class CCategory : BaseHistoricalData
    {

        private int _newCatIndex = -1;
        public CCategory(ForecastInfo finfo)
        {
            this._forecastInfo = finfo;
            InitializeComponent();
            base._lvHistData = lvProduct;
            base._chartSd = chart1;
            InitGridView();

            BindCategorys();
            ShowSummary();
        }


        private void BindCategorys()
        {
            lvCategory.BeginUpdate();
            lvCategory.Items.Clear();

            foreach (ForecastCategory s in _forecastInfo.ForecastCategories)
            {
                ListViewItem li = new ListViewItem(s.CategoryName) { Tag = s };
                lvCategory.Items.Add(li);
            }

            // ShowSummary();//b
            lvCategory.EndUpdate();
        }

        private void BindForecastSite()
        {
            lvSite.BeginUpdate();
            lvSite.Items.Clear();
            int count = 0;
            if (_activeCategory != null)
            {
                foreach (ForecastCategorySite s in _activeCategory.CategorySites)
                {
                    ListViewItem li = new ListViewItem(s.Site.SiteName) { Tag = s.Id };
                    lvSite.Items.Add(li);
                    if (count == _newCatIndex)
                    {
                        li.Selected = true;
                        _newCatIndex = -1;
                    }
                    count++;
                }
                lbtAddsite.Enabled = true;
            }
            else
                lbtAddsite.Enabled = false;
            lvSite.EndUpdate();
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
            {
                _activeCategory = (ForecastCategory)lvCategory.SelectedItems[0].Tag; //_forecastInfo.GetForecastCategory(id);
                txtSitename.Text = _activeCategory.CategoryName;
                txtPcount.Text = _activeCategory.GetUniqFSProduct().Count.ToString();
            }
            else
            {
                _activeCategory = null;
                txtSitename.Text = "";
                txtPcount.Text = "";
            }

            BindForecastCategory();
            BindForecastSite();
            BindForecastProduct();
        }

        private void BindForecastCategory()
        {
            if (_activeCategory != null)
            {
                butSave.Enabled = true;
              //  txtCatname.Enabled = true;//b
                txtCatname.Text = _activeCategory.CategoryName;
                butDelete.Enabled = true;
            }
            else
            {
               // txtCatname.Enabled = false;//b
                butSave.Enabled = false;
                butDelete.Enabled = false;
            }
        }

        private void BindForecastProduct()
        {
            lbtRemoveproduct.Enabled = false;
            lbtAddduration.Enabled = false;

            if (_activeCategory != null && lvCategory.SelectedItems.Count > 0)
            {
                base.BindForecastDataUsage(_activeCategory.Id, lvCategory.SelectedItems[0].Index);
                lbtAddproduct.Enabled = true;
            }
            else
            {
                lbtAddproduct.Enabled = false;
                lvProduct.BeginUpdate();
                lvProduct.Items.Clear();
                lvProduct.EndUpdate();
            }
        }

        private void lbtAddsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddSitesToCategory())
            {
                BindForecastSite();
            }
        }


        private void lbtRemovesite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvSite.SelectedItems.Count > 0)
            {
                int id = (int)lvSite.SelectedItems[0].Tag;
                ForecastCategorySite fs;

                if (id > 0)
                    fs = _activeCategory.GetFCatSite(id);
                else
                    fs = _activeCategory.CategorySites[lvSite.SelectedItems[0].Index];

                _activeCategory.CategorySites.Remove(fs);

                BindForecastSite();
            }
        }

        private void lvSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSite.SelectedItems.Count <= 0)
                lbtRemovesite.Enabled = false;
            else
            {
                if (!lbtRemovesite.Enabled)
                    lbtRemovesite.Enabled = true;
            }
        }

        private void lvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProduct.SelectedItems.Count <= 0)
            {
                lbtRemoveproduct.Enabled = false;
                lbtAddduration.Enabled = false;
            }
            else
            {
                lbtRemoveproduct.Enabled = true;
                lbtAddduration.Enabled = true;
            }
        }


        private void lbtAddproduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddProdutOrTestDatausage())
                BindForecastProduct();

            txtSitename.Text = _activeCategory.CategoryName; //b
            txtPcount.Text = _activeCategory.GetUniqFSProduct().Count.ToString();//b

        }

        private void lbtRemoveproduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RemoveDataUsageFromCategory())
                BindForecastProduct();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            _activeCategory.CategoryName = txtCatname.Text.Trim();

            BindCategorys();
            BindForecastCategory();
            txtSitename.Text = _activeCategory.CategoryName;
            txtPcount.Text = _activeCategory.GetUniqFSProduct().Count.ToString();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want to delete it? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _forecastInfo.ForecastCategories.Remove(_activeCategory);
                _activeCategory = null;
                BindCategorys();
                BindForecastCategory();
                BindForecastSite();
                BindForecastProduct();
                ShowSummary();//b
                txtSitename.Text = "";//b
                txtPcount.Text = "";//b
                txtCatname.Text = "";//b
            }
        }

        private void butAddnew_Click(object sender, EventArgs e)
        {
            ForecastCategory cat = new ForecastCategory();
            cat.ForecastInfo = _forecastInfo;
            cat.CategoryName = txtCatname.Text.Trim();
            if (cat.CategoryName != "")//b
            {
                ForecastCategory catagory = DataRepository.GetForecastCategoryByName(_forecastInfo.Id, cat.CategoryName);//b
                if (catagory != null)//b
                {
                    MessageBox.Show("Duplicate Category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    for(int i=0;i<lvCategory.Items.Count;)
                    {
                        if (lvCategory.Items[i].Text.Trim() == txtCatname.Text.Trim())
                        {
                            MessageBox.Show("Duplicate Category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else i++;
                    }
                
                    _forecastInfo.ForecastCategories.Add(cat);

                    _activeCategory = cat;
                    _newCatIndex = lvCategory.Items.Count;
                    BindCategorys();
                    BindForecastCategory();
                    BindForecastSite();
                    BindForecastProduct();
                    ShowSummary();//b
                
                  }
            }
            else
            {
                MessageBox.Show("Category Name Can not be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void lbtAddduration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddDurationDatausage())
                BindForecastProduct();
        }

        private void ShowSummary()
        {
            txttotalsite.Text = _forecastInfo.ForecastCategories.Count.ToString();
            txtTotalpcount.Text = DataRepository.FCTotalProductCount(_forecastInfo.Id).ToString();

        }

        private void lbtImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ImportConsumption())
            {
                BindCategorys();
                ShowSummary();
            }
        }

        private void lbtAddMultipro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectSiteAndProduct())
            {
                BindCategorys();
                ShowSummary();
            }
        }

        protected override void OnStandardDivationChanged(StandardDivationEventArgs e)
        {
            //base.OnStandardDivationChanged(e);
            this.lblMean.Text = e.Mean;
            this.lblDeviation.Text = e.Deviation;
            this.lblMedian.Text = e.Median;

        }
    }
}
