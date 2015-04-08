using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class TestAreaPane : BaseUserControl
    {
        public event EventHandler CreateOrEditTestingGroup;
        //public event EventHandler TestingGroupDelete;
        private bool _enableCtr;
        private TestingArea _testingArea;

        public TestAreaPane(TestingArea testingarea)
            : this(testingarea, false)
        {
        }

        private bool ShowCommandButtons
        {
            set
            {
                butDeletegroup.Visible = value;
                butEditgoup.Visible = value;
                butNewgroup.Visible = value;
            }
        }

        private bool ShowCategory
        {
            set
            {
                lblcategory.Visible = value;
                cobCategory.Visible = value;
            }
        }

        public TestAreaPane(TestingArea testingarea, bool enableCtr)
        {
            this._testingArea = testingarea;
            this._enableCtr = enableCtr;
            InitializeComponent();
            SetControlState();
            popCategory();
            BindTestingArea();
        }

        private void SetControlState()
        {
            this.txtAreaname.Enabled = _enableCtr;
            this.butNewgroup.Enabled = _enableCtr;
            this.lsvGroups.Enabled = _enableCtr;
            this.chkuseindemograph.Enabled = _enableCtr;
            this.cobCategory.Enabled = _enableCtr;
            ShowCommandButtons = _enableCtr;
        }

        public void popCategory()
        {
            cobCategory.DataSource = LqtUtil.EnumToArray<ClassOfMorbidityTestEnum>();
        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
            if (txtAreaname.Text.Trim() == "")
                throw new LQTUserException("Area name must not be empty.");

            this._testingArea.AreaName = this.txtAreaname.Text;
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

        public void RebindTestingArea(TestingArea testarea)
        {
            this._testingArea = testarea;
            BindTestingArea();
        }

        private void BindTestingArea()
        {
            if (_testingArea.Id > 0)
            {
                this.txtAreaname.Text = _testingArea.AreaName;
                this.chkuseindemograph.Checked = _testingArea.UseInDemography;
                if (_enableCtr)
                {
                    this.butNewgroup.Enabled = true;
                }
                ShowCategory = _testingArea.UseInDemography;
                if (_testingArea.Category != null)
                {
                    cobCategory.Text = _testingArea.Category;
                    cobCategory.Enabled = false;
                }
            }
            else  if (_enableCtr)                
            {
                ShowCategory = _testingArea.UseInDemography;
                if (_testingArea.Category != null)
                {
                    cobCategory.Text = _testingArea.Category;
                    cobCategory.Enabled = false;
                }
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
                    Tag = group.Id
                };

                lsvGroups.Items.Add(listViewItem);
            }
            lsvGroups.EndUpdate();
        }

        public TestingGroup GetSelectedTestingGroup()
        {
            if (lsvGroups.SelectedItems.Count == 0)
                return null;

            int groupId = (int)lsvGroups.SelectedItems[0].Tag;
            return DataRepository.GetTestingGroupById(groupId);
        }

        private void butNewgroup_Click(object sender, EventArgs e)
        {
            if (CreateOrEditTestingGroup != null)
            {
                TestingGroup tg = new TestingGroup();
                tg.TestingArea = _testingArea;
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(tg);
                CreateOrEditTestingGroup(this, eArgs);
            }
        }

        private void butEditgoup_Click(object sender, EventArgs e)
        {
            if (CreateOrEditTestingGroup != null)
            {
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(GetSelectedTestingGroup());
                CreateOrEditTestingGroup(this, eArgs);
            }
        }

        private void butDeletegroup_Click(object sender, EventArgs e)
        {
            TestingGroup tg = this.GetSelectedTestingGroup();
            if (tg != null && MessageBox.Show("Are you sure you want to delete this Test-Group?", "Delete Test-Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteTestingGroup(tg);
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
            ShowCategory = chkuseindemograph.Checked;
        }
    }

   
}
