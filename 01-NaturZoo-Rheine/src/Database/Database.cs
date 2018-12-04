using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
using System.Windows.Forms;

namespace NaturZoo_Rheine {
    class Database : DatabaseConnectionHandler
    {
        /**
         * @var String credentials
         **/
        private static String server   = "localhost";
        private static String database = "BKR_NaturZoo_Rheine";
        private static String uid      = "root";
        private static String password = "";
        

        /**
         * Constructor
         * 
         * @param static String server
         * @param static String database
         * @param static String uid
         * @param static String password
         **/
        public Database() : base(server, database, uid, password)
        {
            //
        }

        /**
         * Returns database rows based of the query
         * 
         * @param DataGridView grid
         * @param String tableName
         * @param String query
         * 
         * @return Datatable results
         **/
        public DataTable FillGridData(String tableName, String query)
        {
            _conn.Open();
            DataTable results = DatabaseQueryManager.GetGridData(this._conn, tableName, query);
            _conn.Close();

            return results;
        }

        /**
         * Get Single Value from String
         * 
         * @param String query
         * 
         * @return String result
         **/
        public String GetSingleValue(String query)
        {
            _conn.Open();
            String result = DatabaseQueryManager.GetSingleResult(this._conn, query);
            _conn.Close();

            return result;
        }

        /**
         * Push Data inside database
         * 
         * @param String query
         * 
         * @return Boolean
         **/
        public Boolean PushData(String query)
        {
            _conn.Open();
            Boolean result = DatabaseQueryManager.PushData(this._conn, query);
            _conn.Close();

            return result;
        }
    }
}
