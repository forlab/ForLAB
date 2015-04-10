
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
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;
using LQT.GUI.UserCtr;
using System.Collections;

namespace LQT.GUI
{
    public partial class ImportSerForm : Form
    {
        private ForecastInfo _forecastInfo;
        private IList<ReportedData> _rdata;
        private int _noColumn;
        private int _error = 0;
        private int _count = 0;


        public ForecastInfo GetForecastInfo
        {
            get { return _forecastInfo; }
        }

        public ImportSerForm(ForecastInfo finfo)
        {
            this._forecastInfo = finfo;
            InitializeComponent();

            txtForecastid.Text = _forecastInfo.ForecastNo;
            txtPeriod.Text = _forecastInfo.Period;
            txtSdate.Text = _forecastInfo.StartDate.ToShortDateString();
            txtExtension.Text = _forecastInfo.Extension.ToString();
            txtMethodology.Text = _forecastInfo.Methodology;
            txtDusage.Text = _forecastInfo.DataUsage;

            if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
            {
                lvImport.Columns.Remove(lvImport.Columns[2]);
                lvImport.Columns.Remove(lvImport.Columns[2]);

                _noColumn = 6;
            }
            else
            {
                lvImport.Columns.Remove(lvImport.Columns[1]);
                _noColumn = 7;
            }
        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtFilename.Text = openFileDialog1.FileName;
            }
        }

