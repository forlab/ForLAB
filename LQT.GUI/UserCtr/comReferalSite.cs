
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
using LQT.GUI.Location;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.UserCtr
{
    public partial class comReferalSite : UserControl
    {
        private ForlabSite _callingSite;
        private IList<ForlabSite> _referingSites;
        private string _platform;
        public comReferalSite()
        {
            InitializeComponent();
            this.Tag = 0;
            
        }

        private void btnaddrefsite_Click(object sender, EventArgs e)
        {
            FrmReferalSite frm = new FrmReferalSite(_callingSite,_referingSites,_platform);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                txtsitename.Text = frm.SelectedSite().SiteName;
                this.Tag = frm.SelectedSite().Id;
            }
        }

        public void SetValue(int Refsiteid)
        {
            ForlabSite site = DataRepository.GetSiteById(Refsiteid);
            if (site != null)
            {
                txtsitename.Text = site.SiteName;
                this.Tag = site.Id;
            }

        }

        public void SetCallingSite(ForlabSite callingSite,string platform)
        {
            _callingSite = callingSite;
            _referingSites = DataRepository.GetReferingSiteByPlatform(platform);
            //if(platform=="CD4")
            //    _platform = "FlowCytometry";
            //else
            _platform = platform;
            
        }
        public string  getValue(int Refsiteid)
        {
            ForlabSite site = DataRepository.GetSiteById(Refsiteid);
            if (site != null)
            {
                return txtsitename.Text;
            }
            else
                return null;

        }

        private void butnDelete_Click(object sender, EventArgs e)
        {
            if (txtsitename.Text != "")
            {
                DataRepository.deleteReferingSite(_callingSite.Id, _platform);
                this.Tag = 0;
                txtsitename.Text = "";
                
            }
            
        }
        
    }
}
