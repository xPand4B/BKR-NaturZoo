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
            showable.Add("building.name as Gebäude");
            showable.Add("territory.name as Revier");
            showable.Add("building.created_at as Erstelldatum");
            showable.Add("building.updated_at as Geändert");

            foreignTable.Add("territory");
        }

        public String Name { get; set; }

        public Int32 fk_territoryID { get; set; }
    }
}
