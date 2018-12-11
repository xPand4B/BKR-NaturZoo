using System;
using MySql.Data.MySqlClient;
using System.Data;

/*
|-----------------------------------------------------------------------------
| Connection management
|-----------------------------------------------------------------------------
|
| //
|
*/
namespace NaturZoo_Rheine.src.Database.Connection
{
    class Connection : NaturZoo_Rheine.config.DatabaseConfig
    {
        /**
         * @var MySqlConnection MySql
         **/
        private MySqlConnector MySql;
        /**
         * @var Object _conn
         **/
        protected Object _conn { get; private set; }
        
        /**
         * @var String driver
         **/
        protected String dbDriver { get; private set; }

        /*
         * Constructor
         **/
        public Connection()
        {
            dbDriver = this.Driver;

            switch (driver) {
                case "mysql":
                    MySql = new MySqlConnector(this.Server, this.Database, this.Uid, this.Password);
                    _conn = MySql._conn;
                    break;

                default:
                    break;
            }
        }

        /**
         * Check Connection at startup
         * 
         * @return Boolean
         **/
        protected Boolean CheckConnection()
        {
            switch (dbDriver) {
                case "mysql":
                    return MySql.CheckConnection();

                default:
                    return false;
            }
        }

        /**
         * Create Database Connection
         * 
         * @return Boolean
         **/
        public Boolean Connect()
        {
            switch (dbDriver) {
                case "mysql":
                    return MySql.Connect();

                default:
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
            switch (dbDriver) {
                case "mysql":
                    return MySql.Close();

                default:
                    return false;
            }
        }
    }
}
