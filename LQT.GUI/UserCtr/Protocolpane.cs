using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.GUI.Testing;
using LQT.Core.UserExceptions;

namespace LQT.GUI.UserCtr
{
    public partial class Protocolpane : LQT.GUI.UserCtr.BaseUserControl
    {
        public event EventHandler CreateOrEditPanel;
        public event EventHandler OnDataUsageEdit;
        private bool _enableCtr;
        private Protocol _protocol;

       
        public Protocolpane(Protocol protocol): this(protocol, false)
        {
        }

        public Protocolpane(Protocol protocol, bool enableCtr)
        {
            this._protocol = protocol;
            this._enableCtr = enableCtr;
            InitializeComponent();
            lvsysmpDirected.AddNoneEditableColumn(0);
            lsvpanel.AddNoneEditableColumn(0);

            lvsysmpDirected.SubitemTextChanged += new EventHandler<SubitemTextEventArgs>(lvsysmpDirected_OnSubitemTextChanged);
          
            SetControlState();
            BindProtocol();
        }

        private bool ShowCommandButtons
        {
            set
            {
                butDeletepanel.Visible = value;
                butEditpanel.Visible = value;
                butNewpanel.Visible = value;
            }
        }

        private void SetControlState()
        {
            this.txtdescription.Enabled = _enableCtr;
            this.txtsymptomdirected.Enabled = _enableCtr;
            this.txttestsrepeated.Enabled = _enableCtr;
            this.ShowCommandButtons = _enableCtr;
            this.lsvpanel.Enabled = _enableCtr;
            SetSymptomDirectedTestCtrl();
        }

        public void SetSymptomDirectedTestCtrl()
        {
            if (_protocol.ProtocolTypeEnum == ClassOfMorbidityTestEnum.CD4)
            {
                txtsymptomdirected.Visible = true;
                lblsystemdirected.Visible = true;
                panel1.Enabled = false;
            }
            else
            {
                txtsymptomdirected.Text = "0";
                txtsymptomdirected.Visible = false;
                lblsystemdirected.Visible = false;
                panel1.Enabled = true;
            }
        }

        void lvsysmpDirected_OnSubitemTextChanged(object sender, SubitemTextEventArgs e)
        {
            ListViewItem li = e.ListVItem;
            LQTListViewTag tag = (LQTListViewTag)li.Tag;



            PSymptomDirectedTest sdt=new PSymptomDirectedTest();

            if (tag.Id <= 0)
                sdt = (PSymptomDirectedTest)_protocol.SymptomDirectedTests[tag.Index];
            else
                sdt = _protocol.GetSymptomDirectedTestById(tag.Id);

            try
            {
                double sdtAITAmt = double.Parse(li.SubItems[1].Text);
                if (sdtAITAmt > 0)
                    sdt.AdultInTreatmeant = sdtAITAmt;
                else
                    li.SubItems[1].Text = sdt.AdultInTreatmeant.ToString();

                double sdtPITAmt = double.Parse(li.SubItems[2].Text);
                if (sdtPITAmt > 0)
                    sdt.PediatricInTreatmeant = sdtPITAmt;
                else
                    li.SubItems[2].Text = sdt.PediatricInTreatmeant.ToString();

                double sdtAPAAmt = double.Parse(li.SubItems[3].Text);
                if (sdtAPAAmt > 0)
                    sdt.AdultPreART = sdtAPAAmt;
                else
                    li.SubItems[3].Text = sdt.AdultPreART.ToString();

                double sdtPPAAmt = double.Parse(li.SubItems[4].Text);
                if (sdtPPAAmt > 0)
                    sdt.PediatricPreART = sdtPPAAmt;
                else
                    li.SubItems[4].Text = sdt.PediatricPreART.ToString();
            }
            catch
            {
                    li.SubItems[1].Text = sdt.AdultInTreatmeant.ToString();
                    li.SubItems[2].Text = sdt.PediatricInTreatmeant.ToString();
                    li.SubItems[3].Text = sdt.AdultPreART.ToString();
                    li.SubItems[4].Text = sdt.PediatricPreART.ToString();
            }

            if (OnDataUsageEdit != null)
            {
                OnDataUsageEdit(this, new EventArgs());
            }
        }

