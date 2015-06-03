
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
using LQT.Core.Util;
using System.Collections;

namespace LQT.GUI.Location
{
    public partial class FrmImportSite : Form
    {
        private IList<SiteImportData> _rdata;
        private int _tabid = -1;

        public FrmImportSite()
        {
            InitializeComponent();
        }

        public FrmImportSite(int tabid)
        {
            this._tabid = tabid;
            InitializeComponent();

            tabSite.SelectedIndex = _tabid;


        }

        private void butBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtFilename.Text = openFileDialog1.FileName;
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilename.Text.Trim()))
                return;
            try
            {
                DataSet ds = LqtUtil.ReadExcelFile(txtFilename.Text, 11);

                _rdata = GetDataRow(ds);
                bool haserror = false;

                lvImport.BeginUpdate();
                lvImport.Items.Clear();
                string errorString;
                foreach (SiteImportData rd in _rdata)
                {
                    string str;
                    errorString = "";
                    ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                    li.SubItems.Add(rd.RegionName);
                    li.SubItems.Add(rd.CategoryName);
                    li.SubItems.Add(rd.SiteName);
                    li.SubItems.Add(rd.SiteLevel);
                    li.SubItems.Add(rd.WorkingDays.ToString());
                    li.SubItems.Add(rd.Cd4Td.ToString());
                    li.SubItems.Add(rd.ChemTd.ToString());
                    li.SubItems.Add(rd.HemaTd.ToString());
                    li.SubItems.Add(rd.ViralTd.ToString());
                    li.SubItems.Add(rd.OtherTd.ToString()); 
                    str = rd.OpeningDate != null ? rd.OpeningDate.Value.ToShortDateString() : "";
                    li.SubItems.Add(str);
                    str = rd.IsExist ? "Yes" : "No";


                    foreach (ListViewItem Item in lvImport.Items)
                    {
                        if (Item.SubItems[1].Text.Trim().ToLower() == rd.RegionName.Trim().ToLower() && Item.SubItems[3].Text.Trim().ToLower() == rd.SiteName.Trim().ToLower())
                        {
                            rd.IsExist = true;
                            str = "Duplicated";
                        }

                    }
                    li.SubItems.Add(str);
                    if (rd.HasError)
                    {
                        if (rd.RegionName == "")
                            errorString = errorString + " Region Name Required";//14 may 14
                        if (rd.SiteName == "")
                            errorString = errorString + " Site Name Required";
                        if (rd.CategoryName == "")
                            errorString = errorString + " Category Name Required";
                        if (rd.SiteLevel == "")
                            errorString = errorString + " Site Level Required";
                        
                        if (rd.Region == null)
                            errorString = errorString + " Region Doesn't Exist";
                        
                        rd.ErrorDescription = rd.ErrorDescription + errorString;
                        li.BackColor = Color.Red;
                        haserror = true;
                    }
                    if (rd.IsExist)
                    {
                        li.BackColor = Color.Yellow;
                    }
                    li.SubItems.Add(rd.ErrorDescription);
                    lvImport.Items.Add(li);
                }
                sort();
                lvImport.EndUpdate();

                butClear.Enabled = true;
                //  if (!haserror)//b jul 2
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
            _rdata = new List<SiteImportData>();
            butSave.Enabled = false;
            butClear.Enabled = false;
        }

       
        private IList<SiteImportData> GetDataRow(DataSet ds)
        {
            string regionName;
            string categoryName;
            string siteName;
            string siteLevel;
            DateTime? openDate;
            string rName = "";
            ForlabRegion region = null;
            string cName = "";
            SiteCategory siteCategory = null;
            int workingDays;


            int Cd4Td;
            int ChemTd;
            int hemaTd;
            int ViralTd;
            int OtherTd;

            int rowno = 0;
            bool haserror;
            IList<SiteImportData> rdlist = new List<SiteImportData>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string errorDescription = "";
                rowno++;
                haserror = false;
                regionName = Convert.ToString(dr[0]).Trim();   //region name
                categoryName = Convert.ToString(dr[1]).Trim();   //site category name
                siteName = Convert.ToString(dr[2]).Trim();   //short name
                siteLevel = Convert.ToString(dr[3]);//Site Level 
                try
                {
                    workingDays = int.Parse(Convert.ToString(dr[4]));
                    if (workingDays > 31)
                    {
                        haserror = true;
                        errorDescription = errorDescription + " Working Days Can't Be More Than 31 Days";
                    }
                }
                catch
                {
                    workingDays = 22;
                }
                try
                {
                    Cd4Td = int.Parse(Convert.ToString(dr[5]));
                    if (Cd4Td > 31 || Cd4Td > workingDays)
                    {
                        haserror = true;
                        errorDescription = errorDescription + " CD4 Testing Days Can't Be More Than 31 Days or Working Days";//14 may 14
                    }
                }
                catch
                {
                    Cd4Td = 0;
                }
                try
                {
                    ChemTd = int.Parse(Convert.ToString(dr[6]));
                    if (ChemTd > 31 || ChemTd > workingDays)
                    {
                        haserror = true;
                        errorDescription = errorDescription + " Chemistry Testing Days Can't Be More Than 31 Days or Working Days";
                    }
                }
                catch
                {
                    ChemTd = 0;
                }
                try
                {
                    hemaTd = int.Parse(Convert.ToString(dr[7]));
                    if (hemaTd > 31 || hemaTd > workingDays)
                    {
                        haserror = true;
                        errorDescription = errorDescription + " Hematology Testing Days Can't Be More Than 31 Days or Working Days";
                    }
                }
                catch
                {
                    hemaTd = 0;
                }
                try
                {
                    ViralTd = int.Parse(Convert.ToString(dr[8]));
                    if (ViralTd > 31 || ViralTd > workingDays)
                    {
                        haserror = true;
                        errorDescription = errorDescription + " ViralLoad Testing Days Can't Be More Than 31 Days or Working Days";
                    }
                }
                catch
                {
                    ViralTd = 0;
                }
                try
                {
                    OtherTd = int.Parse(Convert.ToString(dr[9]));
                    if (OtherTd > 31 || OtherTd > workingDays)
                    {
                        haserror = true;
                        errorDescription = errorDescription + " Testing Days Can't Be More Than 31 Days or Working Days";
                    }
                }
                catch
                {
                    OtherTd = 0;
                }

               
                try
                {
                    openDate = Convert.ToDateTime(dr[10]);
                }
                catch
                {
                    openDate = null;
                }

                SiteImportData rd = new SiteImportData(rowno, regionName, categoryName, siteName, siteLevel, workingDays, Cd4Td, ChemTd, hemaTd, ViralTd, OtherTd, openDate);
                
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
                    if (!String.IsNullOrEmpty(siteName))
                        rd.IsExist = DataRepository.GetSiteByName(siteName, region.Id) != null;
                    else
                        haserror = true;
                }
                else
                    haserror = true;


                if (!string.IsNullOrEmpty(categoryName))
                {
                    siteCategory = DataRepository.GetSiteCategoryByName(categoryName);
                    if (siteCategory == null)
                    {
                        siteCategory = new SiteCategory();
                        siteCategory.CategoryName = categoryName;
                        DataRepository.SaveOrUpdateSiteCategory(siteCategory);
                    }
                }
                else
                    haserror = true;
                cName = categoryName;



                if (siteLevel != "")//14 may 14 null)//b
                {
                    string[] sitelevel = Enum.GetNames(typeof(SiteLevelEnum));
                    string sl = "";
                    bool level = false;
                    for (int i = 0; i < sitelevel.Length; i++)
                    {
                        sl = sitelevel[i].Replace('_', ' ');
                        if (siteLevel == sl)
                        {
                            rd.SiteLevel = siteLevel;
                            level = true;
                            break;
                        }

                    }
                    if (!level)
                    {
                        haserror = true;
                        errorDescription = errorDescription + " Is Not Valid Site Level";
                    }

                }
                else
                    haserror = true;
                rd.Category = siteCategory;
                rd.Cd4Td = Cd4Td;
                rd.ChemTd = ChemTd;
                rd.HemaTd = hemaTd;
                rd.ViralTd = ViralTd;
                rd.OtherTd = OtherTd;

                rd.HasError = haserror;
                rd.ErrorDescription = errorDescription;//14 may 14
                rdlist.Add(rd);
               
            }

            return rdlist;
        }

      

        private DateTime? ConvertStrTodate(string str)
        {
            DateTime? d = null;
            try
            {
                d = DateTime.Parse(str);
            }
            catch { }

            return d;
        }

        private class SiteImportData
        {
            private string _categoryName;
            private string _regionName;
            private ForlabRegion _region;
            private SiteCategory _siteCategory;
            private string _siteName;
            private string _siteLevel;//b
            private int _workingDays;

            private int _Cd4Td;
            private int _ChemTd;
            private int _hemaTd;
            private int _ViralTd;
            private int _OtherTd;

            private int _rowno;
            private bool _hasError = false;
            private bool _isexist = false;
            private DateTime? _openingDate;
            private string _errorDescription;

            public SiteImportData(int rowno, string rname, string cname, string sname, string slevel, int workingDays, int Cd4Td, int ChemTd, int hemaTd, int ViralTd, int OtherTd, DateTime? opendate)
            {
                this._rowno = rowno;
                this._regionName = rname;
                this._siteName = sname;
                this._categoryName = cname;
                this._siteLevel = slevel;//b
                this._workingDays = workingDays;//b
                this._openingDate = opendate;

                this._Cd4Td = Cd4Td;
                this._ChemTd = ChemTd;
                this._hemaTd = hemaTd;
                this._ViralTd = ViralTd;
                this._OtherTd = OtherTd;

               
            }

            public string CategoryName
            {
                get { return _categoryName; }
            }

            public string RegionName
            {
                get { return _regionName; }
            }

            public ForlabRegion Region
            {
                get { return _region; }
                set { _region = value; }
            }

            public SiteCategory Category
            {
                get { return _siteCategory; }
                set { _siteCategory = value; }
            }
            public string SiteName
            {
                get { return _siteName; }
            }
            public string SiteLevel//b
            {
                get { return _siteLevel; }
                set { _siteLevel = value; }
            }
            public int WorkingDays//b
            {
                get { return _workingDays; }
                set { _workingDays = value; }
            }
            public int Cd4Td
            {
                get { return _Cd4Td; }
                set { _Cd4Td = value; }
            }
            public int ChemTd
            {
                get { return _ChemTd; }
                set { _ChemTd = value; }
            }
            public int HemaTd
            {
                get { return _hemaTd; }
                set { _hemaTd = value; }
            }
            public int ViralTd
            {
                get { return _ViralTd; }
                set { _ViralTd = value; }
            }
            public int OtherTd
            {
                get { return _OtherTd; }
                set { _OtherTd = value; }
            }

           
            public int RowNo
            {
                get { return _rowno; }
            }

            public bool HasError
            {
                get { return _hasError; }
                set { _hasError = value; }
            }

            public DateTime? OpeningDate
            {
                get { return _openingDate; }
            }
            public bool IsExist
            {
                get { return _isexist; }
                set { _isexist = value; }
            }

            public string ErrorDescription //14 may 14
            {
                get { return _errorDescription; }
                set { _errorDescription = value; }
            }

        }



        private void butSave_Click(object sender, EventArgs e)
        {
            int count = 0;
            int error = 0;
            try
            {
                foreach (SiteImportData rd in _rdata)
                {
                    if (!rd.IsExist && !rd.HasError)
                    {
                        ForlabSite site = new ForlabSite();

                        site.Region = rd.Region;
                        site.SiteName = rd.SiteName;
                        site.SiteLevel = rd.SiteLevel;
                        site.SiteCategory = rd.Category;
                        site.WorkingDays = rd.WorkingDays;
                        site.CD4TestingDaysPerMonth = rd.Cd4Td;
                        site.ChemistryTestingDaysPerMonth = rd.ChemTd;
                        site.HematologyTestingDaysPerMonth = rd.HemaTd;
                        site.ViralLoadTestingDaysPerMonth = rd.ViralTd;
                        site.OtherTestingDaysPerMonth = rd.OtherTd;
                        SiteStatus ss = new SiteStatus();
                        ss.OpenedFrom = rd.OpeningDate != null ? rd.OpeningDate.Value : DateTime.Now;
                        site.SiteStatuses.Add(ss);
                        count++;
                        DataRepository.SaveOrUpdateSite(site);


                    }
                    else { error++; }

                }
                MessageBox.Show(count + " Sites are imported and saved successfully." + Environment.NewLine + error + " Sites Failed.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch
            {
                MessageBox.Show("Error: Unable to import Site data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();

            }
        }
        private void sort() // private void lvImport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnClickEventArgs e = new ColumnClickEventArgs(13);
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
