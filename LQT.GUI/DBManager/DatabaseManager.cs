
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
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Security.AccessControl;
using System.Reflection;
using LQT.Core;

namespace LQT.GUI
{
    public class DatabaseManager
    {
        private const string UPDATEDATABASE = "Database_Update_{0}_to_{1}.sql";
        private const string CREATEDATABASE = "CreateDatabase_{0}.sql";
        private const string INITIAL_DATAS = "InitialData.sql";
        private const string INSERT_PRODUCTS = "InsertProducts.sql";

        public DatabaseManager()
        {
            _Init();
        }

        private void _Init()
        {
        }

        public static void CreateDatabase(string pDatabaseName, SqlConnection pSqlConnection)
        {
            string sqlText = "CREATE DATABASE " + pDatabaseName;
            SqlCommand cmd = new SqlCommand(sqlText, pSqlConnection);

            cmd.ExecuteNonQuery();
        }

        public static bool CreateDatabase(string pDatabaseName,bool defaultdata, string pScriptPath, string pDatabaseVersion)
        {
            SqlConnection connection = ConnectionManager.GeneralSqlConnection;
            return _createDatabase(pDatabaseName,defaultdata, pDatabaseVersion, pScriptPath, connection);
        }

        private static bool _createDatabase(string pDatabaseName,bool insProduct, string pDatabaseVersion, string pScriptPath, SqlConnection pSqlConnection)
        {
            try
            {
                pSqlConnection.Open();
                CreateDatabase(pDatabaseName, pSqlConnection);

                string createSqlfile = Path.Combine(pScriptPath, string.Format(CREATEDATABASE, pDatabaseVersion));
                DatabaseManager.ExecuteScript(createSqlfile, pDatabaseName, pSqlConnection);
                DatabaseManager.ExecuteScript(Path.Combine(pScriptPath, INITIAL_DATAS), pDatabaseName, pSqlConnection);

                if (insProduct)
                    DatabaseManager.ExecuteScript(Path.Combine(pScriptPath, INSERT_PRODUCTS), pDatabaseName, pSqlConnection);


                pSqlConnection.Close();
                return true;
            }
            catch
            {
                pSqlConnection.Close();
                throw;
            }
        }

        public static bool CreateDatabaseFromBackupFile(string pDatabaseName, string createSqlfile)
        {
            SqlConnection pSqlConnection = ConnectionManager.GeneralSqlConnection;
            try
            {
                pSqlConnection.Open();
                CreateDatabase(pDatabaseName, pSqlConnection);

                //string createSqlfile = Path.Combine(pScriptPath, string.Format(CREATEDATABASE, pDatabaseVersion));
                ExecuteScript(createSqlfile, pDatabaseName, pSqlConnection);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                pSqlConnection.Close();
            }
        }
        public static void ExecuteScript(string pScriptFile, string pDatabaseName, SqlConnection pSqlConnection)
        {
            List<string> queries = new List<string> { string.Format("USE [{0}]", pDatabaseName) };
            queries.AddRange(_ParseSqlFile(pScriptFile));

            foreach (string query in queries)
            {
                SqlCommand command = new SqlCommand(query, pSqlConnection) { CommandTimeout = 480 };
                command.ExecuteNonQuery();
            }
        }

