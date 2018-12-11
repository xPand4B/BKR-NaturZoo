using System;

namespace NaturZoo_Rheine.config
{
    class HashConfig
    {
        /*
        |--------------------------------------------------------------------------
        | Default Hash Driver
        |--------------------------------------------------------------------------
        |
        | This option controls the default hash driver that will be used to hash
        | passwords for the application.
        |
        | Supported: "sha256"
        |
        */
        private const String driver = "sha256";


        
        /**
         * Returns driver
         * 
         * @return String driver
         **/
        public String Driver {
            get { return driver.ToLower(); }
        }
    }
}
