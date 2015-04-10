
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
    public partial class ListMorbidityTestPane : BaseUserControl
    {
        private ClassOfMorbidityTestEnum _filiterBy;
        private IList<MasterProduct> _products;
        private int _selectedTestId = 0;
        private SiteListView _sListView;
        private IList<QuantifyMenu> _qMenus;

        public ListMorbidityTestPane(ClassOfMorbidityTestEnum filiterby)
        {
            this._filiterBy = filiterby;
            this._products = DataRepository.GetAllProductByClassOfTest(filiterby.ToString());
            this._qMenus = DataRepository.GetGeneralQuantifyMenuByClass(filiterby.ToString());

            InitializeComponent();
            
            LoadGeneralQMView();
            PopTests();
            PopGeneralQM();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Tests";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopTests();
        }

        private IList<MorbidityTest> GetTests()
        {
            IList<MorbidityTest> result = DataRepository.GetAllMorbidityTestByClass(_filiterBy.ToString());
            if (result == null)
                result = new List<MorbidityTest>();
            return result;
        }

        private void PopTests()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (MorbidityTest tg in GetTests())
            {
                ListViewItem li = new ListViewItem(tg.TestName) { Tag = tg.Id };
                li.SubItems.Add(tg.ClassOfTest);
                li.SubItems.Add(tg.Instrument.InstrumentName);
                if (tg.Id == _selectedTestId)
                    li.Selected = true;

                listView1.Items.Add(li);
            }

            listView1.EndUpdate();
        }

        private MorbidityTest GetSelectedTest()
        {
           return DataRepository.GetMorbidityTestById(_selectedTestId);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            //listView1.Columns[1].Width = listView1.Width - 255;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMorbidityTest frm = new FrmMorbidityTest(new MorbidityTest() { ClassOfTest = _filiterBy.ToString() }, MdiParentForm);
            frm.ShowDialog();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                _selectedTestId = Convert.ToInt32(listView1.SelectedItems[0].Tag);
            else
                _selectedTestId = 0;
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            if (_selectedTestId > 0)
            {
                FrmMorbidityTest frm = new FrmMorbidityTest(GetSelectedTest(), MdiParentForm);
                frm.ShowDialog();
            }
        }

        public override bool DeleteSelectedItem()
        {
            if (_selectedTestId > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this Test?", "Delete Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataRepository.DeleteMorbidityTest(GetSelectedTest());
                        MdiParentForm.ShowStatusBarInfo("Test was deleted successfully.");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry, you could not delete this test." }).ShowDialog();
                    }
                    finally
                    {
                        DataRepository.CloseSession();
                    }
                }
            }
            return false;
        }

       
        #region General QM

        private void PopGeneralQM()
        {
            _sListView.BeginUpdate();
            _sListView.Items.Clear();

            foreach (QuantifyMenu qmenu in _qMenus)
            {
                foreach (QuantificationMetric qm in qmenu.QuantificationMetrics)
                {
                    EXListViewItem li = new EXListViewItem(qm.Product.ProductName) { Tag = qm };

                    li.SubItems.Add(new EXListViewSubItem(qm.Product.BasicUnit));
                    li.SubItems.Add(new EXListViewSubItem(qm.UsageRate.ToString(), "U.Rate"));
                    li.SubItems.Add(new EXListViewSubItem(qm.QuantifyMenu.DisplayTitle));
                    li.SubItems.Add(new EXListViewSubItem(qm.CollectionSupplieAppliedTo, "Supplies"));

                    _sListView.Items.Add(li);
                }
            }
            _sListView.EndUpdate();
        }

        private ComboBox _comSupplies;

        private void LoadGeneralQMView()
        {
            _sListView = new SiteListView();
            _sListView.MySortBrush = SystemBrushes.ControlLight;
            _sListView.MyHighlightBrush = Brushes.Goldenrod;
            _sListView.GridLines = true;
            _sListView.MultiSelect = false;
            _sListView.Dock = DockStyle.Fill;
            _sListView.ControlPadding = 4;
            _sListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            _sListView.Scrollable = true;

            _comSupplies = new ComboBox();
            _comSupplies.Items.AddRange(Enum.GetNames(typeof(CollectionSupplieAppliedToEnum)));

            //add columns and items
            _sListView.Columns.Add(new EXColumnHeader("Product", 100));
            _sListView.Columns.Add(new EXColumnHeader("B.Unit", 60));
            EXEditableColumnHeader exEditCol = new EXEditableColumnHeader("U.Rate", 60);
            _sListView.Columns.Add(exEditCol);
            _sListView.Columns.Add(new EXColumnHeader("Quantify According to...", 100));

            exEditCol = new EXEditableColumnHeader("Supplies Apply to", _comSupplies, 100);
            _sListView.Columns.Add(exEditCol);

            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            _sListView.SelectedIndexChanged += new EventHandler(_sListView_SelectedIndexChanged);
            panGeneral.Controls.Add(_sListView);
        }

        private void _sListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sListView.SelectedItems.Count > 0)
                lbtRemove.Enabled = true;
            else
                lbtRemove.Enabled = false;
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

        private QuantificationMetric GetSelectedGeneralQM()
        {
            if (_sListView.SelectedItems.Count > 0)
                return (QuantificationMetric)_sListView.SelectedItems[0].Tag;
            return null;
        }
        
        private void lbtAddGeneral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSelectPro frm = new FrmSelectPro(_qMenus, _products);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopGeneralQM();
            }
        }
               

        private void lbtRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuantificationMetric qmetric = GetSelectedGeneralQM();
            if (qmetric != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this Quantification Metric?", "Delete Quantification Metric", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        QuantifyMenu qm = qmetric.QuantifyMenu;
                        qm.QuantificationMetrics.Remove(qmetric);
                        DataRepository.SaveOrUpdateQuantifyMenu(qm);
                        PopGeneralQM();
                        lbtRemove.Enabled = false;
                        MdiParentForm.ShowStatusBarInfo("Quantification Metric was deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry, there are an error to delete this Quantification Metric." }).ShowDialog();
                    }
                }
            }
        }

 
        #endregion
    }
}
