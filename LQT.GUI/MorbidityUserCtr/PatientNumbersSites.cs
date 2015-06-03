
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
    public partial class PatientNumbersSites : BaseMorbidityControl
    {
        private SiteListView _sListView;
        private MorbidityForecast _forecast;
        private IList<ARTSite> _artSites;
        private bool _edited = false;

        public PatientNumbersSites(MorbidityForecast forecast, IList<ARTSite> artsites)
        {
            this._forecast = forecast;
            this._artSites = artsites;
        
            InitializeComponent();
            LoadSiteListView();
            BindArtSites();
        }

        public override string Title
        {
            get { return "Site-Specific Treatment Patient Numbers"; }
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
                return MorbidityCtrEnum.OptPreTreatmentPatientTargets;
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
                string desc = "Site-Specific Targets <br> If you chose one of the first three options on the previous screen, you were ";
                desc += "taken to a different screen that allowed you to use what limited data you had to estimate the number of ";
                desc += "patients your country would have on pre-treatment by the end of the forecast period. All three of those ";
                desc += "options will then take you to this screen, which you can use to manually override any of the pre-populated ";
                desc += "targets by month and by site. However, if you chose Option 4 because you have complete data at the site level, ";
                desc += "then you were brought directly to this screen, which you can use to enter detailed targets by month and by site.";
                return desc;
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
            _sListView.Columns.Add(new EXColumnHeader("Category/Region", 100));
            _sListView.Columns.Add(new EXColumnHeader("ART Site", 120));
            _sListView.Columns.Add(new EXEditableColumnHeader("% pediatrics", 60));

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

            _sListView.EditableListViewSubitemValueChanged += new EventHandler<EXEditableListViewSubitemEventArgs>(_sListView_EditableListViewSubitemValueChanged);
            this.Controls.Add(_sListView);
        }

        private void _sListView_EditableListViewSubitemValueChanged(object sender, EXEditableListViewSubitemEventArgs e)
        {
            ARTSite site = (ARTSite)e.ListVItem.Tag;
            _edited = true;

            if (e.SubItem.ColumnName.ToString() == "PercentOfChildren")
                site.NTTPercentOfChildren = double.Parse(e.SubItem.Text);
            else
            {
                MonthNameEnum month = (MonthNameEnum)e.SubItem.ColumnName;
                switch (month)
                {
                    case MonthNameEnum.January:
                        site.NTTJanuary = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.February:
                        site.NTTFebruary = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.March:
                        site.NTTMarch = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.April:
                        site.NTTApril = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.May:
                        site.NTTMay = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.June:
                        site.NTTJune = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.July:
                        site.NTTJuly = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.August:
                        site.NTTAugust = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.September:
                        site.NTTSeptember = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.October:
                        site.NTTOctober = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.November:
                        site.NTTNovember = double.Parse(e.SubItem.Text);
                        break;
                    case MonthNameEnum.December:
                        site.NTTDecember = double.Parse(e.SubItem.Text);
                        break;
                }
            }
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
                item.SubItems.Add(new EXListViewSubItem(site.NTTJanuary.ToString(), MonthNameEnum.January));
                item.SubItems.Add(new EXListViewSubItem(site.NTTFebruary.ToString(), MonthNameEnum.February));
                item.SubItems.Add(new EXListViewSubItem(site.NTTMarch.ToString(), MonthNameEnum.March));
                item.SubItems.Add(new EXListViewSubItem(site.NTTApril.ToString(), MonthNameEnum.April));
                item.SubItems.Add(new EXListViewSubItem(site.NTTMay.ToString(), MonthNameEnum.May));
                item.SubItems.Add(new EXListViewSubItem(site.NTTJune.ToString(), MonthNameEnum.June));
                item.SubItems.Add(new EXListViewSubItem(site.NTTJuly.ToString(), MonthNameEnum.July));
                item.SubItems.Add(new EXListViewSubItem(site.NTTAugust.ToString(), MonthNameEnum.August));
                item.SubItems.Add(new EXListViewSubItem(site.NTTSeptember.ToString(), MonthNameEnum.September));
                item.SubItems.Add(new EXListViewSubItem(site.NTTOctober.ToString(), MonthNameEnum.October));
                item.SubItems.Add(new EXListViewSubItem(site.NTTNovember.ToString(), MonthNameEnum.November));
                item.SubItems.Add(new EXListViewSubItem(site.NTTDecember.ToString(), MonthNameEnum.December));
                
                _sListView.Items.Add(item);
            }
            _sListView.EndUpdate();
        }

        public override bool DoSomthingBeforeUnload()
        {
            if (_edited)
            {
                DataRepository.BatchSaveARTSite(_artSites);
                MorbidityForm.ReInitMorbidityFrm();
            }
            return true;
        }
    }
}
