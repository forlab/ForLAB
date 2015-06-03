
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
using LQT.GUI.MorbidityUserCtr;

namespace LQT.GUI.Asset
{
    public partial class FrmAssignTestingArea : Form
    {
        private SiteListView _sListView;
        private IDictionary<string, ImportedTestingArea> _listOfImportedTA;

        public FrmAssignTestingArea(IDictionary<string, ImportedTestingArea> listOfImportedTA)
        {
            _listOfImportedTA = listOfImportedTA;
            InitializeComponent();
            LoadSiteListView();
            PopListView();
        }

        private ComboBox _comTestingArea;
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
            _comTestingArea.DisplayMember = "AreaName";
            _comTestingArea.DataSource = DataRepository.GetAllTestingArea();

            //add columns and items
            _sListView.Columns.Add(new EXColumnHeader("Area Name", 200));
            EXEditableColumnHeader exEditCol = new EXEditableColumnHeader("Testing Area", _comTestingArea, 200);
            _sListView.Columns.Add(exEditCol);

            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            panel1.Controls.Add(_sListView);
        }

        private void _sListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            ImportedTestingArea ta = (ImportedTestingArea)e.ListVItem.Tag;
            ta.TestingArea = LqtUtil.GetComboBoxValue<TestingArea>(_comTestingArea);
        }

        private void PopListView()
        {
            _sListView.Items.Clear();
            _sListView.BeginUpdate();

            foreach (ImportedTestingArea ta in _listOfImportedTA.Values)
            {
                EXListViewItem li = new EXListViewItem(ta.AreaName) { Tag = ta };
                li.SubItems.Add(new EXListViewSubItem("---Select Testing Area---", "Testing Area"));

                _sListView.Items.Add(li);
            }

            _sListView.EndUpdate();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
