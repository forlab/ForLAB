
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

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Consumables
{
    public partial class FrmConsumables : Form
    {
        private MasterConsumable _consum;
        private Form _mdiparent;
        private bool _isedited = false;

        public event EventHandler OnDataUsageEdit;
        public event EventHandler DisableSaveButton;
        public event EventHandler EnableSaveButton;

        public FrmConsumables()
        {
        }
        public FrmConsumables(MasterConsumable consum, Form mdiparent)
        {
            this._consum = consum;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            this.EnableSaveButton += new EventHandler(FrmConsumables_EnableSaveButton);
            this.DisableSaveButton += new EventHandler(FrmConsumables_DisableSaveButton);
            OnDataUsageEdit += new EventHandler(_taPane_OnDataUsageEdit);
            lsvProductUsageT.AddNoneEditableColumn(0);
            lsvProductUsageT.AddNoneEditableColumn(1);
            lsvProductUsageP.AddNoneEditableColumn(0);
            lsvProductUsageP.AddNoneEditableColumn(1);
            lsvProductUsageI.AddNoneEditableColumn(0);
            lsvProductUsageI.AddNoneEditableColumn(1);
            lsvProductUsageT.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvProductUsage_SelectedIndexChanged);
            lsvProductUsageP.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvProductUsageP_SelectedIndexChanged);
            lsvProductUsageI.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvProductUsageI_SelectedIndexChanged);
            PopTestingAreas();
            PopTest();
            PopInstrument();
            PopPeriod();
            PopProduct();
            LoadTestCtr();
        }

        private void txtNoofTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void LoadTestCtr()
        {
            SetControlState();
            BindConsumable();
        }

        void _taPane_OnDataUsageEdit(object sender, EventArgs e)
        {
            _isedited = true;
        }

        void FrmConsumables_DisableSaveButton(object sender, EventArgs e)
        {
            lqtToolStrip1.DisableSaveButton();
        }

        void FrmConsumables_EnableSaveButton(object sender, EventArgs e)
        {
            lqtToolStrip1.EnableSaveButton();
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);

                TestingArea ta = _consum.TestingArea;
                Test t = _consum.Test;

                _consum = new MasterConsumable();
                _consum.TestingArea = ta;
                _consum.Test = t;

                // LoadTestCtr();
                SetControlState();
                comTest.Enabled = true;
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

        private void FrmConsumables_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isedited)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show("Do you want to save changes?", "Edit Consumables", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

        private void FrmConsumables_FormClosed(object sender, FormClosedEventArgs e)
        {
            NHibernateHelper.CloseSession();
        }

        private void SetControlState()
        {
            PopTestingAreas();
            PopTest();
            PopInstrument();
            PopProduct();

            BindProductUsage();
        }

        private void PopTestingAreas()
        {
            comTestarea.DataSource = DataRepository.GetAllTestingArea();// DataRepository.GetTestingAreaByDemography(fa);

            if (comTestarea.Items.Count > 0)
            {
                comTestarea.SelectedIndex = -1;
                butAddT.Enabled = false;
            }
            else
            {
                DisableSaveButton(this, new EventArgs());
            }
        }

        private void PopTest()
        {
            TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);

            if (ta != null)
                comTest.DataSource = ta.Tests;////////////////////

            if (comTest.Items.Count > 0)
            {
                comTest.SelectedIndex = -1;
               // EnableSaveButton(this, new EventArgs());
            }
           // else
              //  DisableSaveButton(this, new EventArgs());
        }

        private void PopInstrument()
        {
            TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);

            if (ta != null)
            {
                comInstrumentI.DataSource = DataRepository.GetListOfInstrumentByTestingArea(ta.Id);
                if (comInstrumentI.Items.Count > 0)
                {
                    comInstrumentI.SelectedIndex = -1;
                    butAddI.Enabled = true;
                }
                else
                    butAddI.Enabled = false;
            }
            else
                butAddI.Enabled = false;
        }

        private void PopProduct()
        {
            comProductT.DataSource = DataRepository.GetAllProduct();
            comProductT.SelectedIndex = -1;

            comProductP.DataSource = DataRepository.GetAllProduct();
            comProductP.SelectedIndex = -1;

            comProductI.DataSource = DataRepository.GetAllProduct();
            comProductI.SelectedIndex = -1;

        }

        private void PopPeriod()
        {
            PeriodEnum[] period = LqtUtil.EnumToArray<PeriodEnum>();
            comPeriodP.DataSource = period;
            comPeriodP.SelectedIndex = -1;

            comPeriodI.DataSource = period;
            comPeriodI.SelectedIndex = -1;

        }

        private void BindConsumable()
        {
            if (_consum.TestingArea != null)
            {
                comTestarea.SelectedValue = _consum.TestingArea.Id;
                comTestarea.Enabled = false;

                if (_consum.Test != null)
                {
                    PopTest();

                    comTest.SelectedValue = _consum.Test.Id;
                    comTest.Enabled = false;
                }

            }

           
            BindProductUsage();

        }

        public void RebindTest(MasterConsumable consum)
        {
            this._consum = consum;

            BindConsumable();

        }


        private void BindProductUsage()
        {
            lsvProductUsageT.BeginUpdate();
            lsvProductUsageT.Items.Clear();

            int index = 0;
            foreach (ConsumableUsage r in _consum.ConsumableUsages)
            {
                if (r.PerTest == true)
                {
                    LQTListViewTag tag = new LQTListViewTag();
                    tag.GroupTitle = r.Product.ProductType.TypeName;
                    tag.Id = r.Id;
                    tag.Index = index;
                    ListViewItem li = new ListViewItem(r.Product.ProductName) { Tag = tag };
                    li.SubItems.Add(r.NoOfTest.ToString());
                    li.SubItems.Add(r.ProductUsageRate.ToString());

                    LqtUtil.AddItemToGroup(lsvProductUsageT, li);
                    lsvProductUsageT.Items.Add(li);
                    index++;
                }
            }

            lsvProductUsageT.EndUpdate();

        }
        
        private void BindProductUsageP()
        {
            lsvProductUsageP.BeginUpdate();
            lsvProductUsageP.Items.Clear();

            int index = 0;
            foreach (ConsumableUsage r in _consum.ConsumableUsages)
            {
                if (r.PerPeriod == true)
                {

                    LQTListViewTag tag = new LQTListViewTag();
                    tag.GroupTitle = r.Product.ProductType.TypeName;
                    tag.Id = r.Id;
                    tag.Index = index;
                    ListViewItem li = new ListViewItem(r.Product.ProductName) { Tag = tag };

                    li.SubItems.Add(r.Period.ToString());
                    li.SubItems.Add(r.ProductUsageRate.ToString());

                    LqtUtil.AddItemToGroup(lsvProductUsageP, li);
                    lsvProductUsageP.Items.Add(li);
                    index++;
                }
            }

            lsvProductUsageP.EndUpdate();

        }

        private void BindProductUsageI()
        {
            lsvProductUsageI.BeginUpdate();
            lsvProductUsageI.Items.Clear();

            int index = 0;
            foreach (ConsumableUsage r in _consum.ConsumableUsages)
            {
                if (r.PerInstrument == true)
                {
                    LQTListViewTag tag = new LQTListViewTag();
                    tag.GroupTitle = r.Instrument.InstrumentName;
                    tag.Id = r.Id;
                    tag.Index = index;
                    ListViewItem li = new ListViewItem(r.Product.ProductName) { Tag = tag };

                    li.SubItems.Add(r.Period.ToString());
                    li.SubItems.Add(r.ProductUsageRate.ToString());

                    LqtUtil.AddItemToGroup(lsvProductUsageI, li);
                    lsvProductUsageI.Items.Add(li);
                    index++;
                }
            }

            lsvProductUsageI.EndUpdate();

        }
      
        public LQTUserMessage SaveOrUpdateObject()
        {
           
            if (comTestarea.SelectedIndex < 0)
                throw new LQTUserException("Testing Area can not be empty.");

            if (_consum.TestingArea == null )
            {
                _consum.TestingArea = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
               
            }
            if (comTest.SelectedIndex > -1)
                _consum.Test = (Test)_consum.TestingArea.Tests[comTest.SelectedIndex];// LqtUtil.GetComboBoxValue<Test>(comTest);
            DataRepository.SaveOrUpdateConsumables(_consum);
            return new LQTUserMessage("Consumable was saved or updated successfully.");
        }

        void lsvProductUsageT_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)e.ListVItem.Tag;
            ListViewItem li = e.ListVItem;
            ConsumableUsage cu;// = (ProductUsage)li.Tag;

            if (tag.Id > 0)
                cu = _consum.GetConsumableUsage(tag.Id);
            else
               // cu = _consum.ConsumableUsages[tag.Index];
               cu = _consum.GetPerTestUsage()[tag.Index];

            try
            {
                decimal rate = decimal.Parse(li.SubItems[2].Text);
                cu.ProductUsageRate = rate;
            }
            catch
            {
                li.SubItems[1].Text = cu.ProductUsageRate.ToString();
            }

            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this, new EventArgs());
            }
        }

        void lsvProductUsageP_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)e.ListVItem.Tag;
            ListViewItem li = e.ListVItem;
            ConsumableUsage cu;// = (ProductUsage)li.Tag;

            if (tag.Id > 0)
                cu = _consum.GetConsumableUsage(tag.Id);
            else
                cu = _consum.GetPerPeriodUsage()[tag.Index];


            try
            {
                decimal rate = decimal.Parse(li.SubItems[2].Text);
                cu.ProductUsageRate = rate;
            }
            catch
            {
                li.SubItems[1].Text = cu.ProductUsageRate.ToString();
            }

            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this, new EventArgs());
            }
        }
      
        void lsvProductUsageI_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)e.ListVItem.Tag;
            ListViewItem li = e.ListVItem;
            ConsumableUsage cu;// = (ProductUsage)li.Tag;

            if (tag.Id > 0)
                cu = _consum.GetConsumableUsage(tag.Id);
            else
               // cu = _consum.ConsumableUsages[tag.Index];
            cu = _consum.GetPerInstrumentUsage()[tag.Index];


            try
            {
                decimal rate = decimal.Parse(li.SubItems[2].Text);
                cu.ProductUsageRate = rate;
            }
            catch
            {
                li.SubItems[1].Text = cu.ProductUsageRate.ToString();
            }

            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this, new EventArgs());
            }
        }
       
        private void butAddI_Click(object sender, EventArgs e)
        {
            //Instrument ins = LqtUtil.GetComboBoxValue<Instrument>(comInstrumentI);
            //if (ins != null)
            //{
            //    MasterProduct pro = LqtUtil.GetComboBoxValue<MasterProduct>(comProductI);
            //    if (pro != null)
            //    {
            //        if (!_consum.IsExsistProductUsage(ins.Id, pro.Id))
            //        {
            //            ProductUsage pu = new ProductUsage();
            //            pu.Test = _consum;
            //            pu.Instrument = ins;
            //            pu.Product = pro;
            //            pu.Rate = 1;
            //            _consum.ProductUsages.Add(pu);

            //            BindProductUsage();
            //            if (OnDataUsageEdit != null)
            //            {
            //                OnDataUsageEdit(this, new EventArgs());
            //            }
            //        }
            //    }
            //}
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            //LQTListViewTag tag = (LQTListViewTag)lsvProductUsageT.SelectedItems[0].Tag;

            //ProductUsage pu;
            //if (lsvProductUsageT.SelectedItems.Count > 0)
            //{
            //    if ((MessageBox.Show("Are you sure, do you want to remove it?", "Product Usage", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            //    {


            //        if (tag.Id > 0)
            //            pu = _consum.GetProductUsage(tag.Id);
            //        else
            //            pu = _consum.ProductUsages[tag.Index];
            //        _consum.ProductUsages.Remove(pu);

            //        BindProductUsage();
            //        if (OnDataUsageEdit != null)
            //        {
            //            OnDataUsageEdit(this, new EventArgs());
            //        }
            //    }
            //}
        }

        private void lsvProductUsage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvProductUsageT.SelectedItems.Count > 0)
            {
                butRemoveT.Enabled = true;
            }
            else
                butRemoveT.Enabled = false;
        }

        private void comTestarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comTestarea.SelectedIndex>=0)
            {
                butAddT.Enabled = true;
                butAddP.Enabled = true;
                EnableSaveButton(this, new EventArgs());
            }
            PopTest();
            PopInstrument();
        }

        private void butAddT_Click(object sender, EventArgs e)
        {
                MasterProduct pro = LqtUtil.GetComboBoxValue<MasterProduct>(comProductT);
                if (pro != null)
                {
                    if (!_consum.IsExsistUsageRatePerTest(pro.Id))
                    {
                        if (txtNoofTest.Text != "0")
                        {
                            ConsumableUsage cu = new ConsumableUsage();
                            cu.NoOfTest = int.Parse(txtNoofTest.Text);
                            cu.PerTest = true;
                            cu.Product = pro;
                            cu.ProductUsageRate = 1;
                            cu.MasterConsumable = _consum;
                            _consum.ConsumableUsages.Add(cu);
                            BindProductUsage();
                            if (OnDataUsageEdit != null)
                            {
                                OnDataUsageEdit(this, new EventArgs());
                            }
                        }
                    }
                }
            }

        private void butAddP_Click(object sender, EventArgs e)
        {
            MasterProduct pro = LqtUtil.GetComboBoxValue<MasterProduct>(comProductP);
            if (pro != null)
            {
                if  (comPeriodP.SelectedValue != null)
                {

                    if (!_consum.IsExsistUsageRatePerPeriod(pro.Id))
                    {
                        ConsumableUsage cu = new ConsumableUsage();
                        cu.Period = comPeriodP.SelectedValue.ToString();
                        cu.PerPeriod = true;
                        cu.Product = pro;
                        cu.ProductUsageRate = 1;
                        cu.MasterConsumable = _consum;
                        _consum.ConsumableUsages.Add(cu);
                        BindProductUsageP();
                        if (OnDataUsageEdit != null)
                        {
                            OnDataUsageEdit(this, new EventArgs());
                        }
                    }
                }
            }

        }

        private void butAddI_Click_1(object sender, EventArgs e)
        {

            Instrument ins = LqtUtil.GetComboBoxValue<Instrument>(comInstrumentI);
            if (ins != null)
            {

                MasterProduct pro = LqtUtil.GetComboBoxValue<MasterProduct>(comProductI);
                if (pro != null)
                {
                    //if (! _consum.IsExsistProductUsage(ins.Id, pro.Id))
                    // {
                    if (comPeriodI.SelectedValue != null)
                    {
                        if (!_consum.IsExsistUsageRatePerInst(ins.Id,pro.Id))
                        {

                            ConsumableUsage cu = new ConsumableUsage();
                            cu.Period = comPeriodI.Text;
                            cu.PerInstrument = true;
                            cu.Product = pro;
                            cu.Instrument = ins;
                            cu.ProductUsageRate = 1;
                            cu.MasterConsumable = _consum;
                            _consum.ConsumableUsages.Add(cu);
                            BindProductUsageI();
                            if (OnDataUsageEdit != null)
                            {
                                OnDataUsageEdit(this, new EventArgs());
                            }
                        }
                    }
                }
            }
        }

        private void lsvProductUsageP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvProductUsageP.SelectedItems.Count > 0)
            {
                butRemoveP.Enabled = true;
            }
            else
                butRemoveP.Enabled = false;
        }

        private void lsvProductUsageI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvProductUsageI.SelectedItems.Count > 0)
            {
                butRemoveI.Enabled = true;
            }
            else
                butRemoveI.Enabled = false;
        }

        private void butRemoveT_Click(object sender, EventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)lsvProductUsageT.SelectedItems[0].Tag;

            ConsumableUsage cu;
            if (lsvProductUsageT.SelectedItems.Count > 0)
            {
                if ((MessageBox.Show("Are you sure, do you want to remove it?", "Product Usage", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {


                    if (tag.Id > 0)
                        cu =_consum.GetConsumableUsage(tag.Id);
                    else
                       // cu = _consum.ConsumableUsages[tag.Index];
                        cu = _consum.GetPerTestUsage()[tag.Index];
                    _consum.ConsumableUsages.Remove(cu);

                    BindProductUsage();
                    if (OnDataUsageEdit != null)
                    {
                        OnDataUsageEdit(this, new EventArgs());
                    }
                }
            }
        }

        private void butRemoveP_Click(object sender, EventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)lsvProductUsageP.SelectedItems[0].Tag;

            ConsumableUsage cu;
            if (lsvProductUsageP.SelectedItems.Count > 0)
            {
                if ((MessageBox.Show("Are you sure, do you want to remove it?", "Product Usage", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {


                    if (tag.Id > 0)
                        cu = _consum.GetConsumableUsage(tag.Id);
                    else
                       // cu = _consum.ConsumableUsages[tag.Index];
                        cu = _consum.GetPerPeriodUsage()[tag.Index];
                    _consum.ConsumableUsages.Remove(cu);

                    BindProductUsageP();
                    if (OnDataUsageEdit != null)
                    {
                        OnDataUsageEdit(this, new EventArgs());
                    }
                }
            }
        }

        private void butRemoveI_Click(object sender, EventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)lsvProductUsageI.SelectedItems[0].Tag;

            ConsumableUsage cu;
            if (lsvProductUsageI.SelectedItems.Count > 0)
            {
                if ((MessageBox.Show("Are you sure, do you want to remove it?", "Product Usage", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {


                    if (tag.Id > 0)
                        cu = _consum.GetConsumableUsage(tag.Id);
                    else
                       // cu = _consum.ConsumableUsages[tag.Index];
                        cu = _consum.GetPerInstrumentUsage()[tag.Index];
                    _consum.ConsumableUsages.Remove(cu);

                    BindProductUsageI();
                    if (OnDataUsageEdit != null)
                    {
                        OnDataUsageEdit(this, new EventArgs());
                    }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                BindProductUsage();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                BindProductUsageP();
            }
            else
            {
                BindProductUsageI();
            }

        }

       

        }
    }

