using System;
using System.Collections.Generic;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Guardian"/> data.
    /// </summary>
    public class Guardian : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guardian"/> class.
        /// </summary>
        public Guardian()
        {
            showable.Add("name as Name");
            showable.Add("surname as Nachname");
            showable.Add("email as 'E-Mail'");
            showable.Add("telephone as 'Tel.:'");
            showable.Add("birthday as 'Geb.'");
            showable.Add("created_at as Erstelldatum");
        }

        public String Name { get; set; }

        public String Surname { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public Int32 fk_addressID { get; set; }

        public String Street { get; set; }

        public String Telephone { get; set; }

        public String Birthday { get; set; }

        public Int32 fk_territoryID { get; set; }

        public Int32 Permission { get; set; }
    }
}
