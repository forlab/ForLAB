
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI.Testing
{
    public partial class FrmSelectPro : Form
    {
        private IList<int> _selectedPro;
        private IList<MasterProduct> _products;
        private MorbidityTest _morbidityTest;

        public FrmSelectPro(MorbidityTest mtest, IList<MasterProduct> products) : this(mtest.QuantifyMenus, products)
        {            
            _morbidityTest = mtest;          
        }

        public FrmSelectPro(IList<QuantifyMenu> qmenus,IList<MasterProduct> products)
        {
            _products = products;

            InitializeComponent();

            comClass.DataSource = qmenus;
            if (comClass.Items.Count > 0)
            {
                comClass.SelectedIndex = 0;
                SearchSelectedPro();
                BindProducts();
            }
            else
            {
                butSelect.Enabled = false;                
            }
        }

        private void BindProducts()
        {
            lvProductAll.BeginUpdate();
            lvProductAll.Items.Clear();

            foreach (MasterProduct p in _products)
            {
                if (!IsProductSelected(p.Id))
                {
                    ListViewItem li = new ListViewItem(p.ProductName) { Tag = p };
                    li.SubItems.Add(p.SerialNo);
                    li.SubItems.Add(p.BasicUnit);
                    li.SubItems.Add(p.Specification);
                    lvProductAll.Items.Add(li);
                }
            }

            lvProductAll.EndUpdate();
        }

        private void SearchSelectedPro()
        {
            if (_selectedPro == null)
                _selectedPro = new List<int>();
            else
                _selectedPro.Clear();

            QuantifyMenu qm = LqtUtil.GetComboBoxValue<QuantifyMenu>(comClass);
            foreach (QuantificationMetric m in qm.QuantificationMetrics)
            {
                _selectedPro.Add(m.Product.Id);
            }
        }

        private bool IsProductSelected(int proid)
        {
            foreach (int id in _selectedPro)
            {
                if (id == proid)
                    return true;
            }
            return false;
        }

        private void butSelect_Click(object sender, EventArgs e)
        {
            int len = lvProductAll.SelectedItems.Count;
            QuantifyMenu qm = LqtUtil.GetComboBoxValue<QuantifyMenu>(comClass);
            IList<QuantificationMetric> templits = new List<QuantificationMetric>();

            for (int i = 0; i < len; i++)
            {
                QuantificationMetric metric = new QuantificationMetric();
                metric.ClassOfTest = qm.ClassOfTest;
                metric.CollectionSupplieAppliedTo = CollectionSupplieAppliedToEnum.Testing.ToString();
                metric.Product = (MasterProduct)lvProductAll.SelectedItems[i].Tag;
                metric.QuantifyMenu = qm;
                metric.UsageRate = 1;
                qm.QuantificationMetrics.Add(metric);
                templits.Add(metric);
            }

            lstSelectedPro.BeginUpdate();
            
            foreach (QuantificationMetric m in templits)
            {
                ListViewItem li = new ListViewItem(m.Product.ProductName) { Tag = m };

                li.SubItems.Add(qm.DisplayTitle);

                lstSelectedPro.Items.Add(li);
            }

            lstSelectedPro.EndUpdate();
           
        }

        private void butCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void comClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchSelectedPro();
            BindProducts();
        }

        private IList<QuantifyMenu> _qmtosave = new List<QuantifyMenu>();
        private void butOk_Click(object sender, EventArgs e)
        {
            if (_morbidityTest == null)
            {                
                foreach (ListViewItem li in lstSelectedPro.Items)
                {                    
                    QuantificationMetric qm = (QuantificationMetric)li.Tag;
                    if (!IsQMSelectedToSave(qm.QuantifyMenu))
                        _qmtosave.Add(qm.QuantifyMenu);
                    //DataRepository.SaveOrUpdateQuantificationMetric(qm);
                }

                SaveQMenum();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private bool IsQMSelectedToSave(QuantifyMenu qm)
        {
            foreach (QuantifyMenu q in _qmtosave)
            {
                if (q.Id == qm.Id)
                    return true;
            }
            return false;
        }

        private void SaveQMenum()
        {
            foreach (QuantifyMenu q in _qmtosave)
            {
                DataRepository.SaveOrUpdateQuantifyMenu(q);
            }
        }
    }
}
