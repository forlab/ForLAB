
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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Testing;
using LQT.Core.UserExceptions;
using LQT.GUI.MorbidityUserCtr;

namespace LQT.GUI.UserCtr
{
    public partial class ListSupplyListPane : BaseUserControl
    {
        private ClassOfMorbidityTestEnum _filiterBy;
        private IList<MasterProduct> _products;
        private IList<QuantifyMenu> _qMenus;
        private SiteListView _sListView;
        private int _selectedTestId = 0;

        public ListSupplyListPane(ClassOfMorbidityTestEnum filiterby)
        {
            _filiterBy = filiterby;
            this._products = DataRepository.GetAllProductByClassOfTest(filiterby.ToString());
            if (filiterby != ClassOfMorbidityTestEnum.Consumable)
                this._qMenus = DataRepository.GetAllQuantifyMenuByClass(_filiterBy.ToString());
            else
                this._qMenus = DataRepository.GetAllGeneralQuantifyMenus();

            InitializeComponent();
            LoadSiteListView();

            PopTests();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Selected Product Information List";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopTests();
        }


        private void PopTests()
        {
            _sListView.BeginUpdate();
            _sListView.Items.Clear();

            foreach (QuantificationMetric qm in DataRepository.GetAllQuantificationMetricByClass(_filiterBy.ToString()))
            {
                EXListViewItem li = new EXListViewItem(qm.Product.ProductName) { Tag = qm };

                li.SubItems.Add(new EXListViewSubItem(qm.Product.BasicUnit));
                li.SubItems.Add(new EXListViewSubItem(qm.UsageRate.ToString(), "U.Rate"));
                li.SubItems.Add(new EXListViewSubItem(qm.QuantifyMenu.Title));
                li.SubItems.Add(new EXListViewSubItem(qm.CollectionSupplieAppliedTo, "Supplies"));

                _sListView.Items.Add(li);
            }
            _sListView.EndUpdate();
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
            _sListView.Columns.Add(new EXColumnHeader("Quantify According to...", 100));

            exEditCol = new EXEditableColumnHeader("Supplies Apply to", _comSupplies, 100);
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
            DataRepository.SaveOrUpdateQuantificationMetric(qm);
        }

        private void sListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sListView.SelectedItems.Count > 0)
                _selectedTestId = ((QuantificationMetric)_sListView.SelectedItems[0].Tag).Id;
            else
                _selectedTestId = 0;
            SelectedItemChanged(_sListView);
        }

        private QuantificationMetric GetSelectedTest()
        {
            if (_sListView.SelectedItems.Count > 0)
                return (QuantificationMetric)_sListView.SelectedItems[0].Tag;
            return null;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSelectPro frm = new FrmSelectPro(_qMenus, _products);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopTests();
            }
        }


        public override void EditSelectedItem()
        {

        }

        public override bool DeleteSelectedItem()
        {
            if (GetSelectedTest() != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Selected Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataRepository.DeleteQuantificationMetric(GetSelectedTest());
                        MdiParentForm.ShowStatusBarInfo("Selected Product was deleted successfully.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry, you could not delete this product." }).ShowDialog();
                    }
                    finally
                    {
                        DataRepository.CloseSession();
                    }
                }
            }
            return false;
        }
    }
}
