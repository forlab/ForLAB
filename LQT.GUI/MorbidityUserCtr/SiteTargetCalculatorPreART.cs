
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class SiteTargetCalculatorPreART : BaseMorbidityControl
    {
        private SiteListView _sListView;
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        public SiteTargetCalculatorPreART(MorbidityForecast forecast, IList<ARTSite> artsites)
        {
            this._forecast = forecast;
            this._artSites = artsites;

            InitializeComponent();
            
            //default no growth of patients
            if (_forecast.NTPTDecember <= 0)
            {
                _forecast.NTPTDecember = _forecast.TimeZeroPatientOnPreTreatment;
                CalculateLinearScalup();
                DoTargetCalculation();
                _edited = true;
            }

            MakeMonthLabeling();
            BindForecastMonthValues();

            txtAgust.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtApril.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtDecember.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtFebruary.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtJaunary.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtJuly.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtJune.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtMarch.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtMay.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtNovember.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtOctober.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtRecent.LostFocus += new EventHandler(nTargetTextBox_LostFocus);
            txtSeptember.LostFocus += new EventHandler(nTargetTextBox_LostFocus);

            if (_forecast.PreTreatmentPatinetTargetEnum == OptPreTreatmentPatinetTargetEnum.NationalTarget)
            {
                splitContainer1.Panel2.Hide();
            }
            else
            {
                LoadSiteListView();
                BindArtSites();
            }
        }

        public override string Title
        {
            get { return "Site Target Calculator"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.OptPreTreatmentPatientTargets;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.PreTxNumbersSites;
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
                return "";
            }
        }


        private void BindForecastMonthValues()
        {
            txtDecember.Text = _forecast.NTPTDecember.ToString();
            txtAgust.Text = _forecast.NTPTAugust.ToString();
            txtApril.Text = _forecast.NTPTApril.ToString();
            
            txtFebruary.Text = _forecast.NTPTFebruary.ToString();
            txtJaunary.Text = _forecast.NTPTJanuary.ToString();
            txtJuly.Text = _forecast.NTPTJuly.ToString();
            txtJune.Text = _forecast.NTPTJune.ToString();
            txtMarch.Text = _forecast.NTPTMarch.ToString();
            txtMay.Text = _forecast.NTPTMay.ToString();
            txtNovember.Text = _forecast.NTPTNovember.ToString();
            txtOctober.Text = _forecast.NTPTOctober.ToString();
            txtRecent.Text = _forecast.TimeZeroPatientOnPreTreatment.ToString();
            txtSeptember.Text = _forecast.NTPTSeptember.ToString();
            txtPediatric.Text = _forecast.NTPTPercentOfChildren.ToString();

            if (_forecast.TimeZeroPatientOnPreTreatment > 0)
                lblAnualgrowth.Text = Math.Ceiling(((_forecast.NTPTDecember - _forecast.TimeZeroPatientOnPreTreatment) / _forecast.TimeZeroPatientOnPreTreatment) * 100).ToString() + "%";
        }

        private void MakeMonthLabeling()
        {
            int month = _forecast.StartBudgetPeriod;

            if (month - 1 == 0)
            {
                label0.Text = LqtUtil.Months[11];
                butLinear.Text = String.Format("Calculate linear scale-up between {0} {1} and {2} {3}", LqtUtil.Months[11], _forecast.SatartDate.Year - 1, LqtUtil.Months[11], _forecast.SatartDate.Year);
            }
            else
            {
                label0.Text = LqtUtil.Months[month - 2];
                butLinear.Text = String.Format("Calculate linear scale-up between {0} {1} and {2} {3}", LqtUtil.Months[month - 2], _forecast.SatartDate.Year, LqtUtil.Months[month - 2], _forecast.SatartDate.Year + 1);
            }

            for (int i = 1; i <= 12; i++)
            {
                Label lbl = tableLayoutPanel1.Controls[String.Format("label{0}", i)] as Label;
                if (month > 12)
                    month = 1;
                lbl.Text = LqtUtil.Months[month - 1];
                month++;
            }
        }

        private void LoadSiteListView()
        {
            _sListView = new SiteListView();
            _sListView.MySortBrush = SystemBrushes.ControlLight;
            _sListView.MyHighlightBrush = Brushes.Goldenrod;
            _sListView.GridLines = true;
            _sListView.MultiSelect = false;
            _sListView.Dock = DockStyle.Fill;
            _sListView.ControlPadding = 4;
            _sListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                        
            //add columns and items
            _sListView.Columns.Add(new EXColumnHeader("Category/Region", 150));
            _sListView.Columns.Add(new EXColumnHeader("ART Site", 150));
            _sListView.Columns.Add(new EXEditableColumnHeader("% pediatrics", 80));

            int month = _forecast.StartBudgetPeriod;
            if (month - 1 == 0)
                _sListView.Columns.Add(new EXColumnHeader(LqtUtil.Months[11], 80));
            else
                _sListView.Columns.Add(new EXColumnHeader(LqtUtil.Months[month - 2], 80));

            for (int i = 1; i <= 12; i++)
            {
                if (month > 12)
                    month = 1;
                _sListView.Columns.Add(new EXColumnHeader(LqtUtil.Months[month - 1], 80));
                month++;
            }

            _sListView.Columns.Add(new EXEditableColumnHeader("Growth Target", 80));

            EXBoolColumnHeader boolcol = new EXBoolColumnHeader("Apply Growth", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 80);
            boolcol.Editable = true;

            _sListView.Columns.Add(boolcol);

            _sListView.BoolListViewSubItemValueChanged += new EventHandler<EXBoolListViewSubItemEventArgs>(sListView_BoolListViewSubItemValueChanged);
            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            _sListView.SelectedIndexChanged += new EventHandler(sListView_SelectedIndexChanged);
            splitContainer1.Panel2.Controls.Add(_sListView);
        }

        private void _sListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            ARTSite site = (ARTSite)e.ListVItem.Tag;
            if (e.SubItem.ColumnName.ToString() == "PercentOfChildren")
                site.NTPTPercentOfChildren = double.Parse(e.SubItem.Text);
            if (e.SubItem.ColumnName.ToString() == "GrowthTarget")
                site.NTPTGrowthTarget = double.Parse(e.SubItem.Text);
            _edited = true;
        }

        private void sListView_BoolListViewSubItemValueChanged(object sender, EXBoolListViewSubItemEventArgs e)
        {
            ARTSite site = (ARTSite)e.ListVItem.Tag;
            site.NTPTApplyLinerGrowth = e.Subitem.BoolValue;
            _edited = true;
        }

        private void sListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BindArtSites()
        {
            _sListView.Items.Clear();

            _sListView.BeginUpdate();

            foreach (ARTSite site in _artSites)
            {
                EXListViewItem item = new EXListViewItem(site.MorbidityCategory.CategoryName) { Tag = site };

                item.SubItems.Add(new EXListViewSubItem(site.Site.SiteName));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTPercentOfChildren.ToString(), "PercentOfChildren"));

                item.SubItems.Add(new EXListViewSubItem(site.TimeZeroPatientOnPreTreatment.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTJanuary.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTFebruary.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTMarch.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTApril.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTMay.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTJune.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTJuly.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTAugust.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTSeptember.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTOctober.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTNovember.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTDecember.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTPTGrowthTarget.ToString(), "GrowthTarget"));

                item.SubItems.Add(new EXBoolListViewSubItem(site.NTPTApplyLinerGrowth, "ApplyGrowth"));

                _sListView.Items.Add(item);
            }
            _sListView.EndUpdate();
        }

        private void RefreshListView()
        {
            foreach (ListViewItem li in _sListView.Items)
            {
                ARTSite site = (ARTSite)li.Tag;

                //li.SubItems[2].Text = site.NTTPercentOfChildren.ToString();

                //li.SubItems[3].Text = site.TimeZeroPatientOnTreatment.ToString();
                li.SubItems[4].Text = site.NTPTJanuary.ToString();
                li.SubItems[5].Text = site.NTPTFebruary.ToString();
                li.SubItems[6].Text = site.NTPTMarch.ToString();
                li.SubItems[7].Text = site.NTPTApril.ToString();
                li.SubItems[8].Text = site.NTPTMay.ToString();
                li.SubItems[9].Text = site.NTPTJune.ToString();
                li.SubItems[10].Text = site.NTPTJuly.ToString();
                li.SubItems[11].Text = site.NTPTAugust.ToString();
                li.SubItems[12].Text = site.NTPTSeptember.ToString();
                li.SubItems[13].Text = site.NTPTOctober.ToString();
                li.SubItems[14].Text = site.NTPTNovember.ToString();
                li.SubItems[15].Text = site.NTPTDecember.ToString();
            }
        }

        private void OnlyDigt_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8)||(x==46))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void nTargetTextBox_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            double value = string.IsNullOrEmpty(txt.Text) ? 0 : double.Parse(txt.Text);
            bool docalculation = false;
            int val = int.Parse(txt.Tag.ToString());
            switch (val)
            {
                case 1:
                    if (value != _forecast.NTPTJanuary)
                    {
                        _forecast.NTPTJanuary = value;
                        docalculation = true;
                    }
                    break;
                case 2:
                    if (value != _forecast.NTPTFebruary)
                    {
                        _forecast.NTPTFebruary = value;
                        docalculation = true;
                    }
                    break;
                case 3:
                    if (value != _forecast.NTPTMarch)
                    {
                        _forecast.NTPTMarch = value;
                        docalculation = true;
                    }
                    break;
                case 4:
                    if (value != _forecast.NTPTApril)
                    {
                        _forecast.NTPTApril = value;
                        docalculation = true;
                    }
                    break;
                case 5:
                    if (value != _forecast.NTPTMay)
                    {
                        _forecast.NTPTMay = value;
                        docalculation = true;
                    }
                    break;
                case 6:
                    if (value != _forecast.NTPTJune)
                    {
                        _forecast.NTPTJune = value;
                        docalculation = true;
                    }
                    break;
                case 7:
                    if (value != _forecast.NTPTJuly)
                    {
                        _forecast.NTPTJuly = value;
                        docalculation = true;
                    }
                    break;
                case 8:
                    if (value != _forecast.NTPTAugust)
                    {
                        _forecast.NTPTAugust = value;
                        docalculation = true;
                    }
                    break;
                case 9:
                    if (value != _forecast.NTPTSeptember)
                    {
                        _forecast.NTPTSeptember = value;
                        docalculation = true;
                    }
                    break;
                case 10:
                    if (value != _forecast.NTPTOctober)
                    {
                        _forecast.NTPTOctober = value;
                        docalculation = true;
                    }
                    break;
                case 11:
                    if (value != _forecast.NTPTNovember)
                    {
                        _forecast.NTPTNovember = value;
                        docalculation = true;
                    }
                    break;
                case 12:
                    if (value != _forecast.NTPTDecember)
                    {
                        _forecast.NTPTDecember = value;
                        docalculation = true;
                    }
                    break;
            }

            if (docalculation)
            {
                DoTargetCalculation();
                _edited = true;
            }
        }

        private void CalculateLinearScalup()
        {
            double timezero = _forecast.TimeZeroPatientOnPreTreatment;
            double dif = _forecast.NTPTDecember - timezero;

            _forecast.NTPTJanuary = timezero + (dif / 12);
            _forecast.NTPTFebruary = _forecast.NTPTJanuary + (dif / 12);
            _forecast.NTPTMarch = _forecast.NTPTFebruary + (dif / 12);
            _forecast.NTPTApril = _forecast.NTPTMarch + (dif / 12);
            _forecast.NTPTMay = _forecast.NTPTApril + (dif / 12);
            _forecast.NTPTJune = _forecast.NTPTMay + (dif / 12);
            _forecast.NTPTJuly = _forecast.NTPTJune + (dif / 12);
            _forecast.NTPTAugust = _forecast.NTPTJuly + (dif / 12);
            _forecast.NTPTSeptember = _forecast.NTPTAugust + (dif / 12);
            _forecast.NTPTOctober = _forecast.NTPTSeptember + (dif / 12);
            _forecast.NTPTNovember = _forecast.NTPTOctober + (dif / 12);
            //_forecast.NTTDecember = _forecast.NTTNovember + (dif / 12);
        }

        private double[,] GetPatternOfGrowthOnTreatment()
        {
            double[,] monthlyInc = new double[12, 12];

            monthlyInc[0, 0] = _forecast.NTPTJanuary - _forecast.TimeZeroPatientOnPreTreatment;
            monthlyInc[1, 0] = _forecast.NTPTFebruary - monthlyInc[0, 0];
            monthlyInc[2, 0] = _forecast.NTPTMarch - monthlyInc[1, 0];
            monthlyInc[3, 0] = _forecast.NTPTApril - monthlyInc[2, 0];
            monthlyInc[4, 0] = _forecast.NTPTMay - monthlyInc[3, 0];
            monthlyInc[5, 0] = _forecast.NTPTJune - monthlyInc[4, 0];
            monthlyInc[6, 0] = _forecast.NTPTJuly - monthlyInc[5, 0];
            monthlyInc[7, 0] = _forecast.NTPTAugust - monthlyInc[6, 0];
            monthlyInc[8, 0] = _forecast.NTPTSeptember - monthlyInc[7, 0];
            monthlyInc[9, 0] = _forecast.NTPTOctober - monthlyInc[8, 0];
            monthlyInc[10, 0] = _forecast.NTPTNovember - monthlyInc[9, 0];
            monthlyInc[11, 0] = _forecast.NTPTDecember - monthlyInc[10, 0];

            double total = 0;
            for (int i = 0; i < 12; i++)
            {
                total += monthlyInc[i, 0];
            }

            for (int i = 0; i < 12; i++)
            {
                monthlyInc[i, 1] = monthlyInc[i, 0] / total;
            }

            return monthlyInc;
        }

        private void NotinalTargetForAdjustSites()
        {
            double[,] pattern = GetPatternOfGrowthOnTreatment();

            foreach (ARTSite site in _artSites)
            {
                if (site.NTPTGrowthTarget > 0)
                {
                    if (site.NTPTApplyLinerGrowth)
                        site.ApplieLinearGrowthOnPreTreatment();
                    else
                        site.ApplieNationalGrowthOnPreTreatment(pattern);
                }
            }
        }

        private double SumOfNTTAllSites(int month)
        {
            double result = 0;
            foreach (ARTSite site in _artSites)
            {
                result += site.GetNTPTMonthValue(month);
            }
            return result;
        }

        private double SumOfNTTAdjustedSites(int month)
        {
            double result = 0;
            foreach (ARTSite site in _artSites)
            {
                if (site.NTTGrowthTarget > 0)
                {
                    result += site.GetNTPTMonthValue(month);
                }
            }
            return result;
        }

        private double SumOfNTTNoneAdjustedSites(int month)
        {
            double result = 0;
            foreach (ARTSite site in _artSites)
            {
                if (site.NTPTGrowthTarget == 0)
                {
                    result += site.GetNTPTMonthValue(month);
                }
            }
            return result;
        }

        private void NotinalTargetForNoneAdjustedSites()
        {
            double totalsumOfnoneAsite = SumOfNTTNoneAdjustedSites(0);
            double privsumofAsiteM = SumOfNTTAdjustedSites(1);
            double privincreaseM = (_forecast.NTPTJanuary - privsumofAsiteM) - (_forecast.TimeZeroPatientOnPreTreatment - SumOfNTTAdjustedSites(0));
            privincreaseM = privincreaseM < 0 ? 0 : privincreaseM;

            foreach (ARTSite site in _artSites)
            {
                if (site.NTPTGrowthTarget == 0)
                {
                    site.NTPTJanuary = site.TimeZeroPatientOnPreTreatment + (privincreaseM * (site.TimeZeroPatientOnPreTreatment / totalsumOfnoneAsite));
                }
            }

            double targetM;
            double sumofAsiteM;
            double increaseM;

            for (int i = 2; i <= 12; i++)
            {
                targetM = _forecast.GetNTPTMonthValue(i);
                sumofAsiteM = SumOfNTTAdjustedSites(i);
                //remainderM = targetM - sumofAsiteM;
                increaseM = (targetM - SumOfNTTAllSites(i - 1)) - (sumofAsiteM - privsumofAsiteM);
                increaseM = increaseM < 0 ? 0 : increaseM;

                foreach (ARTSite site in _artSites)
                {
                    if (site.NTPTGrowthTarget == 0)
                    {
                        double nval = site.GetNTPTMonthValue(i - 1) + (increaseM * (site.TimeZeroPatientOnPreTreatment / totalsumOfnoneAsite));
                        site.SetNTPTMonthValue(i, nval);
                    }
                }

                //privtargetM = targetM;
                privsumofAsiteM = sumofAsiteM;
            }

        }

        private void butLinear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDecember.Text) || int.Parse(txtDecember.Text) == 0)
            {
                if (DialogResult.No == MessageBox.Show("Since you haven’t specified the December expected value, the tool will assume that there is no growth throughout the forecast period. Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }

            _forecast.NTPTDecember = double.Parse(txtDecember.Text);
            CalculateLinearScalup();
            BindForecastMonthValues();
            DoTargetCalculation();
            
            _edited = true;
        }

        private void butPedatric_Click(object sender, EventArgs e)
        {
            double val = string.IsNullOrEmpty(txtPediatric.Text.Trim()) ? 0 : double.Parse(txtPediatric.Text);
            _forecast.NTPTPercentOfChildren = val;
            foreach (ARTSite site in _artSites)
            {
                site.NTPTPercentOfChildren = val;
            }
            if (_forecast.PreTreatmentPatinetTargetEnum != OptPreTreatmentPatinetTargetEnum.NationalTarget)
                RefreshListView();
            _edited = true;
            MessageBox.Show("Pediatric population number has been applied successfully", "Confirmation");
        }

        private void DoTargetCalculation()
        {
            NotinalTargetForAdjustSites();
            NotinalTargetForNoneAdjustedSites();
            if (_forecast.PreTreatmentPatinetTargetEnum != OptPreTreatmentPatinetTargetEnum.NationalTarget)
                RefreshListView();
        }

        public override bool DoSomthingBeforeUnload()
        {
            if (_edited)
            {
                DataRepository.BatchSaveARTSite(_artSites);
                DataRepository.SaveOrUpdateMorbidityForecast(_forecast);
                MorbidityForm.ReInitMorbidityFrm();
            }
            return true;
        }
    }
}