        private DataSet ReadExcelFile(string fpath)
        {
            string connectionString = String.Format(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;""", fpath);

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DbDataAdapter adapter = factory.CreateDataAdapter();
            DbCommand selectCommand = factory.CreateCommand();
            selectCommand.CommandText = "Select * From [Sheet1$]";
            DbConnection connection = factory.CreateConnection();
            DataSet ds = new DataSet();

            try
            {
                connection.ConnectionString = connectionString;
                selectCommand.Connection = connection;
                adapter.SelectCommand = selectCommand;
                adapter.Fill(ds, "Consumption");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            int colcount = ds.Tables[0].Columns.Count;

            if (_noColumn > colcount)
                throw new Exception("Imported excel file has less column.");
            if (_noColumn < colcount)
                throw new Exception("Imported excel file have to many column.");
            if (ds.Tables[0].Rows.Count == 0)
                throw new Exception("Imported excel is empty.");
            return ds;
        }

        private IList<ReportedData> GetDataRow(DataSet ds)
        {
            string categoryName = null;
            string regionName;
            string siteName;
            string testName;
            string duration;
            decimal amount;
            int stockout;
            int instrumentDownTime;
            decimal adjusited;
            int rowno = 0;
            bool haserror;
            string cName = "";
            string rName = "";
            string sName = "";
            string tName = "";

            ForecastCategory fcategory = null;
            ForlabRegion region = null;
            ForlabSite site = null;
            //MasterProduct product = null;
            Test test = null;
            string errorDescription = "";
            IList<ReportedData> rdlist = new List<ReportedData>();
            DataRow dr = ds.Tables[0].Rows[0];

            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            for (int i = 1; i < ds.Tables[0].Rows.Count; i = i + 4)
            {
                rowno++;
                haserror = false;
                DataRow dr1 = ds.Tables[0].Rows[i];
                DataRow dr2 = ds.Tables[0].Rows[i + 1];
                DataRow dr3 = ds.Tables[0].Rows[i + 2];
                DataRow dr4 = ds.Tables[0].Rows[i + 3];
                DataRow g = ds.Tables[0].Rows[0];
               // int colid = 0;
                 int f = 3;
                int colid  ;//0 
                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    colid=3;
                else
                    colid=4;
                do
                {
                regionName = "";
                siteName = "";

                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                {
                    categoryName = Convert.ToString(dr1[0]).Trim();//(dr[colid++])
                      testName  = Convert.ToString(dr1[1]).Trim();   //(dr[colid++])testName
                }
                else
                {
                       regionName = Convert.ToString(dr1[0]).Trim(); //(dr[colid++]) region name
                        siteName = Convert.ToString(dr1[1]).Trim();           //(dr[colid++]) site name
                        testName  = Convert.ToString(dr1[2]).Trim();   //(dr[colid++])testName 
                 }


                if (_forecastInfo.PeriodEnum != ForecastPeriodEnum.Monthly || _forecastInfo.PeriodEnum != ForecastPeriodEnum.Bimonthly)
                    duration = Convert.ToString(DateTime.FromOADate(Convert.ToDouble(dr[colid])));//(g[f]) Convert.ToString(dr[colid++]); //  reporting period(duration)
                // f = f + 3;
                else
                    duration = Convert.ToString(dr[colid]);
                    
                //duration = Convert.ToString(dr[colid++]); // reporting period(duration)

                try
                {
                    if (dr1[colid].ToString() == string.Empty)
                        amount = 0;
                    else
                        amount = Convert.ToDecimal(dr1[colid]);  //amount
                     ///if (amount == 0)
                       //  haserror = true;
                }
                catch
                {
                    haserror = true;
                    amount = 0;
                }
                try
                {
                    if (dr2[colid].ToString() == string.Empty)
                        stockout = 0;
                    else
                        stockout = Convert.ToInt32(dr2[colid]);     //stock out
                }
                catch
                {
                    haserror = true;
                    stockout = 0;
                }
                try
                {
                    if (dr3[colid].ToString() == string.Empty)
                        instrumentDownTime = 0;
                    else
                        instrumentDownTime = Convert.ToInt32(dr3[colid]);     //instrumentDownTime
                }
                catch
                {
                    haserror = true;
                    instrumentDownTime = 0;
                }
                //try
                //{
                //    adjusited = Convert.ToDecimal(dr[colid++]);     //adjusted
                //}
                //catch
                //{
                //    haserror = true;
                    adjusited = 0;
               // }

                ReportedData rd = null;

                if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                {
                    rd = new ReportedData(categoryName,rowno, testName, duration, amount,stockout,instrumentDownTime);
                    if (cName != categoryName)
                    {
                        if (!string.IsNullOrEmpty(categoryName))
                        {
                            fcategory = DataRepository.GetForecastCategoryByName(_forecastInfo.Id, categoryName);
                        }
                        else
                            fcategory = null;
                        cName = categoryName;
                    }

                    if (fcategory != null)
                        rd.Category = fcategory;
                    else
                    {
                        rd.HasError = true;
                        errorDescription = errorDescription + " Category Doesn't Exist";
                    }
                }
                else
                {
                    rd = new ReportedData( regionName,rowno, siteName, testName, duration, amount, stockout, instrumentDownTime);

                    if (rName != regionName)
                    {
                        if (!string.IsNullOrEmpty(regionName))
                            region = DataRepository.GetRegionByName(regionName);
                        else
                            region = null;
                        rName = regionName;
                    }

                    if (region != null)
                    {
                        rd.Region = region;
                        if (sName != siteName)
                        {
                            if (!string.IsNullOrEmpty(siteName))
                                site = DataRepository.GetSiteByName(siteName, region.Id);
                            else
                                site = null;
                            sName = siteName;
                        }
                        if (site != null)
                            rd.Site = site;
                        else
                        {
                            haserror = true;
                            errorDescription = errorDescription + " Site Doesn't Exist";
                        }
                    }
                    else
                    {
                        haserror = true;
                        errorDescription = errorDescription + " Region Doesn't Exist";
                    }
                }

               

                      if (tName != testName)
                        {
                            if (!string.IsNullOrEmpty(testName))
                                test = DataRepository.GetTestByName(testName);
                            else
                                test = null;
                            tName = testName;
                        }

                      if (test != null)
                          rd.Test = test;
                      else
                      {
                          haserror = true;
                          errorDescription = errorDescription + " Test Doesn't Exist";
                      }
                   

                rd.HasError = haserror;
                rd.ErrorDescription = errorDescription;
                rdlist.Add(rd);
                colid++;
                errorDescription = "";
                }
                while (colid < g.ItemArray.Length && g[colid].ToString() != "");// dr.ItemArray.Length / ds.Tables[0].Rows.Count);
        
            }

            return rdlist;
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilename.Text.Trim()))
                return;
            try
            {
                DataSet ds = LqtUtil.ReadExcelFileforecast(txtFilename.Text, _noColumn);

                _rdata = GetDataRow(ds);
                bool haserror = false;

                lvImport.BeginUpdate();
                lvImport.Items.Clear();

                ForecastSite fs = new ForecastSite();
                ForecastCategorySite fcatsite = new ForecastCategorySite();

                bool isduplicate = false;
                ForecastSite efs = new ForecastSite();//existing
                IList<ForecastSiteTest> existingFst = new List<ForecastSiteTest>();
                foreach (ForecastSite efss in _forecastInfo.ForecastSites)
                {
                    foreach (ForecastSiteTest efst in efss.SiteTests)
                        existingFst.Add(efst);
                }

                foreach (ReportedData rd in _rdata)
                {
                    ListViewItem li = new ListViewItem(rd.RowNo.ToString());

                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    {
                        li.SubItems.Add(rd.CategoryName);
                    }
                    else
                    {
                        li.SubItems.Add(rd.RegionName);
                        li.SubItems.Add(rd.SiteName);
                    }

                    li.SubItems.Add(rd.TestName);
                  
                    if (!LqtUtil.IsDateTime(rd.Duration))
                    {
                        try
                        {
                            DateTime dd = LqtUtil.DurationToDateTime(rd.Duration);
                            if (rd.Duration.StartsWith("Q") && (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Yearly))
                            {

                                rd.Duration = dd.Year.ToString();
                                li.SubItems.Add(LqtUtil.DatetimeToDurationStr(_forecastInfo.PeriodEnum, dd));
                            }
                            else
                                li.SubItems.Add(rd.Duration);
                        }
                        catch
                        {
                            li.SubItems.Add(rd.Duration);
                            rd.HasError = true;
                        }
                    }
                    else
                    {
                        string datestr = LqtUtil.DatetimeToDurationStr(_forecastInfo.PeriodEnum, DateTime.Parse(rd.Duration));
                        if (!rd.Duration.StartsWith("Q"))
                        {
                            rd.Duration = LqtUtil.DatetimeToDurationStr(_forecastInfo.PeriodEnum, DateTime.Parse(rd.Duration));
                            if (_forecastInfo.PeriodEnum == ForecastPeriodEnum.Yearly)
                            {
                                li.SubItems.Add(datestr);

                            }
                            else
                            {
                                li.SubItems.Add(rd.Duration);

                            }
                        }
                        else
                        {
                            {
                                li.SubItems.Add(datestr);

                            }


                        }
                    }
                    li.SubItems.Add(rd.Amount.ToString());
                    li.SubItems.Add(rd.StockOut.ToString());
                    li.SubItems.Add(rd.InstrumentDownTime.ToString());
                    if (rd.HasError == true && rd.ErrorDescription == "")
                        rd.ErrorDescription = " Test Performed Required ";
                   
                    if (LqtUtil.validDate(rd.Duration, _forecastInfo.PeriodEnum))
                        rd.HasError = true;

                    //check if stockout and instrument downtime is less than site working days
                    try
                    {
                        if(rd.Site!=null)
                        if (!LqtUtil.ValidDownTime(rd.StockOut + rd.InstrumentDownTime, _forecastInfo.PeriodEnum, rd.Site.WorkingDays))
                        {
                            rd.HasError = true;
                            rd.ErrorDescription += " Sum of Stockout and Instrument Downtime can not be greater than site working days";
                        }
                    }
                    catch
                    {
                    }
                    li.SubItems.Add(rd.ErrorDescription.ToString());
                    //add to forecast site test
                    if (!rd.HasError && _forecastInfo.DatausageEnum != DataUsageEnum.DATA_USAGE3)
                    {

                        ForecastSiteTest ft = new ForecastSiteTest();
                        fs = _forecastInfo.GetForecastSiteBySiteId(rd.Site.Id);

                        if (fs == null)
                        {
                            fs = new ForecastSite();
                            fs.Site = rd.Site;
                            fs.ForecastInfo = _forecastInfo;
                            _forecastInfo.ForecastSites.Add(fs);
                        }
                        ft.ForecastSite = fs;
                        ft.Test = rd.Test;
                        if (!LqtUtil.IsDateTime(rd.Duration))
                        {
                            ft.CDuration = rd.Duration;
                            ft.DurationDateTime = LqtUtil.DurationToDateTime(rd.Duration);
                        }
                        else
                        {
                            ft.CDuration = LqtUtil.DatetimeToDurationStr(_forecastInfo.PeriodEnum, DateTime.Parse(rd.Duration));
                            ft.DurationDateTime = DateTime.Parse(rd.Duration);
                        }
                        ft.AmountUsed = rd.Amount;
                        ft.StockOut = rd.StockOut;
                        ft.InstrumentDowntime = rd.InstrumentDownTime;//b
                        ft.Adjusted = rd.Amount;
                  
                        if (ft.StockOut > 0)
                        {
                            int days = ft.StockOut;
                            decimal workingday = GetActiveSiteWorkingDays(ft);

                            if (days >= workingday)
                            {
                                days = 0;
                                ft.StockOut = 0;
                            }
                            if (days >= 0)
                                ft.StockOut = days;
                        }
                        foreach (ForecastSiteTest efst in existingFst)
                        {
                            isduplicate = false;
                            if (ft.ForecastSite.Site.Region == efst.ForecastSite.Site.Region)
                                if (ft.ForecastSite.Site == efst.ForecastSite.Site)
                                    if (ft.Test == efst.Test && ft.DurationDateTime == efst.DurationDateTime)
                                    { isduplicate = true; break; }
                        }
                        foreach (ForecastSiteTest fst in fs.SiteTests)
                        {
                            isduplicate = false;
                            if (ft.ForecastSite.Site.Region == fst.ForecastSite.Site.Region)
                                if (ft.ForecastSite.Site == fst.ForecastSite.Site)
                                    if (ft.Test == fst.Test && ft.DurationDateTime == fst.DurationDateTime)
                                    { isduplicate = true; break; }
                        }
                        if (!isduplicate)
                            fs.SiteTests.Add(ft);
                    }
                    //end adding

                    //add by category
                    if (!rd.HasError && _forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                    {
                        ForecastCategory fcat = new ForecastCategory();
                        ForecastCategoryTest ft = new ForecastCategoryTest();
                       // fcat = DataRepository.GetForecastCategoryByName(_forecastInfo.Id, rd.CategoryName);
                        fcat = _forecastInfo.GetForecastCategorybyname(rd.CategoryName);
                        if (fcat == null)
                        {
                            fcat = new ForecastCategory();
                            fcat.CategoryName = rd.CategoryName;
                            fcat.ForecastInfo = _forecastInfo;
                            _forecastInfo.ForecastCategories.Add(fcat);
                        }

                         ft = fcat.GetFCatTest(rd.Test.Id, rd.Duration);
                        isduplicate = false;

                        if (ft == null)
                            ft = new ForecastCategoryTest();
                        else
                            isduplicate = true;

                        ft.Category = fcat;
                        ft.Test = rd.Test;
                    //    ft.CDuration = rd.Duration;
                        ft.AmountUsed = rd.Amount;
                        ft.StockOut = rd.StockOut;
                        ft.InstrumentDowntime = rd.InstrumentDownTime;//b
                       // ft.Adjusted = rd.Adjusted;
                    //    ft.DurationDateTime = LqtUtil.DurationToDateTime(ft.CDuration);
                        if (!LqtUtil.IsDateTime(rd.Duration))
                        {
                            ft.CDuration = rd.Duration;
                            ft.DurationDateTime = LqtUtil.DurationToDateTime(rd.Duration);
                        }
                        else
                        {
                            ft.CDuration = LqtUtil.DatetimeToDurationStr(_forecastInfo.PeriodEnum, DateTime.Parse(rd.Duration));
                            ft.DurationDateTime = DateTime.Parse(rd.Duration);
                        }
                       
                        if (ft.StockOut > 0)
                        {
                            int days = ft.StockOut;
                            decimal workingday = 22;

                            if (days >= workingday)
                            {
                                days = 0;
                                ft.StockOut = 0;
                            }
                            if (days >= 0)
                                ft.StockOut = days;
                        }

                        
                        if (!isduplicate)
                            fcat.CategoryTests.Add(ft);

                    }
                    //end category adding

                    if (rd.HasError)
                    {
                        li.BackColor = Color.Red;
                        _error++;
                    }
                    else if (isduplicate)
                    {
                        li.BackColor = Color.Yellow;
                        _error++;
                    }
                    else
                    {
                        _count++;
                    }

                    lvImport.Items.Add(li);
                }
                sort();
                lvImport.EndUpdate();

                butClear.Enabled = true;
                butSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            lvImport.BeginUpdate();
            lvImport.Items.Clear();
            lvImport.EndUpdate();
            butSave.Enabled = false;
            butClear.Enabled = false;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            //if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
            //    SaveAsCategory();
            //else
            //    SaveAsSite();

            try
            {
                try
                {
                    UpdateAdjustment();
                }
                catch
                {
                    MessageBox.Show("Error: Sum of Stockout and Instrument Downtime can not be greater than site working days .", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataRepository.SaveOrUpdateForecastInfo(_forecastInfo);
                MessageBox.Show(_count + " Service data imported and saved successfully." + Environment.NewLine + _error + " Failed", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error: Unable to import and save service data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void UpdateAdjustment()
        {
            if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
            {
                foreach (ForecastSite fs in _forecastInfo.ForecastSites)
                {
                    foreach (ForecastSiteTest ft in fs.SiteTests)
                    {
                        ft.Adjusted = ft.AmountUsed;
                        if (ft.AmountUsed == 0)
                        {
                            try
                            {
                                Consumption cs = GetConsumption(ft.Test.Id, ft);
                                ft.Adjusted = Math.Round(cs.TotalConsumption / cs.NoConsumption, 2, MidpointRounding.ToEven);
                            }
                            catch 
                            { 
                                ft.Adjusted = ft.AmountUsed; 
                            }
                        }
                        if ((ft.InstrumentDowntime > 0 || ft.StockOut > 0) && ft.AmountUsed > 0)
                        {
                                ft.Adjusted = LqtUtil.GetAdjustedVolume(ft.AmountUsed, ft.StockOut + ft.InstrumentDowntime, _forecastInfo.PeriodEnum, GetActiveSiteWorkingDays(ft));//b
                            
                        }
                    }
                }
            }
            else
            {
                foreach (ForecastCategory fc in _forecastInfo.ForecastCategories)
                {
                    foreach (ForecastCategoryTest ft in fc.CategoryTests)
                    {
                        ft.Adjusted = ft.AmountUsed;
                        if (ft.AmountUsed == 0)
                        {
                            try
                            {
                                Consumption cs = GetConsumption(ft.Product.Id, ft);
                                ft.Adjusted = Math.Round(cs.TotalConsumption / cs.NoConsumption, 2, MidpointRounding.ToEven);
                            }
                            catch { ft.Adjusted = ft.AmountUsed; }
                        }
                        if ((ft.InstrumentDowntime > 0 || ft.StockOut > 0) && ft.AmountUsed > 0)
                            ft.Adjusted = LqtUtil.GetAdjustedVolume(ft.AmountUsed, ft.StockOut + ft.InstrumentDowntime, _forecastInfo.PeriodEnum, 22);//b
                    }
                }
            }

        }
        
        private void SaveAsSite()
        {
            bool isduplicate = false;
            ForecastSite fs =new ForecastSite();
            IList<ForecastSiteTest> exsistingFst = new List<ForecastSiteTest>();
            foreach (ForecastSite efs in _forecastInfo.ForecastSites)
            {
                foreach (ForecastSiteTest efst in efs.SiteTests)
                    exsistingFst.Add(efst);
            }
            foreach (ReportedData rd in _rdata)
            {
                if (!rd.HasError)
                {
                    ForecastSiteTest ft = new ForecastSiteTest();
                    fs = _forecastInfo.GetForecastSiteBySiteId(rd.Site.Id);

                    if (fs == null)
                    {
                        fs = new ForecastSite();
                        fs.Site = rd.Site;
                        fs.ForecastInfo = _forecastInfo;
                        _forecastInfo.ForecastSites.Add(fs);
                    }

                    ft.ForecastSite = fs;
                    ft.Test = rd.Test;
                    ft.CDuration = rd.Duration;
                    ft.AmountUsed = rd.Amount;
                    ft.StockOut = rd.StockOut;
                    ft.InstrumentDowntime = rd.InstrumentDownTime;//b
                    ft.Adjusted = rd.Amount;//b rd.Adjusted;
                    ft.DurationDateTime = LqtUtil.DurationToDateTime(ft.CDuration);
                    fs.SiteTests.Add(ft);
                    if (ft.AmountUsed == 0)
                    {
                        Consumption cs = GetConsumption(ft.Test.Id, ft);
                        if(cs.NoConsumption!=0)
                        ft.Adjusted = Math.Round(cs.TotalConsumption / cs.NoConsumption, 2, MidpointRounding.ToEven);
                    }
                    if (ft.StockOut > 0)
                    {
                        int days = ft.StockOut;
                        decimal workingday = GetActiveSiteWorkingDays(ft);

                        if (days >= workingday)
                        {
                            days = 0;
                            ft.StockOut = 0;
                        }
                        if (days >= 0)
                            ft.StockOut = days;
                    }

                    if ((ft.InstrumentDowntime > 0 || ft.StockOut > 0) && ft.AmountUsed > 0)
                        ft.Adjusted = LqtUtil.GetAdjustedVolume(ft.AmountUsed, ft.StockOut + ft.InstrumentDowntime, _forecastInfo.PeriodEnum, GetActiveSiteWorkingDays(ft));
                    foreach (ForecastSiteTest efst in exsistingFst)
                    {
                        isduplicate = false;
                        if (ft.ForecastSite.Site.Region == efst.ForecastSite.Site.Region)
                            if (ft.ForecastSite.Site == efst.ForecastSite.Site)
                                if (ft.Test == efst.Test && ft.DurationDateTime == efst.DurationDateTime)
                                { isduplicate = true; break; }
                    }
                    foreach (ForecastSiteTest fst in fs.SiteTests)
                    {
                        isduplicate = false;
                        if (ft.ForecastSite.Site.Region == fst.ForecastSite.Site.Region)
                            if (ft.ForecastSite.Site == fst.ForecastSite.Site)
                                if (ft.Test == fst.Test && ft.DurationDateTime == fst.DurationDateTime)
                                { isduplicate = true; break; }
                    }
                    if (!isduplicate)
                        fs.SiteTests.Add(ft);
                }
            }
        }

        public Consumption GetConsumption(int id, ForecastSiteTest fp)
        {
            Consumption con = null;
            switch (_forecastInfo.DatausageEnum)
            {
                case DataUsageEnum.DATA_USAGE1:
                case DataUsageEnum.DATA_USAGE2:
                    con = fp.ForecastSite.ConsumptionByTest(id);
                    break;
                case DataUsageEnum.DATA_USAGE3:
                    con = fp.ForecastSite.ConsumptionByTest(id);
                    break;
            }
            return con;
        }
       
        public Consumption GetConsumption(int id, ForecastCategoryTest ft)
        {
            Consumption con = null;
            switch (_forecastInfo.DatausageEnum)
            {
                case DataUsageEnum.DATA_USAGE1:
                case DataUsageEnum.DATA_USAGE2:
                    con = ft.Category.ConsumptionByTest(id);
                    break;
                case DataUsageEnum.DATA_USAGE3:
                    con = ft.Category.ConsumptionByTest(id);
                    break;
            }
            return con;
        }

        public decimal GetActiveSiteWorkingDays(ForecastSiteTest fp)
        {
            decimal workingday = 22;

            switch (_forecastInfo.DatausageEnum)
            {
                case DataUsageEnum.DATA_USAGE1:
                case DataUsageEnum.DATA_USAGE2:
                    workingday = fp.ForecastSite.Site.WorkingDays;
                    break;
            }
            return workingday;
        }

        private void SaveAsCategory()
        {

            foreach (ReportedData rd in _rdata)
            {
                ForecastCategory fcat = rd.Category;

                if (fcat == null)
                {
                    fcat = new ForecastCategory();
                    fcat.CategoryName = rd.CategoryName;
                    fcat.ForecastInfo = _forecastInfo;
                    _forecastInfo.ForecastCategories.Add(fcat);
                }

                ForecastCategoryTest fp = fcat.GetFCatTest(rd.Test.Id, rd.Duration);

                if (fp == null)
                    fp = new ForecastCategoryTest();

                fp.Category = fcat;
                fp.Test = rd.Test;
                fp.CDuration = rd.Duration;
                fp.AmountUsed = rd.Amount;
                fp.StockOut = rd.StockOut;
                fp.InstrumentDowntime = rd.InstrumentDownTime;//b
                fp.Adjusted = rd.Amount;//b rd.Adjusted;
                fp.DurationDateTime = LqtUtil.DurationToDateTime(fp.CDuration);

                fcat.CategoryTests.Add(fp);
            }     
          
        }
        private void sort() // private void lvImport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnClickEventArgs e = new ColumnClickEventArgs(8);
            // Create an instance of the ColHeader class.
            // ColHeader clickedCol = (ColHeader)this.lvImport.Columns[e.Column];
            //  ColumnHeader clickedCol = (ColumnHeader)this.lvImport.Columns[e.Column];
            // Set the ascending property to sort in the opposite order.
            //  clickedCol.ascending = !clickedCol.ascending;

            // Get the number of items in the list.
            int numItems = this.lvImport.Items.Count;

            // Turn off display while data is repoplulated.
            this.lvImport.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(this.lvImport.Items[i], e.Column));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.

            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(false));//(clickedCol.ascending));

            // Clear the list, and repopulate with the sorted items.
            this.lvImport.Items.Clear();
            for (int i = 0; i < numItems; i++)
                this.lvImport.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            this.lvImport.EndUpdate();

        }
    }
}
