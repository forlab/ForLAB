
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
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using LQT.Core.Util;
using LQT.Core.Domain;
using System.Data.OleDb;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;



namespace LQT.GUI
{
    public class LqtUtil
    {
        private static readonly string DataUsage1_Description = "I have consumption/service data from all of the sites in this forecast, I want enter this data for each sites.";
        private static readonly string DataUsage2_Description = "I have consumption/service data from some of the sites in this forecast, I want to use this data for non reported sites.";
        private static readonly string DataUsage3_Description = "I want to categorize sites in group based on level and testing behaviors and enter consumption/service data for the group.";
        public static string[] Months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        
        public const string VERSION = "v1.5.0";
        public const string ASSEMBLY_VERSION = "1.5.0.*";

        public static string SoftwareVersion
        {
            get
            {
                return VERSION;
            }
        }

        public static string GetDatausageDescription(string dusage)
        {
            string description = "";
            DataUsageEnum du = (DataUsageEnum)Enum.Parse(typeof(DataUsageEnum), dusage);

            switch(du)
            {
                case DataUsageEnum.DATA_USAGE1:
                    description = DataUsage1_Description;
                    break;
                case DataUsageEnum.DATA_USAGE2:
                    description = DataUsage2_Description;
                    break;
                case DataUsageEnum.DATA_USAGE3:
                    description = DataUsage3_Description;
                    break;
            }

            return description;
        }

        public static int ConvertToInt(decimal val)
        {
            int x = Convert.ToInt32(val);
            if (x < val)
                return x + 1;
            return x;
        }

        public static decimal GetAdjustedVolume(decimal reported, int dos, ForecastPeriodEnum period,decimal workingdays)
        {
            decimal y = 0;
            if (period == ForecastPeriodEnum.Monthly)
                y = workingdays;
            if (period == ForecastPeriodEnum.Bimonthly)
                y = workingdays * 2;
            if (period == ForecastPeriodEnum.Quarterly)
                y = workingdays * 3;
            if (period == ForecastPeriodEnum.Yearly)
                y = workingdays * 12;

            return Math.Round(((reported * y) / (y-dos)), 2, MidpointRounding.ToEven);
        }

        public static T GetComboBoxValue<T>(ComboBox com)
        {
            if (com.SelectedIndex >= 0)
            {
                return (com.DataSource as IList<T>)[com.SelectedIndex];
            }
            return default(T);
        }

        public static void AddItemToGroup(ListView lv, ListViewItem li)
        {
            bool gcreated = false;
            LQTListViewTag tag = (LQTListViewTag)li.Tag;
            
            foreach (ListViewGroup group in lv.Groups)
            {
                if (group.Header == tag.GroupTitle)
                { 
                    ((LQTListViewTag)li.Tag).GroupIndex = group.Items.Count;
                    li.Group = group;                   
                    gcreated = true;
                    break;
                }
            }

            if (!gcreated)
            {
                //tag.GroupId = lv.Groups.Count + 1;
                ListViewGroup group = new ListViewGroup(tag.GroupId.ToString(),tag.GroupTitle);

                lv.Groups.Add(group);
                li.Group = group;
            }
        }

        public static DataSet ReadExcelFile(string fpath, int noColumn)
        {
            string connectionString = String.Format(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;""", fpath);

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DbDataAdapter adapter = factory.CreateDataAdapter();
            DbCommand selectCommand = factory.CreateCommand();
            selectCommand.CommandText = "Select * From [" + PickSheet(fpath) + "]";
            DbConnection connection = factory.CreateConnection();
            DataSet ds = new DataSet();
            bool empty;

            try
            {
                connection.ConnectionString = connectionString;
                selectCommand.Connection = connection;
                adapter.SelectCommand = selectCommand;
                adapter.Fill(ds, "Consumption");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    empty = true;

                    foreach (DataColumn col in ds.Tables[0].Columns)
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i][col].ToString().Trim()))
                            empty = false;

                    if (empty)
                        ds.Tables[0].Rows[i].Delete();
                }

                ds.Tables[0].AcceptChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            int colcount = ds.Tables[0].Columns.Count;

            if (noColumn > colcount)
                throw new Exception("Imported excel file has less columns than needed.");
            if (noColumn < colcount)
                throw new Exception("Imported excel file has too many columns.");
            if (ds.Tables[0].Rows.Count == 0)
                throw new Exception("Imported excel is empty.");
            return ds;
        }

        public static DataSet ReadExcelFileforecast(string fpath, int noColumn)
        {
            string connectionString = String.Format(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;""", fpath);

            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DbDataAdapter adapter = factory.CreateDataAdapter();
            DbCommand selectCommand = factory.CreateCommand();
            selectCommand.CommandText = "Select * From [" + PickSheet(fpath) + "]";
            DbConnection connection = factory.CreateConnection();
            DataSet ds = new DataSet();
            bool empty;

            try
            {
                connection.ConnectionString = connectionString;
                selectCommand.Connection = connection;
                adapter.SelectCommand = selectCommand;
                adapter.Fill(ds, "Consumption");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    empty = true;

                    foreach (DataColumn col in ds.Tables[0].Columns)
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i][col].ToString().Trim()))
                            empty = false;

