using System;

namespace NaturZoo_Rheine.src.Database.Models {
    /// <summary>
    ///     Provides <see cref="Guardian"/> Data.
    /// </summary>
    internal struct Guardian
    {
        public String name { get; set; }

        public String surname { get; set; }

        public DateTime birthday { get; set; }
    }
}
