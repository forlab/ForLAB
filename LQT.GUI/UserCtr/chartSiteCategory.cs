
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;

namespace LQT.GUI.UserCtr
{
    public partial class chartSiteCategory : LQT.GUI.UserCtr.BaseUserControl
    {
        private IList<SiteCategory> _category;
        private IList<ForlabSite> _sites;
        public chartSiteCategory()
        {
            InitializeComponent();
        }

        private void chartSiteCategory_Load(object sender, EventArgs e)
        {
            _sites = DataRepository.GetAllSite();
            _category = DataRepository.GetListOfAllSiteCategory();

            int[] yval = new int[_category.Count];
            string[] xval = new string[_category.Count];

            int i = 0;
            foreach (SiteCategory scat in _category)
            {
                //string catname="Other";
               // if(scat.CategoryName!=
                xval[i] = scat.CategoryName;
                int count=0;
                foreach (ForlabSite site in _sites)
                {
                    if (site.SiteCategory != null)
                    {
                        if (scat.Id == site.SiteCategory.Id)
                            count++;
                    }
                }
                yval[i] = count;
                i++;
            }


          //  Chart1.Series["Series 1"]["PieLabelStyle"] = "OutSide";
            Chart1.Series["Series 1"].Points.DataBindXY(xval, yval);

            


        }
    }
}
