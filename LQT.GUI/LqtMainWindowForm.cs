
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Location;
using LQT.GUI.Asset;
using LQT.GUI.Testing;
using LQT.GUI.Quantification;
using LQT.GUI.UserCtr;
using LQT.GUI.Reports;
using LQT.GUI.Tools;

using LQT.Core;
using LQT.GUI.ReportBorwser;
using LQT.GUI.ReportParameterUserCtr;
using System.Reflection;


namespace LQT.GUI
{
    public partial class LqtMainWindowForm : Form
    {
        private BaseUserControl _currentUserCtr;
        private RptBaseUserControl _ReportParamUserCtr;

        public LqtMainWindowForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            Initialize();
            Cursor.Current = Cursors.Default;
        }

        private void Initialize()
        {
            // Display version
            toolBarLblVersion.Text = String.Format(" {0}", LQT.Core.AppSettings.SoftwareVersion);
            mainStatusBarLblDate.Text = DateTime.Now.ToString();

            BuildNavigationMenu();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                showHelp();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Build left panel navigation section................................................

        public void BuildNavigationMenu()
        {
            treeViewNav.Nodes.Clear();

            treeViewNav.SelectedNode = null;

            //add dash board menu
            TreeNode rootNode = new TreeNode("Dash Board");
            rootNode.Tag = MainMenuTag.DASHBOARD.ToString();
            rootNode.ImageIndex = 1;
            rootNode.SelectedImageIndex = 1;
            treeViewNav.Nodes.Add(rootNode);
            BuildSettingsMenu();
            //BuildTestMenu();
            //BuildProductMenu();
            //BuildInstrumentMenu();
            //BuildProtocolMenus();
            //BuildLoactionMenu();
            BuildMethodologyMenu();
        }

        private void BuildSettingsMenu()
        {
            TreeNode rootNode = new TreeNode("Settings");
            rootNode.Tag = MainMenuTag.SETTINGS.ToString();
            rootNode.ImageIndex = 2;
            rootNode.SelectedImageIndex = 2;

            TreeNode generalNode = new TreeNode("General Settings");
            generalNode.Tag = MainMenuTag.SETTINGS.ToString();
            generalNode.ImageIndex = 2;
            generalNode.SelectedImageIndex = 2;
            generalNode.ToolTipText = "These settings applies for all methodologies.";
            rootNode.Nodes.Add(generalNode);

            TreeNode consumptionNode = new TreeNode("Consumption Settings");
            consumptionNode.Tag = MainMenuTag.SETTINGS.ToString();
            consumptionNode.ImageIndex = 2;
            consumptionNode.SelectedImageIndex = 2;
            rootNode.Nodes.Add(consumptionNode);

            TreeNode servicNode = new TreeNode("Service Statistic Settings");
            servicNode.Tag = MainMenuTag.SETTINGS.ToString();
            servicNode.ImageIndex = 2;
            servicNode.SelectedImageIndex = 2;
            rootNode.Nodes.Add(servicNode);

            TreeNode morbidityNode = new TreeNode("Morbidity Settings");
            morbidityNode.Tag = MainMenuTag.SETTINGS.ToString();
            morbidityNode.ImageIndex = 2;
            morbidityNode.SelectedImageIndex = 2;
            rootNode.Nodes.Add(morbidityNode);

            BuildTestMenu(generalNode);
            BuildProductMenu(generalNode);
            BuildInstrumentMenu(generalNode);
            BuildLoactionMenu(generalNode);

            BuildProtocolMenu(morbidityNode);
            BuildRapidTestMenu(morbidityNode);
            
            treeViewNav.Nodes.Add(rootNode);
        }

        private void BuildTestMenu(TreeNode parentNode)
        {
            IList<TestingArea> list = DataRepository.GetAllTestingArea();
            
            //added just for this build will be optimized later on
            IList<TestingGroup> listtg = DataRepository.GetAllTestingGroup();
            IList<Test> listtc = DataRepository.GetAllTests();

            TreeNode rootNode = new TreeNode("Test Profile");
            rootNode.Tag = MainMenuTag.TEST.ToString();
            rootNode.ImageIndex = 2;
            rootNode.SelectedImageIndex = 2;

            TreeNode tareaNode = new TreeNode("Testing Areas ["+list.Count+"]");
            tareaNode.Tag = MainMenuTag.TEST.ToString() + "|" + -1;
            tareaNode.ImageIndex = 3;
            tareaNode.SelectedImageIndex = 3;
            rootNode.Nodes.Add(tareaNode);
            
            TreeNode tgroupNode = new TreeNode("Testing Groups ["+listtg.Count+"]");
            tgroupNode.Tag = MainMenuTag.TEST.ToString() + "|" + -2;
            tgroupNode.ImageIndex = 4;
            tgroupNode.SelectedImageIndex = 4;
            rootNode.Nodes.Add(tgroupNode);

            TreeNode testNode = new TreeNode("Tests ["+listtc.Count+"]");
            testNode.Tag = MainMenuTag.TEST.ToString() + "|" + -3;
            testNode.ImageIndex = 5;
            testNode.SelectedImageIndex = 5;


            
            foreach (TestingArea ta in list)
            {
                if (!ta.UseInDemography)
                {
                    TreeNode node = new TreeNode(ta.AreaName);
                    node.Tag = MainMenuTag.TEST.ToString() + "|-4|" + ta.Id;
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                    AddTestingGroupToMenu(node, ta.TestingGroups);
                    testNode.Nodes.Add(node);
                }
            }
            rootNode.Nodes.Add(testNode);

            ClassOfMorbidityTestEnum[] mtestEnums = LqtUtil.EnumToArray<ClassOfMorbidityTestEnum>();
            TreeNode artNode = new TreeNode("ART Tests");
            artNode.Tag = MainMenuTag.TEST.ToString() + "|" + -6;
            artNode.ImageIndex = 5;
            artNode.SelectedImageIndex = 5;

            
            for (int i = 0; i < mtestEnums.Length; i++)
            {
                ClassOfMorbidityTestEnum cm = mtestEnums[i];
                TreeNode node = new TreeNode(cm.ToString());
                node.Tag = MainMenuTag.TEST.ToString() + "|-6|" + (int)cm;
                node.ImageIndex = 4;
                node.SelectedImageIndex = 4;
                //AddTestingGroupToMenu(node, ta.TestingGroups);
                artNode.Nodes.Add(node);
            }

            rootNode.Nodes.Add(artNode);
            //rootNode.Expand();
            parentNode.Nodes.Add(rootNode);
            //treeViewNav.Nodes.Add(rootNode);
        }

        private void BuildProductMenu(TreeNode parentNode)
        {
            IList<MasterProduct> plist = DataRepository.GetAllProduct();

            TreeNode rootNode = new TreeNode("Product Profile");
            rootNode.Tag = MainMenuTag.PRODUCT.ToString();
            rootNode.ImageIndex = 6;
            rootNode.SelectedImageIndex = 6;


            TreeNode typeNode = new TreeNode("Product Types");
            typeNode.Tag = MainMenuTag.PRODUCT.ToString() + "|-1";
            typeNode.ImageIndex = 7;
            typeNode.SelectedImageIndex = 7;
            rootNode.Nodes.Add(typeNode);

            TreeNode proNode = new TreeNode("Products ["+plist.Count+"]");
            proNode.Tag = MainMenuTag.PRODUCT.ToString() + "|-2";
            proNode.ImageIndex = 8;
            proNode.SelectedImageIndex = 8;

            int ptcount = 0;
            foreach (ProductType r in DataRepository.GetAllProductType())
            {
                TreeNode node = new TreeNode(r.TypeName);
                node.Tag = MainMenuTag.PRODUCT.ToString() + "|-3|" + r.Id;
                node.ImageIndex = 7;
                node.SelectedImageIndex = 7;
                proNode.Nodes.Add(node);
                ptcount++;
            }
            typeNode.Text = typeNode.Text + "[" + ptcount + "]";

            rootNode.Nodes.Add(proNode);
            parentNode.Nodes.Add(rootNode);

            //treeViewNav.Nodes.Add(rootNode);

        }

        private void BuildInstrumentMenu(TreeNode parentNode)
        {
            IList<Instrument> ilist = DataRepository.GetAllInstrument();

            TreeNode rootNode = new TreeNode("Instruments ["+ ilist.Count+"]");
            rootNode.Tag = MainMenuTag.INSTRUMENT.ToString();
            rootNode.ImageIndex = 9;
            rootNode.SelectedImageIndex = 9;
            parentNode.Nodes.Add(rootNode);
            //treeViewNav.Nodes.Add(rootNode);
        }

        private void BuildProtocolMenu(TreeNode parentNode)
        {
            TreeNode rootNode = new TreeNode("Protocols");
            rootNode.Tag = MainMenuTag.PROTOCOLS.ToString();
            rootNode.ImageIndex = 10;
            rootNode.SelectedImageIndex = 10;
            parentNode.Nodes.Add(rootNode);
            //treeViewNav.Nodes.Add(rootNode);
        }

        private void BuildRapidTestMenu(TreeNode parentNode)
        {
            TreeNode rootNode = new TreeNode("Rapid Test Specification");
            rootNode.Tag = MainMenuTag.RAPIDTEST.ToString();
            rootNode.ImageIndex = 10;
            rootNode.SelectedImageIndex = 10;
            parentNode.Nodes.Add(rootNode);
            //treeViewNav.Nodes.Add(rootNode);
        }
       
        private void BuildLoactionMenu(TreeNode parentNode)
        {
            IList<ForlabSite> slist = DataRepository.GetAllSite();

            TreeNode rootNode = new TreeNode("Laboratory Profile");
            rootNode.Tag = MainMenuTag.LOCATION.ToString();
            rootNode.ImageIndex = 11;
            rootNode.SelectedImageIndex = 11;


            TreeNode regNode = new TreeNode("Regions/Districts/Provinces");
            regNode.Tag = MainMenuTag.LOCATION.ToString() + "|" + -1;
            regNode.ImageIndex = 12;
            regNode.SelectedImageIndex = 12;
            rootNode.Nodes.Add(regNode);

            TreeNode sitecNode = new TreeNode("Site Category");
            sitecNode.Tag = MainMenuTag.LOCATION.ToString() + "|-4";
            sitecNode.ImageIndex = 0;
            sitecNode.SelectedImageIndex = 0;
            rootNode.Nodes.Add(sitecNode);

            TreeNode siteNode = new TreeNode("Sites ["+slist.Count+"]");
            siteNode.Tag = MainMenuTag.LOCATION.ToString() + "|-2";
            siteNode.ImageIndex = 13;
            siteNode.SelectedImageIndex = 13;

            int regioncount = 0;
            foreach (ForlabRegion r in DataRepository.GetAllRegion())
            {
                regioncount++;
                TreeNode node = new TreeNode(r.RegionName);
                node.Tag = MainMenuTag.LOCATION.ToString() + "|-3|" + r.Id;
                node.ImageIndex = 12;
                node.SelectedImageIndex = 12;
                siteNode.Nodes.Add(node);
            }
            regNode.Text = regNode.Text + " [" + regioncount + "]";

            rootNode.Nodes.Add(siteNode);
            parentNode.Nodes.Add(rootNode);
            //rootNode.Expand();
            //treeViewNav.Nodes.Add(rootNode);
        }

        private void BuildMethodologyMenu()
        {
            TreeNode rootNode = new TreeNode("Quantification Process");
            rootNode.Tag = MainMenuTag.METHODOLOGY.ToString();
            rootNode.ImageIndex = 14;
            rootNode.SelectedImageIndex = 14;

            TreeNode conNode = new TreeNode("Consumption Methodology");
            conNode.Tag = MainMenuTag.METHODOLOGY.ToString() + "|-1";
            conNode.ImageIndex = 15;
            conNode.SelectedImageIndex = 15;
            rootNode.Nodes.Add(conNode);

            TreeNode serNode = new TreeNode("Service Statistic Methodology");
            serNode.Tag = MainMenuTag.METHODOLOGY.ToString() + "|-2";
            serNode.ImageIndex = 15;
            serNode.SelectedImageIndex = 15;
            rootNode.Nodes.Add(serNode);

            TreeNode typeNode = new TreeNode("Morbidity Methodology");
            typeNode.Tag = MainMenuTag.METHODOLOGY.ToString() + "|-3";
            typeNode.ImageIndex = 15;
            typeNode.SelectedImageIndex = 15;
            rootNode.Nodes.Add(typeNode);

            rootNode.Expand();
            treeViewNav.Nodes.Add(rootNode);
        }

        private void AddTestingGroupToMenu(TreeNode parentNode, IList<TestingGroup> list)
        {
            foreach (TestingGroup tg in list)
            {
                TreeNode node = new TreeNode(tg.GroupName);
                node.Tag = MainMenuTag.TEST.ToString() + "|-5|" + tg.Id;
                node.ImageIndex = 4;
                node.SelectedImageIndex = 4;
                parentNode.Nodes.Add(node);
            }
        }

        private void treeViewNav_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] tag = e.Node.Tag.ToString().Split(new char[] { '|' });
            MainMenuTag mtag = (MainMenuTag)Enum.Parse(typeof(MainMenuTag), tag[0]);
            e.Node.Expand();
            int mid;

