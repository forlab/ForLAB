
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
