
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.UserCtr;
using LQT.Core.UserExceptions;
using LQT.GUI.MorbidityUserCtr;

namespace LQT.GUI.MorbidityProtocolSetting
{
    public partial class FrmProtocol : Form
    {
        private ClassOfMorbidityTestEnum _classOfTest;
        private Protocol _protocol;
        private Form _mdiparent;
        private bool _isedited = false;

        private ProtocolPanel _cd4Panel;
        private SiteListView _cd4ListView;
        private SiteListView _chemListView;
        private SiteListView _othListView;

        public FrmProtocol(ClassOfMorbidityTestEnum classOfTest, Form mdiparent)
        {
            this._protocol = DataRepository.GetProtocolByPlatform((int)classOfTest);
            this._mdiparent = mdiparent;
            this._classOfTest = classOfTest;
            if (_protocol == null)
            {
                CreatNewProtocol();
            }
            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.DisableSaveAndNewButton();
            BindProtocol();
            SelectActiveTab();
        }

        private void BindProtocol()
        {
            txtprotocolcategory.Text = _classOfTest.ToString() + " Protocols";
            if (_protocol.Id > 0)
            {
                this.txtdescription.Text = _protocol.Descritpion;

                this.txtsymptomdirected.Text = _protocol.SymptomDirectedAmt.ToString();
                this.txttestsrepeated.Text = _protocol.TestReapeated.ToString();
                this.butNewpanel.Enabled = true;
            }
            else
                this.butNewpanel.Enabled = false;
            if (_protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.Chemistry || _protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.OtherTest)
            {
                lblsystemdirected.Visible = false;
                txtsymptomdirected.Visible = false;
            }
        }

        private void SelectActiveTab()
        {
            switch (_protocol.ProtocolTypeEnum)
            {
                case ClassOfMorbidityTestEnum.CD4:                    
                    tabControl1.TabPages.Remove(tabPanels);
                    tabControl1.TabPages.Remove(tabChem);
                    tabControl1.TabPages.Remove(tabOther);
                    BindCD4BloodSample();
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    tabControl1.TabPages.Remove(tabCD4);                    
                    tabControl1.TabPages.Remove(tabOther);
                    BindPanels();
                    BindChemSymptom();
                    break;
                case ClassOfMorbidityTestEnum.Hematology:
                case ClassOfMorbidityTestEnum.ViralLoad:
                    tabControl1.TabPages.Remove(tabCD4);
                    tabControl1.TabPages.Remove(tabChem);
                    tabControl1.TabPages.Remove(tabOther);
                    BindPanels();
                    break;
                case ClassOfMorbidityTestEnum.OtherTest:
                    tabControl1.TabPages.Remove(tabCD4);
                    tabControl1.TabPages.Remove(tabChem);
                    BindPanels();
                    BindOtherSymptom();
                    break;
            }
        }

        private void BindPanels()
        {
            lsvpanel.BeginUpdate();
            lsvpanel.Items.Clear();

            foreach (ProtocolPanel pp in _protocol.ProtocolPanels)
            {
                ListViewItem li = new ListViewItem(pp.PanelName) { Tag = pp };
                lsvpanel.Items.Add(li);
            }
            lsvpanel.EndUpdate();
            butDeletepanel.Enabled = false;
            butEditpanel.Enabled = false;
        }

