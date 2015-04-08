using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Location;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class SitePane : BaseUserControl
    {
        public event EventHandler OnDataUsageEdit;
      
        private bool _enableCtr;
        private ForlabSite _site;
        public static int _serviceAddedbyDefault = 0;
        
        public SitePane(ForlabSite site)
            : this(site, false) {}

        public SitePane(ForlabSite site, bool enableCtr)
        {
            this._site = site;
            this._enableCtr = enableCtr;
            InitializeComponent();

            lsvInstrument.AddNoneEditableColumn(0);
            lsvInstrument.AddNoneEditableColumn(1);
           
            //lsvInstrument.OnSubitemTextChanged += new EventHandler(lsvInstrument_OnSubitemTextChanged);
            lsvInstrument.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvInstrument_OnSubitemTextChanged);
            SetControlState();
            PopRegion();
            PopSiteCategory();
            BindSite();            
        }

        void lsvInstrument_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;// (ListViewItem)sender;
            LQTListViewTag tag = (LQTListViewTag)li.Tag;
            SiteInstrument si;

            if (tag.Id <= 0)
                si = (SiteInstrument)_site.SiteInstruments[tag.Index];
            else
                si = _site.GetSiteInstrumentById(tag.Id);

            try
            {
                int qty = int.Parse(li.SubItems[2].Text);
                if (qty >= 0)
                    si.Quantity = qty;
                else
                    li.SubItems[2].Text = si.Quantity.ToString();

                decimal testRun = decimal.Parse(li.SubItems[3].Text);
                if (testRun >= 0)
                    si.TestRunPercentage = testRun;
                else
                    li.SubItems[3].Text = si.TestRunPercentage.ToString();
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

            lsvInstrument.EndUpdate();

        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
            ForlabRegion region = LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion);

            if (txtName.Text.Trim() == string.Empty)
               throw new LQTUserException("Site Name must not be empty.");
            if (LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion) == null)
                throw new LQTUserException("A Region must be selected.");
            if (DataRepository.GetSiteByName(txtName.Text.Trim(), LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion).Id) != null &&
                _site.Id <= 0)
                throw new LQTUserException("The Site Name already exists in the region.");
            if (txtworkingdays.Text.Trim() == string.Empty)
                throw new LQTUserException("General Working Days Can not be empty.");
            
            _site.SiteName = txtName.Text;
            _site.CD4TestingDaysPerMonth = int.Parse(txtCd4Td.Text);
            _site.ChemistryTestingDaysPerMonth = int.Parse(txtChemTd.Text);
            _site.HematologyTestingDaysPerMonth = int.Parse(txthemaTd.Text);
            _site.ViralLoadTestingDaysPerMonth = int.Parse(txtViralTd.Text);
            _site.OtherTestingDaysPerMonth = int.Parse(txtOtherTd.Text);

            
            _site.CD4RefSite = int.Parse(comCD4RefSite.Tag.ToString());
            _site.ChemistryRefSite = int.Parse(comChemistryRefSite.Tag.ToString());
            _site.HematologyRefSite = int.Parse(comHematologyRefSite.Tag.ToString());
            _site.ViralLoadRefSite = int.Parse(comViralLoadRefSite.Tag.ToString());
            _site.OtherRefSite = int.Parse(comOtheRefSite.Tag.ToString());

            _site.WorkingDays = int.Parse(txtworkingdays.Text);

            if (_site.Region == null)
                _site.Region = LqtUtil.GetComboBoxValue<ForlabRegion>(comRegion);
            _site.SiteCategory = LqtUtil.GetComboBoxValue<SiteCategory>(comCategory);

            AddDefaultStatus();
            DataRepository.SaveOrUpdateSite(_site);

            return new LQTUserMessage("Site was saved or updated successfully.");
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

        public void RebindSite(ForlabSite site)
        {
            this._site = site;
            BindSite();
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

                this.comCD4RefSite.SetValue(_site.CD4RefSite);
                this.comChemistryRefSite.SetValue(_site.ChemistryRefSite);
                this.comHematologyRefSite.SetValue(_site.HematologyRefSite);
                this.comOtheRefSite.SetValue(_site.OtherRefSite);
                this.comViralLoadRefSite.SetValue(_site.OtherRefSite);
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
                int id = (int)lsvStatus.SelectedItems[0].Tag;
                SiteStatus ss;
                if (id > 0)
                    ss = _site.GetSiteStatusById(id);
                else
                    ss = (SiteStatus)_site.SiteStatuses[lsvStatus.SelectedItems[0].Index];

                ss.OpenedFrom = frm.GetDateTimeValue();

                //DataRepository.SaveOrUpdateSite(_site);
                PopStatus();

                if (OnDataUsageEdit != null)
                {
                    OnDataUsageEdit(this, new EventArgs());
                }
            }
        }

        private void lbtClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmInput frm = new FrmInput(DateTime.Now, "Closing Date");
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                int id = (int)lsvStatus.SelectedItems[0].Tag;
                SiteStatus ss;
                if (id > 0)
                    ss = _site.GetSiteStatusById(id);
                else
                    ss = (SiteStatus)_site.SiteStatuses[lsvStatus.SelectedItems[0].Index];
                ss.ClosedOn = frm.GetDateTimeValue();

                //DataRepository.SaveOrUpdateSite(_site);
                PopStatus();

                if (OnDataUsageEdit != null)
                {
                    OnDataUsageEdit(this, new EventArgs());
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
                List<TestingArea> TaInSelectedIns=new List<TestingArea>();
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
              
                if(OnDataUsageEdit !=null)
                {
                    OnDataUsageEdit(this, new EventArgs());
                }
            }
        }

        //private void lbtEditins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    int id = (int)lsvInstrument.SelectedItems[0].Tag;
        //    SiteInstrument si = _site.GetSiteInstrumentById(id);

        //    FrmInput frm = new FrmInput(si.Quantity.ToString(), "Quantity");
        //    frm.ShowDialog();
        //    if (frm.DialogResult == DialogResult.OK)
        //    {
        //        si.Quantity = int.Parse(frm.GetTextValue());
        //        DataRepository.SaveOrUpdateSite(_site);
        //        PopInstruments();
        //    }
        //}

        private void lbtRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)lsvInstrument.SelectedItems[0].Tag;
            SiteInstrument si;
            if (tag.Id > 0)
                si = _site.GetSiteInstrumentById(tag.Id);
            else
                si = (SiteInstrument)_site.SiteInstruments[tag.Index];

            _site.SiteInstruments.Remove(si);
            //DataRepository.SaveOrUpdateSite(_site);
            PopInstruments();
        
            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this, new EventArgs());
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
                  if(SiteIns.Instrument.TestingArea==ta)
                    return true;
            }
            return false;
        }

        public int ServiceAddedByDefault()
        {
            return _serviceAddedbyDefault;
        }

        //public int AddTestingAreaInDemography(IList<TestingArea> ta)
        //{

        //    foreach (TestingArea t in ta)
        //    {
        //        if (!ContainsTestingArea(t))
        //        {
        //            SiteService siteS=new SiteService();
        //            siteS.RefSite=null;
        //            siteS.Site=_site;
        //            siteS.TestingArea=t;
        //            siteS.TestingDayPerMonth=26;
        //            _site.SiteServices.Add(siteS);
        //            _serviceAddedbyDefault++;
        //        }
        //    }
        //    return _serviceAddedbyDefault;

        //}

        //public bool ContainsTestingArea(TestingArea ta)
        //{
        //    foreach (SiteService siteS in _site.SiteServices)
        //    {
        //        if (siteS.TestingArea == ta)
        //            return true;
        //    }
        //    return false;
        //}

        private void lsvSiteService_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

     

        private void txtCd4Td_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

    }
}