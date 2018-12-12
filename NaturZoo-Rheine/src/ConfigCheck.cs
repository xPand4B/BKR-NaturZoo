using System;
using System.Collections.Generic;
using NaturZoo_Rheine.config;
using System.Windows.Forms;

namespace NaturZoo_Rheine.src {
    /// <summary>
    ///     Provides a check for a correctly filled in config.
    /// </summary>
    class ConfigCheck
    {
        private List<string> Errors = new List<string>();


        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigCheck"/> class.
        /// </summary>
        public ConfigCheck()
        {
            DatabaseCheck();
            HashCheck();

            if (Errors.Count != 0) {
                String output = "";

                foreach (String item in Errors)
                    output += item + "\n";
                
                MessageBox.Show(output, "Config error");
                Environment.Exit(1);
            }
        }
        
        /// <summary>
        ///     Check the <seealso cref="DatabaseConfig"/>.
        /// </summary>
        private void DatabaseCheck()
        {
            var DB = new DatabaseConfig();

            if (DB.Driver == "")
                Errors.Add("Database driver can't be empty.");

            if (DB.Server == "")
                Errors.Add("Database server can't be empty.");

            if (DB.Database == "")
                Errors.Add("Database name can't be empty.");

            if (DB.Uid == "")
                Errors.Add("Database UID can't be empty");
        }
        
        /// <summary>
        ///     Check the <seealso cref="HashConfig"/>.
        /// </summary>
        private void HashCheck()
        {
            var Hash = new HashConfig();

            if (Hash.Driver == "")
                Errors.Add("Hash driver can't be empty.");
        }
    }
}
