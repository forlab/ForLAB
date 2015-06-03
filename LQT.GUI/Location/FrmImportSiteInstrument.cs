
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
    public partial class FrmImportSiteInstrument : Form
    {

        private IList<SiteInstrumentImportData> _siteinstrumentdata;
        IList<ForlabSite> result = new List<ForlabSite>();
        IList<ForlabSite> totalResult = new List<ForlabSite>();
        private int sitecount = 0;
        private int siteIndex = 0;
        private int siteCatCount = 0;
        bool sitelist = false;
        int instcount = 0;
        private int _tabid = -1;

        public FrmImportSiteInstrument()
        {
            InitializeComponent();
        }

        public FrmImportSiteInstrument(int tabid)
        {
            this._tabid = tabid;
            InitializeComponent();

            tabSite.SelectedIndex = _tabid;


        }

        private class SiteInstrumentImportData
        {
            private string _tArea;
            private string _regionName;
            private string _siteName;
            private string _instrumentName;
            private int _quantity;
            private int _percentRun;

            private int _rowno;
            private bool _hasError = false;
            private bool _isexist = false;


            public SiteInstrumentImportData(int rowno, string rname, string sname, string tarea, string instname, int quantity, int percentrun)
            {
                this._rowno = rowno;
                this._regionName = rname;
                this._siteName = sname;
                this._tArea = tarea;
                this._instrumentName = instname;
                this._quantity = quantity;
                this._percentRun = percentrun;

            }

            public string InstrumentName
            {
                get { return _instrumentName; }
                set { _instrumentName = value; }

            }

            public string RegionName
            {
                get { return _regionName; }
            }


            public string SiteName
            {
                get { return _siteName; }
            }
            public string TestingArea
            {
                get { return _tArea; }
                set { _tArea = value; }
            }
            public int Quantity
            {
                get { return _quantity; }
                set { _quantity = value; }
            }
            public int PecentRun
            {
                get { return _percentRun; }
                set { _percentRun = value; }
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


            public bool IsExist
            {
                get { return _isexist; }
                set { _isexist = value; }
            }

        }

        private IList<SiteInstrumentImportData> GetInDataRow(DataSet ds)
        {
            string regionName;
            string testingArea;
            string siteName;
            string instrumentName;
            int quantity;
            int percentRun;

            int rowno = 0;
            bool haserror;



            IList<ForlabSite> _referingSites = new List<ForlabSite>();
            IList<ForlabSite> _validsites = new List<ForlabSite>();

            IList<SiteInstrumentImportData> rdlist = new List<SiteInstrumentImportData>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rowno++;
                haserror = false;
                regionName = Convert.ToString(dr[0]).Trim() ;   //region name

                siteName = Convert.ToString(dr[1]).Trim();
                testingArea = Convert.ToString(dr[2]).Trim();
                instrumentName = Convert.ToString(dr[3]).Trim();
                try
                {
                    quantity = int.Parse(Convert.ToString(dr[4]));
                }
                catch
                { quantity = 1; }
                try
                {
                    percentRun = int.Parse(Convert.ToString(dr[5]));
                }
                catch { percentRun = 100; }
                SiteInstrumentImportData rd = new SiteInstrumentImportData(rowno, regionName, siteName, testingArea, instrumentName, quantity, percentRun);

                rd.HasError = haserror;

                rdlist.Add(rd);
            }

            return rdlist;
        }

        private void butInClear_Click(object sender, EventArgs e)
        {
            lvInImport.BeginUpdate();
            lvInImport.Items.Clear();
            lvInImport.EndUpdate();
            _siteinstrumentdata = new List<SiteInstrumentImportData>();
            butInSave.Enabled = false;
            butInClear.Enabled = false;
        }

        private void butInImport_Click(object sender, EventArgs e)
        {
            bool sitexist = false;
            int count = 0;
            if (string.IsNullOrEmpty(txtInFilename.Text.Trim()))
                return;
            if (!sitelist)
            {
                result = DataRepository.GetAllSite();
            }
            if (result.Count > 0)
            {
                try
                {
                    DataSet ds = LqtUtil.ReadExcelFile(txtInFilename.Text, 6);

                    _siteinstrumentdata = GetInDataRow(ds);
                    int[] percentage = new int[_siteinstrumentdata.Count];
                    bool haserror = false;

                    lvInImport.BeginUpdate();
                    lvInImport.Items.Clear();
                    string errorString;

                    foreach (SiteInstrumentImportData rd in _siteinstrumentdata)
                    {
                        string str;
                        errorString = "";
                        ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                        li.SubItems.Add(rd.RegionName);
                        foreach (ForlabSite site in result)
                        {
                            if ((site.SiteName.ToLower() == rd.SiteName.ToLower()) && (site.Region.RegionName.ToLower() == rd.RegionName.ToLower()))
                            {
                                sitexist = true;
                                break;
                            }
                        }
                        if (!sitexist)
                        {
                            rd.HasError = true;
                            if (rd.RegionName=="")
                            errorString = errorString + " Region Doesn't Exist";//14 may 14
                            else
                                errorString = errorString + " Site Doesn't Exist In This Region";//14 may 14
                        }
                        sitexist = false;
                        li.SubItems.Add(rd.SiteName);
                        Instrument Inst = DataRepository.GetInstrumentByName(rd.InstrumentName);
                        ForlabRegion Inregion = DataRepository.GetRegionByName(rd.RegionName);
                        ForlabSite s = DataRepository.GetSiteByName(rd.SiteName,Inregion.Id);

                        if (Inst != null)
                            li.SubItems.Add(Inst.TestingArea.AreaName);
                        else
                        {
                            haserror = true;
                            rd.HasError = true;
                            errorString = errorString + " Instrument Doesn't Exist";//14 may 14
                            li.SubItems.Add("");//?
                        }
                        count = 0;
                        foreach (ListViewItem Item in lvInImport.Items)
                        {
                            if (Item.SubItems[1].Text.Trim().ToLower() == rd.RegionName.Trim().ToLower() && Item.SubItems[2].Text.Trim().ToLower() == rd.SiteName.Trim().ToLower() && Item.SubItems[4].Text.Trim().ToLower() == rd.InstrumentName.Trim().ToLower())
                            {
                                rd.IsExist = true;
                                str = "Duplicated";
                            }
                            //if (rd.TestingArea == Item.SubItems[3].Text)
                            //{  
                            //    try
                            //    {
                            //        percentage[count] = int.Parse(Item.SubItems[6].Text);
                            //        count++;
                            //    }
                            //    catch
                            //    {
                            //    }
                            //}
                        }
                        //int sum = 0;
                        //for (int i = 0; i < count; i++)
                        //{
                        //    sum = sum + percentage[i];
                        //}
                        //if ((sum > 100 || sum < 100) && (sum!=0))
                        //    rd.HasError = true;
                        if (Inst != null && s != null)
                        {
                            foreach (SiteInstrument inst in s.SiteInstruments)
                            {
                                if (inst.Instrument == Inst)
                                {
                                    rd.IsExist = true;
                                }
                            }

                        }




                        li.SubItems.Add(rd.InstrumentName);
                        li.SubItems.Add(rd.Quantity.ToString());
                        li.SubItems.Add(rd.PecentRun.ToString());
                        str = rd.IsExist ? "Yes" : "No";
                        li.SubItems.Add(str);
                        if (rd.HasError)
                        {
                            li.BackColor = Color.Red;
                            haserror = true;
                            if (rd.RegionName == "")
                                errorString = errorString + " Region Name Required";//14 may 14
                            if (rd.SiteName == "")
                                errorString = errorString + " Site Name Required";
                            if (rd.InstrumentName == "")
                                errorString = errorString + " Instrument Name Required";//14 may 14
                            if (rd.SiteName == "")
                                errorString = errorString + " Site Name Required";
                       
                       
                        }
                        if (rd.IsExist)
                        {
                            li.BackColor = Color.Yellow;
                        }
                        li.SubItems.Add(errorString);
                        lvInImport.Items.Add(li);
                    }

                    sort();

                    lvInImport.EndUpdate();
                    //lvInImport.BeginUpdate();
                    //lvInImport.Items.Clear();

                    //foreach (SiteInstrumentImportData rd in _siteinstrumentdata)
                    //{
                    //    string str;

                    //    ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                    //    li.SubItems.Add(rd.RegionName);
                    //    foreach (ForlabSite site in result)
                    //    {
                    //        if ((site.SiteName == rd.SiteName) && (site.Region.RegionName == rd.RegionName))
                    //        {
                    //            sitexist = true;
                    //            break;
                    //        }
                    //    }
                    //    if (!sitexist)
                    //        rd.HasError = true;
                    //    sitexist = false;
                    //    li.SubItems.Add(rd.SiteName);
                    //    Instrument Inst = DataRepository.GetInstrumentByName(rd.InstrumentName);
                    //    ForlabSite s = DataRepository.GetSiteByName(rd.SiteName);

                    //    if (Inst != null)
                    //        li.SubItems.Add(Inst.TestingArea.AreaName);
                    //    else
                    //    {
                    //        haserror = true;
                    //        rd.HasError = true;
                    //        li.SubItems.Add("");
                    //    }
                    //    count = 0;
                    //    foreach (ListViewItem Item in lvInImport.Items)
                    //    {
                    //        if (Item.SubItems[1].Text == rd.RegionName && Item.SubItems[2].Text == rd.SiteName && Item.SubItems[4].Text == rd.InstrumentName)
                    //        {
                    //            rd.IsExist = true;
                    //            str = "Duplicated";
                    //        }
                    //        if (rd.TestingArea == Item.SubItems[3].Text)
                    //        {
                    //            try
                    //            {
                    //                percentage[count] = int.Parse(Item.SubItems[6].Text);
                    //                count++;
                    //            }
                    //            catch
                    //            {
                    //            }
                    //        }
                    //    }
                    //    int sum = 0;
                    //    for (int i = 0; i < count; i++)
                    //    {
                    //        sum = sum + percentage[i];
                    //    }
                    //    if ((sum > 100 || sum < 100) && (sum != 0))
                    //        rd.HasError = true;
                    //    if (Inst != null && s != null)
                    //    {
                    //        foreach (SiteInstrument inst in s.SiteInstruments)
                    //        {
                    //            if (inst.Instrument == Inst)
                    //            {
                    //                rd.IsExist = true;
                    //            }
                    //        }

                    //    }




                    //    li.SubItems.Add(rd.InstrumentName);
                    //    li.SubItems.Add(rd.Quantity.ToString());
                    //    li.SubItems.Add(rd.PecentRun.ToString());
                    //    str = rd.IsExist ? "Yes" : "No";
                    //    li.SubItems.Add(str);
                    //    if (rd.HasError)
                    //    {
                    //        li.BackColor = Color.Cyan;
                    //        haserror = true;
                    //    }
                    //    if (rd.IsExist)
                    //    {
                    //        li.BackColor = Color.Red;
                    //    }
                    //    lvInImport.Items.Add(li);
                    //}



                    //lvInImport.EndUpdate();

                    // SaveInstrument();

                    butInClear.Enabled = true;
                    //  if (!haserror)//b jul 9
                    butInSave.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error:Importing", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveInstrument()
        {
            instcount = 0;
            IList<SiteInstrument> resultin = new List<SiteInstrument>();
            result = DataRepository.GetAllSite();
            try
            {
                foreach (SiteInstrumentImportData rd in _siteinstrumentdata)
                {
                    try
                    {
                        if (!rd.IsExist && !rd.HasError)
                        {
                            SiteInstrument sitein = new SiteInstrument();
                            ForlabRegion Inregion = DataRepository.GetRegionByName(rd.RegionName);
                            if (Inregion == null)
                                rd.HasError = true;
                            ForlabSite site = DataRepository.GetSiteByName(rd.SiteName, Inregion.Id);
                            if (site == null)
                                rd.HasError = true;
                            TestingArea ta = DataRepository.GetTestingAreaByName(rd.TestingArea);
                            if (ta == null)
                                rd.HasError = true;
                            Instrument Inst = DataRepository.GetInstrumentByNameAndTestingArea(rd.InstrumentName, ta.Id);
                            sitein.Site = site;
                            sitein.Instrument = Inst;
                            sitein.Quantity = rd.Quantity;
                            sitein.TestRunPercentage = rd.PecentRun;
                            //   DataRepository.SaveOrUpdateSite(site);

                            foreach (ForlabSite sitei in result)
                            {
                                if (sitei.SiteName == rd.SiteName && !sitei.SiteInstruments.Contains(sitein))
                                {
                                    sitein.Site = sitei;
                                    sitei.SiteInstruments.Add(sitein);
                                    instcount++;
                                }


                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        rd.HasError = true;
                    }
                
                }
                   // 
                //  SaveAll();
                // MessageBox.Show(instcount + " Site Instrument are imported successfully.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();

            }
            catch
            {
                MessageBox.Show("Error: Unable to import Site Instrument data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // DataRepository.CloseSession();
            }

        }

        private void butInBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtInFilename.Text = openFileDialog1.FileName;
            }
        }

        private void butInSave_Click(object sender, EventArgs e)
        {
            SaveInstrument();
            ListViewItem li = new ListViewItem();
            string siteName;
            int count = 0, instPercent = 0;
            foreach (ForlabSite site in result)
            {

                siteName = site.SiteName;
                li = lvImport.FindItemWithText(site.SiteName);
                if (site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.CD4).Count > 0 )//|| site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.FlowCytometry).Count > 0)
                {
                    if (site.CD4TestingDaysPerMonth <= 0)
                    {
                        site.CD4TestingDaysPerMonth = 1;
                    }
                   // if (site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.CD4).Count > 0)
                        instPercent = InstrumentUsage(site, ClassOfMorbidityTestEnum.CD4);//instrument percentage
                    //else
                    //    instPercent = InstrumentUsage(site, ClassOfMorbidityTestEnum.FlowCytometry);//instrument percentage
                    if (instPercent > 0)
                    {
                        count = count + instPercent;
                        instPercent = 0;
                    }

                }

                if (site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.Chemistry).Count > 0)
                {
                    if (site.ChemistryTestingDaysPerMonth <= 0)
                    {
                        site.ChemistryTestingDaysPerMonth = 1;
                    }


                    instPercent = InstrumentUsage(site, ClassOfMorbidityTestEnum.Chemistry);//instrument percentage
                    if (instPercent > 0)
                    {
                        count = count + instPercent;
                        instPercent = 0;
                    }


                }

                if (site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.Hematology).Count > 0)
                {
                    if (site.HematologyTestingDaysPerMonth <= 0)
                    {
                        site.HematologyTestingDaysPerMonth = 1;
                    }
                    instPercent = InstrumentUsage(site, ClassOfMorbidityTestEnum.Hematology);//instrument percentage
                    if (instPercent > 0)
                    {
                        count = count + instPercent;
                        instPercent = 0;
                    }

                }

                if (site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.ViralLoad).Count > 0)
                {
                    if (site.ViralLoadTestingDaysPerMonth <= 0)
                    {
                        site.ViralLoadTestingDaysPerMonth = 1;
                    }
                    instPercent = InstrumentUsage(site, ClassOfMorbidityTestEnum.ViralLoad);//instrument percentage
                    if (instPercent > 0)
                    {
                        count = count + instPercent;
                        instPercent = 0;
                    }

                }

                if (site.GetInstrumentByPlatform(ClassOfMorbidityTestEnum.OtherTest).Count > 0)
                {
                    if (site.OtherTestingDaysPerMonth <= 0)
                    {
                        site.OtherTestingDaysPerMonth = 1;
                    }
                    instPercent = InstrumentUsage(site, ClassOfMorbidityTestEnum.OtherTest);//instrument percentage
                    if (instPercent > 0)
                    {
                        count = count + instPercent;
                        instPercent = 0;
                    }

                }

                if (site.Id > siteIndex && sitelist)
                {
                    site.Id = -1;

                }
                DataRepository.SaveOrUpdateSite(site);
            }
            totalResult = DataRepository.GetAllSite();
            ForlabSite lastsite = DataRepository.GetSiteById(siteIndex);
            int index = totalResult.IndexOf(lastsite);

            if (!sitelist)
            {
                if (instcount - count > 0)
                    MessageBox.Show(instcount - count + " Site Instrument are imported and saved successfully.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No Data imported .", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((count - sitecount) <= 0)
            {
                MessageBox.Show("No Data imported .", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {

                MessageBox.Show(count - sitecount + " Site Instrument are imported and saved successfully.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            sitelist = false;
            instcount = 0;
            this.Close();
        }

        private int InstrumentUsage(ForlabSite s, ClassOfMorbidityTestEnum platform)
        {
            decimal sum = 0;
            // bool error = false;
            int removedInst = 0;
            IList<SiteInstrument> sinst = new List<SiteInstrument>();
            if (s.GetInstrumentByPlatform(platform).Count > 0)//instrument percentage
            {
                sinst = s.GetInstrumentByPlatform(platform);
                foreach (SiteInstrument si in sinst)
                {
                    sum = sum + si.TestRunPercentage;
                }
                if (sum != 100)
                {
                    // error = true;
                    foreach (SiteInstrument si in sinst)
                    {
                        foreach (SiteInstrumentImportData rd in _siteinstrumentdata)
                        {
                            if (rd.InstrumentName == si.Instrument.InstrumentName && rd.SiteName == s.SiteName && !rd.IsExist && !rd.HasError)
                            {
                                s.SiteInstruments.Remove(si);
                                sum = sum + si.TestRunPercentage;
                                removedInst++;
                            }
                        }
                    }
                }
            }
            return removedInst;
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
            int numItems = this.lvInImport.Items.Count;

            // Turn off display while data is repoplulated.
            this.lvInImport.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(this.lvInImport.Items[i], e.Column));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.
            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(false));//(clickedCol.ascending));

            // Clear the list, and repopulate with the sorted items.
            this.lvInImport.Items.Clear();
            for (int i = 0; i < numItems; i++)
                this.lvInImport.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            this.lvInImport.EndUpdate();

        }
    }
}
