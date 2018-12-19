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
            showable.Add("name as Gehege");
            showable.Add("fk_buildingid as Gebäude");
            showable.Add("created_at as Erstelldatum");
            showable.Add("updated_at as Geändert");
        }

        public String Name { get; set; }

        public Int32 fk_buildingID { get; set; }
    }
}
