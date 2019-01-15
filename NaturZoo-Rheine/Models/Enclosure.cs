using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Enclosure"/> data.
    /// </summary>
    class Enclosure : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enclosure"/> class.
        /// </summary>
        public Enclosure()
        {
            showable.Add("enclosure.name as Gehege");
            showable.Add("building.name as Gebäude");
            showable.Add("enclosure.created_at as Erstelldatum");
            showable.Add("enclosure.updated_at as Geändert");

            foreignTable.Add("building");
        }

        public String Name { get; set; }

        public Int32 fk_buildingID { get; set; }
    }
}
