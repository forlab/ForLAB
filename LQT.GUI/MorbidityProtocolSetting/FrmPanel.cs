
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

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;
using System.Globalization;
using LQT.GUI.MorbidityUserCtr;


namespace LQT.GUI.MorbidityProtocolSetting
{
    public partial class FrmPanel : Form
    {
        private ProtocolPanel _panel;
        private Form _mdiparent;        
        private SiteListView _cd4ListView;

        public FrmPanel(ProtocolPanel panel, Form mdiparent)
        {
            this._panel = panel;
            this._mdiparent = mdiparent;

            InitializeComponent();
            txtpanelName.Text = panel.PanelName;

            BindBloodSample();
            BindSymptomDirectedTest();
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

        private void BindBloodSample()
        {
            InitListView();
            for (int i = 1; i <= 4; i++)
            {
                EXListViewItem li = new EXListViewItem(GetRowTitle(i)) { Tag = i };

                if (i == 1)
                    li.SubItems.Add(new EXListViewSubItem(_panel.AITNewPatient.ToString(), 0));
                else if (i == 2)
                    li.SubItems.Add(new EXListViewSubItem(_panel.PITNewPatient.ToString(), 0));
                else if (i == 3)
                    li.SubItems.Add(new EXListViewSubItem(_panel.APARTNewPatient.ToString(), 0));
                else if (i == 4)
                    li.SubItems.Add(new EXListViewSubItem(_panel.PPARTNewPatient.ToString(), 0));

                for (int m = 1; m <= 12; m++)
                {
                    if (i == 1)
                        li.SubItems.Add(new EXListViewSubItem(_panel.AdultArtTestGivenInMonth(m).ToString(), m));
                    else if (i == 2)
                        li.SubItems.Add(new EXListViewSubItem(_panel.PediatricArtTestGivenInMonth(m).ToString(), m));
                    else if (i == 3)
                        li.SubItems.Add(new EXListViewSubItem(_panel.AdultPreArtTestGivenInMonth(m).ToString(), m));
                    else
                        li.SubItems.Add(new EXListViewSubItem(_panel.PediatricPreArtTestGivenInMonth(m).ToString(), m));
                }

                if (i == 1)
                {
                    li.SubItems.Add(new EXListViewSubItem(_panel.AITPreExisting.ToString(), 13));
                    li.SubItems.Add(new EXListViewSubItem(_panel.AITTestperYear.ToString(), 14));
                }
                else if (i == 2)
                {
                    li.SubItems.Add(new EXListViewSubItem(_panel.PITPreExisting.ToString(), 13));
                    li.SubItems.Add(new EXListViewSubItem(_panel.PITTestperYear.ToString(), 14));
                }
                else if (i == 3)
                {
                    li.SubItems.Add(new EXListViewSubItem(_panel.APARTPreExisting.ToString(), 13));
                    li.SubItems.Add(new EXListViewSubItem(_panel.APARTestperYear.ToString(), 14));
                }
                else if (i == 4)
                {
                    li.SubItems.Add(new EXListViewSubItem(_panel.PPARTPreExisting.ToString(), 13));
                    li.SubItems.Add(new EXListViewSubItem(_panel.PPARTTestperYear.ToString(), 14));
                }

                _cd4ListView.Items.Add(li);
            }
        }

        private void InitListView()
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
            EXEditableColumnHeader exEditCol = new EXEditableColumnHeader("", 150);
            _cd4ListView.Columns.Add(exEditCol);

            exEditCol = new EXEditableColumnHeader("% of New Patients on Panel", 60);
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
            exEditCol = new EXEditableColumnHeader("% of Pre-Existing Patients on Panel", 120);
            _cd4ListView.Columns.Add(exEditCol);
            exEditCol = new EXEditableColumnHeader("Tests/ year after month 12", 120);
            _cd4ListView.Columns.Add(exEditCol);

            _cd4ListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_cd4ListView_EditableListViewSubitemValueChanged);

