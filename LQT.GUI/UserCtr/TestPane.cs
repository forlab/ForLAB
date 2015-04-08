using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class TestPane : BaseUserControl
    {
        public event EventHandler OnDataUsageEdit;

        //public event EventHandler CreateOrEditTest;
        private bool _enableCtr;
        private Test _test;

        public TestPane(Test test)
            : this(test, false)
        {
        }

        public TestPane(Test test, bool enableCtr)
        {
            this._test = test;
            this._enableCtr = enableCtr;
            InitializeComponent();
            listView1.AddNoneEditableColumn(0);
            listView1.AddNoneEditableColumn(1);
            listView1.AddNoneEditableColumn(3);
            listView1.OnSubitemTextChanged += new EventHandler(listView1_OnSubitemTextChanged);
            SetControlState();

            popTestType();
            popTestingDuration();
            popProductUsedIn();

            PopTestingAreas();
            PopTestingGroup();
            PopInstrument();
            PopProduct();
        

            BindTest();
        }

        

        void listView1_OnSubitemTextChanged(object sender, EventArgs e)
        {
            ListViewItem li = (ListViewItem)sender;
            int id = (int)li.Tag;
            ProductUsage fp;
            if (id <= 0)
                fp = _test.ProductUsages[li.Index];
            else
                fp = _test.GetProductUsage(id);

            try
            {
                decimal rate = decimal.Parse(li.SubItems[2].Text);
                fp.Rate = rate;
            }
            catch
            {
                li.SubItems[2].Text = fp.Rate.ToString();
            }

            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this,new EventArgs());
            }
        }

        private void SetControlState()
        {
            this.txtTestname.Enabled = _enableCtr;
            this.comTestarea.Enabled = _enableCtr;
            this.comGroup.Enabled = _enableCtr;
            this.comInstrument.Enabled = _enableCtr;
            this.comProduct.Enabled = _enableCtr;
            this.listView1.Enabled = _enableCtr;
            this.comTestingDuration.Enabled = _enableCtr;
            this.comTestType.Enabled = _enableCtr;
            this.comProductUsedIn.Enabled = _enableCtr;
        }

        public bool ShowTestingDuration
        {
            set
            {
                lbltestingduration.Visible = value;
                comTestingDuration.Visible = value;
            }
        }

        private void popTestType()
        {
              comTestType.DataSource = LqtUtil.EnumToArray<TestTypeEnum>();
        }

        private void popTestingDuration()
        {
              comTestingDuration.DataSource = LqtUtil.EnumToArray<TestingDurationEnum>();
        }
        private void popProductUsedIn()
        {
            comProductUsedIn.DataSource = LqtUtil.EnumToArray<CollectionSupplieAppliedToEnum>();
        }

        private void PopTestingAreas()
        {
            comTestarea.DataSource = DataRepository.GetAllTestingArea();

            if (comTestarea.Items.Count > 0)
                comTestarea.SelectedIndex = 0;
            else
            {
                OnDisableSaveButton();
            }
        }

        private void PopTestingGroup()
        {
            TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
           
            comGroup.DataSource = ta.TestingGroups;
            //comGroup.DisplayMember = "GroupName";
            //comGroup.ValueMember = "Id";

            if (comGroup.Items.Count > 0)
                OnEnableSaveButton();
            else
                OnDisableSaveButton();
        }

        
        public override LQTUserMessage SaveOrUpdateObject()
        {
            if (txtTestname.Text == "")
                throw new LQTUserException("Test name must not be empty.");
            else if (
                _test.Id <= 0 &&
                DataRepository.GetTestByNameAndTestArea(txtTestname.Text.Trim(), LqtUtil.GetComboBoxValue<TestingArea>(comTestarea).Id) != null)
                throw new LQTUserException("The Test Name already exists.");

            this._test.TestName = this.txtTestname.Text;
            if (_test.TestingArea == null || _test.TestingGroup == null)
            {
                _test.TestingArea = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
                _test.TestingGroup = LqtUtil.GetComboBoxValue<TestingGroup>(comGroup);
            }


            

            this._test.TestType = comTestType.SelectedValue.ToString();
            
            if (comTestType.SelectedValue.ToString()==TestTypeEnum.ControlTest.ToString())
            {
                this._test.TestingDuration = comTestingDuration.SelectedValue.ToString();
            }
            else
            {
                this._test.TestingDuration = null;
            }

            DataRepository.SaveOrUpdateTest(_test);
            if (!butAdd.Enabled)
                butAdd.Enabled = true;
            return new LQTUserMessage("Test was saved or updated successfully.");
        }

        public void RebindTest(Test test)
        {
            this._test = test;

            BindTest();
            
        }

        private void BindTest()
        {
            if (_test.TestingArea != null)
            {
                comTestarea.SelectedValue = _test.TestingArea.Id;
                comTestarea.Enabled = false;
                
                if (_test.TestingGroup != null)
                {
                    PopTestingGroup();

                    comGroup.SelectedValue = _test.TestingGroup.Id;
                    comGroup.Enabled = false;
                }
               
            }

            if (_test.Id > 0)
            {
                this.txtTestname.Text = _test.TestName;
                if (_test.TestType == TestTypeEnum.ControlTest.ToString())
                {
                    ShowTestingDuration = true;
                }
                else
                {
                    ShowTestingDuration = false;
                }
                comTestType.Text = _test.TestType;
                comTestingDuration.Text = _test.TestingDuration;

                comTestType.Enabled = false;
                comTestingDuration.Enabled = false;

                BindProductUsage();
                butAdd.Enabled = _enableCtr;
            }
        }
    
        private void PopInstrument()
        {
            TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
            if (ta != null)
                comInstrument.DataSource = DataRepository.GetListOfInstrumentByTestingArea(ta.Id);
            
        }

        private void PopProduct()
        {
            comProduct.DataSource = DataRepository.GetAllProduct();
        }

        private void BindProductUsage()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (ProductUsage r in _test.ProductUsages)
            {
                ListViewItem li = new ListViewItem(r.Instrument.InstrumentName) { Tag = r.Id };
                li.SubItems.Add(r.Product.ProductName.ToString());
                li.SubItems.Add(r.Rate.ToString());
                li.SubItems.Add(r.ProductUsedIn);
                listView1.Items.Add(li);
            }

            listView1.EndUpdate();

        }

        private void comTestarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopTestingGroup();
            PopInstrument();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Instrument ins = LqtUtil.GetComboBoxValue<Instrument>(comInstrument);
            if (ins != null)
            {
                MasterProduct pro = LqtUtil.GetComboBoxValue<MasterProduct>(comProduct);
                if (pro != null)
                {
                    if (!_test.IsExsistProductUsage(ins.Id, pro.Id))
                    {
                        ProductUsage pu = new ProductUsage();
                        pu.Test = _test;
                        pu.Instrument = ins;
                        pu.Product = pro;
                        pu.Rate = 1;
                        pu.ProductUsedIn = comProductUsedIn.SelectedValue.ToString();
                        _test.ProductUsages.Add(pu);

                        BindProductUsage();
                        if (OnDataUsageEdit != null)
                        {
                            OnDataUsageEdit(this, new EventArgs());
                        }
                    }
                }
            }
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure, do you want to remove it?", "Product Usage", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                int id = (int)listView1.SelectedItems[0].Tag;

                ProductUsage pu;
                if (id > 0)
                    pu = _test.GetProductUsage(id);
                else
                    pu = _test.ProductUsages[listView1.SelectedItems[0].Index];

                _test.ProductUsages.Remove(pu);

                BindProductUsage();
                if (OnDataUsageEdit != null)
                {
                    OnDataUsageEdit(this, new EventArgs());
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                butRemove.Enabled = true;
            }
            else
                butRemove.Enabled = false;
        }

        private void comTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comTestType.Text == TestTypeEnum.ControlTest.ToString())
            {
                ShowTestingDuration = true;
            }
            else
            {
                ShowTestingDuration = false;
            }
        }

    }
}
