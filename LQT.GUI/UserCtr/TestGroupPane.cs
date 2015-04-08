using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class TestGroupPane : BaseUserControl
    {
       public event EventHandler CreateOrEditTest;
        private bool _enableCtr;
        private TestingGroup _testingGroup;

        public TestGroupPane(TestingGroup testinggroup)
            : this(testinggroup, false)
        {
        }

        private bool ShowCommandButtons
        {
            set
            {
                butDeletetest.Visible = value;
                butEdittest.Visible = value;
                butNewtest.Visible = value;
            }
        }

        public TestGroupPane(TestingGroup testingGroup, bool enableCtr)
        {
            this._testingGroup = testingGroup;
            this._enableCtr = enableCtr;
            InitializeComponent();
            SetControlState();
            PopTestingAreas();
            BindTestingGroup();
        }

        private void SetControlState()
        {
            this.txtAreaname.Enabled = _enableCtr;
            this.comTestarea.Enabled = _enableCtr;
            this.butNewtest.Enabled = _enableCtr;
            this.lsvGroups.Enabled = _enableCtr;
            ShowCommandButtons = _enableCtr;
        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
            if (txtAreaname.Text.Trim() == "")
                throw new LQTUserException("Group name must not be empty.");

            this._testingGroup.GroupName = this.txtAreaname.Text;

            if (_testingGroup.TestingArea == null)
            {
                TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
                this._testingGroup.TestingArea = ta;
            }
            //else if (_testingGroup.Id <= 0)
            //{
            //    _testingGroup.TestingArea.TestingGroups.Add(_testingGroup);
            //}

            DataRepository.SaveOrUpdateTestingGroup(_testingGroup);
            DataRepository.CloseSession();
            return new LQTUserMessage("Testing Group was saved or updated successfully.");
        }

        public void RebindTestingGroup(TestingGroup testgroup)
        {
            this._testingGroup = testgroup;
            BindTestingGroup();
        }

        private void PopTestingAreas()
        {
            comTestarea.DataSource = DataRepository.GetAllTestingArea();
            //comTestarea.DataBindings;
        }

        private void BindTestingGroup()
        {
            if (_testingGroup.TestingArea != null)
            {
                comTestarea.SelectedValue = _testingGroup.TestingArea.Id;
                comTestarea.Enabled = false;
            }

            if (_testingGroup.Id > 0)
            {
                this.txtAreaname.Text = _testingGroup.GroupName;

                if (_enableCtr)
                {
                    this.butNewtest.Enabled = true;
                }
            }
            else  if (_enableCtr)                
            {

                this.butNewtest.Enabled = false;
            }

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

        public Test GetSelectedTest()
        {
            if (lsvGroups.SelectedItems.Count == 0)
                return null;

            int id = (int)lsvGroups.SelectedItems[0].Tag;
            return DataRepository.GetTestById(id);
        }
        
        private void butNewtest_Click(object sender, EventArgs e)
        {
            if (CreateOrEditTest != null)
            {
                Test tg = new Test();
                tg.TestingArea = _testingGroup.TestingArea;
                tg.TestingGroup = _testingGroup;
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(tg);
                CreateOrEditTest(this, eArgs);
            }
        }

        private void butEdittest_Click(object sender, EventArgs e)
        {
            if (CreateOrEditTest != null)
            {
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(GetSelectedTest());
                CreateOrEditTest(this, eArgs);
            }
        }

        private void butDeletetest_Click(object sender, EventArgs e)
        {
            Test tg = GetSelectedTest();
            if (tg != null && MessageBox.Show("Are you sure you want to delete this Test?", "Delete Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteTest(tg);
                }
                catch (Exception ex)
                {
                    throw new LQTUserException(ex.Message);
                }
            }
        }

        private void lsvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvGroups.SelectedItems.Count > 0)
            {
                this.butEdittest.Enabled = true;
                this.butDeletetest.Enabled = true;
            }
            else
            {
                this.butEdittest.Enabled = false;
                this.butDeletetest.Enabled = false;
            }
        }

       
    }
}
