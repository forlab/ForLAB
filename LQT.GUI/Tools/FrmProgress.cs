
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
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Configuration;

using LQT.Core;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using View = Microsoft.SqlServer.Management.Smo.View;
using System.Diagnostics;

namespace LQT.GUI.Tools
{
    public partial class FrmProgress : Form
    {
        delegate void SetProgressBarCallBack(int value);
        SetProgressBarCallBack _setProgressValue;
        delegate void SetTextCallBack(int value);
        SetTextCallBack _setProgressText;
        StringBuilder _sbScript = new StringBuilder();
        bool _workCompletedWithoutError;
        //EventLog myLog = new EventLog();

        public FrmProgress()
        {
            InitializeComponent();

            _setProgressText = SetProgressBarText;
            _setProgressValue = SetProgressBarValue;
            
            //myLog.Source = "ForLABLog";
        }

        private void SetProgressBarValue(int value)
        {
            //myLog.WriteEntry("--2--");
            if (this.progressBar1.InvokeRequired)
            {

                this.Invoke(_setProgressValue, new object[] { value });
            }
            else
                this.progressBar1.Value = value;
        }

        private void SetProgressBarText(int value)
        {
            //myLog.WriteEntry("--1--");
            if (this.lqtProgressBar1.InvokeRequired)
                this.Invoke(_setProgressText, new object[] { value });
            else
            {
                this.lqtProgressBar1.Text = String.Format("{0} / 5", value);
                lqtProgressBar1.PerformStep();
            }
        }

        private void ProgressBarPerformStep()
        {
            this.Invoke(new MethodInvoker(() => progressBar1.PerformStep()));
        }

