using System;

/*
|-----------------------------------------------------------------------------
| Management Model
|-----------------------------------------------------------------------------
|
| Contains Management User Data
|
*/
namespace NaturZoo_Rheine.src.Database.Models
{
    class Management
    {
        /**
         * @var String email
         **/
        public String email { get; set; }

        /**
         * @var String password
         **/
        public String password { get; set; }
    }
}
