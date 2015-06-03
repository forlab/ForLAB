
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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class SiteSelection : BaseMorbidityControl
    {
        private SiteListView _sListView;
        private MorbidityForecast _forecast;
        private MorbidityCategory _activeCategory;
        private IList<ForlabSite> _sites;
        private IList<ForlabRegion> _regions;
        private IList<ARTSite> _artSites;
        private IList<ARTSite> _deletedArtSites;
        private bool _isedited = false;
        
        enum BooleanColumnName
        {
            VCT,
            CD4,
            Chemistry,
            Hematology,
            ViralLoad,
            OtherTest,
            Consumable
        }

        public SiteSelection(MorbidityForecast forecast, IList<ARTSite> artsites)
        {
            this._forecast = forecast;
            this._artSites = artsites;
            _sites = DataRepository.GetAllSite();
            _regions = DataRepository.GetAllRegion();
            _deletedArtSites = new List<ARTSite>();

            InitializeComponent();

            BindCategorys();

            if (_forecast.UseRegionAsCat)
                rbtRegion.Checked = true;
            else
                rbtUserdifiend.Checked = true;
            SetStatusOfCatRadioButton();

            rbtRegion.CheckedChanged +=new EventHandler(UseCategory_CheckedChanged);
            rbtUserdifiend.CheckedChanged +=new EventHandler(UseCategory_CheckedChanged);
            LoadSiteListView();
        }

        public override string Title
        {
            get { return "Sites included in quantification"; }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.OptRecentData;
            }
        }

        public override bool EnableNextButton()
        {
            return _artSites.Count > 0;
        }

        private void SetStatusOfCatRadioButton()
        {
            if (_artSites.Count > 0)
            {
                rbtRegion.Enabled = false;
                rbtUserdifiend.Enabled = false;
            }
        }

        private void LoadSiteListView()
        {
            _sListView = new SiteListView();
            _sListView.MySortBrush = SystemBrushes.ControlLight;
            _sListView.MyHighlightBrush = Brushes.Goldenrod;
            _sListView.GridLines = true;
            _sListView.MultiSelect = false;
            _sListView.Dock = DockStyle.Fill;
            _sListView.ControlPadding = 4;
            _sListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            _sListView.Scrollable = true;
           
            //add SmallImageList to ListView - images will be shown in ColumnHeaders
            ImageList colimglst = new ImageList();
            colimglst.Images.Add("down", trueFalseImageList.Images[2]);
            colimglst.Images.Add("up", trueFalseImageList.Images[3]);
            colimglst.ColorDepth = ColorDepth.Depth32Bit;
            colimglst.ImageSize = new Size(20, 20); // this will affect the row height
            _sListView.SmallImageList = colimglst;
            
            //add columns and items
            _sListView.Columns.Add(new EXColumnHeader("Category/Region", 100));
            _sListView.Columns.Add(new EXColumnHeader("ART Site", 150));
            _sListView.Columns.Add(new EXColumnHeader("Site Type", 80));
            
            EXBoolColumnHeader boolcol = new EXBoolColumnHeader("VCT",trueFalseImageList.Images[0],trueFalseImageList.Images[1], 60);
            boolcol.Editable = true;
            _sListView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("CD4", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 60);
            boolcol.Editable = true;
            _sListView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("Chemistry", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 60);
            boolcol.Editable = true;
            _sListView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("Hematology", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 60);
            boolcol.Editable = true;
            _sListView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("Viral Load", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 60);
            boolcol.Editable = true;
            _sListView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("Other Test", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 60);
            boolcol.Editable = true;
            _sListView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("Consumable", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 60);
            boolcol.Editable = true;
            _sListView.Columns.Add(boolcol);
            _sListView.BoolListViewSubItemValueChanged += new EventHandler<EXBoolListViewSubItemEventArgs>(sListView_BoolListViewSubItemValueChanged);
            _sListView.SelectedIndexChanged += new EventHandler(sListView_SelectedIndexChanged);

            panSites.Controls.Add(_sListView);
        }

        private void sListView_BoolListViewSubItemValueChanged(object sender, EXBoolListViewSubItemEventArgs e)
        {
            ARTSite site = (ARTSite)e.ListVItem.Tag;
         
            BooleanColumnName colname = (BooleanColumnName)e.Subitem.ColumnName;
            switch (colname)
            {
                case BooleanColumnName.VCT:
                    site.ForecastVCT = e.Subitem.BoolValue;
                    break;
                case BooleanColumnName.CD4:
                    site.ForecastCD4 = e.Subitem.BoolValue;
                    break;
                case BooleanColumnName.Chemistry:
                    site.ForecastChemistry = e.Subitem.BoolValue;
                    break;
                case BooleanColumnName.Hematology:
                    site.ForecastHematology = e.Subitem.BoolValue;
                    break;
                case BooleanColumnName.ViralLoad:
                    site.ForecastViralLoad = e.Subitem.BoolValue;
                    break;
                case BooleanColumnName.OtherTest:
                    site.ForecastOtherTest = e.Subitem.BoolValue;
                    break;
                case BooleanColumnName.Consumable:
                    site.ForecastConsumable = e.Subitem.BoolValue;
                    break;
            }
            _isedited = true;
        }

        private IList<ARTSite> GetARTSiteByCategory(int catid)
        {
            IList<ARTSite> result = new List<ARTSite>();

            foreach (ARTSite s in _artSites)
            {
                if (s.MorbidityCategory.Id == catid)
                    result.Add(s);
            }

            return result;
        }

        private void BindArtSites()
        {
            _sListView.Items.Clear();
            _sListView.BeginUpdate();
            
            if (_activeCategory != null)
            {
                foreach (ARTSite site in GetARTSiteByCategory( _activeCategory.Id))
                {
                    EXListViewItem item = new EXListViewItem(site.MorbidityCategory.CategoryName) { Tag = site };

                    item.SubItems.Add(new EXListViewSubItem(site.Site.SiteName));
                    item.SubItems.Add(new EXListViewSubItem(site.Site.SiteCategory != null ? site.Site.SiteCategory.CategoryName : ""));

                    item.SubItems.Add(new EXBoolListViewSubItem(site.ForecastVCT, BooleanColumnName.VCT));
                    item.SubItems.Add(new EXBoolListViewSubItem(site.ForecastCD4, BooleanColumnName.CD4));
                    item.SubItems.Add(new EXBoolListViewSubItem(site.ForecastChemistry, BooleanColumnName.Chemistry));
                    item.SubItems.Add(new EXBoolListViewSubItem(site.ForecastHematology, BooleanColumnName.Hematology));
                    item.SubItems.Add(new EXBoolListViewSubItem(site.ForecastViralLoad, BooleanColumnName.ViralLoad));
                    item.SubItems.Add(new EXBoolListViewSubItem(site.ForecastOtherTest, BooleanColumnName.OtherTest));
                    item.SubItems.Add(new EXBoolListViewSubItem(site.ForecastConsumable, BooleanColumnName.Consumable));

                    _sListView.Items.Add(item);
                }
                lbtAddsite.Enabled = true;
            }
            else
            {
                lbtAddsite.Enabled = false;
                lbtRemovesite.Enabled = false;
            }
            _sListView.EndUpdate();
        }
        
        private void CreateCategoryFromRegion()
        {
            foreach (ForlabRegion r in _regions)
            {
                MorbidityCategory cat = new MorbidityCategory();
                cat.CategoryName = r.RegionName;
                cat.RegionId = r.Id;
                cat.MorbidityForecast = _forecast;
                _forecast.MorbidityCategories.Add(cat);
            }
        }

        private void BindCategorys()
        {
            lvCategory.BeginUpdate();
            lvCategory.Items.Clear();

            foreach (MorbidityCategory cat in _forecast.MorbidityCategories)
            {
                ListViewItem li = new ListViewItem(cat.CategoryName) { Tag = cat };
                lvCategory.Items.Add(li);
            }

            lvCategory.EndUpdate();
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
            {
                _activeCategory = (MorbidityCategory)lvCategory.SelectedItems[0].Tag; 
                if (_activeCategory.Id < 0)
                    DataRepository.SaveOrUpdateMorbidityForecast(_forecast);
                txtCatname.Text = _activeCategory.CategoryName;
            }
            else
            {
                _activeCategory = null;
                txtCatname.Text = "";
            }

            BindForecastCategory();
            BindArtSites();
        }

        private void BindForecastCategory()
        {
            if (_activeCategory != null && !_forecast.UseRegionAsCat)
            {
                butSave.Enabled = true;
                txtCatname.Enabled = true;
                txtCatname.Text = _activeCategory.CategoryName;

                if (_activeCategory.Id > 0)
                    butDelete.Enabled = true;
                else
                    butDelete.Enabled = false;
                butAddnew.Enabled = true;
            }
            else
            {
                txtCatname.Enabled = false;
                butSave.Enabled = false;
                butDelete.Enabled = false;
                butAddnew.Enabled = false;
            }
        }

        private void lbtAddsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddSitesToCategory())
            {
                BindArtSites();
                SetStatusOfCatRadioButton();

                OnNextButtonStatusChanged(true);
                _isedited = true;
            }
        }

        private IList<int> GetSelectedSiteId()
        {
            IList<int> result = new List<int>();
            foreach (ARTSite s in _artSites)
            {
                result.Add(s.Site.Id);
            }
            return result;
        }
        public bool AddSitesToCategory()
        {
            FrmSelectSite frm;
            if (_forecast.UseRegionAsCat)
                frm = new FrmSelectSite(GetSelectedSiteId(), _sites, _activeCategory.RegionId);
            else
                frm = new FrmSelectSite(GetSelectedSiteId(), _sites);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (ForlabSite site in frm.SelectedSites)
                {
                    ARTSite artsite = new ARTSite();
                    artsite.Site = site;
                    artsite.MorbidityCategory= _activeCategory;

                    //_activeCategory.ARTSites.Add(site);
                    _artSites.Add(artsite);
                }

                //OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }
        private void lbtRemovesite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ARTSite art = (ARTSite)_sListView.SelectedItems[0].Tag;
            
            _artSites.Remove(art);
            _deletedArtSites.Add(art);

            BindArtSites();

            if (_artSites.Count == 0)
                OnNextButtonStatusChanged(false);
            _isedited = true;
        }

        private void sListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sListView.SelectedItems.Count <= 0)
                lbtRemovesite.Enabled = false;
            else
            {
                if (!lbtRemovesite.Enabled)
                    lbtRemovesite.Enabled = true;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            _activeCategory.CategoryName = txtCatname.Text;

            try
            {
               DataRepository.SaveOrUpdateMorbidityForecast(_forecast);
               BindCategorys();
            }
            catch
            {
                MessageBox.Show("Error: unable to save ART category");
            }            
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want to delete it? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _forecast.MorbidityCategories.Remove(_activeCategory);
                    DataRepository.SaveOrUpdateMorbidityForecast(_forecast);
                    _activeCategory = null;

                    BindCategorys();
                    BindForecastCategory();
                    BindArtSites();
                }
                catch
                {
                    MessageBox.Show("Error: unable to delete ART category");
                }
            }
        }

        private void butAddnew_Click(object sender, EventArgs e)
        {
            _activeCategory = new MorbidityCategory();
            _activeCategory.CategoryName = "new category";
            _activeCategory.MorbidityForecast = _forecast;
            _forecast.MorbidityCategories.Add(_activeCategory);
            
            BindCategorys();
            BindForecastCategory();
            BindArtSites();
        }

        public override bool DoSomthingBeforeUnload()
        {
            //bool result = true;
            if (_isedited)
            {
                DataRepository.BatchSaveARTSite(_artSites);
                DataRepository.BatchDeleteARTSite(_deletedArtSites);
                MorbidityForm.ReInitMorbidityFrm();
            }
            return true;
        }

        private void UseCategory_CheckedChanged(object sender, EventArgs e)
        {
            _activeCategory = null;
            _forecast.MorbidityCategories.Clear();
            _forecast.UseRegionAsCat = rbtRegion.Checked;

            if (rbtRegion.Checked)
            {                
                CreateCategoryFromRegion();
            }
            BindCategorys();
            BindForecastCategory();
            lbtAddsite.Enabled = false;
        }

        private void butImportPatient_Click(object sender, EventArgs e)
        {
            FrmImportCPN frm = new FrmImportCPN(_forecast, _artSites, GetSelectedSiteId());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindArtSites();
                SetStatusOfCatRadioButton();
                //uncommented on May 12 2014
                OnNextButtonStatusChanged(true);
                _isedited = true;
            }
        }

    }
}
