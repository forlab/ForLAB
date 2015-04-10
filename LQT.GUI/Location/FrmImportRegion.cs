
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
using LQT.Core.UserExceptions;
using System.Collections;

namespace LQT.GUI.Location
{
    public partial class FrmImportRegion : Form
    {
        private IList<RegionReportedData> _rdata;

        public FrmImportRegion()
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
                DataSet ds = LqtUtil.ReadExcelFile(txtFilename.Text, 2);

                _rdata = GetDataRow(ds);
                bool haserror = false;

                lvImport.BeginUpdate();
                lvImport.Items.Clear();
                string errorString;

                foreach (RegionReportedData rd in _rdata)
                {
                    ListViewItem li = new ListViewItem(rd.RowNo.ToString());
                    li.SubItems.Add(rd.RegionName);
                    li.SubItems.Add(rd.ShortName);
                    string str = rd.IsExist?"Yes":"No";
                    errorString = "";
                    foreach (ListViewItem Item in lvImport.Items)
                    {
                        if (Item.SubItems[1].Text.Trim().ToLower() == rd.RegionName.Trim().ToLower())
                        {
                            rd.IsExist = true;
                            str = "Duplicated";
                        }

                    }
                    li.SubItems.Add(str);

                    if (rd.HasError)
                    {
                        if (rd.RegionName == "")
                         errorString = errorString + " Region Name Required";
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
               // if (!haserror)
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
            int error=0;
            try
            {
                foreach (RegionReportedData rd in _rdata)
                {
                    if (!rd.IsExist)
                    {
                        if (!rd.HasError)
                        {
                            ForlabRegion region = new ForlabRegion();
                            region.RegionName = rd.RegionName;
                            region.ShortName = rd.ShortName;
                            count++;
                            DataRepository.SaveOrUpdateRegion(region);
                        }
                        else
                        {
                            error++;
                        }


                    }
                    else
                    {
                        error++;
                    }
                   
                }

                MessageBox.Show(count + " Regions/Districts/Provinces are imported and saved successfully." + Environment.NewLine + error + " Regions/Districts/Provinces Failed.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                
              
            }
            catch
            {
                MessageBox.Show("Error: Unable to import and save Region/District/Province data.", "Importing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataRepository.CloseSession();
            }
        }

        private IList<RegionReportedData> GetDataRow(DataSet ds)
        {
            string regionName;
            string shortName;
            int rowno = 0;

            IList<RegionReportedData> rdlist = new List<RegionReportedData>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rowno++;

                regionName = Convert.ToString(dr[0]).Trim();   //region name
                shortName  = Convert.ToString(dr[1]);   //short name
                RegionReportedData rd = new RegionReportedData(rowno, regionName, shortName);
                if (string.IsNullOrEmpty(regionName))
                    rd.HasError = true;
                else
                {
                    rd.IsExist = DataRepository.GetRegionByName(regionName) != null;
                }

                rdlist.Add(rd);
            }

            return rdlist;
        }
        
        private class RegionReportedData
        {
            private string _regionName;
            private ForlabRegion _region;
            private string _shortName;
            private int _rowno;
            private bool _hasError;
            private bool _isexist;

            private RegionReportedData()
            {
            }

            public RegionReportedData(int rowno, string rname, string sname)
            {
                this._rowno = rowno;
                this._regionName = rname;
                this._shortName = sname;
                this._hasError = false;
                this._isexist = false;
            }

            public string RegionName
            {
                get { return _regionName; }
            }

            public string ShortName
            {
                get { return _shortName; }
            }
            public int RowNo
            {
                get { return _rowno; }
            }

            public bool IsExist
            {
                get { return _isexist; }
                set { _isexist = value; }
            }
            public bool HasError
            {
                get { return _hasError; }
                set { _hasError = value; }
            }

        }
        private void sort() // private void lvImport_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnClickEventArgs e = new ColumnClickEventArgs(4);
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
