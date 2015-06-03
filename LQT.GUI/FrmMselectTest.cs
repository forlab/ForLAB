
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

namespace LQT.GUI
{
    public partial class FrmMselectTest : Form
    {
        public IList<Test> SelectedTests;
        private IList<int> _selectedTestids;
        //private IList<Test> _tests;
        private ForecastInfo _forecastInfo;
        private ForecastSite fsite;
        private int noHistoryRecord = 0;
        private bool getHistory = false;

        public FrmMselectTest(ForecastInfo finfo)
        {
            _forecastInfo = finfo;

            InitializeComponent();
            
            if (_forecastInfo.DatausageEnum != DataUsageEnum.DATA_USAGE3)
                BindSites();
            else
                BindTestCategoryes();
                
            BindTests();
        }
        
        private void BindTests()
        {
            lvTests.BeginUpdate();
            lvTests.Items.Clear();

            foreach (Test s in DataRepository.GetAllTests())
            {
                ListViewItem li = new ListViewItem(s.TestName) { Tag = s };
                li.SubItems.Add(s.TestingGroup.GroupName);
                li.SubItems.Add(s.TestingArea.AreaName);

                lvTests.Items.Add(li);
            }
            lvTests.EndUpdate();

        }

        private void BindSites()
        {
            lsvSites.BeginUpdate();
            lsvSites.Items.Clear();

            foreach (ForlabRegion region in DataRepository.GetAllRegion())
            {
                ListViewGroup lg = new ListViewGroup(region.RegionName);
                lsvSites.Groups.Add(lg);

                foreach (ForlabSite s in region.Sites)
                {
                    ListViewItem li = new ListViewItem(s.SiteName) { Tag = s };
                    li.Group = lg;
                    if (_forecastInfo.GetForecastSiteBySiteId(s.Id) == null) //b         
                    lsvSites.Items.Add(li);    
                }
                
            }
            lsvSites.EndUpdate();
        }

        private void BindTestCategoryes()
        {
            lsvSites.BeginUpdate();
            lsvSites.Items.Clear();
            lsvSites.Columns[0].Text = "List of Categories";

            foreach (ForecastCategory cat in _forecastInfo.ForecastCategories)
            {
                ListViewItem li = new ListViewItem(cat.CategoryName) { Tag = cat };
                lsvSites.Items.Add(li);
            }

            lsvSites.EndUpdate();
        }

        private bool IsTestSelected(int siteid)
        {
            foreach (int id in _selectedTestids)
            {
                if (id == siteid)
                    return true;
            }
            return false;
        }

