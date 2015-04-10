
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
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.GUI.MorbidityUserCtr;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Quantification
{
    public partial class MorbidityForm : Form
    {
        private MorbidityForecast _mforecast;
        private MorbidityCtrEnum _priviousCtr;
        private MorbidityCtrEnum _nextCtr;
        private BaseMorbidityControl _currentCtr;
        private InventoryAssumption _invAssumption;
        private string TempFile = Path.GetTempFileName();
        private Form _mdiparent;
        private bool _edited = false;
        private IList<ARTSite> _artSites;

        public MorbidityForm(MorbidityForecast mforecast, Form mdiparent)
        {
            this._mforecast = mforecast;
            this._mdiparent = mdiparent;
            this._artSites = DataRepository.GetAllARTSite(mforecast.Id);

            if (mforecast.Id > 0)
            {
                this._invAssumption = DataRepository.GetInventoryAssumptionByForecastId(mforecast.Id);
            }

            if (_invAssumption == null)
            {
                this._invAssumption = new InventoryAssumption();
                this._invAssumption.MorbidityForecast = _mforecast;
            }

            InitializeComponent();
            PopPeriod();
            BindForecast();
            
        }

        public void ReInitMorbidityFrm()
        {
            this._mforecast = DataRepository.GetMorbidityForecastById(_mforecast.Id);
            this._artSites = DataRepository.GetAllARTSite(_mforecast.Id);
            this._invAssumption = DataRepository.GetInventoryAssumptionByForecastId(_mforecast.Id);

            if (_invAssumption == null)
            {
                this._invAssumption = new InventoryAssumption();
                this._invAssumption.MorbidityForecast = _mforecast;
            }
        }

        public void ReInitMorbidityFrm(ref MorbidityForecast forecast,ref InventoryAssumption assumption, ref IList<ARTSite> artSites)
        {
            ReInitMorbidityFrm();
            forecast = _mforecast;
            assumption = _invAssumption;
            artSites = _artSites;
        }
        
        private void PopPeriod()
        {
            comBudgetend.Items.AddRange(Enum.GetNames(typeof(MonthNameEnum)));
            comBudgetsart.Items.AddRange(Enum.GetNames(typeof(MonthNameEnum)));
        }
        
        private void BindForecast()
        {
            if (_mforecast.Id > 0)
            {
                txtTitle.Text = _mforecast.Title;
                txtDescription.Text = _mforecast.Descritpion;
                dtpDateofquan.Value = _mforecast.DateOfQuantification;

                dtpForecastsdate.Value = _mforecast.SatartDate;
                comBudgetsart.Text = _mforecast.StartBudgetPeriodEnum.ToString();
                comBudgetend.Text = _mforecast.EndBudgetPeriodEnum.ToString();
                
                if (_mforecast.TypeofAlgorithmEnum == AlgorithmType.Serial)
                    rdbSerial.Checked = true;
                else
                    rdbParallel.Checked = true;
                InitNavigation();
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            bool initnav = _mforecast.Id <= 0;
            try//b
            {
            if (txtTitle.Text.Trim() == string.Empty)
            {
                throw new LQTUserException("Title can not be empty.");
            }
            if (comBudgetsart.Text.Trim() == string.Empty)
            {
                throw new LQTUserException("Budget Start Date can not be empty.");
            }
            if (comBudgetend.Text.Trim() == string.Empty)
            {
                throw new LQTUserException("Budget End Date can not be empty.");
            }
            
                _mforecast.Title = txtTitle.Text;
                _mforecast.Descritpion = txtDescription.Text;
                _mforecast.DateOfQuantification = dtpDateofquan.Value;

                _mforecast.SatartDate = dtpForecastsdate.Value;

                if (comBudgetsart.Text.Trim() != string.Empty)
            {
                _mforecast.StartBudgetPeriod = (int)Enum.Parse(typeof(MonthNameEnum), comBudgetsart.Text);
            }
                if (comBudgetend.Text.Trim() != string.Empty)
            {
                _mforecast.EndBudgetPeriod = (int)Enum.Parse(typeof(MonthNameEnum), comBudgetend.Text);
            }
                _mforecast.DateModified = DateTime.Now;
                _mforecast.TypeofAlgorithm = rdbSerial.Checked ? AlgorithmType.Serial.ToString() : AlgorithmType.Parallel.ToString();

                DataRepository.SaveOrUpdateMorbidityForecast(_mforecast);
                SaveForecast("Forecast Information was saved successfully.");
            if (initnav)
                InitNavigation();

            }
            catch (Exception ex)//b
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }

            
        }


        private bool SaveForecast(string msg)
        {
            try
            {
                DataRepository.SaveOrUpdateMorbidityForecast(_mforecast);
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg, true);
                _edited = false;                
            }
            catch
            {
                MessageBox.Show("Error: Unable to save the forecast.", "Morbidity Quantification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void butResult_Click(object sender, EventArgs e)
        {

        }

        private void MorbidityForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            NHibernateHelper.CloseSession();
        }

        private void MorbidityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_edited)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show("Do you want to save changes?", "Quantification Process", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveForecast("Forecast Information was saved successfully."))
                        e.Cancel = true;
                }
                else if (dr == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        #region navigation.........

        private void InitNavigation()
        {
            if (_mforecast.StatusEnum == ForecastStatusEnum.CLOSED)
            {
                LoadDashBoard();
            }
            else
                this._currentCtr = new SiteSelection(_mforecast, _artSites);

            LoadCurrentCtr();
        }

        private void LoadCurrentCtr()
        {            
            panContainer.Controls.Clear();
            
            _priviousCtr = _currentCtr.PriviousCtr;
            _nextCtr = _currentCtr.NextCtr;
            lblCurrentCtr.Text = _currentCtr.Title;
            if (_currentCtr.EnableNextButton())
                butNext.Enabled = true;
            else
                butNext.Enabled = false;
            _currentCtr.NextButtonStatusChanged += new EventHandler<NextButtonStatusEventArgs>(_currentCtr_NextButtonStatusChanged);
            
            butBack.Enabled = _priviousCtr != MorbidityCtrEnum.Nothing;
            _currentCtr.MorbidityForm = this;
            _currentCtr.Dock = DockStyle.Fill;
            panContainer.Controls.Add(_currentCtr);
            ShowHelp(_currentCtr.Title, _currentCtr.Description);
        }

        void _currentCtr_NextButtonStatusChanged(object sender, NextButtonStatusEventArgs e)
        {
            butNext.Enabled = e.BoolValue;
            _nextCtr = _currentCtr.NextCtr;
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            if (_currentCtr.DoSomthingBeforeUnload())
            {
                _currentCtr = GetMorbidityControl(_priviousCtr);
                LoadCurrentCtr();
            }
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            if (_currentCtr.DoSomthingBeforeUnload())
            {
                _currentCtr = GetMorbidityControl(_nextCtr);
                LoadCurrentCtr();
            }

        }

        private BaseMorbidityControl GetMorbidityControl(MorbidityCtrEnum ctr)
        {
            BaseMorbidityControl mcontrol = null;
            switch (ctr)
            {
                case MorbidityCtrEnum.SiteSelection:
                    mcontrol = new SiteSelection(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.OptRecentData:
                    mcontrol = new OptRecentData(_mforecast);
                    break;
                case MorbidityCtrEnum.FromRecentData:
                    mcontrol = new FromRecentData(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.FromOldData:
                    mcontrol = new FromOldData(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.OptTreatmentTarget:
                    mcontrol = new OptTreatmentTarget(_mforecast);
                    break;
                case MorbidityCtrEnum.OptArtPatientTarget:
                    mcontrol = new OptArtPatientTarget(_mforecast);
                    break;
                case MorbidityCtrEnum.OpEverStartedPatientTarget:
                    mcontrol = new OpEverStartedPatientTarget(_mforecast);
                    break;
                case MorbidityCtrEnum.SiteTargetCalculator:
                    mcontrol = new SiteTargetCalculator(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.PatientNumbersSites:
                    mcontrol = new PatientNumbersSites(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.OptPreTreatmentPatientTargets:
                    mcontrol = new OptPreTreatmentPatientTargets(_mforecast);
                    break;
                case MorbidityCtrEnum.SiteTargetCalculatorPreART:
                    mcontrol = new SiteTargetCalculatorPreART(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.PreTxNumbersSites:
                    mcontrol = new PreTxNumbersSites(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.TestingInformation:
                    mcontrol = new TestingInformation(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.TestingEfficiency:
                    mcontrol = new TestingEfficiency(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.AdultPatientBehavior:
                    mcontrol = new AdultPatientBehavior(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.PediatricPatientBehavior:
                    mcontrol = new PediatricPatientBehavior(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.EverStartedRecentData:
                    mcontrol = new EverStartedRecentData(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.EverStartedOldData:
                    mcontrol = new EverStartedOldData(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.EverStartedNoData:
                    mcontrol = new EverStartedNoData(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.RapidTestSerial:
                    mcontrol = new RapidTestSerial(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.RapidTestParallel:
                    mcontrol = new RapidTestParallel(_mforecast, _artSites);
                    break;
                case MorbidityCtrEnum.InvAssumption:
                    mcontrol = new InvAssumption(_mforecast, _invAssumption);
                    break;
                case MorbidityCtrEnum.CheckupForm:
                    mcontrol = new CheckupForm(_mforecast,_invAssumption, _artSites, _mdiparent);
                    break;                     
                case MorbidityCtrEnum.CalculateForm:
                    mcontrol = new CalculateForm(_mforecast);
                    break;
                case MorbidityCtrEnum.Dashboard:
                    mcontrol = new DashboardForm(_mforecast);
                    break;
            }

            if (ctr == MorbidityCtrEnum.SiteSelection)
                butGohome.Enabled = false;
            else
                butGohome.Enabled = true;

            return mcontrol;
        }

        #endregion


        private void ShowHelp(string header, string detail)
        {
            // Read the about HTML from the assembly
            string html = (new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("LQT.GUI.Morbidity.htm"))).ReadToEnd();

            // Replace sections with appropriate data
            html = html.Replace("{header}", header);

            html = html.Replace("{detail}", detail);
            // Save the temp file so the web browser has a target to navigate to
            File.WriteAllText(TempFile, html);

            webBrowser1.Navigate(TempFile);
            webBrowser1.Refresh();
        }

     
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            File.Delete(TempFile);
        }

        private void lblColapse_Click(object sender, EventArgs e)
        {
            lblColapse.Visible = false;
            lblExpand.Visible = true;
            splitContainer2.Panel2Collapsed = true;
        }

        private void lblExpand_Click(object sender, EventArgs e)
        {
            lblColapse.Visible = true;
            lblExpand.Visible = false;
            splitContainer2.Panel2Collapsed = false;
        }

        public void LoadDashBoard()
        {
            if (_mforecast.StatusEnum == ForecastStatusEnum.CLOSED)
            {
                this._currentCtr = new DashboardForm(_mforecast);


                lblColapse.Visible = false;
                lblExpand.Visible = true;
                splitContainer2.Panel2Collapsed = true;
                LoadCurrentCtr();
            }
        }

        public void LoadForecastResult()
        {
            this._currentCtr = new CalculateForm(_mforecast);
            LoadCurrentCtr();
        }

        private void dtpForecastsdate_ValueChanged(object sender, EventArgs e)
        {
            MonthNameEnum month = (MonthNameEnum)Enum.ToObject(typeof(MonthNameEnum), dtpForecastsdate.Value.Month);
            comBudgetsart.Text = month.ToString();

            if (dtpForecastsdate.Value.Month - 1 == 0)
                month = (MonthNameEnum)Enum.ToObject(typeof(MonthNameEnum), 12);
            else
                month = (MonthNameEnum)Enum.ToObject(typeof(MonthNameEnum), dtpForecastsdate.Value.Month - 1);
            comBudgetend.Text = month.ToString();
        }

        private void butGohome_Click(object sender, EventArgs e)
        {
            if (_currentCtr.DoSomthingBeforeUnload())
            {
                this._currentCtr = new SiteSelection(_mforecast, _artSites);
                LoadCurrentCtr();
            }
        }


    }

}
