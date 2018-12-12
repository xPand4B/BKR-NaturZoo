using System;

namespace NaturZoo_Rheine.config {
    /// <summary>
    ///     Provide all database connection credentials.
    /// </summary>
    internal struct DatabaseConfig
    {
        /// <summary>
        ///     <para>
        ///         Default Database Driver.
        ///     </para>
        ///     
        ///     Here you may specify which of the database connections below you wish to use as your default connection for all database work.
        ///     
        ///     <para>
        ///         Supported: mysql
        ///     </para>
        /// </summary>
        private const String driver = "mysql";


        /// <summary>
        ///     Here are the database connection credentials for your application.
        /// </summary>
        private const String server   = "localhost",
                             database = "BKR_NaturZoo_Rheine",
                             uid      = "root",
                             password = "";



        /// <summary>
        ///     Gets the database driver.
        /// </summary>
        public String Driver {
            get { return driver.ToLower(); }
        }
        
        /// <summary>
        ///     Gets the database server.
        /// </summary>
        public String Server {
            get { return server; }
        }

        /// <summary>
        ///     Gets the database name.
        /// </summary>
        public String Database {
            get { return database; }
        }
        
        /// <summary>
        ///     Gets the database uid.
        /// </summary>
        public String Uid {
            get { return uid; }
        }
        
        /// <summary>
        ///     Gets the database password.
        /// </summary>
        public String Password {
            get { return password; }
        }
    }
}
