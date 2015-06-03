
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
    public partial class SReported : BaseHistoricalData
    {
   

        public SReported(ForecastInfo finfo)
        {
            this._forecastInfo = finfo;
            InitializeComponent();

            base._lvHistData = lvTest;
            base._chartSd = chart1;
            InitGridView();
            BindSites();
            ShowSummary();
        }
        private void BindSites()
        {
            lvSite.BeginUpdate();
            lvSite.Items.Clear();

            foreach (ForecastSite s in _forecastInfo.GetReportedForecastSite())
            {
                ListViewItem li = new ListViewItem(s.Site.SiteName) { Tag = s.Id };
                lvSite.Items.Add(li);

                foreach (ForecastSite nrfs in _forecastInfo.GetNoneReportedForecastSite(s.Id))
                {
                    li = new ListViewItem("....." + nrfs.Site.SiteName) { Tag = s.Id };
                    lvSite.Items.Add(li);
                }
            }
            ShowSummary();//b
            lvSite.EndUpdate();
        }

        private void BindNoneReportedSite()
        {
            lvNrSite.BeginUpdate();
            lvNrSite.Items.Clear();

            if (_activeFSite != null)
            {
                foreach (ForecastNRSite s in _activeFSite.NoneReportedSites)
                {
                    ListViewItem li = new ListViewItem(s.NReportedSite.SiteName) { Tag = s.Id };
                    li.SubItems.Add(s.NReportedSite.Region.RegionName);
                    lvNrSite.Items.Add(li);
                }
                if (_activeFSite.Id > 0)
                    lbtAddnrsite.Enabled = true;
            }
            else
                lbtAddnrsite.Enabled = false;
            lvNrSite.EndUpdate();
        }

        private void lvSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSite.SelectedItems.Count > 0)
            {
                int id = (int)lvSite.SelectedItems[0].Tag;
                if (id > 0)
                    _activeFSite = _forecastInfo.GetForecastSite(id);
                else
                    _activeFSite = _forecastInfo.ForecastSites[lvSite.SelectedItems[0].Index];
                lbtRemovesite.Enabled = true;

                txtSitename.Text = _activeFSite.Site.SiteName;
                txtPcount.Text = _activeFSite.GetUniqTest().Count.ToString();
            }
            else
            {
                _activeFSite = null;
                lbtRemovesite.Enabled = false;
                txtSitename.Text = "";
                txtPcount.Text = "";
            }

            BindNoneReportedSite();
            BindForecastTest();
        }

        private void BindForecastTest()
        {
            lbtRemovetest.Enabled = false;

            if (_activeFSite != null)
            {
                if (lvSite.SelectedItems.Count > 0)
                    BindForecastDataUsage(_activeFSite.Id, lvSite.SelectedItems[0].Index);
                lbtAddtest.Enabled = true;
            }
            else
                lbtAddtest.Enabled = false;
            ShowSummary();//b
        }

        private void lbtAddsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddSiteToForecast())
                BindSites();
        }

        private void lbtRemovesite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool haschild = false;

            if (lvSite.SelectedItems.Count > 0)//if selected
            {
                int id = (int)lvSite.SelectedItems[0].Tag;
                if (!lvSite.SelectedItems[0].Text.Contains("..."))//if not non reported
                {
                    ForecastSite fs;

                    if (id > 0)
                        fs = _forecastInfo.GetForecastSite(id);
                    else
                        fs = _forecastInfo.ForecastSites[lvSite.SelectedItems[0].Index];

                    
                    if (fs.NoneReportedSites.Count > 0)
                    {
                        //int count = fs.NoneReportedSites.Count;
                        //ForecastSite site = new ForecastSite();
                        //for (int i = count - 1; i >= count - 1 && count > 0; i--)
                        //{
                        //    site = _forecastInfo.GetForecastSiteBySiteId(fs.NoneReportedSites[count - 1].NReportedSite.Id);
                        //    _activeFSite.NoneReportedSites.Remove(fs.NoneReportedSites[count - 1]);
                        //    DataRepository.CloseSession();
                        //    DataRepository.DeleteForecastSite(site);//b                            
                        //    count--;
                        haschild = true;

                        //}
                        MessageBox.Show("You have first to Remove Non Reported Site .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    if (!haschild)
                    {

                        _forecastInfo.ForecastSites.Remove(fs);
                        DataRepository.DeleteForecastSite(fs);//b                  

                        _activeFSite = null;
                        BindSites();
                        BindNoneReportedSite();
                        BindForecastTest();
                        OnForecastInfoDataChanged();
                        txtSitename.Text = "";//b
                        txtPcount.Text = "";//b
                    }
                }
            }
        }

        private void lvNrSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNrSite.SelectedItems.Count <= 0)
                lbtRemoveNrsite.Enabled = false;
            else
            {
                if (!lbtRemoveNrsite.Enabled)
                    lbtRemoveNrsite.Enabled = true;
            }
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

        private void lbtAddtest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddProdutOrTestDatausage())
                BindForecastTest();
            txtSitename.Text = _activeFSite.Site.SiteName;//b
            txtPcount.Text = _activeFSite.GetUniqFSProduct().Count.ToString();//b
    
        }

        private void lbtRemovetest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RemoveDataUsageFromSite())
                BindForecastTest();
        }

        private void lbtAddnrsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddNoneReportedSite())
            {
                BindNoneReportedSite();
                BindSites();
            }
        }

        private void lbtRemoveNrsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvNrSite.SelectedItems.Count > 0)
            {
                int id = (int)lvNrSite.SelectedItems[0].Tag;

                ForecastNRSite fp;
                if (id > 0)
                    fp = _activeFSite.GetNReportedSite(id);
                else
                    fp = _activeFSite.NoneReportedSites[lvNrSite.SelectedItems[0].Index];

                _activeFSite.NoneReportedSites.Remove(fp);

                ForecastSite fs = _forecastInfo.GetForecastSiteBySiteId(fp.NReportedSite.Id);
                _forecastInfo.ForecastSites.Remove(fs);
                DataRepository.DeleteForecastSite(fs);//b
                BindNoneReportedSite();
                BindSites();
                OnForecastInfoDataChanged();
            }
        }

        private void lbtAddduration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AddDurationDatausage())
                BindForecastTest();
        }
        private void ShowSummary()
        {
            txttotalsite.Text = _forecastInfo.ForecastSites.Count.ToString();
            txtTotalpcount.Text = DataRepository.FSTotalProductCount(_forecastInfo.Id).ToString();
        }

        private void lbtImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ImportServiceStatistic())
            {
                BindSites();
                ShowSummary();
            }
        }

        private void lbtAddmselect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectSiteAndTest())
            {
                BindSites();
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