        private static List<string> _ParseSqlFile(string pScriptFile)
        {
            List<string> queries = new List<string>();
            using (StreamReader reader = File.OpenText(pScriptFile))
            {
                // Parse file and get individual queries (separated by GO)
                while (!reader.EndOfStream)
                {
                    StringBuilder sb = new StringBuilder();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("GO")) break;
                        if ((!line.StartsWith("/*")) && (line.Length > 0))
                        {
                            sb.Append(line);
                            sb.Append("\n");
                        }
                    }
                    string q = sb.ToString();
                    if ((!q.StartsWith("SET QUOTED_IDENTIFIER"))
                        && (!q.StartsWith("SET ANSI_"))
                        && (q.Length > 0))
                    {
                        queries.Add(q);
                    }
                }
            }
            return queries;
        }

        public static string GetDatabaseSize(string pDatabase, SqlConnection pSqlConnection)
        {
            string sql = string.Format("USE {0} EXEC sp_spaceused", pDatabase);

            using (SqlCommand cmd = new SqlCommand(sql, pSqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader == null || !reader.HasRows) return string.Empty;
                    if (reader.Read())
                    {
                        return (string)reader["database_size"];
                    }
                    return string.Empty;
                }
            }
        }

        public static string GetDatabasePath(SqlConnection pSqlConnection)
        {
            const string sqlText = @"DECLARE @rc INT, @dir NVARCHAR(4000)
                  EXEC @rc = master.dbo.xp_instance_regread N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\Setup', N'SQLPath', @dir OUTPUT, 'no_output'
                  SELECT  @dir AS dir";

            using (SqlCommand select = new SqlCommand(sqlText, pSqlConnection))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    if (reader == null || !reader.HasRows) return string.Empty;
                    reader.Read();
                    return (string)reader["dir"];
                }
            }
        }

        /// <summary>
        /// Drop database
        /// </summary>
        /// <param name="pName">Database name</param>
        public void DropDatabase(string pName)
        {
            //SqlConnection con = DefaultConnectionManager.SqlConnectionOnMaster;
            //con.Open();
            //string sql = "DROP DATABASE " + pName;
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.ExecuteNonQuery();
            //con.Close();
        }

        /// <summary>
        /// Srink the database.
        /// </summary>
        public static void ShrinkDatabase(string pDatabaseName, SqlConnection pSqlConnection)
        {
            string database = AppSettings.DatabaseName;
            string sql1 = String.Format("ALTER DATABASE {0} SET RECOVERY SIMPLE", database);
            string sql2 = String.Format("ALTER DATABASE {0} SET AUTO_SHRINK ON", database);

            try
            {
                SqlCommand cmd = new SqlCommand(sql1, pSqlConnection);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(sql2, pSqlConnection);
                cmd.ExecuteNonQuery();

                string sql = String.Format("DBCC SHRINKDATABASE ({0})", database);
                cmd = new SqlCommand(sql, pSqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception) { }
        }

        public static SqlDatabaseSettings GetSQLDatabaseSettings(string pDatabaseName)
        {
            SqlConnection connection = ConnectionManager.GeneralSqlConnection;
            try
            {
                connection.Open();
                SqlDatabaseSettings sqlDatabase = _GetDatabaseInfos(pDatabaseName, connection);

                connection.Close();
                return sqlDatabase;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
        public static List<SqlDatabaseSettings> GetSQLDatabasesSettings(string pDatabaseServerName, string pDatabaseLoginName, string pDatabasePassword, bool pintegrated)
        {
            SqlConnection connection = ConnectionManager.GeneralSqlConnection;
            try
            {
                connection.Open();
                SQLInfoEnumerator sie = new SQLInfoEnumerator
                {
                    SQLServer = pDatabaseServerName,
                    Username = pDatabaseLoginName,
                    Password = pDatabasePassword,
                    IntegratedSecurity = pintegrated
                };

                List<SqlDatabaseSettings> list = new List<SqlDatabaseSettings>();
                foreach (string database in sie.EnumerateSQLServersDatabases())
                {
                    SqlDatabaseSettings sqlDatabase = _GetDatabaseInfos(database, connection);
                    if (sqlDatabase == null) continue;

                    list.Add(sqlDatabase);
                }

                connection.Close();
                return list;
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
        }

        private static SqlDatabaseSettings _GetDatabaseInfos(string pDatabaseName, SqlConnection pSqlConnection)
        {
            SqlDatabaseSettings sqlDatabase = new SqlDatabaseSettings { Name = pDatabaseName };
            string version = GetDatabaseVersion(pDatabaseName, pSqlConnection);

            if (string.IsNullOrEmpty(version)) return null;

            sqlDatabase.Version = version;
            sqlDatabase.Size = GetDatabaseSize(pDatabaseName, pSqlConnection);
            return sqlDatabase;
        }

        public static string GetDatabaseVersion(string pDatabase, SqlConnection pSqlConnection)
        {
            try
            {
                string sqlText = string.Format("USE {0} SELECT [ParmValue] FROM [ForlabParameters] WHERE [ParmName]='version'", pDatabase);
                using (SqlCommand select = new SqlCommand(sqlText, pSqlConnection))
                {
                    using (SqlDataReader reader = select.ExecuteReader())
                    {
                        if (reader == null || !reader.HasRows) return string.Empty;
                        reader.Read();
                        return (string)reader["ParmValue"];
                    }
                }
            }
            catch (SqlException)
            {
                return string.Empty;
            }
        }
        public static string GetDatabaseDefaultPath()
        {
            string path = "";

            SqlConnection connection = ConnectionManager.GeneralSqlConnection;
            try
            {
                connection.Open();

                try
                {
                    path = GetDatabasePath(connection) + @"\Data";
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }

            return path;
        }

        public static string Backup(string pDatabaseName, string pDatabaseVersion, string pBackupPath)
        {
            SqlConnection connection = ConnectionManager.GeneralSqlConnection;
            try
            {
                connection.Open();
                string fileName = _FindAvailableName(String.Format("ForLab-{0}-{1}-@-{1}.bak", pDatabaseVersion, pDatabaseName, DateTime.Now.ToString("ddMMyyyy")));
                BackupManager.Backup(fileName, pBackupPath, pDatabaseName, connection);

                connection.Close();
                return fileName;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }

        public static bool Restore(string pBackupPath, string pDatabase)
        {
            var conm = ConnectionManager.GetInstance();
            SqlConnection connection = conm.SqlConnectionForRestore; //ConnectionManager.GeneralSqlConnection;
            try
            {
                connection.Open();

                BackupManager.Restore(pBackupPath, pDatabase, connection);

                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }

        private static string _FindAvailableName(string pFileName)
        {
            bool available = false;
            int counter = -1;
            string name = pFileName;
            while (!available)
            {
                counter++;
                if (counter > 0) name += string.Format(" ({0})", counter);
                available = (!_IsThisNameAlreadyUsed(name));
            }
            return name;
        }

        private static bool _IsThisNameAlreadyUsed(string pName)
        {
            string fileName = Path.Combine(AppSettings.BackupPath, pName);
            return File.Exists(fileName + ".bak");
        }
    }
}