        private void lsvpanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvpanel.SelectedItems.Count > 0)
            {
                this.butEditpanel.Enabled = true;
                this.butDeletepanel.Enabled = true;
            }
            else
            {
                this.butEditpanel.Enabled = false;
                this.butDeletepanel.Enabled = false;
            }
        }
        private string GetRowTitle(int rowno)
        {
            if (rowno == 1)
                return "Adults in Treatment";
            if (rowno == 2)
                return "Pediatrics in Treatment";
            if (rowno == 3)
                return "Adults pre-ART";

            return "Pediatrics pre-ART";
        }

        #region CD4
        private void BindCD4BloodSample()
        {
            InitCD4ListView();
            foreach (ProtocolPanel pp in _protocol.ProtocolPanels)
            {
                _cd4Panel = pp;
                for (int i = 1; i <= 4; i++)
                {
                    EXListViewItem li = new EXListViewItem(GetRowTitle(i)) { Tag = i };

                    for (int m = 1; m <= 12; m++)
                    {
                        if (i == 1)
                            li.SubItems.Add(new EXListViewSubItem(pp.AdultArtTestGivenInMonth(m).ToString(), m));
                        else if (i == 2)
                            li.SubItems.Add(new EXListViewSubItem(pp.PediatricArtTestGivenInMonth(m).ToString(), m));
                        else if (i == 3)
                            li.SubItems.Add(new EXListViewSubItem(pp.AdultPreArtTestGivenInMonth(m).ToString(), m));
                        else
                            li.SubItems.Add(new EXListViewSubItem(pp.PediatricPreArtTestGivenInMonth(m).ToString(), m));
                    }

                    if (i == 1)
                        li.SubItems.Add(new EXListViewSubItem(pp.AITTestperYear.ToString(), 13));
                    else if (i == 2)
                        li.SubItems.Add(new EXListViewSubItem(pp.PITTestperYear.ToString(), 13));
                    else if (i == 3)
                        li.SubItems.Add(new EXListViewSubItem(pp.APARTestperYear.ToString(), 13));
                    else if (i == 4)
                        li.SubItems.Add(new EXListViewSubItem(pp.PPARTTestperYear.ToString(), 13));

                    _cd4ListView.Items.Add(li);
                }
                break;
            }
        }

        private void InitCD4ListView()
        {
            _cd4ListView = new SiteListView();
            _cd4ListView.MySortBrush = SystemBrushes.ControlLight;
            _cd4ListView.MyHighlightBrush = Brushes.Goldenrod;
            _cd4ListView.GridLines = true;
            _cd4ListView.MultiSelect = false;
            _cd4ListView.Dock = DockStyle.Fill;
            _cd4ListView.ControlPadding = 4;
            _cd4ListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            //add columns and items
            EXEditableColumnHeader exEditCol = new EXEditableColumnHeader("", 120);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month1", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month2", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month3", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month4", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month5", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month6", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month7", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month8", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month9", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month10", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month11", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Month12", 60);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Tests/ year after month 12", 100);
            _cd4ListView.Columns.Add(exEditCol);

            _cd4ListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_cd4ListView_EditableListViewSubitemValueChanged);

            tabCD4.Controls.Add(_cd4ListView);
        }

        private void _cd4ListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            int rowid = (int)e.ListVItem.Tag;
            int month = (int)e.SubItem.ColumnName;
            try
            {
                //int value = Convert.ToInt32(e.SubItem.Text);
                if (rowid == 1)
                {
                    if (month < 13)
                        _cd4Panel.SetAdultArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else
                        _cd4Panel.AITTestperYear = Convert.ToDouble(e.SubItem.Text);
                }
                else if (rowid == 2)
                {
                    if (month < 13)
                        _cd4Panel.SetPediatricArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else
                        _cd4Panel.PITTestperYear = Convert.ToDouble(e.SubItem.Text);
                }
                else if (rowid == 3)
                {
                    if (month < 13)
                        _cd4Panel.SetAdultPreArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else
                        _cd4Panel.APARTestperYear = Convert.ToDouble(e.SubItem.Text);
                }
                else
                {
                    if (month < 13)
                        _cd4Panel.SetPediatricPreArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else
                        _cd4Panel.PPARTTestperYear = Convert.ToDouble(e.SubItem.Text);
                }
            }
            catch
            {
            }
        }

        #endregion

        #region chemistry

        private void BindChemSymptom()
        {
            InitChemListView();
            
            ChemistryTestNameEnum[] tname = LqtUtil.EnumToArray<ChemistryTestNameEnum>();
            for (int i = 1; i <= 4; i++)
            {
                EXListViewItem li = new EXListViewItem(GetRowTitle(i)) { Tag = i };

                for (int m = 0; m < tname.Length; m++)
                {
                    PSymptomDirectedTest pdt = _protocol.GetSymptomDirectedTestByTestName(tname[m]);
                    if (i == 1)
                        li.SubItems.Add(new EXListViewSubItem(pdt.AdultInTreatmeant.ToString(), tname[m]));
                    else if (i == 2)
                        li.SubItems.Add(new EXListViewSubItem(pdt.PediatricInTreatmeant.ToString(), tname[m]));
                    else if (i == 3)
                        li.SubItems.Add(new EXListViewSubItem(pdt.AdultPreART.ToString(), tname[m]));
                    else
                        li.SubItems.Add(new EXListViewSubItem(pdt.PediatricPreART.ToString(), tname[m]));
                }

                _chemListView.Items.Add(li);
            }
        }

        private void InitChemListView()
        {
            _chemListView = new SiteListView();
            _chemListView.MySortBrush = SystemBrushes.ControlLight;
            _chemListView.MyHighlightBrush = Brushes.Goldenrod;
            _chemListView.GridLines = true;
            _chemListView.MultiSelect = false;
            _chemListView.Dock = DockStyle.Fill;
            _chemListView.ControlPadding = 4;
            _chemListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            //add columns and items
            
            EXColumnHeader exEditCol = new EXColumnHeader("", 120);
            _chemListView.Columns.Add(exEditCol);
            
            string[] testname = Enum.GetNames(typeof(ChemistryTestNameEnum));
            for (int i = 0; i < testname.Length; i++)
            {
               EXEditableColumnHeader  exCol = new EXEditableColumnHeader(testname[i].Replace('_',' '), 60);
                _chemListView.Columns.Add(exCol);
            }

            _chemListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_chemListView_EditableListViewSubitemValueChanged);

            tabChem.Controls.Add(_chemListView);
        }

        void _chemListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            int rowid = (int)e.ListVItem.Tag;
            ChemistryTestNameEnum tname = (ChemistryTestNameEnum)e.SubItem.ColumnName;
            try
            {
                double value = Convert.ToDouble(e.SubItem.Text);
                PSymptomDirectedTest pdt = _protocol.GetSymptomDirectedTestByTestName(tname);
                if (rowid == 1)
                    pdt.AdultInTreatmeant = value;
                else if (rowid == 2)
                    pdt.PediatricInTreatmeant = value;
                else if (rowid == 3)
                    pdt.AdultPreART = value;
                else
                    pdt.PediatricPreART = value;
            }
            catch
            {
            }
        }

        #endregion

        #region othertest

        private void BindOtherSymptom()
        {
            InitOtherListView();

            OtherTestNameEnum[] tname = LqtUtil.EnumToArray<OtherTestNameEnum>();
            for (int i = 1; i <= 4; i++)
            {
                EXListViewItem li = new EXListViewItem(GetRowTitle(i)) { Tag = i };

                for (int m = 0; m < tname.Length; m++)
                {
                    PSymptomDirectedTest pdt = _protocol.GetSymptomDirectedTestByTestName(tname[m]);
                    if (i == 1)
                        li.SubItems.Add(new EXListViewSubItem(pdt.AdultInTreatmeant.ToString(), tname[m]));
                    else if (i == 2)
                        li.SubItems.Add(new EXListViewSubItem(pdt.PediatricInTreatmeant.ToString(), tname[m]));
                    else if (i == 3)
                        li.SubItems.Add(new EXListViewSubItem(pdt.AdultPreART.ToString(), tname[m]));
                    else
                        li.SubItems.Add(new EXListViewSubItem(pdt.PediatricPreART.ToString(), tname[m]));
                }

               _othListView.Items.Add(li);
            }
        }

        private void InitOtherListView()
        {
            _othListView = new SiteListView();
            _othListView.MySortBrush = SystemBrushes.ControlLight;
            _othListView.MyHighlightBrush = Brushes.Goldenrod;
            _othListView.GridLines = true;
            _othListView.MultiSelect = false;
            _othListView.Dock = DockStyle.Fill;
            _othListView.ControlPadding = 4;
            _othListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            //add columns and items

            EXColumnHeader exEditCol = new EXColumnHeader("", 120);
            _othListView.Columns.Add(exEditCol);

            string[] testname = Enum.GetNames(typeof(OtherTestNameEnum));
            for (int i = 0; i < testname.Length; i++)
            {
                EXEditableColumnHeader exCol = new EXEditableColumnHeader(testname[i].Replace('_', ' '), 60);
                _othListView.Columns.Add(exCol);
            }

            _othListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_othListView_EditableListViewSubitemValueChanged);

            tabOther.Controls.Add(_othListView);
        }

        void _othListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            int rowid = (int)e.ListVItem.Tag;
            OtherTestNameEnum tname = (OtherTestNameEnum)e.SubItem.ColumnName;
            try
            {
                double value = Convert.ToDouble(e.SubItem.Text);
                PSymptomDirectedTest pdt = _protocol.GetSymptomDirectedTestByTestName(tname);
                if (rowid == 1)
                    pdt.AdultInTreatmeant = value;
                else if (rowid == 2)
                    pdt.PediatricInTreatmeant = value;
                else if (rowid == 3)
                    pdt.AdultPreART = value;
                else
                    pdt.PediatricPreART = value;
            }
            catch
            {
            }
        }

        #endregion

        void lqtToolStrip1_SaveAndCloseClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();               
                DataRepository.CloseSession();
                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void FrmProtocol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isedited)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show("Do you want to save changes?", "Edit Protocol", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                try
                {
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        LQTUserMessage msg = SaveOrUpdateObject();
                        ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message);
                    }
                    else if (dr == System.Windows.Forms.DialogResult.Cancel)
                        e.Cancel = true;
                }
                catch (Exception ex)
                {
                    new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                    e.Cancel = true;
                }
            }
        }

        public LQTUserMessage SaveOrUpdateObject()
        {
            this._protocol.TestReapeated = txttestsrepeated.Text != "" ? double.Parse(this.txttestsrepeated.Text) : 0;
            this._protocol.SymptomDirectedAmt = txtsymptomdirected.Text != "" ? double.Parse(this.txtsymptomdirected.Text) : 0;
            this._protocol.Descritpion = txtdescription.Text;
            DataRepository.SaveOrUpdateProtocol(_protocol);
            return new LQTUserMessage("Protocol was saved or updated Successfully.");
        }
       
       
        private ProtocolPanel  GetSelectedProtocol()
        {
            if (lsvpanel.SelectedItems.Count == 0)
                return null;
            return (ProtocolPanel)lsvpanel.SelectedItems[0].Tag;
        }

        private void butNewpanel_Click(object sender, EventArgs e)
        {
            ProtocolPanel panel = new ProtocolPanel();
            panel.Protocol = _protocol;
            
            FrmPanel frm = new FrmPanel(panel, _mdiparent); 

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _protocol.ProtocolPanels.Add(panel);
                BindPanels();
            }
        }

        private void butEditpanel_Click(object sender, EventArgs e)
        {
            ProtocolPanel panel = GetSelectedProtocol();
            if (panel != null)
            {   
                FrmPanel frm = new FrmPanel(panel, _mdiparent); 
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {                    
                    BindPanels();
                }
            }
        }

        private void butDeletepanel_Click(object sender, EventArgs e)
        {
            ProtocolPanel panel = GetSelectedProtocol();
            if (panel != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this Panel?", "Delete Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _protocol.ProtocolPanels.Remove(panel);
                        DataRepository.SaveOrUpdateProtocol(_protocol);
                    }
                    catch (Exception ex)
                    {
                        FrmShowError frm = new FrmShowError(new ExceptionStatus() { message = "Panel could not be deleted.", ex = ex });
                        frm.ShowDialog();
                    }
                }

            }
        }

        private void txttestsrepeated_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8) || (x == 46))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;

        }      

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;

        }

        private void CreatNewProtocol()
        {
            _protocol = new Protocol();
            _protocol.ProtocolType = (int)_classOfTest;

            switch (_classOfTest)
            {
                case ClassOfMorbidityTestEnum.CD4:
                    ProtocolPanel panel = new ProtocolPanel();
                    panel.PanelName = "CD4 Panel";
                    panel.Protocol = _protocol;
                    _protocol.ProtocolPanels.Add(panel);
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    string[] testname = Enum.GetNames(typeof(ChemistryTestNameEnum));
                    for (int i = 0; i < testname.Length; i++)
                    {
                        PSymptomDirectedTest sdt = new PSymptomDirectedTest();
                        sdt.ChemTestName = testname[i];
                        sdt.Protocol = _protocol;
                        _protocol.SymptomDirectedTests.Add(sdt);
                    }
                    break;
                case ClassOfMorbidityTestEnum.OtherTest:
                    string[] tname = Enum.GetNames(typeof(OtherTestNameEnum));
                    for (int i = 0; i < tname.Length; i++)
                    {
                        PSymptomDirectedTest sdt = new PSymptomDirectedTest();
                        sdt.OtherTestName = tname[i];
                        sdt.Protocol = _protocol;
                        _protocol.SymptomDirectedTests.Add(sdt);
                    }
                    break;
            }
        }
    }
}
