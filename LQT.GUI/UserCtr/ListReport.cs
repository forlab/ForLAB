
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
