
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LQT.Core.Domain;
using LQT.Core.UserExceptions;
using LQT.Core.Util;
using LQT.Core;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using  Excel=Microsoft.Office.Interop.Excel; 

namespace LQT.GUI
{
    public partial class FrmForecastResult : Form
    {
        private ForecastInfo forecastInfo = null;
        public FrmForecastResult(ForecastInfo finfo, string stime, string etime)
        {
            InitializeComponent();
            forecastInfo = finfo;
            lblmeapindicator3.Text = "no field color represents an" + Environment.NewLine + "accurate forecast, within 25%.";

            lblmeapindicator3.Text = "no field color represents an" + Environment.NewLine + "accurate forecast, within 25%.";
            lblgray.Text = "represents insufficient data to" + Environment.NewLine + "complete the forecast";


            lblAddby.Text = finfo.Scaleup.ToString();
            lblExtension.Text = finfo.Extension.ToString();
            //lblOrder.Text = finfo.Order;
            lblRegression.Text = finfo.Method;
            lblWestage.Text = finfo.Westage.ToString();

            richTextBox1.AppendText("Start On: " + stime);
            richTextBox1.AppendText("End On: " + etime);
            richTextBox1.AppendText("Forecasting process completed successfully.");

            if (finfo.FMethodologeyEnum == MethodologyEnum.SERVICE_STATISTIC && finfo.DatausageEnum != DataUsageEnum.DATA_USAGE2)
            {
                IList result = DataRepository.GetBeyondMaxTPutResult(finfo.Id, finfo.MonthInPeriod);
                if (result.Count > 0)
                {
                    listView1.BeginUpdate();
                    listView1.Items.Clear();

                    foreach (object[] r in result)
                    {
                        ListViewItem li = new ListViewItem(r[0].ToString());
                        li.SubItems.Add(r[1].ToString());
                        li.SubItems.Add(r[2].ToString());
                        li.SubItems.Add(r[3].ToString());
                        li.SubItems.Add(r[4].ToString());
                        listView1.Items.Add(li);
                    }

                    listView1.EndUpdate();
                    richTextBox1.AppendText("But there is a forecast which exceed Maximum through-put of instrument.");
                    richTextBox1.AppendText("You can view the detail on 'Max-Through Put' tab.");
                }
                else
                {
                    tabResult.TabPages.Remove(tabMax);
                }
            }
            else
            {
                tabResult.TabPages.Remove(tabMax);
            }
            BindMapeSummaryChart(finfo);
        }

        public FrmForecastResult(ForecastInfo finfo)
        {
            InitializeComponent();

            forecastInfo = finfo;
            lblmeapindicator3.Text = "no field color represents an" + Environment.NewLine + "accurate forecast, within 25%.";
            lblgray.Text = "represents insufficient data to" + Environment.NewLine + "complete the forecast";
            lblAddby.Text = finfo.Scaleup.ToString();
            lblExtension.Text = finfo.Extension.ToString();
            //lblOrder.Text = finfo.Order;
            lblRegression.Text = finfo.Method;
            lblWestage.Text = finfo.Westage.ToString();

            tabResult.TabPages.Remove(tabPage1);
            tabResult.TabPages.Remove(tabMax);
            BindMapeSummaryChart(finfo);

        }

        public IList<MAPEResult> CorrectMapeResultDates(IList<MAPEResult> maperesults, ForecastInfo finfo)
        {
            foreach (MAPEResult maperesult in maperesults)
            {
                DateTime date = new DateTime();
                if (maperesult.DurationDateTime.Day > 28)
                {
                    if (maperesult.DurationDateTime.Month == 12)
                        date = new DateTime(maperesult.DurationDateTime.Year + 1, 1, 01);
                    else
                        date = new DateTime(maperesult.DurationDateTime.Year, maperesult.DurationDateTime.Month + 1, 01);
                }
                else
                {
                    date = maperesult.DurationDateTime;
                }
                string duration = date.ToShortDateString();

                if (finfo.PeriodEnum == ForecastPeriodEnum.Bimonthly || finfo.PeriodEnum == ForecastPeriodEnum.Monthly)
                    duration = date.ToString("MMMM-yyyy");
                if (finfo.PeriodEnum == ForecastPeriodEnum.Quarterly)
                    duration = "Qua" + LqtUtil.GetQuarter(date).ToString() + "-" + date.Year.ToString();
                if (finfo.PeriodEnum == ForecastPeriodEnum.Yearly)
                    duration = date.Year.ToString();

                maperesult.Duration = duration;
            }
            return maperesults;
        }

