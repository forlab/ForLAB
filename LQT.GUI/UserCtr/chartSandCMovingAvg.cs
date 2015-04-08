
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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using LQT.Core;

namespace LQT.GUI.UserCtr
{
	public partial class chartSandCMovingAvg : LQT.GUI.UserCtr.BaseUserControl
	{
		private CD4TestNumber _cd;
		private int _ForecastId;
		private SqlConnection cn = ConnectionManager.GetInstance().GetSqlConnection();
		private DataSet _dataSet;
		private decimal _total;
		private ForecastInfo _finfo;
		private bool doCalculations = false;
		private int _parentid;
		private int _childId;
		private string _title;

		private readonly string Checked_Image_Path = AppSettings.GetReportPath + "\\Reports.Icono\\chk_checked.png";
		private readonly string Unchecked_Image_Path = AppSettings.GetReportPath + "\\Reports.Icono\\chk_unchecked.png";

		public chartSandCMovingAvg()
		{
			InitializeComponent();
		}

		public chartSandCMovingAvg(int forecastId, int parentid, int childId)
		{
			_ForecastId = forecastId;
			_parentid = parentid;
			_childId = childId;
			InitializeComponent();
		}

		private void chartSandCMovingAvg_Load(object sender, EventArgs e)
		{
			lqtChart1.Series["Input"].ChartType = SeriesChartType.Line;

			for (int i = 1; i < 4; i++)
			{
				lqtChart1.Legends["Default"].CustomItems[i].Cells[0].ImageTransparentColor = Color.Red;
			}

			lqtChart1.Legends["Default"].CustomItems[1].Cells[0].Image = Checked_Image_Path;
			lqtChart1.Legends["Default"].CustomItems[2].Cells[0].Image = Checked_Image_Path;
			// lqtChart1.Legends["Default"].CustomItems[3].Cells[0].Image = Checked_Image_Path;
			lqtChart1.Legends["Default"].CustomItems[3].Cells[0].Image = Checked_Image_Path;

			// Set tag property for all custom items to appropriate series
			lqtChart1.Legends["Default"].CustomItems[1].Tag = lqtChart1.Series["Simple"];
			lqtChart1.Legends["Default"].CustomItems[2].Tag = lqtChart1.Series["Exponential"];
			// lqtChart1.Legends["Default"].CustomItems[3].Tag = lqtChart1.Series["Triangular"];
			lqtChart1.Legends["Default"].CustomItems[3].Tag = lqtChart1.Series["Weighted"];

			_finfo = DataRepository.GetForecastInfoById(_ForecastId);
			if (_finfo.StatusEnum == ForecastStatusEnum.CLOSED)
				doCalculations = true;

			BindDataToChart();
		}

		private void SetSeriesAppearance(string seriesName)
		{
			lqtChart1.Series[seriesName].ChartArea = "Default";
			lqtChart1.Series[seriesName].ChartType = SeriesChartType.Line;
			lqtChart1.Series[seriesName].BorderWidth = 2;
			lqtChart1.Series[seriesName].ShadowOffset = 1;
			lqtChart1.Series[seriesName].IsVisibleInLegend = false;
		}

		private void UpdateMovingAvgChart(string period)
		{

			lqtChart1.DataManipulator.IsStartFromFirst = true;
	
			lqtChart1.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, period, "Input", "Simple");
			SetSeriesAppearance("Simple");
	
			lqtChart1.DataManipulator.FinancialFormula(FinancialFormula.ExponentialMovingAverage, period, "Input", "Exponential");
			SetSeriesAppearance("Exponential");

			lqtChart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, period, "Input", "Weighted");
			SetSeriesAppearance("Weighted");

			lqtChart1.Invalidate();
		}

		private void lqtChart1_MouseDown(object sender, MouseEventArgs e)
		{
			HitTestResult result = lqtChart1.HitTest(e.X, e.Y);
			if (result != null && result.Object != null)
			{
				// When user hits the LegendItem
				if (result.Object is LegendItem)
				{
					// Legend item result
					LegendItem legendItem = (LegendItem)result.Object;

					// series item selected
					Series selectedSeries = (Series)legendItem.Tag;

					if (selectedSeries != null)
					{
						if (selectedSeries.Enabled)
						{
							selectedSeries.Enabled = false;
							legendItem.Cells[0].Image = Unchecked_Image_Path;
							legendItem.Cells[0].ImageTransparentColor = Color.Red;
						}

						else
						{
							selectedSeries.Enabled = true;
							legendItem.Cells[0].Image = Checked_Image_Path;
							legendItem.Cells[0].ImageTransparentColor = Color.Red;
						}
					}
				}
			}
		}


		private void BindDataToChart()
		{
			lqtChart1.Series["Input"].Points.Clear();
			int period = 0;

			foreach (Series s in lqtChart1.Series)
			{
				s.Points.Clear();
			}

			if (_finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
			{
				if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
				{
					IList<ForecastSiteProduct> fsiteProduct = DataRepository.GetFSiteProductByProId(_parentid, _childId, SortDirection.Ascending);
					period = fsiteProduct.Count;
					foreach (ForecastSiteProduct sp in fsiteProduct)
					{
						lqtChart1.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted);
					}
				}
				else
				{
					IList<ForecastSiteTest> fsiteTest = DataRepository.GetFSiteTestByTestId(_parentid, _childId, SortDirection.Ascending);
					period = fsiteTest.Count;
					foreach (ForecastSiteTest sp in fsiteTest)
					{
						lqtChart1.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted);
					}
				}
			}
			else
			{
				if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
				{
					IList<ForecastCategoryProduct> fcatProduct = DataRepository.GetFCategoryProductByProId(_parentid, _childId, SortDirection.Ascending);
					period = fcatProduct.Count;
					foreach (ForecastCategoryProduct cp in fcatProduct)
					{
						lqtChart1.Series["Input"].Points.AddXY(cp.DurationDateTime.Value, cp.Adjusted);
					}
				}
				else
				{
					IList<ForecastCategoryTest> fcatTest = DataRepository.GetFCategoryTestByTestId(_parentid, _childId, SortDirection.Ascending);
					period = fcatTest.Count;
					foreach (ForecastCategoryTest ft in fcatTest)
					{
						lqtChart1.Series["Input"].Points.AddXY(ft.DurationDateTime.Value, ft.Adjusted);
					}
				}
			}

			UpdateMovingAvgChart(period.ToString());
		   
		}

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
	}
}
