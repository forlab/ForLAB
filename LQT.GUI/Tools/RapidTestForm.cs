
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI), U.S. Agency for International Development (USAID) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
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

namespace LQT.GUI.Tools
{
    public partial class RapidTestForm : Form
    {
        private IList<RapidTestSpec> _scrtest;
        private IList<RapidTestSpec> _contest;
        private IList<RapidTestSpec> _tietest;
        private bool _edited = false;
        private ForlabParameter _paramNegative;
        private ForlabParameter _paramPositive;
        private ForlabParameter _paramDiscordant;

        public RapidTestForm()
        {
            InitializeComponent();

            lsvSerial.AddNoneEditableColumn(0);
            lsvSerial.AddNoneEditableColumn(3);
            lsvSerial.AddNoneEditableColumn(4);
            lsvSerial.SubitemTextChanged +=new EventHandler<SubitemTextEventArgs>(lsvSerial_SubitemTextChanged);

            lsvParallel.AddNoneEditableColumn(0);
            lsvParallel.AddNoneEditableColumn(3);
            lsvParallel.AddNoneEditableColumn(4);
            lsvParallel.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lsvParallel_SubitemTextChanged);

            PopProductToComboBox(comSrapid1, TestingSpecificationGroup.Screening);
            PopProductToComboBox(comSrapid2, TestingSpecificationGroup.Screening);
            PopProductToComboBox(comSrapid3, TestingSpecificationGroup.Screening);

            PopProductToComboBox(comSCrapid1, TestingSpecificationGroup.Confirmatory);
            PopProductToComboBox(comSCrapid2, TestingSpecificationGroup.Confirmatory);
            PopProductToComboBox(comSCrapid3, TestingSpecificationGroup.Confirmatory);

            PopProductToComboBox(comSTrapid1, TestingSpecificationGroup.Tie_Breaker);
            PopProductToComboBox(comSTrapid2, TestingSpecificationGroup.Tie_Breaker);
            PopProductToComboBox(comSTrapid3, TestingSpecificationGroup.Tie_Breaker);

            BindRapidTests();
            BindSerialRapidTest();
            BindParallelRapidTest();

            _paramNegative = DataRepository.GetForlabParameterByParamName("RulesBothNegative");
            _paramPositive = DataRepository.GetForlabParameterByParamName("RulesBothPositive");
            _paramDiscordant = DataRepository.GetForlabParameterByParamName("RulesDiscordant");

            comBothnegative.Text = _paramNegative.ParmValue;
            comBothpostive.Text = _paramPositive.ParmValue;
            comDiscordant.Text = _paramDiscordant.ParmValue;
        }

