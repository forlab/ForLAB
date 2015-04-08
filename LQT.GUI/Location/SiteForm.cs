
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

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Location
{
    public partial class SiteForm : Form
    {
        private ForlabSite _site;
        //  private SitePane _sPane;
        private Form _mdiparent;
        private bool _reloadCtr = true;
        private bool _isedited = false;

        public event EventHandler OnDataUsageEdit;
        private bool _enableCtr;


        public static int _serviceAddedbyDefault = 0;

        public SiteForm(ForlabSite site, Form mdiparent, bool reloadctr)
            : this(site, mdiparent)
        {
            this._reloadCtr = reloadctr;
        }

        public SiteForm(ForlabSite site, Form mdiparent)
        {
            this._site = site;
            this._mdiparent = mdiparent;

            InitializeComponent();
            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            LoadSiteCtr();
            SetRefSites();
        }

        private void SetRefSites()
        {
            comCD4RefSite.SetCallingSite(_site,"CD4");
            comChemistryRefSite.SetCallingSite(_site, "Chemistry");
            comHematologyRefSite.SetCallingSite(_site, "Hematology");
            comOtheRefSite.SetCallingSite(_site, "Other");
            comViralLoadRefSite.SetCallingSite(_site, "ViralLoad");
        }

        private void LoadSiteCtr()
        {
            // tableLayoutPanel2.Controls.Clear();//b
            // _sPane = new SitePane(_site, true);
            //_sPane.cr += new EventHandler(OnCreateOrEditSite);
            // _sPane.Dock = DockStyle.Fill;
            // _sPane.OnDataUsageEdit += new EventHandler(_sPane_OnDataUsageEdit);
            // tableLayoutPanel2.Controls.Add(_sPane);//b
            this.OnDataUsageEdit += new EventHandler(_sPane_OnDataUsageEdit);

            this._enableCtr = true;
            lsvInstrument.AddNoneEditableColumn(0);
            lsvInstrument.AddNoneEditableColumn(1);

            //lsvInstrument.OnSubitemTextChanged += new EventHandler(lsvInstrument_OnSubitemTextChanged);
            lsvInstrument.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvInstrument_OnSubitemTextChanged);
            SetControlState();
            PopRegion();
            PopSiteCategory();
            PopulateSiteLevel();//b
            BindSite();


        }

        void _sPane_OnDataUsageEdit(object sender, EventArgs e)
        {
            _isedited = true;
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, _reloadCtr);
                DataRepository.CloseSession();

                ForlabRegion r = _site.Region;
                SiteCategory sc = _site.SiteCategory;

                
                _site = new ForlabSite();
                _site.Region = r;
                _site.SiteCategory = sc;


                LoadSiteCtr();
                _isedited = false;
                if (_site.SiteCategory != null)//b
                {
                    comCategory.SelectedValue = _site.SiteCategory.Id;
                }
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
                _isedited = false;
                DataRepository.CloseSession();
                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void SiteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isedited)
            {
               // System.Windows.Forms.DialogResult dr = MessageBox.Show("Do you want to save changes to site?", "Edit Site", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                try
                {
                    //if (dr == System.Windows.Forms.DialogResult.Yes)
                    //{
                        LQTUserMessage msg = SaveOrUpdateObject();
                        ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, _reloadCtr);
                    //}
                    //else if (dr == System.Windows.Forms.DialogResult.Cancel)
                    //    e.Cancel = true;
                }
                catch (Exception ex)
                {
                    new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                    e.Cancel = true;
                }
            }
            
        }

        private void SetControlState()
        {
            this.txtCd4Td.Enabled = _enableCtr;
            this.txtChemTd.Enabled = _enableCtr;
            this.txthemaTd.Enabled = _enableCtr;
            this.txtViralTd.Enabled = _enableCtr;
            this.txtOtherTd.Enabled = _enableCtr;

            this.txtName.Enabled = _enableCtr;
            this.comRegion.Enabled = _enableCtr;
            this.comCategory.Enabled = _enableCtr;
            if (!_enableCtr)
            {
                this.lbtOpen.Enabled = _enableCtr;
                this.lbtAddins.Enabled = _enableCtr;
                this.lbtRemove.Enabled = _enableCtr;

            }
            this.lsvInstrument.Enabled = _enableCtr;
            this.lsvStatus.Enabled = _enableCtr;
            this.comCD4RefSite.Enabled = _enableCtr;
            this.comChemistryRefSite.Enabled = _enableCtr;
            this.comHematologyRefSite.Enabled = _enableCtr;
            this.comOtheRefSite.Enabled = _enableCtr;
            this.comViralLoadRefSite.Enabled = _enableCtr;
            this.txtworkingdays.Enabled = _enableCtr;


            this.txtCd4Td.Text = "0";
            this.txtChemTd.Text = "0";
            this.txthemaTd.Text = "0";
            this.txtViralTd.Text = "0";
            this.txtOtherTd.Text = "0";

            this.txtName.Text = "";
            this.comsitelevel.Text = "";

        }

        private void PopRegion()
        {
            comRegion.DataSource = DataRepository.GetAllRegion();
        }

        private void PopSiteCategory()
        {
            comCategory.DataSource = DataRepository.GetListOfAllSiteCategory();
        }

        private void BindSite()
        {
            if (_site.Region != null)
            {
                comRegion.SelectedValue = _site.Region.Id;
                comRegion.Enabled = false;
            }

            if (_site.Id > 0)
            {
                this.txtCd4Td.Text = _site.CD4TestingDaysPerMonth.ToString();
                this.txtChemTd.Text = _site.ChemistryTestingDaysPerMonth.ToString();
                this.txthemaTd.Text = _site.HematologyTestingDaysPerMonth.ToString();
                this.txtViralTd.Text = _site.ViralLoadTestingDaysPerMonth.ToString();
                this.txtOtherTd.Text = _site.OtherTestingDaysPerMonth.ToString();
                this.comsitelevel.Text = _site.SiteLevel;
                //IList<ForlabSite> result = new List<ForlabSite>();
                //result = DataRepository.GetReferingSiteByPlatform(_site.Id,1);
                string type = "CD4";
                if (DataRepository.GetRefSiteBySiteId(_site.Id, type))
                {
                    this.comCD4RefSite.Enabled = false;
                    this.comCD4RefSite.SetValue(0);
                }
                else
                    this.comCD4RefSite.SetValue(_site.CD4RefSite);
                type = "Chemistry";
                if (DataRepository.GetRefSiteBySiteId(_site.Id, type))
                {
                    this.comChemistryRefSite.Enabled = false;
                    this.comChemistryRefSite.SetValue(0);
                }
                else
                    this.comChemistryRefSite.SetValue(_site.ChemistryRefSite);
                type = "Hematology";
                if (DataRepository.GetRefSiteBySiteId(_site.Id, type))
                {
                    this.comHematologyRefSite.Enabled = false;
                    this.comHematologyRefSite.SetValue(0);
                }
                else
                    this.comHematologyRefSite.SetValue(_site.HematologyRefSite);
                type = "Other";
                if (DataRepository.GetRefSiteBySiteId(_site.Id, type))
                {
                    this.comOtheRefSite.Enabled = false;
                    this.comOtheRefSite.SetValue(0);
                }
                else
                    this.comOtheRefSite.SetValue(_site.OtherRefSite);
                type = "ViralLoad";

                if (DataRepository.GetRefSiteBySiteId(_site.Id, type))
                {
                    this.comViralLoadRefSite.Enabled = false;
                    this.comViralLoadRefSite.SetValue(0);
                }
                else
                    this.comViralLoadRefSite.SetValue(_site.ViralLoadRefSite);

                this.txtworkingdays.Text = _site.WorkingDays.ToString();
                this.txtName.Text = _site.SiteName;
                if (_site.SiteCategory != null)
                {
                    comCategory.SelectedValue = _site.SiteCategory.Id;
                }
            }

            PopStatus();
            PopInstruments();


            if (_site.Id > 0 && _enableCtr)
            {
                lbtAddins.Enabled = true;

            }

        }

        public void RebindSite(ForlabSite site)
        {
            this._site = site;
            BindSite();
        }

        private void PopStatus()
        {
            lsvStatus.BeginUpdate();
            lsvStatus.Items.Clear();

            foreach (SiteStatus s in _site.SiteStatuses)
            {
                ListViewItem li = new ListViewItem(s.OpenedFrom.ToShortDateString()) { Tag = s.Id };
                string str = s.ClosedOn != null ? s.ClosedOn.Value.ToShortDateString() : "";
                li.SubItems.Add(str);
                lsvStatus.Items.Add(li);
            }

            lsvStatus.EndUpdate();

            if (_site.CurrentlyOpen)
                lbtOpen.Enabled = false;
            else if (_enableCtr)
                lbtOpen.Enabled = true;
        }

        private void PopInstruments()
        {
            lsvInstrument.BeginUpdate();
            lsvInstrument.Items.Clear();

            int index = 0;
            foreach (SiteInstrument s in _site.SiteInstruments)
            {
                LQTListViewTag tag = new LQTListViewTag();
                tag.Id = s.Id;
                tag.Index = index;

                ListViewItem li = new ListViewItem(s.Instrument.TestingArea.AreaName) { Tag = tag };
                li.SubItems.Add(s.Instrument.InstrumentName);
                li.SubItems.Add(s.Quantity.ToString());
                li.SubItems.Add(s.TestRunPercentage.ToString());
                lsvInstrument.Items.Add(li);
                index++;
            }
            if (_site.SiteInstruments.Count <= 0)
            {
                lbtRemove.Enabled = false;
            }
            lsvInstrument.EndUpdate();

        }

        private void txtCd4Td_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                _isedited = true;
            }
        }

        private void lbtRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lsvInstrument.SelectedItems.Count > 0)
            {
                foreach (ListViewItem l in lsvInstrument.SelectedItems)
                {
                    LQTListViewTag tag = (LQTListViewTag)lsvInstrument.SelectedItems[0].Tag;
                    SiteInstrument si;
                    if (tag.Id > 0)
                        si = _site.GetSiteInstrumentById(tag.Id);
                    else
                        si = (SiteInstrument)_site.SiteInstruments[tag.Index];

                    _site.SiteInstruments.Remove(si);
                    
                }
                PopInstruments();


                if (OnDataUsageEdit != null)
                {
                    OnDataUsageEdit(this, new EventArgs());
                }
            }

        }

        private void lsvInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvInstrument.SelectedItems.Count > 0)
            {
                lbtRemove.Enabled = true;

            }
            else
            {
                lbtRemove.Enabled = false;
            }
        }

        public bool HasInstrument(TestingArea ta)
        {
            foreach (SiteInstrument SiteIns in _site.SiteInstruments)
            {
                if (SiteIns.Instrument.TestingArea == ta)
                    return true;
            }
            return false;
        }

        public int ServiceAddedByDefault()
        {
            return _serviceAddedbyDefault;
        }

        private void lbtOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmInput frm = new FrmInput(DateTime.Now, "Opening Date");
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                SiteStatus ss = new SiteStatus();
                ss.OpenedFrom = frm.GetDateTimeValue();
                _site.SiteStatuses.Add(ss);
                //DataRepository.SaveOrUpdateSite(_site);
                PopStatus();

                if (OnDataUsageEdit != null)
                {
                    OnDataUsageEdit(this, new EventArgs());
                }
            }
        }

        private void lbtEditstatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmInput frm = new FrmInput(DateTime.Now, "Opening Date");
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                if (lsvStatus.SelectedItems.Count > 0)
                {

                    int id = (int)lsvStatus.SelectedItems[0].Tag;
                    SiteStatus ss;
                    if (id > 0)
                        ss = _site.GetSiteStatusById(id);
                    else
                        ss = (SiteStatus)_site.SiteStatuses[lsvStatus.SelectedItems[0].Index];
                   // DateTime closeDate = _site.GetLastClosedDate.Value;//b
                   // string closeDate = _site.GetLastClosedDate != null ? _site.GetLastClosedDate.Value.ToShortDateString() : "";
                    int Count = _site.SiteStatuses.Count;
                    string closeDate;
                    closeDate = _site.SiteStatuses[Count - 1].ClosedOn != null ? _site.SiteStatuses[Count - 1].ClosedOn.ToString() : "";

                    if (closeDate != "")//b
                    {
                        if (DateTime.Parse(closeDate) < frm.GetDateTimeValue())//b
                        {
                            ss.OpenedFrom = frm.GetDateTimeValue();

                            //DataRepository.SaveOrUpdateSite(_site);
                            PopStatus();
                        }
                        else
                        {
                            MessageBox.Show("Opening Date can not be after Closing Date.");
                        }
                    }
                    else
                    {
                    ss.OpenedFrom = frm.GetDateTimeValue();
                    //DataRepository.SaveOrUpdateSite(_site);
                    PopStatus();
                     }
                    if (OnDataUsageEdit != null)
                    {
                        OnDataUsageEdit(this, new EventArgs());
                    }
                }
            }
        }

        private void lbtClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmInput frm = new FrmInput(DateTime.Now, "Closing Date");
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (lsvStatus.SelectedItems.Count > 0)
                {
                    int id = (int)lsvStatus.SelectedItems[0].Tag;

                    SiteStatus ss;
                    if (id > 0)
                        ss = _site.GetSiteStatusById(id);
                    else
                        ss = (SiteStatus)_site.SiteStatuses[lsvStatus.SelectedItems[0].Index];
                    DateTime openDate = _site.GetLastOpenDate;//b
                    if (openDate <= frm.GetDateTimeValue())//b
                    {
                        ss.ClosedOn = frm.GetDateTimeValue();
                        PopStatus();
                    }
                    else
                    {
                        MessageBox.Show("Closing Date can not be before Opening Date.");
                    }

                    //DataRepository.SaveOrUpdateSite(_site);
                  

                    if (OnDataUsageEdit != null)
                    {
                        OnDataUsageEdit(this, new EventArgs());
                    }
                }
            }
        }

        private void lsvStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvStatus.SelectedItems.Count > 0)
            {
                lbtEditstatus.Enabled = true;
                lbtClose.Enabled = true;
            }
            else
            {
                lbtEditstatus.Enabled = false;
                lbtClose.Enabled = false;
            }
        }

        private void lbtAddins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSelectInstrument frm = new FrmSelectInstrument(_site.SiteInstruments);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                List<TestingArea> TaInSelectedIns = new List<TestingArea>();

                foreach (Instrument i in frm.SelectedInstruments)
                {

                    SiteInstrument si = new SiteInstrument();
                    si.Instrument = i;
                    si.Quantity = 1;
                    si.TestRunPercentage = 100;
                    _site.SiteInstruments.Add(si);
                    TaInSelectedIns.Add(i.TestingArea);

                }

                //AddTestingAreaInDemography(TaInSelectedIns);


                PopInstruments();

                if (OnDataUsageEdit != null)
                {
                    OnDataUsageEdit(this, new EventArgs());
                }
            }
        }

        void lsvInstrument_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;// (ListViewItem)sender;
            LQTListViewTag tag = (LQTListViewTag)li.Tag;
            SiteInstrument si;
            _isedited = true;
            if (tag.Id <= 0)
                si = (SiteInstrument)_site.SiteInstruments[tag.Index];
            else
                si = _site.GetSiteInstrumentById(tag.Id);

            try
            {
                if (li.SubItems[3].Text == "0")
                {
                    li.SubItems[3].Text = "100";
                }
                //if (TestInstrumentPercentage()=="")
                //{
                    int qty = int.Parse(li.SubItems[2].Text);
                    if (qty >= 0)
                        si.Quantity = qty;
                    else
                        li.SubItems[2].Text = si.Quantity.ToString();

                    decimal testRun = decimal.Parse(li.SubItems[3].Text);
                    if (testRun >= 0)
                    {

                        si.TestRunPercentage = testRun;

                    }
                    else
                        li.SubItems[3].Text = si.TestRunPercentage.ToString();
                //}
                //else
                //{
                //    MessageBox.Show("The sum of % Tests Run for the "+TestInstrumentPercentage()+" must add up to 100%");
                //    decimal testRun = decimal.Parse(li.SubItems[3].Text);
                //    if (testRun >= 0)
                //    {

                //        si.TestRunPercentage = testRun;

                //    }
                //    else
                //        li.SubItems[3].Text = si.TestRunPercentage.ToString();
                //    //li.SubItems[2].Text = si.Quantity.ToString();
                //    //li.SubItems[3].Text = si.TestRunPercentage.ToString();
                //}
            }
            catch
            {
                li.SubItems[3].Text = si.TestRunPercentage.ToString();
                li.SubItems[2].Text = si.Quantity.ToString();
            }

            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this, new EventArgs());
            }
            
        }

        public LQTUserMessage SaveOrUpdateObject()
        {
            bool refSite = true;
            bool testDays = true;
            ForlabRegion region = LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion);
            this.Focus();
            if (txtName.Text.Trim() == string.Empty)
                throw new LQTUserException("Site Name must not be empty.");
            if (LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion) == null)
                throw new LQTUserException("A Region must be selected.");
            if (DataRepository.GetSiteByName(txtName.Text.Trim(), LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion).Id) != null &&
                _site.Id <= 0)
                throw new LQTUserException("The Site Name already exists in the region.");
            if (txtworkingdays.Text.Trim() == string.Empty)
                throw new LQTUserException("General Working Days Can not be empty.");
            if (int.Parse(txtworkingdays.Text)>31)
                throw new LQTUserException("General Working Days Can not be greater than 31.");

            if (comsitelevel.Text.Trim() == string.Empty)
                throw new LQTUserException("Site Level Can not be empty.");

            if (comCategory.Text.Trim() == string.Empty)
                throw new LQTUserException("Site Category can not be empty. Please add site category first.");

            string test="";
            string wDays = "";
            bool workDays = false;
            _site.SiteName = txtName.Text.Trim();
            if (txtCd4Td.Text == "")
                txtCd4Td.Text = "0";

            if (int.Parse(txtCd4Td.Text) > int.Parse(txtworkingdays.Text))
            {
                testDays = false;
                test = test + "CD4, ";
            }
            else
                _site.CD4TestingDaysPerMonth = int.Parse(txtCd4Td.Text);
            if (txtChemTd.Text == "")
                txtChemTd.Text = "0";
            if (int.Parse(txtChemTd.Text) > int.Parse(txtworkingdays.Text))
            {
                testDays = false;
                test = test + "Chemistry, ";
            }
            else
                _site.ChemistryTestingDaysPerMonth = int.Parse(txtChemTd.Text);

            if (txthemaTd.Text == "")
                txthemaTd.Text = "0";
            if (int.Parse(txthemaTd.Text) > int.Parse(txtworkingdays.Text))
            {
                testDays = false;
                test = test + "Hematology, ";
            }
            else
            _site.HematologyTestingDaysPerMonth = int.Parse(txthemaTd.Text);
            if (txtViralTd.Text == "")
                txtViralTd.Text = "0";
            if (int.Parse(txtViralTd.Text) > int.Parse(txtworkingdays.Text))
            {
                testDays = false;
                test = test + "Viral Load, ";
            }
            else
            _site.ViralLoadTestingDaysPerMonth = int.Parse(txtViralTd.Text);
            if (txtOtherTd.Text == "")
                txtOtherTd.Text = "0";
            if (int.Parse(txtOtherTd.Text) > int.Parse(txtworkingdays.Text))
            {
                testDays = false;
                test = test + "Other: ";
            }
            else
            _site.OtherTestingDaysPerMonth = int.Parse(txtOtherTd.Text);
            _site.SiteLevel = comsitelevel.Text;


            //if (int.Parse(comCD4RefSite.Tag.ToString()) > 0 && int.Parse(txtCd4Td.Text) <= 0)//jul 5
            //{
            //    wDays = wDays + "CD4, ";
            //    workDays = true;
            //}
            //if (int.Parse(comChemistryRefSite.Tag.ToString()) > 0 && int.Parse(txtChemTd.Text) <= 0)
            //{
            //    wDays = wDays + "Chemistry, ";
            //    workDays = true;
            //}
            //if (int.Parse(comHematologyRefSite.Tag.ToString()) > 0 && int.Parse(txthemaTd.Text) <= 0)
            //{
            //    wDays = wDays + "Hematology, ";
            //    workDays = true;
            //}
            //if (int.Parse(comViralLoadRefSite.Tag.ToString()) > 0 && int.Parse(txtViralTd.Text) <= 0)
            //{
            //    wDays = wDays + "Viral Load, ";
            //    workDays = true;
            //}
            //if (int.Parse(comOtheRefSite.Tag.ToString()) > 0 && int.Parse(txtOtherTd.Text) <= 0)
            //{
            //    wDays = wDays + "Other: ";
            //    workDays = true;
            //}
            _site.CD4RefSite = int.Parse(comCD4RefSite.Tag.ToString());
            _site.ChemistryRefSite = int.Parse(comChemistryRefSite.Tag.ToString());
            _site.HematologyRefSite = int.Parse(comHematologyRefSite.Tag.ToString());
            _site.ViralLoadRefSite = int.Parse(comViralLoadRefSite.Tag.ToString());
            _site.OtherRefSite = int.Parse(comOtheRefSite.Tag.ToString());

            _site.WorkingDays = int.Parse(txtworkingdays.Text);
            //if (workDays)
            //{
            //    throw new LQTUserException(wDays + " Testing days has to be greater than 0.");
            //}
            if (testDays == false)
            {
                throw new LQTUserException(test+ " Testing Days Can't be Greater Than Working Days.");
            }
            if (refSite == false)
            {
                throw new LQTUserException("A Site Can't be Referral Site for Itself.");
            }
            if (_site.Region == null)
                _site.Region = LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion);
            _site.SiteCategory = LqtUtil.GetComboBoxValue<SiteCategory>(comCategory);

            string siteCategory = _site.SiteCategory.CategoryName;//b
            SiteCategory sCatagory;//b
            if (!string.IsNullOrEmpty(siteCategory))//b
            {
                sCatagory = DataRepository.GetSiteCategoryByName(siteCategory);
                if (siteCategory == null)
                {
                    sCatagory = new SiteCategory();
                    sCatagory.CategoryName = siteCategory;
                    DataRepository.SaveOrUpdateSiteCategory(sCatagory);
                }
            }
            if (lsvInstrument.Items.Count > 0)//b
            {
                if (TestDaysCount()!="")
                {
                    throw new LQTUserException(TestDaysCount()+ " Testing days has to be greater than 0");
                }
                //if (WorkingDaysCount() != "")//dec19
                //{
                //    throw new LQTUserException(WorkingDaysCount() + " Testing days has to be 0");
                //}
                if (TestInstrumentPercentage()=="")//b
                {
                    AddDefaultStatus();
                    DataRepository.SaveOrUpdateSite(_site);
                    return new LQTUserMessage("Site was saved or updated successfully.");
                }
                else//b
                    //  return new LQTUserMessage("Site can not be  saved or updated");
                    throw new LQTUserException("The sum of % Tests Run for the " + TestInstrumentPercentage() + " must add up to 100%");
               
            }
            else
            {
                string workingtestDays = "";
                if (int.Parse(txtCd4Td.Text) > 0 )//&& comCD4RefSite.Tag.ToString() == "0")//add jul 5 
                    workingtestDays = workingtestDays + "CD4, ";
                if (int.Parse(txtChemTd.Text) > 0)// && comChemistryRefSite.Tag.ToString() == "0")
                    workingtestDays = workingtestDays + "Chemistry, ";
                if (int.Parse(txthemaTd.Text) > 0)// && comHematologyRefSite.Tag.ToString() == "0")
                    workingtestDays = workingtestDays + "Hematology, ";
                if (int.Parse(txtViralTd.Text) > 0)// && comViralLoadRefSite.Tag.ToString() == "0")
                    workingtestDays = workingtestDays + "Viral Load, ";
                if (int.Parse(txtOtherTd.Text) > 0)// && comOtheRefSite.Tag.ToString() == "0")
                    workingtestDays = workingtestDays + "Other ";
                //if(workingtestDays!="")//dec 19
                //throw new LQTUserException(workingtestDays + " Testing days has to be 0");
                AddDefaultStatus();
                DataRepository.SaveOrUpdateSite(_site);

                return new LQTUserMessage("Site was saved or updated successfully.");
            }

        }

        public void AddDefaultStatus()
        {
            if (_site.SiteStatuses.Count == 0)
            {
                SiteStatus Defaultstatus = new SiteStatus();
                Defaultstatus.OpenedFrom = DateTime.Now;
                Defaultstatus.Site = _site;
                _site.SiteStatuses.Add(Defaultstatus);
            }
        }

        private string TestDaysCount()
        {

            List<String> category = TestCategory();
            string testDays="";
            for (int i = 0; i < category.Count; i++)
            {
                if ((category[i].Contains("CD4") || category[i].Contains("Flow Cytometry")) && int.Parse(txtCd4Td.Text) <= 0)
                    testDays=testDays+ "CD4,  ";
                if (category[i].Contains("Chemistry") && int.Parse(txtChemTd.Text) <= 0)
                   testDays=testDays+ "Chemistry,  ";
                if (category[i].Contains("Hematology") && int.Parse(txthemaTd.Text) <= 0)
                   testDays=testDays+"Hematology,  ";
                if (category[i].Contains("Viral Load") && int.Parse(txtViralTd.Text) <= 0)
                   testDays=testDays+"Viral Load,  ";
                if (category[i].Contains("Other") && int.Parse(txtOtherTd.Text) <= 0)
                    testDays=testDays+ "Other:  ";

            }
            return testDays;
        }

        private string WorkingDaysCount()
        {          
          
            List<String> category = TestCategory();
            string testDays = "";            
            string [] s=new string [5];

            for (int i = 0; i < category.Count; i++)
            {
                if ((category[i].Contains("CD4") || category[i].Contains("Flow Cytometry")) && int.Parse(txtCd4Td.Text) > 0)
                    s[0] = "CD4";
                if ((category[i].Contains("Chemistry") && int.Parse(txtChemTd.Text) > 0))
                    s[1]= "Chemistry";
                if ((category[i].Contains("Hematology") && int.Parse(txthemaTd.Text) > 0))
                    s[2]= "Hematology";
                if ((category[i].Contains("Viral Load") && int.Parse(txtViralTd.Text) > 0))
                    s[3]="Viral Load";
                if ((category[i].Contains("Other") && int.Parse(txtOtherTd.Text) > 0))
                    s[4]="Other";

            }
        
            if (s[0] != "CD4" && comCD4RefSite.Tag.ToString() == "0" && int.Parse(txtCd4Td.Text) > 0)
                testDays = testDays + "CD4, ";
            if (s[1] != "Chemistry" && comChemistryRefSite.Tag.ToString() == "0" && int.Parse(txtChemTd.Text) >0)
                testDays = testDays + "Chemistry, ";
            if (s[2] != "Hematology" && comHematologyRefSite.Tag.ToString() == "0" && int.Parse(txthemaTd.Text) >0)
                testDays = testDays + "Hematology, ";
            if (s[3] != "Viral Load" && comViralLoadRefSite.Tag.ToString() == "0" && int.Parse(txtViralTd.Text) > 0)
                testDays = testDays + "Viral Load, ";
            if (s[4] != "Other" && comOtheRefSite.Tag.ToString() == "0" && int.Parse(txtOtherTd.Text) > 0)
                testDays = testDays + "Other ";
           
            return testDays;
        }
             
        private List<string> TestCategory()
        {

            List<string> list = new List<string>();
            
            foreach (ListViewItem item in lsvInstrument.Items)
            {
                if(list.Contains(item.SubItems[0].Text)!=true)
                {
                    list.Add(item.SubItems[0].Text);
                }
            }
            return list;

            
        }

        private string TestInstrumentPercentage()
        {

            int count = lsvInstrument.Items.Count;
            List<String> category = TestCategory();
            double[] sum = new double[category.Count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j <= category.Count - 1; j++)
                {
                    if (lsvInstrument.Items[i].SubItems[0].Text.ToString() == category[j])
                    {
                        sum[j] = sum[j] + double.Parse(lsvInstrument.Items[i].SubItems[3].Text);

                    }
                    if (sum[j] > 100)
                    {

                        return category[j];
                    }
                }

            }
            for (int k = 0; k <= category.Count - 1; k++)
            {
                if (sum[k] < 100 && sum[k] != 0)
                {

                    return category[k];
                }
            }
            return "";



        }

        private void PopulateSiteLevel()
        {          
            string[] sitelevel = Enum.GetNames(typeof(SiteLevelEnum));
           // List<string> list = new List<string>(); 
            for (int i = 0; i < sitelevel.Length; i++)
            {
                comsitelevel.Items.Add(sitelevel[i].Replace('_', ' '));               
            }
           // comsitelevel.DataSource = list;
        }

       

    }
}
