
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
