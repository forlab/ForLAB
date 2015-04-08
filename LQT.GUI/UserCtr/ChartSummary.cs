
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
using System.Text;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.Core.Util;

namespace LQT.GUI.UserCtr
{
    public partial class ChartSummary : LQT.GUI.UserCtr.BaseUserControl
    {
        private DataSet _DSforcast;
        private FTable _fTable;
        private DataTable tbl = new DataTable("forecast");

        public ChartSummary(DataSet ds,FTable ft)
        {
            _DSforcast = ds;
            _fTable = ft;
            InitializeComponent();
        }
        private void constructSummary()
        {
            //ForecastInfo finfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
            ForecastInfo finfo;
           
            DataRow row = null;
            //decimal totalAmount = 0;
            string titel = string.Empty;
            if (_fTable != null)
            {
                 finfo = DataRepository.GetForecastInfoById(_fTable.ForecastId);
                if (finfo.Methodology == MethodologyEnum.CONSUMPTION.ToString())
                    titel = _fTable.Product.ProductName;
                else
                    titel = _fTable.Test.TestName;
            }
            tbl.Columns.Add(titel, typeof(string));

            foreach (DataRow rowf in _DSforcast.Tables[0].Rows)
            {
                tbl.Columns.Add(rowf[0].ToString(), typeof(string));
            }
            tbl.Columns.Add("Total", typeof(string));
            row = tbl.NewRow();
            tbl.Rows.Add(row);

            row.BeginEdit();
            row[titel] =titel;
            decimal total = 0;
            foreach (DataRow rowf in _DSforcast.Tables[0].Rows)
            {
                row[rowf[0].ToString()] = rowf[1].ToString();
                total += decimal.Parse(rowf[1].ToString());
            }
            row["Total"] = total;
            row.EndEdit();
        }

        private void ChartSummary_Load(object sender, EventArgs e)
        {
            constructSummary();
            this.dataGridView1.DataSource = tbl;

        }
    }
}
