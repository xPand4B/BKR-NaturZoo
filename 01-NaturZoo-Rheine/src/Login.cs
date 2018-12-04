using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace NaturZoo_Rheine
{
    class Login : Database
    {
        /**
         * Constructor
         **/
        public Login()
        {
            /*
            |--------------------------------------------------------------------------
            | Check if there is at least one record inside the "management" database table
            |--------------------------------------------------------------------------
            |
            | If there are records:     Run as normal
            | If there are no records:  Create Default user
            |
            | Default User:
            |   E-Mail:     management@naturzoo-rheine.de
            |   Password:   NaturZoo
            */
            Int32 userCount = Convert.ToInt32(this.GetSingleValue(
                "SELECT count(*)" +
                "FROM management"
            ));

            if(userCount == 0) {
                CreateDefaultUser();
                MessageBox.Show("No Management User found. Default User has been created.", "User Information", MessageBoxButtons.OK);
            }

        }

        /**
         * Create default management user
         * 
         * @return Boolean
         **/
        public Boolean CreateDefaultUser()
        {
            String email = "management@naturzoo-rheine.de";
            String password = this.ComputeSha256Hash("NaturZoo");
            
            return this.PushData(string.Format(
                "INSERT INTO management (email, password)" +
                "VALUES ('{0}', '{1}')",
                email, password
            ));
        }

        /**
         * Check if input is equal to DB-Data
         * 
         * @param Strin user
         * @param String password
         * 
         * @return Boolean
         **/
        public Boolean Check(String emailInput, String passwordInput)
        {
            Int32 result = Convert.ToInt32(this.GetSingleValue(string.Format(
                "SELECT count(*) " +
                "FROM management " +
                "WHERE email='{0}' " +
                    "AND password='{1}'",
                emailInput, ComputeSha256Hash(passwordInput)
            )));

            if(result == 1) { return true; }

            return false;
        }

        /**
         * Create Hash
         * 
         * @param String rawData
         * 
         * @return String HashValue
         **/
        private String ComputeSha256Hash(String rawData)
        {
            // Create a SHA256   
            using(SHA256 sha256Hash = SHA256.Create()) {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
