
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
    public enum FiliterTestByEnum
    {
        All,
        TestArea,
        TestGroup
    }

    public partial class ListTestPane : BaseUserControl
    {
        private int _selectedTestId = 0;
      
        private FiliterTestByEnum _filiterBy;
        private int _parentId;

        public ListTestPane(FiliterTestByEnum filiterby, int parentid)
        {
            this._filiterBy = filiterby;
            this._parentId = parentid;

            InitializeComponent(); 
            PopTests();
            
        }

        public override string GetControlTitle
        {
            get
            {
                return "Tests";
            }
        }

        public override void ReloadUserCtrContents()
        {
            PopTests();
        }

        private IList<Test > GetTests()
        {
            IList<Test> result = new List<Test>();
            switch(_filiterBy)
            {
                case FiliterTestByEnum.All:
                    result = DataRepository.GetAllTests();
                    break;
                case FiliterTestByEnum.TestArea:
                    result = DataRepository.GetAllTestsByAreaId(_parentId);
                    break;
                case FiliterTestByEnum.TestGroup:
                    result = DataRepository.GetAllTestsByGroupId(_parentId);
                    break;
            }

            return result;
        }
        private void PopTests()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (Test tg in GetTests())
            {
                ListViewItem li = new ListViewItem(tg.TestName) { Tag = tg.Id };
                li.SubItems.Add(tg.TestingArea.AreaName);
                li.SubItems.Add(tg.TestingGroup.GroupName);
                if (tg.Id == _selectedTestId)
                {
                    li.Selected = true;
                }
                listView1.Items.Add(li);
            }
            
            listView1.EndUpdate();

            
        }

       

        private Test GetSelectedTest()
        {
            return DataRepository.GetTestById(_selectedTestId);
        }
        private Test GetSelectedTest(int Id)
        {
            return DataRepository.GetTestById(Id);
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            //listView1.Columns[1].Width = listView1.Width - 255;
        }

        private void lbtAddnew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Test test = new Test();
            if (_filiterBy == FiliterTestByEnum.TestArea)
                test.TestingArea = DataRepository.GetTestingAreaById(_parentId);
            else if (_filiterBy == FiliterTestByEnum.TestGroup)
            {
                test.TestingGroup = DataRepository.GetTestingGroupById(_parentId);
                test.TestingArea = test.TestingGroup.TestingArea;
            }
            
            TestFrom frm = new TestFrom(test, MdiParentForm);
            frm.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                if (id != _selectedTestId)
                {
                    _selectedTestId = id;
                   
                }
            }
            SelectedItemChanged(listView1);
        }

        public override void EditSelectedItem()
        {
            TestFrom frm = new TestFrom(GetSelectedTest(), MdiParentForm);
            frm.ShowDialog();
        }

        public override bool DeleteSelectedItem()
        {
            if (MessageBox.Show("Are you sure you want to delete this Test?", "Delete Test", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int delTestCount = 0;
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    try
                    {
                        DataRepository.DeleteTest(GetSelectedTest(int.Parse(listView1.SelectedItems[i].Tag.ToString())));
                        delTestCount++;
                    }
                    catch (Exception ex)
                    {
                        DataRepository.CloseSession();
                        new FrmShowError(new ExceptionStatus() { ex = ex, message = "Sorry, you could not delete Test. " + (GetSelectedTest(int.Parse(listView1.SelectedItems[i].Tag.ToString()))).TestName }).ShowDialog();
                    }
                    //finally
                    //{
                    //    DataRepository.CloseSession();
                    //}
                }
                    MdiParentForm.ShowStatusBarInfo(delTestCount+" Test was deleted successfully.");
                    _selectedTestId = 0;
                    PopTests();
                    return true;

               
            }

            return false;
        }

       

       
    }
}
