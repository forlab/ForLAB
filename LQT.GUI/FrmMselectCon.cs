
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

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;
namespace LQT.GUI
{
    public partial class FrmMselectCon : Form
    {
        public IList<MasterProduct> SelectedProducts;
        private IList<int> _selectedProductids;
        private ForecastInfo _forecastInfo;
        private ForecastSite fsite;
        private int noHistoryRecord = 0;
        private bool getHistory = false;


        public FrmMselectCon(ForecastInfo finfo)
        {
            _forecastInfo = finfo;

            InitializeComponent();

            if (_forecastInfo.DatausageEnum != DataUsageEnum.DATA_USAGE3)
                BindSites();
            else
                BindProductCategoryes();

            BindProducts();
        }

        private void BindProducts()
        {
            lvProductAll.BeginUpdate();
            lvProductAll.Items.Clear();

            foreach (MasterProduct p in DataRepository.GetAllProduct())
            {
                ListViewItem li = new ListViewItem(p.ProductName) { Tag = p };
                li.SubItems.Add(p.SerialNo);
                li.SubItems.Add(p.BasicUnit);
               // li.SubItems.Add(p.PackagingSize.ToString());
                li.SubItems.Add(p.Specification);

                lvProductAll.Items.Add(li);
            }

            lvProductAll.EndUpdate();

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

        private void BindProductCategoryes()
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
            foreach (int id in _selectedProductids)
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
                _selectedProductids = fsite.GetSelectedTestId();

                int month = _forecastInfo.StartDate.Month;
               
                foreach (ListViewItem l in lvProductAll.SelectedItems)
                {
                    int noperiod = NoRPeriod();
                    MasterProduct  pro = (MasterProduct)l.Tag;
                    if (!IsTestSelected(pro.Id))
                    {
                        int year = _forecastInfo.StartDate.Year;
                        DateTime lastd = _forecastInfo.StartDate;
                        int quar = LqtUtil.GetQuarter(_forecastInfo.StartDate);
                        int quartermonth = 1;
                        IList<ForecastSiteProduct> historicalSiteProduct =
                   DataRepository.GetHistoricalProduct(_forecastInfo.Period,_forecastInfo.Methodology, _forecastInfo.DataUsage, pro.Id, fsite.Site.Id, _forecastInfo.StartDate, 0);
                        TimeSpan diff = new TimeSpan(); ;
                        if (historicalSiteProduct.Count > 0)
                        {
                            DateTime lasthistorydate = historicalSiteProduct[0].DurationDateTime.Value;//sd
                            DateTime startdate = _forecastInfo.StartDate;
                            diff = startdate.Subtract(lasthistorydate);
                            if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                            {
                                int noofemptyM = (((int)diff.TotalDays / 30)*2) - 1;
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

                            AddForecastProductHistory(pro.Id, fsite.Site.Id, _forecastInfo.StartDate);
                        }
                   
                        for (int x = 1; x <= noperiod; x++)
                        {
                            ForecastSiteProduct sp = new ForecastSiteProduct();
                            sp.Product = pro;
                            sp.ForecastSite = fsite;
                            sp.AmountUsed = 1;
                            sp.Adjusted = 1;
                            if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                            {
                                //int y = month - x;
                                //if (y <= 0)
                                //    y = 12 + y;
                                lastd = lastd.AddMonths(-2);
                                sp.CDuration = LqtUtil.Months[lastd.Month - 1] + "-" + lastd.Year.ToString();
                                DateTime Duration = new DateTime(lastd.Year, lastd.Month, 1);
                                sp.DurationDateTime = Duration;
                            }
                            else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                            {
                                //int y = month - x;
                                //if (y <= 0)
                                //    y = 12 + y;
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
                            fsite.SiteProducts.Add(sp);
                        }
                       
                    }
                }
                // _forecastInfo.ForecastSites.Add(fsite);
            }

        }

        public void AddForecastProductHistory(int productid, int siteid, DateTime startdate)
        {
            IList<ForecastSiteProduct> historicalSiteProduct =
           DataRepository.GetHistoricalProduct(_forecastInfo.Period,_forecastInfo.Methodology, _forecastInfo.DataUsage, productid, siteid, startdate, noHistoryRecord);
            MasterProduct product = DataRepository.GetProductById(productid);
            foreach (ForecastSiteProduct fst in historicalSiteProduct)
            {
                fst.Product = product;
                fst.ForecastSite = fsite;
                fsite.SiteProducts.Add(fst);

            }
            DataRepository.BatchSaveForecastSiteProduct(historicalSiteProduct);

        }

        private void ProcessByCategory()
        {
            foreach (ListViewItem li in lsvSites.CheckedItems)
            {
                ForecastCategory fcat = (ForecastCategory)li.Tag;
                _selectedProductids = fcat.GetSelectedProductId();

                int month = _forecastInfo.StartDate.Month;

                foreach (ListViewItem l in lvProductAll.SelectedItems)
                {
                    MasterProduct pro = (MasterProduct)l.Tag;
                    if (!IsTestSelected(pro.Id))
                    {
                        int year = _forecastInfo.StartDate.Year;
                        int quar = LqtUtil.GetQuarter(_forecastInfo.StartDate);
                        DateTime lastd = _forecastInfo.StartDate;
                      
                        int quartermonth = 1;
                        for (int x = 1; x <= NoRPeriod(); x++)
                        {
                            ForecastCategoryProduct sp = new ForecastCategoryProduct();
                            sp.Product = pro;
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
                            fcat.CategoryProducts.Add(sp);
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

       

    }
}
