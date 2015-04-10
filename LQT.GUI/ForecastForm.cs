
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Xml;
using System.IO;
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;
using LQT.Core;
using LQT.GUI.Reports;
using LQT.GUI.UserCtr;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Reporting.WinForms;
using LQT.GUI.Quantification;
using System.Xml.Serialization;

using System.Linq;

namespace LQT.GUI
{
	public partial class ForecastForm : Form
	{
		private decimal _westage;
		private DateTime lastEntryDate;
		private decimal _scaleup;
	    private string _regressionType;
	    private bool _forecastWithoutError;
	    private string _startTime;
		private bool _doCalculations = false;
		private IList<ForecastedResult> _listFresult;
		private readonly string Checked_Image_Path = AppSettings.GetReportPath + "\\Reports.Icono\\chk_checked.png";
		private readonly string Unchecked_Image_Path = AppSettings.GetReportPath + "\\Reports.Icono\\chk_unchecked.png";
		private UserControl _currentControl;
		private ForecastInfo _forecastInfo;

		public static event EventHandler OnFResultSaved;
		public static event EventHandler OnFResultDeleted;

		private int  fid;
		private int siteorcatid;
		private bool iscost = false;


		public ForecastForm()
		{
			InitializeComponent();
            //DataUsageEnum.DATA_USAGE1.Description
            foreach (DataUsageEnum val in Enum.GetValues(typeof(DataUsageEnum)))
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = val.Description();
                item.Value = val;

                comStatus.Items.Add(item);
                
            }
                
			//comStatus.Items.AddRange(Enum.GetNames(typeof(DataUsageEnum)));
			comStatus.Items.Insert(0, "--Select Here--");
			comStatus.SelectedIndex = 0;

			comMethodologey.Items.AddRange(Enum.GetNames(typeof(MethodologyEnum)));
			comMethodologey.Items.Insert(0, "--Select Here--");
			comMethodologey.SelectedIndex = 0;

			cboRegressionType.Items.AddRange(Enum.GetNames(typeof(ForecastingMethodEnum)));
			cboRegressionType.SelectedIndex = 0;
			cboOrder.SelectedIndex = 0;

