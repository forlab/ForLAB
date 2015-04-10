
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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LQT.Core.Util;
using LQT.GUI.Reports;

namespace LQT.GUI.UserCtr
{
    public partial class ListReport : UserControl
    {
       private string rootDirectoryPath;

       public ListReport()
        {
            InitializeComponent();
            rootDirectoryPath = ReportPath;
        }

        private string ReportPath
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports"); }
        }

        private void ListReport_Load(object sender, EventArgs e)
        {
            if (ShowFolders())
            {
                ShowFiles(new DirectoryInfo(rootDirectoryPath));
            }
        }
        #region GUI Methods

        private bool ShowFolders()
        {
            var rootDirectoryInfo = new DirectoryInfo(rootDirectoryPath);

            if (!rootDirectoryInfo.Exists)
            {
                MessageBox.Show("DIRECTORY_NOT_FOUND");
                return false;
            }

            return true;
        }

        private void ShowFiles(DirectoryInfo selectedDirectory)
        {
            lvFiles.BeginUpdate();
            lvFiles.Clear();

            imageListReports.Images.Clear();
            string iconoPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Reports\Reports.Icono");
            string deflt = Path.Combine(Path.Combine(rootDirectoryPath, "Reports.Icono"), "Default.png");
            if (File.Exists(deflt)) imageListReports.Images.Add("default", Image.FromFile(deflt));

            foreach (FileInfo file in selectedDirectory.GetFiles("*.rpt"))
            {
                string imageKey = Path.GetFileNameWithoutExtension(file.Name);
                string label =  file.Name;

                string image = Path.Combine(iconoPath, imageKey + ".png");
                if (File.Exists(image))
                {
                    imageListReports.Images.Add(imageKey, Image.FromFile(image));
                }
                else
                {
                    imageKey = "default";
                }
                var item = new ListViewItem(label, imageKey) { Tag = file };

                lvFiles.Items.Add(item);
            }

            lvFiles.EndUpdate();
        }

        #endregion

        private static OReports _FindReport(string pFileName)
        {

            if (pFileName == "ConsumptionSummary.rpt")
                return OReports.ConsumptionSummary;
            if (pFileName == "ForecastSummary.rpt")
                return OReports.ForecastSummary;

            return OReports.Default;
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                var file = (FileInfo)lvFiles.SelectedItems[0].Tag;
                string reportLabel = lvFiles.SelectedItems[0].Text;
               ShowRpt(file, reportLabel, _FindReport(file.Name));
            }
        }

        private void ShowRpt(FileInfo pFile, string pReportLabel, OReports pReport)
        {
            var frmRL = new FrmReportLoader(pFile, pReportLabel, pReport);
            frmRL.ShowDialog();
        }

    }
}
