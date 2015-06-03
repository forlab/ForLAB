
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
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Testing;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListTestingAreaPane : BaseUserControl 
    {
        private int _selectedTestAreaId = 0;
      

        public ListTestingAreaPane()
        {
            InitializeComponent();
            PopTestingAreas();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Testing Areas";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopTestingAreas();
        }

        private void PopTestingAreas()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (TestingArea ta in DataRepository.GetAllTestingArea())
            {
                ListViewItem li = new ListViewItem(ta.AreaName) { Tag = ta.Id };
                li.SubItems.Add(ta.UseInDemography.ToString());
                li.SubItems.Add(ta.Category);
                if (ta.Id == _selectedTestAreaId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }
            
            listView1.EndUpdate();

           
        }

        

        private TestingArea GetSelectedTestingArea()
        {
            return DataRepository.GetTestingAreaById(_selectedTestAreaId);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
           //// listView1.Columns[1].Width = listView1.Width - 5;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TestingAreaFrom frm = new TestingAreaFrom(new TestingArea(), MdiParentForm);
            frm.ShowDialog();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                if (id != _selectedTestAreaId)
                {
                    _selectedTestAreaId = id;
                   
                }
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            TestingAreaFrom frm = new TestingAreaFrom(GetSelectedTestingArea(), MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            if (MessageBox.Show("Are you sure you want to delete this Testing Area?", "Delete Testing Area", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteTestingArea(GetSelectedTestingArea());
                    MdiParentForm.ShowStatusBarInfo("Testing Area was deleted successfully.");
                    DataRepository.CloseSession();
                    _selectedTestAreaId = 0;
                    PopTestingAreas();
                    MdiParentForm.BuildNavigationMenu();
                    return true;
                }
                catch (Exception ex)
                {
                    DataRepository.CloseSession();
                    new FrmShowError(new ExceptionStatus() {ex=ex, message="Sorry, you could not delete this Testing Area." }).ShowDialog();
                }
            }

            return false;
        }
    }
}
