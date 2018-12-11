using System;

/*
|-----------------------------------------------------------------------------
| Guardian Model
|-----------------------------------------------------------------------------
|
| Contains Guardian Data
|
*/
namespace NaturZoo_Rheine.src.Database.Models
{
    class Guardian
    {
        /**
         * @var String name
         **/
        public String name { get; set; }

        /**
         * @var String surname
         **/
        public String surname { get; set; }

        /**
         * @var DateTime birthday
         **/
        public DateTime birthday { get; set; }
    }
}
