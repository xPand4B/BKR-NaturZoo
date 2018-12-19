using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using NaturZoo_Rheine.Models;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// Handles the config inside the App.config file.
    /// </summary>
    class ConfigRepository
    {
        private List<string> Errors = new List<string>();
        public Config Config { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigRepository"/> class.
        /// </summary>
        public ConfigRepository()
        {
            CheckDatabase();
            CheckHash();

            if (Errors.Count != 0) {
                String output = "";

                foreach (String item in Errors)
                    output += item + "\n";

                MessageBox.Show(output, "Config error");
                Environment.Exit(1);

            }
        }

        /// <summary>
        /// Get the config.
        /// </summary>
        public Config GetConfig()
        {
            return new Config() {
                DB_Server       = ConfigurationManager.AppSettings["DB_Server"],
                DB_Database     = ConfigurationManager.AppSettings["DB_Database"],
                DB_User         = ConfigurationManager.AppSettings["DB_User"],
                DB_Password     = ConfigurationManager.AppSettings["DB_Password"],

                Start_Password  = ConfigurationManager.AppSettings["Start_password"],

                Hash_Driver     = ConfigurationManager.AppSettings["Hash_Driver"],
            };
        }

        /// <summary>
        /// Check the Databaseconfig.
        /// </summary>
        private void CheckDatabase()
        {
            if (ConfigurationManager.AppSettings["DB_Server"] == "")
                Errors.Add("Database server can't be empty.");

            if (ConfigurationManager.AppSettings["DB_Database"] == "")
                Errors.Add("Database name can't be empty.");

            if (ConfigurationManager.AppSettings["DB_User"] == "")
                Errors.Add("Database UID can't be empty");
        }

        /// <summary>
        /// Check the HashConfig.
        /// </summary>
        private void CheckHash()
        {
            if (ConfigurationManager.AppSettings["Hash_Driver"] == "")
                Errors.Add("Hash driver can't be empty.");
        }
    }
}
