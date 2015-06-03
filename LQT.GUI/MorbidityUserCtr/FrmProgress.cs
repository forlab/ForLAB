
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.GUI.Quantification;
using LQT.GUI.MorbidityCalculation;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class FrmProgress : Form
    {
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private InventoryAssumption _invAssumption;
       // private MorbidityForm _morbidityForm;
        private MorbidityCalculater _mCalculaterEngine;
        
        delegate void SetProgressBarCallBack(int value);
        SetProgressBarCallBack _setProgressValue;
        delegate void SetTextCallBack(int value);
        SetTextCallBack _setProgressText;

        public FrmProgress(MorbidityForecast forecast, InventoryAssumption invAssumption)
        {
            //this._morbidityForm = morbidityForm;
            this._forecast = forecast;
            this._invAssumption = invAssumption;

            InitializeComponent();

            _setProgressText = new SetTextCallBack(SetProgressBarText);
            _setProgressValue = new SetProgressBarCallBack(SetProgressBarValue);
        }

        private void DoCalculation()
        {
            SetProgressBarText(1);

            _mCalculaterEngine.CalculateTestConducted();

            SetProgressBarText(2);
            _mCalculaterEngine.ForecastCalculatedTestContacted();

            SetProgressBarText(3);
            MorbidityForecastUtil.DeleteMorbidityForecast(_forecast.Id);
            MorbidityForecastUtil.SaveMorbidityForecastOutput(_mCalculaterEngine.GetListOfArtSiteCalculated);

            _forecast.Status = ForecastStatusEnum.CLOSED.ToString();
            DataRepository.SaveOrUpdateMorbidityForecast(_forecast);
            SummerizeSupplyForecast();
        }

        private void InitalizeCalculaterEngine()
        {
            _artSites = DataRepository.GetAllARTSite(_forecast.Id);

            _mCalculaterEngine = new MorbidityCalculater(_forecast, _artSites, _invAssumption);
            _mCalculaterEngine.UpdateCalculationEvent += new MorbidityCalculater.PerformMorbidityCalculationOnSite(CalculaterEngine_UpdateCalculationEvent);

            _mCalculaterEngine.TargetSelected = _forecast.PatientTreatmentTargetEnum == Core.Util.OptPatientTreatmentTargetEnum.OnTreatment ? 1 : 2;
            _mCalculaterEngine.RapidTestAlgorithm = new RapidTestAlgorithm(_forecast.TypeofAlgorithmEnum);
            _mCalculaterEngine.BudgetPeridoInfo = InitPeriodInfo();

            MorbidityForecastUtil.OnSaveCalculatedMorbidityEvent += new MorbidityForecastUtil.SaveCalculatedMorbidityOutPutOnSite(MorbidityForecastUtil_OnSaveCalculatedMorbidityEvent);
        }

        private BudgetPeriodInfo InitPeriodInfo()
        {
            BudgetPeriodInfo peridoInfo = new BudgetPeriodInfo();
            peridoInfo.FirstMonth = 1;
            if (_forecast.StartBudgetPeriod > _forecast.EndBudgetPeriod)
            {
                peridoInfo.LastMonth = ((12 - _forecast.StartBudgetPeriod) + 1) + _forecast.EndBudgetPeriod;
                peridoInfo.NumberofMonthsinBudgetPeriod = (_forecast.EndBudgetPeriod + 12) - _forecast.StartBudgetPeriod + 1;
            }
            else
            {
                peridoInfo.LastMonth = (_forecast.EndBudgetPeriod - _forecast.StartBudgetPeriod) + 1;
                peridoInfo.NumberofMonthsinBudgetPeriod = (_forecast.EndBudgetPeriod - _forecast.StartBudgetPeriod) + 1;
            }

            peridoInfo.BufferStoks = _invAssumption.SecurityStock;
            peridoInfo.BeginsOnmonth = peridoInfo.LastMonth + 1;
            peridoInfo.EndOnMonth = peridoInfo.LastMonth + peridoInfo.BufferStoks;

            if (peridoInfo.EndOnMonth > 13)
                peridoInfo.NumberofBufferMonthsBeyondForecast = peridoInfo.EndOnMonth - 13;
            else
                peridoInfo.NumberofBufferMonthsBeyondForecast = 0;

            peridoInfo.WeeksinBudgetPeriod = Convert.ToInt32(Math.Ceiling((peridoInfo.NumberofMonthsinBudgetPeriod * 30d) / 7d));
            peridoInfo.QuartersinBudgetPeriod = Convert.ToInt32(Math.Ceiling(peridoInfo.NumberofMonthsinBudgetPeriod / 3d));

            return peridoInfo;
        }

        public void SummerizeSupplyForecast()
        {
            IList<MorbiditySupplyProcurement> MSupplyForecastSummery = DataRepository.GetMorbiditySupplyForecastSummery(_forecast.Id);
            DataRepository.MorbiditySupplyProcurementBatchSave(MSupplyForecastSummery);
        }

        private void StartCalculation()
        {
            this.Cursor = Cursors.WaitCursor;

            InitalizeCalculaterEngine();

            _mCalculaterEngine.InitForCalculation();

            progressBar1.Maximum = _artSites.Count;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;

            lqtProgressBar1.Value = 0;
            lqtProgressBar1.Step = 35;

            bwCalculation.RunWorkerAsync();
        }

        private void CalculaterEngine_UpdateCalculationEvent(int count, PerformMorbidityCalculationArgs args)
        {
            if (count == 1)
                SetProgressBarValue(0);
            try
            {
                if (bwCalculation.WorkerReportsProgress)
                    bwCalculation.ReportProgress(count, args);
            }
            catch
            {
            }
        }


        private void MorbidityForecastUtil_OnSaveCalculatedMorbidityEvent(int count, PerformMorbidityCalculationArgs args)
        {
            if (count == 1)
                SetProgressBarValue(0);
            try
            {
                if (bwCalculation.WorkerReportsProgress)
                    bwCalculation.ReportProgress(count, args);
            }
            catch{}

        }


        private void SetProgressBarValue(int value)
        {
            if (this.progressBar1.InvokeRequired)
            {

                this.Invoke(_setProgressValue, new object[] { value });
            }
            else
                this.progressBar1.Value = value;
        }

        private void SetProgressBarText(int value)
        {
            if (this.lqtProgressBar1.InvokeRequired)
                this.Invoke(_setProgressText, new object[] { value });
            else
            {
                this.lqtProgressBar1.Text = String.Format("{0} / 3", value);
                lqtProgressBar1.PerformStep();
            }
        }

        private void bwCalculation_DoWork(object sender, DoWorkEventArgs e)
        {
            DoCalculation();
        }

        private void bwCalculation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PerformMorbidityCalculationArgs args = (PerformMorbidityCalculationArgs)e.UserState;
            if (args.ArgumentType == 1)
                lblProgress.Text = String.Format("Calculate test conducted for site -> {0}", args.SiteName);
            else if (args.ArgumentType == 2)
                lblProgress.Text = String.Format("Forecast reagents for site -> {0}", args.SiteName);
            else if (args.ArgumentType == 3)
                lblProgress.Text = String.Format("Save Forecasted data for site -> {0}", args.SiteName);
            progressBar1.PerformStep();
        }

        private void bwCalculation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Text = "All tasks done.";            
            this.Cursor = Cursors.Default;
            MessageBox.Show("Forecast completed.", "Morbidity Quantification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public void InitializeTimer()
        {
            timer1.Enabled = true;
            lblProgress.Text = "Initializing...";            
        }

        private void Timer1_Tick(object Sender, EventArgs e)
        {
            timer1.Enabled = false;
            StartCalculation();
        }

       
    }
}
