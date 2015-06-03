
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.DataAccess;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class FrmImportCPN : Form
    {
        private IList<ImportSiteNumber> _rdata;
        private MorbidityForecast _forecast;
        private IList<int> _selectedSiteId;
        private IList<ARTSite> _artSites;
        private SiteListView _sListView;
        private ComboBox _comTestingArea;
        private IList<ForlabRegion> _regions;
        private double _sumofTimeZeroPatientOnTreatment;
        private double _sumofTimeZeroPatientOnPreTreatment;

        public FrmImportCPN(MorbidityForecast forecast, IList<ARTSite> artsites, IList<int> selectedSiteids)
        {
            _forecast = forecast;
            _artSites = artsites;
            _selectedSiteId = selectedSiteids;

            InitializeComponent();

            _regions = DataRepository.GetAllRegion();
        }

        private bool IsSiteSelected(int siteid)
        {
            return _selectedSiteId.Any(id => id == siteid);
        }

        private void LoadSiteListView()
        {
            _sListView = new SiteListView();
            _sListView.MySortBrush = SystemBrushes.ControlLight;
            _sListView.MyHighlightBrush = Brushes.Goldenrod;
            _sListView.GridLines = true;
            _sListView.MultiSelect = false;
            _sListView.Dock = DockStyle.Fill;
            _sListView.ControlPadding = 4;
            _sListView.HeaderStyle = ColumnHeaderStyle.None;

            _comTestingArea = new ComboBox();
            _comTestingArea.ValueMember = "Id";
            _comTestingArea.DisplayMember = "CategoryName";
            //_comTestingArea.DataSource = _lstCategories;

            //add columns and items
            _sListView.Columns.Add(new EXColumnHeader("Region Name", 100));
            _sListView.Columns.Add(new EXColumnHeader("ART Site", 100));
            var colMsite = new EXEditableColumnHeader("Mapped Site", _comTestingArea, 200);
            _sListView.Columns.Add(colMsite);
            var colCat = new EXEditableColumnHeader("Category/Region", _comTestingArea, 200);
            _sListView.Columns.Add(colCat);
            _sListView.Columns.Add(new EXColumnHeader("CURRENT P.T", 130));
            _sListView.Columns.Add(new EXColumnHeader("CURRENT P.Pre-T", 130));
            _sListView.Columns.Add(new EXColumnHeader("EVER STARTED P.T", 130));
            _sListView.Columns.Add(new EXColumnHeader("EVER STARTED P.Pre-T", 130));
            _sListView.Columns.Add(new EXColumnHeader("VCT", 100));
            _sListView.Columns.Add(new EXColumnHeader("CD4", 100));
            _sListView.Columns.Add(new EXColumnHeader("Chemistry", 100));
            _sListView.Columns.Add(new EXColumnHeader("Hematology", 100));
            _sListView.Columns.Add(new EXColumnHeader("Viral Load", 100));
            _sListView.Columns.Add(new EXColumnHeader("Other Tests", 100));
            _sListView.Columns.Add(new EXColumnHeader("Consumables", 100));
            _sListView.Columns.Add(new EXColumnHeader("Exist", 100));
            _sListView.Columns.Add(new EXColumnHeader("Remarks", 165));
            
            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            _sListView.ComboBoxBeforeVisible += new EventHandler<EXEditableListViewComboBoxEventArgs>(_sListView_ComboBoxBeforeVisible);
            //panel1.Controls.Add(_sListView);
        }

        private void _sListView_ComboBoxBeforeVisible(object sender, EXEditableListViewComboBoxEventArgs e)
        {
            //e.ListVItem.Tag;
            //DataRepository.GetAllSiteByRegionId()
        }

        private void _sListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            ImportedReagionOrCategory ta = (ImportedReagionOrCategory)e.ListVItem.Tag;
            ta.MCategory = LqtUtil.GetComboBoxValue<MorbidityCategory>(_comTestingArea);
        }

        private void PopListView()
        {
            _sListView.Items.Clear();
            _sListView.BeginUpdate();

            //foreach (ImportedReagionOrCategory ta in _listOfImportedCat.Values)
            //{
            //    EXListViewItem li = new EXListViewItem(ta.RegionOrCatName) { Tag = ta };
            //    li.SubItems.Add(new EXListViewSubItem("---Select Category/Region---", "Category/Region"));

            //    _sListView.Items.Add(li);
            //}

            _sListView.EndUpdate();
        }
        private void butBrowse_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
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
                var ds = LqtUtil.ReadExcelFile(txtFilename.Text, 13);

                _rdata = GetDataRow(ds);
                lvImport.BeginUpdate();
                lvImport.Items.Clear();

                foreach (var rd in _rdata)
                {
                    var li = new ListViewItem(rd.RowNo.ToString());
                    li.SubItems.Add(rd.RegionName);
                    li.SubItems.Add(rd.SiteName);
                    li.SubItems.Add(rd.PatientOnTreatment.ToString());
                    li.SubItems.Add(rd.PatientOnPreTreatment.ToString());
                    li.SubItems.Add(rd.EverStartedPonT.ToString());
                    li.SubItems.Add(rd.EverStartedPonPreT.ToString());
                    li.SubItems.Add(rd.Vct.ToString());
                    li.SubItems.Add(rd.CD4.ToString());
                    li.SubItems.Add(rd.Chemistry.ToString());
                    li.SubItems.Add(rd.Hematology.ToString());
                    li.SubItems.Add(rd.ViralLoad.ToString());
                    li.SubItems.Add(rd.OtherTest.ToString());
                    li.SubItems.Add(rd.Consumable.ToString());
                    li.SubItems.Add(rd.IsExist ? "Yes" : "No");
                    li.SubItems.Add(rd.ErrorDescription);

                    if (rd.HasError)
                    {
                        li.BackColor = Color.Red;
                    }
                    else if (rd.IsExist)
                    {
                        li.BackColor = Color.Green;
                    }
                    lvImport.Items.Add(li);
                }

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
            var count = 0;
            try
            {
                foreach (var ims in _rdata.Where(ims => !ims.HasError))
                {
                    count++;
                    var artsite = new ARTSite
                    {
                        Site = ims.Site,
                        MorbidityCategory = ims.MCategory,
                        ForecastCD4 = ims.CD4 > 0,
                        ForecastChemistry = ims.Chemistry > 0,
                        ForecastHematology = ims.Hematology > 0,
                        ForecastViralLoad = ims.ViralLoad > 0,
                        ForecastOtherTest = ims.OtherTest > 0,
                        ForecastConsumable = ims.Consumable > 0,
                        ForecastVCT = ims.Vct > 0,
                        TimeZeroPatientOnTreatment = ims.PatientOnTreatment,
                        TimeZeroPatientOnPreTreatment = ims.PatientOnPreTreatment,
                        EverSTimeZeroPatientOnTreatment = ims.EverStartedPonT,
                        EverSTimeZeroPatientOnPreTreatment = ims.EverStartedPonPreT
                    };

                    _artSites.Add(artsite);
                }

                PerformAddition();
                _forecast.TimeZeroPatientOnTreatment = _sumofTimeZeroPatientOnTreatment;
                _forecast.TimeZeroPatientOnPreTreatment = _sumofTimeZeroPatientOnPreTreatment;

                DataRepository.BatchSaveARTSite(_artSites);
                
                MessageBox.Show(count + " ART sites are imported and saved successfully.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Error: Unable to import and save ART sites data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();
            }
        }
        
        IDictionary<string, ImportedReagionOrCategory> _listOfImportedMCategorys = new Dictionary<string, ImportedReagionOrCategory>();
        private void AddImportedMCategory(ImportedReagionOrCategory mcat)
        {
            if (!_listOfImportedMCategorys.ContainsKey(mcat.RegionOrCatName))
                _listOfImportedMCategorys.Add(mcat.RegionOrCatName, mcat);
        }

        private IList<ImportSiteNumber> GetDataRow(DataSet ds)
        {
            var rowno = 0;
            IList<ImportSiteNumber> rdlist = new List<ImportSiteNumber>();
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rowno++;
                int pOnT,pOnPreT, everPonT, everPreT;
                
                if (!DatarowValueToInt(dr[2], out pOnT))
                    pOnT = 0;
                if (!DatarowValueToInt(dr[3], out pOnPreT))
                    pOnPreT = 0;
                if (!DatarowValueToInt(dr[4], out everPonT))
                    everPonT = 0;
                if (!DatarowValueToInt(dr[5], out everPreT))
                    everPreT = 0;
                string rname = Convert.ToString(dr[0]).ToUpper().Trim();

                int regionid = _regions.Any(x => x.RegionName.ToUpper() == rname)
                    ? _regions.Single(x => x.RegionName.ToUpper() == rname).Id
                    : 0;

                var rd = new ImportSiteNumber(rowno, regionid, Convert.ToString(dr[0]).Trim(), Convert.ToString(dr[1]).Trim(), pOnT, pOnPreT, everPonT, everPreT, Convert.ToString(dr[6]).Trim(), Convert.ToString(dr[7]).Trim(), Convert.ToString(dr[8]).Trim(), Convert.ToString(dr[9]).Trim(), Convert.ToString(dr[10]).Trim(), Convert.ToString(dr[11]).Trim(), Convert.ToString(dr[12]).Trim());
                
                if (!string.IsNullOrEmpty(Convert.ToString(dr[0])))
                    AddImportedMCategory(new ImportedReagionOrCategory(Convert.ToString(dr[0]).Trim()));

                rdlist.Add(rd);
            }

            var frm = new FrmAssignCat(_listOfImportedMCategorys, _forecast.MorbidityCategories);
            frm.ShowDialog();

            foreach (var rd in rdlist)
            { 
                if (!string.IsNullOrEmpty(rd.RegionName))
                {
                    rd.MCategory = _listOfImportedMCategorys[rd.RegionName.Trim()].MCategory;

                    if (!string.IsNullOrEmpty(rd.SiteName))
                    {
                        rd.Site = _forecast.UseRegionAsCat ? DataRepository.GetSiteByName(rd.SiteName, rd.MCategory.RegionId) : DataRepository.GetSiteByName(rd.SiteName,rd.RegionId);

                        if (rd.Site != null)
                        {
                            if (!IsSiteSelected(rd.Site.Id))
                            {
                                _selectedSiteId.Add(rd.Site.Id);
                                if (rd.Vct < 0 || rd.CD4 < 0 || rd.Chemistry < 0 || rd.Hematology < 0 || rd.ViralLoad < 0 || rd.Consumable < 0 || rd.OtherTest< 0)
                                {
                                    rd.HasError = true;
                                    rd.ErrorDescription = "Error: there is invalid value in CVT to Consumables";
                                }
                                
                            }
                            else
                            {
                                rd.HasError = true;
                                rd.ErrorDescription = "Error:ART site already exist.";
                            }

                        }
                        else
                        {
                            rd.HasError = true;
                            rd.ErrorDescription = "Error: unable to found ART site";
                        }
                    }
                    else
                    {
                        rd.HasError = true;
                        rd.ErrorDescription = "Error: ART site name is empty";
                    }
                }
                else
                {
                    rd.HasError = true;
                    rd.ErrorDescription = "Error: Category/Region name is empty";
                }
            }

            return rdlist;
        }

        private bool DatarowValueToInt(object drvalue, out int result)
        {
            return int.TryParse(Convert.ToString(drvalue), out result);
        }

        private void PerformAddition()
        {
            _sumofTimeZeroPatientOnTreatment = 0;
            _sumofTimeZeroPatientOnPreTreatment = 0;
            foreach (var site in _artSites)
            {
                _sumofTimeZeroPatientOnTreatment += site.TimeZeroPatientOnTreatment;
                _sumofTimeZeroPatientOnPreTreatment += site.TimeZeroPatientOnPreTreatment;
            }
        }
        
        private class ImportSiteNumber
        {
            public ImportSiteNumber(int rowno,int regionId, string regionname, string sitename, int patientonT, int patientonPreT, int everstartedPonT, int everstartedPonPreT, string vct, string cd4, string chem, string hem, string vl, string other, string con)
            {
                IsExist = false;
                HasError = false;
                RowNo = rowno;
                RegionId = regionId;
                RegionName = regionname;
                SiteName = sitename;
                PatientOnTreatment = patientonT;
                PatientOnPreTreatment = patientonPreT;
                EverStartedPonT = everstartedPonT;
                EverStartedPonPreT = everstartedPonPreT;
                Vct = StringToInt(vct);
                CD4 = StringToInt(cd4);
                Chemistry = StringToInt(chem);
                Hematology = StringToInt(hem);
                ViralLoad = StringToInt(vl);
                OtherTest = StringToInt(other);
                Consumable = StringToInt(con);
            }

            public int RegionId { get; set; }
            public string RegionName { get; private set; }

            public string SiteName { get; private set; }

            public ARTSite ArtSite { get; set; }

            public ForlabSite Site { get; set; }

            public MorbidityCategory MCategory { get; set; }

            private static int StringToInt(string val)
            {
                if (string.IsNullOrEmpty( val))
                    return 0;
                if (val == "y" || val == "Y")
                    return 1;
                if (val == "n"||val=="N")
                    return 0;
                return -1;
            }

            public int PatientOnTreatment { get; private set; }

            public int PatientOnPreTreatment { get; private set; }

            public int EverStartedPonT { get; private set; }

            public int EverStartedPonPreT { get; private set; }

            public int Vct { get; private set; }

            public int CD4 { get; private set; }

            public int Chemistry { get; private set; }

            public int Hematology { get; private set; }

            public int ViralLoad { get; private set; }

            public int OtherTest { get; private set; }

            public int Consumable { get; private set; }

            public int RowNo { get; private set; }

            public bool HasError { get; set; }

            public bool IsExist { get; set; }

            public string ErrorDescription { get; set; }
        }

    }

    public class ImportedReagionOrCategory
    {
        public ImportedReagionOrCategory(string catName)
        {
            RegionOrCatName = catName;
        }

        public string RegionOrCatName { get; private set; }

        public MorbidityCategory MCategory { get; set; }
    }
}
