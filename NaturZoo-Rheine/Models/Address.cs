using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Address"/> data.
    /// </summary>
    class Address : EntityBase
    {
        public Int32 postcode { get; set; }

        public String city { get; set; }
    }
}
