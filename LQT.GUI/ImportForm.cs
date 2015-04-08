
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
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;
using LQT.GUI.UserCtr;


namespace LQT.GUI
{
    public partial class ImportForm : Form
    {
        private ForecastInfo _forecastInfo;
        private IList<ReportedData> _rdata;

        public ForecastInfo GetForecastInfo
        {
            get { return _forecastInfo; }
        }

        public ImportForm(ForecastInfo finfo)
        {
            this._forecastInfo = finfo;
            InitializeComponent();

            txtForecastid.Text = _forecastInfo.ForecastNo;
            txtPeriod.Text = _forecastInfo.Period;
            txtSdate.Text = _forecastInfo.StartDate.ToShortDateString();
            txtExtension.Text = _forecastInfo.Extension.ToString();
            txtMethodology.Text = _forecastInfo.Methodology;
            txtDusage.Text = _forecastInfo.DataUsage;
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
            catch
            {
                //ShowError(ex.Message);
                //return;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return ds;
        }

        private IList<ReportedData> GetDataRow(DataSet ds)
        {
            //ArrayList errorList = new ArrayList();
            //int count = 0;

            //try
            //{
                string regionName;
                string siteName;
                string productName;
                string duration;
                decimal amount;
                int stockout;
                int instrumentDownTime;//b
                decimal adjusited;
                int rowno = 0;
                bool haserror;
                string rName = "";
                string sName = "";
                string pName = "";
                ForlabRegion region = null;
                ForlabSite site = null;
                MasterProduct product = null;

                IList<ReportedData> rdlist = new List<ReportedData>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    rowno++;
                    haserror = false;
                    regionName = Convert.ToString(dr[0]); //region name
                    siteName = Convert.ToString(dr[1]);           //site name
                    productName = Convert.ToString(dr[2]);   //product name
                    duration = Convert.ToString(dr[3]); // reporting period(duration)

                    try
                    {
                        amount = Convert.ToDecimal(dr[4]);  //amount
                    }
                    catch
                    {
                        haserror = true;
                        amount = 0;
                    }
                    try
                    {
                        stockout = Convert.ToInt32(dr[5]);     //stock out
                    }
                    catch
                    {
                        haserror = true;
                        stockout = 0;
                    }
                    try
                    {
                        instrumentDownTime = Convert.ToInt32(dr[6]);     //instrumentDownTime
                    }
                    catch
                    {
                        haserror = true;
                        instrumentDownTime = 0;
                    }
                    try
                    {
                        adjusited = Convert.ToDecimal(dr[7]);     //adjusted
                    }
                    catch
                    {
                        haserror = true;
                        adjusited = 0;
                    }

                    ReportedData rd = new ReportedData(rowno, regionName, siteName, productName, duration, amount, stockout,instrumentDownTime);
                    
                    if ( rName != regionName)
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
                            haserror = true;
                    }
                    else
                        haserror = true;
                    
                    if (pName != productName)
                    {
                        if (!string.IsNullOrEmpty(productName))
                            product = DataRepository.GetProductByName(productName);
                        else
                            product = null;
                        pName = productName;
                    }

                    if (product != null)
                        rd.Product = product;
                    else
                        haserror = true;
                    rd.HasError = haserror;
                    rdlist.Add(rd);
                }

            //}
            //catch (Exception ex)
            //{
            //    //ShowError(ex.Message);
            //}
                return rdlist;
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilename.Text.Trim()))
                return;

            DataSet ds = ReadExcelFile(txtFilename.Text);
            _rdata = GetDataRow(ds);
            bool haserror = false;
            lvImport.BeginUpdate();
            lvImport.Items.Clear();
            
            foreach (ReportedData rd in _rdata)
            {
                ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                li.SubItems.Add(rd.RegionName);
                li.SubItems.Add(rd.SiteName);
                li.SubItems.Add(rd.ProductName);
                li.SubItems.Add(rd.Duration);
                li.SubItems.Add(rd.Amount.ToString());
                li.SubItems.Add(rd.StockOut.ToString());
                li.SubItems.Add(rd.InstrumentDownTime.ToString());//b
               // li.SubItems.Add(rd.Adjusted.ToString());
                
                if (rd.HasError)
                {
                    li.BackColor = Color.Cyan;
                    haserror = true;
                }
                lvImport.Items.Add(li);
            }
            
            lvImport.EndUpdate();

            butClear.Enabled = true;
            if (!haserror)
                butSave.Enabled = true;
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
            foreach (ReportedData rd in _rdata)
            {
                ForecastSiteProduct fp = new ForecastSiteProduct();
                ForecastSite fs = _forecastInfo.GetForecastSiteBySiteId(rd.Site.Id);
                if (fs == null)
                {
                    fs = new ForecastSite();
                    fs.Site = rd.Site;
                    fs.ForecastInfo = _forecastInfo;
                    _forecastInfo.ForecastSites.Add(fs);
                }
                fp.ForecastSite = fs;
                fp.Product = rd.Product;
                fp.CDuration = rd.Duration;
                fp.AmountUsed = rd.Amount;
                fp.StockOut = rd.StockOut;
                fp.InstrumentDowntime = rd.InstrumentDownTime;//b
                fp.Adjusted = rd.Amount; //b

                fs.SiteProducts.Add(fp);
            }
            try
            {
                DataRepository.SaveOrUpdateForecastInfo(_forecastInfo);
                MessageBox.Show("Consumption data imported and saved successfully.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error: Unable to imported and saved consumption data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

    }

}
