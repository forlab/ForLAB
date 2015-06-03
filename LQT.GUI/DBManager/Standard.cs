
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
using System.Data;
using System.Data.SqlClient;
using LQT.Core;

namespace LQT.GUI
{
    [Serializable]
    public class Standard : IConnectionManager
    {
        private SqlConnection _connection;
        private SqlConnection _connectionOnMasterDatabase;
        private string _connectionStringForRestore;

        private static IConnectionManager _theUniqueInstance;
        private SqlTransaction sqlTransaction;

        public SqlConnection GetSqlConnection()
        {
            return _connection;
        }
        
        private Standard()
        {
            InitConnections(AppSettings.DatabaseLoginName, AppSettings.DatabasePassword, AppSettings.DatabaseServerName, AppSettings.DatabaseName, AppSettings.DatabaseTimeout, AppSettings.IntegratedSecurity);
        }

        private Standard(string pLogin, string pPassword, string pServer, string pDatabase, string pTimeout, bool integrated)
        {
            InitConnections(pLogin, pPassword, pServer, pDatabase, Convert.ToInt32(pTimeout), integrated);
        }

        private bool _connectionInitSuceeded = false;

        public bool ConnectionInitSuceeded { get { return _connectionInitSuceeded; } }

        private void InitConnections(string pLogin, string pPassword, string pServer, string pDatabase, int pTimeout,bool integrated)
        {
            try
            {
                if (integrated)
                {
                    _connectionOnMasterDatabase = new SqlConnection(
                       String.Format("database=MASTER;server={0};Persist Security Info=False;Integrated Security=SSPI;connection timeout={1}", pServer, pTimeout));
                 
                    _connectionStringForRestore =
                    String.Format("database=MASTER;server={0};Persist Security Info=False;Integrated Security=SSPI;connection timeout={1}", pServer, 300);
                    
                    _connection = new SqlConnection(
                        String.Format("database={0};server={1};Persist Security Info=False;Integrated Security=SSPI;connection timeout={2}", pDatabase, pServer, pTimeout));
                }
                else
                {
                    _connectionOnMasterDatabase = new SqlConnection(
                   String.Format("user id={0};password={1};data source={2};persist security info=False;initial catalog=MASTER;connection timeout={3}",
                                 pLogin, pPassword, pServer, pTimeout));

                    _connectionStringForRestore =
                        String.Format("user id={0};password={1};data source={2};persist security info=False;initial catalog=MASTER;connection timeout={3}",
                                      pLogin, pPassword, pServer, 300);

                    _connection = new SqlConnection(
                        String.Format("user id={0};password={1};data source={2};persist security info=False;initial catalog={3};connection timeout={4}",
                                      pLogin, pPassword, pServer, pDatabase, pTimeout));
                }
                _connection.Open();
                        
                _connectionInitSuceeded = true;
            }
            catch (Exception)
            {
                _connectionInitSuceeded = false;
            }
        }

        public static IConnectionManager GetInstance()
        {
            if (_theUniqueInstance == null)
                return _theUniqueInstance = new Standard();
            else
                return _theUniqueInstance;
        }

        public static IConnectionManager GetInstance(string pLogin, string pPassword, string pServer, string pDatabase, string pTimeout, bool integrated)
        {
            if (_theUniqueInstance == null)
                return _theUniqueInstance = new Standard(pLogin, pPassword, pServer, pDatabase, pTimeout, integrated);
            else
                return _theUniqueInstance;
        }

        public static void KillSingleton()
        {
            _theUniqueInstance = null;	
        }
        public SqlConnection SqlConnection
        {
            get
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        _connection.Open();
                    }
                    catch (SqlException sqlEx)
                    {
                        throw new ApplicationException("Unable to connect to database (" + _connection.DataSource + "/" + _connection.Database + "). Please contact your local IT administrator.", sqlEx);
                    }
                }
                return _connection;
            }
        }


        public SqlTransaction GetSqlTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                try
                {
                    _connection.Open();
                }
                catch (SqlException ex)
                {
                    throw new ApplicationException( "Unable to connect to database (" + _connection.DataSource + "/" + _connection.Database +
                        "). Please contact your local IT administrator.", ex);
                }
            }
            else
            {
                try
                {
                    throw new ApplicationException("COUCOU");
                }
                catch (ApplicationException ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.StackTrace);
                }
                sqlTransaction = _connection.BeginTransaction();
            }
            return sqlTransaction;
        }
                
        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// Get a connection on the master database.<br/>
        /// (Used for maintenance database operations)
        /// </summary>
        public SqlConnection SqlConnectionOnMaster
        {
            get
            {
                return _connectionOnMasterDatabase;
            }
        }

        /// <summary>
        /// Get a connection on the master database with a long timeout.<br/>
        /// (Used for  database restore)
        /// </summary>
        public SqlConnection SqlConnectionForRestore
        {
            get
            {
                return new SqlConnection(_connectionStringForRestore);
            }
        }

        public void KillAllConnections()
        {
            String sql = @"
                            DECLARE loop_name INSENSITIVE CURSOR FOR
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
                            DEALLOCATE loop_name
                            ";
            _connectionOnMasterDatabase.Open();
            sql = String.Format(sql, AppSettings.DatabaseName);
            SqlCommand cmd = new SqlCommand(sql, _connectionOnMasterDatabase);
            cmd.ExecuteNonQuery();
            _connectionOnMasterDatabase.Close();
        }

        public static bool CheckSQLServerConnection()
        {
            string sqlConnection;
            
            if(AppSettings.IntegratedSecurity)
                sqlConnection = String.Format(@"database=MASTER;server={0};Persist Security Info=False;Integrated Security=SSPI;connection timeout=10",AppSettings.DatabaseServerName);
            else 
            sqlConnection = String.Format(@"user id={0};password={1};data source={2};persist security info=False;initial catalog=MASTER;connection timeout=10",
                AppSettings.DatabaseLoginName, AppSettings.DatabasePassword, AppSettings.DatabaseServerName);
            SqlConnection connection = new SqlConnection(sqlConnection);
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CheckSQLDatabaseConnection()
        {
            string sqlConnection;
            if(AppSettings.IntegratedSecurity)
                sqlConnection = String.Format(@"database={0};server={1};Persist Security Info=False;Integrated Security=SSPI;connection timeout=10",AppSettings.DatabaseName, AppSettings.DatabaseServerName);
            else 
            sqlConnection = String.Format(@"user id={0};password={1};data source={2};persist security info=False;initial catalog={3};connection timeout=10",
                AppSettings.DatabaseLoginName, AppSettings.DatabasePassword, AppSettings.DatabaseServerName, AppSettings.DatabaseName);
            SqlConnection connection = new SqlConnection(sqlConnection);
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static SqlConnection MasterConnection()
        {
            string sqlConnection;
            if (AppSettings.IntegratedSecurity)
                sqlConnection = String.Format(@"database=MASTER;server={0};Persist Security Info=False;Integrated Security=SSPI;connection timeout=10", AppSettings.DatabaseServerName);
            else
                sqlConnection = String.Format(@"user id={0};password={1};data source={2};persist security info=False;initial catalog=MASTER;connection timeout=10",
                AppSettings.DatabaseLoginName, AppSettings.DatabasePassword, AppSettings.DatabaseServerName);
            return new SqlConnection(sqlConnection);
        }
    }
}
