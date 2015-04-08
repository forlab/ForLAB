
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
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
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using LQT.Core;
using LQT.Core.Util;
using LQT.Core.Domain;
using Microsoft.Samples.Windows.Forms.TaskPane;
using System.IO;
using Microsoft.Reporting.WinForms;
using LQT.GUI.Reports;
using System.Data.SqlClient;

using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace LQT.GUI.MorbidityUserCtr
{
    public partial class DashboardForm :  BaseMorbidityControl
    {

        private MorbidityForecast _forecast;
      
        private UserControl _currentUserCtr;

        private FileInfo _fileToLoad;
        private SortedList<string, object> _parameters;
        private DataSet _rDataSet;
        private bool _load = false;
        private DataSet _rDataSet2;


        public DashboardForm(MorbidityForecast forecast)
        {
            this._forecast = forecast;
           
            InitializeComponent();
            LoadDashBoard();
        }

        public override string Title
        {
            get { return "Dashboard"; }
        }

        public override MorbidityCtrEnum PriviousCtr
        {
            get
            {
                return MorbidityCtrEnum.CalculateForm;
            }
        }

        public override MorbidityCtrEnum NextCtr
        {
            get
            {
                return MorbidityCtrEnum.Nothing;
            }
        }

        public override bool EnableNextButton()
        {
            return false;
        }

        public override string Description
        {
            get
            {
                string desc = "";
                return desc;
            }
        }

    

        public void LoadDashBoard()
        {
            if(_forecast.Status!=null)
            if (_forecast.StatusEnum == ForecastStatusEnum.CLOSED)
            {
                //display report
                pnlreport.Visible = true;
                //display dashboard
                taskPane1.Visible = true;
                LoadCharts();
            }
        }

        public void LoadCharts()
        {
            this.flowLayoutPanel1.Controls.Clear();
           
            this._currentUserCtr = new chartMSupplyProcurmentForecast(_forecast.Id);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 1);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 2);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 3);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 4);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMSupplyForecast(_forecast.Id, 6);
            LoadCurrentUserCtr();

            this._currentUserCtr = new chartMPatientNo(_forecast.Id);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHIVRapidTest(_forecast.Id);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHematologyTest(_forecast.Id, 3);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMHematologyTest(_forecast.Id, 4);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMCD4Test(_forecast.Id);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMChemOtherTest(_forecast.Id, 2);
            LoadCurrentUserCtr1();

            this._currentUserCtr = new chartMChemOtherTest(_forecast.Id, 5);
            LoadCurrentUserCtr1();
        }

        private void LoadCurrentUserCtr()
        {
            //_currentUserCtr.MdiParentForm = this;
            // _currentUserCtr.Dock = DockStyle.None;
            // _currentUserCtr.Width = 404;
            //_currentUserCtr.Height = 283;
            //_currentUserCtr.OnDoubleClick += new EventHandler(_currentUserCtr_OnDoubleClick);
            this.flowLayoutPanel1.Controls.Add(_currentUserCtr);

        }

        private void LoadCurrentUserCtr1()
        {
            //_currentUserCtr.MdiParentForm = this;
            // _currentUserCtr.Dock = DockStyle.None;
            // _currentUserCtr.Width = 404;
            //_currentUserCtr.Height = 283;
            //_currentUserCtr.OnDoubleClick += new EventHandler(_currentUserCtr_OnDoubleClick);
            //this.flowLayoutPanel2.Controls.Add(_currentUserCtr);

        }

        public void closeAllFrames()
        {
            foreach (TaskFrame tf in taskPane1.TaskFrames)
            {
                tf.IsExpanded = false;
            }
        }

        private void taskPane1_FrameExpanding(object sender, TaskPaneCancelEventArgs ce)
        {
            closeAllFrames();
        }

        private void btnDisplayReport_Click(object sender, EventArgs e)
        {
            LoadReport(cboreport.SelectedIndex);
        }

        public void LoadReport(int reportId)
        {
            if (reportId == 0)//supply Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillsupplyForecastDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.MorbiditySupplyForecast)));
                _fileToLoad = filinfo;

                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 1)//supply procurement Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillsupplyprocurementDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.MorbiditySupplyProcurement)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 2)//Patinet Distribution Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillPatinetDistributionDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.PatientNumberForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 3)//Cd4 hivrapid Forecast Report
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillCD4HIVRapidDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.CD4TestNumberForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, _rDataSet2, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 4)//chemistry Other
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillchemistryOtherDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.ChemistryNumberofTestForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
            if (reportId == 5)//hematology viral
            {
                FileInfo filinfo = null;
                List<ReportParameter> param = new List<ReportParameter>();
                //ReportParameter finfo = new ReportParameter("ForecastId", "1");
                //param.Add(finfo);
                FillhematologyviralDataSet();
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.HemaandViralTestNumberForecast)));
                _fileToLoad = filinfo;
                FrmReportViewer frmRV = new FrmReportViewer(_fileToLoad, _rDataSet, param);
                frmRV.Dock = DockStyle.Fill;
                frmRV.ShowDialog();
            }
        }

        private void FillsupplyForecastDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spMorbiditySupplyForecast";
            cmd.Parameters.AddWithValue("@ForecastId", _forecast.Id);

            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spMorbiditySupplyForecast");
        }

        private void FillsupplyprocurementDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spMorbiditySupplyProcuremnetForecast";
            cmd.Parameters.AddWithValue("@ForecastId", _forecast.Id);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spMorbiditySupplyProcuremnetForecast");
        }

        private void FillPatinetDistributionDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spPatientNumberofTestforecast";
            cmd.Parameters.AddWithValue("@ForecastId", _forecast.Id);
            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spPatientNumberofTestforecast");

        }

        private void FillCD4HIVRapidDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCD4TestNumberForecast";
            cmd.Parameters.AddWithValue("@ForecastId", _forecast.Id);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spCD4TestNumberForecast");


            SqlConnection cn2 = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd2 = cn2.CreateCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "spHIVRapidTestNumberForecast";
            cmd2.Parameters.AddWithValue("@ForecastId", _forecast.Id);
            _rDataSet2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(_rDataSet2, "spHIVRapidTestNumberForecast");

        }

        private void FillchemistryOtherDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();


            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "spChemandOtherNumberofTestforecast";
            cmd.Parameters.AddWithValue("@ForecastId", _forecast.Id);


            _rDataSet = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spChemandOtherNumberofTestforecast");

        }

        private void FillhematologyviralDataSet()
        {

            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spHemaandViralNumberofTest";
            cmd.Parameters.AddWithValue("@ForecastId", _forecast.Id);
            _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(_rDataSet, "spHemaandViralNumberofTest");
        }

        private void btnAdjustsupplyproc_Click(object sender, EventArgs e)
        {

            FrmMorbiditySupplyForecastAdj f = new FrmMorbiditySupplyForecastAdj(_forecast);
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
            {
                LoadCharts();
            }
           
        }

        private void butToxml_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Specify Destination Filename";
                saveFileDialog1.FileName = String.Format("{0}.xml", _forecast.Id.ToString() + "-" + _forecast.Title + "- Morbidity");
                saveFileDialog1.Filter = "Execl files (*.xml)|*.xml";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.OverwritePrompt = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string xmlfname = saveFileDialog1.FileName;

                    if (File.Exists(xmlfname))
                        File.Delete(xmlfname);

                    DataSet summaryData = new DataSet();

                    summaryData = FillXmlExportDataSet();

                    var myData = summaryData.Tables[0].AsEnumerable().Select(r => new
                    {
                        ProductType1 = r.Field<string>("PlatformName"),//ProductType
                        ProductName1 = r.Field<string>("ProductName"),//ProductName
                        NoofProduct1 = r.Field<double>("QuantityToPurchase"),//NoofProduct decimal
                        PackQty1 = r.Field<int>("PackSize"),//PackQty 
                        Price1 = r.Field<double>("TotalCost"),//Price decimal
                       // Duration1 = r.Field<string>("SatartDate"),
                        DurationDateTime1 = r.Field<DateTime>("SatartDate"),
                        ProductID1 = r.Field<int>("ProductId")
                    }).ToList();

                    DateTime forecastStartDate = myData[0].DurationDateTime1;
                    DateTime forecastEndDate = myData[myData.Count - 1].DurationDateTime1;

                    //distnict products in the forecast
                    IList<MasterProduct> forecastProducts = new List<MasterProduct>();
                    foreach (var item in myData)
                    {

                        MasterProduct p = DataRepository.GetProductById(item.ProductID1);
                        if (!forecastProducts.Contains(p))
                            forecastProducts.Add(p);
                    }

                    //root of the schema
                    var root = new PLexport.Export_File();

                    //products in the forecast
                    PLexport.Product[] expproducts = new PLexport.Product[forecastProducts.Count];

                    //results in the forecast
                    PLexport.Record[] expresult = new PLexport.Record[myData.Count];

                    //forecast informaiton ( Header)
                    var exportHeader = new PLexport.File_Header
                    {
                        System_Name = _forecast.Id.ToString()+"-"+_forecast.Title + "- Morbidity",
                        FileType = "Forecast",
                        dtmDataExported = DateTime.Now.ToShortDateString(),
                        dtmStart = _forecast.SatartDate.ToShortDateString(),//forecastStartDate.ToShortDateString(),
                        dtmEnd = _forecast.SatartDate.ToShortDateString(),//forecastEndDate.ToShortDateString(),
                        dblDataInterval = Convert.ToSByte("1"),
                        SourceName = "ForLabLQT",
                    };

                    //load products to schema
                    int pcount = 0;
                    foreach (MasterProduct product in forecastProducts)
                    {
                        //forecast products (Products)
                        var exportProducts1 = new PLexport.Product
                        {
                            strName = product.ProductName,
                            strProductID = product.SerialNo,
                            Source = "ForLAB",
                            UserDefined = "false",
                            ProductGroup = product.ProductType.TypeName,
                            InnovatorName = ""
                        };
                        var exportbaseUOM1 = new PLexport.BaseUOM
                        {
                            LowestUnitQty = Convert.ToSByte(product.MinimumPackSize.ToString()),
                            LowestUnitMeasure = product.BasicUnit,
                            QuantificationFactor = Convert.ToSByte("1")
                        };
                        exportProducts1.BaseUOM = exportbaseUOM1;
                        expproducts[pcount] = exportProducts1;
                        pcount++;
                    }

                    //load forecast result to schema
                    int fcount = 0;
                    foreach (var item in myData)
                    {
                        MasterProduct p = DataRepository.GetProductById(item.ProductID1);
                        //forecast results  (Records)
                        var exportRecord1 = new PLexport.Record
                        {
                            strProductID = p.SerialNo,
                            dtmPeriod = item.DurationDateTime1.ToShortDateString(),
                            lngConsumption = item.PackQty1,
                            lngAdjustments = Convert.ToSByte("1")
                        };
                        expresult[fcount] = exportRecord1;
                        fcount++;
                    }

                    //add all results to the roor
                    root.File_Header = exportHeader;
                    root.Products = expproducts;
                    root.Records = expresult;



                    //serialize and export
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    var serializer = new XmlSerializer(typeof(PLexport.Export_File));
                    using (var stream = new StreamWriter(xmlfname))
                        serializer.Serialize(stream, root, ns);
                    ////

                    MessageBox.Show("Export to XML is completed Successfully.", "Export to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error unable to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataSet FillXmlExportDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spMorbiditySupplyProcuremnetForecast";

            cmd.Parameters.AddWithValue("@ForecastId", _forecast.Id);
            cmd.CommandTimeout = 300000;
           
            DataSet _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(_rDataSet, "spMorbiditySupplyProcuremnetForecast");


            return _rDataSet;
        }

    }
}
