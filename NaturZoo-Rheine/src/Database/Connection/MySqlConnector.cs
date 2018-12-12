using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace NaturZoo_Rheine.src.Database.Connection {
    /// <summary>
    ///     Provides the MySql Connection.
    /// </summary>
    class MySqlConnector : IConnector
    {
        public MySqlConnection _conn{ get; private set; }


        /// <summary>
        ///     Initializes a new instance of the <see cref="MySqlConnector"/> class.
        /// </summary>
        /// <param name="server">The MySql database server.</param>
        /// <param name="database">The MySql database name.</param>
        /// <param name="uid">The MySql database user.</param>
        /// <param name="password">The MySql database password.</param>
        public MySqlConnector(String server, String database, String uid, String password)
        {
            String connString = string.Format(
                "SERVER={0};DATABASE={1};UID={2};PASSWORD={3}",
                server, database, uid, password
            );

            this._conn = new MySqlConnection(connString);
        }


        /// <summary>
        ///     Check MySql connection at startup.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection is available; otherwise, <c>false</c>.
        /// </returns>
        public Boolean CheckConnection()
        {
            if (this.Connect()) {
                this.Close();
                return true;
            }

            MessageBox.Show("", "MySql Connection Error", MessageBoxButtons.OK);

            return false;
        }

        /// <summary>
        ///     Create MySql database connection.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection has been opened successfully; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        ///     Close MySql database connection.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection has been closed successfully; otherwise, <c>false</c>.
        /// </returns> 
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