        private void butSelect_Click(object sender, EventArgs e)
        {

            if (_forecastInfo.DatausageEnum != DataUsageEnum.DATA_USAGE3)
                ProcessBySite();
            else
                ProcessByCategory();
        
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void ProcessBySite()
        {
            foreach (ListViewItem li in lsvSites.CheckedItems)
            {
                ForlabSite site = (ForlabSite)li.Tag;
                fsite = _forecastInfo.GetForecastSiteBySiteId(site.Id);

                if (fsite == null)
                {
                    fsite = new ForecastSite();
                    fsite.Site = site;
                    fsite.ForecastInfo = _forecastInfo;
                    _forecastInfo.ForecastSites.Add(fsite);
                }
                _selectedTestids = fsite.GetSelectedTestId();

                int month = _forecastInfo.StartDate.Month;

                foreach (ListViewItem l in lvTests.SelectedItems)
                {
                    int noperiod = NoRPeriod();
                    Test test = (Test)l.Tag;
                    if (!IsTestSelected(test.Id))
                    {
                        int year = _forecastInfo.StartDate.Year;
                        DateTime lastd = _forecastInfo.StartDate;
                        int quar = LqtUtil.GetQuarter(_forecastInfo.StartDate);
                        IList<ForecastSiteTest> historicalSiteProduct =
                 DataRepository.GetHistoricalTest(_forecastInfo.Period,_forecastInfo.Methodology, _forecastInfo.DataUsage, test.Id,fsite.Site.Id, _forecastInfo.StartDate, 0);
                        TimeSpan diff = new TimeSpan(); ;
                        if (historicalSiteProduct.Count > 0)
                        {
                            DateTime lasthistorydate = historicalSiteProduct[0].DurationDateTime.Value;//sd
                            DateTime startdate = _forecastInfo.StartDate;
                            diff = startdate.Subtract(lasthistorydate);
                            if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                            {
                                int noofemptyM = (((int)diff.TotalDays / 30)/2) - 1;
                                if (noofemptyM >= 1)
                                {
                                    if (noperiod > noofemptyM)
                                    {
                                        noHistoryRecord = noperiod - noofemptyM;
                                        noperiod = noofemptyM;
                                        getHistory = true;
                                    }
                                    else
                                    {
                                        getHistory = false;
                                    }
                                }
                                else
                                {
                                    noHistoryRecord = noperiod;
                                    getHistory = true;
                                    noperiod = 0;
                                }

                            }
                            else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                            {
                                int noofemptyM = ((int)diff.TotalDays / 30)-1;
                                if (noofemptyM >= 1)
                                {
                                    if (noperiod > noofemptyM)
                                    {
                                        noHistoryRecord = noperiod - noofemptyM;
                                        noperiod = noofemptyM;
                                        getHistory = true;
                                    }
                                    else
                                    {
                                        getHistory = false;
                                    }
                                }
                                else
                                {
                                    noHistoryRecord = noperiod;
                                    getHistory = true;
                                    noperiod = 0;
                                }

                            }
                            else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                            {
                                int noofemptyQ = ((int)diff.TotalDays / (30 * 3))-1;
                                if (noofemptyQ >= 1)
                                {
                                    if (noperiod > noofemptyQ)
                                    {
                                        noHistoryRecord = noperiod - noofemptyQ;
                                        noperiod = noofemptyQ;
                                        getHistory = true;
                                    }
                                    else
                                    {
                                        getHistory = false;
                                    }
                                }
                                else
                                {
                                    noofemptyQ = noperiod;
                                    noHistoryRecord = noperiod;
                                    getHistory = true;
                                    noperiod = 0;
                                }
                            }
                            else
                            {
                                int noofemptyY = ((int)diff.TotalDays / 365)-1;
                                if (noofemptyY >= 1)
                                {
                                    if (noperiod > noofemptyY)
                                    {
                                        noHistoryRecord = noperiod - noofemptyY;
                                        noperiod = noofemptyY;
                                        getHistory = true;
                                    }
                                    else
                                    {
                                        getHistory = false;
                                    }
                                }
                                else
                                {
                                    noHistoryRecord = noperiod;
                                    getHistory = true;
                                    noperiod = 0;

                                }
                            }
                        }
                        else
                        {
                            getHistory = false;
                        }


                        if (getHistory)
                        {

                            AddForecastSiteHistory(test.Id, fsite.Site.Id, _forecastInfo.StartDate);
                        }
                   

                        for (int x = 1; x <= noperiod; x++)
                        {
                            ForecastSiteTest sp = new ForecastSiteTest();
                            sp.Test = test;
                            sp.ForecastSite = fsite;
                            sp.AmountUsed = 1;
                            sp.Adjusted = 1;
                            int quartermonth = 1;
                            if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                            {
                                lastd = lastd.AddMonths(-2);
                                sp.CDuration = LqtUtil.Months[lastd.Month - 1] + "-" + lastd.Year.ToString();
                                DateTime Duration = new DateTime(lastd.Year, lastd.Month, 1);
                                sp.DurationDateTime = Duration;
                            }
                            else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                            {
                                lastd = lastd.AddMonths(-1);
                                sp.CDuration = LqtUtil.Months[lastd.Month - 1] + "-" + lastd.Year.ToString();
                                DateTime Duration = new DateTime(lastd.Year, lastd.Month, 1);
                                sp.DurationDateTime = Duration;
                            }
                            else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                            {

                                if (quar == 1)
                                {
                                    quar = 4;
                                    year--;
                                }
                                else
                                    quar--;
                                sp.CDuration = String.Format("{0}-Qua{1}", year, quar);

                                if (quar == 1)
                                    quartermonth = 1;
                                else if (quar == 2)
                                    quartermonth = 4;
                                else if (quar == 3)
                                    quartermonth = 7;
                                else
                                    quartermonth = 10;

                                DateTime Duration = new DateTime(year, quartermonth, 1);
                                sp.DurationDateTime = Duration;

                            }
                            else
                            {
                                year--;
                                sp.CDuration = year.ToString();
                                DateTime Duration = new DateTime(year, 1, 1);
                                sp.DurationDateTime = Duration;
                            }
                            fsite.SiteTests.Add(sp);
                        }
                       
                    }
                }
               
            }

        }
        //private void chkgethistory_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkgethistory.Checked)
        //    {
        //        txtHistoryPeriod.Visible = true;
        //        lblhistoryPeriod.Visible = true;
        //    }
        //    else
        //    {
        //        txtHistoryPeriod.Visible = false;
        //        lblhistoryPeriod.Visible = false;
        //    }

        //}

        //public bool GetHistory()
        //{
        //    if (chkgethistory.Checked)
        //        return true;
        //    else
        //        return false;
        //}

        //public int GetHistoryPeriod()
        //{
        //    if (txtHistoryPeriod.Text == "ALL")
        //        return 0;
        //    else
        //        return int.Parse(txtHistoryPeriod.Text);
        //}

        private void txtHistoryPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        public void AddForecastSiteHistory(int testid, int siteid, DateTime startdate)
        {
            IList<ForecastSiteTest> historicalSiteTests =
           DataRepository.GetHistoricalTest(_forecastInfo.Period,_forecastInfo.Methodology, _forecastInfo.DataUsage, testid, siteid, startdate, noHistoryRecord);
            Test test = DataRepository.GetTestById(testid);
            foreach (ForecastSiteTest fst in historicalSiteTests)
            {
                fst.Test = test;
                fst.ForecastSite = fsite;
                fsite.SiteTests.Add(fst);
            }
            DataRepository.BatchSaveForecastSiteTest(historicalSiteTests);

        }

        private void ProcessByCategory()
        {
            foreach (ListViewItem li in lsvSites.CheckedItems)
            {
                ForecastCategory fcat = (ForecastCategory)li.Tag;
                //ForecastSite fsite = _forecastInfo.GetForecastCategory(site.Id);

                //if (fsite == null)
                //{
                //    fsite = new ForecastSite();
                //    fsite.Site = site;
                //    fsite.ForecastInfo = _forecastInfo;
                //    _forecastInfo.ForecastSites.Add(fsite);
                //}
                _selectedTestids = fcat.GetSelectedTestId();

                int month = _forecastInfo.StartDate.Month;

                foreach (ListViewItem l in lvTests.SelectedItems)
                {
                    Test test = (Test)l.Tag;
                    if (!IsTestSelected(test.Id))
                    {
                        int year = _forecastInfo.StartDate.Year;
                        DateTime lastd = _forecastInfo.StartDate;
                        int quar = LqtUtil.GetQuarter(_forecastInfo.StartDate);
                        int quartermonth = 1;
                        for (int x = 1; x <= NoRPeriod(); x++)
                        {
                            ForecastCategoryTest sp = new ForecastCategoryTest();
                            sp.Test = test;
                            sp.Category = fcat;
                            sp.AmountUsed = 1;
                            sp.Adjusted = 1;
                            if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                            {
                                lastd = lastd.AddMonths(-2);
                                sp.CDuration = LqtUtil.Months[lastd.Month - 1] + "-" + lastd.Year.ToString();
                                DateTime Duration = new DateTime(lastd.Year, lastd.Month, 1);
                                sp.DurationDateTime = Duration;
                            }
                            else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                            {
                                lastd = lastd.AddMonths(-1);
                                sp.CDuration = LqtUtil.Months[lastd.Month - 1] + "-" + lastd.Year.ToString();
                                DateTime Duration = new DateTime(lastd.Year, lastd.Month, 1);
                                sp.DurationDateTime = Duration;
                            }
                            else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                            {
                                if (quar == 1)
                                {
                                    quar = 4;
                                    year--;
                                }
                                else
                                    quar--;
                                sp.CDuration = String.Format("{0}-Qua{1}", year, quar);

                                if (quar == 1)
                                    quartermonth = 1;
                                else if (quar == 2)
                                    quartermonth = 4;
                                else if (quar == 3)
                                    quartermonth = 7;
                                else
                                    quartermonth = 10;

                                DateTime Duration = new DateTime(year, quartermonth, 1);
                                sp.DurationDateTime = Duration;
                            }
                            else
                            {
                                year--;
                                sp.CDuration = year.ToString();
                                DateTime Duration = new DateTime(year, 1, 1);
                                sp.DurationDateTime = Duration;
                            }
                            fcat.CategoryTests.Add(sp);
                        }
                    }
                }
                // _forecastInfo.ForecastSites.Add(fsite);
            }

        }
        public int NoRPeriod()
        {
            if (txtNoperiod.Text == "")
                return 3;
            int no = int.Parse(txtNoperiod.Text);

            return no > 3 ? no : 3;
        }

        private void txtNoperiod_KeyPress(object sender, KeyPressEventArgs e)
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
