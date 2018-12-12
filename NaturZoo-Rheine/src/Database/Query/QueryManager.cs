using System;
using System.Data;
using MySql.Data.MySqlClient;
using NaturZoo_Rheine.config;

namespace NaturZoo_Rheine.src.Database.Query {
    /// <summary>
    ///     Provides the Processor, based on the selected driver inside the <see cref="DatabaseConfig"/>.
    /// </summary>
    class QueryManager
    {
        /// <summary>
        ///     Call the QueryManager and get a <seealso cref="DataTable "/> result, based on the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </summary>
        /// <param name="conn">The connection object.</param>
        /// <param name="tableName">The Tablename.</param>
        /// <param name="query">The query string.</param>
        /// <returns name="DataTable">
        ///     <seealso cref="DataTable"/> result, based on the query and the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </returns>
        public static DataTable GetGridData(Object conn, String tableName, String query)
        {
            DatabaseConfig Config = new DatabaseConfig();

            switch (Config.Driver) {
                case "mysql":
                    return MySqlProcessor.GetGridData(conn as MySqlConnection, tableName, query);

                default:
                    return null;
            }
        }

        /// <summary>
        ///     Call the QueryManager and get a single <seealso cref="String"/> result, based on the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </summary>
        /// <param name="conn">The connection object.</param>
        /// <param name="query">The query string.</param> 
        /// <returns name="String">
        ///     <seealso cref="String"/> result, based on the query and the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </returns>
        public static String GetSingleResult(Object conn, String query)
        {
            DatabaseConfig Config = new DatabaseConfig();

            switch (Config.Driver) {
                case "mysql":
                    return MySqlProcessor.GetSingleResult(conn as MySqlConnection, query);

                default:
                    return null;
            }
        }

        /// <summary>
        ///     Call the QueryManager, push data and return a <seealso cref="Boolean"/>, based on the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </summary>
        /// <param name="conn">The connection object.</param>
        /// <param name="query">The query string.</param> 
        /// <returns name="Boolean">
        ///     <c>true</c> if the data has been pushed successfully; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean PushData(Object conn, String query)
        {
            DatabaseConfig Config = new DatabaseConfig();

            switch (Config.Driver) {
                case "mysql":
                    return MySqlProcessor.PushData(conn as MySqlConnection, query);

                default:
                    return false;
            }
        }
    }
}
