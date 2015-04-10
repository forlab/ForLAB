
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

using LQT.Core.Domain;
using LQT.Core.Util;
using System.Collections;

namespace LQT.GUI.Asset
{
    public partial class FrmImportPro : Form
    {
        private IList<ImportProductData> _rdata;

        public FrmImportPro()
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
                DataSet ds = LqtUtil.ReadExcelFile(txtFilename.Text, 10);

                _rdata = GetDataRow(ds);
                bool haserror = false;
                string errorString;

                lvImport.BeginUpdate();
                lvImport.Items.Clear();

                foreach (ImportProductData rd in _rdata)
                {
                    string str;
                    errorString="";
                    ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                    li.SubItems.Add(rd.ProductName);
                    li.SubItems.Add(rd.CategoryName);
                    li.SubItems.Add(rd.Serial);
                   
                    if (rd.Specification != null)
                    {
                        li.SubItems.Add(rd.Specification.ToString());//b
                    }
                    else
                    {
                        li.SubItems.Add("");
                    }

                    li.SubItems.Add(rd.BasicUnit);
                    li.SubItems.Add(rd.minSize.ToString());//b
                    
                    if (rd.RapidTest!=null)
                    {
                    li.SubItems.Add(rd.RapidTest.ToString());//b
                    }
                    else
                    {
                        li.SubItems.Add("");
                    }
                    
                    li.SubItems.Add(rd.Price.ToString());
                    li.SubItems.Add(rd.Packsize.ToString());
                    li.SubItems.Add(rd.PriceDate.ToShortDateString());

                    if (rd.CategoryName == string.Empty)
                        rd.HasError = true;

                    str = rd.IsExist? "Yes" : "No";
                    foreach (ListViewItem Item in lvImport.Items)
                    {
                        if (Item.SubItems[1].Text.Trim() == rd.ProductName.Trim() && Item.SubItems[2].Text.Trim() == rd.CategoryName.Trim())
                        {
                            rd.IsExist = true;
                            str = "Duplicated";
                        }

                    }
                    li.SubItems.Add(str);   
                    //li.SubItems.Add(str);

                    if (rd.HasError)
                    {
                        if (rd.ProductName == "")
                            errorString = errorString + " Product Name Required";
                        if (rd.CategoryName == "")
                            errorString = errorString + " Product Type Required";
                        if (rd.BasicUnit == "")
                            errorString = errorString + " Basic Unit Required";                       
                                              
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
            int error = 0;
            try
            {
                foreach (ImportProductData rd in _rdata)
                {
                    if (!rd.IsExist)
                    {
                        if (!rd.HasError)
                        { 
                            MasterProduct pro = new MasterProduct();
                            pro.ProductName = rd.ProductName;
                            pro.SerialNo = rd.Serial;
                            pro.BasicUnit = rd.BasicUnit;
                            pro.ProductType = rd.Category;
                            pro.Specification = rd.Specification;
                            pro.MinimumPackSize = rd.minSize;
                            pro.RapidTestGroup = rd.RapidTest;

                            ProductPrice pp = new ProductPrice();
                            pp.FromDate = rd.PriceDate;
                            pp.PackSize = rd.Packsize;
                            pp.Price = rd.Price;

                            pro.ProductPrices.Add(pp);
                            count++;
                            DataRepository.SaveOrUpdateProduct(pro);
                        }
                        else { error++; }
                    }else { error++; }
                    
                }

                MessageBox.Show(count + " Products are imported and saved successfully." + Environment.NewLine + error + " Products Failed.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                
                
            }
            catch
            {
                MessageBox.Show("Error: Unable to import and save product data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();
            }
        }

        private IList<ImportProductData> GetDataRow(DataSet ds)
        {
            string proName;
            string catName;
            string serial;
            string bunit;
            int psize;
            decimal price;
            string cName = "";
            ProductType category = null;
            int rowno = 0;
            bool haserror;
            ProductType defaultPt = DataRepository.GetProductTypeByName(MasterProduct.GetDefaultCategoryName);
            string rapidTest;
            string specification;
            int minSize;
            DateTime pricedate;
            if (defaultPt == null)
            {
                defaultPt = new ProductType();
                defaultPt.TypeName = MasterProduct.GetDefaultCategoryName;
                DataRepository.SaveOrUpdateProductType(defaultPt);
            }

            IList<ImportProductData> rdlist = new List<ImportProductData>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rowno++;
                haserror = false;
                proName = Convert.ToString(dr[0]).Trim();
                catName = Convert.ToString(dr[1]).Trim();   
                serial  = Convert.ToString(dr[2]);
                bunit   = Convert.ToString(dr[4]);
                category = DataRepository.GetProductTypeByName(catName);
                specification = Convert.ToString(dr[3]);
                bool testrapid = false;
                try
                {
                    if (category.UseInDemography)
                      {
                      string[] group= Enum.GetNames(typeof(TestingSpecificationGroup)); 
                        
                        if (category.ClassOfTestToEnum == ClassOfMorbidityTestEnum.RapidTest)
                          {
                              for (int i = 0; i < group.Length; i++)
                              {
                                  if (Convert.ToString(dr[6]) == group[i])
                                      testrapid = true;
                                     
                              }
                              if (testrapid)
                            rapidTest = Convert.ToString(dr[6]);//b
                              else
                                  rapidTest = null;
                          }
                          else
                              rapidTest = null;
                       }
                    else
                        rapidTest = null;
               
                }
                catch
                {
                    rapidTest = null;
                }
                try
                {
                    psize = int.Parse(Convert.ToString(dr[8]));
                }
                catch
                {
                    psize = 1;
                }
                try//b
                {
                    minSize = int.Parse(Convert.ToString(dr[5]));//b
                }
                catch
                {
                    minSize = 1;
                }

                try
                {
                    price = decimal.Parse(Convert.ToString(dr[7]));
                }
                catch
                {
                    price = 1;
                }

                try
                {
                    pricedate = DateTime.Parse(Convert.ToString(dr[9]));
                }
                catch
                {
                    pricedate = DateTime.Now;
                }

                ImportProductData rd = new ImportProductData(proName, catName, serial, bunit, psize, price, rowno, specification,minSize, rapidTest,pricedate);

                if (cName != catName)
                {
                    if (!string.IsNullOrEmpty(catName))
                    {
                        category = DataRepository.GetProductTypeByName(catName);
                        if (category == null)
                        {
                            category = new ProductType();
                            category.TypeName = catName;
                            DataRepository.SaveOrUpdateProductType(category);
                        }
                    }
                    else
                    {
                        category = defaultPt;
                    }
                    cName = catName;
                }
                
                


                rd.Category = category;

                if (!String.IsNullOrEmpty(proName))
                {

                    rd.IsExist = DataRepository.GetProductByTypeandName(proName,category.TypeName) != null;
                }
                else
                    haserror = true;


                rd.HasError = haserror;
                rdlist.Add(rd);
            }

            return rdlist;
        }
        
        
        private class ImportProductData
        {
            private string _proname;
            private string _catname;
            private string _serial;
            private string _unit;
            private int _size;
            private decimal _price;
            private int _rowno;
            private ProductType _protype;
            private bool _haserror = false;
            private bool _isexist = false;
            private string _rapidTest;//b
            private string _specification;//b
            private int _minSize;//b
            private DateTime _pricedate=DateTime.Now;

            public ImportProductData(string pname, string cname, string serial, string unit, int size, decimal price, int rowno, string specification,int minsize, string rapidTest,DateTime pricedate)
            {
                _proname = pname;
                _catname = cname;
                _serial = serial;
                _unit = unit;
                _size = size;
                _price = price;
                _rowno = rowno;
                _rapidTest = rapidTest;
                _specification = specification;
                _minSize = minsize;
                _pricedate = pricedate;
            }

            public string ProductName
            {
                get { return _proname; }
            }
            public string CategoryName
            {
                get { return _catname; }
            }
            public string Serial
            {
                get { return _serial; }
            }
            public string BasicUnit
            {
                get { return _unit; }
            }
            public int Packsize
            {
                get { return _size; }
            }
            public decimal Price
            {
                get { return _price; }
            }
            public int RowNo
            {
                get { return _rowno; }
            }

            public ProductType Category
            {
                get { return _protype; }
                set { _protype = value; }
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
            public string RapidTest
            {
                get { return _rapidTest; }
            }
            public string Specification
            {
                get { return _specification; }
            }
            public int minSize
            {
                get { return _minSize; }
            }

            public DateTime PriceDate
            {
                get { return _pricedate; }
            }
        }
        private void sort() // private void lvImport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnClickEventArgs e = new ColumnClickEventArgs(12);
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
