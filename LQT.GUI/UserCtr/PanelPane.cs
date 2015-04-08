using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Location;
using LQT.Core.UserExceptions;
using System.Globalization;

namespace LQT.GUI.UserCtr
{
	public partial class PanelPane : LQT.GUI.UserCtr.BaseUserControl
	{
       
        public event EventHandler OnDataUsageEdit;
      
        private bool _enableCtr;
        private ProtocolPanel _panel;

        public PanelPane(ProtocolPanel panel)
            : this(panel, false) { }

        public PanelPane(ProtocolPanel panel, bool enableCtr)
        {
            this._panel = panel;
            this._enableCtr = enableCtr;
            InitializeComponent();
            lvTest.AddNoneEditableColumn(0);
            SetControlState();
          
            BindPanel();            
        }
        public void SetControlState()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    c.Enabled = _enableCtr;

                
            }
            lvTest.Enabled = _enableCtr;
            if (!_enableCtr)
            {
                this.lbtAddTest.Enabled = _enableCtr;
                this.lbtRemoveTest.Enabled = _enableCtr;

            }

            if (_panel.Protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.CD4)
            {
                pnlnewpatient.Visible = false;
                pnlpreexisting.Visible = false;
                pnltest.Enabled = false;
                pnlmonths.Location = new Point(129, 39);
               
            }
            else
            {
                pnlnewpatient.Visible = true;
                pnlpreexisting.Visible = true;
                pnltest.Visible = true;
            }
        }
        public void BindPanel()
        {
            if (_panel.Id > 0)
            {
                txtpanelName.Text=_panel.PanelName;

                txtAITmonth1.Text=_panel.AITMonth1.ToString();
                txtAITmonth2.Text = _panel.AITMonth2.ToString();
                txtAITmonth3.Text = _panel.AITMonth3.ToString();
                txtAITmonth4.Text = _panel.AITMonth4.ToString();
                txtAITmonth6.Text = _panel.AITMonth5.ToString();
                txtAITmonth5.Text = _panel.AITMonth6.ToString();
                txtAITmonth7.Text = _panel.AITMonth7.ToString();
                txtAITmonth8.Text = _panel.AITMonth8.ToString();
                txtAITmonth9.Text = _panel.AITMonth9.ToString();
                txtAITmonth10.Text = _panel.AITMonth10.ToString();
                txtAITmonth11.Text = _panel.AITMonth11.ToString();
                txtAITmonth12.Text = _panel.AITMonth12.ToString();
                txtAITnewpatients.Text = _panel.AITNewPatient.ToString();
                txtAITtestperyear.Text = _panel.AITTestperYear.ToString();
                txtAITpreexisting.Text = _panel.AITPreExisting.ToString();

                txtPITpreexisting.Text=_panel.PITPreExisting.ToString();
                txtPITtestperyear.Text=_panel.PITTestperYear.ToString();
                txtPITnewpatients.Text=_panel.PITNewPatient.ToString();
                txtPITmonth12.Text=_panel.PITMonth12.ToString();
                txtPITmonth11.Text = _panel.PITMonth11.ToString();
                txtPITmonth10.Text = _panel.PITMonth10.ToString();
                txtPITmonth9.Text = _panel.PITMonth9.ToString();
                txtPITmonth8.Text = _panel.PITMonth8.ToString();
                txtPITmonth7.Text = _panel.PITMonth7.ToString();
                txtPITmonth5.Text = _panel.PITMonth5.ToString();
                txtPITmonth6.Text = _panel.PITMonth6.ToString();
                txtPITmonth4.Text = _panel.PITMonth4.ToString();
                txtPITmonth3.Text = _panel.PITMonth3.ToString();
                txtPITmonth2.Text = _panel.PITMonth2.ToString();
                txtPITmonth1.Text = _panel.PITMonth1.ToString();

                txtPpARTpreexisting.Text=_panel.PPARTPreExisting.ToString();
                txtPpARTtestperyear.Text=_panel.PPARTTestperYear.ToString();
                txtPpARTnewpatient.Text=_panel.PPARTNewPatient.ToString();
                txtPpARTmonth12.Text=_panel.PPARTMonth12.ToString();
                txtPpARTmonth11.Text = _panel.PPARTMonth11.ToString();
                txtPpARTmonth10.Text = _panel.PPARTMonth10.ToString();
                txtPpARTmonth9.Text = _panel.PPARTMonth9.ToString();
                txtPpARTmonth8.Text = _panel.PPARTMonth8.ToString();
                txtPpARTmonth7.Text = _panel.PPARTMonth7.ToString();
                txtPpARTmonth5.Text = _panel.PPARTMonth5.ToString();
                txtPpARTmonth6.Text = _panel.PPARTMonth6.ToString();
                txtPpARTmonth4.Text = _panel.PPARTMonth4.ToString();
                txtPpARTmonth3.Text = _panel.PPARTMonth3.ToString();
                txtPpARTmonth2.Text = _panel.PPARTMonth2.ToString();
                txtPpARTmonth1.Text = _panel.PPARTMonth1.ToString();

                txtApARTpreexisting.Text=_panel.APARTPreExisting.ToString();
                txtApARTtestperyear.Text=_panel.APARTestperYear.ToString();
                txtApARTnewpatients.Text=_panel.APARTNewPatient.ToString();
                txtApARTmonth12.Text=_panel.APARTMonth12.ToString();
                txtApARTmonth11.Text = _panel.APARTMonth11.ToString();
                txtApARTmonth10.Text = _panel.APARTMonth10.ToString();
                txtApARTmonth9.Text = _panel.APARTMonth9.ToString();
                txtApARTmonth8.Text = _panel.APARTMonth8.ToString();
                txtApARTmonth7.Text = _panel.APARTMonth7.ToString();
                txtApARTmonth5.Text = _panel.APARTMonth5.ToString();
                txtApARTmonth6.Text = _panel.APARTMonth6.ToString();
                txtApARTmonth4.Text = _panel.APARTMonth4.ToString();
                txtApARTmonth3.Text = _panel.APARTMonth3.ToString();
                txtApARTmonth2.Text = _panel.APARTMonth2.ToString();
                txtApARTmonth1.Text = _panel.APARTMonth1.ToString();
            }
            PopPanelTests();
        }

        public void RebindPanel(ProtocolPanel panel)
        {
            this._panel = panel;
            BindPanel();
        }
        public void PopPanelTests()
        {
            lvTest.BeginUpdate();
            lvTest.Items.Clear();
            int index = 0;
            foreach (PanelTest pt in _panel.PanelPanelTests)
            {
                LQTListViewTag tag = new LQTListViewTag();
                tag.Id = pt.Id;
                tag.Index = index;
                ListViewItem li = new ListViewItem(pt.TestId.TestName) { Tag = tag };
                lvTest.Items.Add(li);
                index++;
            }
            lvTest.EndUpdate();
        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
           
            if (txtpanelName.Text.Trim() == string.Empty)
                throw new LQTUserException("Panel Name must not be empty.");


            SetPanel();

           

            DataRepository.SaveOrUpdateProtocolPanel(_panel);

            return new LQTUserMessage("Panel was saved or updated Successfully.");
        }
        public void SetPanel()
        {
            _panel.PanelName=txtpanelName.Text;

            _panel.AITMonth1 = int.Parse(txtAITmonth1.Text);
            _panel.AITMonth2=int.Parse( txtAITmonth2.Text);
            _panel.AITMonth3=int.Parse(txtAITmonth3.Text);
            _panel.AITMonth4=int.Parse( txtAITmonth4.Text);
            _panel.AITMonth5=int.Parse( txtAITmonth6.Text);
            _panel.AITMonth6=int.Parse(  txtAITmonth5.Text);
            _panel.AITMonth7=int.Parse( txtAITmonth7.Text);
            _panel.AITMonth8=int.Parse(  txtAITmonth8.Text);
            _panel.AITMonth9=int.Parse(  txtAITmonth9.Text);
            _panel.AITMonth10=int.Parse( txtAITmonth10.Text);
            _panel.AITMonth11=int.Parse( txtAITmonth11.Text);
            _panel.AITMonth12=int.Parse( txtAITmonth12.Text);
            _panel.AITNewPatient = double.Parse(txtAITnewpatients.Text);
            _panel.AITTestperYear = double.Parse(txtAITtestperyear.Text);
            _panel.AITPreExisting = double.Parse(txtAITpreexisting.Text);

            _panel.PITPreExisting = double.Parse(txtPITpreexisting.Text);
            _panel.PITTestperYear = double.Parse(txtPITtestperyear.Text);
            _panel.PITNewPatient = double.Parse(txtPITnewpatients.Text);
            _panel.PITMonth12=int.Parse(txtPITmonth12.Text);
            _panel.PITMonth11=int.Parse(txtPITmonth11.Text);
            _panel.PITMonth10=int.Parse(txtPITmonth10.Text );
            _panel.PITMonth9=int.Parse(txtPITmonth9.Text);
            _panel.PITMonth8=int.Parse(txtPITmonth8.Text);
            _panel.PITMonth7=int.Parse(txtPITmonth7.Text);
            _panel.PITMonth5=int.Parse(txtPITmonth5.Text);
            _panel.PITMonth6=int.Parse( txtPITmonth6.Text);
            _panel.PITMonth4=int.Parse(txtPITmonth4.Text);
            _panel.PITMonth3=int.Parse(txtPITmonth3.Text);
            _panel.PITMonth2=int.Parse(txtPITmonth2.Text);
            _panel.PITMonth1=int.Parse( txtPITmonth1.Text);

            _panel.PPARTPreExisting = double.Parse(txtPpARTpreexisting.Text);
            _panel.PPARTTestperYear = double.Parse(txtPpARTtestperyear.Text);
            _panel.PPARTNewPatient = double.Parse(txtPpARTnewpatient.Text);
            _panel.PPARTMonth12=int.Parse(txtPpARTmonth12.Text);
            _panel.PPARTMonth11=int.Parse(txtPpARTmonth11.Text);
            _panel.PPARTMonth10=int.Parse(txtPpARTmonth10.Text);
            _panel.PPARTMonth9=int.Parse( txtPpARTmonth9.Text);
            _panel.PPARTMonth8=int.Parse(txtPpARTmonth8.Text);
            _panel.PPARTMonth7=int.Parse(txtPpARTmonth7.Text);
            _panel.PPARTMonth5=int.Parse(txtPpARTmonth5.Text);
            _panel.PPARTMonth6=int.Parse( txtPpARTmonth6.Text);
            _panel.PPARTMonth4=int.Parse(txtPpARTmonth4.Text);
            _panel.PPARTMonth3=int.Parse( txtPpARTmonth3.Text);
            _panel.PPARTMonth2=int.Parse(txtPpARTmonth2.Text);
            _panel.PPARTMonth1=int.Parse(txtPpARTmonth1.Text);

            //txtApARTpreexisting
            _panel.APARTPreExisting = double.Parse(txtApARTpreexisting.Text);
            _panel.APARTestperYear = double.Parse(txtApARTtestperyear.Text);
            _panel.APARTNewPatient = double.Parse(txtApARTnewpatients.Text);
            _panel.APARTMonth12=int.Parse(txtApARTmonth12.Text );
            _panel.APARTMonth11=int.Parse(txtApARTmonth11.Text);
            _panel.APARTMonth10=int.Parse(txtApARTmonth10.Text);
            _panel.APARTMonth9=int.Parse(txtApARTmonth9.Text);
            _panel.APARTMonth8=int.Parse(txtApARTmonth8.Text );
            _panel.APARTMonth7=int.Parse(txtApARTmonth7.Text);
            _panel.APARTMonth5=int.Parse( txtApARTmonth5.Text);
            _panel.APARTMonth6=int.Parse(txtApARTmonth6.Text);
            _panel.APARTMonth4=int.Parse(txtApARTmonth4.Text);
            _panel.APARTMonth3=int.Parse(txtApARTmonth3.Text);
            _panel.APARTMonth2=int.Parse(txtApARTmonth2.Text);
            _panel.APARTMonth1=int.Parse(txtApARTmonth1.Text);
        }

        public bool SymptomDirectedTestAdded(Test t)
        {
            foreach (PSymptomDirectedTest pS in _panel.Protocol.SymptomDirectedTests)
            {
                if (pS.Test == t)
                    return true;
            }
            return false;
        }
        private void lbtAddTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            FrmSelectTest frm = new FrmSelectTest(_panel);
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {

                foreach (Test t in frm._selectedTest)
                {

                    PanelTest pt = new PanelTest();
                    pt.TestId = t;
                    pt.Panel = _panel;
                    _panel.PanelPanelTests.Add(pt);

                    if(!SymptomDirectedTestAdded(t))
                    {
                        PSymptomDirectedTest pSDT = new PSymptomDirectedTest();
                        pSDT.Test = t;
                        pSDT.PediatricInTreatmeant = 0;
                        pSDT.PediatricPreART = 0;
                        pSDT.Protocol = _panel.Protocol;
                        pSDT.AdultInTreatmeant = 0;
                        pSDT.AdultPreART = 0;
                        _panel.Protocol.SymptomDirectedTests.Add(pSDT);
                    }
                   

                   
                }
                PopPanelTests();
               

                //if (OnDataUsageEdit != null)
                //{
                //    OnDataUsageEdit(this, new EventArgs());
                //}
            }
        }

        private void lbtRemoveTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LQTListViewTag tag = (LQTListViewTag)lvTest.SelectedItems[0].Tag;
            PanelTest pt;
            if (tag.Id > 0)
                pt = _panel.GetPanelTestById(tag.Id);
            else
                pt = (PanelTest)_panel.PanelPanelTests[tag.Index];

            _panel.PanelPanelTests.Remove(pt);

            PopPanelTests();
           

            //if (OnDataUsageEdit != null)
            //{
            //    OnDataUsageEdit(this, new EventArgs());
            //}

        }

        private void lvTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTest.SelectedItems.Count > 0)
            {
                lbtRemoveTest.Enabled = true;
            }
            else
            {
                lbtRemoveTest.Enabled = false;
            }
        }

        private void txtAITnewpatients_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            int x = e.KeyChar;
            TextBox t = (TextBox)sender;
            int dot = t.Text.IndexOf(".");
            if ((x >= 48 && x <= 57) || (x == 8)||(x==46))
            {
                if (x==46 && dot > -1)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
                e.Handled = true;
        }

       
	}
}
