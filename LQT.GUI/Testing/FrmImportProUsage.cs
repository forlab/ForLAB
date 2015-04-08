
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
using LQT.Core.Domain;
using LQT.Core.Util;
using System.Collections;

namespace LQT.GUI.Testing
{
    public partial class FrmImportProUsage : Form
    {
        private IList<ImportProUsageData> _rdata;
        public FrmImportProUsage()
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
                string errorString;

                foreach (ImportProUsageData rd in _rdata)
                {
                    string str;
                    errorString = "";
                    ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                  
                    li.SubItems.Add(rd.TestName);
                    li.SubItems.Add(rd.InstrumentName);                    
                    li.SubItems.Add(rd.ProName);                    
                    li.SubItems.Add(rd.Rate.ToString());
                    str = rd.IsExist ? "Yes" : "No";

                    foreach (ListViewItem Item in lvImport.Items)
                    {
                        if (Item.SubItems[1].Text.Trim().ToLower() == rd.TestName.Trim().ToLower() && Item.SubItems[2].Text.Trim().ToLower() == rd.InstrumentName.Trim().ToLower().ToLower() && Item.SubItems[3].Text.Trim().ToLower() == rd.ProName.Trim().ToLower())
                        {
                            rd.IsExist = true;
                            str = "Duplicated";
                        }

                    }

                    li.SubItems.Add(str);

                    if (rd.HasError)
                    {
                        if (rd.TestName == "")
                            errorString = errorString + " Test Name Required";
                        if (rd.InstrumentName == "")
                            errorString = errorString + " Instrument Name Required";
                        if (rd.ProName == "")
                            errorString = errorString + " Product Name Required";                      
                        if (rd.Test == null)
                            errorString = errorString + " Test Doesn't Exist";
                        if (rd.Instrument == null)
                            errorString = errorString + " Instrument Doesn't Exist";
                        if (rd.Product == null)
                            errorString = errorString + " Product Doesn't Exist";
                       

                        li.BackColor = Color.Red;
                        haserror = true;
                    }
                    if (rd.IsExist)
                    {
                        li.BackColor = Color.Yellow;
                    }
                    li.SubItems.Add(errorString);
                    lvImport.Items.Add(li);
                }
                sort();
                lvImport.EndUpdate();

                butClear.Enabled = true;
                if (!haserror)
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
            int error = 0;
            try
            {
                foreach (ImportProUsageData rd in _rdata)
                {
                    if (!rd.IsExist)
                    {
                        ProductUsage pu = new ProductUsage();
                        pu.Instrument = rd.Instrument;
                        pu.Product = rd.Product;
                        pu.Rate = rd.Rate;
                        rd.Test.ProductUsages.Add(pu);
                        count++;
                        DataRepository.SaveOrUpdateTest(rd.Test);
                    }
                    else { error++; }

                }

                MessageBox.Show(count + "Product Usages are imported and saved successfully." + Environment.NewLine + error + " Products Failed.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error: Unable to imported and saved Product Usage data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();
            }
        }

        private IList<ImportProUsageData> GetDataRow(DataSet ds)
        {
           
            string testName;
            string insName;
            string proName;
            decimal rate;
            string tName = "";
            string iName = "";
            string pName = "";
          
            Test test = null;
            Instrument instrument = null;
           

            int rowno = 0;
            bool haserror;

            IList<ImportProUsageData> rdlist = new List<ImportProUsageData>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rowno++;
                haserror = false;


                testName = Convert.ToString(dr[0]).Trim();   //region name
                insName = Convert.ToString(dr[1]).Trim();
                proName = Convert.ToString(dr[2]).Trim();
                try
                {
                    rate = decimal.Parse( Convert.ToString(dr[3]),System.Globalization.NumberStyles.Float);
                }
                catch
                {
                    rate =1;
                }

                ImportProUsageData rd = new ImportProUsageData(testName, insName,proName , rate, rowno);

                if (tName != testName)
                {
                    if (!string.IsNullOrEmpty(testName))
                        test = DataRepository.GetTestByName(testName);
                    else
                        test = null;
                    tName = testName;
                }

                if (test != null)
                {
                    rd.Test = test;

                    if (iName != insName)
                    {
                        if (!String.IsNullOrEmpty(insName))
                            instrument = DataRepository.GetInstrumentByName(insName);
                        else
                            instrument = null;
                        iName = insName;
                    }

                    if (instrument != null)
                    {
                        rd.Instrument = instrument;

                        if (!String.IsNullOrEmpty(proName))
                        {
                            rd.Product = DataRepository.GetProductByName(proName);
                            if (rd.Product == null)
                                haserror = true;
                            else if (test.IsExsistProductUsage(instrument.Id, rd.Product.Id))
                            {
                                rd.IsExist = true;
                            }
                        }
                        else
                            haserror = true;
                    }
                    else
                        haserror = true;
                }
                else
                    haserror = true;
                                
                                
                rd.HasError = haserror;
                rdlist.Add(rd);
            }

            return rdlist;
        }


        private class ImportProUsageData
        {
          
            private string _testname;
            private string _insName;
            private string _proname;
            private decimal _rate;
            private int _rowno;
            private Test _test;
            private Instrument _instrument;
            private MasterProduct _product;
          
            private bool _haserror = false;
            private bool _isexist = false;

            public ImportProUsageData(string tname,string iname, string pname, decimal rate, int rowno)
            {
               
                _testname = tname;
                _insName = iname;
                _proname = pname;
                _rate = rate;
                _rowno = rowno;
            }

           
            public string TestName
            {
                get { return _testname; }
            }
            public string InstrumentName
            {
                get { return _insName; }
            }
            public string ProName
            {
                get { return _proname; }
            }
            public decimal Rate
            {
                get { return _rate; }
            }
            public int RowNo
            {
                get { return _rowno; }
            }

            public Test Test
            {
                get { return _test; }
                set { _test = value; }
            }
            public Instrument Instrument
            {
                get { return _instrument; }
                set { _instrument = value; }
            }
            public MasterProduct Product
            {
                get { return _product; }
                set { _product = value; }
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
        }
        private void sort() // private void lvImport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnClickEventArgs e = new ColumnClickEventArgs(6);
            // Create an instance of the ColHeader class.
            // ColHeader clickedCol = (ColHeader)this.lvImport.Columns[e.Column];
            //  ColumnHeader clickedCol = (ColumnHeader)this.lvImport.Columns[e.Column];
            // Set the ascending property to sort in the opposite order.
            //  clickedCol.ascending = !clickedCol.ascending;

            // Get the number of items in the list.
            int numItems = this.lvImport.Items.Count;

            // Turn off display while data is repoplulated.
            this.lvImport.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(this.lvImport.Items[i], e.Column));
            }

            // Sort the elements in the ArrayList using a new instance of the SortComparer
            // class. The parameters are the starting index, the length of the range to sort,
            // and the IComparer implementation to use for comparing elements. Note that
            // the IComparer implementation (SortComparer) requires the sort
            // direction for its constructor; true if ascending, othwise false.
            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(false));//(clickedCol.ascending));

            // Clear the list, and repopulate with the sorted items.
            this.lvImport.Items.Clear();
            for (int i = 0; i < numItems; i++)
                this.lvImport.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            // Turn display back on.
            this.lvImport.EndUpdate();

        }
    }
}
