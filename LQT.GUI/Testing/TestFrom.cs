
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
    public partial class TestFrom : Form
    {
        private Test _test;
        private Form _mdiparent;
        private bool _isedited = false;

        public event EventHandler OnDataUsageEdit;
        public event EventHandler DisableSaveButton;
        public event EventHandler EnableSaveButton;

        public TestFrom(Test test, Form mdiparent)
        {
            this._test = test;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            this.EnableSaveButton += new EventHandler(TestFrom_EnableSaveButton);
            this.DisableSaveButton += new EventHandler(TestFrom_DisableSaveButton);
            OnDataUsageEdit += new EventHandler(_taPane_OnDataUsageEdit);
            lsvProductUsage.AddNoneEditableColumn(0);
            lsvProductUsage.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvProductUsage_OnSubitemTextChanged);

            PopTestingAreas();
            PopTestingGroup();
            PopInstrument();
            PopProduct();

            LoadTestCtr();
        }

        private void LoadTestCtr()
        {
            SetControlState();
            BindTest();
        }

        void _taPane_OnDataUsageEdit(object sender, EventArgs e)
        {
            _isedited = true;
        }

        void TestFrom_DisableSaveButton(object sender, EventArgs e)
        {
            lqtToolStrip1.DisableSaveButton();
        }

        void TestFrom_EnableSaveButton(object sender, EventArgs e)
        {
            lqtToolStrip1.EnableSaveButton();
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);

                TestingArea ta = _test.TestingArea;
                TestingGroup tg = _test.TestingGroup;

                _test = new Test();
                _test.TestingArea = ta;
                _test.TestingGroup = tg;

                // LoadTestCtr();
                SetControlState();
                comGroup.Enabled = true;
                comTestarea.Enabled = true;

                _isedited = false;
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
                _isedited = false;

                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void TestFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isedited)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show("Do you want to save changes?", "Edit Site", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                try
                {
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        LQTUserMessage msg = SaveOrUpdateObject();
                        ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
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

        private void TestFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            NHibernateHelper.CloseSession();
        }

        private void SetControlState()
        {
            this.txtTestname.Text = "";
            PopTestingAreas();
            PopTestingGroup();
            PopInstrument();
            PopProduct();

            BindProductUsage();
        }

        private void PopTestingAreas()
        {
            comTestarea.DataSource = DataRepository.GetAllTestingArea();// DataRepository.GetTestingAreaByDemography(fa);

            if (comTestarea.Items.Count > 0)
                comTestarea.SelectedIndex = -1;
            else
            {
                DisableSaveButton(this, new EventArgs());
            }
        }

        private void PopTestingGroup()
        {
            TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);

            if (ta != null)
                comGroup.DataSource = ta.TestingGroups;

            if (comGroup.Items.Count > 0)
            {
                comGroup.SelectedIndex = -1;
                EnableSaveButton(this, new EventArgs());
            }
            else
                DisableSaveButton(this, new EventArgs());
        }

        private void PopInstrument()
        {
            TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);

            if (ta != null)
            {
                comInstrument.DataSource = DataRepository.GetListOfInstrumentByTestingArea(ta.Id);
                if (comInstrument.Items.Count > 0)
                {
                    comInstrument.SelectedIndex = -1;
                    butAdd.Enabled = true;
                }
                else
                    butAdd.Enabled = false;
            }
            else
                butAdd.Enabled = false;
        }

        private void PopProduct()
        {
            comProduct.DataSource = DataRepository.GetAllProduct();
            comProduct.SelectedIndex = -1;

        }

        private void BindTest()
        {
            if (_test.TestingArea != null)
            {
                comTestarea.SelectedValue = _test.TestingArea.Id;
                comTestarea.Enabled = false;

                if (_test.TestingGroup != null)
                {
                    PopTestingGroup();

                    comGroup.SelectedValue = _test.TestingGroup.Id;
                    comGroup.Enabled = false;
                }

            }

            if (_test.Id > 0)
            {
                this.txtTestname.Text = _test.TestName;
                //butAdd.Enabled = true;
            }
            BindProductUsage();

        }

        public void RebindTest(Test test)
        {
            this._test = test;

            BindTest();

        }


        private void BindProductUsage()
        {
            lsvProductUsage.BeginUpdate();
            lsvProductUsage.Items.Clear();

            int index = 0;
            foreach (ProductUsage r in _test.ProductUsages)
            {
                LQTListViewTag tag = new LQTListViewTag();
                tag.GroupTitle = r.Instrument.InstrumentName;
                tag.Id = r.Id;
                tag.Index = index;
                ListViewItem li = new ListViewItem(r.Product.ProductName) { Tag = tag };

                li.SubItems.Add(r.Rate.ToString());
                //li.SubItems.Add(r.ProductUsedIn);
                LqtUtil.AddItemToGroup(lsvProductUsage, li);
                lsvProductUsage.Items.Add(li);
                index++;
            }

            lsvProductUsage.EndUpdate();

        }

        public LQTUserMessage SaveOrUpdateObject()
        {
            if (txtTestname.Text == "")
                throw new LQTUserException("Test name must not be empty.");
            Test temp = DataRepository.GetTestByName(txtTestname.Text.Trim());
            if (_test.Id <= 0 && temp != null)
                throw new LQTUserException("The Test Name already exists.");
            if (temp != null && _test.Id != temp.Id)
                throw new LQTUserException("The Test Name already exists.");
            temp = null;

            this._test.TestName = this.txtTestname.Text.Trim();
            if (comTestarea.SelectedIndex < 0)
                throw new LQTUserException("Testing Area can not be empty.");

            if (comGroup.SelectedIndex < 0)
                throw new LQTUserException("Testing Group can not be empty.");

            if (_test.TestingArea == null || _test.TestingGroup == null)
            {
                _test.TestingArea = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
                _test.TestingGroup = LqtUtil.GetComboBoxValue<TestingGroup>(comGroup);
            }

            DataRepository.SaveOrUpdateTest(_test);
            return new LQTUserMessage("Test was saved or updated successfully.");
        }

        void lsvProductUsage_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)e.ListVItem.Tag;
            ListViewItem li = e.ListVItem;
            ProductUsage pu;// = (ProductUsage)li.Tag;

            if (tag.Id > 0)
                pu = _test.GetProductUsage(tag.Id);
            else
                pu = _test.ProductUsages[tag.Index];


            try
            {
                decimal rate = decimal.Parse(li.SubItems[1].Text);
                pu.Rate = rate;
            }
            catch
            {
                li.SubItems[1].Text = pu.Rate.ToString();
            }

            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this, new EventArgs());
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Instrument ins = LqtUtil.GetComboBoxValue<Instrument>(comInstrument);
            if (ins != null)
            {
                MasterProduct pro = LqtUtil.GetComboBoxValue<MasterProduct>(comProduct);
                if (pro != null)
                {
                    if (!_test.IsExsistProductUsage(ins.Id, pro.Id))
                    {
                        ProductUsage pu = new ProductUsage();
                        pu.Test = _test;
                        pu.Instrument = ins;
                        pu.Product = pro;
                        pu.Rate = 1;
                        _test.ProductUsages.Add(pu);

                        BindProductUsage();
                        if (OnDataUsageEdit != null)
                        {
                            OnDataUsageEdit(this, new EventArgs());
                        }
                    }
                }
            }
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)lsvProductUsage.SelectedItems[0].Tag;

            ProductUsage pu;
            if (lsvProductUsage.SelectedItems.Count > 0)
            {
                if ((MessageBox.Show("Are you sure, do you want to remove it?", "Product Usage", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {


                    if (tag.Id > 0)
                        pu = _test.GetProductUsage(tag.Id);
                    else
                        pu = _test.ProductUsages[tag.Index];
                    _test.ProductUsages.Remove(pu);

                    BindProductUsage();
                    if (OnDataUsageEdit != null)
                    {
                        OnDataUsageEdit(this, new EventArgs());
                    }
                }
            }
        }

        private void lsvProductUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvProductUsage.SelectedItems.Count > 0)
            {
                butRemove.Enabled = true;
            }
            else
                butRemove.Enabled = false;
        }

        private void comTestarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopTestingGroup();
            PopInstrument();
        }


    }
}
