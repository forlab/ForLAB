
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

namespace LQT.GUI.UserCtr
{
    public partial class chartSandCForecast : LQT.GUI.UserCtr.BaseUserControl
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

        public chartSandCForecast()
        {
            InitializeComponent();
        }

        public chartSandCForecast(int forecastId, int parentid, int childId)
        {
            _ForecastId = forecastId;
            _parentid = parentid;
            _childId = childId;
            InitializeComponent();
        }

        private void chartSandCForecast_Load(object sender, EventArgs e)
        {
            _finfo = DataRepository.GetForecastInfoById(_ForecastId);
            if (_finfo.StatusEnum == ForecastStatusEnum.CLOSED)
                doCalculations = true;

            BindDataToChart();
        }

        

        private void checkBoxError_CheckedChanged(object sender, EventArgs e)
        {
            if (doCalculations)
            {
                CalculateChart2(_finfo.Extension);
            }
        }

        private void checkBoxForecastingError_CheckedChanged(object sender, EventArgs e)
        {
            if (doCalculations)
            {
                CalculateChart2(_finfo.Extension);
            }
        }

        private void CalculateChart2(int extension)
        {
            //if (cboRegressionType.Text == "WeightedMovingAverage")
            //    chart2.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, extension.ToString(), "Input:Y", "Forecasting:Y,Range:Y,Range:Y2");
            //else
            chart2.DataManipulator.FinancialFormula(FinancialFormula.Forecasting, GetFormulaParameters(extension), "Input:Y", "Forecasting:Y,Range:Y,Range:Y2");

            chart2.Series["Range"].Enabled = checkBoxError.Checked || checkBoxForecastingError.Checked;

            chart2.Invalidate();
        }

        public string GetFormulaParameters(int extension)
        {
            string error = checkBoxError.Checked.ToString();
            string forecastingError = checkBoxForecastingError.Checked.ToString();

            string typeRegression;

            if (_finfo.Method != "Polynomial")
                typeRegression = _finfo.Method;
            else
                typeRegression = _finfo.ROrder.ToString();

            return String.Format("{0},{1},{2},{3}", typeRegression, extension, error, forecastingError);
        }

        private void ClearChart2SeriesPoints()
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
        }

        private void BindDataToChart()
        {
            doCalculations = true;
            ClearChart2SeriesPoints();
           
            int period = 0;
            string title = "";

            if (_finfo.DatausageEnum == DataUsageEnum.DATA_USAGE1 || _finfo.DatausageEnum == DataUsageEnum.DATA_USAGE2)
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    IList<ForecastSiteProduct> fsiteProduct = DataRepository.GetFSiteProductByProId(_parentid, _childId, SortDirection.Ascending);
                    period = fsiteProduct.Count;
                    title = fsiteProduct[0].Product.ProductName;
                    foreach (ForecastSiteProduct sp in fsiteProduct)
                    {
                        chart2.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted);
                    }
                }
                else
                {
                    IList<ForecastSiteTest> fsiteTest = DataRepository.GetFSiteTestByTestId(_parentid, _childId, SortDirection.Ascending);
                    period = fsiteTest.Count;
                    title = fsiteTest[0].Test.TestName;
                    foreach (ForecastSiteTest sp in fsiteTest)
                    {
                        chart2.Series["Input"].Points.AddXY(sp.DurationDateTime.Value, sp.Adjusted);
                    }
                }
            }
            else
            {
                if (_finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                {
                    IList<ForecastCategoryProduct> fcatProduct = DataRepository.GetFCategoryProductByProId(_parentid, _childId, SortDirection.Ascending);
                    period = fcatProduct.Count;
                    title = fcatProduct[0].Product.ProductName;
                    foreach (ForecastCategoryProduct cp in fcatProduct)
                    {
                        chart2.Series["Input"].Points.AddXY(cp.DurationDateTime.Value, cp.Adjusted);
                    }
                }
                else
                {
                    IList<ForecastCategoryTest> fcatTest = DataRepository.GetFCategoryTestByTestId(_parentid, _childId, SortDirection.Ascending);
                    period = fcatTest.Count;
                    title = fcatTest[0].Test.TestName;
                    foreach (ForecastCategoryTest ft in fcatTest)
                    {
                        chart2.Series["Input"].Points.AddXY(ft.DurationDateTime.Value, ft.Adjusted);
                    }
                }
            }

            chart2.Invalidate();
            CalculateChart2(_finfo.Extension);
            Tag = title;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
