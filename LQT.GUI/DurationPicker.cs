
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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LQT.GUI
{
    public partial class DurationPicker : UserControl
    {
        private string[] _months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        private string[] _quarter = new string[] { "Qua1", "Qua2", "Qua3", "Qua4" };

        private bool _disableMonthcom = false;
        private bool _popQuarter = false;
        
        public bool DisableMonthCom
        {
            set 
            {
                _disableMonthcom = value;
                comMonth.Enabled = !value;
            }
        }
        
        public bool PopQuarter
        {
            set { 
                _popQuarter = value;
                if (value)
                    PopMonthOrQuarterValue();
            }
        }

        public DurationPicker()
        {
            InitializeComponent();
            populateYear();
        }

        public void populateYear()
        {
            for (int i = 2000; i <= DateTime.Now.Year + 15; i++)
            {
                comYear.Items.Add(i.ToString());
            }
           
        }

        public void PopMonthOrQuarterValue()
        {
            comMonth.Items.Clear();
            if (_popQuarter)
                comMonth.Items.AddRange(_quarter);
            else
                comMonth.Items.AddRange(_months);

        }

        public void SetDefaultDate()
        {
            if (_popQuarter)
            {
                comMonth.SelectedText = _quarter[LqtUtil.GetQuarter(DateTime.Now)-1].ToString();
                comMonth.Text = _quarter[LqtUtil.GetQuarter(DateTime.Now)-1].ToString();
            }
            else
            {
                comMonth.SelectedText = GetMonths(DateTime.Now.Month);
                comMonth.Text = GetMonths(DateTime.Now.Month);

            }

            comYear.SelectedText = DateTime.Now.Year.ToString();
            comYear.Text = DateTime.Now.Year.ToString();

            if (_disableMonthcom)
                comMonth.Items.Clear();
        }

        public void SetYearValue(int yaer)
        {
            comYear.SelectedText = yaer.ToString();
        }

        public int GetYear
        {
            get{
                if(comYear.Text!="")
                {
                return int.Parse(comYear.Text);}
                else
                {
                    return -1;
                }}
        }

        public void SetMonthOrQuaValue(string val)
        {
            comMonth.SelectedText = val;
        }

        public void SetValue(string du)
        {
            string[] s = du.Split(new char[] { '-' });

            if (s.Length == 1)
            {
                comYear.Text = du;
                comMonth.Text = "";
            }
            else if(s.Length ==2)
            { 
                comYear.Text = s[1];
                if (_popQuarter)
                    comMonth.Text = _quarter[int.Parse(s[0]) - 1];
                else
                    comMonth.Text = _months[int.Parse(s[0]) - 1];
            }
        }

        public int GetMonth
        {
            get
            {
                int m = 0;
                switch (comMonth.Text)
                {
                    case "January":
                        m = 1;
                        break;
                    case "February":
                        m = 2;
                        break;
                    case "March":
                        m = 3;
                        break;
                    case "April":
                        m = 4;
                        break;
                    case "May":
                        m = 5;
                        break;
                    case "June":
                        m = 6;
                        break;
                    case "July":
                        m = 7;
                        break;
                    case "August":
                        m = 8;
                        break;
                    case "September":
                        m = 9;
                        break;
                    case "October":
                        m = 10;
                        break;
                    case "November":
                        m = 11;
                        break;
                    case "December":
                        m = 12;
                        break;
                }
                return m;
            }
        }

        public int GetQuarter
        {
            get
            {
                int q = 0;
                switch (comMonth.Text)
                {
                    case "Qua1":
                        q = 1;
                        break;
                    case "Qua2":
                        q = 4;
                        break;
                    case "Qua3":
                        q = 7;
                        break;
                    case "Qua4":
                        q = 10;
                        break;
                }
                return q;
            }
        }

        public DateTime GetDurationDateTime()
        {
            DateTime d;

            if(!_popQuarter)
                d = new DateTime(GetYear, GetMonth, 1);
            else
                d = new DateTime(GetYear, GetQuarter, 1);

            return d;
        }

        public string GetDuration()
        {
            if (_disableMonthcom)
                return comYear.Text;

            return String.Format("{0}-{1}", comMonth.Text, comYear.Text);
        }

        public string GetMonths(int m)
        {
            
                string month="";
                switch (m)
                {
                    case 1:
                        month ="January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                    case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                }
                return month;
            
        }
    }
}
