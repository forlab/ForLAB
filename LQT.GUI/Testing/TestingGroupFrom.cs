
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
using System.Windows.Forms;

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Testing
{
    public partial class TestingGroupFrom : Form
    {
        private TestingGroup _testingGroup;
        private Form _mdiparent;
        private bool _enableCtr;
  
        public TestingGroupFrom(TestingGroup tgroup, Form mdiparent)
        {
            this._testingGroup = tgroup;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            PopTestingAreas();
            LoadTestingAreaCtr();
           
        }

        private void LoadTestingAreaCtr()
        {
            txtAreaname.Text = "";
            PopTestingAreas();
            BindTestingGroup();
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                //DataRepository.CloseSession();

                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();
                _testingGroup = new TestingGroup();
                //_testingGroup.TestingArea = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
                
                LoadTestingAreaCtr();
            }
            catch (LQTUserException ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
            catch (Exception ex)
            {

                new FrmShowError(CustomExceptionHandler.ShowExceptionText("There is already a Test-Group with this group name.", ex)).ShowDialog();
            }
        }

        void lqtToolStrip1_SaveAndCloseClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                //DataRepository.CloseSession();
                ((LqtMainWindowForm)_mdiparent).BuildNavigationMenu();
                this.Close();
            }
            catch (LQTUserException ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
            catch (Exception ex)
            {
                
                new FrmShowError(CustomExceptionHandler.ShowExceptionText("There is already a Test-Group with this group name.", ex)).ShowDialog();
            }
        }

        private void PopTestingAreas()
        {
            comTestarea.DataSource = DataRepository.GetAllTestingArea();
            comTestarea.SelectedIndex = -1;
        }

        private void BindTestingGroup()
        {
            if (_testingGroup.TestingArea != null)
            {
                comTestarea.SelectedValue = _testingGroup.TestingArea.Id;
                comTestarea.Enabled = false;
            }
            else
                comTestarea.Enabled = true;

            if (_testingGroup.Id > 0)
                this.txtAreaname.Text = _testingGroup.GroupName;

            DisplayTests();
        }

        private void DisplayTests()
        {
            lsvGroups.BeginUpdate();
            lsvGroups.Items.Clear();

            foreach (Test t in _testingGroup.Tests)
            {
                ListViewItem listViewItem = new ListViewItem(t.TestName)
                {
                    Tag = t.Id
                };

                lsvGroups.Items.Add(listViewItem);
            }
            lsvGroups.EndUpdate();
        }

        public LQTUserMessage SaveOrUpdateObject()
        {
            if (txtAreaname.Text.Trim() == "")
                throw new LQTUserException("Group name must not be empty.");

            this._testingGroup.GroupName = this.txtAreaname.Text.Trim();
            TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
            if(ta == null)
                throw new LQTUserException("A testing-area must be selected.");

            if (_testingGroup.TestingArea == null)
            {   
                this._testingGroup.TestingArea = ta;
                ta.TestingGroups.Add(_testingGroup);
                
            }
            else if (!ta.TestingGroups.Contains(_testingGroup))
            {
                this._testingGroup.TestingArea = ta;
                ta.TestingGroups.Add(_testingGroup);
            }
            DataRepository.SaveOrUpdateTestingArea(ta);
            return new LQTUserMessage("Testing Group was saved or updated successfully.");
        }
      


    }
}
