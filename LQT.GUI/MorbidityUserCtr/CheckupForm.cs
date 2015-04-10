
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
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.GUI.Location;
using LQT.Core.UserExceptions;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class CheckupForm : BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private InventoryAssumption _invAssumption;
        private Form _mdiparent;
        private SiteListView _sPlatformView;
        private SiteListView _pBehaviorView;
        private SiteListView _supplyListView;
        private double _maxAttrition = 45;
        private double _minMigration = 5;
        private Color _colorMaxAttrition = Color.Yellow;
        private Color _colorMinMigration = Color.Red;

        public CheckupForm(MorbidityForecast forecast,InventoryAssumption invAssumption, IList<ARTSite> artSites, Form mdiparent)
        {
            this._forecast = forecast;
            this._invAssumption = invAssumption;
            this._artSites = artSites;
            this._mdiparent = mdiparent;

            InitializeComponent();
            
            txtMigration.Text = _minMigration.ToString();
            txtAttrition.Text = _maxAttrition.ToString();

            BuildPatientBehaviorView();
            AddSubItemToPBehaviorView();

            BuildPlatformView();
            BuildSupplyListView();
        }

        public override string Title
        {
            get { return "Review your data"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.InvAssumption;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                if (_forecast.StatusEnum == ForecastStatusEnum.CLOSED)
                    return MorbidityCtrEnum.CalculateForm;

                return MorbidityCtrEnum.Nothing;
            }
        }

        public override bool EnableNextButton()
        {
            if (_forecast.StatusEnum == ForecastStatusEnum.CLOSED)
                return true;

            return false;
        }

        public override string Description
        {
            get
            {
                string desc = "Now that you have finished entering all your data. <br>";
                desc += "Before you prompt the model to begin calculating, " +
                    "take this time to review your data inputs for accuracy." +
                    "Pay special attention to the data inputs that have the " +
                    "greatest impact on the final result.";

                return desc;
            }
        }

        private void BuildPlatformView()
        {
            _sPlatformView = new SiteListView();
            _sPlatformView.MySortBrush = SystemBrushes.ControlLight;
            _sPlatformView.MyHighlightBrush = Brushes.Khaki;
            _sPlatformView.GridLines = true;
            _sPlatformView.MultiSelect = false;
            _sPlatformView.Dock = DockStyle.Fill;
            _sPlatformView.ControlPadding = 4;
            _sPlatformView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            _sPlatformView.Columns.Add(new EXColumnHeader("Test Category", 100));

            EXBoolColumnHeader boolcol = new EXBoolColumnHeader("Test Selected?", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 80);
            boolcol.Editable = false;
            _sPlatformView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("Test Referred?", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 80);
            boolcol.Editable = false;
            _sPlatformView.Columns.Add(boolcol);

            boolcol = new EXBoolColumnHeader("Has Instrument?", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 80);
            boolcol.Editable = false;
            _sPlatformView.Columns.Add(boolcol);

            _sPlatformView.Columns.Add(new EXColumnHeader("# Instrument", 80));
            _sPlatformView.Columns.Add(new EXColumnHeader("Remarks", 300));

            _sPlatformView.DoubleClick += new EventHandler(sListView_DoubleClick);

            tabInstrument.Controls.Add(_sPlatformView);
        }

        private void BuildPatientBehaviorView()
        {
            _pBehaviorView = new SiteListView();
            _pBehaviorView.MySortBrush = SystemBrushes.ControlLight;
            _pBehaviorView.MyHighlightBrush = Brushes.Khaki;
            _pBehaviorView.GridLines = true;
            _pBehaviorView.MultiSelect = false;
            _pBehaviorView.Dock = DockStyle.Fill;
            _pBehaviorView.ControlPadding = 1;
            _pBehaviorView.HeaderStyle = ColumnHeaderStyle.None;

            _pBehaviorView.Columns.Add(new EXColumnHeader("Site Name", 150));
            _pBehaviorView.Columns.Add(new EXColumnHeader("--", 10));
            //adult in treatment attrition
            _pBehaviorView.Columns.Add(new EXColumnHeader("A.T.A", 51));
            //adult in pre-ART attrition
            _pBehaviorView.Columns.Add(new EXColumnHeader("A.P.A.A", 51));
            //adult migration to treatment
            _pBehaviorView.Columns.Add(new EXColumnHeader("A.M", 51));
            _pBehaviorView.Columns.Add(new EXColumnHeader("--", 10));
            _pBehaviorView.Columns.Add(new EXColumnHeader("%Ped in treatment", 51));
            _pBehaviorView.Columns.Add(new EXColumnHeader("%Ped in Pre-ART", 51));
            _pBehaviorView.Columns.Add(new EXColumnHeader("--", 10));
            //pediatric in treatment attrition
            _pBehaviorView.Columns.Add(new EXColumnHeader("P.T.A", 51));
            //pediatric in pre-ART attrition
            _pBehaviorView.Columns.Add(new EXColumnHeader("P.P.A.A", 51));
            //pediatric migration
            _pBehaviorView.Columns.Add(new EXColumnHeader("P.M", 51));
            
            scPBehavior.Panel2.Controls.Add(_pBehaviorView);
        }

        private void BuildSupplyListView()
        {
            _supplyListView = new SiteListView();
            _supplyListView.MySortBrush = SystemBrushes.ControlLight;
            _supplyListView.MyHighlightBrush = Brushes.Khaki;
            _supplyListView.GridLines = true;
            _supplyListView.MultiSelect = false;
            _supplyListView.Dock = DockStyle.Fill;
            _supplyListView.ControlPadding = 1;
            _supplyListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            _supplyListView.Columns.Add(new EXColumnHeader("Product Name", 160));
            _supplyListView.Columns.Add(new EXColumnHeader("Pack Size", 60));
            _supplyListView.Columns.Add(new EXColumnHeader("Unit", 40));
            _supplyListView.Columns.Add(new EXColumnHeader("Pack Cost", 60));
            _supplyListView.Columns.Add(new EXColumnHeader("Packs/Site", 40));
            _supplyListView.Columns.Add(new EXColumnHeader("Usage Rate", 60));
            _supplyListView.Columns.Add(new EXColumnHeader("Quantify According To", 150));
            _supplyListView.Columns.Add(new EXColumnHeader("Applied To", 60));

            tabSupply.Controls.Add(_supplyListView);
        }

        private void sListView_DoubleClick(object sender, EventArgs e)
        {
            if (_sPlatformView.SelectedItems.Count > 0)
            {
                ForlabSite site = ((ARTSite) _sPlatformView.SelectedItems[0].Tag).Site;
                new SiteForm(site, _mdiparent).ShowDialog();
                _forecast = null;
                _artSites = null;
                MorbidityForm.ReInitMorbidityFrm(ref _forecast, ref _invAssumption, ref _artSites);
                _behaviorVisted = false;
                AddSubItemToPlatformView();
            }
        }

        private bool _platformVisted = false;
        private void AddSubItemToPlatformView()
        {
            ClassOfMorbidityTestEnum[] ctest = LqtUtil.EnumToArray<ClassOfMorbidityTestEnum>();
            _sPlatformView.Items.Clear();
            _sPlatformView.BeginUpdate();

            foreach (ARTSite site in _artSites)
            {
                ListViewGroup group = new ListViewGroup(site.Id.ToString(), site.MorbidityCategory.CategoryName + "-> " + site.Site.SiteName);
                _sPlatformView.Groups.Add(group);

                for (int i = 0; i < ctest.Length; i++)
                {
                    EXListViewItem item = new EXListViewItem(ctest[i].ToString()) { Tag = site };
                    string remark = IsValidRow(site, ctest[i]);
                    if (remark != null)
                        item.BackColor = Color.Tomato;
                    item.SubItems.Add(new EXBoolListViewSubItem(site.TestWasSelected(ctest[i])) { BackColor = item.BackColor });
                    if (ctest[i] == ClassOfMorbidityTestEnum.RapidTest || ctest[i] == ClassOfMorbidityTestEnum.Consumable)
                    {
                        item.SubItems.Add(new EXListViewSubItem());
                        item.SubItems.Add(new EXListViewSubItem());
                        item.SubItems.Add(new EXListViewSubItem());
                        item.SubItems.Add(new EXListViewSubItem());
                    }
                    else
                    {
                        item.SubItems.Add(new EXBoolListViewSubItem(site.TestWasReffered(ctest[i])) { BackColor = item.BackColor });
                        item.SubItems.Add(new EXBoolListViewSubItem(site.HasPlatform(ctest[i])) { BackColor = item.BackColor });
                        item.SubItems.Add(new EXListViewSubItem(site.NoOfPlatform(ctest[i]).ToString()) { BackColor = item.BackColor });
                        item.SubItems.Add(new EXListViewSubItem(remark) { BackColor = item.BackColor });
                    }
                    item.Group = group;
                    _sPlatformView.Items.Add(item);
                }
            }
            _platformVisted = true;
            _sPlatformView.EndUpdate();
        }

        private bool _behaviorVisted = false;
        private void AddSubItemToPBehaviorView()
        {
            _pBehaviorView.Items.Clear();
            _pBehaviorView.BeginUpdate();

            foreach (ARTSite site in _artSites)
            {
                EXListViewItem item = new EXListViewItem(site.Site.SiteName) { Tag = site };

                item.SubItems.Add(new EXListViewSubItem() { BackColor = Color.WhiteSmoke });
                item.SubItems.Add(new EXListViewSubItem(site.AITAnnualPatientAttrition.ToString()) { BackColor = CheckForAttritionAndMigration(site, 1, Color.PaleGoldenrod) });
                item.SubItems.Add(new EXListViewSubItem(site.AIPAnualPatientAttrition.ToString()) { BackColor = CheckForAttritionAndMigration(site, 2, Color.PaleGoldenrod) });
                item.SubItems.Add(new EXListViewSubItem(site.AIPAnnualMigration.ToString()) { BackColor = CheckForAttritionAndMigration(site, 3, Color.PaleGoldenrod) });

                item.SubItems.Add(new EXListViewSubItem() { BackColor = Color.WhiteSmoke });
                item.SubItems.Add(new EXListViewSubItem(site.NTTPercentOfChildren.ToString()) { BackColor = Color.PaleGoldenrod });
                item.SubItems.Add(new EXListViewSubItem(site.NTPTPercentOfChildren.ToString()) { BackColor = Color.PaleGoldenrod });

                item.SubItems.Add(new EXListViewSubItem() { BackColor = Color.WhiteSmoke });
                item.SubItems.Add(new EXListViewSubItem(site.PITAnnualPatientAttrition.ToString()) { BackColor = Color.PaleGoldenrod });
                item.SubItems.Add(new EXListViewSubItem(site.PIPAnualPatientAttrition.ToString()) { BackColor = Color.PaleGoldenrod });
                item.SubItems.Add(new EXListViewSubItem(site.PIPAnnualMigration.ToString()) { BackColor = Color.PaleGoldenrod });

                _pBehaviorView.Items.Add(item);
            }
            _behaviorVisted = true;
            _pBehaviorView.EndUpdate();
        }

        private bool _supplyVisted = false;
        private void AddSubItemToSupplyListView()
        {
            IList<QuantificationMetric> result = DataRepository.GetListOfAllQuantificationMetrics();
            
            _supplyListView.Groups.Add(new ListViewGroup(ClassOfMorbidityTestEnum.CD4.ToString(), ClassOfMorbidityTestEnum.CD4.ToString()));
            _supplyListView.Groups.Add(new ListViewGroup(ClassOfMorbidityTestEnum.Chemistry.ToString(), ClassOfMorbidityTestEnum.Chemistry.ToString()));
            _supplyListView.Groups.Add(new ListViewGroup(ClassOfMorbidityTestEnum.Hematology.ToString(), ClassOfMorbidityTestEnum.Hematology.ToString()));
            _supplyListView.Groups.Add(new ListViewGroup(ClassOfMorbidityTestEnum.ViralLoad.ToString(), ClassOfMorbidityTestEnum.ViralLoad.ToString()));
            _supplyListView.Groups.Add(new ListViewGroup(ClassOfMorbidityTestEnum.RapidTest.ToString(), ClassOfMorbidityTestEnum.RapidTest.ToString()));
            _supplyListView.Groups.Add(new ListViewGroup(ClassOfMorbidityTestEnum.OtherTest.ToString(), ClassOfMorbidityTestEnum.OtherTest.ToString()));
            _supplyListView.Groups.Add(new ListViewGroup(ClassOfMorbidityTestEnum.Consumable.ToString(), ClassOfMorbidityTestEnum.Consumable.ToString()));
            foreach (QuantificationMetric q in result)
            {
                EXListViewItem item = new EXListViewItem(q.Product.ProductName) { Tag = q.ClassOfTest };

                item.SubItems.Add(new EXListViewSubItem(q.Product.GetActiveProductPrice(DateTime.Now).PackSize.ToString()));
                item.SubItems.Add(new EXListViewSubItem(q.Product.BasicUnit));
                decimal price = q.Product.GetActiveProductPrice(DateTime.Now).Price;
                if (price > 0)
                    item.SubItems.Add(new EXListViewSubItem(price.ToString()));
                else
                    item.SubItems.Add(new EXListViewSubItem() { BackColor = _colorMinMigration });
                item.SubItems.Add(new EXListViewSubItem(q.Product.MinimumPackSize.ToString()));

                double rate = q.UsageRate;
                if (rate > 0)
                    item.SubItems.Add(new EXListViewSubItem(rate.ToString()));
                else
                    item.SubItems.Add(new EXListViewSubItem() { BackColor = _colorMinMigration});
                item.SubItems.Add(new EXListViewSubItem(q.QuantifyMenu.DisplayTitle));
                item.SubItems.Add(new EXListViewSubItem(q.CollectionSupplieAppliedTo));
                AddToGroup(_supplyListView, item);
                _supplyListView.Items.Add(item);
            }
            _supplyVisted = true;
            result.Clear();
            result = null;
        }

        private void AddToGroup(ListView lv, ListViewItem li)
        {
            foreach (ListViewGroup group in lv.Groups)
            {
                if (group.Header == li.Tag.ToString())
                {
                    li.Group = group;
                    break;
                }
            }
        }
        private string IsValidRow(ARTSite site, ClassOfMorbidityTestEnum ctest)
        {
            if (ctest == ClassOfMorbidityTestEnum.RapidTest || ctest == ClassOfMorbidityTestEnum.Consumable)
                return null;

            if (site.TestWasSelected(ctest) && !site.TestWasReffered(ctest))
            {
                if (site.NoOfPlatform(ctest) == 0)
                    return "Site has not instrument listed under this test category.";
                return null;
            }

            if (site.TestWasSelected(ctest) && site.TestWasReffered(ctest))
            {
                if (site.NoOfPlatform(ctest) > 0)
                    return "Site has instrument listed under this test category but it refer it's samples to other.";
                
                int refId = site.TestRefferedSiteId(ctest);
                foreach (ARTSite s in _artSites)
                {
                    if (refId == s.Site.Id)
                    {
                        if (s.TestWasSelected(ctest))
                            return null;
                        return "Site listed to refer it's samples was not selected to do this test category.";
                    }
                }
                return "Site listed to refer it's samples was not included in this forecast.";
            }

            return null;
        }

        private Color CheckForAttritionAndMigration(ARTSite site, int columnIndex, Color defColor)
        {   
            if (columnIndex == 1)
            {
                if (site.AITAnnualPatientAttrition > _maxAttrition)
                    return _colorMaxAttrition;
            }
            else if (columnIndex == 2)
            {
                if (site.AIPAnualPatientAttrition > _maxAttrition)
                    return _colorMaxAttrition;
            }
            else if (columnIndex == 3)
            {
                if(site.AIPAnnualMigration < _minMigration)
                    return _colorMinMigration;
            }
            
            return defColor;
        }

        private void butRecheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMigration.Text) || string.IsNullOrEmpty(txtAttrition.Text))
                return;
            _maxAttrition = double.Parse(txtAttrition.Text);
            _minMigration = double.Parse(txtMigration.Text);
            
            AddSubItemToPBehaviorView();
        }

        private void OnlyDigt_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (!_behaviorVisted)
                {
                    this.Cursor = Cursors.WaitCursor;
                    AddSubItemToPBehaviorView();
                    this.Cursor = Cursors.Default;
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (!_platformVisted)
                {
                    this.Cursor = Cursors.WaitCursor;
                    AddSubItemToPlatformView();
                    this.Cursor = Cursors.Default;
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                if (!_supplyVisted)
                {
                    this.Cursor = Cursors.WaitCursor;
                    AddSubItemToSupplyListView();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void butCalculate_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Are you sure you want to do calculation", "Data Model Calculation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            try
            {
                FrmProgress frm = new FrmProgress(_forecast, _invAssumption);
                frm.InitializeTimer();
                frm.ShowDialog();

                MorbidityForm.LoadForecastResult();
            }
            catch(Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText("There is an error to complete the forecast. See below for detail.", ex)).ShowDialog();
            }
        }
    }
}
