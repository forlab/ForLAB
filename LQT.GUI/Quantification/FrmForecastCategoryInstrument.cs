
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
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Quantification
{
    public partial class FrmForecastCategoryInstrument : Form
    {
        private IList<ForecastCategoryInstrument> _fCategoryInstrument;
        private int _Fid;
        private string _error = string.Empty;
        public FrmForecastCategoryInstrument(int forecastId)
        {
            InitializeComponent();

            lsvInstrument.AddNoneEditableColumn(0);
            //lsvInstrument.AddNoneEditableColumn(1);
            lsvInstrument.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvInstrument_OnSubitemTextChanged);
            

            _Fid = forecastId;
            _fCategoryInstrument = DataRepository.GetFCInstrumentByFinfoId(_Fid);
            PopInstruments();
        }

        private void lbtAddins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSelectInstrument frm = new FrmSelectInstrument(_fCategoryInstrument,1);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                List<TestingArea> TaInSelectedIns = new List<TestingArea>();

                foreach (Instrument i in frm.SelectedInstruments)
                {

                    ForecastCategoryInstrument si = new ForecastCategoryInstrument();
                    si.Instrument = i;
                    si.TestRunPercentage = 100;
                    si.ForecastId = _Fid;
                    _fCategoryInstrument.Add(si);
                   // DataRepository.SaveOrUpdateForecastCategoryInstrument(si);

                }
              
                PopInstruments();

                //if (OnDataUsageEdit != null)
                //{
                //    OnDataUsageEdit(this, new EventArgs());
                //}
            }
        }

        private void PopInstruments()
        {
           // _fCategoryInstrument = DataRepository.GetFCInstrumentByFinfoId(_Fid);

            lsvInstrument.BeginUpdate();
            lsvInstrument.Items.Clear();

            int index = 0;
            foreach (ForecastCategoryInstrument s in _fCategoryInstrument)
            {
                
                LQTListViewTag tag = new LQTListViewTag();
                tag.Id = s.Id;
                tag.Index = index;
                tag.GroupTitle =s.Instrument.TestingArea.AreaName;

                ListViewItem li = new ListViewItem(s.Instrument.InstrumentName) { Tag =tag };
               //i.SubItems.Add(s.Instrument.InstrumentName);
                li.SubItems.Add(s.TestRunPercentage.ToString());
                 LqtUtil.AddItemToGroup(lsvInstrument, li);
                lsvInstrument.Items.Add(li);
                index++;
            }
            if (_fCategoryInstrument.Count <= 0)
            {
                lbtRemove.Enabled = false;
            }
            lsvInstrument.EndUpdate();

        }
        private void lsvInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvInstrument.SelectedItems.Count > 0)
            {
                lbtRemove.Enabled = true;

            }
            else
            {
                lbtRemove.Enabled = false;
            }
        }

        void lsvInstrument_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;
            LQTListViewTag tag = (LQTListViewTag)li.Tag;
            ForecastCategoryInstrument si;

            if (tag.Id <= 0)
                si = (ForecastCategoryInstrument)_fCategoryInstrument[tag.Index];
            else
            {
                si = _fCategoryInstrument[_fCategoryInstrument.IndexOf(DataRepository.GetFCInstrumentById(tag.Id))];
            }
            try
            {
                if (li.SubItems[1].Text == "0")
                {
                    li.SubItems[1].Text = "100";
                }
                    decimal testRun = decimal.Parse(li.SubItems[1].Text);
                    if (testRun >= 0)
                    {

                        si.TestRunPercentage = testRun;

                    }
                    else
                        li.SubItems[1].Text = si.TestRunPercentage.ToString();

            }
            catch
            {
                li.SubItems[1].Text = si.TestRunPercentage.ToString();
               
            }

        }

        public void checktestrunpercentage()
        {
            IList<TestingArea> ta = new List<TestingArea>();
           
            decimal sum = 0;
            foreach (ForecastCategoryInstrument s in _fCategoryInstrument)
            {
                if (!ta.Contains(s.Instrument.TestingArea))
                    ta.Add(s.Instrument.TestingArea);
            }
            foreach (TestingArea t in ta)
            {
                sum = 0;
                foreach (ForecastCategoryInstrument s in _fCategoryInstrument)
                {
                    if(t==s.Instrument.TestingArea)
                         sum += s.TestRunPercentage;

                }
                if(sum!=100)
                    _error+=t.AreaName+" : ";
            }
            
        }
            
        private void FrmForecastCategoryInstrument_FormClosing(object sender, FormClosingEventArgs e)
        {
            checktestrunpercentage();

            if (_error != string.Empty)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show("The sum of % Tests Run for the " + _error + " Instruments must add up to 100% " + "\n" + " or the change will not be saved. " + "\n" + " Do you want to close?", "Forecast Category Instrument", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                try
                {
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                catch (Exception ex)
                {
                    new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
                    e.Cancel = true;
                }
            }
            else
            {
                foreach (ForecastCategoryInstrument t in _fCategoryInstrument)
                    DataRepository.SaveOrUpdateForecastCategoryInstrument(t);
            }
        }

        private void lbtRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lsvInstrument.SelectedItems.Count > 0)
            {
                //LQTListViewTag tag = (LQTListViewTag)lsvInstrument.SelectedItems[0].Tag;
                foreach (ListViewItem lvi in lsvInstrument.SelectedItems)
                {
                    LQTListViewTag tag = (LQTListViewTag)lvi.Tag;
                    ForecastCategoryInstrument si;
                    if (tag.Id > 0)
                        si = DataRepository.GetForecastCategoryInstrumentById(tag.Id);
                    else
                        si = (ForecastCategoryInstrument)_fCategoryInstrument[tag.Index];
                    //_fCategoryInstrument.Remove(si);
                    DataRepository.DeleteForecastCategoryInstrument(si);
                   // DataRepository.SaveOrUpdateForecastCategoryInstrument(si);
                }

                _fCategoryInstrument = DataRepository.GetFCInstrumentByFinfoId(_Fid);

                PopInstruments();
            }
        }
    }
}
