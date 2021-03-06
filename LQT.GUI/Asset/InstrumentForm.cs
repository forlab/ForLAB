
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using LQT.GUI.UserCtr;
using LQT.Core.Domain;
using LQT.Core.Util;
using LQT.Core.UserExceptions;

namespace LQT.GUI.Asset
{
    public partial class InstrumentForm : Form
    {
        private Instrument _instrument;
        // private InstrumentPane _rPane;
        private Form _mdiparent;

        private bool _enableCtr;

        public InstrumentForm(Instrument inst, Form mdiparent)
        {
            this._instrument = inst;
            this._mdiparent = mdiparent;

            InitializeComponent();

            lqtToolStrip1.SaveAndCloseClick += new EventHandler(lqtToolStrip1_SaveAndCloseClick);
            lqtToolStrip1.SaveAndNewClick += new EventHandler(lqtToolStrip1_SaveAndNewClick);

            LoadInstrumentCtr();
        }

        private void LoadInstrumentCtr()
        {
            // tableLayoutPanel2.Controls.Clear();//b
            //_rPane = new InstrumentPane(_instrument, true);
            //_rPane.Dock = DockStyle.Fill;
            // tableLayoutPanel2.Controls.Add(_rPane);//b

            _enableCtr = true;
            SetControlState();
            PopTestingAreas();
            BindInstrument();
        }

        void lqtToolStrip1_SaveAndNewClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                DataRepository.CloseSession();

                TestingArea ta = _instrument.TestingArea;
                _instrument = new Instrument();
                _instrument.TestingArea = ta;

                LoadInstrumentCtr();
                //if (_instrument.TestingArea != null)//b
                //{
                //    comTestarea.SelectedValue = _instrument.TestingArea.Id;
                //}
                comTestarea.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        void lqtToolStrip1_SaveAndCloseClick(object sender, EventArgs e)
        {
            try
            {
                LQTUserMessage msg = SaveOrUpdateObject();
                ((LqtMainWindowForm)_mdiparent).ShowStatusBarInfo(msg.Message, true);
                DataRepository.CloseSession();
                this.Close();
            }
            catch (Exception ex)
            {
                new FrmShowError(CustomExceptionHandler.ShowExceptionText(ex)).ShowDialog();
            }
        }

        private void SetControlState()
        {
            this.txtName.Enabled = _enableCtr;
            this.txtMaxput.Enabled = _enableCtr;
            this.comTestarea.Enabled = _enableCtr;
            this.txtdailyctrltest.Enabled = _enableCtr;
            this.txtnooftestBctrl.Enabled = _enableCtr;
            this.txtweekly.Enabled = _enableCtr;
            this.txtmonthly.Enabled = _enableCtr;
            this.txtquarterly.Enabled = _enableCtr;

            this.txtName.Text = "";
            this.txtMaxput.Text = "0";
            this.txtdailyctrltest.Text = "0";
            this.txtnooftestBctrl.Text = "0";
            this.txtweekly.Text = "0";
            this.txtmonthly.Text = "0";
            this.txtquarterly.Text = "0";
        }

        private void PopTestingAreas()
        {
            //comTestarea.Items.Clear();
            //foreach (TestingArea t in DataRepository.GetAllTestingArea())
            //{
            //    comTestarea.Items.Add(t);
            //}
            //// comTestarea.DataSource = DataRepository.GetAllTestingArea();           
            //comTestarea.Items.Insert(0, "--Select Here--");
            //comTestarea.SelectedIndex = 0;
            comTestarea.DataSource = DataRepository.GetAllTestingArea();
            comTestarea.SelectedIndex = -1;

        }
        private void BindInstrument()
        {
            if (_instrument.Id > 0)
            {
                if (_instrument.TestingArea != null)
                {
                    comTestarea.Text = _instrument.TestingArea.AreaName;
                    comTestarea.Enabled = false;
                }

                this.txtName.Text = _instrument.InstrumentName;
                this.txtMaxput.Text = _instrument.MaxThroughPut.ToString();
                this.txtdailyctrltest.Text = _instrument.DailyCtrlTest.ToString();
                this.txtnooftestBctrl.Text = _instrument.MaxTestBeforeCtrlTest.ToString();

                this.txtweekly.Text = _instrument.WeeklyCtrlTest.ToString();
                this.txtmonthly.Text = _instrument.MonthlyCtrlTest.ToString();
                this.txtquarterly.Text = _instrument.QuarterlyCtrlTest.ToString();

            }
        }
        public LQTUserMessage SaveOrUpdateObject()
        {
            if (txtName.Text.Trim() == string.Empty)
                throw new LQTUserException("Instrument name can not be empty.");
            else if (DataRepository.GetInstrumentByName(txtName.Text.Trim()) != null &&
                _instrument.Id <= 0)
                throw new LQTUserException("The Instrument Name already exists.");

            if (comTestarea.SelectedIndex < 0)
                throw new LQTUserException("Testing Area can not be empty.");

            if (txtMaxput.Text.Trim() == string.Empty)
                throw new LQTUserException("Max. Through Put can not be empty.");

            if (int.Parse(this.txtMaxput.Text) <= 0)
                throw new LQTUserException("Max. Through Put should be greater than 0.");

            //TestingArea ta = DataRepository.GetTestingAreaByName(comTestarea.Text);// LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
            //this._instrument.TestingArea = ta;
            if (_instrument.TestingArea == null)
            {
                TestingArea ta = LqtUtil.GetComboBoxValue<TestingArea>(comTestarea);
                this._instrument.TestingArea = ta;
            }


            _instrument.InstrumentName = this.txtName.Text.Trim();
            _instrument.MaxThroughPut = int.Parse(this.txtMaxput.Text);

            if (txtdailyctrltest.Text.Trim() == string.Empty)
                _instrument.DailyCtrlTest = 0;
            else
                _instrument.DailyCtrlTest = int.Parse(this.txtdailyctrltest.Text);



            if (txtnooftestBctrl.Text.Trim() == string.Empty)
                _instrument.MaxTestBeforeCtrlTest = 0;
            else
                _instrument.MaxTestBeforeCtrlTest = int.Parse(this.txtnooftestBctrl.Text);

            if (txtweekly.Text.Trim() == string.Empty)
                _instrument.WeeklyCtrlTest = 0;
            else
                _instrument.WeeklyCtrlTest = int.Parse(this.txtweekly.Text);

            if (txtmonthly.Text.Trim() == string.Empty)
                _instrument.MonthlyCtrlTest = 0;
            else
                _instrument.MonthlyCtrlTest = int.Parse(this.txtmonthly.Text);

            if (txtquarterly.Text.Trim() == string.Empty)
                _instrument.QuarterlyCtrlTest = 0;
            else
                _instrument.QuarterlyCtrlTest = int.Parse(this.txtquarterly.Text);


            DataRepository.SaveOrUpdateInstrument(_instrument);

            return new LQTUserMessage("Instrument was saved or updated successfully.");
        }
        public void RebindInstrument(Instrument inst)
        {
            this._instrument = inst;
            BindInstrument();
        }
        private void txtMaxput_KeyPress(object sender, KeyPressEventArgs e)
        {
            int x = e.KeyChar;

            if ((x >= 48 && x <= 57) || (x == 8))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }


    }
}
