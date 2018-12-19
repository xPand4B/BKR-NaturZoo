using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Config"/> data.
    /// </summary>
    public struct Config
    {
        public String DB_Server { get; set; }

        public String DB_Database { get; set; }

        public String DB_User { get; set; }

        public String DB_Password { get; set; }


        public String Start_Password { get; set; }


        public String Hash_Driver { get; set; }
    }
}
