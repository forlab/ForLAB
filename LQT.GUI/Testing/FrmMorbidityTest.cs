
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
using LQT.Core.UserExceptions;
using LQT.GUI.MorbidityUserCtr;

namespace LQT.GUI.Testing
{
    public partial class FrmMorbidityTest : Form
    {
        private MorbidityTest _morbidityTest;
        private LqtMainWindowForm _mdiParentForm;
        private IList<MasterProduct> _products;
        private SiteListView _sListView;
                
        public FrmMorbidityTest(MorbidityTest morbidityTest, LqtMainWindowForm MdiParentForm)
        {
            this._morbidityTest = morbidityTest;
            this._mdiParentForm = MdiParentForm;
            this._products = DataRepository.GetAllProductByClassOfTest(_morbidityTest.ClassOfTest);

            
            InitializeComponent();
                    LoadSiteListView();  

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);
            
            PopInstrument();
            BindMorbidityTest();
        }

        private void PopInstrument()
        {
            comInstrument.DataSource = DataRepository.GetListOfInstrumentByTestingArea(_morbidityTest.ClassOfTest);
        }

        private void BindMorbidityTest()
        {
            txtTestType.Text = _morbidityTest.ClassOfTest;
        
            if (_morbidityTest.Id > 0)
            {
                txtTestname.Text = _morbidityTest.TestName;
                comInstrument.SelectedValue = _morbidityTest.Instrument.Id;
                comInstrument.Enabled = false;
                PopListView();
            }
            else
            {
                txtTestname.Text = "";
                comInstrument.Enabled = true;
                //CreateQuantifyMenus();
            }

        }

        private void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {                
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiParentForm).ShowStatusBarInfo(msg.Message, true);

                MorbidityTest mtest = new MorbidityTest();
                mtest.ClassOfTest = _morbidityTest.ClassOfTest;
                _morbidityTest = mtest;
                BindMorbidityTest();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void lqtToolStrip1_SaveAndCloseClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiParentForm).ShowStatusBarInfo(msg.Message, true);

                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private LQTUserMessage SaveOrUpdateObject()
        {
            if (_morbidityTest.Id <= 0)
            {
                Instrument ins = LqtUtil.GetComboBoxValue<Instrument>(comInstrument);
                if (ins == null)
                    throw new LQTUserException("Platform must not be empty.");
                this._morbidityTest.Instrument = ins;
                this._morbidityTest.TestName = ManageQuantificationMenus.BuildTestName(ins.InstrumentName, _morbidityTest.ClassOfTestEnum);
                ManageQuantificationMenus.CreateQuantifyMenus(_morbidityTest);
            }

            DataRepository.SaveOrUpdateMorbidityTest(_morbidityTest);

            return new LQTUserMessage("Test was saved or updated successfully.");
        }

        private void PopListView()
        {
            _sListView.Items.Clear();
            _sListView.BeginUpdate();

            foreach(QuantifyMenu qmenu in _morbidityTest.QuantifyMenus)
            {
                foreach (QuantificationMetric qm in qmenu.QuantificationMetrics)
                {
                    EXListViewItem li = new EXListViewItem(qm.Product.ProductName) { Tag = qm };

                    li.SubItems.Add(new EXListViewSubItem(qm.Product.BasicUnit));
                    li.SubItems.Add(new EXListViewSubItem(qm.UsageRate.ToString(), "U.Rate"));
                    li.SubItems.Add(new EXListViewSubItem(qm.QuantifyMenu.Title.Replace('_', ' ')));
                    li.SubItems.Add(new EXListViewSubItem(qm.CollectionSupplieAppliedTo, "Supplies"));
                    
                   _sListView.Items.Add(li);
                }
            }

            _sListView.EndUpdate();
            lbtRemoveReagent.Enabled = false;
        }


        private void lbtAddReagent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSelectPro frm = new FrmSelectPro(_morbidityTest, _products);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopListView();
            }
        }

        private void lbtRemoveReagent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((_sListView.SelectedItems.Count > 0) && MessageBox.Show("Are you sure, do you want to remove it?", "ART-Test Reagent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                QuantificationMetric metric = _sListView.SelectedItems[0].Tag as QuantificationMetric;
                QuantifyMenu qm = _morbidityTest.GetQuantifyMenuById(metric.QuantifyMenu.Id);
                qm.QuantificationMetrics.Remove(metric);

                DataRepository.SaveOrUpdateMorbidityTest(_morbidityTest);

                PopListView();
            }
        }

        private void FrmMorbidityTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataRepository.CloseSession();
        }

        private ComboBox _comSupplies;
        
        private void LoadSiteListView()
        {
            _sListView = new SiteListView();
            _sListView.MySortBrush = SystemBrushes.ControlLight;
            _sListView.MyHighlightBrush = Brushes.Goldenrod;
            _sListView.GridLines = true;
            _sListView.MultiSelect = false;
            _sListView.Dock = DockStyle.Fill;
            _sListView.ControlPadding = 4;
            _sListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            _comSupplies = new ComboBox();
            _comSupplies.Items.AddRange(Enum.GetNames(typeof(CollectionSupplieAppliedToEnum)));    

            //add columns and items
            _sListView.Columns.Add(new EXColumnHeader("Product", 150));
            _sListView.Columns.Add(new EXColumnHeader("B.Unit", 60));
            EXEditableColumnHeader exEditCol = new EXEditableColumnHeader("U.Rate", 60);
            _sListView.Columns.Add(exEditCol);
            _sListView.Columns.Add(new EXColumnHeader("Quantify According to...", 150));

            exEditCol = new EXEditableColumnHeader("Supplies Apply to",_comSupplies, 100);
            _sListView.Columns.Add(exEditCol);

            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            _sListView.SelectedIndexChanged += new EventHandler(sListView_SelectedIndexChanged);
            panProduct.Controls.Add(_sListView);
        }

        private void _sListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            QuantificationMetric qm = (QuantificationMetric)e.ListVItem.Tag;

            if (e.SubItem.ColumnName.ToString() == "U.Rate")
            {
                try
                {
                    qm.UsageRate = Convert.ToDouble(e.SubItem.Text);
                }
                catch
                {
                    e.SubItem.Text = qm.UsageRate.ToString();
                }
            }
            else
            {
                qm.CollectionSupplieAppliedTo = e.SubItem.Text;
            }
        }

        private void sListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sListView.SelectedItems.Count <= 0)
                lbtRemoveReagent.Enabled = false;
            else
                lbtRemoveReagent.Enabled = true;
        }
    }
}