        public override LQTUserMessage SaveOrUpdateObject()
        {
            //this._protocol.ProtocolType = (int)Enum.Parse(typeof(MorbidityPlatform), this.txtprotocolcategory.Text); 
            this._protocol.TestReapeated = txttestsrepeated.Text != "" ? double.Parse(this.txttestsrepeated.Text) : 0;
            this._protocol.SymptomDirectedAmt = txtsymptomdirected.Text != "" ? double.Parse(this.txtsymptomdirected.Text) : 0;
            this._protocol.Descritpion = txtdescription.Text;

            DataRepository.SaveOrUpdateProtocol(_protocol);

            return new LQTUserMessage("Protocol was saved or updated Successfully.");
        }

        public void RebindProtocol(Protocol P)
        {
            this._protocol = P;
            BindProtocol();
        }

        private void BindProtocol()
        {

            if (_protocol.Id > 0)
            {
                this.txtdescription.Text = _protocol.Descritpion;
                
                this.txtsymptomdirected.Text = _protocol.SymptomDirectedAmt.ToString();
                this.txttestsrepeated.Text = _protocol.TestReapeated.ToString();
                if (_enableCtr)
                {
                    this.butNewpanel.Enabled = true;
                }
            }
            else if (_enableCtr)
            {

                this.butNewpanel.Enabled = false;
            }
          
                this.txtprotocolcategory.Text = _protocol.ProtocolTypeEnum.ToString();

                DisplayPanel();
                DisplaySDT();

           
        }

        private void DisplayPanel()
        {
            lsvpanel.BeginUpdate();
            lsvpanel.Items.Clear();

            foreach (ProtocolPanel p in _protocol.ProtocolPanels)
            {
                ListViewItem listViewItem = new ListViewItem(p.PanelName)
                {
                    Tag = p.Id
                };
              

                lsvpanel.Items.Add(listViewItem);
            }
            lsvpanel.EndUpdate();
        }
        private void DisplaySDT()
        {
            lvsysmpDirected.BeginUpdate();
            lvsysmpDirected.Items.Clear();
            int index = 0;
            foreach (PSymptomDirectedTest psdt in _protocol.SymptomDirectedTests)
            {
               
                LQTListViewTag tag = new LQTListViewTag();
                tag.Id = psdt.Id;
                tag.Index = index;
                tag.GroupTitle = psdt.Test.TestName;

                ListViewItem listViewItem = new ListViewItem(psdt.Test.TestName) { Tag = tag };


                listViewItem.SubItems.Add(psdt.AdultInTreatmeant.ToString());
                listViewItem.SubItems.Add(psdt.PediatricInTreatmeant.ToString());
                listViewItem.SubItems.Add(psdt.AdultPreART.ToString());
                listViewItem.SubItems.Add(psdt.PediatricPreART.ToString());

                lvsysmpDirected.Items.Add(listViewItem);
                index++;
            }
            lvsysmpDirected.EndUpdate();
        }

        public ProtocolPanel GetSelectedProtocol()
        {
            if (lsvpanel.SelectedItems.Count == 0)
                return null;

            int pId = (int)lsvpanel.SelectedItems[0].Tag;
            return DataRepository.GetProtocolPanelById(pId);
        }

        private void butNewpanel_Click(object sender, EventArgs e)
        {
            if (CreateOrEditPanel != null)
            {
                ProtocolPanel panel = new ProtocolPanel();
                panel.Protocol = _protocol;
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(panel);
                CreateOrEditPanel(this, eArgs);
            }

            DisplayPanel();
        }

        private void butEditpanel_Click(object sender, EventArgs e)
        {
            if (CreateOrEditPanel != null)
            {
                CreateOrUpdateEventArgs eArgs = new CreateOrUpdateEventArgs(GetSelectedProtocol());
                CreateOrEditPanel(this, eArgs);
            }

            DisplayPanel();
        }

        private void butDeletepanel_Click(object sender, EventArgs e)
        {
            ProtocolPanel p = this.GetSelectedProtocol();
            if (p != null &&
                MessageBox.Show("Are you sure you want to delete this Panel?", "Delete Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataRepository.DeleteProtocolPanel(p);
                }
                catch (Exception ex)
                {
                    FrmShowError frm = new FrmShowError(new ExceptionStatus() { message = "Panel could not be deleted.", ex = ex });
                    frm.ShowDialog();
                }
            }

            DisplayPanel();
        }

        private void lsvpanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvpanel.SelectedItems.Count > 0)
            {
                this.butEditpanel.Enabled = true;
                this.butDeletepanel.Enabled = true;
            }
            else
            {
                this.butEditpanel.Enabled = false;
                this.butDeletepanel.Enabled = false;
            }
        }

       
    }
}
