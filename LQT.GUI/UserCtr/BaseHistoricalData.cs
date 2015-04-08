
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI.UserCtr
{
    public partial class BaseHistoricalData : BaseUserControl
    {
        public event EventHandler<EventArgs> ForecastInfoDataChanged;
        public event EventHandler<StandardDivationEventArgs> StandardDivationChanged;

        public ForecastInfo _forecastInfo;
        public ForecastCategory _activeCategory;
        public ForecastSite _activeFSite;
        public LQT.GUI.LQTListView _lvHistData;
        public Chart _chartSd;

        private int _noOfPeriod;

        private IList<MasterProduct> _products;
        private IList<ForlabSite> _sites;
        private IList<Test> _tests;
        private int _noOfHistData;
        private int _currentIndex;
        private string _removeErrorMessage;
        private bool addData = false;
        ColumnHeader[] col = null;
        IList<ForecastCategoryProduct> productcatList = null;
        IList<ForecastSiteProduct> productsiteList = null;

        IList<ForecastCategoryTest> testcatList = null;
        IList<ForecastSiteTest> testsiteList = null;

        int productListunsorted = 0;
        int testListunsorted = 0;
        public BaseHistoricalData()
        {
            //InitializeComponent();

            _products = DataRepository.GetAllProduct();
            _sites = DataRepository.GetAllSite();
            _tests = DataRepository.GetAllTests();
        }

        protected void InitGridView()
        {
            _lvHistData.AddNoneEditableColumn(0);
            //_lvHistData.AddNoneEditableColumn(4);
            //_lvHistData.AddNoneEditableColumn(5);

            _lvHistData.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(_lvHistData_SubitemTextChanged);
            _lvHistData.OnSelectedGroupChanged += new EventHandler(lvProduct_OnSelectedGroupChanged);
        }

        private void lvProduct_OnSelectedGroupChanged(object sender, EventArgs e)
        {
            try
            {
                LqtListViewGroupSelectedEventArgs eargs = (LqtListViewGroupSelectedEventArgs)e;
                FillData(eargs.GetChartXYvalue);
                if (eargs.GetChartXYvalue.Count >= 3)
                    StartTest();

                _chartSd.Titles[0].Text = eargs.Title;
            }
            catch (Exception ex)
            {

            }
        }

        protected virtual void OnForecastInfoDataChanged()
        {
            EventHandler<EventArgs> handler = ForecastInfoDataChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        protected virtual void OnStandardDivationChanged(StandardDivationEventArgs e)
        {
            EventHandler<StandardDivationEventArgs> handler = StandardDivationChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private Consumption GetConsumption(int id)
        {
            Consumption con = null;
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                switch (_forecastInfo.DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        con = _activeFSite.ConsumptionByProduct(id);
                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        con = _activeCategory.ConsumptionByProduct(id);
                        break;
                }
            }
            else
            {
                switch (_forecastInfo.DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        con = _activeFSite.ConsumptionByTest(id);
                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        con = _activeCategory.ConsumptionByTest(id);
                        break;
                }
            }
            return con;
        }

        private IBaseDataUsage GetDataUsage(LQTListViewTag tag)
        {
            IBaseDataUsage idusage = null;

            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                switch (_forecastInfo.DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        if (tag.Id <= 0)
                            idusage = _activeFSite.SiteProducts[tag.Index];
                        else
                            idusage = _activeFSite.GetSiteProduct(tag.Id);
                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        if (tag.Id <= 0)
                            idusage = _activeCategory.CategoryProducts[tag.Index];
                        else
                            idusage = _activeCategory.GetFCatProduct(tag.Id);
                        break;
                }
            }
            else
            {
                switch (_forecastInfo.DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        if (tag.Id <= 0)
                            idusage = _activeFSite.SiteTests[tag.Index];
                        else
                            idusage = _activeFSite.GetSiteTest(tag.Id);
                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        if (tag.Id <= 0)
                            idusage = _activeCategory.CategoryTests[tag.Index];
                        else
                            idusage = _activeCategory.GetFCatTest(tag.Id);
                        break;
                }
            }

            return idusage;
        }

        private void _lvHistData_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            try
            {
                ListViewItem li = new ListViewItem();
                li = e.ListVItem;

                LQTListViewTag tag = new LQTListViewTag();

                tag.GroupTitle = li.Group.ToString();
                tag.Index = e.ColumnIndex;
                tag = (LQTListViewTag)li.Tag;

                //   int id = e.ColumnIndex-1 +tag.Id;
                //tag.Id = id;

                

                IBaseDataUsage fp = GetDataUsage((LQTListViewTag)li.Tag);
                bool flag = false;
                
                for (int i = 1; tag.Id < (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? productListunsorted : testListunsorted); i++)
                {
                    if (fp != null)
                    {
                        if (e.ListVItem.ListView.Columns[e.ColumnIndex].Text == fp.CDuration && tag.GroupTitle == (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? fp.Product.ProductName : fp.Test.TestName))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            tag.Id = 1 + tag.Id;
                            fp = GetDataUsage((LQTListViewTag)li.Tag);
                        }
                    }
                    else
                    {
                        tag.Id = 1 + tag.Id;
                        fp = GetDataUsage((LQTListViewTag)li.Tag);
                    }
                }
                //   }
                if (flag == false)
                {
                    for (int i = 1; ; i++)
                    {
                        if(tag.Id<0)                        
                        break;
                       
                        if (fp != null)
                        {
                            if (e.ListVItem.ListView.Columns[e.ColumnIndex].Text == fp.CDuration && (tag.GroupTitle == (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? fp.Product.ProductName : fp.Test.TestName)))
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                tag.Id = tag.Id - 1;
                                fp = GetDataUsage((LQTListViewTag)li.Tag);
                               
                            }
                        }
                        else
                        {
                            tag.Id = tag.Id - 1;
                            fp = GetDataUsage((LQTListViewTag)li.Tag);
                        }
                    }
                    
                }
                if (tag.Id > 0)
                {
                    ListView l1 = _lvHistData;
                    double am = 0, adj = 0, In = 0, St = 0;

                    int k = 0;
                    foreach (ListViewItem item in this._lvHistData.Items)
                    {

                        if (li.Group == item.Group)
                        {
                            if (k == 0)
                            {
                                am = double.Parse((string)item.SubItems[e.ColumnIndex].Text);//st

                            }
                            else if (k == 3)//4
                            {
                                adj = double.Parse((string)item.SubItems[e.ColumnIndex].Text);
                            }
                            else if (k == 2)//3
                            {
                                In = double.Parse((string)item.SubItems[e.ColumnIndex].Text);//am
                            }
                            else if (k == 1)//2
                            {
                                St = double.Parse((string)item.SubItems[e.ColumnIndex].Text);//In
                            }
                            k++;
                        }
                    }

                    decimal oldamount = fp.AmountUsed;
                    fp.AmountUsed = decimal.Parse(am.ToString());
                    fp.Adjusted = decimal.Parse(adj.ToString()); ;
                    fp.InstrumentDowntime = int.Parse(In.ToString());
                    fp.StockOut = int.Parse(St.ToString()); 

                   
                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
                        UpdateProductOfNReportedSite(fp);

                    OnForecastInfoDataChanged();
                    int activeid = 0, adjustment = 0;
                    if (_activeCategory != null || _activeFSite != null)
                    {
                        if (_activeCategory != null)
                            activeid = _activeCategory.Id;
                        else if (_activeFSite != null)
                            activeid = _activeFSite.Id;

                        int activeIndex = _lvHistData.SelectedItems[0].Index;
                        foreach (IBaseDataUsage p in _forecastInfo.GetListOfDataUsages(activeid, activeIndex))
                        {
                            if (p.Id == tag.Id)//b
                            {
                                //_lvHistData.BeginUpdate();
                                p.Adjusted = p.AmountUsed;
                                if (p.AmountUsed == 0)
                                {
                                    try
                                    {
                                        Consumption cs = (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? GetConsumption(p.Product.Id) : GetConsumption(p.Test.Id));
                                        p.Adjusted = Math.Round(cs.TotalConsumption / cs.NoConsumption, 2, MidpointRounding.ToEven);
                                    }
                                    catch { p.Adjusted = p.AmountUsed; }
                                }

                                if ((p.InstrumentDowntime > 0 || p.StockOut > 0) && p.AmountUsed > 0)//
                                    p.Adjusted = LqtUtil.GetAdjustedVolume(p.AmountUsed, p.StockOut + p.InstrumentDowntime, _forecastInfo.PeriodEnum, GetActiveSiteWorkingDays());//b

                                foreach (ListViewItem item in this._lvHistData.Items)
                                {
                                    if (li.Group == item.Group)
                                    {
                                        if (item.Text == "Adjusted")
                                        {
                                            item.SubItems[e.ColumnIndex].Text = p.Adjusted.ToString();
                                            adjustment++;
                                        }
                                        if (item.Text == "Note")
                                        {
                                            if ((p.InstrumentDowntime > 0 || p.StockOut > 0) && p.AmountUsed > 0)
                                                item.SubItems[e.ColumnIndex].Text = "Adjusted";

                                            adjustment++;
                                        }
                                    }
                                    if (adjustment == 2)
                                        break;
                                }
                                //_lvHistData.EndUpdate();
                                break;
                            }

                        }
                    } 
                }
                else
                {
                    int k = 0;
                    foreach (ListViewItem item in this._lvHistData.Items)
                    {

                        if (li.Group == item.Group)
                        {
                            if (k == 0)
                            {
                                item.SubItems[e.ColumnIndex].Text = "-";

                            }
                            else if (k == 3)//4
                            {
                                item.SubItems[e.ColumnIndex].Text = "-";
                            }
                            else if (k == 2)//3
                            {
                                item.SubItems[e.ColumnIndex].Text = "-";
                            }
                            else if (k == 1)//2
                            {
                                item.SubItems[e.ColumnIndex].Text = "-";
                            }
                            k++;
                        }
                    }
                }

            }
            catch (Exception ex)
            { }
            // UpdateAdjustment();

        }

        private void UpdateAdjustment()
        {
            int activeid = 0;
            if (_activeCategory != null || _activeFSite != null)
            {
                if (_activeCategory != null)
                    activeid = _activeCategory.Id;
                else if (_activeFSite != null)
                    activeid = _activeFSite.Id;

                int activeIndex = _lvHistData.SelectedItems[0].Index;
                _lvHistData.BeginUpdate();
                _lvHistData.Items.Clear();
                int index = 0;
                foreach (IBaseDataUsage p in _forecastInfo.GetListOfDataUsages(activeid, activeIndex))
                {

                    p.Adjusted = p.AmountUsed;
                    if (p.AmountUsed == 0)
                    {
                        try
                        {
                            Consumption cs = (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? GetConsumption(p.Product.Id) : GetConsumption(p.Test.Id));
                            p.Adjusted = Math.Round(cs.TotalConsumption / cs.NoConsumption, 2, MidpointRounding.ToEven);
                        }
                        catch { p.Adjusted = p.AmountUsed; }
                    }

                    if ((p.InstrumentDowntime > 0 || p.StockOut > 0) && p.AmountUsed > 0)//
                        p.Adjusted = LqtUtil.GetAdjustedVolume(p.AmountUsed, p.StockOut + p.InstrumentDowntime, _forecastInfo.PeriodEnum, GetActiveSiteWorkingDays());//b


                    //update listview
                    LQTListViewTag tag = new LQTListViewTag();
                    tag.GroupTitle = (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? p.Product.ProductName : p.Test.TestName);
                    tag.Id = p.Id;
                    tag.Index = index;
                    ListViewItem li = new ListViewItem(p.CDuration) { Tag = tag };
                    if (p.AmountUsed == 0 && p.StockOut == 0 && p.InstrumentDowntime == 0)
                    {

                        li.SubItems.Add("-");
                        li.SubItems.Add("-");
                        li.SubItems.Add("-");
                    }
                    else
                    {
                        li.SubItems.Add(p.AmountUsed.ToString());
                        li.SubItems.Add(p.StockOut.ToString());
                        li.SubItems.Add(p.InstrumentDowntime.ToString());
                    }
                    li.SubItems.Add(p.Adjusted.ToString());


                    if (p.AmountUsed != p.Adjusted)
                        li.SubItems.Add("Adjusted");
                    else
                        li.SubItems.Add("");

                    LqtUtil.AddItemToGroup(_lvHistData, li);

                    if (IsHistorical(p.CDuration))
                        li.BackColor = System.Drawing.Color.LightBlue;
                    else
                        li.BackColor = System.Drawing.Color.Green;

                    _lvHistData.Items.Add(li);
                    index++;
                }
                _lvHistData.EndUpdate();
                //end update listview
            }
        }

        public decimal GetActiveSiteWorkingDays()
        {
            decimal workingday = 22;

            switch (_forecastInfo.DatausageEnum)
            {
                case DataUsageEnum.DATA_USAGE1:
                case DataUsageEnum.DATA_USAGE2:
                    workingday = _activeFSite.Site.WorkingDays;
                    break;
            }
            return workingday;
        }

        public void BindForecastDataUsage(int siteOrcatid, int activIndex)
        {

            DataRepository.SaveOrUpdateForecastInfo(_forecastInfo);

            _lvHistData.BeginUpdate();
            _lvHistData.Items.Clear();
            List<string> list = new List<string>();
            List<string> plist = new List<string>();
            List<int> plistId = new List<int>();

            if (_activeCategory != null || _activeFSite != null)
            {
                int index = 0;
                int productcount = 0;

                #region MyRegion
                if (_forecastInfo.GetListOfDataUsages(siteOrcatid, activIndex).Count > 0)
                {
                    if (_forecastInfo.Methodology == MethodologyEnum.CONSUMPTION.ToString())
                    {
                        if (_forecastInfo.DataUsage == DataUsageEnum.DATA_USAGE3.ToString())
                        {
                            productcatList = (IList<ForecastCategoryProduct>)_forecastInfo.GetListOfDataUsages(siteOrcatid, activIndex);
                            productListunsorted = productcatList[0].Id;
                            productcatList.Sort(delegate(ForecastCategoryProduct p1, ForecastCategoryProduct p2) { return p1.DurationDateTime.Value.Date.CompareTo(p2.DurationDateTime.Value.Date); });
                            productcount = productcatList.Count;
                            foreach (ForecastCategoryProduct p in productcatList)
                            {
                                if (list.Contains(p.CDuration) != true)
                                {
                                    list.Add(p.CDuration);
                                }
                                if (plist.Contains(p.Product.ProductName) != true)
                                {
                                    plist.Add(p.Product.ProductName);
                                    plistId.Add(p.Product.Id);
                                }
                                if (productListunsorted < p.Id)
                                    productListunsorted = p.Id;

                            }
                        }
                        else
                        {
                            productsiteList = (IList<ForecastSiteProduct>)_forecastInfo.GetListOfDataUsages(siteOrcatid, activIndex);
                            productListunsorted = productsiteList[0].Id;
                            productsiteList.Sort(delegate(ForecastSiteProduct p1, ForecastSiteProduct p2) { return p1.DurationDateTime.Value.Date.CompareTo(p2.DurationDateTime.Value.Date); });
                            productcount = productsiteList.Count;


                            foreach (ForecastSiteProduct p in productsiteList)
                            {
                                if (list.Contains(p.CDuration) != true)
                                {
                                    list.Add(p.CDuration);
                                }
                                if (plist.Contains(p.Product.ProductName) != true)
                                {
                                    plist.Add(p.Product.ProductName);
                                }
                                if (productListunsorted < p.Id)
                                    productListunsorted = p.Id;

                            }


                        }
                    }
                    else
                    {
                        if (_forecastInfo.DataUsage == DataUsageEnum.DATA_USAGE3.ToString())
                        {
                            testcatList = (IList<ForecastCategoryTest>)_forecastInfo.GetListOfDataUsages(siteOrcatid, activIndex);
                            testListunsorted = testcatList[0].Id;
                            testcatList.Sort(delegate(ForecastCategoryTest t1, ForecastCategoryTest t2) { return t1.DurationDateTime.Value.Date.CompareTo(t2.DurationDateTime.Value.Date); });
                            productcount = testcatList.Count;



                            foreach (ForecastCategoryTest t in testcatList)
                            {
                                if (list.Contains(t.CDuration) != true)
                                {
                                    list.Add(t.CDuration);
                                }
                                if (plist.Contains(t.Test.TestName) != true)
                                {
                                    plist.Add(t.Test.TestName);
                                    plistId.Add(t.Test.Id);
                                }
                                if (testListunsorted < t.Id)
                                    testListunsorted = t.Id;

                            }
                        }
                        else
                        {
                            testsiteList = (IList<ForecastSiteTest>)_forecastInfo.GetListOfDataUsages(siteOrcatid, activIndex);
                            testListunsorted = testsiteList[0].Id;
                            testsiteList.Sort(delegate(ForecastSiteTest t1, ForecastSiteTest t2) { return t1.DurationDateTime.Value.Date.CompareTo(t2.DurationDateTime.Value.Date); });
                            productcount = testsiteList.Count;


                            foreach (ForecastSiteTest t in testsiteList)
                            {
                                if (list.Contains(t.CDuration) != true)
                                {
                                    list.Add(t.CDuration);
                                }
                                if (plist.Contains(t.Test.TestName) != true)
                                {
                                    plist.Add(t.Test.TestName);
                                }
                                if (testListunsorted < t.Id)
                                    testListunsorted = t.Id;

                            }
                        }
                    }


                    if (_forecastInfo.Period == "YEARLY")
                        list.Sort();
                    int count = list.Count;
                    _lvHistData.Columns.Clear();
                    this._lvHistData.Items.Clear();
                    col = new ColumnHeader[count + 1];
                    ColumnHeader u = new ColumnHeader();
                    u.Text = "";
                    col[0] = u;
                    if (_forecastInfo.Period == ForecastPeriodEnum.Yearly.ToString())
                    {
                        for (int i = count; i >= 1; i--)
                        {
                            ColumnHeader c = new ColumnHeader();
                            c.Text = list[i - 1].ToString();
                            col[i] = c;
                        }

                    }

                    if (_forecastInfo.Period == ForecastPeriodEnum.Monthly.ToString())
                    {
                        DateTime last = _forecastInfo.StartDate;
                        for (int i = 1; i <= count; i++)
                        {
                            ColumnHeader c = new ColumnHeader();
                            c.Text = list[i - 1].ToString();
                            col[i] = c;
                        }


                    }
                    if (_forecastInfo.Period == ForecastPeriodEnum.Bimonthly.ToString())
                    {
                        DateTime last = _forecastInfo.StartDate;
                        for (int i = count; i >= 1; i--)
                        {
                            ColumnHeader c = new ColumnHeader();
                            last = last.AddMonths(-2);
                            c.Text = list[i - 1].ToString();
                            col[i] = c;
                        }

                    }
                    if (_forecastInfo.Period == ForecastPeriodEnum.Quarterly.ToString())
                    {
                        int quar = GetQuarter(_forecastInfo.StartDate);
                        int year = _forecastInfo.StartDate.Year;
                        for (int i = count; i >= 1; i--)
                        {
                            if (quar == 1)
                            {
                                quar = 4;
                                year--;
                            }
                            else
                                quar--;
                            ColumnHeader c = new ColumnHeader();
                            c.Text = list[i - 1].ToString();
                            col[i] = c;
                        }
                    }


                    this._lvHistData.Columns.AddRange(col);
                    addData = false;
                    
                    int j = 0, k = 1;
                    ListViewItem l1 = null;
                    ListViewItem l2 = null;
                    ListViewItem l3 = null;
                    ListViewItem l4 = null;
                    ListViewItem l5 = null;
                    List<string> prolist = new List<string>();


                    
                    for (int z = 0; z < plist.Count; z++)
                    {
                        bool flag = false;
                        bool flag1 = false;
                        int insert = 1, rem = 0;
                        j = 0;

                        foreach (IBaseDataUsage p in _forecastInfo.GetListOfDataUsages(siteOrcatid, activIndex))
                        { 
                          
                            if (plist[z] ==( _forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? p.Product.ProductName : p.Test.TestName))
                            {
                            LQTListViewTag tag = new LQTListViewTag();
                            tag.GroupTitle = (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? p.Product.ProductName : p.Test.TestName);
                            tag.Id = p.Id;
                            tag.Index = index;

                           
                                if (flag1 == false) 
                                {

                                    l1 = new ListViewItem("ProductUsed/TestPerformed") { Tag = tag };
                                    l2 = new ListViewItem("StockOut") { Tag = tag };
                                    l3 = new ListViewItem("InstrumentDowntime") { Tag = tag };
                                    l4 = new ListViewItem("Adjusted") { Tag = tag };
                                    l5 = new ListViewItem("Note") { Tag = tag };

                                    for (int f = 1; f <= list.Count; f++)
                                        if (list[f - 1] == p.CDuration)
                                        {
                                            insert = f;

                                            for (int l = 1; l < insert; l++)
                                            {
                                                l1.SubItems.Add("-");
                                                l2.SubItems.Add("-");
                                                l3.SubItems.Add("-");
                                                l4.SubItems.Add("-");
                                                l5.SubItems.Add("-");
                                                l1.SubItems.Insert(l, l1.SubItems[l]);
                                                l2.SubItems.Insert(l, l2.SubItems[l]);
                                                l3.SubItems.Insert(l, l3.SubItems[l]);
                                                l4.SubItems.Insert(l, l4.SubItems[l]);
                                                k = k + 2;
                                            }
                                            break;
                                        }

                                    l1.SubItems.Add(p.AmountUsed.ToString());
                                    l2.SubItems.Add(p.StockOut.ToString());
                                    l3.SubItems.Add(p.InstrumentDowntime.ToString());
                                    l4.SubItems.Add(p.Adjusted.ToString());
                                    if (p.AmountUsed != p.Adjusted)
                                    {
                                        l5.SubItems.Add("Adjusted");
                                    }
                                    else
                                    {
                                        l5.SubItems.Add("-");
                                    }
                                    l1.SubItems.Insert(insert, l1.SubItems[k]);
                                    l2.SubItems.Insert(insert, l2.SubItems[k]);
                                    l3.SubItems.Insert(insert, l3.SubItems[k]);
                                    l4.SubItems.Insert(insert, l4.SubItems[k]);

                                    k = k + 2;
                                    flag1 = true;
                                    rem = insert;
                                    insert++;

                                }
                                else if (j == productcount - 1)
                                {

                                    l1.SubItems.Add(p.AmountUsed.ToString());
                                    l2.SubItems.Add(p.StockOut.ToString());
                                    l3.SubItems.Add(p.InstrumentDowntime.ToString());
                                    l4.SubItems.Add(p.Adjusted.ToString());
                                    if (p.AmountUsed != p.Adjusted)
                                    {
                                        l5.SubItems.Add("Adjusted");
                                    }
                                    else
                                    {
                                        l5.SubItems.Add("-");
                                    }
                                    

                                    l1.SubItems.Insert(insert, l1.SubItems[k]);
                                    l2.SubItems.Insert(insert, l2.SubItems[k]);
                                    l3.SubItems.Insert(insert, l3.SubItems[k]);
                                    l4.SubItems.Insert(insert, l4.SubItems[k]);
                                    j = 0; 
                                    flag = true;
                                    k = 1;
                                    insert++;
                                    rem = insert;

                                    break;

                                }
                                else 
                                {


                                    l1.SubItems.Add(p.AmountUsed.ToString());
                                    l2.SubItems.Add(p.StockOut.ToString());
                                    l3.SubItems.Add(p.InstrumentDowntime.ToString());
                                    l4.SubItems.Add(p.Adjusted.ToString());
                                    if (p.AmountUsed != p.Adjusted)
                                    {
                                        l5.SubItems.Add("Adjusted");
                                    }
                                    else
                                    {
                                        l5.SubItems.Add("-");
                                    }
                                    

                                    l1.SubItems.Insert(insert, l1.SubItems[k]);
                                    l2.SubItems.Insert(insert, l2.SubItems[k]);
                                    l3.SubItems.Insert(insert, l3.SubItems[k]);
                                    l4.SubItems.Insert(insert, l4.SubItems[k]);
                                    
                                    k = k + 2;
                                    rem = insert;
                                    insert++;

                                }  
                            }
                                else if (flag == false && j == productcount - 1)
                                {
                                    if (rem > 1)
                                        for (int l = rem + 1; l <= list.Count; l++)
                                        {
                                            l1.SubItems.Add("-");
                                            l2.SubItems.Add("-");
                                            l3.SubItems.Add("-");
                                            l4.SubItems.Add("-");
                                            l5.SubItems.Add("-");
                                            l1.SubItems.Insert(l, l1.SubItems[k]);
                                            l2.SubItems.Insert(l, l2.SubItems[k]);
                                            l3.SubItems.Insert(l, l3.SubItems[k]);
                                            l4.SubItems.Insert(l, l4.SubItems[k]);
                                            k = k + 2;
                                        }

                                    k = 1;
                                    break;
                                }

                                j++;


                            }
                      
                        if (k == 1)
                        {
                            LqtUtil.AddItemToGroup(_lvHistData, l1);
                            LqtUtil.AddItemToGroup(_lvHistData, l2);
                            LqtUtil.AddItemToGroup(_lvHistData, l3);
                            LqtUtil.AddItemToGroup(_lvHistData, l4);
                            LqtUtil.AddItemToGroup(_lvHistData, l5);
                            index++;
                            _lvHistData.Items.AddRange(new ListViewItem[] { l1, l2, l3, l4, l5 });
                            l1.BackColor = System.Drawing.Color.LightBlue;
                            l2.BackColor = System.Drawing.Color.LightBlue;
                            l3.BackColor = System.Drawing.Color.LightBlue;
                            l4.BackColor = System.Drawing.Color.LightBlue;
                            l5.BackColor = System.Drawing.Color.LightBlue;
                        }

                    }
                    



                }
                #endregion

                _lvHistData.EndUpdate();
            }
        }

        public bool IsHistorical(string duration)
        {
            DateTime date = LqtUtil.DurationToDateTime(duration);
            if (date >= _forecastInfo.StartDate)
                return false;
            return true;
        }

        public bool AddSitesToCategory()
        {
            FrmSelectSite frm = new FrmSelectSite(_activeCategory.GetSelectedSiteId(), _sites);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (int siteid in frm.SelectedSiteIds)
                {
                    ForecastCategorySite fc = new ForecastCategorySite();
                    fc.Site = DataRepository.GetSiteById(siteid);
                    fc.Category = _activeCategory; ;

                    _activeCategory.CategorySites.Add(fc);
                }

                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public void AddSitesToForecast()
        {
            FrmSelectSite frm = new FrmSelectSite(_forecastInfo.GetSelectedSiteId(), _sites);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (int siteid in frm.SelectedSiteIds)
                {
                    ForecastSite fc = new ForecastSite();
                    fc.Site = DataRepository.GetSiteById(siteid);
                    fc.ForecastInfo = _forecastInfo;

                    _forecastInfo.ForecastSites.Add(fc);
                }

                OnForecastInfoDataChanged();
            }
        }

        private IList<int> GetSelectedProOrTestId()
        {
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                FrmSelectProduct frm = null;
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    frm = new FrmSelectProduct(_activeCategory.GetSelectedProductId(), _products);
                else
                    frm = new FrmSelectProduct(_activeFSite.GetSelectedProductId(), _products);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _noOfPeriod = frm.NoRPeriod();
                    return frm.SelectedProductIds;
                }
            }
            else
            {
                FrmSelectTest frm = null;
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    frm = new FrmSelectTest(_activeCategory.GetSelectedTestId(), _tests);
                else
                    frm = new FrmSelectTest(_activeFSite.GetSelectedTestId(), _tests);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _noOfPeriod = frm.NoRPeriod();
                    return frm.SelectedTestIds;
                }
            }
            return null;
        }

        private IBaseDataUsage GetNewDataUsage()
        {
            IBaseDataUsage dusage = null;
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                switch (_forecastInfo.DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        dusage = new ForecastSiteProduct() { ForecastSite = _activeFSite };

                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        dusage = new ForecastCategoryProduct() { Category = _activeCategory };
                        break;
                }
            }
            else
            {
                switch (_forecastInfo.DatausageEnum)
                {
                    case DataUsageEnum.DATA_USAGE1:
                    case DataUsageEnum.DATA_USAGE2:
                        dusage = new ForecastSiteTest() { ForecastSite = _activeFSite };
                        break;
                    case DataUsageEnum.DATA_USAGE3:
                        dusage = new ForecastCategoryTest() { Category = _activeCategory };
                        break;
                }
            }
            return dusage;
        }

        public bool AddProdutOrTestDatausage()
        {
            IList<int> selectedIds = GetSelectedProOrTestId();
            if (selectedIds != null)
            {
                foreach (int proid in selectedIds)
                {
                    int year = _forecastInfo.StartDate.Year;
                    int quar = GetQuarter(_forecastInfo.StartDate);
                    DateTime lastd = _forecastInfo.StartDate;

                    MasterProduct product = null;
                    Test test = null;
                    if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                        product = DataRepository.GetProductById(proid);
                    else
                        test = DataRepository.GetTestById(proid);
                    ////
                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE1)
                    {
                        if (HistoryDataExist(proid))
                        {
                            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                                AddForecastProductHistory(proid, _activeFSite.Site.Id, _forecastInfo.StartDate);
                            else
                                AddForecastTestHistory(proid, _activeFSite.Site.Id, _forecastInfo.StartDate);

                        }

                    }

                    ///



                    for (int x = _noOfPeriod; x >= 1; x--)
                    {
                        IBaseDataUsage fc = GetNewDataUsage();
                        fc.Product = product;
                        fc.Test = test;
                        fc.AmountUsed = 1;
                        fc.Adjusted = 1;

                        if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                        {
                            //  lastd = lastd.AddMonths(-2);
                            lastd = _forecastInfo.StartDate.AddMonths(-(x * 2));
                            fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);
                        }
                        else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                        {
                            lastd = _forecastInfo.StartDate.AddMonths(-(x));

                            fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);

                        }
                        else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                        {
                            lastd = _forecastInfo.StartDate.AddMonths(-(x * 3));
                            quar = GetQuarter(lastd);
                            year = _forecastInfo.StartDate.AddMonths(-(x * 3)).Year;
                            //if (quar == 1)
                            //{
                            //    quar = 4;
                            //}

                            //else
                            //    quar = quar - 1;

                            fc.CDuration = String.Format("Qua{0}-{1}", quar, year);

                        }
                        else
                        {

                            fc.CDuration = (year - x).ToString();
                        }

                        fc.DurationDateTime = LqtUtil.DurationToDateTime(fc.CDuration);
                        AddDataUsageToSiteOrCat(fc);

                        if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
                            AddProductToNReportedSite(_activeFSite.Id, fc);
                    }
                }
                if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                    _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();

                OnForecastInfoDataChanged();
                addData = true;
                return true;
            }

            return false;
        }

        private void AddDataUsageToSiteOrCat(IBaseDataUsage dusage)
        {
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                {
                    _activeCategory.CategoryProducts.Add((ForecastCategoryProduct)dusage);
                    //ArrayList.Adapter(_activeCategory.CategoryProducts).Sort();
                }
                else
                    _activeFSite.SiteProducts.Add((ForecastSiteProduct)dusage);


            }
            else
            {
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    _activeCategory.CategoryTests.Add((ForecastCategoryTest)dusage);
                else
                    _activeFSite.SiteTests.Add((ForecastSiteTest)dusage);


            }
            if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();
        }

        public bool RemoveDataUsageFromCategory()
        {
            if (_lvHistData.SelectedItems.Count > 0)
            {
                string SelectedCol = col[_lvHistData.subItemSelected].Text.ToString();
                int j = 0;
                LQTListViewTag tag = (LQTListViewTag)_lvHistData.SelectedItems[0].Tag;
                IBaseDataUsage fp1 = GetDataUsage((LQTListViewTag)tag);
                string type = _forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? fp1.Product.ProductName.ToString() : fp1.Test.TestName.ToString();
                bool flag = false;
                for (int i = 1; tag.Id < (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? productListunsorted : testListunsorted); i++)
                {
                    if (fp1 != null)
                    {
                        if (fp1.CDuration == SelectedCol && (type == (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? fp1.Product.ProductName.ToString() : fp1.Test.TestName.ToString())))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            tag.Id = 1 + tag.Id;
                            fp1 = GetDataUsage((LQTListViewTag)tag);
                        }
                    }
                    else
                    {
                        tag.Id = 1 + tag.Id;
                        fp1 = GetDataUsage((LQTListViewTag)tag);
                    }
                    j++;

                }
                if (flag == false)
                {
                    j = 0;
                    for (int i = 1; ; i++)
                    {
                        if (tag.Id < 0 || j >= _lvHistData.Items.Count)
                            break;

                        if (fp1 != null)
                        {
                            if (fp1.CDuration == SelectedCol && (type == (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? fp1.Product.ProductName.ToString() : fp1.Test.TestName.ToString())))
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                tag.Id = tag.Id - 1;
                                fp1 = GetDataUsage((LQTListViewTag)tag);

                            }
                        }
                        else
                        {
                            tag.Id = tag.Id - 1;
                            fp1 = GetDataUsage((LQTListViewTag)tag);
                        }
                        j++;

                    }

                }


                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    ForecastCategoryProduct fp;
                    if (tag.Id > 0)
                        fp = _activeCategory.GetFCatProduct(tag.Id);
                    else
                        fp = _activeCategory.CategoryProducts[tag.Index];
                    if (flag == true)
                    {
                        IList<ForecastCategoryProduct> fcp = DataRepository.GetFCategoryProductByProId(fp.Category.Id, fp.Product.Id, SortDirection.Descending);

                        _currentIndex = (int)fcp.IndexOf(fp);
                        if (fp.Product.ProductName == tag.GroupTitle)
                        {
                            if (_forecastInfo.CanRemoveDataUsage(fp.Category.Id, fp.Product.Id, _currentIndex, out _removeErrorMessage))
                                _activeCategory.CategoryProducts.Remove(fp);
                            else
                                ShowErrorMessage(_removeErrorMessage, "Delete Error");
                        }
                    }
                }
                else
                {
                    ForecastCategoryTest ft;
                    if (tag.Id > 0)
                        ft = _activeCategory.GetFCatTest(tag.Id);
                    else
                        ft = _activeCategory.CategoryTests[tag.Index];
                    if (flag == true)
                    {
                        IList<ForecastCategoryTest> fct = DataRepository.GetFCategoryTestByTestId(ft.Category.Id, ft.Test.Id, SortDirection.Descending);

                        _currentIndex = (int)fct.IndexOf(ft);
                        if (ft.Test.TestName == tag.GroupTitle)
                        {
                            if (_forecastInfo.CanRemoveDataUsage(ft.Category.Id, ft.Test.Id, _currentIndex, out _removeErrorMessage))
                                _activeCategory.CategoryTests.Remove(ft);
                            else
                                ShowErrorMessage(_removeErrorMessage, "Delete Error");
                        }
                    }
                }
                if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                    _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();

                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public bool RemoveDataUsageFromSite()
        {
            if (_lvHistData.SelectedItems.Count > 0)
            {
                string SelectedCol= col[_lvHistData.subItemSelected].Text.ToString();
                int j=0;  
                LQTListViewTag tag = (LQTListViewTag)_lvHistData.SelectedItems[0].Tag;
                IBaseDataUsage fp1 = GetDataUsage((LQTListViewTag)tag);
                string type = _forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ?fp1.Product.ProductName.ToString():fp1.Test.TestName.ToString();
                bool flag = false;
                for (int i = 1; tag.Id < (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? productListunsorted : testListunsorted); i++)
                {
                    if (fp1 != null)
                    {
                        if (fp1.CDuration == SelectedCol &&(type==(_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ?fp1.Product.ProductName.ToString():fp1.Test.TestName.ToString())))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            tag.Id = 1 + tag.Id;
                            fp1 = GetDataUsage((LQTListViewTag)tag);
                        }
                    }
                    else
                    {
                        tag.Id = 1 + tag.Id;
                        fp1 = GetDataUsage((LQTListViewTag)tag);
                    }
                    j++;
                   
                }
                if (flag == false)
                {
                   j=0;
                    for (int i = 1; ; i++)
                    {
                        if (tag.Id < 0 || j >= _lvHistData.Items.Count)
                            break;

                        if (fp1 != null)
                        {
                            if (fp1.CDuration == SelectedCol && (type == (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION ? fp1.Product.ProductName.ToString() : fp1.Test.TestName.ToString())))
                            {
                                flag = true;
                                break;
                            }
                            else
                            {
                                tag.Id = tag.Id - 1;
                                fp1 = GetDataUsage((LQTListViewTag)tag);

                            }
                        }
                        else
                        {
                            tag.Id = tag.Id - 1;
                            fp1 = GetDataUsage((LQTListViewTag)tag);
                        }
                        j++;
                        
                    }

                }

                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    ForecastSiteProduct fp;
                    if (tag.Id > 0)
                        fp = _activeFSite.GetSiteProduct(tag.Id);
                    else
                        fp = _activeFSite.SiteProducts[tag.Index];

                    if (flag == true)
                    {
                        IList<ForecastSiteProduct> fsp = DataRepository.GetFSiteProductByProId(fp.ForecastSite.Id, fp.Product.Id, SortDirection.Descending);

                        _currentIndex = (int)fsp.IndexOf(fp);

                        if (fp.Product.ProductName == tag.GroupTitle)
                        {
                            if (_forecastInfo.CanRemoveDataUsage(fp.ForecastSite.Id, fp.Product.Id, _currentIndex, out _removeErrorMessage))
                                _activeFSite.SiteProducts.Remove(fp);
                            else
                                ShowErrorMessage(_removeErrorMessage, "Delete Error");
                        }
                    }
                }
                else
                {
                    ForecastSiteTest ft;
                    if (tag.Id > 0)
                        ft = _activeFSite.GetSiteTest(tag.Id);
                    else
                        ft = _activeFSite.SiteTests[tag.Index];
                    if (flag == true)
                    {
                        IList<ForecastSiteTest> fst = DataRepository.GetFSiteTestByTestId(ft.ForecastSite.Id, ft.Test.Id, SortDirection.Descending);

                        _currentIndex = (int)fst.IndexOf(ft);
                        if (ft.Test.TestName == tag.GroupTitle)
                        {
                            if (_forecastInfo.CanRemoveDataUsage(ft.ForecastSite.Id, ft.Test.Id, _currentIndex, out _removeErrorMessage))
                                _activeFSite.SiteTests.Remove(ft);
                            else
                                ShowErrorMessage(_removeErrorMessage, "Delete Error");
                        }
                    }
                }
                if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                    _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();

                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        private IList GetListOfDataUsages(int proOrtestid)
        {
            IList result = new ArrayList();
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    result = (IList)DataRepository.GetFCategoryProductByProId(_activeCategory.Id, proOrtestid, SortDirection.Descending);
                else
                    result = (IList)DataRepository.GetFSiteProductByProId(_activeFSite.Id, proOrtestid, SortDirection.Descending);
            }
            else
            {
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    result = (IList)DataRepository.GetFCategoryTestByTestId(_activeCategory.Id, proOrtestid, SortDirection.Descending);
                else
                    result = (IList)DataRepository.GetFSiteTestByTestId(_activeFSite.Id, proOrtestid, SortDirection.Descending);
            }
            return result;
        }

        public bool AddDurationDatausage()
        {
            LQTListViewTag tag = (LQTListViewTag)_lvHistData.SelectedItems[0].Tag;
            FrmReportedPeriod frm = new FrmReportedPeriod(_forecastInfo.StartDate);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                addData = true;
                MasterProduct product = null;
                Test test = null;
                IList list = new ArrayList();

                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                        product = tag.Id > 0 ? _activeCategory.GetFCatProduct(tag.Id).Product : _activeCategory.CategoryProducts[tag.Index].Product;
                    else
                        product = tag.Id > 0 ? _activeFSite.GetSiteProduct(tag.Id).Product : _activeFSite.SiteProducts[tag.Index].Product;
                    list = GetListOfDataUsages(product.Id);
                }
                else
                {
                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                        test = tag.Id > 0 ? _activeCategory.GetFCatTest(tag.Id).Test : _activeCategory.CategoryTests[tag.Index].Test;
                    else
                        test = tag.Id > 0 ? _activeFSite.GetSiteTest(tag.Id).Test : _activeFSite.SiteTests[tag.Index].Test;
                    list = GetListOfDataUsages(test.Id);
                }

                int direction = frm.DataFlow() == "Down" ? -1 : 1;
                DateTime lastd = _forecastInfo.StartDate;
                if (list.Count > 0)
                {
                    if (direction == -1)
                        lastd = ((IBaseDataUsage)list[list.Count - 1]).DurationDateTime.Value;
                    else
                        lastd = ((IBaseDataUsage)list[0]).DurationDateTime.Value;
                }

                int year = lastd.Year;
                int quar = GetQuarter(lastd);
                ////

                _noOfPeriod = frm.NoPeriod;
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 && direction == -1)
                {
                    if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                    {
                        if (CheckHistoryData(product.Id, lastd))
                            AddForecastProductHistory(product.Id, _activeFSite.Site.Id, lastd);
                    }
                    else
                    {
                        if (CheckHistoryData(test.Id, lastd))
                            AddForecastTestHistory(test.Id, _activeFSite.Site.Id, lastd);
                    }
                }
                int len = list.Count + _noOfPeriod;

                if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                {
                    lastd = lastd.AddMonths(direction * _noOfHistData * 2);
                }
                else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                {
                    lastd = lastd.AddMonths(direction * _noOfHistData);
                }
                else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                {
                    for (int i = 0; i < _noOfHistData; i++)
                    {
                        // lastd = lastd.AddMonths(-3);
                    }
                }
                else
                {
                    lastd = lastd.AddYears(direction * _noOfHistData);
                }
                int count;
                int last;

                if (direction == -1)
                {
                    count = list.Count + _noOfHistData + 1;
                    last = len;
                }
                else
                {
                    count = 1;
                    last = frm.NoPeriod;
                }


                ////

                for (int i = count; i <= last; i++) //for (int i = 1; i <= frm.NoPeriod; i++)
                {
                    IBaseDataUsage fc = GetNewDataUsage();
                    fc.Product = product;
                    fc.Test = test;
                    fc.AmountUsed = 1;
                    fc.Adjusted = 1;

                    if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                    {
                        lastd = lastd.AddMonths(direction * 2);
                        fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);
                    }
                    else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                    {
                        lastd = lastd.AddMonths(direction * 1);
                        fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);
                    }
                    else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                    {
                        lastd = lastd.AddMonths(direction * 3);
                        if (direction == -1)
                        {
                            if (quar == 1)
                            {
                                quar = 4;
                                year--;
                            }
                            else
                                quar--;
                        }
                        else
                        {
                            if (quar == 4)
                            {
                                quar = 1;
                                year++;
                            }
                            else
                                quar++;
                        }
                        fc.CDuration = String.Format("Qua{0}-{1}", quar, year);
                    }
                    else
                    {
                        lastd = lastd.AddYears(direction * 1);
                        fc.CDuration = lastd.Year.ToString();
                    }
                    fc.DurationDateTime = LqtUtil.DurationToDateTime(fc.CDuration);
                    AddDataUsageToSiteOrCat(fc);
                }

                if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                    _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();


                _lvHistData.ItemAreAddtogroup();
                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public bool ImportConsumption()
        {
            ImportConForm frm = new ImportConForm(_forecastInfo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _forecastInfo = frm.GetForecastInfo;
                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public bool SelectSiteAndProduct()
        {
            FrmMselectCon frm = new FrmMselectCon(_forecastInfo);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public bool ImportServiceStatistic()
        {
            ImportSerForm frm = new ImportSerForm(_forecastInfo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _forecastInfo = frm.GetForecastInfo;
                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public bool SelectSiteAndTest()
        {
            FrmMselectTest frm = new FrmMselectTest(_forecastInfo);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public bool AddSiteToForecast()
        {
            FrmSelectSite frm = new FrmSelectSite(_forecastInfo.GetSelectedSiteId(), _sites);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (int siteid in frm.SelectedSiteIds)
                {
                    ForecastSite fc = new ForecastSite();
                    fc.Site = DataRepository.GetSiteById(siteid);
                    fc.ForecastInfo = _forecastInfo;

                    _forecastInfo.ForecastSites.Add(fc);
                }
                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        public bool AddNoneReportedSite()
        {
            // FrmSelectSite frm = new FrmSelectSite(_activeFSite.GetSelectedNRSiteId(), _sites);
            FrmSelectSite frm = new FrmSelectSite(_forecastInfo.GetSelectedSiteId(), _sites);//b it Filters N.R site and Reported Site 
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (int siteid in frm.SelectedSiteIds)
                {
                    ForecastNRSite fc = new ForecastNRSite();
                    fc.NReportedSite = DataRepository.GetSiteById(siteid);
                    fc.ForecastSite = _activeFSite;

                    _activeFSite.NoneReportedSites.Add(fc);

                    ForecastSite fs = new ForecastSite();
                    fs.Site = fc.NReportedSite;
                    fs.ForecastInfo = _forecastInfo;
                    fs.ReportedSiteId = _activeFSite.Id;

                    CopySiteProduct(_activeFSite, fs);

                    _forecastInfo.ForecastSites.Add(fs);
                }

                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

        private void AddProductToNReportedSite(int sourceid, IBaseDataUsage fc)
        {
            foreach (ForecastSite fs in _forecastInfo.GetNoneReportedForecastSite(sourceid))
            {
                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    ForecastSiteProduct fsp = (ForecastSiteProduct)GetCloneForecastSiteProduct(fc);
                    fsp.ForecastSite = fs;
                    fs.SiteProducts.Add(fsp);
                }
                else
                {
                    ForecastSiteTest fst = (ForecastSiteTest)GetCloneForecastSiteProduct(fc);
                    fst.ForecastSite = fs;
                    fs.SiteTests.Add(fst);
                }
            }
            if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();
        }

        private void UpdateProductOfNReportedSite(IBaseDataUsage fc)
        {
            int id;
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                id = ((ForecastSiteProduct)fc).ForecastSite.Id;
            else
                id = ((ForecastSiteTest)fc).ForecastSite.Id;

            foreach (ForecastSite fs in _forecastInfo.GetNoneReportedForecastSite(id))
            {
                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    foreach (ForecastSiteProduct fp in fs.SiteProducts)
                    {
                        if (fp.DurationDateTime == fc.DurationDateTime)
                        {
                            fp.AmountUsed = fc.AmountUsed;
                            fp.StockOut = fc.StockOut;
                            fp.Adjusted = fc.Adjusted;
                            fp.InstrumentDowntime = fc.InstrumentDowntime;
                        }
                    }
                }
                else
                {
                    foreach (ForecastSiteTest fp in fs.SiteTests)
                    {
                        if (fp.DurationDateTime == fc.DurationDateTime)
                        {
                            fp.AmountUsed = fc.AmountUsed;
                            fp.StockOut = fc.StockOut;
                            fp.Adjusted = fc.Adjusted;
                            fp.InstrumentDowntime = fc.InstrumentDowntime;
                        }
                    }
                }
            }
            if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();
        }

        private void CopySiteProduct(ForecastSite source, ForecastSite destination)
        {
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                foreach (IBaseDataUsage fp in source.SiteProducts)
                {
                    ForecastSiteProduct fc = (ForecastSiteProduct)GetCloneForecastSiteProduct(fp);
                    fc.ForecastSite = destination;
                    destination.SiteProducts.Add(fc);
                }
            }
            else
            {
                foreach (IBaseDataUsage fp in source.SiteTests)
                {
                    ForecastSiteTest ft = (ForecastSiteTest)GetCloneForecastSiteProduct(fp);
                    ft.ForecastSite = destination;
                    destination.SiteTests.Add(ft);
                }
            }
        }

        private IBaseDataUsage GetCloneForecastSiteProduct(IBaseDataUsage fsp)
        {
            IBaseDataUsage dusage;
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                dusage = new ForecastSiteProduct();
            else
                dusage = new ForecastSiteTest();

            dusage.Product = fsp.Product;
            dusage.AmountUsed = fsp.AmountUsed;
            dusage.Adjusted = fsp.Adjusted;
            dusage.CDuration = fsp.CDuration;
            dusage.DurationDateTime = fsp.DurationDateTime;
            dusage.Test = fsp.Test; //Feb 19 2015
            return dusage;
        }

        private void FillData(IList<ChartXYValue> chartval)
        {

            _chartSd.Series[0].Points.Clear();

            ArrayList.Adapter((IList)chartval).Sort();
            if (chartval.Count >= 3)
            {
                foreach (ChartXYValue cv in chartval)
                {
                    _chartSd.Series[0].Points.AddXY(cv.XValue, cv.YValue);
                }
            }

        }

        private void StartTest()
        {
            // Calculate descriptive statistics
            double mean = _chartSd.DataManipulator.Statistics.Mean("Series1");
            double median = _chartSd.DataManipulator.Statistics.Median("Series1");
            double variance = _chartSd.DataManipulator.Statistics.Variance("Series1", true);

            // Set Strip line item
            _chartSd.ChartAreas[0].AxisY.StripLines[0].IntervalOffset = mean - Math.Sqrt(variance);
            _chartSd.ChartAreas[0].AxisY.StripLines[0].StripWidth = 2.0 * Math.Sqrt(variance);

            // Set Strip line item
            _chartSd.ChartAreas[0].AxisY.StripLines[1].IntervalOffset = mean;

            // Set Strip line item
            _chartSd.ChartAreas[0].AxisY.StripLines[2].IntervalOffset = median;

            // Refresh Chart
            _chartSd.Invalidate();
            OnStandardDivationChanged(new StandardDivationEventArgs(mean.ToString("G5"), Math.Sqrt(variance).ToString("G5"), median.ToString("G5")));
        }

        public bool HistoryDataExist(int proid)
        {

            DateTime lasthistorydate = new DateTime();
            DateTime startdate = _forecastInfo.StartDate;
            bool getHistory = false;
            IList<ForecastSiteProduct> historicalSiteProduct = null;
            IList<ForecastSiteTest> historicalSiteTest = null;
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                historicalSiteProduct =
           DataRepository.GetHistoricalProduct(_forecastInfo.Period, _forecastInfo.Methodology, _forecastInfo.DataUsage, proid, _activeFSite.Site.Id, _forecastInfo.StartDate, 0);
                _noOfHistData = historicalSiteProduct.Count;
            }
            else
            {
                historicalSiteTest = DataRepository.GetHistoricalTest(_forecastInfo.Period, _forecastInfo.Methodology, _forecastInfo.DataUsage, proid, _activeFSite.Site.Id, _forecastInfo.StartDate, 0);
                _noOfHistData = historicalSiteTest.Count;
            }
            TimeSpan diff = new TimeSpan();
            if (_noOfHistData > 0)
            {
                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                    lasthistorydate = historicalSiteProduct[0].DurationDateTime.Value;//sd
                else
                    lasthistorydate = historicalSiteTest[0].DurationDateTime.Value;

                diff = startdate.Subtract(lasthistorydate);

                if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                {
                    int noofemptyM = (((int)diff.TotalDays / 30) / 2) - 1;
                    if (noofemptyM >= 1)
                    {
                        if (_noOfPeriod > noofemptyM)
                        {
                            _noOfHistData = _noOfPeriod - noofemptyM;
                            _noOfPeriod = noofemptyM;
                            getHistory = true;
                        }
                        else
                        {
                            getHistory = false;
                        }
                    }
                    else
                    {
                        _noOfHistData = _noOfPeriod;
                        getHistory = true;
                        _noOfPeriod = 0;
                    }

                }
                else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                {
                    int noofemptyM = ((int)diff.TotalDays / 30) - 1;
                    if (noofemptyM >= 1)
                    {
                        if (_noOfPeriod > noofemptyM)
                        {
                            _noOfHistData = _noOfPeriod - noofemptyM;
                            _noOfPeriod = noofemptyM;
                            getHistory = true;
                        }
                        else
                        {
                            getHistory = false;
                        }
                    }
                    else
                    {
                        _noOfHistData = _noOfPeriod;
                        getHistory = true;
                        _noOfPeriod = 0;
                    }

                }
                else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                {
                    int noofemptyQ = (((int)diff.TotalDays / 30) / 3) - 1;
                    if (noofemptyQ >= 1)
                    {
                        if (_noOfPeriod > noofemptyQ)
                        {
                            _noOfHistData = _noOfPeriod - noofemptyQ;
                            _noOfPeriod = noofemptyQ;
                            getHistory = true;
                        }
                        else
                        {
                            getHistory = false;
                        }
                    }
                    else
                    {
                        noofemptyQ = _noOfPeriod;
                        _noOfHistData = _noOfPeriod;
                        getHistory = true;
                        _noOfPeriod = 0;
                    }
                }
                else
                {
                    int noofemptyY = ((int)diff.TotalDays / 365) - 1;
                    if (noofemptyY >= 1)
                    {
                        if (_noOfPeriod > noofemptyY)
                        {
                            _noOfHistData = _noOfPeriod - noofemptyY;
                            _noOfPeriod = noofemptyY;
                            getHistory = true;
                        }
                        else
                        {
                            getHistory = false;
                        }
                    }
                    else
                    {
                        _noOfHistData = _noOfPeriod;
                        getHistory = true;
                        _noOfPeriod = 0;

                    }
                }
            }
            else
            {
                getHistory = false;
            }
            return getHistory;

        }

        public void AddForecastProductHistory(int productid, int siteid, DateTime startdate)
        {
            IList<ForecastSiteProduct> historicalSiteProduct =
           DataRepository.GetHistoricalProduct(_forecastInfo.Period, _forecastInfo.Methodology, _forecastInfo.DataUsage, productid, siteid, startdate, _noOfHistData);
            MasterProduct product = DataRepository.GetProductById(productid);
            foreach (ForecastSiteProduct fst in historicalSiteProduct)
            {
                fst.Product = product;
                fst.ForecastSite = _activeFSite;

                _activeFSite.SiteProducts.Add(fst);

            }
            if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();
        }

        public void AddForecastTestHistory(int testid, int siteid, DateTime startdate)
        {
            IList<ForecastSiteTest> historicalSiteTest =
           DataRepository.GetHistoricalTest(_forecastInfo.Period, _forecastInfo.Methodology, _forecastInfo.DataUsage, testid, siteid, startdate, _noOfHistData);

            Test test = DataRepository.GetTestById(testid);

            foreach (ForecastSiteTest fst in historicalSiteTest)
            {
                fst.Test = test;
                fst.ForecastSite = _activeFSite;

                _activeFSite.SiteTests.Add(fst);

            }
            if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();
        }

        public bool AddDatausage()
        {
            IList<int> selectedIds = GetSelectedProOrTestId();
            if (selectedIds != null)
            {
                foreach (int proid in selectedIds)
                {
                    int year = _forecastInfo.StartDate.Year;
                    int quar = GetQuarter(_forecastInfo.StartDate);
                    DateTime lastd = _forecastInfo.StartDate;

                    MasterProduct product = null;
                    Test test = null;
                    if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                        product = DataRepository.GetProductById(proid);
                    else
                        test = DataRepository.GetTestById(proid);

                    //if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE1)
                    //{
                    //    if (HistoryDataExist(proid))
                    //    {
                    //        if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                    //            AddForecastProductHistory(proid, _activeFSite.Site.Id, _forecastInfo.StartDate);
                    //        else
                    //            AddForecastProductHistory(proid, _activeFSite.Site.Id, _forecastInfo.StartDate);
                    //    }
                    //}


                    for (int x = 1; x <= _noOfPeriod; x++)
                    {
                        IBaseDataUsage fc = GetNewDataUsage();
                        fc.Product = product;
                        fc.Test = test;
                        fc.AmountUsed = 1;
                        fc.Adjusted = 1;

                        if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                        {
                            lastd = lastd.AddMonths(-2);
                            fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);
                        }
                        else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                        {
                            lastd = lastd.AddMonths(-1);
                            fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);
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

                            fc.CDuration = String.Format("Qua{0}-{1}", quar, year);
                        }
                        else
                        {
                            year--;
                            fc.CDuration = year.ToString();
                        }

                        fc.DurationDateTime = LqtUtil.DurationToDateTime(fc.CDuration);
                        AddDataUsageToSiteOrCat(fc);

                        if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
                            AddProductToNReportedSite(_activeFSite.Id, fc);
                    }
                }
                if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                    _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();

                OnForecastInfoDataChanged();
                return true;
            }

            return false;
        }

        public bool CheckHistoryData(int proid, DateTime lastd)
        {
            bool getHistory = false;
            IList<ForecastSiteProduct> historicalSiteProduct = null;
            IList<ForecastSiteTest> historicalSiteTest = null;
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                historicalSiteProduct =
           DataRepository.GetHistoricalProduct(_forecastInfo.Period, _forecastInfo.Methodology, _forecastInfo.DataUsage, proid, _activeFSite.Site.Id, lastd, 0);
                _noOfHistData = historicalSiteProduct.Count;
            }
            else
            {
                historicalSiteTest = DataRepository.GetHistoricalTest(_forecastInfo.Period, _forecastInfo.Methodology, _forecastInfo.DataUsage, proid, _activeFSite.Site.Id, lastd, 0);
                _noOfHistData = historicalSiteTest.Count;
            }
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                if (historicalSiteProduct.Count > 0)
                {
                    if (historicalSiteProduct.Count >= _noOfPeriod)
                    {
                        _noOfHistData = _noOfPeriod;
                        _noOfPeriod = 0;
                        getHistory = true;
                    }
                    else
                    {
                        _noOfHistData = historicalSiteProduct.Count;
                        _noOfPeriod = _noOfPeriod - historicalSiteProduct.Count;
                        getHistory = true;
                    }
                }
                else
                {
                    _noOfHistData = 0;
                    getHistory = false;
                }
            }
            else
            {
                if (historicalSiteTest.Count > 0)
                {
                    if (historicalSiteTest.Count >= _noOfPeriod)
                    {
                        _noOfHistData = _noOfPeriod;
                        _noOfPeriod = 0;
                        getHistory = true;
                    }
                    else
                    {
                        _noOfHistData = historicalSiteTest.Count;
                        _noOfPeriod = _noOfPeriod - historicalSiteTest.Count;
                        getHistory = true;
                    }
                }
                else
                {
                    _noOfHistData = 0;
                    getHistory = false;

                }
            }
            return getHistory;
        }

        public bool AddDurationDatausage1()
        {
            LQTListViewTag tag = (LQTListViewTag)_lvHistData.SelectedItems[0].Tag;
            FrmReportedPeriod frm = new FrmReportedPeriod(_forecastInfo.StartDate);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                MasterProduct product = null;
                Test test = null;
                IList list = new ArrayList();

                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                        product = tag.Id > 0 ? _activeCategory.GetFCatProduct(tag.Id).Product : _activeCategory.CategoryProducts[tag.Index].Product;
                    else
                        product = tag.Id > 0 ? _activeFSite.GetSiteProduct(tag.Id).Product : _activeFSite.SiteProducts[tag.Index].Product;
                    list = GetListOfDataUsages(product.Id);
                }
                else
                {
                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                        test = tag.Id > 0 ? _activeCategory.GetFCatTest(tag.Id).Test : _activeCategory.CategoryTests[tag.Index].Test;
                    else
                        test = tag.Id > 0 ? _activeFSite.GetSiteTest(tag.Id).Test : _activeFSite.SiteTests[tag.Index].Test;
                    list = GetListOfDataUsages(test.Id);
                }

                int direction = frm.DataFlow() == "Down" ? -1 : 1;
                DateTime lastd = _forecastInfo.StartDate;

                if (list.Count > 0)
                {
                    if (direction == -1)
                        lastd = ((IBaseDataUsage)list[list.Count - 1]).DurationDateTime.Value;
                    else
                        lastd = ((IBaseDataUsage)list[0]).DurationDateTime.Value;
                }



                int year = lastd.Year;
                int quar = GetQuarter(lastd);

                _noOfPeriod = frm.NoPeriod;
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 && direction == -1)
                {
                    if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                    {
                        if (CheckHistoryData(product.Id, lastd))
                            AddForecastProductHistory(product.Id, _activeFSite.Site.Id, lastd);
                    }
                    else
                    {
                        if (CheckHistoryData(test.Id, lastd))
                            AddForecastProductHistory(product.Id, _activeFSite.Site.Id, lastd);
                    }
                }
                int len = list.Count + _noOfPeriod;

                if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                {
                    lastd = lastd.AddMonths(direction * _noOfHistData * 2);
                }
                else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                {
                    lastd = lastd.AddMonths(direction * _noOfHistData);
                }
                else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                {
                    for (int i = 0; i < _noOfHistData; i++)
                    {
                        // lastd = lastd.AddMonths(-3);
                    }
                }
                else
                {
                    lastd = lastd.AddYears(direction * _noOfHistData);
                }
                int count;
                int last;

                if (direction == -1)
                {
                    count = list.Count + _noOfHistData + 1;
                    last = len;
                }
                else
                {
                    count = 1;
                    last = frm.NoPeriod;
                }

                for (int i = count; i <= last; i++)
                {
                    IBaseDataUsage fc = GetNewDataUsage();
                    fc.Product = product;
                    fc.Test = test;
                    fc.AmountUsed = 1;
                    fc.Adjusted = 1;

                    if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
                    {
                        lastd = lastd.AddMonths(direction * 2);
                        fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);
                    }
                    else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                    {
                        lastd = lastd.AddMonths(direction * 1);
                        fc.CDuration = String.Format("{0}-{1}", LqtUtil.Months[lastd.Month - 1], lastd.Year);
                    }
                    else if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                    {
                        lastd = lastd.AddMonths(direction * 3);
                        if (direction == -1)
                        {
                            if (quar == 1)
                            {
                                quar = 4;
                                year--;
                            }
                            else
                                quar--;
                        }
                        else
                        {
                            if (quar == 4)
                            {
                                quar = 1;
                                year++;
                            }
                            else
                                quar++;
                        }
                        fc.CDuration = String.Format("Qua{0}-{1}", quar, year);
                    }
                    else
                    {
                        lastd = lastd.AddYears(direction * 1);
                        fc.CDuration = lastd.Year.ToString();
                    }
                    fc.DurationDateTime = LqtUtil.DurationToDateTime(fc.CDuration);
                    AddDataUsageToSiteOrCat(fc);
                }

                _lvHistData.ItemAreAddtogroup();

                if (_forecastInfo.StatusEnum == ForecastStatusEnum.CLOSED)
                    _forecastInfo.Status = ForecastStatusEnum.REOPEN.ToString();
                OnForecastInfoDataChanged();
                return true;
            }
            return false;
        }

    }

    public class StandardDivationEventArgs : EventArgs
    {
        string _mean;
        string _deviation;
        string _median;

        public StandardDivationEventArgs(string mean, string dev, string median)
        {
            _mean = mean;
            _deviation = dev;
            _median = median;
        }

        public string Mean
        {
            get { return _mean; }
        }
        public string Deviation
        {
            get { return _deviation; }
        }
        public string Median
        {
            get { return _median; }
        }
    }
}
