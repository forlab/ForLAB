
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LQT.GUI.UserCtr
{
    public partial class LqtToolStrip : UserControl
    {
        public event EventHandler SaveAndCloseClick;
        public event EventHandler SaveAndNewClick;

        public LqtToolStrip()
        {
            InitializeComponent();
        }

        private void tsbSaveandclose_Click(object sender, EventArgs e)
        {
            if (SaveAndCloseClick != null)
            {
                SaveAndCloseClick(sender, e);
            }
        }

        private void tsbSaveandnew_Click(object sender, EventArgs e)
        {
            if (SaveAndNewClick != null)
            {
                SaveAndNewClick(sender, e);
            }
        }

        public void EnableSaveButton()
        {
            this.tsbSaveandclose.Enabled = true;
            this.tsbSaveandnew.Enabled = true;
        }

        public void DisableSaveButton()
        {
            this.tsbSaveandclose.Enabled = false;
            this.tsbSaveandnew.Enabled = false;
        }

        public void DisableSaveAndNewButton()
        {
            this.tsbSaveandnew.Enabled = false;
        }
    }
}
