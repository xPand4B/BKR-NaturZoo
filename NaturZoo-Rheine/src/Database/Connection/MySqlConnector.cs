using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

/*
|-----------------------------------------------------------------------------
| MySql Connector
|-----------------------------------------------------------------------------
|
| //
|
*/
namespace NaturZoo_Rheine.src.Database.Connection
{
    class MySqlConnector : IConnector
    {
        /**
         * @var MySqlConnection _conn
         **/
        public MySqlConnection _conn { get; private set; }

        /**
         * Constructor
         * 
         * @param String server
         * @param String database
         * @param String uid
         * @param String password
         **/
        public MySqlConnector(String server, String database, String uid, String password)
        {
            String connString = string.Format(
                "SERVER={0};DATABASE={1};UID={2};PASSWORD={3}",
                server, database, uid, password
            );

            this._conn = new MySqlConnection(connString);
        }

        /**
         * Check Connection at startup
         * 
         * @return Boolean
         **/
        public Boolean CheckConnection()
        {
            if (this.Connect()) {
                this.Close();
                return true;
            }

            MessageBox.Show("", "MySql Connection Error", MessageBoxButtons.OK);

            return false;
        }

        /**
         * Create Database Connection
         * 
         * @return Boolean
         **/
        public Boolean Connect()
        {
            try {
                _conn.Open();
                return true;

            } catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error", MessageBoxButtons.OK);
                return false;
            }
        }

        /**
         * Close Database Connection
         * 
         * @return Boolean
         **/
        public Boolean Close()
        {
            try {
                _conn.Close();
                return true;

            } catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error", MessageBoxButtons.OK);
                return false;
            }
        }
    }
}
