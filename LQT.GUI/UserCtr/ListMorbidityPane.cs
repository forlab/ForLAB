
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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Quantification;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListMorbidityPane : BaseUserControl
    {
        private int _selectedForcastId = 0;
        
        public ListMorbidityPane()
        {
            InitializeComponent();
            BindForecasts();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Morbidity Forecasting Methodology.";
            }
        }

        public override void ReloadUserCtrContents()
        {
            BindForecasts();
        }

        private void BindForecasts()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            IList<MorbidityForecast> result = DataRepository.GetAllMorbidityForecast();
            foreach (MorbidityForecast  r in result)
            {
                ListViewItem li = new ListViewItem(r.Title) { Tag = r.Id };
                li.SubItems.Add(r.Title);
                li.SubItems.Add(r.DateOfQuantification.ToShortDateString());
                li.SubItems.Add(r.SatartDate.ToShortDateString());
                li.SubItems.Add(r.StartBudgetPeriodEnum.ToString());
                li.SubItems.Add(r.EndBudgetPeriodEnum.ToString());
                li.SubItems.Add(r.DateModified.ToShortDateString());

                if (r.Id == _selectedForcastId)
                {
                    li.Selected = true;
                }

                listView1.Items.Add(li);
            }

            listView1.EndUpdate();

        }
               
        private MorbidityForecast GetSelectedForecast()
        {
            return DataRepository.GetMorbidityForecastById(_selectedForcastId);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }


        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MorbidityForecast finfo = new MorbidityForecast();
            MorbidityForm frm = new MorbidityForm(finfo, MdiParentForm);
            frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;

                if (id != _selectedForcastId)
                {
                    _selectedForcastId = id;
                }
            }
            SelectedItemChanged(listView1);
        }


        public override void EditSelectedItem()
        {
                MorbidityForm frm = new MorbidityForm(GetSelectedForecast(), MdiParentForm);
                frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            if (MessageBox.Show("Are you sure you want to delete this Forecast?", "Delete Forecasting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteMorbidityForecast(GetSelectedForecast());
                    MdiParentForm.ShowStatusBarInfo("The Forecast was deleted successfully.");
                    _selectedForcastId = 0;
                    BindForecasts();
                    return true;
                }
                catch (Exception ex)
                {
                    new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                }
            }

            return false;
        }

    }
}