        private void bwCalculation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (_workCompletedWithoutError)
            {
                lblProgress.Text = "All tasks done.";
                
                SaveSqlToFile(_sbScript);
                _sbScript = null;
                MessageBox.Show("Generate Scripting Database completed.", "Generate Script", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            this.Close();
        }

        public void InitializeTimer()
        {
            //myLog.WriteEntry("--timer started--");
            timer1.Enabled = true;
            lblProgress.Text = "Initializing...";            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //myLog.WriteEntry("--timer tick started--");
            timer1.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            progressBar1.Minimum = 0;
            progressBar1.Step = 1;

            lqtProgressBar1.Value = 0;
            lqtProgressBar1.Step = 20;
            //myLog.WriteEntry("--check if bw is busy--"+bwCalculation.IsBusy.ToString());
            if (bwCalculation.IsBusy != true)
            {
                //myLog.WriteEntry("--bw called--");
                try
                {
                    bwCalculation.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    //myLog.WriteEntry("--exception in bwCalculation--"+ex.StackTrace+ex.Message+ex.InnerException);
                }
            }
        }
        

        private string ScriptObject(Urn[] urns, Scripter scripter)
        {
            StringCollection sc = scripter.Script(urns);

            var sb = new StringBuilder();
            foreach (string str in sc)
            {
                sb.Append(str + Environment.NewLine + "GO" + Environment.NewLine + Environment.NewLine);
            }

            return sb.ToString();

        }

        protected void ScriptingProgressEventHandler(object sender, ProgressReportEventArgs e)
        {
            if (e.Current.XPathExpression.Length > 2)
            {   
                this.Invoke(new MethodInvoker(delegate
                {
                   lblProgress.Text = e.Current.XPathExpression[2].GetAttributeFromFilter("Name") + Environment.NewLine;
                }));
            }
        }

        private void bwCalculation_DoWork(object sender, DoWorkEventArgs e)
        {
            _workCompletedWithoutError = false;
            var conn = new ServerConnection(ConnectionManager.GetInstance().GetSqlConnection());
            //myLog.WriteEntry("--connection--"+conn.ToString());
            try
            {
                _sbScript = new StringBuilder();
                var server = new Server(conn);
                //myLog.WriteEntry("--server initalized--" + server.ToString());
                var db = server.Databases[AppSettings.DatabaseName];
                //myLog.WriteEntry("--get db--" + db.ToString());
                //myLog.WriteEntry("--sp contain check--" + db.StoredProcedures.Contains("sp_generate_inserts").ToString());
                if (!db.StoredProcedures.Contains("sp_generate_inserts"))
                {
                   // myLog.WriteEntry("--get into spgenerate and call SpGenerate--" );
                    try
                    {
                        db.ExecuteNonQuery(SpGenerate());
                    }
                    catch(Exception ex)
                    {
                        //myLog.WriteEntry("--error on excute SpGenerate()--"+ex.Message+"--trace--"+ex.StackTrace+"--spgenerate out--"+SpGenerate());
                    }
                        
                }

                var scripter = new Scripter(server);
                //myLog.WriteEntry("--scripter initalized--" + scripter.ToString());
                scripter.ScriptingProgress += new ProgressReportEventHandler(ScriptingProgressEventHandler);

                var so = new ScriptingOptions
                {
                    IncludeIfNotExists = false,
                    IncludeHeaders = false,
                    Permissions = false,
                    ExtendedProperties = false,
                    ScriptDrops = false,
                    IncludeDatabaseContext = false,
                    NoCollation = false,
                    NoFileGroup = false,
                    NoIdentities = false,
                    TargetServerVersion = SqlServerVersion.Version90
                };

                scripter.Options = so;

                SetProgressBarText(1);
                SetProgressBarValue(0);
                //myLog.WriteEntry("--scripter options set--" + scripter.Options.ToString());
                
                this.Invoke(new MethodInvoker(() => progressBar1.Maximum = db.Tables.Count));
                server.SetDefaultInitFields(typeof (Table), "IsSystemObject");
                //myLog.WriteEntry("--init start looping tables--");
                foreach (Table tb in db.Tables)
                {
                    //myLog.WriteEntry("--start looping tables--" + tb.Name);
                    ProgressBarPerformStep();
                    if (!tb.IsSystemObject)
                    {
                        _sbScript.Append(ScriptObject(new Urn[] {tb.Urn}, scripter));
                    }
                }
                
                

                SetProgressBarValue(0);
                SetProgressBarText(2);
                this.Invoke(new MethodInvoker(() => progressBar1.Maximum = db.UserDefinedFunctions.Count));
                server.SetDefaultInitFields(typeof (UserDefinedFunction), "IsSystemObject");
                foreach (UserDefinedFunction udf in db.UserDefinedFunctions)
                {
                    ProgressBarPerformStep();
                    if (!udf.IsSystemObject)
                    {
                        _sbScript.Append(ScriptObject(new Urn[] {udf.Urn}, scripter));
                    }
                }

                SetProgressBarValue(0);
                SetProgressBarText(3);
                this.Invoke(new MethodInvoker(() => progressBar1.Maximum = db.StoredProcedures.Count));
                server.SetDefaultInitFields(typeof (StoredProcedure), "IsSystemObject");
                foreach (StoredProcedure sp in db.StoredProcedures)
                {
                    ProgressBarPerformStep();
                    if (!sp.IsSystemObject)
                    {
                        _sbScript.Append(ScriptObject(new Urn[] {sp.Urn}, scripter));
                    }
                }

                SetProgressBarValue(0);
                SetProgressBarText(4);
                this.Invoke(new MethodInvoker(delegate
                {
                    lblProgress.Text = "Script Views";
                }));
                server.SetDefaultInitFields(typeof (Microsoft.SqlServer.Management.Smo.View), "IsSystemObject");
                List<SqlSmoObject> views = db.Views.Cast<View>().Cast<SqlSmoObject>().ToList();
                var sviews = SortViews(db, views);
                this.Invoke(new MethodInvoker(() => progressBar1.Maximum = sviews.Count));
                foreach (var v in sviews)
                {
                    ProgressBarPerformStep();
                    if (!v.IsSystemObject)
                    {
                        _sbScript.Append(ScriptObject(new Urn[] {v.Urn}, scripter));
                    }
                }

                SetProgressBarText(5);
                this.Invoke(new MethodInvoker(() => lblProgress.Text = "Execute Generate Insert Data"));
                GenereateData(db, scripter, _sbScript);
                
                _workCompletedWithoutError = true;
            }
            catch (Exception err)
            {
                //myLog.WriteEntry("--/   /--" + err.ToString());
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Disconnect();
            }
        }

        private static List<View> SortViews(Database db, List<SqlSmoObject> sso)
        {
            var dw = new DependencyWalker(db.Parent);
            var dt = new DependencyTree(dw.DiscoverDependencies(sso.ToArray(), true));

            var views = new List<View>();
            
            foreach (var d in dw.WalkDependencies(dt))
            {
                if (d.Urn.Type != "View") 
                    continue;
                var o = db.Views[d.Urn.GetNameForType(d.Urn.Type)];
                if (o != null)
                    views.Add(db.Views[d.Urn.GetNameForType(d.Urn.Type)]);
            }

            return views;
        }

        private static void GenereateData(Database db, Scripter scripter, StringBuilder sbScript)
        {
            var tbls = new Table[db.Tables.Count];
            db.Tables.CopyTo(tbls, 0);
            var tree = scripter.DiscoverDependencies(tbls, true);
            var depwalker = new DependencyWalker();
            var depcoll = depwalker.WalkDependencies(tree);
            var sb = new StringBuilder();
            //progressBar1.Maximum = sviews.Count;
            foreach (DependencyCollectionNode dep in depcoll)
            {
                var o = db.Tables[dep.Urn.GetAttribute("Name")];
                if (o != null && !o.IsSystemObject)
                    sb.AppendFormat("EXEC sp_generate_inserts @table_name='{0}', @owner='dbo'{1}", dep.Urn.GetAttribute("Name"), Environment.NewLine);
            }

            DataSet dset = db.ExecuteWithResults(sb.ToString());
            foreach (DataTable dt in dset.Tables)
            {
                
                foreach (DataRow dr in dt.Rows)
                {
                    sbScript.AppendLine(dr[0].ToString());
                }
            }
        }

        private void SaveSqlToFile(StringBuilder sb)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "SQL File|*.sql",
                FileName = DateTime.Now.Ticks + ".sql",
                Title = "Save SQL File",
                InitialDirectory = "%USERPROFILE%\\Documents",
                DefaultExt = ".sql",
                AddExtension = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                var filepath = sfd.FileName;

                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }

