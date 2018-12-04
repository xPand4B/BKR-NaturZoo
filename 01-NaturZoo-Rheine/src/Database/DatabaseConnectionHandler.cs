using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
using System.Windows.Forms;

namespace NaturZoo_Rheine {
    class DatabaseConnectionHandler
    {
        /**
         * @var MySqlConnection _conn
         **/
        protected MySqlConnection _conn { get; private set; }

        /**
         * Constructor
         * 
         * @param String server
         * @param String database
         * @param String uid
         * @param String password
         **/
        public DatabaseConnectionHandler(String server, String database, String uid, String password)
        {
            String connString = string.Format(
                "SERVER={0};" +
                "DATABASE={1};" +
                "UID={2};" +
                "PASSWORD={3}" 
                , server, database, uid, password
            );

            this._conn = new MySqlConnection(connString);
        }

        /**
         * Create Database Connection+
         * 
         * @return Boolean
         **/
        protected Boolean Connect()
        {
            try {
                _conn.Open();
                return true;

            } catch(MySqlException ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error", MessageBoxButtons.OK);
                return false;
            }
        }

        /**
         * Close Database Connection
         * 
         * @return Boolean
         **/
        protected Boolean Close()
        {
            try {
                _conn.Close();
                return true;

            } catch(MySqlException ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error", MessageBoxButtons.OK);
                return false;
            }
        }
    }
}
