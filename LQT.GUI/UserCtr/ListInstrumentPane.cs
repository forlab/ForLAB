
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
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Asset;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListInstrumentPane : BaseUserControl
    {
        private int _selectedInsId = 0;


        public ListInstrumentPane()
        {
            InitializeComponent();
            PopInstruments();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Instruments";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopInstruments();
        }

        private void PopInstruments()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (Instrument r in DataRepository.GetAllInstrument())
            {
                ListViewItem li = new ListViewItem(r.InstrumentName) { Tag = r.Id };
                li.SubItems.Add(r.TestingArea != null ? r.TestingArea.AreaName : "");
                li.SubItems.Add(r.MaxThroughPut.ToString());
                li.SubItems.Add(r.DailyCtrlTest.ToString());
                li.SubItems.Add(r.MaxTestBeforeCtrlTest.ToString());
                li.SubItems.Add(r.WeeklyCtrlTest.ToString());
                li.SubItems.Add(r.MonthlyCtrlTest.ToString());
                li.SubItems.Add(r.QuarterlyCtrlTest.ToString());
                if (r.Id == _selectedInsId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }

            listView1.EndUpdate();


        }



        private Instrument GetSelectedInstrument()
        {
            return DataRepository.GetInstrumentById(_selectedInsId);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            //listView1.Columns[1].Width = listView1.Width - 305;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InstrumentForm frm = new InstrumentForm(new Instrument(), MdiParentForm);
            frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                if (id != _selectedInsId)
                {
                    _selectedInsId = id;

                }
            }
            SelectedItemChanged(listView1);
        }


        public override void EditSelectedItem()
        {
            InstrumentForm frm = new InstrumentForm(GetSelectedInstrument(), MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            if (MessageBox.Show("Are you sure you want to delete this Instrument?", "Delete Instrument", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteInstrument(GetSelectedInstrument());
                    MdiParentForm.ShowStatusBarInfo("Instrument was deleted successfully.");
                    _selectedInsId = 0;
                    PopInstruments();
                    return true;
                }
                catch (Exception ex)
                {
                    new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry, you could not delete Instrument it been added as Site Instrument." }).ShowDialog();
                }
                finally
                {
                    DataRepository.CloseSession();
                }
            }

            return false;
        }
    }
}
