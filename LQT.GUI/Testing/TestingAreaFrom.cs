
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LQT.Core.DataAccess;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.UserCtr;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Testing
{
    public partial class TestingAreaFrom : Form
    {
        private TestingArea _testingArea;
        private Form _mdiparent;

        public TestingAreaFrom(TestingArea testingarea, Form mdiparent)
        {
            this._testingArea = testingarea;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            LoadTestingAreaCtr();
        }

        private void LoadTestingAreaCtr()
        {
            SetControlState();
            popCategory();
            BindTestingArea();
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message);
                DataRepository.CloseSession();
                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();
                _testingArea = new TestingArea();
                LoadTestingAreaCtr();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        void lqtToolStrip1_SaveAndCloseClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                DataRepository.CloseSession();

                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();
                this.Close();
            }
            catch (LQTUserException ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText("Error: unable to save or update testing area.", ex)).ShowDialog();
            }
        }

        private void SetControlState()
        {
            this.txtAreaname.Text = "";
            this.chkuseindemograph.Checked = false;
        }

        public void popCategory()
        {
            cobCategory.DataSource = LqtUtil.EnumToArray<ClassOfMorbidityTestEnum>();
            cobCategory.SelectedIndex = -1;
        }
        
        public LQTUserMessage SaveOrUpdateObject()
        {
            if (txtAreaname.Text.Trim() == "")
                throw new LQTUserException("Testing Area name must not be empty.");

            this._testingArea.AreaName = this.txtAreaname.Text.Trim();
            this._testingArea.UseInDemography = this.chkuseindemograph.Checked;
            if (this.chkuseindemograph.Checked)
            {
                this._testingArea.Category = this.cobCategory.SelectedValue.ToString();
            }
            else
            {
                this._testingArea.Category = null;
            }
            
            DataRepository.SaveOrUpdateTestingArea(_testingArea);

            return new LQTUserMessage("Testing Area was saved or updated successfully.");
        }

        private void BindTestingArea()
        {
            if (_testingArea.Id > 0)
            {
                this.txtAreaname.Text = _testingArea.AreaName;
                this.chkuseindemograph.Checked = _testingArea.UseInDemography;
                this.butNewgroup.Enabled = true;

                if (_testingArea.Category != null)
                    cobCategory.Text = _testingArea.Category;
                cobCategory.Enabled = _testingArea.UseInDemography;
            }
            else
            {
                this.butNewgroup.Enabled = false;
            }

            DisplayTestingGroup();
        }
        private void DisplayTestingGroup()
        {
            lsvGroups.BeginUpdate();
            lsvGroups.Items.Clear();

            foreach (TestingGroup group in _testingArea.TestingGroups)
            {
                ListViewItem listViewItem = new ListViewItem(group.GroupName)
                {
                    Tag = group
                };

                lsvGroups.Items.Add(listViewItem);
            }
            lsvGroups.EndUpdate();
        }
        private void butNewgroup_Click(object sender, EventArgs e)
        {
            TestingGroup tg = new TestingGroup();
            tg.TestingArea = _testingArea;
            TestingGroupFrom frm = new TestingGroupFrom(tg, _mdiparent);
            frm.ShowDialog();
            DisplayTestingGroup();
        }

        private void butEditgoup_Click(object sender, EventArgs e)
        {
            TestingGroup tg = GetSelectedTestingGroup();//b
            if (tg != null)//b
            {
                TestingGroupFrom frm = new TestingGroupFrom(tg, _mdiparent);
                frm.ShowDialog();
                DisplayTestingGroup();
            }
        }

        private void butDeletegroup_Click(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0)//b
            {
                TestingGroup tg = GetSelectedTestingGroup();
                if (tg != null && MessageBox.Show("Are you sure you want to delete this Testing Group?", "Delete Testing Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _testingArea.TestingGroups.Remove(tg);
                    }
                    catch (Exception ex)
                    {
                        new FrmShowError(CustomExceptionHandler.ShowExceptionText("Error: unable to delete the Testing Group.", ex)).ShowDialog();
                    }
                }
                DisplayTestingGroup();
            }
        }

        private void lsvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0)
            {
                butDeletegroup.Enabled = true;
                butEditgoup.Enabled = true;
            }
            else
            {
                butDeletegroup.Enabled = false;
                butEditgoup.Enabled = false;

            }

        }

        private void chkuseindemograph_CheckedChanged(object sender, EventArgs e)
        {
            cobCategory.Enabled = chkuseindemograph.Checked;
        }

        public TestingGroup GetSelectedTestingGroup()
        {
            if (lsvGroups.SelectedItems.Count == 0)
                return null;

            return (TestingGroup)lsvGroups.SelectedItems[0].Tag;
        }


    }
}
