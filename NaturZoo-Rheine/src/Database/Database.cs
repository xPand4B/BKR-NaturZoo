using System;
using System.Data;
using MySql.Data.MySqlClient;
using NaturZoo_Rheine.src.Database.Query;

/*
|-----------------------------------------------------------------------------
| Database management
|-----------------------------------------------------------------------------
|
| //
|
*/
namespace NaturZoo_Rheine.src.Database
{
    class Database : NaturZoo_Rheine.src.Database.Connection.Connection
    {

        /**
         * Constructor
         **/
        public Database() : base()
        {
            // Check connection
            if (!this.CheckConnection()) { Environment.Exit(1); }
        }

        /**
         * Returns database rows based of the query
         * 
         * @param DataGridView grid
         * @param String tableName
         * @param String query
         * @return Datatable results
         **/
        protected DataTable FillGridData(String tableName, String query)
        {
            DataTable results;
            
            if (this.Connect()) {
                switch (this.Driver) {
                    case "mysql":
                        results = QueryManager.GetGridData(this._conn as MySqlConnection, tableName, query);
                        break;

                    default:
                        results = null;
                        break;
                }
                this.Close();
            } else {
                results = null;
            }

            return results;
        }

        /**
         * Get Single Value from String
         * 
         * @param String query
         * @return String result
         **/
        protected String GetSingleValue(String query)
        {
            String result;

            if (this.Connect()) {
                switch (this.Driver) {
                    case "mysql":
                        result = QueryManager.GetSingleResult(this._conn as MySqlConnection, query);
                        break;

                    default:
                        result = null;
                        break;
                }
                this.Close();
            } else {
                result = null;
            }

            return result;
        }

        /**
         * Push Data inside database
         * 
         * @param String query
         * @return Boolean
         **/
        protected Boolean PushData(String query)
        {
            Boolean result;

            if (this.Connect()) {
                switch (this.Driver) {
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
