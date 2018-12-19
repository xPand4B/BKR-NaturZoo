using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using NaturZoo_Rheine.Models;

namespace NaturZoo_Rheine.Database
{
    /// <summary>
    /// Connect to a database using the <seealso cref="MySqlConnection"/> provided by the package <seealso cref="MySql.Data.MySqlClient"/>.
    /// </summary>
    public class MySqlConnector
    {
        protected MySqlConnection _conn { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlConnector"/> class.
        /// </summary>
        public MySqlConnector(Config config)
        {
            String connString = string.Format(
                "SERVER={0};DATABASE={1};UID={2};PASSWORD={3}",
                config.DB_Server, config.DB_Database, config.DB_User, config.DB_Password
            );

            this._conn = new MySqlConnection(connString);
        }


        /// <summary>
        /// Check MySql connection at startup.
        /// </summary>
        /// <returns name="Boolean">
        /// <c>true</c> if the connection is available; otherwise, <c>false</c>.
        /// </returns>
        protected Boolean CheckConnection()
        {
            if (this.Connect()) {
                this.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create MySql database connection.
        /// </summary>
        /// <returns name="Boolean">
        /// <c>true</c> if the connection has been opened successfully; otherwise, <c>false</c>.
        /// </returns>
        protected Boolean Connect()
        {
            try {
                _conn.Open();
                return true;

            } catch (MySqlException ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error", MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// Close MySql database connection.
        /// </summary>
        /// <returns name="Boolean">
        /// <c>true</c> if the connection has been closed successfully; otherwise, <c>false</c>.
        /// </returns> 
        protected Boolean Close()
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