        public void BuildMeapResultView(IList<MAPEResult> maperesult, ForecastInfo finfo)
        {

            DataTable Maper = new DataTable();


            IEnumerable<MAPEResult> sortedMAPE = maperesult.OrderBy(meap => meap.DurationDateTime);
            IList<MAPEResult> sortedMAPEList = sortedMAPE.ToList();

            Maper = LqtUtil.ToDataTable<MAPEResult>(CorrectMapeResultDates(sortedMAPEList, finfo));
            string x = "";
            string y = "";
            string z = "";
            if (finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
                y = Maper.Columns[4].ColumnName;//product
            else
                y = Maper.Columns[3].ColumnName;//test

            x = Maper.Columns[11].ColumnName;//duration

            z = Maper.Columns[8].ColumnName;//mape percentage value

            DataTable newDt = new DataTable();

            newDt = PivotTable.GetInversedDataTable(Maper, x, y, z, "-", false);

            gdvmeapresult.DataSource = newDt;

        }

        private void BindMapeSummaryChart(ForecastInfo finfo)
        {
            int id = -1;
            string seriesName = "";
            lqtChart2.Series["mape"].Points.Clear();

            foreach (Series s in lqtChart2.Series)
            {
                s.Points.Clear();
            }
            lqtChart2.Series.Clear();

            if (finfo.FMethodologeyEnum == MethodologyEnum.CONSUMPTION)
            {
                IList<MAPEResult> maperesult = DataRepository.GetMAPESummaryByProduct(finfo.Id);
                BuildMeapResultView(maperesult, finfo);

                foreach (MAPEResult r in maperesult)
                {
                    if (id != r.ProductId)
                    {
                        seriesName = r.ProductName;
                        lqtChart2.Series.Add(seriesName);
                        lqtChart2.Series[seriesName].ChartType = SeriesChartType.Line;
                        lqtChart2.Series[seriesName]["PointWidth"] = "0.5";
                        lqtChart2.Series[seriesName].LabelFormat = "p";
                        // lqtChart2.Series[seriesName].IsValueShownAsLabel = true;
                    }

                    lqtChart2.Series[seriesName].Points.AddXY(r.DurationDateTime, r.MapeValue);
                    id = r.ProductId;
                }

            }
            else
            {
                IList<MAPEResult> maperesult = DataRepository.GetMAPESummaryByTest(finfo.Id);
                BuildMeapResultView(maperesult, finfo);
                foreach (MAPEResult r in maperesult)
                {
                    if (id != r.TestId)
                    {
                        seriesName = r.TestName;
                        lqtChart2.Series.Add(seriesName);
                        lqtChart2.Series[seriesName].ChartType = SeriesChartType.Line;
                        lqtChart2.Series[seriesName]["PointWidth"] = "0.5";
                        lqtChart2.Series[seriesName].LabelFormat = "p";
                        // lqtChart2.Series[seriesName].IsValueShownAsLabel = false;
                    }

                    lqtChart2.Series[seriesName].Points.AddXY(r.DurationDateTime, r.MapeValue);
                    id = r.TestId;
                }
            }
            lqtChart2.Invalidate();
        }

        private void gdvmeapresult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int rowscount = gdvmeapresult.Rows.Count;
            int columnscount = gdvmeapresult.Columns.Count;

            for (int i = 0; i < rowscount; i++)
            {

                for (int j = 1; j < columnscount; j++)
                {
                    Color bgc = Color.Pink;
                    Color fgc = Color.Black;
                    if (gdvmeapresult.Rows[i].Cells[j].Value.ToString() == "-")//data not available
                    {
                        bgc = Color.Gray;
                    }
                    else
                    {
                        decimal mapevalue = decimal.Parse(gdvmeapresult.Rows[i].Cells[j].Value.ToString());
                        if (mapevalue > 25)
                            bgc = Color.FromArgb(204, 51, 51);
                        if (mapevalue < -25)
                            bgc = Color.FromArgb(114, 154, 210);
                        if (mapevalue <= 25 && mapevalue >= -25)
                            bgc = Color.White;

                    }
                    gdvmeapresult.Rows[i].Cells[j].Style.BackColor = bgc;
                    gdvmeapresult.Rows[i].Cells[j].Style.ForeColor = fgc;
                }

            }
        }

        private void gdvmeapresult_SelectionChanged(object sender, EventArgs e)
        {
            this.gdvmeapresult.ClearSelection();

        }

        private void lnkexporttoexcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;
            Excel.Range cells = xlWorkSheet.Cells;

            for (i = 1; i <= gdvmeapresult.ColumnCount; i++)
            {
                string column = gdvmeapresult.Columns[i - 1].Name;
                xlWorkSheet.Cells[2, i + 1] = column;
                cells = (Excel.Range)xlWorkSheet.Cells[2, i + 1];
                cells.Font.Bold = true;
                cells.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                cells.ColumnWidth = 15;
            }

