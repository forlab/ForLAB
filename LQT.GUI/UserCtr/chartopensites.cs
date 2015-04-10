
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
using System.Windows.Forms.DataVisualization.Charting;

namespace LQT.GUI.UserCtr
{
    public partial class chartopensites : LQT.GUI.UserCtr.BaseUserControl
    {
        private IList<ForlabRegion> _regions;
        private IList<SiteCategory> _category;
        private IList<ForlabSite> _sites;

        public chartopensites()
        {
            InitializeComponent();
        }

        private void chartopensites_Load(object sender, EventArgs e)
        {
            //No of sites per region
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = true;
            chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
            _regions = DataRepository.GetAllRegion();
            _sites = DataRepository.GetAllSite();
            _category = DataRepository.GetListOfAllSiteCategory();

            //
            for (int j=0;j<2;j++)
            {
                //
                 string seriesName="";
                if(j==0)
                   seriesName = "Open";
                else
                   seriesName = "Closed";

                chart1.Series.Add(seriesName);
                chart1.Series[seriesName].ChartType = SeriesChartType.StackedColumn;
                chart1.Series[seriesName].BorderWidth = 2;
                chart1.Series[seriesName].ShadowOffset = 2;
                chart1.Series[seriesName]["PointWidth"] = "0.4";
                //chart1.Series[seriesName].IsValueShownAsLabel = true;

                for (int i = 0; i < _regions.Count; i++)
                {

                    int count = 0;
                    foreach (ForlabSite site in _regions[i].Sites)
                    {
                        if (j == 0)
                        {
                            if (site.SiteStatuses!=null)
                                if (site.SiteStatuses.Count >0)
                                     if (site.SiteStatuses[site.SiteStatuses.Count-1].OpenedFrom!=null && site.SiteStatuses[site.SiteStatuses.Count-1].ClosedOn==null)
                                         count++;
                        }
                        else
                        {
                            if (site.SiteStatuses != null)
                                if (site.SiteStatuses.Count > 0)
                                {
                                    if (site.SiteStatuses[site.SiteStatuses.Count - 1].ClosedOn != null)
                                        count++;
                                }
                                else
                                    count++;
                            
                            

                        }
                    }
                    string columnName = _regions[i].RegionName;
                    int YVal = (int)count;

                    chart1.Series[seriesName].Points.AddXY(columnName, YVal);


                }
                //
            }
            //
        }
    }
}
