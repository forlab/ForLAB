using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.Testing
{
    public partial class ListQuanMetric : UserControl
    {
        private QuantifyMenu _qMenu;
        private TabPage _parentTab;
        private IList<MasterProduct> _products;

        public ListQuanMetric()
        {
            InitializeComponent();
            _products = DataRepository.GetAllProduct();
        }

        public QuantifyMenu QuantifyMenu
        {
            set { _qMenu = value; }
        }

        public TabPage ParentTab
        {
            get { return _parentTab; }
            set { _parentTab = value; }
        }

        public void BindQuantifyMenu()
        {
            PopListView();
        }

        private void PopListView()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            if (_qMenu != null)
            {
                foreach (QuantificationMetric qm in _qMenu.QuantificationMetrics)
                {
                    ListViewItem li = new ListViewItem(qm.Product.ProductName) { Tag = qm };
                    li.SubItems.Add(qm.UsageRate.ToString());
                    li.SubItems.Add(qm.QuantifyMenu.Title);
                    li.SubItems.Add(qm.CollectionSupplieAppliedTo);

                    listView1.Items.Add(li);
                }
            }

            listView1.EndUpdate();
            lbtRemoveReagent.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                lbtRemoveReagent.Enabled = true;
            else
                lbtRemoveReagent.Enabled = false;
        }

        private void lbtAddReagent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSelectPro frm = new FrmSelectPro(_qMenu.GetSelectedProductId(), _products);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (MasterProduct p in frm.SelectedProducts)
                {
                    QuantificationMetric q = new QuantificationMetric();
                    q.ClassOfTest = _qMenu.ClassOfTest;
                    q.CollectionSupplieAppliedTo = CollectionSupplieAppliedToEnum.Testing.ToString();
                    q.Product = p;
                    q.QuantifyMenu = _qMenu;
                    q.UsageRate = 1;
                    _qMenu.QuantificationMetrics.Add(q);
                }

                PopListView();
            }
        }

        private void lbtRemoveReagent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                QuantificationMetric qm = listView1.SelectedItems[0].Tag as QuantificationMetric;
                _qMenu.QuantificationMetrics.Remove(qm);
                PopListView();
            }
        }
    }
}