                using (var fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.Write(sb.ToString());
                        sw.Close();
                    }
                }

                this.Cursor = Cursors.Default;
            }
        }

        private string SpGenerate()
        {
            string spg = @"CREATE PROC [dbo].[sp_generate_inserts](
                         @table_name varchar(776), @target_table varchar(776) = NULL,
                         @include_column_list bit = 1, @from varchar(800) = NULL, 	
                         @include_timestamp bit = 0, @debug_mode bit = 0, @owner varchar(64) = NULL,
                         @ommit_images bit = 0, @ommit_identity bit = 0,	@top int = NULL, 
                         @cols_to_include varchar(8000) = NULL, @cols_to_exclude varchar(8000) = NULL,
                         @disable_constraints bit = 0, @ommit_computed_cols bit = 0,	@enable_identiy_insert bit = 0)
                         AS
                         BEGIN 
                         SET NOCOUNT ON
                         IF ((@cols_to_include IS NOT NULL) AND (@cols_to_exclude IS NOT NULL))
	BEGIN
		RAISERROR('Use either @cols_to_include or @cols_to_exclude. Do not use both the parameters at once',16,1)
		RETURN -1
	END

IF ((@cols_to_include IS NOT NULL) AND (PATINDEX('''%''',@cols_to_include) = 0))
	BEGIN
		RAISERROR('Invalid use of @cols_to_include property',16,1)
		RETURN -1
	END

IF ((@cols_to_exclude IS NOT NULL) AND (PATINDEX('''%''',@cols_to_exclude) = 0))
	BEGIN
		RAISERROR('Invalid use of @cols_to_exclude property',16,1)
		RETURN -1
	END


IF (PARSENAME(@table_name,3)) IS NOT NULL
	BEGIN
		RAISERROR('Do not specify the database name. Be in the required database and just specify the table name.',16,1)
		RETURN -1 
	END


IF @owner IS NULL
	BEGIN
		IF ((OBJECT_ID(@table_name,'U') IS NULL) AND (OBJECT_ID(@table_name,'V') IS NULL)) 
			BEGIN
				RAISERROR('User table or view not found.',16,1)
				RETURN -1 
			END
	END
ELSE
	BEGIN
		IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @table_name AND (TABLE_TYPE = 'BASE TABLE' OR TABLE_TYPE = 'VIEW') AND TABLE_SCHEMA = @owner)
			BEGIN
				RAISERROR('User table or view not found.',16,1)
				RETURN -1 
			END
	END

DECLARE		@Column_ID int, 		
		@Column_List varchar(8000), 
		@Column_Name varchar(128), 
		@Start_Insert varchar(786), 
		@Data_Type varchar(128), 
		@Actual_Values varchar(max), 	
		@IDN varchar(128)		

--Variable Initialization
SET @IDN = ''
SET @Column_ID = 0
SET @Column_Name = ''
SET @Column_List = ''
SET @Actual_Values = ''

IF @owner IS NULL 
	BEGIN
		SET @Start_Insert = 'INSERT INTO ' + '[' + RTRIM(COALESCE(@target_table,@table_name)) + ']' 
	END
ELSE
	BEGIN
		SET @Start_Insert = 'INSERT ' + '[' + LTRIM(RTRIM(@owner)) + '].' + '[' + RTRIM(COALESCE(@target_table,@table_name)) + ']' 		
	END


