using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Animal"/> data.
    /// </summary>
    public class Animal : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Animal"/> class.
        /// </summary>
        public Animal()
        {
            showable.Add("animal.name as Name");
            showable.Add("animal.species as Art");
            showable.Add("animal.gender as Geschlecht");
            showable.Add("territory.name as Revier");
            showable.Add("enclosure.name as Gehege");
            showable.Add("animal.birthday as 'Geb.'");
            showable.Add("animal.away_since as 'Weg seit'");

            foreignTable.Add("territory");
            foreignTable.Add("enclosure");
        }

        public String Name { get; set; }

        public String Species { get; set; }

        public String Gender { get; set; }

        public String Birthday { get; set; }

        public Int32 fk_territoryID { get; set; }

        public Int32 fk_enclosureID { get; set; }

        public String away_since { get; set; }
    }
}
