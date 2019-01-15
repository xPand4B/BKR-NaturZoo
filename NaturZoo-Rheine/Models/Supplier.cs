using System;
using System.Collections.Generic;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Supplier"/> data.
    /// </summary>
    class Supplier : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        public Supplier()
        {
            showable.Add("supplier.name as Name");
            showable.Add("supplier.telephone as 'Tel.:'");
            showable.Add("supplier.contact_person_name as 'Ansprechpartner (Name)'");
            showable.Add("supplier.contact_person_surname as 'Ansprechpartner (Nachname)'");
            showable.Add("supplier.street as Straße");
            showable.Add("address.city as Stadt");
            showable.Add("address.postcode as PLZ");

            foreignTable.Add("address");
        }

        public String Name { get; set; }

        public Int32 fk_addressID{ get; set; }

        public String Street { get; set; }

        public String telephone { get; set; }

        public String Contact_Person_Name { get; set; }

        public String Contact_Person_Surname { get; set; }
    }
}