            switch (mtag)
            {
                case MainMenuTag.LOCATION:
                    if (tag.Length > 1)
                    {
                        mid = int.Parse(tag[1]);
                        if (mid == -1)
                        {
                            this._currentUserCtr = new ListRegionPane();
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -2)
                        {
                            this._currentUserCtr = new ListSitePane(0);
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -3)
                        {
                            this._currentUserCtr = new ListSitePane(int.Parse(tag[2]));
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -4)
                        {
                            this._currentUserCtr = new ListSiteCatPane();
                            LoadCurrentUserCtr();
                        }
                    }
                    else
                    {
                        this._currentUserCtr = new ChartSiteperRegion();
                        LoadCurrentUserCtr();
                    }
                    break;
                case MainMenuTag.SETTINGS:                    
                    break;
                case MainMenuTag.TEST:
                    if (tag.Length > 1)
                    {
                        mid = int.Parse(tag[1]);
                        if (mid == -1)
                        {
                            this._currentUserCtr = new ListTestingAreaPane();
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -2)
                        {
                            this._currentUserCtr = new ListTestingGroupPane();
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -3)
                        {
                            this._currentUserCtr = new ListTestPane(FiliterTestByEnum.All, 0);
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -4)
                        {
                            this._currentUserCtr = new ListTestPane(FiliterTestByEnum.TestArea, int.Parse(tag[2]));
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -5)
                        {
                            this._currentUserCtr = new ListTestPane(FiliterTestByEnum.TestGroup, int.Parse(tag[2]));
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -6)
                        {
                            if (tag.Length > 2)
                            {
                                ClassOfMorbidityTestEnum mtest = (ClassOfMorbidityTestEnum)Enum.ToObject(typeof(ClassOfMorbidityTestEnum), int.Parse(tag[2]));
                                if (int.Parse(tag[2]) <= 4)
                                {
                                    this._currentUserCtr = new ListMorbidityTestPane(mtest);
                                }
                                else
                                {
                                    this._currentUserCtr = new ListSupplyListPane(mtest);
                                }

                                LoadCurrentUserCtr();
                            }
                        }
                    }
                    else
                    {
                        this._currentUserCtr = new ChartTestperArea();
                        LoadCurrentUserCtr();
                    }
                    break;
                case MainMenuTag.PRODUCT:
                    if (tag.Length > 1)
                    {
                        mid = int.Parse(tag[1]);
                        if (mid == -1)
                        {
                            this._currentUserCtr = new ListProductTypePane();
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -2)
                        {
                            this._currentUserCtr = new ListProductPane(0);
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -3)
                        {
                            this._currentUserCtr = new ListProductPane(int.Parse(tag[2]));
                            LoadCurrentUserCtr();
                        }
                    }
                    else
                    {
                        this._currentUserCtr = new ProductNoperCat();
                        LoadCurrentUserCtr();
                    }
                    break;
                case MainMenuTag.INSTRUMENT:
                    this._currentUserCtr = new ListInstrumentPane();
                    LoadCurrentUserCtr();
                    break;
                case MainMenuTag.METHODOLOGY:
                    if (tag.Length > 1)
                    {
                        mid = int.Parse(tag[1]);
                        if (mid == -1)
                        {
                            this._currentUserCtr = new ListConsumptionPane(MethodologyEnum.CONSUMPTION);
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -2)
                        {
                            this._currentUserCtr = new ListConsumptionPane(MethodologyEnum.SERVICE_STATISTIC);
                            LoadCurrentUserCtr();
                        }
                        else if (mid == -3)
                        {
                            this._currentUserCtr = new ListMorbidityPane();
                            LoadCurrentUserCtr();
                        }
                    }
                    break;
                case MainMenuTag.DASHBOARD:
                    this._currentUserCtr = new DashBoard();
                    LoadCurrentUserCtr();
                    break;
                case MainMenuTag.PROTOCOLS:

                    this._currentUserCtr = new ListProtocolPane();
                    LoadCurrentUserCtr();
                    break;
                case MainMenuTag.RAPIDTEST:

                    //this._currentUserCtr = new ListProtocolPane();
                    //LoadCurrentUserCtr();
                    RapidTestForm frm = new RapidTestForm();
                    frm.ShowDialog();
                    break;
            }
        }

        private void LoadCurrentUserCtr()
        {
            SetEditButtonsStatus(false);

            this.tlpMainPanel.Controls.Clear();
            _currentUserCtr.MdiParentForm = this;
            _currentUserCtr.Dock = DockStyle.Fill;
            _currentUserCtr.OnSelectedItemChanged += new EventHandler(_currentUserCtr_OnSelectedItemChanged);
            this.lblTitle.Text = _currentUserCtr.GetControlTitle;
            this.tlpMainPanel.Controls.Add(_currentUserCtr);
        }

        private void LoadReportParamUserCtr()
        {
            this.tlpMainPanel.Controls.Clear();
            _ReportParamUserCtr.MdiParentForm = this;
            _ReportParamUserCtr.Dock = DockStyle.Top;
            _ReportParamUserCtr.BackColor = Control.DefaultBackColor;
            this.lblTitle.Text = _ReportParamUserCtr.GetControlTitle;
            this.tlpMainPanel.Controls.Add(_ReportParamUserCtr);
        }

        private void _currentUserCtr_OnSelectedItemChanged(object sender, EventArgs e)
        {
            if (sender is ListView)
            {
                ListView lv = (ListView)sender;
                if (lv.SelectedItems.Count > 0)
                {
                    SetEditButtonsStatus(true);
                }
                else
                {
                    SetEditButtonsStatus(false);
                }
            }
            else
            {
                SetEditButtonsStatus(false);
            }
        }

        #endregion

        #region Tool-strip button actions...........................................................

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (_currentUserCtr != null)
            {
                _currentUserCtr.EditSelectedItem();
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (_currentUserCtr != null)
            {
                SetEditButtonsStatus(!_currentUserCtr.DeleteSelectedItem());
            }
        }

        private void tsbReport_Click(object sender, EventArgs e)
        {
            //FrmReportBrowser frm = new FrmReportBrowser();
            //frm.ShowDialog();
            this._currentUserCtr = null;

            SetEditButtonsStatus(false);

            ListReport lr = new ListReport();

            this.tlpMainPanel.Controls.Clear();
            //lr.MdiParentForm = this;
            lr.Dock = DockStyle.Fill;
            //.OnSelectedItemChanged += new EventHandler(_currentUserCtr_OnSelectedItemChanged);
            this.lblTitle.Text = "List of reports";
            this.tlpMainPanel.Controls.Add(lr);
        }

        private void tsbForecast_Click(object sender, EventArgs e)
        {
            ForecastForm frm = new ForecastForm();
            frm.ShowDialog();
        }

        #endregion

        #region Menustrip button action............................................................

        private void newRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegionForm frm = new RegionForm(new ForlabRegion(), this);
            frm.ShowDialog();
        }

        private void newSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiteForm frm = new SiteForm(new ForlabSite(), this);
            frm.ShowDialog();
        }

        private void searchSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmSearchSite(this).ShowDialog();
        }

        private void newProductTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductTypeForm frm = new ProductTypeForm(new ProductType(), this);
            frm.ShowDialog();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm(new MasterProduct(), this);
            frm.ShowDialog();
        }

        private void searchProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmSearchProduct(this).ShowDialog();
        }

        private void newInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstrumentForm frm = new InstrumentForm(new Instrument(), this);
            frm.ShowDialog();
        }

        private void newTestingAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestingAreaFrom frm = new TestingAreaFrom(new TestingArea(), this);
            frm.ShowDialog();
        }

        private void newTestingGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestingGroupFrom frm = new TestingGroupFrom(new TestingGroup(), this);
            frm.ShowDialog();
        }

        private void newTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestFrom frm = new TestFrom(new Test(), this);
            frm.ShowDialog();
        }

        private void backupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAdvanceSetting(FrmDatabaseSettingsEnum.SqlServerSettings, false, true);
            frm.ShowDialog();
        }

        private void aboutLQTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void importRegionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportRegion frm = new FrmImportRegion();
            frm.ShowDialog();
        }

        private void importSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportSite frm = new FrmImportSite(0);
            frm.ShowDialog();
        }

        private void importSitesInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportSiteInstrument frm = new FrmImportSiteInstrument(1);
            frm.ShowDialog();
        }

        private void importProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportPro frm = new FrmImportPro();
            frm.ShowDialog();
        }

        private void importInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportIns frm = new FrmImportIns();
            frm.ShowDialog();
        }

        private void importTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportTest frm = new FrmImportTest();
            frm.ShowDialog();
        }

        private void importProductUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportProUsage frm = new FrmImportProUsage();
            frm.ShowDialog();
        }

        private void siteCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiteCategoryForm frm = new SiteCategoryForm();
            frm.ShowDialog();
        }

        private void chartTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LQT.GUI.ReportBorwser.frmRptViewer frm = new ReportBorwser.frmRptViewer();
            //frm.ShowDialog();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void getImportTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Specify Destination Filename";
                saveFileDialog1.FileName = "ImportTemplate.xls";
                saveFileDialog1.Filter = "Execl files (*.xls)|*.xls";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.OverwritePrompt = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))//LqtUtil.GetFolderPath(AppSettings.ExportPath) + "\\ImportTemplate.xls", FileMode.Create))
                    {
                        Stream xstream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LQT.GUI.Resources.ImportTemplate.xls");

                        byte[] b = new byte[xstream.Length + 1];
                        xstream.Read(b, 0, Convert.ToInt32(xstream.Length));

                        fs.Write(b, 0, Convert.ToInt32(b.Length - 1));
                        fs.Flush();
                        fs.Close();


                    }
                    MessageBox.Show("Exported Successfully!");
                }
                // + Environment.NewLine + "To:- " + LqtUtil.GetFolderPath(AppSettings.ExportPath) + "\\ImportTemplate.xls");

            }
            catch
            {
                MessageBox.Show("Access Denied. ", "Template Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsRapidTestAlgorithm_Click(object sender, EventArgs e)
        {
            new RapidTestForm().ShowDialog();
        }

        private void regionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new RegionListParam();
            LoadReportParamUserCtr();
        }

        private void siteListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new SiteListParam();
            LoadReportParamUserCtr();
        }

        private void siteInstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new SiteInstrumentListParam();
            LoadReportParamUserCtr();
        }

        private void instrumentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new InstrumentListParam();
            LoadReportParamUserCtr();
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new ProductListParam();
            LoadReportParamUserCtr();
        }

        private void productPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new ProductListParam(true);
            LoadReportParamUserCtr();
        }

        private void testListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new TestListParam();
            LoadReportParamUserCtr();
        }

        private void testProductUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new ProductUsageParam();
            LoadReportParamUserCtr();
        }

        private void forecastComparisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new ComparisionReportParam();
            LoadReportParamUserCtr();
        }

        private void morbidityForecastCostSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new MorbidityCostSReportParam();
            LoadReportParamUserCtr();
        }

        private void morbidityForecastNoOfPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new MorbidityNoPatientReportParam();
            LoadReportParamUserCtr();
        }

        private void morbidityForecastNoOfTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._ReportParamUserCtr = new MorbidityNoofTestReportParam();
            LoadReportParamUserCtr();
        }

        private void importQuantificationVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportQMenu frm = new FrmImportQMenu();
            frm.ShowDialog();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showHelp();
        }

        #endregion

        #region Methods ...........................................................................

        private void SetEditButtonsStatus(bool status)
        {
            tsbEdit.Enabled = status;
            tsbDelete.Enabled = status;
        }

        public void ShowStatusBarInfo(string msg)
        {
            mainStatusBarLblInfo.Text = msg;
        }

        public void ShowStatusBarInfo(string msg, bool reloadUserCtr)
        {
            mainStatusBarLblInfo.Text = msg;
            if (reloadUserCtr)
            {
                if (_currentUserCtr != null)
                    _currentUserCtr.ReloadUserCtrContents();
            }
        }

        //public void ExcelHeaderFormatt(Excel.Range unicell)
        //{
        //    unicell.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.White);
        //    unicell.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Gray);
        //    unicell.Font.Bold = true;
        //    unicell.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
        //}

        private void showHelp()
        {
            string path = LqtUtil.GetFolderPath(AppSettings.ExportPath);
            if (!File.Exists(path + "\\ForLAB.chm"))
            {
                GenerateHelp();
            }
            path = "file://" + Path.Combine(path, "ForLAB.chm");

            Help.ShowHelp(this, path);
        }

        public void GenerateHelp()
        {
            try
            {

                using (FileStream fs = new FileStream(LqtUtil.GetFolderPath(AppSettings.ExportPath) + "\\ForLAB.chm", FileMode.Create))
                {
                    Stream xstream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LQT.GUI.Resources.ForLAB.chm");

                    byte[] b = new byte[xstream.Length + 1];
                    xstream.Read(b, 0, Convert.ToInt32(xstream.Length));

                    fs.Write(b, 0, Convert.ToInt32(b.Length - 1));
                    fs.Flush();
                    fs.Close();


                }

            }
            catch
            {
                MessageBox.Show("Access Denied. ", "Generate Help File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void referalSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportRefSite frm = new FrmImportRefSite(0);
            frm.ShowDialog();
        
        }

    }
}
