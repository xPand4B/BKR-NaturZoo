using System;
using System.Data;
using MySql.Data.MySqlClient;
using NaturZoo_Rheine.config;

/*
|-----------------------------------------------------------------------------
| Query Manager
|-----------------------------------------------------------------------------
|
| //
|
*/
namespace NaturZoo_Rheine.src.Database.Query
{
    class QueryManager
    {
        /**
         * Run query and return result
         * 
         * @param MySqlConnection conn
         * @param String tableName
         * @param String query
         * @return DataTable results
         **/
        public static DataTable GetGridData(MySqlConnection conn, String tableName, String query)
        {
            DatabaseConfig Config = new DatabaseConfig();

            switch (Config.Driver) {
                case "mysql":
                    return MySqlProcessor.GetGridData(conn, tableName, query);

                default:
                    return null;
            }
        }

        /**
         * Run query and return a single result. 
         * This Method only returns the first found value.
         * 
         * @param MySqlConnection conn
         * @param String query
         * @return String result
         **/
        public static String GetSingleResult(MySqlConnection conn, String query)
        {
            DatabaseConfig Config = new DatabaseConfig();

            switch (Config.Driver) {
                case "mysql":
                    return MySqlProcessor.GetSingleResult(conn, query);

                default:
                    return null;
            }
        }

        /**
         * Push Data to the Database
         * 
         * @param MySqlConnection conn
         * @param String query
         * @return Boolean
         **/
        public static Boolean PushData(MySqlConnection conn, String query)
        {
            DatabaseConfig Config = new DatabaseConfig();

            switch (Config.Driver) {
                case "mysql":
                    return MySqlProcessor.PushData(conn, query);

                default:
                    return false;
            }
        }
    }
}
