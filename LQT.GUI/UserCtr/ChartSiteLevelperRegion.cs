
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
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
    public partial class ChartSiteLevelperRegion : LQT.GUI.UserCtr.BaseUserControl
    {
        private IList<ForlabRegion> _regions;
        private IList<ForlabSite> _sites;
        List<string> _siteLevel = new List<string>();

        public ChartSiteLevelperRegion()
        {
            InitializeComponent();
        }
        private void PopulateSiteLevel()
        {
            string[] sitelevel = Enum.GetNames(typeof(SiteLevelEnum));
            for (int i = 0; i < sitelevel.Length; i++)
            {
                _siteLevel.Add(sitelevel[i].Replace('_', ' '));
            }

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //No of sites per region
            PopulateSiteLevel();
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = true; 
            chart1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
            _regions = DataRepository.GetAllRegion();
            _sites = DataRepository.GetAllSite();

            
             int [] sitecount=new int[_regions.Count];
           
            string [] regions=new string[_regions.Count];
           
 //
                      foreach (string slevel in _siteLevel)
                    {
                        //
                        string seriesName = slevel;
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
                                if (site.SiteLevel != null)
                                {
                                    if (slevel == site.SiteLevel)
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

     

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            FillChart(this);
        }
    }
}
