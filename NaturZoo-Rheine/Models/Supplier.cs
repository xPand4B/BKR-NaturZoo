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
            showable.Add("name as Name");
            showable.Add("telephone as 'Tel.:'");
            showable.Add("contact_person_name as 'Ansprechpartner (Name)'");
            showable.Add("contact_person_surname as 'Ansprechpartner (Nachname)'");
        }

        public String Name { get; set; }

        public Int32 fk_addressID{ get; set; }

        public String Street { get; set; }

        public String telephone { get; set; }

        public String Contact_Person_Name { get; set; }

        public String Contact_Person_Surname { get; set; }

        public String updated_at { get; set; }
    }
}
