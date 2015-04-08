
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
using System.Data;
using System.Data.SqlClient;

namespace LQT.GUI
{
    [Serializable]
    public class ConnectionManager
    {
        private readonly IConnectionManager _connectionManager;
        private static ConnectionManager _theUniqueInstance;

        private ConnectionManager()
        {
                _connectionManager = Standard.GetInstance();
        }

        private ConnectionManager(string pLogin, string pPassword, string pServer, string pDatabase, string pTimeout, bool integrated)
        {
            _connectionManager = Standard.GetInstance(pLogin, pPassword, pServer, pDatabase, pTimeout, integrated);
        }

        public static ConnectionManager GetInstance()
        {
            if (_theUniqueInstance == null)
                return _theUniqueInstance = new ConnectionManager();
            else
                return _theUniqueInstance;
        }

        public static ConnectionManager GetInstance(string pLogin, string pPassword, string pServer, string pDatabase, string pTimeout, bool integrated)
        {
            if (_theUniqueInstance == null)
                return _theUniqueInstance = new ConnectionManager(pLogin, pPassword, pServer, pDatabase, pTimeout, integrated);
            else
                return _theUniqueInstance;
        }

        public static void KillSingleton()
        {            
            _theUniqueInstance = null;
        }

        public SqlConnection GetSqlConnection()
        {
            return _connectionManager.GetSqlConnection();
        }
      
        public SqlConnection SqlConnection
        {
            get { return _connectionManager.SqlConnection; }
        }


        public SqlTransaction GetSqlTransaction()
        {
            return _connectionManager.GetSqlTransaction();
        }

        public void CloseConnection()
        {
            _connectionManager.CloseConnection();
        }
        
        public bool ConnectionInitSuceeded
        {
            get { return _connectionManager.ConnectionInitSuceeded; }
        }

        public SqlConnection SqlConnectionOnMaster
        {
            get { return _connectionManager.SqlConnectionOnMaster; }
        }

        public SqlConnection SqlConnectionForRestore
        {
            get { return _connectionManager.SqlConnectionForRestore; }
        }

        public void KillAllConnections()
        {
            _connectionManager.KillAllConnections();
        }

        public static bool CheckSQLServerConnection()
        {
            return Standard.CheckSQLServerConnection();
        }

        public static bool CheckSQLDatabaseConnection()
        {
            return Standard.CheckSQLDatabaseConnection();
        }
        public static SqlConnection GeneralSqlConnection
        {
            get
            {
                return Standard.MasterConnection();
            }
        }
        
    }
}
