
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.MorbidityUserCtr;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class FrmAssignCat : Form
    {
        private SiteListView _sListView;
        private IDictionary<string, ImportedReagionOrCategory> _listOfImportedCat;
        private IList<MorbidityCategory> _lstCategories;

        public FrmAssignCat(IDictionary<string, ImportedReagionOrCategory> listOfImportedTA, IList<MorbidityCategory> categorys)
        {
            _listOfImportedCat = listOfImportedTA;
            _lstCategories = categorys;

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
            _comTestingArea.DisplayMember = "CategoryName";
            _comTestingArea.DataSource = _lstCategories;

            //add columns and items
            _sListView.Columns.Add(new EXColumnHeader("Category/Region Name", 200));
            EXEditableColumnHeader exEditCol = new EXEditableColumnHeader("Category/Region", _comTestingArea, 200);
            _sListView.Columns.Add(exEditCol);
            

            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            panel1.Controls.Add(_sListView);
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

            foreach (ImportedReagionOrCategory ta in _listOfImportedCat.Values)
            {
                EXListViewItem li = new EXListViewItem(ta.RegionOrCatName) { Tag = ta };
                li.SubItems.Add(new EXListViewSubItem("---Select Category/Region---", "Category/Region"));

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