SELECT	@Column_ID = MIN(ORDINAL_POSITION) 	
FROM	INFORMATION_SCHEMA.COLUMNS (NOLOCK) 
WHERE 	TABLE_NAME = @table_name AND
(@owner IS NULL OR TABLE_SCHEMA = @owner)



WHILE @Column_ID IS NOT NULL
	BEGIN
		SELECT 	@Column_Name = QUOTENAME(COLUMN_NAME), 
		@Data_Type = DATA_TYPE 
		FROM 	INFORMATION_SCHEMA.COLUMNS (NOLOCK) 
		WHERE 	ORDINAL_POSITION = @Column_ID AND 
		TABLE_NAME = @table_name AND
		(@owner IS NULL OR TABLE_SCHEMA = @owner)



		IF @cols_to_include IS NOT NULL 
		BEGIN
			IF CHARINDEX( '''' + SUBSTRING(@Column_Name,2,LEN(@Column_Name)-2) + '''',@cols_to_include) = 0 
			BEGIN
				GOTO SKIP_LOOP
			END
		END

		IF @cols_to_exclude IS NOT NULL 
		BEGIN
			IF CHARINDEX( '''' + SUBSTRING(@Column_Name,2,LEN(@Column_Name)-2) + '''',@cols_to_exclude) <> 0 
			BEGIN
				GOTO SKIP_LOOP
			END
		END

		IF (SELECT COLUMNPROPERTY( OBJECT_ID(QUOTENAME(COALESCE(@owner,USER_NAME())) + '.' + @table_name),SUBSTRING(@Column_Name,2,LEN(@Column_Name) - 2),'IsIdentity')) = 1 
		BEGIN
			SET @enable_identiy_insert = 1
			IF @ommit_identity = 0 
				SET @IDN = @Column_Name
			ELSE
				GOTO SKIP_LOOP			
		END
		
		IF @ommit_computed_cols = 1
		BEGIN
			IF (SELECT COLUMNPROPERTY( OBJECT_ID(QUOTENAME(COALESCE(@owner,USER_NAME())) + '.' + @table_name),SUBSTRING(@Column_Name,2,LEN(@Column_Name) - 2),'IsComputed')) = 1 
			BEGIN
				GOTO SKIP_LOOP					
			END
		END
		
		
		IF(@Data_Type in ('image'))
			BEGIN
				IF (@ommit_images = 0)
					BEGIN
						RAISERROR('Tables with image columns are not supported.',16,1)
						RETURN -1
					END
				ELSE
					BEGIN
					GOTO SKIP_LOOP
					END
			END

		SET @Actual_Values = @Actual_Values  +
		CASE 
			WHEN @Data_Type IN ('char','varchar','nchar','nvarchar') 
				THEN 
					'COALESCE('''''''' + REPLACE(RTRIM(' + @Column_Name + '),'''''''','''''''''''')+'''''''',''NULL'')'
			WHEN @Data_Type IN ('datetime','smalldatetime') 
				THEN 
					'COALESCE('''''''' + RTRIM(CONVERT(char,' + @Column_Name + ',109))+'''''''',''NULL'')'
			WHEN @Data_Type IN ('uniqueidentifier') 
				THEN  
					'COALESCE('''''''' + REPLACE(CONVERT(char(255),RTRIM(' + @Column_Name + ')),'''''''','''''''''''')+'''''''',''NULL'')'
			WHEN @Data_Type IN ('text','ntext') 
				THEN  
					'COALESCE('''''''' + REPLACE(CONVERT(char(8000),' + @Column_Name + '),'''''''','''''''''''')+'''''''',''NULL'')'					
			WHEN @Data_Type IN ('binary','varbinary') 
				THEN  
					'COALESCE(RTRIM(CONVERT(char,' + 'CONVERT(int,' + @Column_Name + '))),''NULL'')'  
			WHEN @Data_Type IN ('timestamp','rowversion') 
				THEN  
					CASE 
						WHEN @include_timestamp = 0 
							THEN 
								'''DEFAULT''' 
							ELSE 
								'COALESCE(RTRIM(CONVERT(char,' + 'CONVERT(int,' + @Column_Name + '))),''NULL'')'  
					END
			WHEN @Data_Type IN ('float','real','money','smallmoney')
				THEN
					'COALESCE(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @Column_Name  + ',2)' + ')),''NULL'')' 
			ELSE 
				'COALESCE(LTRIM(RTRIM(' + 'CONVERT(char, ' +  @Column_Name  + ')' + ')),''NULL'')' 
		END   + '+' +  ''',''' + ' + '
		
		SET @Column_List = @Column_List +  @Column_Name + ','	

		SKIP_LOOP: 

		SELECT 	@Column_ID = MIN(ORDINAL_POSITION) 
		FROM 	INFORMATION_SCHEMA.COLUMNS (NOLOCK) 
		WHERE 	TABLE_NAME = @table_name AND 
		ORDINAL_POSITION > @Column_ID AND
		(@owner IS NULL OR TABLE_SCHEMA = @owner)

	END

SET @Column_List = LEFT(@Column_List,len(@Column_List) - 1)
SET @Actual_Values = LEFT(@Actual_Values,len(@Actual_Values) - 6)

IF LTRIM(@Column_List) = '' 
	BEGIN
		RAISERROR('No columns to select. There should at least be one column to generate the output',16,1)
		RETURN -1 
	END

IF (@include_column_list <> 0)
	BEGIN
		SET @Actual_Values = 
			'SELECT ' +  
			CASE WHEN @top IS NULL OR @top < 0 THEN '' ELSE ' TOP ' + LTRIM(STR(@top)) + ' ' END + 
			'''' + RTRIM(@Start_Insert) + 
			' ''+' + '''(' + RTRIM(@Column_List) +  '''+' + ''')''' + 
			' +''VALUES(''+ ' +  @Actual_Values  + '+'')''' + ' ' + 
			COALESCE(@from,' FROM ' + CASE WHEN @owner IS NULL THEN '' ELSE '[' + LTRIM(RTRIM(@owner)) + '].' END + '[' + rtrim(@table_name) + ']' + '(NOLOCK)')
	END
ELSE IF (@include_column_list = 0)
	BEGIN
		SET @Actual_Values = 
			'SELECT ' + 
			CASE WHEN @top IS NULL OR @top < 0 THEN '' ELSE ' TOP ' + LTRIM(STR(@top)) + ' ' END + 
			'''' + RTRIM(@Start_Insert) + 
			' '' +''VALUES(''+ ' +  @Actual_Values + '+'')''' + ' ' + 
			COALESCE(@from,' FROM ' + CASE WHEN @owner IS NULL THEN '' ELSE '[' + LTRIM(RTRIM(@owner)) + '].' END + '[' + rtrim(@table_name) + ']' + '(NOLOCK)')
	END	

IF (@IDN <> '')
	BEGIN
		SELECT 'SET IDENTITY_INSERT ' + QUOTENAME(COALESCE(@owner,USER_NAME())) + '.' + QUOTENAME(@table_name) + ' ON'
	END

IF @disable_constraints = 1 AND (OBJECT_ID(QUOTENAME(COALESCE(@owner,USER_NAME())) + '.' + @table_name, 'U') IS NOT NULL)
	BEGIN
		IF @owner IS NULL
			BEGIN
				SELECT 	'ALTER TABLE ' + QUOTENAME(COALESCE(@target_table, @table_name)) + ' NOCHECK CONSTRAINT ALL' AS '--Code to disable constraints temporarily'
			END
		ELSE
			BEGIN
				SELECT 	'ALTER TABLE ' + QUOTENAME(@owner) + '.' + QUOTENAME(COALESCE(@target_table, @table_name)) + ' NOCHECK CONSTRAINT ALL' AS '--Code to disable constraints temporarily'
			END
	END

EXEC (@Actual_Values)

IF @disable_constraints = 1 AND (OBJECT_ID(QUOTENAME(COALESCE(@owner,USER_NAME())) + '.' + @table_name, 'U') IS NOT NULL)
	BEGIN
		IF @owner IS NULL
			BEGIN
				SELECT 	'ALTER TABLE ' + QUOTENAME(COALESCE(@target_table, @table_name)) + ' CHECK CONSTRAINT ALL'  AS '--Code to enable the previously disabled constraints'
			END
		ELSE
			BEGIN
				SELECT 	'ALTER TABLE ' + QUOTENAME(@owner) + '.' + QUOTENAME(COALESCE(@target_table, @table_name)) + ' CHECK CONSTRAINT ALL' AS '--Code to enable the previously disabled constraints'
			END
	END


IF (@IDN <> '')
	BEGIN
		SELECT 'SET IDENTITY_INSERT ' + QUOTENAME(COALESCE(@owner,USER_NAME())) + '.' + QUOTENAME(@table_name) + ' OFF'
	END

SET NOCOUNT OFF
RETURN 0 
END

GO";
            return spg;
        }
    }
}
