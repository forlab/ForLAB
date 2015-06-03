
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

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI.UserCtr
{
    public partial class SDataUsage : BaseHistoricalData
    {


        public SDataUsage(ForecastInfo finfo)
        {

            this._forecastInfo = finfo;
            InitializeComponent();
            base._lvHistData = lvTest;
            base._chartSd = chart1;
            InitGridView();
            BindSites();
            BindForecastSite();
            ShowSummary();
        }


      
        private void BindSites()
        {
            lvSiteAll.BeginUpdate();
            lvSiteAll.Items.Clear();

                foreach (ForlabSite s in DataRepository.GetAllSite())
                {
                    if (!_forecastInfo.SiteIsSelected(s.Id))
                    {
                        ListViewItem li = new ListViewItem(s.SiteName) { Tag = s.Id };
                        lvSiteAll.Items.Add(li);
                    }
                }

            lvSiteAll.EndUpdate();
    
        }

        private void BindForecastSite()
        {
            lvSite.BeginUpdate();
            lvSite.Items.Clear();

            foreach (ForecastSite s in _forecastInfo.ForecastSites)
            {
                ListViewItem li = new ListViewItem(s.Site.SiteName) { Tag = s.Id };
                lvSite.Items.Add(li);
            }

            lvSite.EndUpdate();
        }

        private void BindForecastSiteTest()
        {
            lbtRemovesite.Enabled = false;
            lbtAddduration.Enabled = false;

            if (_activeFSite != null)
            {
                if (lvSite.SelectedItems.Count > 0)
                    base.BindForecastDataUsage(_activeFSite.Id, lvSite.SelectedItems[0].Index);
            }
            else
            {
                lbtAddtest.Enabled = false;
            }
            ShowSummary();//b
        }



        private void lvSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSite.SelectedItems.Count <= 0)
            {
                lbtRemovesite.Enabled = false;
                lbtImport.Enabled = false;
                lbtAddduration.Enabled = false;
                lbtAddtest.Enabled = false;
                _activeFSite = null;
                BindForecastSiteTest();
                txtSitename.Text = "";
                txtPcount.Text = "";
            }
            else
            {
                int id = (int)lvSite.SelectedItems[0].Tag;

                if (id > 0)
                    _activeFSite = _forecastInfo.GetForecastSite(id);
                else
                    _activeFSite = _forecastInfo.ForecastSites[lvSite.SelectedItems[0].Index];

                BindForecastSiteTest();

                lbtRemovesite.Enabled = true;
                lbtAddtest.Enabled = true;
                lbtImport.Enabled = true;
                lbtAddtest.Enabled = true;
                CurrentSiteSummary();

                ShowSummary();
            }
        }

        private void lbtAddsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int len = lvSiteAll.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                int siteid = (int)lvSiteAll.SelectedItems[i].Tag;
                ForecastSite fs = new ForecastSite();
                fs.Site = DataRepository.GetSiteById(siteid);
                fs.ForecastInfo = _forecastInfo;

                _forecastInfo.ForecastSites.Add(fs);
            }

            BindSites();
            BindForecastSite();
            ShowSummary();

        }
        private void lbtAddsiteall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < lvSiteAll.Items.Count; i++)
            {
                lvSiteAll.Items[i].Selected = true;
                lvSiteAll.Select();
            }
            int len = lvSiteAll.SelectedItems.Count;

            for (int i = 0; i < len; i++)
            {
                int siteid = (int)lvSiteAll.SelectedItems[i].Tag;
                ForecastSite fs = new ForecastSite();
                fs.Site = DataRepository.GetSiteById(siteid);
                fs.ForecastInfo = _forecastInfo;

                _forecastInfo.ForecastSites.Add(fs);
            }

            BindSites();
            BindForecastSite();
            ShowSummary();
            lbtAddsiteall.Enabled = false; 
            lbtAddsite.Enabled = false;

        }

        private void lbtRemovesite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int id = (int)lvSite.SelectedItems[0].Tag;

            ForecastSite fs = _forecastInfo.GetForecastSite(id);

            if (id > 0)
                fs = _forecastInfo.GetForecastSite(id);
            else
                fs = _forecastInfo.ForecastSites[lvSite.SelectedItems[0].Index];

            _forecastInfo.ForecastSites.Remove(fs);
            DataRepository.DeleteForecastSite(fs);//b  
            _activeFSite = null;

            BindSites();
            BindForecastSite();
            BindForecastSiteTest();
            txtSitename.Text = "";//b
            txtPcount.Text = "";//b
            ShowSummary();
           
        }

        private void lvTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTest.SelectedItems.Count <= 0)
            {
                lbtRemovetest.Enabled = false;
                lbtAddduration.Enabled = false;
            }
            else
            {
                lbtRemovetest.Enabled = true;
                lbtAddduration.Enabled = true;
            }
        }
         
        private void lvSiteAll_Leave(object sender, EventArgs e)
        {
            lbtAddsite.Enabled = false;
        }

        private void lvSiteAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSiteAll.SelectedItems.Count <= 0)
                lbtAddsite.Enabled = false;
            else
                lbtAddsite.Enabled = true;
        }

        private void lbtAddtest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddProdutOrTestDatausage())//AddDatausage())
                BindForecastSiteTest();

            CurrentSiteSummary();
            ShowSummary();
        }

        private void lbtRemovetest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RemoveDataUsageFromSite())
                BindForecastSiteTest();

            CurrentSiteSummary();
            ShowSummary();
        }

        private void lbtAddduration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddDurationDatausage())//AddDurationDatausage1())
                BindForecastSiteTest();
        }

        private void lbtImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ImportServiceStatistic())
            {

                BindSites();
                BindForecastSite();
                ShowSummary();

            }
        }

        private void ShowSummary()
        {
            txttotalsite.Text = _forecastInfo.ForecastSites.Count.ToString();
            txtTotalpcount.Text = DataRepository.FSTotalTestCount(_forecastInfo.Id).ToString();
        }

        private void CurrentSiteSummary()
        {
            txtSitename.Text = _activeFSite.Site.SiteName;
            txtPcount.Text = _activeFSite.GetUniqTest().Count.ToString();
        }

        private void lbtAddmultisite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectSiteAndTest())
            {
                BindSites();
                BindForecastSite();
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

        private void lvTest_Leave(object sender, EventArgs e)
        {
            if (this._chartSd.Series.Count > 0)
            {
                this._chartSd.Series[0].Points.Clear();
                this._chartSd.Titles[0].Text = "";
                this.lblMean.Text = "";
                this.lblDeviation.Text = "";
                this.lblMedian.Text = "";
            }
        }
       

    }
}
