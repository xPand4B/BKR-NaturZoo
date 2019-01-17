using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Food"/> data.
    /// </summary>
    class Food : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Food"/> class.
        /// </summary>
        public Food()
        {
            showable.Add("food.name as Futterplan");
            showable.Add("food.amount as Menge");
            showable.Add("supplier.name as Lieferant");
            showable.Add("supplier.telephone as 'Lieferant Tel.:'");

            foreignTable.Add("supplier");
        }

        public String Name { get; set; }

        public Int32 Amount { get; set; }

        public Int32 fk_supplierID { get; set; }
    }
}
