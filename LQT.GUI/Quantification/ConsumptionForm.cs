
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
using LQT.Core.UserExceptions;
using LQT.Core.Util;
using LQT.GUI.UserCtr;

namespace LQT.GUI.Quantification
{
    public partial class ConsumptionForm : Form
    {
        private ForecastInfo _forecastInfo;
        private Form _mdiparent;
        private string _currentTab = "GENERAL";
        private bool _contabSelected = false;
        //private bool _rpttabSelected = false;        
        //private ForecastSite _activeFSite;
        private bool _edited = false;

        public ConsumptionForm(ForecastInfo finfo, Form mdiparent)
        {
            this._forecastInfo = finfo;
            this._mdiparent = mdiparent;

            InitializeComponent();
            PopPeriod();
            BindConsumption();
           
        }

        private void PopPeriod()
        {
            string[] periods = Enum.GetNames(typeof(ForecastPeriodEnum));
            comPeriod.Items.Clear();
            comslowmovingperiod.Items.Clear();
            for (int i = 0; i <periods.Length; i++)
            {
                comPeriod.Items.Add(periods[i]);
                comslowmovingperiod.Items.Add(periods[i]);
            }
        }

        private void BindConsumption()
        {
            if (_forecastInfo.Id > 0)
            {
                string startdate="";
                this.txtForecastNo.Text = _forecastInfo.ForecastNo;
               
                this.dtpForecastDate.Value = _forecastInfo.ForecastDate.Value;
                this.comPeriod.SelectedItem = _forecastInfo.Period;
                this.comslowmovingperiod.SelectedItem = _forecastInfo.SlowMovingPeriod;
                if (_forecastInfo.ScopeOfTheForecast != "GLOBAL" && _forecastInfo.ScopeOfTheForecast != "NATIONAL")
                {
                    this.txtScope.Visible = true;
                    // this.cboscope.Items.Add(_forecastInfo.ScopeOfTheForecast);
                    this.cboscope.Text = "CUSTOM";
                }
                else
                {
                    this.cboscope.Text = _forecastInfo.ScopeOfTheForecast;
                }
                
                 this.txtScope.Text = _forecastInfo.ScopeOfTheForecast;
                 if (_forecastInfo.Period == ForecastPeriodEnum.Bimonthly.ToString())
                 {
                     dtpstart.DisableMonthCom = false;
                     dtpstart.PopQuarter = false;
                     dtpstart.PopMonthOrQuarterValue();
                     startdate = _forecastInfo.StartDate.Month.ToString() + "-" + _forecastInfo.StartDate.Year.ToString();
                 }
                if (_forecastInfo.Period == ForecastPeriodEnum.Monthly.ToString())
                {
                    dtpstart.DisableMonthCom = false;
                    dtpstart.PopQuarter = false;
                    dtpstart.PopMonthOrQuarterValue();
                    startdate =_forecastInfo.StartDate.Month.ToString()+ "-" + _forecastInfo.StartDate.Year.ToString();
                }
                else if (_forecastInfo.Period == ForecastPeriodEnum.Quarterly.ToString())
                {
                    dtpstart.DisableMonthCom = false;
                    dtpstart.PopQuarter = true;
                    dtpstart.PopMonthOrQuarterValue();
                    int month = _forecastInfo.StartDate.Month;
                    int quarter = 0;

                    if (month == 1)
                        quarter = 1;
                    else if (month == 4)
                        quarter = 2;
                    else if (month == 7)
                        quarter = 3;
                    else
                        quarter = 4;

                    startdate = quarter + "-" + _forecastInfo.StartDate.Year.ToString();
                }
                else if (_forecastInfo.Period == ForecastPeriodEnum.Yearly.ToString())
                {
                    dtpstart.DisableMonthCom = true;
                    startdate = _forecastInfo.StartDate.Year.ToString();
                }

                //if (_forecastInfo.)
                //{
                //    dtpstart.Enabled = false;
                //}
                
                this.dtpstart.SetValue(startdate);
                this.txtExtension.Text = _forecastInfo.Extension.ToString();
                //this.comDatausage.SelectedItem = _forecastInfo.DataUsage;
                this.txtDatausage.Text = LqtUtil.GetDatausageDescription(_forecastInfo.DataUsage);

                this.dtplastmodifieddate.Value = _forecastInfo.LastUpdated;
                //this.comDatausage.Enabled = false;
                this.comPeriod.Enabled = false;
                switch(_forecastInfo.DatausageEnum)
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
                grbDatausage.Enabled = false;
            }
            else
            {
                tabControl1.TabPages.Remove(tabConsumption);
                SetDatausagDescription(DataUsageEnum.DATA_USAGE1.ToString());
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            _currentTab = e.TabPage.Tag.ToString();

            switch(_currentTab)
            {
                case "GENERAL":
                    butSave.Enabled = true;
                    butSave.Text = "Save General Info";
                    break;
                case "CONSUMPTION":
                    butSave.Enabled = true;
                    butSave.Text = "Save Consumption";
                    
                    if (!_contabSelected)
                    {
                        DataUsageEnum duenum = (DataUsageEnum)Enum.Parse(typeof(DataUsageEnum), _forecastInfo.DataUsage);
                        switch (duenum)
                        {
                            case DataUsageEnum.DATA_USAGE1:
                                CDataUsage ctr = new CDataUsage(_forecastInfo);
                              //  ctr.OnDataUsageEdit += new EventHandler(ctr_OnDataUsageEdit);
                                ctr.ForecastInfoDataChanged += new EventHandler<EventArgs>(ctr_ForecastInfoDataChanged);
                                ctr.Dock = DockStyle.Fill;
                                tabConsumption.Controls.Add(ctr);                               
                                break;
                            case DataUsageEnum.DATA_USAGE2:
                                CReported ctr1 = new CReported(_forecastInfo);
                                ctr1.ForecastInfoDataChanged += new EventHandler<EventArgs>(ctr_ForecastInfoDataChanged);
                                ctr1.Dock = DockStyle.Fill;
                                tabConsumption.Controls.Add(ctr1);
                                break;
                            case DataUsageEnum.DATA_USAGE3:
                                CCategory ctr2 = new CCategory(_forecastInfo);
                                ctr2.ForecastInfoDataChanged += new EventHandler<EventArgs>(ctr_ForecastInfoDataChanged);
                                ctr2.Dock = DockStyle.Fill;
                                tabConsumption.Controls.Add(ctr2);
                                break;
                        }
                        _contabSelected = true;
                    }

                    break;
                case "REPORT":
                        butSave.Enabled = false;
                    break;
            }
        }

        void ctr_ForecastInfoDataChanged(object sender, EventArgs e)
        {
            this._edited = true;
        }

        void ctr_OnDataUsageEdit(object sender, EventArgs e)
        {
            this._edited = true;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            switch (_currentTab)
            {
                case "GENERAL":
                    SaveGeneralInfo();
                    break;
                case "CONSUMPTION":
                    SaveConsumption("Consumption Data usage was saved successfully.");
                    break;
            }
            _edited = false;
        }

        private void SaveGeneralInfo()
        {
            DateTime startdate = new DateTime();
            if (comPeriod.SelectedItem != null)//b
            {
                if (this.txtForecastNo.Text == string.Empty)//b
                {
                    MessageBox.Show("Forecast Id can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (_forecastInfo.Id <= 0||(_forecastInfo.Id > 0&&_forecastInfo.ForecastNo != txtForecastNo.Text))
                        
                    {
                        IList<ForecastInfo> _forcastinfo = DataRepository.GetAllForecastInfo();//b
                        for (int i = 0; i < _forcastinfo.Count; i++)//b
                        //foreach (ForecastInfo info in _forecastInfo)
                        {
                            if (_forcastinfo[i].ForecastNo == txtForecastNo.Text)
                            {
                                MessageBox.Show("Duplicate Forecast Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    


                    _forecastInfo.ForecastNo = this.txtForecastNo.Text;
                }
                

                if (this.txtScope.Text == string.Empty)//b
                {
                    MessageBox.Show("Scope of the Forcast can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    _forecastInfo.ScopeOfTheForecast = this.txtScope.Text;
                if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Bimonthly.ToString())
                {
                    if (dtpstart.GetMonth == 0)
                    {
                        MessageBox.Show("Month name can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (dtpstart.GetYear ==-1)//b
                        {
                            MessageBox.Show("Year can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            startdate = new DateTime(dtpstart.GetYear, dtpstart.GetMonth, 1);
                            _forecastInfo.MonthInPeriod = 2;
                        }
                    }
                }
                else if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Monthly.ToString())
                {
                    if (dtpstart.GetMonth == 0)
                    {
                        MessageBox.Show("Month name can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (dtpstart.GetYear == -1)//b
                        {
                            MessageBox.Show("Year can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        startdate = new DateTime(dtpstart.GetYear, dtpstart.GetMonth, 1);
                        _forecastInfo.MonthInPeriod = 1;
                    }
                }
                else if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Quarterly.ToString())
                {
                    if (dtpstart.GetQuarter == 0)
                    {
                        MessageBox.Show("Quarter name can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (dtpstart.GetYear == -1)//b
                        {
                            MessageBox.Show("Year can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        startdate = new DateTime(dtpstart.GetYear, dtpstart.GetQuarter, 1);
                        _forecastInfo.MonthInPeriod = 3;
                    }
                }
                else if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Yearly.ToString())
                {
                    if (dtpstart.GetYear == 0)
                    {
                        MessageBox.Show("Year can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (dtpstart.GetYear == -1)//b
                        {
                            MessageBox.Show("Year can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        startdate = new DateTime(dtpstart.GetYear, 1, 1);
                        _forecastInfo.MonthInPeriod = 12;
                    }
                }
                

                _forecastInfo.ForecastDate = this.dtpForecastDate.Value;
                _forecastInfo.StartDate = startdate;// this.dtpStartdate.Value;
                if (this.txtExtension.Text == string.Empty)//b
                {
                    MessageBox.Show("Forecasting Period can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                _forecastInfo.Extension = txtExtension.Text != "" ? int.Parse(this.txtExtension.Text) : 3;
                //_forecastInfo.Period = comPeriod.SelectedItem.ToString();

         

            bool addtab = false;
            if (_forecastInfo.Id <= 0)
            {
                _forecastInfo.Status = ForecastStatusEnum.OPEN.ToString();

                if (rdbUsage1.Checked)
                    _forecastInfo.DataUsage = DataUsageEnum.DATA_USAGE1.ToString();
                else if(rdbUsage2.Checked)
                    _forecastInfo.DataUsage = DataUsageEnum.DATA_USAGE2.ToString();
                else
                    _forecastInfo.DataUsage = DataUsageEnum.DATA_USAGE3.ToString();
                if (comPeriod.SelectedItem == null)
                {
                    MessageBox.Show("Forecasting Period can not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    _forecastInfo.Period = comPeriod.SelectedItem.ToString();
                }
                if (comslowmovingperiod.SelectedItem == null)
                    _forecastInfo.SlowMovingPeriod = _forecastInfo.Period;
                else
                    _forecastInfo.SlowMovingPeriod = comslowmovingperiod.SelectedItem.ToString();
                //comDatausage.Enabled = false;
                grbDatausage.Enabled = false;
                comPeriod.Enabled = false;
                addtab = true;
            }
             
            DataRepository.SaveOrUpdateForecastInfo(_forecastInfo);
            SaveConsumption("Forecast Information was saved successfully.");

            if (addtab)
            {
                tabControl1.TabPages.Add(tabConsumption);
                tabControl1.SelectedTab = tabConsumption;
            }  
         }
            if (comPeriod.SelectedItem == null)
            {
                MessageBox.Show("Reporting Period can not be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveConsumption(string msg)
        {
            try
            {
                DataRepository.SaveOrUpdateForecastInfo(_forecastInfo);
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg, true);
                MessageBox.Show("Consumption Forecast Information saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            { }
        }


        private void ConsumptionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            NHibernateHelper.CloseSession();
        }
              
        private void ConsumptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_edited)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show("Do you want to save changes?", "Quantification Process", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                    SaveConsumption("Forecast Information was saved successfully.");
                else if (dr == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void txtExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void SetDatausagDescription(string usage)
        {
            this.txtDatausage.Text = LqtUtil.GetDatausageDescription(usage);
        }
        private void rdbUsage1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUsage1.Checked)
                SetDatausagDescription(DataUsageEnum.DATA_USAGE1.ToString());
        }

        private void rdbUsage2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUsage2.Checked)
                SetDatausagDescription(DataUsageEnum.DATA_USAGE2.ToString());
        }

        private void rdbUsage3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUsage3.Checked)
                SetDatausagDescription(DataUsageEnum.DATA_USAGE3.ToString());
        }

        private void comPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Bimonthly.ToString())
            {
                label5.Text = "Forecast in Bimonthly:";
                dtpstart.DisableMonthCom = false;
                dtpstart.PopQuarter = false;
                dtpstart.PopMonthOrQuarterValue();
                
            }
            else if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Monthly.ToString())
            {
                label5.Text = "Forecast in Months:";
                dtpstart.DisableMonthCom = false;
                dtpstart.PopQuarter = false;
                dtpstart.PopMonthOrQuarterValue();
            }
            else if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Quarterly.ToString())
            {
                label5.Text = "Forecast in Quarters:";
                dtpstart.DisableMonthCom = false;
                dtpstart.PopQuarter = true;
                dtpstart.PopMonthOrQuarterValue();
            }
            else if (comPeriod.SelectedItem.ToString() == ForecastPeriodEnum.Yearly.ToString())
            {
                label5.Text = "Forecast in Years:";
                dtpstart.DisableMonthCom = true;
                dtpstart.PopMonthOrQuarterValue();
            }

            dtpstart.SetDefaultDate();
            
           
        }

        private void txtExtension_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void cboscope_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboscope.Text == "GLOBAL" || this.cboscope.Text == "NATIONAL")
            {
                this.txtScope.Visible = false;
                this.txtScope.Text = this.cboscope.Text;
            }
            else
            {
                if (_forecastInfo != null)
                    this.txtScope.Text = _forecastInfo.ScopeOfTheForecast;
                else
                    this.txtScope.Text = this.cboscope.Text;


                this.txtScope.Visible = true;
            }
           
        }

        
    }

    
}
