using System;
using System.Collections.Generic;
using NaturZoo_Rheine.config;
using System.Windows.Forms;

/*
|-----------------------------------------------------------------------------
| Config Checker
|-----------------------------------------------------------------------------
|
| Checks if the config files are filled correctly.
|
*/
namespace NaturZoo_Rheine.src
{
    class ConfigCheck
    {
        /**
         * @var List<string> Errors
         **/
        private List<string> Errors = new List<string>();


        /**
         * Constructor
         **/
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

        /**
         * Check Databaseconfig
         * 
         * @return void
         **/
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

        /**
         * Check HashConfig
         * 
         * @return void
         **/
        private void HashCheck()
        {
            var Hash = new HashConfig();

            if (Hash.Driver == "")
                Errors.Add("Hash driver can't be empty.");
        }
    }
}
