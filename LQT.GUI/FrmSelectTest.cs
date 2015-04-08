
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
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI
{
    public partial class FrmSelectTest : Form
    {
        public IList<int> SelectedTestIds;
        private IList<int> _selectedTestids;
        private IList<Test> _tests;

        
        private TestingArea _selectedTestingArea;
        public IList<Test> _selectedTest;
        private bool _protocol = false;
        private ProtocolPanel _panel;

        public FrmSelectTest(IList<int> selectedids, IList<Test> tests)
        {
            _selectedTestids = selectedids;
            _tests = tests;

            InitializeComponent();
            SelectedTestIds = new List<int>();
            BindTests();
        }

  
        public FrmSelectTest(ProtocolPanel p)
        {
            _panel = p;
            _selectedTest = new List<Test>();
            InitializeComponent();
            label1.Visible = false;
            txtNoperiod.Visible = false;
            BindPanelTests();
        }

        private void BindPanelTests()
        {
            lvTests.BeginUpdate();
            lvTests.Items.Clear();
            foreach (Test s in DataRepository.GetTestByPlatform(_panel.Protocol.ProtocolTypeEnum.ToString()))
            {
                if (!IsTestAdded(s))
                {
                    ListViewItem li = new ListViewItem(s.TestName) { Tag = s };
                    li.SubItems.Add(s.TestingGroup.GroupName);
                    li.SubItems.Add(s.TestingArea.AreaName);
                    lvTests.Items.Add(li);
                }
            }

            lvTests.EndUpdate();
        }

    

        private bool IsTestAdded(Test t)
        {
            foreach (PanelTest pt in _panel.PanelTests)
            {
                if (pt.TestId==t)
                    return true;
            }
            return false;
        }

      
        
        private void BindTests()
        {
            lvTests.BeginUpdate();
            lvTests.Items.Clear();

            foreach (Test s in _tests)
            {
                if (!IsTestSelected(s.Id))
                {
                    ListViewItem li = new ListViewItem(s.TestName) { Tag = s.Id };
                    li.SubItems.Add(s.TestingGroup.GroupName);
                    li.SubItems.Add(s.TestingArea.AreaName);

                    lvTests.Items.Add(li);
                }
            }

            lvTests.EndUpdate();

        }

        private bool IsTestSelected(int siteid)
        {
            foreach (int id in _selectedTestids)
            {
                if (id == siteid)
                    return true;
            }
            return false;
        }

        private void lvSiteAll_Resize(object sender, EventArgs e)
        {

        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            int len = lvTests.SelectedItems.Count;
            if (!_protocol && _panel == null)
            {
                for (int i = 0; i < len; i++)
                {
                    SelectedTestIds.Add((int)lvTests.SelectedItems[i].Tag);
                }
            }
            else if (_panel!=null)
            {
                for (int i = 0; i < len; i++)
                {
                    _selectedTest.Add((Test)lvTests.SelectedItems[i].Tag);
                }
            }
            else
            {

                for (int i = 0; i < len; i++)
                {
                    _selectedTest.Add((Test)lvTests.SelectedItems[i].Tag);
                }
            }


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public int NoRPeriod()
        {
            if (txtNoperiod.Text == "")
                return 3;
            int no = int.Parse(txtNoperiod.Text);

            return no > 3 ? no : 3;
        }

        private void txtNoperiod_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
