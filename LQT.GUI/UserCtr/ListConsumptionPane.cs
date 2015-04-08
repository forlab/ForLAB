
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
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Quantification;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListConsumptionPane : BaseUserControl
    {
        private int _selectedForcastId = 0;
        private MethodologyEnum _methoEnum;

        public ListConsumptionPane(MethodologyEnum metho)
        {
            this._methoEnum = metho;

            InitializeComponent();
            if (_methoEnum != MethodologyEnum.DEMOGRAPHIC)
            {
                PopPeriod();
                PopConsumptions();
            }
            else
            {
                lbtAddnew.Enabled = false;
            }                
                
        }

        public override string GetControlTitle
        {
            get
            {
                if (_methoEnum == MethodologyEnum.CONSUMPTION)
                    return "Consumption Forecast Methodology";
                else if (_methoEnum == MethodologyEnum.SERVICE_STATISTIC)
                    return "Service Statistics Forecast Methodology";
                else
                    return "Morbidity Forecast Methodology. Under construction";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopConsumptions();
        }

        private void PopPeriod()
        {
            string[] periods = Enum.GetNames(typeof(ForecastPeriodEnum));
            //comPeriod.Items.Clear();

            //for (int i = 0; i < periods.Length; i++)
            //{
            //    comPeriod.Items.Add(periods[i]);
            //}
        }
        private void PopConsumptions()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ForecastInfo  r in DataRepository.GetForecastInfoByMethodology(_methoEnum.ToString()))
            {
                ListViewItem li = new ListViewItem(r.Status) { Tag = r.Id };
                li.SubItems.Add(r.ForecastNo);
                li.SubItems.Add(r.ScopeOfTheForecast);
                li.SubItems.Add(r.ForecastDate.Value.ToShortDateString());
                li.SubItems.Add(r.StartDate.ToShortDateString());
                li.SubItems.Add(r.Period);
                li.SubItems.Add(r.Extension.ToString());
                li.SubItems.Add(r.Method);
                li.SubItems.Add(r.Westage.ToString());
                li.SubItems.Add(r.LastUpdated.ToShortDateString());
                if (r.Id == _selectedForcastId)
                {
                    li.Selected = true;
                }

                listView1.Items.Add(li);
            }

            listView1.EndUpdate();

            if (_selectedForcastId > 0)
            {
                BindConsumptionPane();
            }
            else if (listView1.Items.Count > 0)
            {
                _selectedForcastId = (int)listView1.Items[0].Tag;
                BindConsumptionPane();
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void BindConsumptionPane()
        {
            panel1.Visible = true;
            ForecastInfo finfo = GetSelectedConsumption();

            //this.txtForecastId.Text = finfo.ForecastNo;
            //this.txtScope.Text = finfo.ScopeOfTheForecast;
            //this.dtpForecastDate.Value = finfo.ForecastDate.Value;
           // this.dtpStartdate.Value = finfo.StartDate != null ? finfo.StartDate.Value : DateTime.Now;
            //this.txtExtension.Text = finfo.Extension.ToString();
            //this.comPeriod.SelectedItem = finfo.Period;
            this.txtDatausage.Text = LqtUtil.GetDatausageDescription(finfo.DataUsage);
            string startdate = "";
            if (finfo.Period == ForecastPeriodEnum.Bimonthly.ToString())
            {
                //dtpstart.DisableMonthCom = false;
                //dtpstart.PopQuarter = false;
                //dtpstart.PopMonthOrQuarterValue();
                startdate = finfo.StartDate.Month.ToString() + "-" + finfo.StartDate.Year.ToString();
            }
            else if (finfo.Period == ForecastPeriodEnum.Monthly.ToString())
            {
                //dtpstart.DisableMonthCom = false;
                //dtpstart.PopQuarter = false;
                //dtpstart.PopMonthOrQuarterValue();
                startdate = finfo.StartDate.Month.ToString() + "-" + finfo.StartDate.Year.ToString();
            }
            else if (finfo.Period == ForecastPeriodEnum.Quarterly.ToString())
            {
                //dtpstart.DisableMonthCom = false;
                //dtpstart.PopQuarter = true;
                //dtpstart.PopMonthOrQuarterValue();
                int month = finfo.StartDate.Month;
                int quarter = 0;

                if (month == 1)
                    quarter = 1;
                else if (month == 4)
                    quarter = 2;
                else if (month == 7)
                    quarter = 3;
                else
                    quarter = 4;

                startdate = quarter + "-" + finfo.StartDate.Year.ToString();
            }
            else if (finfo.Period == ForecastPeriodEnum.Yearly.ToString())
            {
                //dtpstart.DisableMonthCom = true;
                startdate = finfo.StartDate.Year.ToString();
            }

            //this.dtpstart.SetValue(startdate);

            switch (finfo.DatausageEnum)
            {
                case DataUsageEnum.DATA_USAGE1:
                    rdbUsage1.Checked = true;
                    break;
                case DataUsageEnum.DATA_USAGE2:
                    rdbUsage2.Checked = true;
                    break;
                case DataUsageEnum.DATA_USAGE3:
                    rdbUsage3.Checked = true;
                    break;
            }
        }

        private ForecastInfo GetSelectedConsumption()
        {
            return DataRepository.GetForecastInfoById(_selectedForcastId);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            //listView1.Columns[4].Width = listView1.Width - 445;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForecastInfo finfo = new ForecastInfo();
            finfo.Methodology = _methoEnum.ToString();

            if (_methoEnum == MethodologyEnum.CONSUMPTION)
            {
                ConsumptionForm frm = new ConsumptionForm(finfo, MdiParentForm);
                frm.ShowDialog();
            }
            else if (_methoEnum == MethodologyEnum.SERVICE_STATISTIC)
            {
                ServiceForm frm = new ServiceForm(finfo, MdiParentForm);
                frm.ShowDialog();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;

                if (id != _selectedForcastId)
                {
                    _selectedForcastId = id;
                    BindConsumptionPane();
                }
            }
            SelectedItemChanged(listView1);
        }


        public override void EditSelectedItem()
        {
            if (_methoEnum == MethodologyEnum.CONSUMPTION)
            {
                ConsumptionForm frm = new ConsumptionForm(GetSelectedConsumption(), MdiParentForm);
                frm.ShowDialog();
            }
            else if (_methoEnum == MethodologyEnum.SERVICE_STATISTIC)
            {
                ServiceForm frm = new ServiceForm(GetSelectedConsumption(), MdiParentForm);
                frm.ShowDialog();
            }
        }

        public override bool DeleteSelectedItem()
        {
            if (MessageBox.Show("Are you sure you want to delete this Forecasting Methodology?", "Delete Forecasting Methodology", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (GetSelectedConsumption().Status != ForecastStatusEnum.CLOSED.ToString())//b
                    {
                        DataRepository.DeleteForecastInfo(GetSelectedConsumption());
                        MdiParentForm.ShowStatusBarInfo("Forecasting Methodology was deleted successfully.");
                        _selectedForcastId = 0;
                        PopConsumptions();
                        return true;
                    }
                    else//b
                    {
                        MessageBox.Show("You Can't Delete This Forecast.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                }
            }

            return false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