            gbxSample.Controls.Add(_cd4ListView);
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
                    if (month < 13 && month > 0)
                        _panel.SetAdultArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else if (month == 0)
                        _panel.AITNewPatient = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 13)
                        _panel.AITPreExisting = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 14)
                        _panel.AITTestperYear = Convert.ToInt32(e.SubItem.Text);
                }
                else if (rowid == 2)
                {
                    if (month < 13 && month > 0)
                        _panel.SetPediatricArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else if (month == 0)
                        _panel.PITNewPatient = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 13)
                        _panel.PITPreExisting = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 14)
                        _panel.PITTestperYear = Convert.ToInt32(e.SubItem.Text);
                }
                else if (rowid == 3)
                {
                    if (month < 13 && month > 0)
                        _panel.SetAdultPreArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else if (month == 0)
                        _panel.APARTNewPatient = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 13)
                        _panel.APARTPreExisting = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 14)
                        _panel.APARTestperYear = Convert.ToInt32(e.SubItem.Text);
                }
                else
                {
                    if (month < 13 && month >0)
                        _panel.SetPediatricPreArtTestGivenInMonth(month, Convert.ToInt32(e.SubItem.Text));
                    else if (month == 0)
                        _panel.PPARTNewPatient = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 13)
                        _panel.PPARTPreExisting = Convert.ToDouble(e.SubItem.Text);
                    else if (month == 14)
                        _panel.PPARTTestperYear = Convert.ToInt32(e.SubItem.Text);
                }
            }
            catch
            {
            }
        }

        #endregion

        public void BindSymptomDirectedTest()
        {
            lstTest.BeginUpdate();
            lstTest.Items.Clear();

            if (_panel.Protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.Chemistry)
            {
                ChemistryTestNameEnum[] cmt = LqtUtil.EnumToArray<ChemistryTestNameEnum>();
                for (int i = 0; i < cmt.Length; i++)
                {
                    ListViewItem li = new ListViewItem(cmt[i].ToString()) { Tag = cmt[i] };
                    li.Checked = _panel.IsChemTestSelected(cmt[i]);
                    lstTest.Items.Add(li);
                }
            }
            else if (_panel.Protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.OtherTest)
            {
                OtherTestNameEnum[] otn = LqtUtil.EnumToArray<OtherTestNameEnum>();
                for (int i = 0; i < otn.Length; i++)
                {
                    ListViewItem li = new ListViewItem(otn[i].ToString()) { Tag = otn[i] };
                    li.Checked = _panel.IsOtherTestSelected(otn[i]);
                    lstTest.Items.Add(li);
                }
            }
            else
                lstTest.Enabled = false;
            lstTest.EndUpdate();
        }
             

        private void lstTest_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_panel.Protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.Chemistry)
                SelectChemTest(e);
            else if (_panel.Protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.OtherTest)
                SelectOtherTest(e);
        }

        private void SelectChemTest(ItemCheckedEventArgs e)
        {
            ChemistryTestNameEnum tname = (ChemistryTestNameEnum)e.Item.Tag;
            if (e.Item.Checked)
                _panel.PanelTests.Add(new PanelTest() { ChemTestName = tname.ToString(), Panel = _panel });
            else
            {
                PanelTest pt = _panel.GetChemPanelTest(tname);
                if (pt != null)
                    _panel.PanelTests.Remove(pt);
            }

        }

        private void SelectOtherTest(ItemCheckedEventArgs e)
        {
            OtherTestNameEnum tname = (OtherTestNameEnum)e.Item.Tag;
            if (e.Item.Checked)
                _panel.PanelTests.Add(new PanelTest() { OtherTestName = tname.ToString(), Panel = _panel });
            else
            {
                PanelTest pt = _panel.GetOtherPanelTest(tname);
                if (pt != null)
                    _panel.PanelTests.Remove(pt);
            }
        }
        
        private void butOk_Click(object sender, EventArgs e)
        {
            _panel.PanelName = txtpanelName.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
