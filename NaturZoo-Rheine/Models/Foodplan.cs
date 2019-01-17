using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Foodplan"/> data.
    /// </summary>
    class Foodplan : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Foodplan"/> class.
        /// </summary>
        public Foodplan()
        {
            showable.Add("animal.name as Tiername");
            showable.Add("animal.species as Tierart");
            showable.Add("food.name as Futter");
            showable.Add("foodplan.amount as Menge");
            showable.Add("foodplan.time as Zeit");
            showable.Add("foodplan.weekday as Wochentag");

            foreignTable.Add("animal");
            foreignTable.Add("food");
        }

        public Int32 fk_animalID { get; set; }

        public Int32 fk_foodID { get; set; }

        public String Time { get; set; }

        public String Weekday { get; set; }

        public Int32 Amount { get; set; }
    }
}
