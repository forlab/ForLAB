
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class SiteTargetCalculator : BaseMorbidityControl
    {
        private SiteListView _sListView;
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        public SiteTargetCalculator(MorbidityForecast forecast, IList<ARTSite> artsites)
        {
            this._forecast = forecast;
            this._artSites = artsites;

            InitializeComponent();

            MakeMonthLabeling();

            //default no growth of patients
            if (_forecast.NTTDecember <= 0)
            {
                _forecast.NTTDecember = _forecast.TimeZeroPatientOnTreatment;
                CalculateLinearScalup();
                DoTargetCalculation();
                _edited = true;
            }

            BindForecastMonthValues();
            
            txtAgust.LostFocus +=new EventHandler(nTargetTextBox_LostFocus);
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

            if (_forecast.ArtPatinetTargetEnum == OptArtPatinetTargetEnum.NationalTarget)
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
                return MorbidityCtrEnum.OptArtPatientTarget;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.PatientNumbersSites;
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
            txtDecember.Text = _forecast.NTTDecember.ToString();
            txtAgust.Text = _forecast.NTTAugust.ToString();
            txtApril.Text = _forecast.NTTApril.ToString();
           
            txtFebruary.Text = _forecast.NTTFebruary.ToString();
            txtJaunary.Text = _forecast.NTTJanuary.ToString();
            txtJuly.Text = _forecast.NTTJuly.ToString();
            txtJune.Text = _forecast.NTTJune.ToString();
            txtMarch.Text = _forecast.NTTMarch.ToString();
            txtMay.Text = _forecast.NTTMay.ToString();
            txtNovember.Text = _forecast.NTTNovember.ToString();
            txtOctober.Text = _forecast.NTTOctober.ToString();
            txtRecent.Text = _forecast.TimeZeroPatientOnTreatment.ToString();
            txtSeptember.Text = _forecast.NTTSeptember.ToString();
            txtPediatric.Text = _forecast.NTTPercentOfChildren.ToString();

            if (_forecast.TimeZeroPatientOnTreatment > 0)
                lblAnualgrowth.Text = Math.Ceiling(((_forecast.NTTDecember - _forecast.TimeZeroPatientOnTreatment) / _forecast.TimeZeroPatientOnTreatment) * 100).ToString() + "%";
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

            //add SmallImageList to ListView - images will be shown in ColumnHeaders
            var colimglst = new ImageList();
            colimglst.Images.Add("down", trueFalseImageList.Images[2]);
            colimglst.Images.Add("up", trueFalseImageList.Images[3]);
            colimglst.ColorDepth = ColorDepth.Depth32Bit;
            colimglst.ImageSize = new Size(20, 20); // this will affect the row height
            _sListView.SmallImageList = colimglst;

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

            var boolcol = new EXBoolColumnHeader("Apply Growth", trueFalseImageList.Images[0], trueFalseImageList.Images[1], 80)
            {
                Editable = true
            };

            _sListView.Columns.Add(boolcol);

            _sListView.BoolListViewSubItemValueChanged += new EventHandler<EXBoolListViewSubItemEventArgs>(sListView_BoolListViewSubItemValueChanged);
            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            _sListView.SelectedIndexChanged += new EventHandler(sListView_SelectedIndexChanged);
            splitContainer1.Panel2.Controls.Add(_sListView);
        }

        private void _sListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            ARTSite site = (ARTSite)e.ListVItem.Tag;
            if(e.SubItem.ColumnName.ToString() == "PercentOfChildren")
                site.NTTPercentOfChildren = double.Parse( e.SubItem.Text);
            if (e.SubItem.ColumnName.ToString() == "GrowthTarget")
                site.NTTGrowthTarget = double.Parse(e.SubItem.Text);
            _edited = true;
        }

        private void sListView_BoolListViewSubItemValueChanged(object sender, EXBoolListViewSubItemEventArgs e)
        {
            ARTSite site = (ARTSite)e.ListVItem.Tag;            
            site.NTTApplyLinerGrowth = e.Subitem.BoolValue;
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
                item.SubItems.Add(new EXListViewSubItem(site.NTTPercentOfChildren.ToString(), "PercentOfChildren"));

                item.SubItems.Add(new EXListViewSubItem(site.TimeZeroPatientOnTreatment.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTJanuary.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTFebruary.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTMarch.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTApril.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTMay.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTJune.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTJuly.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTAugust.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTSeptember.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTOctober.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTNovember.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTDecember.ToString()));
                item.SubItems.Add(new EXListViewSubItem(site.NTTGrowthTarget.ToString(), "GrowthTarget"));

                item.SubItems.Add(new EXBoolListViewSubItem(site.NTTApplyLinerGrowth, "ApplyGrowth"));

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
                li.SubItems[4].Text = site.NTTJanuary.ToString();
                li.SubItems[5].Text = site.NTTFebruary.ToString();
                li.SubItems[6].Text = site.NTTMarch.ToString();
                li.SubItems[7].Text = site.NTTApril.ToString();
                li.SubItems[8].Text = site.NTTMay.ToString();
                li.SubItems[9].Text = site.NTTJune.ToString();
                li.SubItems[10].Text = site.NTTJuly.ToString();
                li.SubItems[11].Text = site.NTTAugust.ToString();
                li.SubItems[12].Text = site.NTTSeptember.ToString();
                li.SubItems[13].Text = site.NTTOctober.ToString();
                li.SubItems[14].Text = site.NTTNovember.ToString();
                li.SubItems[15].Text = site.NTTDecember.ToString();
            }
        }

        private void OnlyDigt_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8) || (x == 46))
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

            int val=int.Parse(txt.Tag.ToString());
            switch (val)
            {
                case 1:
                    if (value != _forecast.NTTJanuary)
                    {
                        _forecast.NTTJanuary = value;
                        docalculation = true;
                    }
                    break;
                case 2:
                    if (value != _forecast.NTTFebruary)
                    {
                        _forecast.NTTFebruary = value;
                        docalculation = true;
                    }
                    break;
                case 3:
                    if (value != _forecast.NTTMarch)
                    {
                        _forecast.NTTMarch = value;
                        docalculation = true;
                    }
                    break;
                case 4:
                    if (value != _forecast.NTTApril)
                    {
                        _forecast.NTTApril = value;
                        docalculation = true;
                    }
                    break;
                case 5:
                    if (value != _forecast.NTTMay)
                    {
                        _forecast.NTTMay = value;
                        docalculation = true;
                    }
                    break;
                case 6:
                    if (value != _forecast.NTTJune)
                    {
                        _forecast.NTTJune = value;
                        docalculation = true;
                    }
                    break;
                case 7:
                    if (value != _forecast.NTTJuly)
                    {
                        _forecast.NTTJuly = value;
                        docalculation = true;
                    }
                    break;
                case 8:
                    if (value != _forecast.NTTAugust)
                    {
                        _forecast.NTTAugust = value;
                        docalculation = true;
                    }
                    break;
                case 9:
                    if (value != _forecast.NTTSeptember)
                    {
                        _forecast.NTTSeptember = value;
                        docalculation = true;
                    }
                    break;
                case 10:
                    if (value != _forecast.NTTOctober)
                    {
                        _forecast.NTTOctober = value;
                        docalculation = true;
                    }
                    break;
                case 11:
                    if (value != _forecast.NTTNovember)
                    {
                        _forecast.NTTNovember = value;
                        docalculation = true;
                    }
                    break;
                case 12:
                    if (value != _forecast.NTTDecember)
                    {
                        _forecast.NTTDecember = value;
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
            double timezero = _forecast.TimeZeroPatientOnTreatment;
            double dif = _forecast.NTTDecember - timezero;

            _forecast.NTTJanuary = timezero + (dif / 12);
            _forecast.NTTFebruary = _forecast.NTTJanuary + (dif / 12);
            _forecast.NTTMarch = _forecast.NTTFebruary + (dif / 12);
            _forecast.NTTApril = _forecast.NTTMarch + (dif / 12);
            _forecast.NTTMay = _forecast.NTTApril + (dif / 12);
            _forecast.NTTJune = _forecast.NTTMay + (dif / 12);
            _forecast.NTTJuly = _forecast.NTTJune + (dif / 12);
            _forecast.NTTAugust = _forecast.NTTJuly + (dif / 12);
            _forecast.NTTSeptember = _forecast.NTTAugust + (dif / 12);
            _forecast.NTTOctober = _forecast.NTTSeptember + (dif / 12);
            _forecast.NTTNovember = _forecast.NTTOctober + (dif / 12);
            //_forecast.NTTDecember = _forecast.NTTNovember + (dif / 12);

            if (_forecast.TimeZeroPatientOnTreatment > 0)
                lblAnualgrowth.Text = Math.Ceiling((dif / _forecast.TimeZeroPatientOnTreatment)).ToString() + "%";
        }
        
        private double[,] GetPatternOfGrowthOnTreatment()
        {
            double[,] monthlyInc = new double[12,12];

            monthlyInc[0,0]  = _forecast.NTTJanuary - _forecast.TimeZeroPatientOnTreatment;
            monthlyInc[1, 0] = _forecast.NTTFebruary - monthlyInc[0, 0];
            monthlyInc[2, 0] = _forecast.NTTMarch - monthlyInc[1, 0];
            monthlyInc[3, 0] = _forecast.NTTApril - monthlyInc[2, 0];
            monthlyInc[4, 0] = _forecast.NTTMay - monthlyInc[3, 0];
            monthlyInc[5, 0] = _forecast.NTTJune - monthlyInc[4, 0];
            monthlyInc[6, 0] = _forecast.NTTJuly - monthlyInc[5, 0];
            monthlyInc[7, 0] = _forecast.NTTAugust - monthlyInc[6, 0];
            monthlyInc[8, 0] = _forecast.NTTSeptember - monthlyInc[7, 0];
            monthlyInc[9, 0] = _forecast.NTTOctober - monthlyInc[8, 0];
            monthlyInc[10, 0] = _forecast.NTTNovember - monthlyInc[9, 0];
            monthlyInc[11, 0] = _forecast.NTTDecember - monthlyInc[10, 0];

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
                if (site.NTTGrowthTarget > 0)
                {
                    if (site.NTTApplyLinerGrowth)
                        site.ApplieLinearGrowthOnTreatment();
                    else
                        site.ApplieNationalGrowthOnTreatment(pattern);
                }
            }
        }

        private double SumOfNTTAllSites(int month)
        {
            return _artSites.Sum(site => site.GetNTTMonthValue(month));
        }

        private double SumOfNTTAdjustedSites(int month)
        {
            return _artSites.Where(site => site.NTTGrowthTarget > 0).Sum(site => site.GetNTTMonthValue(month));
        }

        private double SumOfNTTNoneAdjustedSites(int month)
        {
            return _artSites.Where(site => site.NTTGrowthTarget == 0).Sum(site => site.GetNTTMonthValue(month));
        }

        private void NotinalTargetForNoneAdjustedSites()
        {
            double totalsumOfnoneAsite = SumOfNTTNoneAdjustedSites(0);

            //double privtargetM = _forecast.NTTJanuary;
            double privsumofAsiteM = SumOfNTTAdjustedSites(1);
            //double privremainderM = _forecast.NTTJanuary - privsumofAsiteM;
            double privincreaseM = (_forecast.NTTJanuary - privsumofAsiteM) - (_forecast.TimeZeroPatientOnTreatment - SumOfNTTAdjustedSites(0));
            privincreaseM = privincreaseM < 0 ? 0 : privincreaseM;

            foreach (ARTSite site in _artSites)
            {
                if(site.NTTGrowthTarget==0)
                {
                    site.NTTJanuary = site.TimeZeroPatientOnTreatment + (privincreaseM * (site.TimeZeroPatientOnTreatment / totalsumOfnoneAsite));
                }
            }

            double targetM;
            double sumofAsiteM;
            //double remainderM;
            double increaseM;

            for (int i = 2; i <= 12; i++)
            {
                targetM = _forecast.GetNTTMonthValue(i);
                sumofAsiteM = SumOfNTTAdjustedSites(i);
                //remainderM = targetM - sumofAsiteM;
                increaseM = (targetM - SumOfNTTAllSites(i - 1)) - (sumofAsiteM - privsumofAsiteM);
                increaseM = increaseM < 0 ? 0 : increaseM;

                foreach (ARTSite site in _artSites)
                {
                    if (site.NTTGrowthTarget == 0)
                    {
                        double nval = site.GetNTTMonthValue(i-1) + (increaseM * (site.TimeZeroPatientOnTreatment / totalsumOfnoneAsite));
                        site.SetNTTMonthValue(i, nval);
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
                if (DialogResult.No == MessageBox.Show(String.Format("Since you haven't specified the {0} expected value, the tool will assume that there is no growth throughout the forecast period.\n\t Do you want to continue?", label12.Text ), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }
            
            _forecast.NTTDecember = double.Parse(txtDecember.Text);
            
            CalculateLinearScalup();
            BindForecastMonthValues();
            DoTargetCalculation();
            _edited = true;
        }

        private void butPedatric_Click(object sender, EventArgs e)
        {
            double val = string.IsNullOrEmpty(txtPediatric.Text.Trim()) ? 0 : double.Parse(txtPediatric.Text);
            _forecast.NTTPercentOfChildren = val;
            foreach (ARTSite site in _artSites)
            {
                site.NTTPercentOfChildren = val;
            }
            if (_forecast.ArtPatinetTargetEnum != OptArtPatinetTargetEnum.NationalTarget)
                RefreshListView();
            _edited = true;
            MessageBox.Show("Pediatric population number has been applied successfully", "Confirmation");
        }

        private void DoTargetCalculation()
        {
            NotinalTargetForAdjustSites();
            NotinalTargetForNoneAdjustedSites();
            if (_forecast.ArtPatinetTargetEnum != OptArtPatinetTargetEnum.NationalTarget)
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
