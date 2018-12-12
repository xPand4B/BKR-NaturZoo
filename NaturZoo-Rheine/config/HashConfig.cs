using System;

namespace NaturZoo_Rheine.config {
    /// <summary>
    ///     Provides all hash settings.
    /// </summary>
    internal struct HashConfig
    {
        /// <summary>
        ///     <para>
        ///         Default Hash Driver
        ///     </para>
        ///     
        ///     This option controls the default hash driver that will be used to hash passwords for the application.
        ///     
        ///     <para>
        ///         Supported: sha256
        ///     </para>
        /// </summary>
        private const String driver = "sha256";


        /// <summary>
        ///     Gets the hash driver.
        /// </summary>
        public String Driver {
            get { return driver.ToLower(); }
        }
    }
}
