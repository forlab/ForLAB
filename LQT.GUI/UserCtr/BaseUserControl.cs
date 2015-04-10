
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
using System.Windows.Forms;

using LQT.Core.Util;

namespace LQT.GUI.UserCtr
{
    public partial class BaseUserControl :System.Windows.Forms.UserControl
    {
        //public event EventHandler SaveOrUpdateCompleted;
        public event EventHandler DisableSaveButton;
        public event EventHandler EnableSaveButton;
        public event EventHandler OnSelectedItemChanged;
        //public event EventHandler OnDoubleClick;

        private LqtMainWindowForm _mdiparent;

        public BaseUserControl()
        {
            InitializeComponent();
        }
                
        public LqtMainWindowForm MdiParentForm
        {
            get { return _mdiparent; }
            set { _mdiparent = value; }
        }

        public virtual void OnDisableSaveButton()
        {
            if (DisableSaveButton != null)
            {
                DisableSaveButton(this, new EventArgs());
            }
        }

        public virtual void OnEnableSaveButton()
        {
            if (EnableSaveButton != null)
            {
                EnableSaveButton(this, new EventArgs());
            }
        }
        public virtual LQTUserMessage  SaveOrUpdateObject()
        {
            return new LQTUserMessage(string.Empty);
        }
                
        public virtual string GetControlTitle
        {
            get { return ""; }
        }

        public virtual void ReloadUserCtrContents()
        {

        }

        public void SelectedItemChanged(ListView lv)
        {
            if (OnSelectedItemChanged != null)
            {
                OnSelectedItemChanged(lv, new EventArgs());
            }
        }

        public void FillChart(UserControl uc)
        {
            //if (sender is UserControl)
            //{
            //OnDoubleClick(uc, new EventArgs());
            //}
         }

       

        public virtual bool DeleteSelectedItem()
        {
            return false;
        }

        public virtual void EditSelectedItem()
        {

        }

        public void ShowErrorMessage(string msg, string title)
        {
            MessageBox.Show(msg, title , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public int GetQuarter(DateTime d)
        {
            return LqtUtil.GetQuarter(d);
        }
    }
}