        private void lsvSerial_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            RapidTestSpec rt = (RapidTestSpec)li.Tag;
            switch (e.ColumnIndex)
            {
                case 1:
                    rt.SerialTestSensitivity = double.Parse(li.SubItems[1].Text);
                    li.SubItems[3].Text = rt.SerialFalseNegative.ToString();
                    break;
                case 2:
                    rt.SerialTestSpecificity = double.Parse(li.SubItems[2].Text);
                    li.SubItems[4].Text = rt.SerialFalsePositive.ToString();
                    break;
            }
            _edited = true;
        }

        private void lsvParallel_SubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;

            RapidTestSpec rt = (RapidTestSpec)li.Tag;
            switch (e.ColumnIndex)
            {
                case 1:
                    rt.ParallelTestSensitivity = double.Parse(li.SubItems[1].Text);
                    li.SubItems[3].Text = rt.ParallelFalseNegative.ToString();
                    break;
                case 2:
                    rt.ParallelTestSpecificity = double.Parse(li.SubItems[2].Text);
                    li.SubItems[4].Text = rt.ParallelFalsePositive.ToString();
                    break;
            }
            _edited = true;
        }

        private void BindRapidTests()
        {
            _scrtest = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Screening.ToString());

            if (_scrtest.Count == 0)
            {
                for (int i = 1; i <= 3; i++)
                {
                    RapidTestSpec r = new RapidTestSpec();
                    r.ProductOrder = i;
                    r.TestGroup = TestingSpecificationGroup.Screening.ToString();
                    _scrtest.Add(r);
                }
            }
            else
            {
                foreach (RapidTestSpec r in _scrtest)
                {
                    if (r.ProductOrder == 1 && r.Product != null)
                    {
                        comSrapid1.Text = r.Product.ProductName;
                    }
                    else if (r.ProductOrder == 2 && r.Product != null)
                    {
                        comSrapid2.Text = r.Product.ProductName;
                    }
                    else if (r.ProductOrder == 3 && r.Product != null)
                    {
                        comSrapid3.Text = r.Product.ProductName;
                    }
                }
            }
            _contest = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Confirmatory.ToString());

            if (_contest.Count == 0)
            {
                for (int i = 1; i <= 3; i++)
                {
                    RapidTestSpec r = new RapidTestSpec();
                    r.ProductOrder = i;
                    r.TestGroup = TestingSpecificationGroup.Confirmatory.ToString();
                    _contest.Add(r);
                }
            }
            else
            {
                foreach (RapidTestSpec r in _contest)
                {
                    if (r.ProductOrder == 1 && r.Product != null)
                    {
                        comSCrapid1.Text = r.Product.ProductName;
                    }
                    if (r.ProductOrder == 2 && r.Product != null)
                    {
                        comSCrapid2.Text = r.Product.ProductName;
                    }
                    if (r.ProductOrder == 3 && r.Product != null)
                    {
                        comSCrapid3.Text = r.Product.ProductName;
                    }
                }
            }

            _tietest = DataRepository.GetRapidTestSpecByTestGroup(TestingSpecificationGroup.Tie_Breaker.ToString());
            if (_tietest.Count == 0)
            {
                for (int i = 1; i <= 3; i++)
                {
                    RapidTestSpec r = new RapidTestSpec();
                    r.ProductOrder = i;
                    r.TestGroup = TestingSpecificationGroup.Tie_Breaker.ToString();
                    _tietest.Add(r);
                }
            }
            else
            {
                foreach (RapidTestSpec r in _tietest)
                {
                    if (r.ProductOrder == 1 && r.Product != null)
                    {
                        comSTrapid1.Text = r.Product.ProductName;
                    }
                    else if (r.ProductOrder == 2 && r.Product != null)
                    {
                        comSTrapid2.Text = r.Product.ProductName;
                    }
                    else if (r.ProductOrder == 3 && r.Product != null)
                    {
                        comSTrapid3.Text = r.Product.ProductName;
                    }
                }
            }
        }

        private void PopProductToComboBox(ComboBox com, TestingSpecificationGroup testgroup)
        {
            IList<MasterProduct> list = DataRepository.GetAllProductByClassOfTest(ClassOfMorbidityTestEnum.RapidTest.ToString(), testgroup.ToString());
            list.Insert(0, new MasterProduct() { ProductName = "---NONE---" });

            com.DisplayMember = "ProductName";
            com.ValueMember = "Id";
            com.DataSource = list;
           com.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region screeining--------------------------------
            if (comSrapid1.Text != "---NONE---")
            {
                _scrtest[0].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSrapid1);                
            }
            else
            {
                _scrtest[0].Product = null;
            }

            if (comSrapid2.Text != "---NONE---")
            {
                _scrtest[1].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSrapid2);
            }
            else
            {
                _scrtest[1].Product = null;
            }

            if (comSrapid3.Text != "---NONE---")
            {
                _scrtest[2].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSrapid3);
            }
            else
            {
                _scrtest[2].Product = null;
            }
            
            #endregion

            #region Confermatory------------------------
            if (comSCrapid1.Text != "---NONE---")
            {
                _contest[0].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSCrapid1);
            }
            else
            {
                _contest[0].Product = null;
            }

            if (comSCrapid2.Text != "---NONE---")
            {
                _contest[1].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSCrapid2);
            }
            else
            {
                _contest[1].Product = null;
            }

            if (comSCrapid3.Text != "---NONE---")
            {
                _contest[2].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSCrapid3);
            }
            else
            {
                _contest[2].Product = null;
            }
            #endregion

            #region tie-breaker--------------------------------
            if (comSTrapid1.Text != "---NONE---")
            {
                _tietest[0].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSTrapid1);
            }
            else
            {
                _tietest[0].Product = null;
            }

            if (comSTrapid2.Text != "---NONE---")
            {
                _tietest[1].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSTrapid2);
            }
            else
            {
                _tietest[1].Product = null;
            }

            if (comSTrapid3.Text != "---NONE---")
            {
                _tietest[2].Product = LqtUtil.GetComboBoxValue<MasterProduct>(comSTrapid3);
            }
            else
            {
                _tietest[2].Product = null;
            }

            #endregion

            SaveRapidTests();

            BindSerialRapidTest();
            BindParallelRapidTest();
        }

        private void BindSerialRapidTest()
        {
            lsvSerial.Items.Clear();
            lsvSerial.BeginUpdate();
            ListViewGroup group = new ListViewGroup("Screening");
            lsvSerial.Groups.Add(group);
            for (int i = 0; i <= 2; i++)
            {
                string pname = _scrtest[i].Product != null ? _scrtest[i].Product.ProductName : "";
                ListViewItem li = new ListViewItem(pname) { Tag = _scrtest[i] };

                li.SubItems.Add(_scrtest[i].SerialTestSensitivity.ToString());
                li.SubItems.Add(_scrtest[i].SerialTestSpecificity.ToString());
                li.SubItems.Add(_scrtest[i].SerialFalseNegative.ToString());
                li.SubItems.Add(_scrtest[i].SerialFalsePositive.ToString());
                li.Group = group;
                lsvSerial.Items.Add(li);
            }

            group = new ListViewGroup("Confirmatory");
            lsvSerial.Groups.Add(group);
            for (int i = 0; i <= 2; i++)
            {
                string pname = _contest[i].Product != null ? _contest[i].Product.ProductName : "";
                ListViewItem li = new ListViewItem(pname) { Tag = _contest[i] };
                li.SubItems.Add(_contest[i].SerialTestSensitivity.ToString());
                li.SubItems.Add(_contest[i].SerialTestSpecificity.ToString());
                li.SubItems.Add(_contest[i].SerialFalseNegative.ToString());
                li.SubItems.Add(_contest[i].SerialFalsePositive.ToString());
                li.Group = group;
                lsvSerial.Items.Add(li);
            }


            group = new ListViewGroup("Tie-Breaker");
            lsvSerial.Groups.Add(group);
            for (int i = 0; i <= 2; i++)
            {
                string pname = _tietest[i].Product != null ? _tietest[i].Product.ProductName : "";
                ListViewItem li = new ListViewItem(pname) { Tag = _tietest[i] };
                li.SubItems.Add(_tietest[i].SerialTestSensitivity.ToString());
                li.SubItems.Add(_tietest[i].SerialTestSpecificity.ToString());
                li.SubItems.Add(_tietest[i].SerialFalseNegative.ToString());
                li.SubItems.Add(_tietest[i].SerialFalsePositive.ToString());
                li.Group = group;
                lsvSerial.Items.Add(li);
            }
            lsvSerial.EndUpdate();
        }

        private void BindParallelRapidTest()
        {
            lsvParallel.Items.Clear();
            lsvParallel.BeginUpdate();
            ListViewGroup group = new ListViewGroup("Screening");
            lsvParallel.Groups.Add(group);
            for (int i = 0; i <= 2; i++)
            {
                string pname = _scrtest[i].Product != null ? _scrtest[i].Product.ProductName : "";
                ListViewItem pli = new ListViewItem(pname) { Tag = _scrtest[i] };

                pli.SubItems.Add(_scrtest[i].ParallelTestSensitivity.ToString());
                pli.SubItems.Add(_scrtest[i].ParallelTestSpecificity.ToString());
                pli.SubItems.Add(_scrtest[i].ParallelFalseNegative.ToString());
                pli.SubItems.Add(_scrtest[i].ParallelFalsePositive.ToString());
                pli.Group = group;
                lsvParallel.Items.Add(pli);
            }

            group = new ListViewGroup("Confirmatory");
            lsvParallel.Groups.Add(group);
            for (int i = 0; i <= 2; i++)
            {
                string pname = _contest[i].Product != null ? _contest[i].Product.ProductName : "";
                ListViewItem pli = new ListViewItem(pname) { Tag = _contest[i] };

                pli.SubItems.Add(_contest[i].ParallelTestSensitivity.ToString());
                pli.SubItems.Add(_contest[i].ParallelTestSpecificity.ToString());
                pli.SubItems.Add(_contest[i].ParallelFalseNegative.ToString());
                pli.SubItems.Add(_contest[i].ParallelFalsePositive.ToString());
                pli.Group = group;
                lsvParallel.Items.Add(pli);
            }
            
            group = new ListViewGroup("Tie-Breaker");
            lsvParallel.Groups.Add(group);
            for (int i = 0; i <= 2; i++)
            {
                string pname = _tietest[i].Product != null ? _tietest[i].Product.ProductName : "";
                ListViewItem pli = new ListViewItem(pname) { Tag = _tietest[i] };

                pli.SubItems.Add(_tietest[i].ParallelTestSensitivity.ToString());
                pli.SubItems.Add(_tietest[i].ParallelTestSpecificity.ToString());
                pli.SubItems.Add(_tietest[i].ParallelFalseNegative.ToString());
                pli.SubItems.Add(_tietest[i].ParallelFalsePositive.ToString());
                pli.Group = group;
                lsvParallel.Items.Add(pli);
            }
            lsvParallel.EndUpdate();
        }
        
        private void SaveRapidTests()
        {
            for (int i = 0; i <= 2; i++)
            {
                DataRepository.SaveOrUpdateRapidTestSpec(_scrtest[i]);
                if (_scrtest[i].Product != null && DataRepository.GetQuantifyMenuByProductId(_scrtest[i].Product.Id) == null)
                {
                    QuantifyMenu qmenu = new QuantifyMenu();
                    qmenu.ClassOfTest = ClassOfMorbidityTestEnum.RapidTest.ToString();
                    qmenu.TestType = TestTypeEnum.Test.ToString();
                    qmenu.ProductId = _scrtest[i].Product.Id;
                    qmenu.Title = "Screening - " + _scrtest[i].Product.ProductName;
                    DataRepository.SaveOrUpdateQuantifyMenu(qmenu);
                }
                DataRepository.SaveOrUpdateRapidTestSpec(_contest[i]);
                if (_contest[i].Product != null &&  DataRepository.GetQuantifyMenuByProductId(_contest[i].Product.Id) == null)
                {
                    QuantifyMenu qmenu = new QuantifyMenu();
                    qmenu.ClassOfTest = ClassOfMorbidityTestEnum.RapidTest.ToString();
                    qmenu.TestType = TestTypeEnum.Test.ToString();
                    qmenu.ProductId = _contest[i].Product.Id;
                    qmenu.Title = "Confirmatory -  " + _contest[i].Product.ProductName;
                    DataRepository.SaveOrUpdateQuantifyMenu(qmenu);
                }
                DataRepository.SaveOrUpdateRapidTestSpec(_tietest[i]);
                if (_tietest[i].Product != null && DataRepository.GetQuantifyMenuByProductId(_tietest[i].Product.Id) == null)
                {
                    QuantifyMenu qmenu = new QuantifyMenu();
                    qmenu.ClassOfTest = ClassOfMorbidityTestEnum.RapidTest.ToString();
                    qmenu.TestType = TestTypeEnum.Test.ToString();
                    qmenu.ProductId = _tietest[i].Product.Id;
                    qmenu.Title = "Tie-Breaker - " + _tietest[i].Product.ProductName;
                    DataRepository.SaveOrUpdateQuantifyMenu(qmenu);
                }
            }
            _paramNegative.ParmValue =  comBothnegative.Text;
            _paramPositive.ParmValue = comBothpostive.Text;
            _paramDiscordant.ParmValue = comDiscordant.Text;

            DataRepository.SaveOrUpdateForlabParameter(_paramNegative);
            DataRepository.SaveOrUpdateForlabParameter(_paramPositive);
            DataRepository.SaveOrUpdateForlabParameter(_paramDiscordant);
            _edited = false;
        }
        
        private void RapidTestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_edited)
            {
                System.Windows.Forms.DialogResult dr = MessageBox.Show("Do you want to save changes?", "Rapid Test", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                    SaveRapidTests();
                else if (dr == System.Windows.Forms.DialogResult.Cancel)
                    e.Cancel = true;
            }

        }

   
    }
}
