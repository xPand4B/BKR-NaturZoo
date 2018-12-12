using System;
using System.Windows.Forms;
using NaturZoo_Rheine.src.Hashing;
using NaturZoo_Rheine.src.Database.Models;

/*
|-----------------------------------------------------------------------------
| Login Management
|-----------------------------------------------------------------------------
|
| Default User:
|   E-Mail:     management@naturzoo-rheine.de
|   Password:   NaturZoo
*/
namespace NaturZoo_Rheine.src
{
    class Login : NaturZoo_Rheine.src.Database.Database
    {
        private ZooRheine Zoo;

        private const String defaultEmail    = "management@naturzoo-rheine.de";
        private const String defaultPassword = "NaturZoo";


        /// <summary>
        ///     Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        public Login()
        {
            Zoo = new ZooRheine();

            String userCount       = Zoo.GetGuardianCount;
            String managementCount = Zoo.GetManagementCount;

            if (managementCount == "0" || (userCount == "0" && managementCount == "0")) {
                CreateDefaultUser();
                MessageBox.Show("No Management User found. Default User has been created.", "User Information", MessageBoxButtons.OK);
            }

        }

        /**
         * Create default management user
         * 
         * @return Boolean
         **/

        /// <summary>
        ///     Create the default <seealso cref="Management"/> user.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the user has been created successfully; otherwise, <c>false</c>.
        /// </returns>
        private Boolean CreateDefaultUser()
        {
            return Zoo.CreateManagement(new Management {
                email = defaultEmail,
                password = Hashmanager.Hash(defaultPassword)
            });
        }

        /**
         * Check if input is equal to DB-Data
         * 
         * @param String emailInput
         * @param String passwordInput
         * @return Boolean
         **/

        /// <summary>
        ///     Check if the input is contains valid credentials.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the login was successfully; otherwise, <c>false</c>.
        /// </returns>
        public Boolean Check(String emailInput, String passwordInput)
        {
            String result = this.GetSingleValue(string.Format(
                "SELECT count(*) " +
                "FROM management " +
                "WHERE email='{0}' " +
                    "AND password='{1}'",
                emailInput, Hashmanager.Hash(passwordInput)
            ));

            if (result == "1") { return true; }

            return false;
        }
    }
}
