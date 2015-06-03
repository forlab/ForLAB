
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

using System.Windows.Forms;
using LQT.Core.Util;
using LQT.Core;
using Microsoft.Reporting.WinForms;

namespace LQT.GUI.Reports
{
    public partial class FrmReportViewer : Form
    {
        #region propertys

        private FileInfo _file;
        private DataSet _dataset;
        private DataSet _dataset2;
        private DataSet _dataset3;
        private DataSet _dataset4;
        private DataSet _dataset1;
        private SortedList<string, object> _parameters;
        private List<ReportParameter> _rParam;

     

        public FileInfo File
        {
            get { return _file; }
            set { _file = value; }
        }

        public SortedList<string, object> ReportParameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion

        public FrmReportViewer()
        {
            InitializeComponent();
            _dataset = null;
        }
                
        public FrmReportViewer(FileInfo pFile, SortedList<string, object> pParameters)
        {
            InitializeComponent();
            _file = pFile;
            _parameters = pParameters;
        }

        public FrmReportViewer(FileInfo pFile, DataSet dataset,List<ReportParameter> rparam)
        {
            InitializeComponent();
            _file = pFile;
            _rParam = rparam;
            _dataset = dataset;
            
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = _file.ToString();
            reportViewer1.LocalReport.SetParameters(_rParam);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _dataset.Tables[0]));
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.LocalReport.Refresh();
          
        }
        public FrmReportViewer(FileInfo pFile, DataSet dataset,DataSet dataset2, List<ReportParameter> rparam)
        {
            InitializeComponent();
            _file = pFile;
            _rParam = rparam;
            _dataset = dataset;
            _dataset2 = dataset2;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = _file.ToString();
            reportViewer1.LocalReport.SetParameters(_rParam);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _dataset.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", _dataset2.Tables[0]));
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            reportViewer1.LocalReport.Refresh();

        }

        public FrmReportViewer(FileInfo pFile, DataSet dataset, DataSet dataset2,DataSet dataset3, List<ReportParameter> rparam)
        {
            InitializeComponent();
            _file = pFile;
            _rParam = rparam;
            _dataset = dataset;
            _dataset2 = dataset2;
            _dataset3 = dataset3;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = _file.ToString();
            reportViewer1.LocalReport.SetParameters(_rParam);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _dataset.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", _dataset2.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", _dataset3.Tables[0]));
            reportViewer1.SetDisplayMode(DisplayMode.Normal);
            reportViewer1.LocalReport.Refresh();


        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public FrmReportViewer(FileInfo pFile, DataSet dataset, DataSet dataset1, DataSet dataset2, DataSet dataset3, List<ReportParameter> rparam)
        {
            InitializeComponent();
            _file = pFile;
            _rParam = rparam;
            _dataset = dataset;
            _dataset1 = dataset1;
            _dataset2 = dataset2;
            _dataset3 = dataset3;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = _file.ToString();
            reportViewer1.LocalReport.SetParameters(_rParam);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _dataset.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", _dataset1.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", _dataset2.Tables[0]));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet4", _dataset3.Tables[0]));
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.LocalReport.Refresh();

        }

      

       
    }
}
