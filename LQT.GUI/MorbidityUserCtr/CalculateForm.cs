
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;
using LQT.GUI.Quantification;
using LQT.GUI.MorbidityCalculation;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class CalculateForm :  BaseMorbidityControl
    {
        private MorbidityForecast _forecast;
        //private IList<ARTSite> _artSites;
        //private InventoryAssumption _invAssumption;
        //private MorbidityForm _morbidityForm;
        //private MorbidityCalculater _mCalculaterEngine;
        
        //delegate void SetProgressBarCallBack(int value);
        //SetProgressBarCallBack _setProgressValue;
        //delegate void SetTextCallBack(int value);
        //SetTextCallBack _setProgressText;

        public CalculateForm(MorbidityForecast forecast)
        {
            this._forecast = forecast;
            //this._artSites = artsites;
            //this._invAssumption = invAssumption;
            
            InitializeComponent();

            if (_forecast.StatusEnum != ForecastStatusEnum.OPEN)
            {
                LoadPatientAssumptions();
                LoadCD4Assumptions();
                LoadHematologyAssumptions();
                LoadViralLoadAssumptions();
                LoadRapidTestAssumptions();
                LoadChemistryAssumptions();
                LoadOtherTestAssumptions();
                LoadTotalCost();
            }
            else
            {
                chartPatientAss.Hide();
                chartCd4Assumptions.Hide();
                chartHematology.Hide();
                chartViralload.Hide();
                chartRapidTest.Hide();
                chartTotalCost.Hide();
                chartChemistry.Hide();
                chartOthertest.Hide();
            }
        }

        public override string Title
        {
            get { return "Forecast Results"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.CheckupForm;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.Dashboard;
            }
        }

        public override bool EnableNextButton()
        {
            return true;
        }

        public override string Description
        {
            get
            {
                string desc = "View the number of patients, number of tests expected, and otherkey assumptions.";
                return desc;
            }
        }

        private void LoadPatientAssumptions()
        {
            PatientsNoofTest _p = DataRepository.GetPatientsNoofTestSummery(_forecast.Id);

            if (_p != null)
            {
                double[] yval = { Math.Round(_p.PITMonth1), Math.Round(_p.PITMonth2), Math.Round(_p.PITMonth3), Math.Round(_p.PITMonth4), Math.Round(_p.PITMonth5), Math.Round(_p.PITMonth6), Math.Round(_p.PITMonth7), Math.Round(_p.PITMonth8), Math.Round(_p.PITMonth9), Math.Round(_p.PITMonth10), Math.Round(_p.PITMonth11), Math.Round(_p.PITMonth12) };
                string[] xval = new string[12];
                for (int i = 0; i < 12; i++)
                {
                    xval[i] = "Month " + (i + 1);
                }
                chartPatientAss.Series["Series1"].Points.DataBindXY(xval, yval);

                double[] yval1 = { Math.Round(_p.PPARTMonth1), Math.Round(_p.PPARTMonth2), Math.Round(_p.PPARTMonth3), Math.Round(_p.PPARTMonth4), Math.Round(_p.PPARTMonth5), Math.Round(_p.PPARTMonth6), Math.Round(_p.PPARTMonth7), Math.Round(_p.PPARTMonth8), Math.Round(_p.PPARTMonth9), Math.Round(_p.PPARTMonth10), Math.Round(_p.PPARTMonth11), Math.Round(_p.PPARTMonth12) };
                string[] xval1 = new string[12];
                for (int i = 0; i < 12; i++)
                {
                    xval1[i] = "Month " + (i + 1);
                }
                chartPatientAss.Series["Series4"].Points.DataBindXY(xval1, yval1);
            }
            chartPatientAss.Update();
            chartPatientAss.Show();
        }

        private void LoadCD4Assumptions()
        {
            CD4TestNumber _cd = DataRepository.GetCD4TestNumberSummary(_forecast.Id);

            if (_cd != null)
            {
                double[] yval = { Math.Ceiling(_cd.ExistingPIT),Math.Ceiling(_cd.ExistingPIPreART),Math.Ceiling(_cd.CD4BaseLineTest),
                                Math.Ceiling(_cd.NewPatienttoTreatment),Math.Ceiling(_cd.NewPatientstoPreART),Math.Ceiling(_cd.SymptomDirectedTest),
                                Math.Ceiling(_cd.RepeatsdutoClinicalRequest),Math.Ceiling(_cd.Wastage),Math.Ceiling(_cd.ReagentstoRunControls),Math.Ceiling(_cd.BufferStockandControls) };
                string[] xval = { "Existing Patients in Treatment", "Existing Patients in pre-ART ", "CD4 Baseline Test",
                                    "New Patients to Treatment", "New Patients to pre-ART", "Symptom-Directed Tests", 
                                    "Repeats due to Clinician Request", "Wastage", "Reagents to Run Controls", "Buffer Stock for Routine Tests & Controls" };
                //{ "EPT", "EP Pre-ART", "Baseline", "NPT", "NP Pre-ART", "SDT", "RCR", "Wastage", "RRC", "BSRTC" };

                chartCd4Assumptions.Series["Series1"].Points.DataBindXY(xval, yval);
                chartCd4Assumptions.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                chartCd4Assumptions.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            }
            chartCd4Assumptions.Update();
            chartCd4Assumptions.Show();
        }

        private void LoadHematologyAssumptions()
        {
            HemaandViralNumberofTest _cd = DataRepository.GetHematologySummary(_forecast.Id);

            if (_cd != null)
            {
                double[] yval = { Math.Ceiling(_cd.TestBasedOnProtocols),Math.Ceiling(_cd.SymptomDirectedTests),Math.Ceiling(_cd.RepeatedDuetoClinicalReq),
                                Math.Ceiling(_cd.InvalidTestandWastage),Math.Ceiling(_cd.ReagentstoRunControls),Math.Ceiling(_cd.BufferStockandControls)};
                string[] xval = { "Tests based on protocols", "Symptom-Directed Tests", "Repeats due to Clinician Request", "Invalid Tests and Wastage", "Reagents to Run Controls", "Buffer Stock" };

                chartHematology.Series["Series1"].Points.DataBindXY(xval, yval);
            }
            chartHematology.Update();
            chartHematology.Show();
        }

        private void LoadViralLoadAssumptions()
        {
            HemaandViralNumberofTest _cd = DataRepository.GetViralLoadSummary(_forecast.Id);
            if (_cd != null)
            {
                double[] yval = { Math.Ceiling(_cd.TestBasedOnProtocols),Math.Ceiling(_cd.SymptomDirectedTests),Math.Ceiling(_cd.RepeatedDuetoClinicalReq),
                                Math.Ceiling(_cd.InvalidTestandWastage),Math.Ceiling(_cd.ReagentstoRunControls),Math.Ceiling(_cd.BufferStockandControls)};
                string[] xval = { "Tests based on protocols", "Symptom-Directed Tests", "Repeats due to Clinician Request", "Invalid Tests and Wastage", "Reagents to Run Controls", "Buffer Stock" };

                chartViralload.Series["Series1"].Points.DataBindXY(xval, yval);
            }
            chartViralload.Update();
            chartViralload.Show();
        }

        private void LoadRapidTestAssumptions()
        {
            HIVRapidNumberofTest _cd = DataRepository.GetHIVRapidNumberofTestSummary(_forecast.Id);

            if (_cd != null)
            {
                double[] yval = { Math.Ceiling(_cd.Screening), Math.Ceiling(_cd.Confirmatory), Math.Ceiling(_cd.TieBreaker) };
                string[] xval = { "Screening Tests", "Confirmatory Tests", "Tie-Breaker Tests" };


                chartRapidTest.Series["Series1"].Points.DataBindXY(xval, yval);
            }
            chartRapidTest.Update();
            chartRapidTest.Show();
        }

        private void LoadTotalCost()
        {
            IList result = DataRepository.GetSummaryOfTotalCost(_forecast.Id);
            double total = 0;
            if (result.Count > 0)
            {
                foreach (object[] o in result)
                {
                    total += Convert.ToDouble(o[1]);
                }
                double[] yval = new double[7];
                string[] xval = new string[7];
                object[] row;

                for (int i = 0; i < result.Count; i++)
                {
                    row = (object[])result[i];
                    yval[i] = Math.Round(Convert.ToDouble(row[1]), 2);
                    xval[i] = MorbidityTestEnumToString(Convert.ToInt32(row[0]));
                }
                chartTotalCost.Series["Series2"].Points.DataBindXY(xval, yval);                
            }
            chartTotalCost.Update();
            chartTotalCost.Show();
        }

        private void LoadChemistryAssumptions()
        {
            IList result = DataRepository.GetChemistryTestSummarys(_forecast.Id);
            double[] yval = new double[12];
            string[] xval = new string[12];
            object[] row;

            if (result.Count > 0)
            {
                for (int col = 0; col <= 5; col++)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        row = (object[])result[i];
                        xval[i] = row[0].ToString();
                        yval[i] = Convert.ToDouble(row[col + 1]); //Reagents to Run Controls
                    }
                    chartChemistry.Series[col].Points.DataBindXY(xval, yval);
                }
            }

            chartChemistry.Update();
            chartChemistry.Show();
        }

        private void LoadOtherTestAssumptions()
        {
            IList result = DataRepository.GetOtherTestSummarys(_forecast.Id);
            double[] yval = new double[8];
            string[] xval = new string[8];
            object[] row;
            if (result.Count > 0)
            {
                for (int col = 0; col <= 5; col++)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        row = (object[])result[i];
                        xval[i] = row[0].ToString().Replace('_', ' ');
                        yval[i] = Convert.ToDouble(row[col + 1]);
                    }
                    chartOthertest.Series[col].Points.DataBindXY(xval, yval);
                }
            }
            chartOthertest.Update();
            chartOthertest.Show();
        }

        private string MorbidityTestEnumToString(int mtype)
        {
            ClassOfMorbidityTestEnum mt= (ClassOfMorbidityTestEnum)Enum.ToObject(typeof(ClassOfMorbidityTestEnum), mtype);
            string result = "";
            switch (mt)
            {
                case ClassOfMorbidityTestEnum.CD4:
                    result = "CD4";
                    break;
                case ClassOfMorbidityTestEnum.Chemistry:
                    result = "Chemistry";
                    break;
                case ClassOfMorbidityTestEnum.Hematology:
                    result = "Hematology";
                    break;
                case ClassOfMorbidityTestEnum.ViralLoad:
                    result = "Viral Load";
                    break;
                case ClassOfMorbidityTestEnum.OtherTest:
                    result = "Other Test";
                    break;
                case ClassOfMorbidityTestEnum.RapidTest:
                    result = "HIV Testing";
                    break;
                case ClassOfMorbidityTestEnum.Consumable:
                    result = "Consumable";
                    break;
            }

            return result;
        }
    }

   
}
