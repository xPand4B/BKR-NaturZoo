using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Building"/> data.
    /// </summary>
    class Building : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Building"/> class.
        /// </summary>
        public Building()
        {
            showable.Add("name as Gebäude");
            showable.Add("fk_territoryID as Revier");
            showable.Add("created_at as Erstelldatum");
            showable.Add("updated_at as Geändert");
        }

        public String Name { get; set; }

        public Int32 fk_territoryID { get; set; }
    }
}
