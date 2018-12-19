using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Territory"/> data.
    /// </summary>
    class Territory : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Territory"/> class.
        /// </summary>
        public Territory()
        {
            showable.Add("name as Revier");
            showable.Add("created_at as Erstelldatum");
            showable.Add("updated_at as Geändert");
        }

        public String Name { get; set; }
    }
}
