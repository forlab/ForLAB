
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
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
