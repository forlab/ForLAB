
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.Testing
{
    public partial class FrmImportQMenu : Form
    {  
        private IList<ImportQVariableData> _rdata;
        
        public FrmImportQMenu()
        {
            InitializeComponent();
        }
        
       
        private void butBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtFilename.Text = openFileDialog1.FileName;
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilename.Text.Trim()))
                return;
            try
            {
                DataSet ds = LqtUtil.ReadExcelFile(txtFilename.Text, 4);

                _rdata = GetDataRow(ds);
                bool haserror = false;

                lvImport.BeginUpdate();
                lvImport.Items.Clear();

                foreach (ImportQVariableData rd in _rdata)
                {
                    ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                    li.SubItems.Add(rd.ProductName);                    
                    li.SubItems.Add(rd.UsageRate.ToString());
                    li.SubItems.Add(rd.QuantifyMenu);
                    li.SubItems.Add(rd.AppliedTo);                   
                    li.SubItems.Add(rd.IsExist ? "Yes" : "No");
                    li.SubItems.Add(rd.ErrorDescription);

                    if (rd.HasError)
                    {
                        li.BackColor = Color.Red;
                        haserror = true;
                    }
                    else if (rd.IsExist)
                    {
                        li.BackColor = Color.Green;
                    }
                    lvImport.Items.Add(li);
                }

                lvImport.EndUpdate();

                butClear.Enabled = true;
                //if (!haserror)
                    butSave.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            lvImport.BeginUpdate();
            lvImport.Items.Clear();
            lvImport.EndUpdate();
            butSave.Enabled = false;
            butClear.Enabled = false;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            int count = 0;
            try
            {
                foreach (QuantifyMenu qm in _modifiedQuantifyMenus.Values)
                {
                    count++;
                    DataRepository.SaveOrUpdateQuantifyMenu(qm);
                }
                MessageBox.Show(count + " Quantification variable are imported and saved successfully.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error: Unable to import and save Quantification variable.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();
            }
        }

        IDictionary<int, QuantifyMenu> _modifiedQuantifyMenus;
        private void AddModifiedQMenu(QuantifyMenu qmenu)
        {
            if (!_modifiedQuantifyMenus.ContainsKey(qmenu.Id))
                _modifiedQuantifyMenus.Add(qmenu.Id, qmenu);
        }

        private IList<ImportQVariableData> GetDataRow(DataSet ds)
        {
            DataRepository.CloseSession();

            int rowno = 0;
            IList<ImportQVariableData> rdlist = new List<ImportQVariableData>();
            double usagerate;
            _modifiedQuantifyMenus = new Dictionary<int, QuantifyMenu>();
            _listofQmenus = null;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rowno++;
                if (!DatarowValueToDouble(dr[1], out usagerate))
                    usagerate = 1;

                ImportQVariableData rd = new ImportQVariableData(Convert.ToString(dr[0]), usagerate, Convert.ToString(dr[2]), Convert.ToString(dr[3]), rowno);
                rdlist.Add(rd);
            }

            foreach (ImportQVariableData rd in rdlist)
            {
                if (!string.IsNullOrEmpty(rd.ProductName))
                {
                    rd.Product = DataRepository.GetProductByName(rd.ProductName);
                    if (rd.Product != null)
                    {
                        if (!string.IsNullOrEmpty(rd.QuantifyMenu))
                        {
                            QuantifyMenu qm = GetQuantifyMenuByTitle(rd.QuantifyMenu);
                            if (qm != null)
                            {
                                if (qm.IsProductSelected(rd.Product.Id))
                                {
                                    rd.IsExist = true;
                                    rd.ErrorDescription = "Already this quantification variable is existed";
                                }
                                else
                                {
                                    QuantificationMetric qmetric = new QuantificationMetric();
                                    qmetric.ClassOfTest = qm.ClassOfTest;
                                    qmetric.CollectionSupplieAppliedTo = rd.AppliedTo;
                                    qmetric.Product = rd.Product;
                                    qmetric.QuantifyMenu = qm;
                                    qmetric.UsageRate = rd.UsageRate;

                                    qm.QuantificationMetrics.Add(qmetric);
                                    AddModifiedQMenu(qm);
                                }
                            }
                            else
                            {
                                rd.HasError = true;
                                rd.ErrorDescription = "Error: unable to found Quantification variable";
                            }
                        }
                        else
                        {
                            rd.HasError = true;
                            rd.ErrorDescription = "Error: Quantify according to is empty";
                        }

                    }
                    else
                    {
                        rd.HasError = true; ;
                        rd.ErrorDescription = "Error: unable to found a Product";
                    }
                }
                else
                {
                    rd.HasError = true;
                    rd.ErrorDescription = "Error: Product name is empty";
                }
            }

            return rdlist;
        }

        private bool DatarowValueToDouble(object drvalue, out double result)
        {
            return double.TryParse(Convert.ToString(drvalue), out result);
        }

        private IList<QuantifyMenu> _listofQmenus;
        private QuantifyMenu GetQuantifyMenuByTitle(string quaTitle)
        {
            if (_listofQmenus == null)
            {
                _listofQmenus = DataRepository.GetAllQuantifyMenus();
            }
            string title ="";
            foreach (QuantifyMenu qm in _listofQmenus)
            {
                title = qm.Title.Replace('_', ' ').Trim();
                if (title.Equals(quaTitle, StringComparison.OrdinalIgnoreCase))
                    return qm;
            }
            return null;
        }

        
        private class ImportQVariableData
        {
            private int _rowno;
            private string _productName;
            private double _usageRate;
            private string _quantifyMenu;
            private string _appliedTo;
            private MasterProduct _product;
            private bool _haserror = false;
            private bool _isexist = false;
            private string _errorDescription;

            public ImportQVariableData(string productname, double usagerate, string quantifymenu, string appliedto, int rowno)
            {
                _rowno = rowno;
                _productName = productname;
                _usageRate = usagerate;
                _quantifyMenu = quantifymenu;
                _appliedTo = appliedto;
            }

            public string ProductName
            {
                get { return _productName; }
            }

            public MasterProduct Product
            {
                get { return _product; }
                set { _product = value; }
            }

            public double UsageRate
            {
                get { return _usageRate; }
            }
            public int RowNo
            {
                get { return _rowno; }
            }

            public bool HasError
            {
                get { return _haserror; }
                set { _haserror = value; }
            }

            public bool IsExist
            {
                get { return _isexist; }
                set { _isexist = value; }
            }
            public string ErrorDescription
            {
                get { return _errorDescription; }
                set { _errorDescription = value; }
            }
            public string  QuantifyMenu
            {
                get { return _quantifyMenu; }
            }
            public string AppliedTo
            {
                get { return _appliedTo; }
            }
        }

        private void FrmImportQMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataRepository.CloseSession();
        }
    }

}
