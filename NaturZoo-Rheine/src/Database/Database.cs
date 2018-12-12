using System;
using System.Data;
using MySql.Data.MySqlClient;
using NaturZoo_Rheine.src.Database.Query;
using NaturZoo_Rheine.config;

namespace NaturZoo_Rheine.src.Database {
    /// <summary>
    /// 
    /// </summary>
    class Database : NaturZoo_Rheine.src.Database.Connection.Connection
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database() : base()
        {
            // Check connection
            if (!this.CheckConnection()) { Environment.Exit(1); }
        }

        /// <summary>
        ///     Call the QueryManager and get a <seealso cref="DataTable "/> result.
        /// </summary>
        /// <param name="tableName">The Tablename</param>
        /// <param name="query">The query string.</param>
        /// <returns name="DataTable">
        ///     <seealso cref="DataTable"/> result, based on the query and the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </returns>
        protected DataTable FillGridData(String tableName, String query)
        {
            DataTable results;
            
            if (this.Connect()) {
                results = QueryManager.GetGridData(this._conn, tableName, query); 
                this.Close();
            } else {
                results = null;
            }

            return results;
        }

        /// <summary>
        ///     Call the QueryManager and get a single <seealso cref="String"/> result.
        /// </summary>
        /// <param name="query">The query string.</param> 
        /// <returns name="String">
        ///     <seealso cref="String"/> result, based on the query and the selected driver inside the <seealso cref="DatabaseConfig"/>.
        /// </returns>
        protected String GetSingleValue(String query)
        {
            String result;

            if (this.Connect()) {
                result = QueryManager.GetSingleResult(this._conn as MySqlConnection, query);
                this.Close();

            } else {
                result = null;
            }

            return result;
        }

        /// <summary>
        ///     Call the QueryManager, push data and return a <seealso cref="Boolean"/>.
        /// </summary>
        /// <param name="query">The query string.</param> 
        /// <returns name="Boolean">
        ///     <c>true</c> if the data has been pushed successfully; otherwise, <c>false</c>.
        /// </returns>
        protected Boolean PushData(String query)
        {
            Boolean result;

            if (this.Connect()) {
                switch (this.dbDriver) {
                    case "mysql":
                        result = QueryManager.PushData(this._conn as MySqlConnection, query);
                        break;

                    default:
                        result = false;
                        break;
                }
                this.Close();

            } else {
                result = false;
            }

            return result;
        }
    }
}
