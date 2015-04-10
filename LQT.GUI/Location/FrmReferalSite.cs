
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Util;
using LQT.Core.Domain;

namespace LQT.GUI.Location
{
    public partial class FrmReferalSite : Form
    {
        public ForlabSite _selectedSite;
        private ForlabSite _callingSite;
        private IList<ForlabSite> _referingSites;
        private string _platform;

       public FrmReferalSite()
       {
           InitializeComponent();
           PopRegion();

       }
       public FrmReferalSite(ForlabSite callingsite,IList<ForlabSite> referingsites,string platform)
       {
           _callingSite = callingsite;
           _referingSites = referingsites;
           _platform = platform;
           InitializeComponent();
           PopRegion();
          
       }
 
        private void PopRegion()
        {
            cobRegion.DataSource = DataRepository.GetAllRegion();
            
        }

        private void PopSite(int regionId)
        {
            //IList<ForlabSite> sites = DataRepository.GetAllSiteByRegionId(regionId);//b
            IList<ForlabSite> sites=DataRepository.GetAllSiteByRegionandPlatform(regionId,_platform);//b
            if (sites.Count > 0)//b
            {
                sites.Remove(_callingSite);
                if (_referingSites != null)
                {
                    foreach (ForlabSite site in _referingSites)
                    {
                        sites.Remove(site);
                    }
                }

                cobsite.DataSource = sites;
                btnAdd.Enabled = true;
            }
            else//b
            {
                btnAdd.Enabled = false;
            }
        }

        private void cobRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int regionId = int.Parse(cobRegion.SelectedValue.ToString());
            PopSite(regionId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
           _selectedSite=LqtUtil.GetComboBoxValue<ForlabSite>(cobsite);
            Close();
        }

        public ForlabSite SelectedSite()
        {
            return _selectedSite;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cobsite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