                    if (empty)
                        ds.Tables[0].Rows[i].Delete();
                }

                ds.Tables[0].AcceptChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            int colcount = ds.Tables[0].Columns.Count;

            //if (noColumn > colcount)
            //    throw new Exception("Imported excel file has less columns than needed.");
            //if (noColumn < colcount)
            //    throw new Exception("Imported excel file has too many columns.");
            if (ds.Tables[0].Rows.Count == 0)
                throw new Exception("Imported excel is empty.");
            return ds;
        }
        public static string PickSheet(string excelFile)
        {
            OleDbConnection objConn = null;
            DataTable dt = null;
            String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";

            objConn = new OleDbConnection(connString);

            objConn.Open();

            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            List<String> excelSheets = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                excelSheets.Add(row["TABLE_NAME"].ToString());
            }

            objConn.Close();
            objConn.Dispose();

            FrmSelectSheet frmSelectSheet = new FrmSelectSheet(excelSheets);
            DialogResult dr = frmSelectSheet.ShowDialog();

            if (dr == DialogResult.OK)
                return frmSelectSheet.SelectedSheet;

            return "$Sheet1";
        }

        public static int GetQuarter(DateTime d)
        {
            int qua;
            if (d.Month <= 3)
                qua = 1;
            else if (d.Month <= 6)
                qua = 2;
            else if (d.Month <= 9)
                qua = 3;
            else
                qua = 4;

            return qua;
        }
        
        public static int GetQuarter(string qtext)
        {
                int q = 0;
                switch (qtext)
                {
                    case "Qua1":
                        q = 1;
                        break;
                    case "Qua2":
                        q = 4;
                        break;
                    case "Qua3":
                        q = 7;
                        break;
                    case "Qua4":
                        q = 10;
                        break;
                }
                return q;
        }

        private static int GetMonth(string mname)
        {
            for (int i = 0; i < 12; i++)
            {
                if (Months[i] == mname)
                    return i + 1;
            }
            return 1;
        }

        public static DateTime DurationToDateTime(string duration)
        {
            string[] s = duration.Split(new char[] { '-' });
            DateTime d;
            if (s.Length == 1)
                d = new DateTime(int.Parse(duration),1,1);
            else if(s[0].StartsWith("Q"))
                d= new DateTime(int.Parse(s[1]), GetQuarter(s[0]),1);
            else 
                d= new DateTime(int.Parse(s[1]), GetMonth(s[0]),1);

            return d;
        }

        

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static T[] EnumToArray<T>()
        {
            Type enumType = typeof(T);
            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be a System.Enum");
            }
            return (Enum.GetValues(enumType) as IEnumerable<T>).ToArray();
        }

        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static string GetFolderPath(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            return path;
        }

        public static DateTime CorrectDateTime(DateTime durationdt)
        {
            DateTime date = new DateTime();
            if (durationdt.Day > 24)
            {
                if (durationdt.Month == 12)
                    date = new DateTime(durationdt.Year + 1, 1, 01);
                else
                    date = new DateTime(durationdt.Year, durationdt.Month + 1, 01);
            }
            else
            {
                date = durationdt;
            }
            return date;
        }

        public static bool IsDateTime(string datestring)
        {
            DateTime tempDate;

            return DateTime.TryParse(datestring, out tempDate) ? true : false;
        }

        public static string DatetimeToDurationStr(ForecastPeriodEnum PeriodEnum, DateTime date)
        {
            string CDuration=string.Empty;
            if (PeriodEnum == ForecastPeriodEnum.Bimonthly||PeriodEnum == ForecastPeriodEnum.Monthly)
            {

                CDuration = String.Format("{0}-{1}", LqtUtil.Months[date.Month - 1], date.Year);
            }
            else if (PeriodEnum == ForecastPeriodEnum.Quarterly)
            {
                CDuration = String.Format("Qua{0}-{1}", GetQuarter(date), date.Year);
            }
            else if (PeriodEnum == ForecastPeriodEnum.Yearly)//b
            {
                CDuration = date.Year.ToString();
            }
            return CDuration;
        }

        public static bool validDate(string duration, ForecastPeriodEnum period)
        {
            string[] s = duration.Split(new char[] { '-' });
            bool hasError = false;

            try
            {
                if (duration.StartsWith("Q") && ((period == ForecastPeriodEnum.Monthly) || (period == ForecastPeriodEnum.Bimonthly)))
                {
                    hasError = true;
                }
                else if (s.Length == 1 && ((period == ForecastPeriodEnum.Monthly) || (period == ForecastPeriodEnum.Bimonthly) || (period == ForecastPeriodEnum.Quarterly)))
                {
                    hasError = true;
                }


            }
            catch
            {
                hasError = true;
            }
            return hasError;

        }

        public static string GetNODataValue(string sval)
        {
            if (sval == "-")
                sval = "0";
            return sval;
        }


        public static string RemoveWhitespace(string input)
        {
            // return new string(input.ToCharArray()
            //   .Where(c => !Char.IsWhiteSpace(c))
            //   .ToArray());
            return Regex.Replace(input, @"\s+", "");
        }

        public static bool ValidDownTime(int downtime, ForecastPeriodEnum period, decimal workingdays)
        {
            decimal y = 0;
            if (period == ForecastPeriodEnum.Monthly)
                y = workingdays;
            if (period == ForecastPeriodEnum.Bimonthly)
                y = workingdays * 2;
            if (period == ForecastPeriodEnum.Quarterly)
                y = workingdays * 3;
            if (period == ForecastPeriodEnum.Yearly)
                y = workingdays * 12;


            if (downtime > y)
                return false;

            return true;

        }
    }


    public class CreateOrUpdateEventArgs : EventArgs
    {
        private object _obj;

        public CreateOrUpdateEventArgs(object obj)
        {
            _obj = obj;
        }

        public object GetCreatedOrUpdateObject
        {
            get { return _obj; }
        }
    }

    public class LqtListViewGroupSelectedEventArgs : EventArgs
    {
        private IList<ChartXYValue> _xyvalue;
        private string _title;

        public LqtListViewGroupSelectedEventArgs(IList<ChartXYValue> xyvlues, string title)
        {
            _xyvalue = xyvlues;
            _title = title;
        }

        public IList<ChartXYValue> GetChartXYvalue
        {
            get { return _xyvalue; }
        }

        public string Title
        {
            get { return _title; }
        }

       
    }

    public class ChartXYValue : System.IComparable
    {
        public string XValue;
        public decimal YValue;

       
        #region IComparable Members
        public int CompareTo(object obj)
        {
            if (obj is ChartXYValue)
            { 
                ChartXYValue chartXYValue = (ChartXYValue)obj;
                return LqtUtil.DurationToDateTime(this.XValue).CompareTo(LqtUtil.DurationToDateTime(chartXYValue.XValue));
                //return 1;
            }
            throw new ArgumentException("This object is not of type ChartXYValue");
        }
        #endregion
    }

    public class LQTListViewTag
    {
        public string GroupTitle;
        public int Id;
        public int Index;
        public int GroupIndex;
        public int GroupId;
    }

    public class ReportedData
    {
        private string _categoryName;
        private ForecastCategory _category;
        private string _regionName;
        private ForlabRegion _region;
        private string _siteName;
        private ForlabSite _site;
        private string _productName;
        private MasterProduct _product;
        private string _testname;
        private Test _test;
        private string _duration;
        private decimal _amount;
        private int _stockout;
        private int _instrumentDownTime;
        private int _rowno;
        private bool _hasError;
        private DateTime? _openingDate;
        private DateTime? _closingDate;
        private string errorDescription;

        private ReportedData()
        {
        }

        public ReportedData(int rowno, string rname, string sname, string pname, string duration, decimal amount, int stockout, int instrumentDownTime)
        {
            this._rowno = rowno;
            this._regionName = rname;
            this._siteName = sname;
            this._productName = pname;
            this._duration = duration;
            this._amount = amount;
            this._stockout = stockout;
            this._instrumentDownTime = instrumentDownTime;
            this._hasError = false;
        }


        public ReportedData(string rname, int rowno, string sanme, string testname, string duration, decimal amount, int stockout, int instrumentDownTime)
        {
            this._regionName = rname;
            this._siteName = sanme;
            this._rowno = rowno;
            this._testname = testname;
            this._duration = duration;
            this._amount = amount;
            this._stockout = stockout;
            this._instrumentDownTime = instrumentDownTime;
            this._hasError = false;
        }
        public ReportedData(int rowno, string catname, string pname, string duration, decimal amount, int stockout, int instrumentDownTime)
        {
            this._categoryName = catname;
            this._rowno = rowno;
            this._productName = pname;
            this._duration = duration;
            this._amount = amount;
            this._stockout = stockout;
            this._instrumentDownTime = instrumentDownTime;
            this._hasError = false;
        }

        public ReportedData(string catname, int rowno, string testname, string duration, decimal amount, int stockout, int instrumentDownTime)
        {
            this._categoryName = catname;
            this._rowno = rowno;
            this._testname = testname;
            this._duration = duration;
            this._amount = amount;
            this._stockout = stockout;
            this._instrumentDownTime = instrumentDownTime;
            this._hasError = false;
        }
        public string CategoryName
        {
            get { return _categoryName; }
        }
        
        public ForecastCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string RegionName
        {
            get { return _regionName; }
        }

        public ForlabRegion Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public string SiteName
        {
            get { return _siteName; }
        }
        public ForlabSite Site
        {
            get { return _site; }
            set { _site = value; }
        }
        
        public string ProductName
        {
            get { return _productName; }
        }

        public MasterProduct Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public string TestName
        {
            get { return _testname; }
        }
        public Test Test
        {
            get { return _test; }
            set { _test = value; }
        }

        
        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public decimal Amount
        {
            get { return _amount; }
        }
        public int StockOut
        {
            get { return _stockout; }
        }
        public int InstrumentDownTime
        {
            get { return _instrumentDownTime; }
        }
       
        public int RowNo
        {
            get { return _rowno; }
        }

        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        public DateTime? OpeningDate
        {
            get { return _openingDate; }
            set { _openingDate = value; }
        }

        public DateTime? ClosingDate
        {
            get { return _closingDate; }
            set { _closingDate = value; }
        }
        public string ErrorDescription
        {
            get { return errorDescription; }
            set { errorDescription = value; }
        }
    }

    public class ForecastSummaryData
    {
        private decimal _noofTest;
        private string _testingArea;
        private string _duration;
        private DateTime _durationDataTime;

        private ForecastSummaryData()
        {

        }

        public ForecastSummaryData(decimal nooftest,string testingarea,string duration,DateTime durationdatetime)
        {
            _noofTest = nooftest;
            _testingArea = testingarea;
            _duration = duration;
            _durationDataTime = durationdatetime;
        }

        public decimal NoOfTest
        {
            get { return _noofTest; }
            set { _noofTest = value; }
        }
        public string TestingArea
        {
            get { return _testingArea; }
            set { _testingArea = value; }
        }
        public string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        public DateTime DurationDateTime
        {
            get { return _durationDataTime; }
            set { _durationDataTime = value; }
        }


    }

    public static class EnumExtensions
    {
        public static string Description(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var field = enumType.GetField(enumValue.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0
                ? enumValue.ToString()
                : ((DescriptionAttribute)attributes[0]).Description;
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class InstrumentPerTA
    {
        public int _qty;
        public decimal _totalTestDone;
        public TestingArea _testingArea;

        public int Quantity
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public TestingArea TestingArea
        {
            get { return _testingArea; }
            set { _testingArea = value; }
        }
        public decimal TotalTestDone
        {
            get { return _totalTestDone; }
            set { _totalTestDone = value; }

        }


    }
}
