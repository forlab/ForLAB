
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
    public partial class FrmImportRefSite : Form
    {
        private IList<RefSiteImportData> _rdata;
        // private IList<SiteInstrumentImportData> _siteinstrumentdata;
        IList<ForlabSite> result = new List<ForlabSite>();
        IList<ForlabSite> totalResult = new List<ForlabSite>();
        private int sitecount = 0;
        private int siteIndex = 0;
        bool sitelist = false;
        int instcount = 0;
        private int _tabid = -2;

        public FrmImportRefSite()
        {
            InitializeComponent();
        }

        public FrmImportRefSite(int tabid)
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
                DataSet ds = LqtUtil.ReadExcelFile(txtFilename.Text, 7);

                _rdata = GetDataRow(ds);
                bool haserror = false;

                lvImport.BeginUpdate();
                lvImport.Items.Clear();
                string errorString;
                foreach (RefSiteImportData rd in _rdata)
                {
                    string str;
                    errorString = "";
                    ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                    li.SubItems.Add(rd.RegionName);
                    li.SubItems.Add(rd.SiteName);
                    li.SubItems.Add(rd.CD4RefSite.ToString());
                    li.SubItems.Add(rd.ChemistryRefSite.ToString());
                    li.SubItems.Add(rd.HematologyRefSite.ToString());
                    li.SubItems.Add(rd.ViralLoadRefSite.ToString());
                    li.SubItems.Add(rd.OtheRefSite.ToString());


                    str = rd.IsExist ? "Yes" : "No";


                    foreach (ListViewItem Item in lvImport.Items)
                    {
                        if (((Item.SubItems[2].Text.Trim().ToLower() == rd.SiteName.Trim().ToLower()) && (Item.SubItems[3].Text.Trim().ToLower() == rd.CD4RefSite.Trim().ToLower())) ||
                            ((Item.SubItems[2].Text.Trim().ToLower() == rd.SiteName.Trim().ToLower()) && (Item.SubItems[4].Text.Trim().ToLower() == rd.ChemistryRefSite.Trim().ToLower())) ||
                            ((Item.SubItems[2].Text.Trim().ToLower() == rd.SiteName.Trim().ToLower()) && (Item.SubItems[5].Text.Trim().ToLower() == rd.HematologyRefSite.Trim().ToLower())) ||
                            ((Item.SubItems[2].Text.Trim().ToLower() == rd.SiteName.Trim().ToLower()) && (Item.SubItems[6].Text.Trim().ToLower() == rd.ViralLoadRefSite.Trim().ToLower())) ||
                            ((Item.SubItems[2].Text.Trim().ToLower() == rd.SiteName.Trim().ToLower()) && (Item.SubItems[7].Text.Trim().ToLower() == rd.OtheRefSite.Trim().ToLower())))
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
            _rdata = new List<RefSiteImportData>();
            butSave.Enabled = false;
            butClear.Enabled = false;
        }


        private IList<RefSiteImportData> GetDataRow(DataSet ds)
        {
            string regionName;
            string siteName;
            string rName = "";
            ForlabRegion region = null;
            ForlabSite site = null;

            string CD4RefSite;
            string ChemRefSite;
            string HemRefSite;
            string ViralRefSite;
            string OtherRefSite;

            int rowno = 0;
            bool haserror;

            ForlabSite refSite = null;
            int CD4RefSiteId = 0;
            int ChemRefSiteId = 0;
            int HemRefSiteId = 0;
            int ViralRefSiteId = 0;
            int OtherRefSiteId = 0;

            IList<ForlabSite> _referingSites = new List<ForlabSite>();
            IList<ForlabSite> sites;
            IList<ForlabSite> _validsites = new List<ForlabSite>();

            IList<RefSiteImportData> rdlist = new List<RefSiteImportData>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string errorDiscription = "";
                rowno++;
                haserror = false;
                regionName = Convert.ToString(dr[0]).Trim();   //region namegory name
                siteName = Convert.ToString(dr[1]).Trim();   //short name
                try
                {
                    CD4RefSite = Convert.ToString(dr[2]);

                }
                catch
                {
                    CD4RefSite = "";
                }
                try
                {
                    ChemRefSite = Convert.ToString(dr[3]);

                }
                catch
                {
                    ChemRefSite = "";
                }
                try
                {
                    HemRefSite = Convert.ToString(dr[4]);

                }
                catch
                {
                    HemRefSite = "";
                }
                try
                {
                    ViralRefSite = Convert.ToString(dr[5]);

                }
                catch
                {
                    ViralRefSite = "";
                }
                try
                {
                    OtherRefSite = Convert.ToString(dr[6]);

                }
                catch
                {
                    OtherRefSite = "";
                }

                RefSiteImportData rd = new RefSiteImportData(rowno, regionName, siteName, CD4RefSite, ChemRefSite, HemRefSite, ViralRefSite, OtherRefSite);

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
                    {
                        site = DataRepository.GetSiteByName(siteName, region.Id);
                        if (site != null)
                        {
                            //if((site.CD4RefSite.ToString().Trim()==(dr[2]).ToString().Trim().ToLower())||(site.ChemistryRefSite.ToString().Trim().ToLower()==(dr[3]).ToString().Trim().ToLower())||
                            //    (site.HematologyRefSite.ToString().Trim().ToLower()==(dr[4]).ToString().Trim().ToLower())||(site.ViralLoadRefSite.ToString().Trim().ToLower()==(dr[5]).ToString().Trim().ToLower())||
                            //    (site.OtherRefSite.ToString().Trim().ToLower()==(dr[6]).ToString().Trim().ToLower()))
                            //    rd.IsExist=true;
                        }
                        else
                        {
                            errorDiscription = errorDiscription + " Site doesn't exist";
                            haserror = true;
                        }

                    }
                    else
                    {
                        errorDiscription = errorDiscription + " Site name required";
                        haserror = true;
                    }
                    if (!haserror)
                    {
                        if (!String.IsNullOrEmpty(CD4RefSite))
                            if ((ISValidReferralSite(CD4RefSite, siteName, "CD4", out refSite)) || (ISValidReferralSite(CD4RefSite, siteName, "Flow Cytometry", out refSite)))
                                CD4RefSiteId = refSite.Id;
                            else
                            {
                                haserror = true;
                                CD4RefSiteId = -1;
                                errorDiscription = errorDiscription + " Is Not Valid CD4 Referral Site";//14 may 14
                            }

                        if (!String.IsNullOrEmpty(ChemRefSite))
                            if (ISValidReferralSite(ChemRefSite, siteName, "Chemistry", out refSite))
                                ChemRefSiteId = refSite.Id;
                            else
                            {
                                haserror = true;
                                ChemRefSiteId = -1;
                                errorDiscription = errorDiscription + " Is Not Valid Chemistry Referral Site";
                            }

                        if (!String.IsNullOrEmpty(HemRefSite))
                            if (ISValidReferralSite(HemRefSite, siteName, "Hematology", out refSite))
                                HemRefSiteId = refSite.Id;
                            else
                            {
                                haserror = true;
                                HemRefSiteId = -1;
                                errorDiscription = errorDiscription + " Is Not Valid Hematology Referral Site";
                            }

                        if (!String.IsNullOrEmpty(ViralRefSite))
                            if (ISValidReferralSite(ViralRefSite, siteName, "ViralLoad", out refSite))
                                ViralRefSiteId = refSite.Id;
                            else
                            {
                                haserror = true;
                                ViralRefSiteId = -1;
                                errorDiscription = errorDiscription + " Is Not Valid ViralLoad Referral Site";
                            }

                        if (!String.IsNullOrEmpty(OtherRefSite))
                            if (ISValidReferralSite(OtherRefSite, siteName, "Other", out refSite))
                                OtherRefSiteId = refSite.Id;
                            else
                            {
                                haserror = true;
                                OtherRefSiteId = -1;
                                errorDiscription = errorDiscription + " Is Not Valid Referral Site";
                            }
                    }
                    else
                        haserror = true;
                }
                else
                {
                    errorDiscription = errorDiscription + " Region doesn't exist";
                    haserror = true;
                }


                rd.CD4RefSiteId = CD4RefSiteId;
                rd.ChemistryRefSiteId = ChemRefSiteId;
                rd.HematologyRefSiteId = HemRefSiteId;
                rd.ViralLoadRefSiteId = ViralRefSiteId;
                rd.OtheRefSiteId = OtherRefSiteId;
                rd.HasError = haserror;
                if (rd.CD4RefSiteId == 0 && rd.ChemistryRefSiteId == 0 && rd.HematologyRefSiteId == 0 && rd.ViralLoadRefSiteId == 0 && rd.OtheRefSiteId == 0)
                {
                    rd.HasError = true;
                    errorDiscription = errorDiscription + " At least one referral site required";
                }

                rd.ErrorDescription = errorDiscription;//14 may 14
                rdlist.Add(rd);
                CD4RefSiteId = 0;
                ChemRefSiteId = 0;
                HemRefSiteId = 0;
                ViralRefSiteId = 0;
                OtherRefSiteId = 0;
            }

            return rdlist;
        }

        private bool ISValidReferralSite(string Referralsite, string siten, string platform, out ForlabSite refSite)
        {

            IList<ForlabSite> _referingSites = new List<ForlabSite>();

            IList<ForlabSite> _validsites = new List<ForlabSite>();

            refSite = null;
            bool isvalid = false;
            if (!String.IsNullOrEmpty(Referralsite))
            {
                refSite = DataRepository.GetSiteByName(Referralsite);
                if (refSite != null)
                {

                    if (refSite.SiteName != siten)
                    {
                        _validsites = DataRepository.GetAllSiteByRegionandPlatform(-1, LqtUtil.RemoveWhitespace(platform));
                        _referingSites = DataRepository.GetReferingSiteByPlatform(LqtUtil.RemoveWhitespace(platform));
                        if (_validsites.Contains(refSite) && !_referingSites.Contains(refSite))
                            isvalid = true;
                        else
                            isvalid = false;
                    }
                    else
                        isvalid = false;
                }
                else
                {
                    isvalid = false;
                }
            }
            else
            {
                isvalid = false;
            }

            return isvalid;
        }


        private class RefSiteImportData
        {

            private string _regionName;
            private ForlabRegion _region;
            private string _siteName;
            private ForlabSite _site;

            private string _CD4RefSite;
            private string _ChemistryRefSite;
            private string _HematologyRefSite;
            private string _OtheRefSite;
            private string _ViralLoadRefSite;

            private int _CD4RefSiteId;
            private int _ChemistryRefSiteId;
            private int _HematologyRefSiteId;
            private int _OtheRefSiteId;
            private int _ViralLoadRefSiteId;




            private int _rowno;
            private bool _hasError = false;
            private bool _isexist = false;
            private string _errorDescription;

            public RefSiteImportData(int rowno, string rname, string sname, string CD4RefSite, string ChemistryRefSite, string HematologyRefSite, string ViralLoadRefSite, string OtheRefSite)
            {
                this._rowno = rowno;
                this._regionName = rname;
                this._siteName = sname;

                this._CD4RefSite = CD4RefSite;
                this._ChemistryRefSite = ChemistryRefSite;
                this._HematologyRefSite = HematologyRefSite;
                this._OtheRefSite = OtheRefSite;
                this._ViralLoadRefSite = ViralLoadRefSite;

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

            public string SiteName
            {
                get { return _siteName; }
            }
            public string CD4RefSite//b
            {
                get { return _CD4RefSite; }
                set { _CD4RefSite = value; }
            }

            public string ChemistryRefSite//b
            {
                get { return _ChemistryRefSite; }
                set { _ChemistryRefSite = value; }
            }
            public string HematologyRefSite//b
            {
                get { return _HematologyRefSite; }
                set { _HematologyRefSite = value; }
            }
            public string ViralLoadRefSite//b
            {
                get { return _ViralLoadRefSite; }
                set { _ViralLoadRefSite = value; }
            }
            public string OtheRefSite//b
            {
                get { return _OtheRefSite; }
                set { _OtheRefSite = value; }
            }

            public int CD4RefSiteId//b
            {
                get { return _CD4RefSiteId; }
                set { _CD4RefSiteId = value; }
            }

            public int ChemistryRefSiteId//b
            {
                get { return _ChemistryRefSiteId; }
                set { _ChemistryRefSiteId = value; }
            }
            public int HematologyRefSiteId//b
            {
                get { return _HematologyRefSiteId; }
                set { _HematologyRefSiteId = value; }
            }
            public int ViralLoadRefSiteId//b
            {
                get { return _ViralLoadRefSiteId; }
                set { _ViralLoadRefSiteId = value; }
            }
            public int OtheRefSiteId//b
            {
                get { return _OtheRefSiteId; }
                set { _OtheRefSiteId = value; }
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

            public string ErrorDescription //14 may 14
            {
                get { return _errorDescription; }
                set { _errorDescription = value; }
            }

        }

        private void SaveSite()
        {
            int count = 0;
            int error = 0;
            try
            {
                foreach (RefSiteImportData rd in _rdata)
                {
                    if (!rd.IsExist && !rd.HasError)
                    {
                        ForlabSite site = DataRepository.GetSiteByName(rd.SiteName);
                        site.CD4RefSite = rd.CD4RefSiteId;
                        site.ChemistryRefSite = rd.ChemistryRefSiteId;
                        site.HematologyRefSite = rd.HematologyRefSiteId;
                        site.ViralLoadRefSite = rd.ViralLoadRefSiteId;
                        site.OtherRefSite = rd.OtheRefSiteId;
                        count++;
                        DataRepository.SaveOrUpdateSite(site);


                    }
                    else { error++; }

                }
            }
            catch
            {
                MessageBox.Show("Error: Unable to import Referral Site data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();

            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {

            int errorcount = 0;
            ForlabSite refSite = null;
            ListViewItem li = new ListViewItem();
            string siteName;
            bool error = false;
            string refsite = "";
            int sindex = 0, count = 0;
            try
            {
                foreach (RefSiteImportData rd in _rdata)
                {

                    siteName = rd.SiteName;
                    li = lvImport.FindItemWithText(rd.SiteName);
                    if (rd.CD4RefSiteId != 0)
                    {
                        if (rd.CD4RefSiteId == -1)
                        {
                            refsite = li.SubItems[2].Text;
                            if (!ISValidReferral(refsite, rd.SiteName, "CD4", out sindex))
                                error = true;
                            else
                                rd.CD4RefSiteId = sindex;
                        }
                        else
                        {
                            refSite = DataRepository.GetSiteById(rd.CD4RefSiteId);
                            if (refSite != null)
                                if (!(ISValidReferralSite(refSite.SiteName, siteName, "CD4", out refSite)) || !(ISValidReferralSite(refSite.SiteName, siteName, "Flow Cytometry", out refSite)))
                                    error = true;
                        }
                        sindex = 0;

                    }
                    if (rd.ChemistryRefSiteId != 0)
                    {
                        if (rd.ChemistryRefSiteId == -1)
                        {
                            refsite = li.SubItems[3].Text;
                            if (!ISValidReferral(refsite, rd.SiteName, "Chemistry", out sindex))
                                error = true;
                            else
                                rd.ChemistryRefSiteId = sindex;

                        }
                        else
                        {
                            refSite = DataRepository.GetSiteById(rd.ChemistryRefSiteId);
                            if (refSite != null)
                                if (!ISValidReferralSite(refSite.SiteName, siteName, "Chemistry", out refSite))
                                    error = true;
                        }
                        sindex = 0;

                    }
                    if (rd.HematologyRefSiteId != 0)
                    {
                        if (rd.HematologyRefSiteId == -1)
                        {
                            refsite = li.SubItems[4].Text;
                            if (!ISValidReferral(refsite, rd.SiteName, "Hematology", out sindex))
                                error = true;
                            else
                                rd.HematologyRefSiteId = sindex;
                        }
                        else
                        {
                            refSite = DataRepository.GetSiteById(rd.HematologyRefSiteId);
                            if (refSite != null)
                                if (!ISValidReferralSite(refSite.SiteName, siteName, "Hematology", out refSite))
                                    error = true;
                        }
                        sindex = 0;
                    }
                    if (rd.ViralLoadRefSiteId != 0)
                    {
                        if (rd.ViralLoadRefSiteId == -1)
                        {
                            refsite = li.SubItems[5].Text;
                            if (!ISValidReferral(refsite, rd.SiteName, "ViralLoad", out sindex))
                                error = true;
                            else
                                rd.ViralLoadRefSiteId = sindex;

                        }
                        else
                        {
                            refSite = DataRepository.GetSiteById(rd.ViralLoadRefSiteId);
                            if (refSite != null)
                                if (!ISValidReferralSite(refSite.SiteName, siteName, "ViralLoad", out refSite))
                                    error = true;
                        }
                        sindex = 0;
                    }
                    if (rd.OtheRefSiteId != 0)
                    {
                        if (rd.OtheRefSiteId == -1)
                        {
                            refsite = li.SubItems[6].Text;
                            if (!ISValidReferral(refsite, rd.SiteName, "Other", out sindex))
                                error = true;
                            else
                                rd.OtheRefSiteId = sindex;


                        }
                        else
                        {
                            refSite = DataRepository.GetSiteById(rd.OtheRefSiteId);
                            if (refSite != null)
                                if (!ISValidReferralSite(refSite.SiteName, siteName, "Other", out refSite))
                                    error = true;
                        }
                        sindex = 0;
                    }
                    if (!rd.IsExist && !rd.HasError && !error)
                    {
                        ForlabSite site = DataRepository.GetSiteByName(rd.SiteName,rd.Region.Id);
                        site.CD4RefSite = rd.CD4RefSiteId;
                        site.ChemistryRefSite = rd.ChemistryRefSiteId;
                        site.HematologyRefSite = rd.HematologyRefSiteId;
                        site.ViralLoadRefSite = rd.ViralLoadRefSiteId;
                        site.OtherRefSite = rd.OtheRefSiteId;
                        count++;
                        DataRepository.SaveOrUpdateSite(site);


                    }
                    else { errorcount++; }
                    error = false;
                }

                MessageBox.Show(count + " Referral Sites are imported and saved successfully." + Environment.NewLine + errorcount + " Referral Sites Failed.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();


            }
            catch
            {
                MessageBox.Show("Error: Unable to import and save Referral Site data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();
            }
        }

        private bool ISValidReferral(string Referralsite, string siten, string platform, out int sindex)
        {
            sindex = 0;
            bool isvalid = false;
            IList<SiteInstrument> _siteins = new List<SiteInstrument>();
            if (Referralsite == siten)
                isvalid = false;

            else
            {
                foreach (ForlabSite s in result)
                {
                    if (s.SiteName == Referralsite)//site exist
                    {
                        if ((LqtUtil.RemoveWhitespace(platform).ToLower() == LqtUtil.RemoveWhitespace("CD4").ToLower() && s.CD4RefSite == 0) || 
                            (LqtUtil.RemoveWhitespace(platform).ToLower() == LqtUtil.RemoveWhitespace("Flow Cytometry").ToLower() && s.CD4RefSite == 0) || 
                            (platform == "Chemistry" && s.ChemistryRefSite == 0) || 
                            (platform == "Hematology" && s.HematologyRefSite == 0) || 
                            (LqtUtil.RemoveWhitespace(platform).ToLower() == LqtUtil.RemoveWhitespace("Viral Load").ToLower() && s.ViralLoadRefSite == 0) || 
                            (platform == "Other" && s.OtherRefSite == 0)
                            )
                        {
                            _siteins = s.SiteInstruments;
                            foreach (SiteInstrument inst in _siteins)
                            {
                                if (inst.Instrument.TestingArea.AreaName.Replace(" ", "") == platform)
                                {
                                    isvalid = true;
                                    sindex = s.Id;
                                    break;
                                }

                            }


                        }


                    }

                }




            }

            return isvalid;
        }

        private void sort() // private void lvImport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnClickEventArgs e = new ColumnClickEventArgs(9);
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
