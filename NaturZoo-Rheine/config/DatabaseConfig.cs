using System;

namespace NaturZoo_Rheine.config
{
    class DatabaseConfig
    {
        /*
        |--------------------------------------------------------------------------
        | Default Database Connection Name
        |--------------------------------------------------------------------------
        |
        | Here you may specify which of the database connections below you wish
        | to use as your default connection for all database work.
        |
        | Supported: "mysql"
        |
        */
        public const String driver = "mysql";

        /*
        |--------------------------------------------------------------------------
        | Database Connections
        |--------------------------------------------------------------------------
        |
        | Here are the database connections setup for your application.
        |
        */
        public const String server   = "localhost";
        public const String database = "BKR_NaturZoo_Rheine";
        public const String uid      = "root";
        public const String password = "";



        /**
         * Returns driver
         * 
         * @return String driver
         **/
        public String Driver {
            get { return driver.ToLower(); }
        }
        
        /**
         * Returns server
         * 
         * @return String server
         **/
        public String Server {
            get { return server; }
        }

        /**
         * Returns database
         * 
         * @return String database
         **/
        public String Database {
            get { return database; }
        }

        /**
         * Returns uid
         * 
         * @return String uid
         **/
        public String Uid {
            get { return uid; }
        }

        /**
         * Returns password
         * 
         * @return String password
         **/
        public String Password {
            get { return password; }
        }
    }
}