			PopForecastInfo();
			_forecastInfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);

           
		}

		private void PopForecastInfo()
		{
			if (comMethodologey.Text != "--Select Here--")
			{
                if (comStatus.Text != "--Select Here--")
                {
                    ComboboxItem sel = new ComboboxItem();
                    sel = (ComboboxItem)comStatus.Items[comStatus.SelectedIndex];

                    comForecastinfo.DataSource = DataRepository.GetForecastInfoByDatausage(comMethodologey.Text, sel.Value.ToString());
                }
                else
                    comForecastinfo.DataSource = DataRepository.GetForecastInfoByMethodology(comMethodologey.Text);
			}
			//else
				//comForecastinfo.DataSource = DataRepository.GetAllForecastInfo();
			if (comForecastinfo.Items.Count == 0)
				comForecastinfo_SelectedIndexChanged(this, new EventArgs());
		}

		private void comForecastinfo_SelectedIndexChanged(object sender, EventArgs e)
		{
			_forecastInfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
			if (_forecastInfo != null)
			{
				txtPeriod.Text = _forecastInfo.Period;
				txtSdate.Text = _forecastInfo.StartDate.ToShortDateString();
				txtExtension.Text = _forecastInfo.Extension.ToString();
				txtMethodology.Text = _forecastInfo.Methodology;
				txtDusage.Text = _forecastInfo.DataUsage;
				txtWestage.Text = _forecastInfo.Westage.ToString();
				txtAddby.Text = _forecastInfo.Scaleup.ToString();
				txtStatus.Text = _forecastInfo.Status;
				txtRegressionType.Text = _forecastInfo.Method;

				//if (fi.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
				//    txtWestage.Enabled = false;
				//else
				//    txtWestage.Enabled = true;

				if (_forecastInfo.StatusEnum != ForecastStatusEnum.OPEN)
				{
					butSummary.Enabled = true;
					butToxml.Enabled = true;
					lnkshowmapesummary.Enabled = true;
				}
				else
				{
					butSummary.Enabled = false;
					butToxml.Enabled = false;
					lnkshowmapesummary.Enabled = false;
				}
				if (cboRegressionType.FindString(_forecastInfo.Method) >= 0)
				{
					cboRegressionType.Text = _forecastInfo.Method;
					cboRegressionType.SelectedText = _forecastInfo.Method;
				}

				butForecast.Enabled = true;
			}
			else
			{
				txtPeriod.Text = "";
				txtSdate.Text = "";
				txtExtension.Text = "";
				txtMethodology.Text = "";
				txtDusage.Text = "";
				txtWestage.Text = "";
				txtAddby.Text = "";
				txtStatus.Text = "";
				txtRegressionType.Text = "";

				butSummary.Enabled = false;
				butToxml.Enabled = false;
				butForecast.Enabled = false;
				_doCalculations = false;
			}
            EnableCatInstUtilizationlink();

			BuildNavigationTree();
		}

		private void BuildNavigationTree()
		{
			
			treeViewlocation.BeginUpdate();
			treeViewlocation.Nodes.Clear();

			if (_forecastInfo != null)
			{
				if (_forecastInfo.StatusEnum != ForecastStatusEnum.OPEN)
				{
					if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
						BuildNavFromCategory(_forecastInfo);
					else
						BuildNavFromSite(_forecastInfo);

					if (_forecastInfo.StatusEnum == ForecastStatusEnum.REOPEN)
						rtbInfo.Text = "Historical data was modified after forecasting is done. So this data must be Re-forecasting  to reflect the modification on the report";
					else
						rtbInfo.Text = "";
				}
				else if (_forecastInfo.StatusEnum == ForecastStatusEnum.OPEN)
				{
					rtbInfo.Text = "Historical data is not yet forecasted.  You can forecast it by clicking on 'Do-Forecast' button.";
					_doCalculations = false;
				}
			}
			else
			{
				rtbInfo.Text = "";
			}

			treeViewlocation.EndUpdate();
			
		}

		public void BuildNavFromSite(ForecastInfo finfo)
		{   
            IList list;
            object[] row;
            if(finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
             list = DataRepository.GetUniqueFType(finfo.Id, 1);
            else
             list = DataRepository.GetUniqueFType(finfo.Id, 0);
			TreeNode all = new TreeNode("All") { Tag = finfo.Id };
			treeViewlocation.Nodes.Add(all);
            //TreeNode testarea = new TreeNode("Testing Area") { Tag = finfo.Id };//the same as all 
            //treeViewlocation.Nodes.Add(testarea);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    row = (object[])list[i];
            //    TreeNode test = new TreeNode(row[0].ToString()) { Tag =row[1]};
            //    testarea.Nodes.Add(test);
            //}
           
			foreach (ForecastSite ft in finfo.ForecastSites)
			{
				TreeNode rootNode = new TreeNode(ft.Site.SiteName) { Tag = ft.Id };
                all.Nodes.Add(rootNode);
                ////----------------------------
                //if (finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                //{

                //    foreach (MasterProduct mp in ft.GetUniqFSProduct())
                //    {
                       
                //            rootNode.Nodes.Add(new TreeNode(mp.ProductName) { Tag = mp.Id });
                //    }
           
                //}
                //else
                //{
                   
                //    foreach (Test t in ft.GetUniqTest())
                //    {
                        
                //            rootNode.Nodes.Add(new TreeNode(t.TestName) { Tag = t.Id });
                //    }
                    
                //}
			}
		}

		public void BuildNavFromCategory(ForecastInfo finfo)
		{
            IList list;
            object[] row;
            if (finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                list = DataRepository.GetUniqueFType(finfo.Id, 1);
            else
                list = DataRepository.GetUniqueFType(finfo.Id, 0);

			TreeNode all = new TreeNode("All") { Tag = finfo.Id };
			treeViewlocation.Nodes.Add(all);
            //TreeNode testarea = new TreeNode("Testing Area") { Tag = finfo.Id };//the same as all 
            //treeViewlocation.Nodes.Add(testarea);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    row = (object[])list[i];
            //    TreeNode test = new TreeNode(row[0].ToString()) { Tag = row[1] };
            //    testarea.Nodes.Add(test);
            //}

			foreach (ForecastCategory cat in finfo.ForecastCategories)
			{
				TreeNode rootNode = new TreeNode(cat.CategoryName) { Tag = cat.Id };
                all.Nodes.Add(rootNode);
                //if (finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                //{
                //    foreach (MasterProduct mp in cat.GetUniqFSProduct())
                //    {
                      
                //            rootNode.Nodes.Add(new TreeNode(mp.ProductName) { Tag = mp.Id });
                //    }
                //}
                //else
                //{
                //    foreach (Test t in cat.GetUniqFCTest())
                //    {
                //        rootNode.Nodes.Add(new TreeNode(t.TestName) { Tag = t.Id });
                //    }                        
                //}
			}

		}

		#region report and xml

		private void butSummary_Click(object sender, EventArgs e)
		{
			FileInfo filinfo;

			List<ReportParameter> param = new List<ReportParameter>();
			ReportParameter finfoparam = new ReportParameter("forecastid", _forecastInfo.Id.ToString());
			param.Add(finfoparam);
			ReportParameter siteid = new ReportParameter("siteid", "0");
			param.Add(siteid);
			ReportParameter catid = new ReportParameter("catid", "0");
			param.Add(catid);
            ReportParameter protypeid = new ReportParameter("protypeid", "0");
            param.Add(protypeid);

            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
            {
                ReportParameter testareaId = new ReportParameter("testareaId", "0");
                param.Add(testareaId);
            }

            FrmReportViewer frm = new FrmReportViewer();
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptConsumptionCostSummary)));
                 frm = new FrmReportViewer(filinfo,FillFinfoReportDataSet(), FillDetailReportDataSet(), param);
            }
            else
            {
                filinfo = new FileInfo(Path.Combine(AppSettings.GetReportPath, String.Format("{0}.rdlc", OReports.rptServiceCostSummary)));
                 frm = new FrmReportViewer(filinfo, FillReportDataSet(), FillFinfoReportDataSet(), FillDetailReportDataSet(), FillServiceDetailReportDataSet(), param);
            }

			
			frm.ShowDialog();
		}
		
        private DataSet FillFinfoReportDataSet()
		{
			SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
			SqlCommand cmd = cn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "spForecastInfo";
		   
			cmd.Parameters.AddWithValue("@fid", _forecastInfo.Id);
			DataSet _rDataSet = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(cmd);

			da.Fill(_rDataSet, "spForecastInfo");
			return _rDataSet;

		}

		private DataSet FillReportDataSet()
		{
			SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
			SqlCommand cmd = cn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
			{
				cmd.CommandText = "spConsumptionTotalSummary";
			}
			else
			{
				cmd.CommandText = "spServiceTotalSummary";
			}
			cmd.CommandTimeout = 300000;
			cmd.Parameters.AddWithValue("@forecastid", _forecastInfo.Id);
			cmd.Parameters.AddWithValue("@siteid", 0);
			cmd.Parameters.AddWithValue("@catid", 0);
			DataSet _rDataSet = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
				da.Fill(_rDataSet, "spConsumptionTotalSummary");
			else
				da.Fill(_rDataSet, "spServiceTotalSummary");

			return _rDataSet;

		}

        private DataSet FillDetailReportDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                cmd.CommandText = "spConsumptionForecastbytypeandduration";
                cmd.Parameters.AddWithValue("@protypeid", 0);
            }
            else
            {
                cmd.CommandText = "spServiceForecastTestbytypeandduration";
                cmd.Parameters.AddWithValue("@testareaId", 0);
            }
            cmd.CommandTimeout = 300000;
            cmd.Parameters.AddWithValue("@forecastid", _forecastInfo.Id);
            cmd.Parameters.AddWithValue("@siteid", 0);
            cmd.Parameters.AddWithValue("@catid", 0);
            DataSet _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                da.Fill(_rDataSet, "spConsumptionForecastbytypeandduration");
            else
                da.Fill(_rDataSet, "spServiceForecastTestbytypeandduration");

            return _rDataSet;
        }

        private DataSet FillServiceDetailReportDataSet()
        {
            SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spServiceForecastProductbytypeandduration";
  
            cmd.Parameters.AddWithValue("@protypeid", 0);
           
            cmd.CommandTimeout = 300000;
            cmd.Parameters.AddWithValue("@forecastid", _forecastInfo.Id);
            cmd.Parameters.AddWithValue("@siteid", 0);
            cmd.Parameters.AddWithValue("@catid", 0);
            DataSet _rDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
                da.Fill(_rDataSet, "spServiceForecastProductbytypeandduration");
            

            return _rDataSet;
        }

		private DataSet FillXmlExportDataSet()
		{
			SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
			SqlCommand cmd = cn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
				cmd.CommandText = "spConsumptionXmlExport";
			else
				cmd.CommandText = "spServiceXmlExport";

			cmd.Parameters.AddWithValue("@protypeid", 0);
			cmd.CommandTimeout = 300000;
			cmd.Parameters.AddWithValue("@forecastid", _forecastInfo.Id);
			cmd.Parameters.AddWithValue("@siteid", 0);
			cmd.Parameters.AddWithValue("@catid", 0);
			DataSet _rDataSet = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(cmd);

			if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
				da.Fill(_rDataSet, "spConsumptionXmlExport");
			else
				da.Fill(_rDataSet, "spServiceXmlExport");


			return _rDataSet;
		}

		private void butToxml_Click(object sender, EventArgs e)
		{ 
			ForecastInfo finfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
			
			try
			{
				saveFileDialog1.Title = "Specify Destination Filename";
                saveFileDialog1.FileName =String.Format("{0}.xml",finfo.ForecastNo);
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
						ProductType1 = r.Field<string>("ProductType"),
						ProductName1 = r.Field<string>("ProductName"),
						NoofProduct1 = r.Field<decimal>("NoofProduct"),
						PackQty1 = r.Field<int>("PackQty"),
						Price1 = r.Field<decimal>("Price"),
						Duration1 = r.Field<string>("Duration"),
						DurationDateTime1 = r.Field<DateTime>("DurationDateTime"),
						ProductID1 = r.Field<int>("ProductID")
					}).ToList();

					DateTime forecastStartDate = myData[0].DurationDateTime1;
					DateTime forecastEndDate =myData[myData.Count-1].DurationDateTime1;

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
						System_Name = finfo.ForecastNo + "-" + finfo.ForecastMethodEnum.ToString(),
						FileType = "Forecast",
						dtmDataExported = DateTime.Now.ToShortDateString(),
						dtmStart = forecastStartDate.ToShortDateString(),
						dtmEnd = forecastEndDate.ToShortDateString(),
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
						serializer.Serialize(stream, root,ns);
					////

					MessageBox.Show("Export to XML is completed Successfully.", "Export to XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch
			{
				MessageBox.Show("Error unable to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion
        
		private void treeViewlocation_AfterSelect(object sender, TreeViewEventArgs e)
		{
            int testorproductid = 0;
            int sorcatid = 0;
            ForecastInfo finfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
            lblSelectedTitle.Text = treeViewlocation.SelectedNode.Text;

			if (treeViewlocation.SelectedNode.Parent != null)
			{
                if (finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
                {
                   // if (treeViewlocation.SelectedNode.Parent.Text != "All")
                    //{
                        //sorcatid =(int)treeViewlocation.SelectedNode.Parent.Tag;// 
                        sorcatid = DataRepository.GetSiteByName(treeViewlocation.SelectedNode.Text).Id;//site
                        testorproductid=(int)treeViewlocation.SelectedNode.Tag;
                    //}
                }
                else
                {
                   // if (treeViewlocation.SelectedNode.Parent.Text != "All")
                    //{
                        //sorcatid = (int)treeViewlocation.SelectedNode.Parent.Tag;// 
                        sorcatid = DataRepository.GetSiteByName(treeViewlocation.SelectedNode.Text).Id;//site
                        testorproductid = (int)treeViewlocation.SelectedNode.Tag;
                   // }
                   // sorcatid = DataRepository.GetForecastCategoryByName(finfo.Id, treeViewlocation.SelectedNode.Text).Id;//category
                }

                 
            }
                   // if (finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
                   // {
                       // if (finfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
                        //{
                            //lnkUtilization.Enabled = true;
                        //}
                        //else
                           // lnkUtilization.Enabled = false;
                   // }
                    fid = finfo.Id;
                    siteorcatid = sorcatid;
                    BindForecastSummaryChart(fid, siteorcatid);
                    //if (testorproductid > 0)
                    //{
                    //    BindDataToChart(siteorcatid, testorproductid);
                    //    this.tabControl1.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    this.tabControl1.TabPages[0].Controls.Clear();
                    //    this.tabControl1.SelectedIndex = 1;
                    //}

            
		}

		private void BindForecastSummaryChart(int fid,int siteorcatid)
		{
				//cost summary
                //tableLayoutPanel2.Controls.Clear();

                //_currentControl = new chartFoercastResultDashboard(fid, siteorcatid);
                //_currentControl.Dock = DockStyle.Fill;
                //tableLayoutPanel2.Controls.Add(_currentControl);

                this.tabControl1.TabPages[0].Controls.Clear();
                _currentControl = new chartFoercastResultDashboard(fid, siteorcatid);
                _currentControl.Dock = DockStyle.Fill;
                tabControl1.TabPages[0].Controls.Add(_currentControl);

                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
                {
                    if (this.tabControl1.TabPages.Count < 3)
                    {
                        this.tabControl1.TabPages.Add("Forecasted Service");
                        this.tabControl1.TabPages.Add("Actual Service");
                    }

                    this.tabControl1.TabPages[1].Controls.Clear();
                    _currentControl = new chartUtilization(fid, siteorcatid);
                    _currentControl.Dock = DockStyle.Fill;
                    this.tabControl1.TabPages[1].Controls.Add(_currentControl);

                    this.tabControl1.TabPages[2].Controls.Clear();
                    _currentControl = new chartHistoricalUtilization(fid, siteorcatid); 
                    _currentControl.Dock = DockStyle.Fill;
                    this.tabControl1.TabPages[2].Controls.Add(_currentControl);
                }
                else
                {
                    if (this.tabControl1.TabPages.Count > 2)
                    {
                        tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
                        tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
                    }
                }

              

		}

        private void BindForecastUtilization()
        {
            //tableLayoutPanel3.Controls.Clear();
            //_currentControl = new chartUtilization(fid, siteorcatid);
            //_currentControl.Dock = DockStyle.Fill;
            //tableLayoutPanel3.Controls.Add(_currentControl);

            //tableLayoutPanel4.Controls.Clear();
            //_currentControl = new chartInsCoverage(fid, siteorcatid);
            //_currentControl.Dock = DockStyle.Fill;
            //tableLayoutPanel4.Controls.Add(_currentControl);
        }

        private void BindForecastChart(int fid, int siteorcatid,int typeid)
        {

            //if (iscost)
            //{
            ////    //cost summary
            //    tableLayoutPanel3.Controls.Clear();
            //    _currentControl = new chartTestCost(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel3.Controls.Add(_currentControl);

            //    tableLayoutPanel4.Controls.Clear();
            //    _currentControl = new chartTestCostbyduration(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel4.Controls.Add(_currentControl);
            //}
            //else
            //{
            //    //f summary
            //    tableLayoutPanel3.Controls.Clear();
            //    _currentControl = new chartTestNumberSummary(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel3.Controls.Add(_currentControl);

            //    tableLayoutPanel4.Controls.Clear();
            //    _currentControl = new chartTestNumberbyduration(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel4.Controls.Add(_currentControl);
            //}
        }
        
        private void BindChart(int fid, int siteorcatid, int typeid)
        {

            //if (iscost)
            //{
            //    //    //cost summary
            //    tableLayoutPanel3.Controls.Clear();
            //    _currentControl = new chartForecastTestCost(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel3.Controls.Add(_currentControl);

            //    tableLayoutPanel4.Controls.Clear();
            //    _currentControl = new chartForecastTestCostbyduration(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel4.Controls.Add(_currentControl);
            //}
            //else
            //{
            //    //f summary
            //    tableLayoutPanel3.Controls.Clear();
            //    _currentControl = new chartServiceTestNumber(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel3.Controls.Add(_currentControl);

            //    tableLayoutPanel4.Controls.Clear();
            //    _currentControl = new chartForecastTestNumberbyduration(fid, siteorcatid, typeid);
            //    _currentControl.Dock = DockStyle.Fill;
            //    tableLayoutPanel4.Controls.Add(_currentControl);
            //}
        }

		private void BindDataToChart(int parentid, int childId)
		{

            
           // // load forecast chart
            ForecastInfo finfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
            _currentControl = new chartSandCForecast(finfo.Id, parentid, childId);
            _currentControl.Dock = DockStyle.Fill;
            this.tabControl1.TabPages[0].Controls.Clear();
            this.tabControl1.TabPages[0].Controls.Add(_currentControl);
           // lblSelectedTitle.Text = lblSelectedTitle.Text + " -> " + _currentControl.Tag.ToString();

           // ///
           ////load moving average chart
           // _currentControl = new chartSandCMovingAvg(finfo.Id, parentid, childId);
           // _currentControl.Dock = DockStyle.Fill;
           // tableLayoutPanel4.Controls.Clear();
           // tableLayoutPanel4.Controls.Add(_currentControl);

		}
	  
		private void cboRegressionType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboRegressionType.Text != "Polynomial")
				cboOrder.Enabled = false;
			else
				 cboOrder.Enabled = true;
		}
		
		private void comMethodologey_SelectedIndexChanged(object sender, EventArgs e)
		{
            //lnkUtilization.Enabled = false;
            
			if (comMethodologey.Text == "--All--")
			{
				comStatus.SelectedIndex = 0;
				comStatus.Enabled = false;
			}
			else
				comStatus.Enabled = true;

			PopForecastInfo();
            EnableCatInstUtilizationlink();
		}

		private void comStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			PopForecastInfo();
		}

	    private void butForecast_Click(object sender, EventArgs e)
	    {
	        _westage = decimal.Parse(txtWestage.Text);
	        _scaleup = decimal.Parse(txtAddby.Text);
	        _regressionType = cboRegressionType.Text;
	        _forecastWithoutError = false;
            _startTime = String.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
	        bwforecast.RunWorkerAsync();
	    }

	    private void Forecast()
	    {
	        try
	        {
	            if (_forecastInfo.StatusEnum != ForecastStatusEnum.OPEN)
	            {
	                if (
	                    MessageBox.Show(
	                        "This forecast is already forecasted.Are you sure do you want to overwrite this forecast?",
	                        "Forecasting Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
	                    DialogResult.Yes)
	                {
	                    return;
	                }
	                DataRepository.DeleteAllFResult(_forecastInfo.Id);
	            }

	            if (lblProgress.InvokeRequired)
	            {
	                lblProgress.Invoke((MethodInvoker) delegate { lblProgress.Visible = true; });
	                lblProgress.Invoke((MethodInvoker) delegate { lblProgress.Text = "Starting forecasting..."; });
	            }
	            else
	            {
	                lblProgress.Visible = true;
	                lblProgress.Text = "Starting forecasting...";
	            }

	            if (progressBar1.InvokeRequired)
	                progressBar1.Invoke((MethodInvoker) delegate { progressBar1.Enabled = true; });
	            else
	                progressBar1.Enabled = true;

	            if (rtbInfo.InvokeRequired)
	                rtbInfo.Invoke((MethodInvoker) delegate { rtbInfo.Text = ""; });
	            else
	                rtbInfo.Text = "";
                
	            _listFresult = new List<ForecastedResult>();

	            if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 ||
	                _forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
	                ForcastSiteHistoricalData(_forecastInfo);
	            else
	                ForcastCategoryHistoricalData(_forecastInfo);

	            if (lblProgress.InvokeRequired)
	                lblProgress.Invoke((MethodInvoker) delegate { lblProgress.Text = "Saving result to database..."; });
	            else
	                lblProgress.Text = "Saving result to database...";

	            if (progressBar1.InvokeRequired)
	            {
	                progressBar1.Invoke((MethodInvoker) delegate
	                {
	                    progressBar1.Maximum = _listFresult.Count;
	                    progressBar1.Value = 0;
	                });
	            }
	            else
	            {
	                progressBar1.Maximum = _listFresult.Count;
	                progressBar1.Value = 0;
	            }
                
                SaveBulkForecastedResult();
	            
	            _forecastWithoutError = true;
	        }
	        catch (Exception ex)
	        {
	            _forecastWithoutError = false;
	            FrmShowError frm = new FrmShowError(new ExceptionStatus()
	            {
	                message = "Forecasting process not completed successfully.",
	                ex = ex
	            });
	            frm.ShowDialog();
	        }
	    }

	    private void SaveBulkForecastedResult()
	    {
	        SqlConnection sqlConnection = ConnectionManager.GetInstance().GetSqlConnection();
	        DataTable fresultdt = GenericToDataTable.ConvertTo(_listFresult);
            try
            {
                using (var bulkCopy = new SqlBulkCopy(sqlConnection))
                {
                    bulkCopy.DestinationTableName = "dbo.ForecastedResult";

                    bulkCopy.WriteToServer(fresultdt);
                }
            }
            catch
            { }
	    }

	    private void ShowResultForm(ForecastInfo finfo, string stime, string etime)
		{
			FrmForecastResult frm = new FrmForecastResult(finfo, stime,etime);
			frm.ShowDialog();
		}

		void DataRepository_OnFResultSaved(object sender, EventArgs e)
		{
			if (progressBar1.InvokeRequired)
				progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value += 1; });
			else
				progressBar1.Value += 1;
		}

		public string GetFormulaParameters(int extension)
		{
			//string error = checkBoxError.Checked.ToString();
			//string forecastingError = checkBoxForecastingError.Checked.ToString();

			if (cboRegressionType.Text != "Polynomial")
				cboOrder.Enabled = false;
			else
				cboOrder.Enabled = true;

			string typeRegression;

			if (cboRegressionType.Text != "Polynomial")
				typeRegression = cboRegressionType.Text;
			else
				typeRegression = cboOrder.Text;

			return String.Format("{0},{1},{2},{3}", typeRegression, extension, "true", "true");
		}

		private void ForcastSiteHistoricalData(ForecastInfo finfo)
		{
			
			foreach (ForecastSite s in finfo.ForecastSites)
			{
				if (finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
				{
					IList<MasterProduct> products = s.GetUniqFSProduct();
					if (this.progressBar1.InvokeRequired)
					{
						progressBar1.Invoke((MethodInvoker)delegate
						{
							progressBar1.Maximum = products.Count;
							progressBar1.Value = 0;
						});
					}
					else
					{
						progressBar1.Maximum = products.Count;
						progressBar1.Value = 0;
					}
							
					

					foreach (MasterProduct p in products)
					{
						if (this.lblProgress.InvokeRequired)
						{
							lblProgress.Invoke((MethodInvoker)delegate
							{
								lblProgress.Text = String.Format("{0} -> {1} forecasted...", s.Site.SiteName, p.ProductName);
							});
						}
						else
							lblProgress.Text = String.Format("{0} -> {1} forecasted...",s.Site.SiteName, p.ProductName);

					   Application.DoEvents();

						ClearChart1SeriesPoints();

						IList<ForecastSiteProduct> fsiteProduct = DataRepository.GetFSiteProductByProId(s.Id, p.Id, SortDirection.Ascending);                        
						foreach (ForecastSiteProduct sp in fsiteProduct)
						{
							if (this.chart1.InvokeRequired)
							{
								chart1.Invoke((MethodInvoker)delegate
								{
									chart1.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted);
								});
							}
							else
								chart1.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted);
						}

						//gets last Input date
						lastEntryDate = fsiteProduct[fsiteProduct.Count - 1].DurationDateTime.Value;
							if (this.chart1.InvokeRequired)
								chart1.Invoke((MethodInvoker)delegate { chart1.Invalidate(); });
							else
								chart1.Invalidate();

						CalculateChart1(finfo.Extension);

						DataSet  ds = chart1.DataManipulator.ExportSeriesValues("Forecasting");
						DataSet InputDs = chart1.DataManipulator.ExportSeriesValues("Input");
						//
						ReadDataset(finfo, s.Site.Id, 0, p.Id, 0, ds,lastEntryDate,InputDs);
						if (this.progressBar1.InvokeRequired)
							progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value += 1; });
						else
							progressBar1.Value += 1;

						Application.DoEvents();
					}
				}
				else if (finfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
				{
					IList<Test> tests = s.GetUniqTest();
					if (this.progressBar1.InvokeRequired)
					{
						progressBar1.Invoke((MethodInvoker)delegate
						{
							progressBar1.Maximum = tests.Count;
							progressBar1.Value = 0;
						});
					}
					else
					{
						progressBar1.Maximum = tests.Count;
						progressBar1.Value = 0;
					}
					foreach (Test p in tests)
					{
						IList<ForecastSiteTest> fsiteTest = DataRepository.GetFSiteTestByTestId(s.Id, p.Id, SortDirection.Ascending);
						if (this.lblProgress.InvokeRequired)
						{
							lblProgress.Invoke((MethodInvoker)delegate
							{
								lblProgress.Text = String.Format("{0} -> {1} forecasted...", s.Site.SiteName, p.TestName);
							});
						}
						else
							lblProgress.Text = String.Format("{0} -> {1} forecasted...", s.Site.SiteName, p.TestName);

						Application.DoEvents();

						ClearChart1SeriesPoints();

						foreach (ForecastSiteTest sp in fsiteTest)
						{
							if (this.chart1.InvokeRequired)
								chart1.Invoke((MethodInvoker)delegate { chart1.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted); });
							else
								chart1.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted);
						}


						lastEntryDate = fsiteTest[fsiteTest.Count - 1].DurationDateTime.Value;
						DataSet InputDs = chart1.DataManipulator.ExportSeriesValues("Input");

						if (this.chart1.InvokeRequired)
							chart1.Invoke((MethodInvoker)delegate { chart1.Invalidate(); });
						else 
							chart1.Invalidate();
							
						CalculateChart1(finfo.Extension);
						DataSet ds = chart1.DataManipulator.ExportSeriesValues("Forecasting");
						ReadDataset(finfo, s.Site.Id, 0, 0, p.Id, ds, lastEntryDate,InputDs);
						if (this.progressBar1.InvokeRequired)
							progressBar1.Invoke((MethodInvoker)delegate { progressBar1.Value += 1; });
						else
							progressBar1.Value += 1;

						Application.DoEvents();
					}
				}
			}
		}

		private void ForcastCategoryHistoricalData(ForecastInfo finfo)
		{
		  
			foreach (ForecastCategory c in finfo.ForecastCategories)
			{
				if (finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
				{
					IList<MasterProduct> products = c.GetUniqFSProduct();
					foreach (MasterProduct p in products)
					{
						ClearChart1SeriesPoints();
						IList<ForecastCategoryProduct> fcatProduct = DataRepository.GetFCategoryProductByProId(c.Id, p.Id, SortDirection.Ascending);                       
						foreach (ForecastCategoryProduct cp in fcatProduct)
						{
							if (this.chart1.InvokeRequired)
								chart1.Invoke((MethodInvoker)delegate { chart1.Series["Input"].Points.AddXY(cp.DurationDateTime.Value, cp.Adjusted); });
							else
								chart1.Series["Input"].Points.AddXY(cp.DurationDateTime.Value, cp.Adjusted);
						}


						lastEntryDate = fcatProduct[fcatProduct.Count - 1].DurationDateTime.Value;

						DataSet InputDs = chart1.DataManipulator.ExportSeriesValues("Input");

                        if (this.chart1.InvokeRequired)
                            chart1.Invoke((MethodInvoker)delegate { chart1.Invalidate(); });
                        else
						    chart1.Invalidate();
						CalculateChart1(finfo.Extension);
						DataSet ds = chart1.DataManipulator.ExportSeriesValues("Forecasting");
						ReadDataset(finfo,0, c.Id, p.Id, 0, ds,lastEntryDate,InputDs);                        
					}
				}
				else if (finfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
				{
					IList<Test> tests = c.GetUniqFCTest();
					foreach (Test p in tests)
					{
						ClearChart1SeriesPoints();
						IList<ForecastCategoryTest> fcatTest = DataRepository.GetFCategoryTestByTestId(c.Id, p.Id, SortDirection.Ascending);
						foreach (ForecastCategoryTest ft in fcatTest)
						{
							if (this.chart1.InvokeRequired)
								chart1.Invoke((MethodInvoker)delegate { chart1.Series["Input"].Points.AddXY(ft.DurationDateTime.Value, ft.Adjusted); });
							else
								chart1.Series["Input"].Points.AddXY(ft.DurationDateTime.Value, ft.Adjusted);
						}

						lastEntryDate = fcatTest[fcatTest.Count - 1].DurationDateTime.Value;
						DataSet InputDs = chart1.DataManipulator.ExportSeriesValues("Input");
						if (this.chart1.InvokeRequired)
							chart1.Invoke((MethodInvoker)delegate { chart1.Invalidate(); });
						else
							chart1.Invalidate();

						CalculateChart1(finfo.Extension);
						DataSet ds = chart1.DataManipulator.ExportSeriesValues("Forecasting");
						ReadDataset(finfo, 0, c.Id, 0, p.Id, ds, lastEntryDate,InputDs);
					}
				}
			}
		}

		private void ClearChart1SeriesPoints()
		{
			if (this.chart1.InvokeRequired)
			{
				chart1.Invoke((MethodInvoker)delegate { chart1.Series[0].Points.Clear(); });
				chart1.Invoke((MethodInvoker)delegate { chart1.Series[1].Points.Clear(); });
				chart1.Invoke((MethodInvoker)delegate { chart1.Series[2].Points.Clear(); });
			}
			else
			{
				chart1.Series[0].Points.Clear();
				chart1.Series[1].Points.Clear();
				chart1.Series[2].Points.Clear();
			}
			
		}

		private void CalculateChart1(int extension)
		{
			if (this.chart1.InvokeRequired)
			{
				chart1.Invoke((MethodInvoker)delegate { chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, GetFormulaParameters(extension), "Input:Y", "Forecasting:Y,Range:Y,Range:Y2"); });
				chart1.Invoke((MethodInvoker)delegate { chart1.Series["Range"].Enabled = false; });
				chart1.Invoke((MethodInvoker)delegate { chart1.Invalidate(); });
			}
			else
			{
				chart1.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, GetFormulaParameters(extension), "Input:Y", "Forecasting:Y,Range:Y,Range:Y2");
				chart1.Series["Range"].Enabled = false;
				chart1.Invalidate();
			}
		}

		private int GetNoofPackage(int packSize,decimal noofproduct)
		{
			int Nopack;
			decimal Result;
			if(packSize==0)
				Result=noofproduct;
			else
				Result=noofproduct/packSize;

			Nopack= int.Parse(decimal.Round(Result,0).ToString());

			if(Nopack<Result)
				Nopack=Nopack+1;
			if(Nopack==0)
				Nopack=0;

			return Nopack;
		}

		private void ReadDataset(ForecastInfo finfo, int siteid,int catid, int proid, int testid,DataSet ds,DateTime lastDate,DataSet inputDs)
		{
		   
			
			decimal prevValue = 0;
			int period = 0;

			foreach (DataRow row in ds.Tables[0].Rows)
			{
				DateTime ddate = Convert.ToDateTime(row[0]);

				//if (ddate.Day > 29)
				//{
				//    if (ddate.Month == 12)
				//        ddate = new DateTime(ddate.Year + 1, 1, 1);
				//    ddate = new DateTime(ddate.Year, ddate.Month+1, 1);
				//}
		  
					ForecastedResult fresult = new ForecastedResult();
					fresult.ForecastId = finfo.Id;
					fresult.SiteId = siteid;
					fresult.CategoryId = catid;
					fresult.TestId = testid;
					fresult.ProductId = proid;
					fresult.DurationDateTime = LqtUtil.CorrectDateTime(ddate.Date);//ddate.Date;

                    if (Convert.ToDecimal(row[1]) < 0)
                        fresult.ForecastValue = 0;
                    else
					    fresult.ForecastValue = Convert.ToDecimal(row[1]);
                

					if (ddate > lastDate)
					{
						fresult.IsHistory = false;
						fresult.HistoricalValue = 0;
					}
					else
					{
						DataRow rowinput = inputDs.Tables[0].Rows[period];
						fresult.HistoricalValue = Convert.ToDecimal(rowinput[1]);
						fresult.IsHistory = true;
					}

					if (finfo.PeriodEnum == ForecastPeriodEnum.Monthly || finfo.PeriodEnum == ForecastPeriodEnum.Bimonthly)
						fresult.Duration = String.Format("{0}-{1}", LqtUtil.Months[fresult.DurationDateTime.Month - 1], fresult.DurationDateTime.Year);
					else if (finfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
						fresult.Duration = String.Format("Qua{0}-{1}", LqtUtil.GetQuarter(fresult.DurationDateTime), fresult.DurationDateTime.Year);
					else
						fresult.Duration = String.Format("{0}", fresult.DurationDateTime.Year);

					fresult.TotalValue = fresult.ForecastValue + (fresult.ForecastValue * (_westage / 100));
					fresult.TotalValue += prevValue * (_scaleup / 100);
					prevValue = fresult.TotalValue;

					fresult.ServiceConverted = false;

					//get TestingArea
					if (fresult.TestId > 0)
					{
						Test test = DataRepository.GetTestById(fresult.TestId);
						fresult.TestingArea = test.TestingArea.AreaName;
						
					}
				   

					//get packQty
					if (fresult.ProductId > 0)
					{
						MasterProduct p = DataRepository.GetProductById(fresult.ProductId);

						//converting quantity to packsize commented out
						//int packSize = p.GetActiveProductPrice(fresult.DurationDateTime).PackSize;
						//fresult.PackQty = GetNoofPackage(packSize, fresult.TotalValue);

						//rounding forecasted pack quantity
						int Nopack = int.Parse(decimal.Round(fresult.TotalValue, 0).ToString());

						if (Nopack < fresult.TotalValue)
							Nopack = Nopack + 1;
						if (Nopack == 0)
							Nopack = 0;
						fresult.TotalValue = Nopack;
						fresult.PackQty = Nopack;

						fresult.PackPrice = fresult.PackQty * p.GetActiveProductPrice(fresult.DurationDateTime).Price;

						fresult.ProductTypeId = p.ProductType.Id;
						fresult.ProductType = p.ProductType.TypeName;
					}

					_listFresult.Add(fresult);

					//test to product
					if (fresult.TestId > 0)
					{
						Test test = DataRepository.GetTestById(fresult.TestId);
                        ForlabSite fsite = null;
                        if (fresult.SiteId > 0)
                            fsite = DataRepository.GetSiteById(fresult.SiteId);

                        ForecastCategory fc = null;
                        if (fresult.CategoryId > 0)
                            fc = DataRepository.GetForecastCategoryById(fresult.CategoryId);
                            
						foreach (ProductUsage pu in test.ProductUsages)
						{
                            ForecastedResult cfresult = new ForecastedResult();
                            //copyvalues
                            cfresult.ForecastId = fresult.ForecastId;
                            cfresult.TestId = fresult.TestId;
                            cfresult.DurationDateTime = fresult.DurationDateTime;
                            //cfresult.ForecastValue = fresult.ForecastValue;
                            //cfresult.TotalValue = fresult.TotalValue;
                            cfresult.SiteId = fresult.SiteId;
                            cfresult.CategoryId = fresult.CategoryId;
                            cfresult.Duration = fresult.Duration;
                            cfresult.IsHistory = fresult.IsHistory;
                            //cfresult.HistoricalValue = fresult.HistoricalValue;
                            cfresult.TestingArea = fresult.TestingArea;
                            //endcopy

                            if (finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
                            {
                                if (fsite != null)
                                { 
                                    SiteInstrument siteins=fsite.GetSiteInstrumentByInsId(pu.Instrument.Id);
                                    if (siteins!=null)
                                    {
                                        decimal Qty = pu.Rate * fresult.TotalValue*siteins.TestRunPercentage/100;
                                        cfresult.TotalValue = Qty;
                                        int packSize = pu.Product.GetActiveProductPrice(fresult.DurationDateTime).PackSize;
                                        cfresult.ProductId = pu.Product.Id;
                                        cfresult.PackQty = GetNoofPackage(packSize, Qty);
                                        cfresult.PackPrice = cfresult.PackQty * pu.Product.GetActiveProductPrice(fresult.DurationDateTime).Price;

                                        cfresult.ProductTypeId = pu.Product.ProductType.Id;
                                        cfresult.ProductType = pu.Product.ProductType.TypeName;
                                        cfresult.ServiceConverted = true;
                                        _listFresult.Add(cfresult);
                                    }
                                }
                            }
                            else
                            {
                                if (fsite != null)
                                {
                                    ForecastCategoryInstrument fcins = DataRepository.GetForecastCategoryInstrumentById(pu.Instrument.Id);

                                    if (fcins != null)
                                    {
                                        decimal Qty = pu.Rate * fresult.TotalValue*fcins.TestRunPercentage;
                                        cfresult.TotalValue = Qty;
                                        int packSize = pu.Product.GetActiveProductPrice(fresult.DurationDateTime).PackSize;
                                        cfresult.ProductId = pu.Product.Id;
                                        cfresult.PackQty = GetNoofPackage(packSize, Qty);
                                        cfresult.PackPrice = cfresult.PackQty * pu.Product.GetActiveProductPrice(fresult.DurationDateTime).Price;

                                        cfresult.ProductTypeId = pu.Product.ProductType.Id;
                                        cfresult.ProductType = pu.Product.ProductType.TypeName;
                                        cfresult.ServiceConverted = true;
                                        _listFresult.Add(cfresult);
                                    }
                                }
                            }
						}

					}
			   
				period++;
			}
		}

		private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
				int x = e.KeyChar;

			if ((x >= 48 && x <= 57) || (x == 8) || (x == 46))
			{
				e.Handled = false;
			}
			else
				e.Handled = true;
		}

        private void lnkshowmapesummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ForecastInfo finfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
			FrmForecastResult frm = new FrmForecastResult(finfo);
			frm.ShowDialog();
		}

		private void bwforecast_DoWork(object sender, DoWorkEventArgs e)
		{
			if (butForecast.InvokeRequired)
				butForecast.Invoke((MethodInvoker)delegate
				{
					foreach (Control c in this.Controls)
					{ c.Enabled = false; }
				});
			else
				foreach (Control c in this.Controls)
				{ c.Enabled = false; }
            
			Forecast();
		}

		private void bwforecast_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		    if (_forecastWithoutError)
		    {
		        _forecastInfo.Status = ForecastStatusEnum.CLOSED.ToString();
		        _forecastInfo.Method = _regressionType;
		        _forecastInfo.ForecastDate = DateTime.Now;
		        _forecastInfo.Westage = _westage;
		        _forecastInfo.Scaleup = _scaleup;

		        DataRepository.SaveOrUpdateForecastInfo(_forecastInfo);

		        string etime = String.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
		        ShowResultForm(_forecastInfo, _startTime, etime);
		    }

		    foreach (Control c in this.Controls)
			{ c.Enabled = true; }
            
			BuildNavigationTree();

			if (_forecastInfo.StatusEnum != ForecastStatusEnum.OPEN)
			{
				butSummary.Enabled = true;
				butToxml.Enabled = true;
				lnkshowmapesummary.Enabled = true;
			}
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = 0;
                    progressBar1.Enabled = false;
                });
            }
            else
            {
                progressBar1.Value = 0;
                progressBar1.Enabled = false;
            }

            if (lblProgress.InvokeRequired)
                lblProgress.Invoke((MethodInvoker)delegate { lblProgress.Visible = false; });
            else
                lblProgress.Visible = false;
		}

	    private void lnkCostSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	    {
	        iscost = true;
	        if (treeViewlocation.SelectedNode.Parent == null)
	        {
	            BindForecastSummaryChart(fid, siteorcatid);
	        }
	        else if (treeViewlocation.SelectedNode.Parent.Parent == null) //b pro type under site     
	        {
	            BindForecastChart(fid, siteorcatid, (int) treeViewlocation.SelectedNode.Tag);
	        }
	    }

	    private void lnkforecastsummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			iscost = false;
            if (treeViewlocation.SelectedNode.Parent == null)
            {
                BindForecastSummaryChart(fid, siteorcatid);
            }
            else if (treeViewlocation.SelectedNode.Parent.Parent == null)//b pro type under site            
            {
                BindForecastChart(fid, siteorcatid, (int)treeViewlocation.SelectedNode.Tag);
            }
        
		}

		private void lnkUtilization_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			BindForecastUtilization();
		}
        
        private void lnkCatInstUtilizaiton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForecastCategoryInstrument frm = new FrmForecastCategoryInstrument(fid);
            frm.ShowDialog();
        }

        private void EnableCatInstUtilizationlink()
        {
            _forecastInfo = LqtUtil.GetComboBoxValue<ForecastInfo>(comForecastinfo);
            if (_forecastInfo != null)
            {
                if (_forecastInfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC)
                {
                    if (_forecastInfo.DatausageEnum == DataUsageEnum.DATA_USAGE3)
                        lnkCatInstUtilizaiton.Visible = true;
                    else
                        lnkCatInstUtilizaiton.Visible = false;
                }
                else
                    lnkCatInstUtilizaiton.Visible = false;
            }
            else
                lnkCatInstUtilizaiton.Visible = false;

        }
	}
}