            for (i = 2; i <= gdvmeapresult.RowCount + 1; i++)
            {
                for (j = 2; j <= gdvmeapresult.ColumnCount + 1; j++)
                {

                    DataGridViewCell cell = gdvmeapresult[j - 2, i - 2];
                    xlWorkSheet.Cells[i + 1, j] = Convert.ToString(cell.Value);

                    ////format cells
                    if (j > 2)
                    {
                        Color bgc = Color.Pink;
                        Color fgc = Color.Black;
                        if (cell.Value.ToString() == "-")//data not available
                        {
                            bgc = Color.Gray;
                        }
                        else
                        {

                            decimal mapevalue = decimal.Parse(cell.Value.ToString());
                            if (mapevalue > 25)
                                bgc = Color.Red; //Color.Black;//(204, 51, 51);
                            if (mapevalue < -25)
                                bgc = Color.Blue;//(114, 154, 210);
                            if (mapevalue <= 25 && mapevalue >= -25)
                                bgc = Color.White;

                        }

                        ((Excel.Range)xlWorkSheet.Cells[i + 1, j]).Interior.Color = System.Drawing.ColorTranslator.ToOle(bgc);
                        ((Excel.Range)xlWorkSheet.Cells[i + 1, j]).Font.Color = System.Drawing.ColorTranslator.ToOle(fgc);
                    }
                    ((Excel.Range)xlWorkSheet.Cells[i + 1, j]).Borders.Weight = Excel.XlBorderWeight.xlThin;
                    //end cell format
                }
            }


            //last row range
            Excel.Range range = xlWorkSheet.get_Range(xlWorkSheet.Cells[i + 1, 2], xlWorkSheet.Cells[i + 1, gdvmeapresult.ColumnCount + 1]);
            range.Merge(true);
            range.RowHeight = 40;
            range.WrapText = true;
            xlWorkSheet.Cells[i + 1, 2] = "Note: Red represents underforecasts (>25%), Blue represents overforecasts (<-25%)," +
                                         "Gray represents insufficient data to complete the forecast, and no field color represents an accurate forecast, within 25%.";

            //header
            Excel.Range header = xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 1]);
            header = header.EntireRow;
            for (int no = 0; no < 5; no++)
            {
                header.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);
            }

            header = xlWorkSheet.get_Range(xlWorkSheet.Cells[2, 2], xlWorkSheet.Cells[2, gdvmeapresult.ColumnCount + 1]);
            header.Value = "Forecast MAPE Result";
            header.Merge(true);
            header.Font.Underline = true;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header.RowHeight = 40;
            header.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


            xlWorkSheet.Cells[3, 2] = "Forecast Id : ";
            xlWorkSheet.Cells[3, 3] = forecastInfo.ForecastNo;
            xlWorkSheet.Cells[3, 4] = "Methodology : ";
            xlWorkSheet.Cells[3, 5] = forecastInfo.Methodology;
            xlWorkSheet.Cells[3, 6] = "Wastage % : ";
            xlWorkSheet.Cells[3, 7] = forecastInfo.Westage.ToString();

            xlWorkSheet.Cells[4, 2] = "Start Date : ";
            xlWorkSheet.Cells[4, 3] = forecastInfo.StartDate.ToShortDateString();
            xlWorkSheet.Cells[4, 4] = "Data Usage : ";
            xlWorkSheet.Cells[4, 5] = forecastInfo.DataUsage;
            xlWorkSheet.Cells[4, 6] = "Add By % : ";
            xlWorkSheet.Cells[4, 7] = forecastInfo.Scaleup.ToString();

            xlWorkSheet.Cells[5, 2] = "Period : ";
            xlWorkSheet.Cells[5, 3] = forecastInfo.Period;
            xlWorkSheet.Cells[5, 4] = "Regression Type : ";
            xlWorkSheet.Cells[5, 5] = forecastInfo.Method;
            xlWorkSheet.Cells[5, 6] = "Extension Period : ";
            xlWorkSheet.Cells[5, 7] = forecastInfo.Extension.ToString();

            //header end

            saveFileDialog1.FileName = forecastInfo.ForecastNo + ".xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                LqtUtil.releaseObject(xlWorkSheet);
                LqtUtil.releaseObject(xlWorkBook);
                LqtUtil.releaseObject(xlApp);
                MessageBox.Show("Exported Successfully!");
            }
        }
    }

	public class DialogState
	{
		public DialogResult result;
		public FileDialog dialog;


		public void ThreadProcShowDialog()
		{
			result = dialog.ShowDialog();
		}
	}
}
