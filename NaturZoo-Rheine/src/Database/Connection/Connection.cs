using System;
using NaturZoo_Rheine.config;

namespace NaturZoo_Rheine.src.Database.Connection {
    /// <summary>
    ///     Provides a dynamic database connection, based on the selected driver inside the <see cref="DatabaseConfig"/>.
    /// </summary>
    class Connection
    {
        private MySqlConnector MySql;
        protected Object _conn { get; private set; }
        protected String dbDriver { get; private set; }


        /// <summary>
        ///     Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        public Connection()
        {
            var Config = new DatabaseConfig();
            dbDriver = Config.Driver;

            switch (dbDriver) {
                case "mysql":
                    MySql = new MySqlConnector(Config.Server, Config.Database, Config.Uid, Config.Password);
                    _conn = MySql._conn;
                    break;

                default:
                    break;
            }
        }


        /// <summary>
        ///     Check connection at startup, based on the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection is available; otherwise, <c>false</c>.
        /// </returns>
        protected Boolean CheckConnection()
        {
            switch (dbDriver) {
                case "mysql":
                    return MySql.CheckConnection();

                default:
                    return false;
            }
        }

        /// <summary>
        ///     Create database connection, based on the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection has been opened successfully; otherwise, <c>false</c>.
        /// </returns>
        public Boolean Connect()
        {
            switch (dbDriver) {
                case "mysql":
                    return MySql.Connect();

                default:
                    return false;
            }
        }

        /// <summary>
        ///     Close database connection, based on the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection has been closed successfully; otherwise, <c>false</c>.
        /// </returns> 
        public Boolean Close()
        {
            switch (dbDriver) {
                case "mysql":
                    return MySql.Close();

                default:
                    return false;
            }
        }
    }
}
