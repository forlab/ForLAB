
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI) and Supply Chain Management System(SCMS) 
 *
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU Affero General Public License as published by the Free Software Foundation, version 3 of the License.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License along with this program.  If not, see http://www.gnu.org/licenses.
 */

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace LQT.GUI
{
    public static class BackupManager
    {
        private static class ExtendedRegistry
        {
            [DllImport("advapi32.dll", EntryPoint = "RegOpenKeyEx")]
            private static extern int RegOpenKeyEx_DllImport(UIntPtr hKey, string subkey, uint options, int sam, out IntPtr phkResult);

            [DllImport("advapi32.dll", EntryPoint = "RegQueryValueEx")]
            private static extern int RegQueryValueEx_DllImport(IntPtr hKey, string lpValueName, int lpReserved, out uint lpType, StringBuilder lpData, ref uint lpcbData);

            [DllImport("kernel32.dll")]
            private static extern uint FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr Arguments);

            public static string GetKeyValue(string subkey, string key)
            {
                UIntPtr HKEY_LOCAL_MACHINE = (UIntPtr)0x80000002;
                const int KEY_WOW64_64KEY = 0x0100;
                const int KEY_QUERY_VALUE = 0x1;

                const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
                const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
                const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
                const uint FLAGS =
                    FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;

                IntPtr hKeyVal;
                uint lpType;
                uint lpcbData = 0;
                string retval = string.Empty;

                unchecked
                {
                    try
                    {
                        int ret;
                        ret = RegOpenKeyEx_DllImport(HKEY_LOCAL_MACHINE, subkey, 0, KEY_QUERY_VALUE | KEY_WOW64_64KEY,
                                               out hKeyVal);
                        if (ret > 0)
                        {
                            IntPtr lpMsgBuf = IntPtr.Zero;
                            FormatMessage(FLAGS, IntPtr.Zero, (uint)ret, 0, ref lpMsgBuf, 0, IntPtr.Zero);
                            string msg = Marshal.PtrToStringAnsi(lpMsgBuf);
                            System.Diagnostics.Debug.WriteLine(msg);
                        }
                        ret = RegQueryValueEx_DllImport(hKeyVal, key, 0, out lpType, null, ref lpcbData);
                        StringBuilder data = new StringBuilder((int)lpcbData);
                        ret = RegQueryValueEx_DllImport(hKeyVal, key, 0, out lpType, data, ref lpcbData);
                        retval = data.ToString();
                    }
                    catch (Exception error)
                    {
                        System.Diagnostics.Debug.WriteLine(error.Message);
                        throw;
                    }
                }
                return retval;
            }
        }

        public static void Backup(string pFileName, string pBackupPath, string pDatabaseName, SqlConnection pSqlConnection)
        {
            string sourceFile = BackupInFile(pFileName, pDatabaseName, pSqlConnection);
            //string zipFile = Path.Combine(_GetTempBackupPath(), pFileName) + ".zip";
            //_ZipTempFile(sourceFile, zipFile);
            string targetFile = Path.Combine(pBackupPath, pFileName);

            if (File.Exists(targetFile))
            {
                File.Delete(targetFile);
            }

            File.Move(sourceFile, targetFile);
        }

        private static string BackupInFile(string fileName, string database, SqlConnection connection)
        {
            // To perform a backup we first need to get the appropriate backup folder, which is a bit tricky.
            // First, we need to get the service name.
            const string query = "SELECT @@SERVICENAME AS name";
            SqlCommand cmd = new SqlCommand(query, connection);
            string serviceName = string.Empty;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (null == reader || !reader.HasRows) return null;
                reader.Read();
                if (reader.GetValue(reader.GetOrdinal("name")) != DBNull.Value)
                    serviceName = reader.GetString(reader.GetOrdinal("name"));
                else
                    serviceName = null;
            }

            // Then get the instance name from the registry
            const string sqlServerKey = @"SOFTWARE\Microsoft\Microsoft SQL Server";
            string key = string.Format(@"{0}\Instance Names\SQL", sqlServerKey);
            string instanceName = ExtendedRegistry.GetKeyValue(key, serviceName);
            if (string.IsNullOrEmpty(instanceName)) return null;

            // Finally, get the backup directory
            key = string.Format(@"{0}\{1}\MSSQLServer", sqlServerKey, instanceName);
            string backupDirectory = ExtendedRegistry.GetKeyValue(key, "BackupDirectory");
            if (string.IsNullOrEmpty(backupDirectory)) return null;

            string path = Path.Combine(backupDirectory, fileName);
            _BackupDatabaseInTempFile(path, database, connection);
            return path;
        }

        //private static Dictionary<string, char> GetFilelist(string file, SqlConnection connection)
        //{
        //    //list of files of a backup.
        //    Dictionary<string, char> databaseFiles = new Dictionary<string, char>();

        //    string q = @"RESTORE FILELISTONLY FROM DISK = '{0}'";
        //    q = string.Format(q, file);
        //    OctopusCommand cmd = new OctopusCommand(q, connection);
        //    using (OctopusReader reader = cmd.ExecuteReader())
        //    {
        //        if (null == reader || reader.Empty) return null;
        //        while (reader.Read())
        //        {
        //            string logicalName = reader.GetString("LogicalName");
        //            char type = reader.GetString("Type").ToCharArray()[0];
        //            databaseFiles.Add(logicalName, type);
        //        }
        //    }
        //    return databaseFiles;
        //}

        public static void Restore(string pBackupFile, string pDatabaseName, SqlConnection pSqlConnection)
        {
            try
            {

                _KillAllConnections(pDatabaseName, pSqlConnection);
                SwitchOnSigleMode(pDatabaseName, pSqlConnection); //commented on may 16 

                string sqlText = String.Format(@"DECLARE 
	                                @DestDataBaseName varchar(255),
	                                @BackupFile varchar(255)

                                    SET @DestDataBaseName = '{0}'
                                    SET @BackupFile = '{1}'

                                    RESTORE DATABASE @DestDataBaseName FROM DISK = @BackupFile
                                    WITH REPLACE", pDatabaseName, pBackupFile);

                //Dictionary<string, char> logicalFiles = GetFilelist(filePath, conn);

                //foreach (KeyValuePair<string, char> logicalFile in logicalFiles)
                //{
                //    const string moveString = ", MOVE '{0}' TO '{1}'";
                //    switch (logicalFile.Value)
                //    {
                //        case 'D':
                //            query += string.Format(
                //                moveString
                //                , logicalFile.Key
                //                , Path.Combine(dataDir, dbName + ".mdf")
                //                );
                //            break;
                //        case 'L':
                //            query += string.Format(
                //                moveString
                //                , logicalFile.Key
                //                , Path.Combine(dataDir, dbName + ".ldf")
                //                );
                //            break;
                //    }
                //}

                using (SqlCommand command = new SqlCommand(sqlText, pSqlConnection))
                {
                    command.CommandTimeout = 300;
                    command.ExecuteNonQuery();
                }

                SwitchOffSigleMode(pDatabaseName, pSqlConnection);
            }
            catch(Exception ex)
            {
                SwitchOffSigleMode(pDatabaseName, pSqlConnection);
                throw;
            }
        }

        private static void SwitchOnSigleMode(string pDatabaseName, SqlConnection pSqlConnection)
        {
            string sqlText = string.Format(@"ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", pDatabaseName);

            using (SqlCommand cmd = new SqlCommand(sqlText, pSqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void SwitchOffSigleMode(string pDatabaseName, SqlConnection pSqlConnection)
        {
            string sqlText = string.Format(@"ALTER DATABASE {0} SET MULTI_USER", pDatabaseName);

            using (SqlCommand cmd = new SqlCommand(sqlText, pSqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void _KillAllConnections(string pDatabaseName, SqlConnection pSqlConnection)
        {
            string sqlText = string.Format(@"DECLARE loop_name INSENSITIVE CURSOR FOR
                            SELECT spid
                            FROM master..sysprocesses
                            WHERE dbid = DB_ID('{0}')

                            OPEN loop_name
                            DECLARE @conn_id SMALLINT
                            DECLARE @exec_str VARCHAR(255)
                            FETCH NEXT FROM loop_name INTO @conn_id
                            WHILE (@@fetch_status = 0)
                              BEGIN
                                SELECT @exec_str = 'KILL ' + CONVERT(VARCHAR(7), @conn_id)
                                EXEC( @exec_str )
                                FETCH NEXT FROM loop_name INTO @conn_id
                              END
                            DEALLOCATE loop_name", pDatabaseName);

            using (SqlCommand cmd = new SqlCommand(sqlText, pSqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }


        private static void _BackupDatabaseInTempFile(string pTempSavingPath, string pDatabaseName, SqlConnection pSqlConnection)
        {
            string sqlRecoveryMode1 = String.Format("ALTER DATABASE {0} SET RECOVERY SIMPLE", pDatabaseName);

            string sqlAutoShrink2 = String.Format("ALTER DATABASE {0} SET AUTO_SHRINK ON", pDatabaseName);

            string sqlBackupFile3 = String.Format(@"
					DECLARE
					@DataBaseName varchar(255),
					@BackupFile varchar(255)
	
					SET @DataBaseName = '{0}'
					SET @BackupFile = '{1}'

					BACKUP DATABASE @DataBaseName TO DISK= @BackupFile
					WITH FORMAT", pDatabaseName, pTempSavingPath);

            string sqlTruncLogFile4 = String.Format(@"
                    DECLARE 
                    @DestDataBaseName varchar(255)
                    SET @DestDataBaseName = '{0}'
                    BACKUP LOG @DestDataBaseName WITH TRUNCATE_ONLY", pDatabaseName);

            string sqlTruncLogFile5 = String.Format(@"
                    DECLARE 
                    @DestDataBaseName varchar(255),
                    @LogName varchar(255)
                    SET @DestDataBaseName = '{0}'
                    SET @LogName = (SELECT name from sysfiles where groupid = 0)
                    DBCC SHRINKFILE(@Logname)", pDatabaseName);

            const string sqlSqlServerVersion
                = @"SELECT CONVERT(INTEGER, CONVERT(FLOAT, CONVERT(VARCHAR(3), SERVERPROPERTY('productversion'))))";

            // Ensure recovery mode is simple
            var cmd = new SqlCommand(sqlRecoveryMode1, pSqlConnection);
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();

            // Ensure auto shrink is on
            cmd = new SqlCommand(sqlAutoShrink2, pSqlConnection);
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();

            // Backup data int file
            cmd = new SqlCommand(sqlBackupFile3, pSqlConnection);
            cmd.CommandTimeout = 300;
            cmd.ExecuteNonQuery();

            // Trunc transaction log
            cmd = new SqlCommand(sqlSqlServerVersion, pSqlConnection);
            cmd.CommandTimeout = 300;
            var sqlVersion = (int)cmd.ExecuteScalar();

            if (sqlVersion < 10) // If SQL Server is 2000 or 2005
            {
                cmd = new SqlCommand(sqlTruncLogFile4, pSqlConnection);
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }
            else // If SQL Server is 2008 or higher
            {
                cmd = new SqlCommand(sqlTruncLogFile5, pSqlConnection);
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }

        }

        private static string _GetTempBackupPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp");
        }
    }
}