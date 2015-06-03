
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
using LQT.GUI.Testing;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class ListTestingGroupPane : BaseUserControl
    {
        private int _selectedTestgroupId = 0;
       

        public ListTestingGroupPane()
        {
            InitializeComponent(); 
            PopTestingGroups();
        }

        public override string GetControlTitle
        {
            get
            {
                return "Testing Groups";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopTestingGroups();
        }

        private void PopTestingGroups()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (TestingGroup tg in DataRepository.GetAllTestingGroup())
            {
                ListViewItem li = new ListViewItem(tg.GroupName) { Tag = tg.Id };
                li.SubItems.Add(tg.TestingArea.AreaName);
                if (tg.Id == _selectedTestgroupId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }
            
            listView1.EndUpdate();

           
        }

       

        private TestingGroup GetSelectedTestingGroup()
        {
            return DataRepository.GetTestingGroupById(_selectedTestgroupId);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            listView1.Columns[1].Width = listView1.Width - 255;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TestingGroupFrom frm = new TestingGroupFrom(new TestingGroup(), MdiParentForm);
            frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                if (id != _selectedTestgroupId)
                {
                    _selectedTestgroupId = id;
                   
                }
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            TestingGroupFrom frm = new TestingGroupFrom(GetSelectedTestingGroup(), MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            if (MessageBox.Show("Are you sure you want to delete this Testing Group?", "Delete Testing Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteTestingGroup(GetSelectedTestingGroup());
                    MdiParentForm.ShowStatusBarInfo("Testing Group was deleted successfully.");
                    DataRepository.CloseSession();
                    _selectedTestgroupId = 0;
                    PopTestingGroups();
                    MdiParentForm.BuildNavigationMenu();
                    return true;
                }
                catch (Exception ex)
                {
                    new FrmShowError(new ExceptionStatus() {ex=ex, message="Sorry, you could not Delete this Testing Group." }).ShowDialog();
                }
            }

            return false;
        }
    }
}
