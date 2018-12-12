using System;
using System.Data;
using NaturZoo_Rheine.src.Database.Models;
using NaturZoo_Rheine.src.Hashing;

/*
|-----------------------------------------------------------------------------
| Zoo management
|-----------------------------------------------------------------------------
|
| Every request for returning/pushing data to/from the database is managed here.
|
*/
namespace NaturZoo_Rheine.src
{
    class ZooRheine : Database.Database
    {
        #region "Management"

            /// <summary>
            ///     Gets the <seealso cref="Management"/> count as <seealso cref="String"/>.
            /// </summary>
            /// <returns name="String">
            ///     The <seealso cref="Management"/> count.
            /// </returns>
            public String GetManagementCount {
                get {
                    return this.GetSingleValue(
                        "SELECT count(*) from management"
                    );
                }
            }

            /// <summary>
            ///     Gets the <seealso cref="Management"/> grid as <seealso cref="DataTable"/>.
            /// </summary>
            /// <returns name="DataTable">
            ///     The <seealso cref="Management"/> datagrid.
            /// </returns>
            public DataTable GetManagementGrid {
                get {
                    return this.FillGridData("Management",
                        "SELECT email as 'E-Mail', created_at as 'Erstelldatum' " +
                        "FROM management " +
                        "ORDER BY created_at asc"
                    );
                }
            }

            /// <summary>
            ///     Create a <seealso cref="Management"/> user and return a <seealso cref="Boolean"/>.
            /// </summary>
            /// <returns name="Boolean">
            ///     <c>true</c> if the user has been created successfully; otherwise, <c>false</c>.
            /// </returns>
            public Boolean CreateManagement(Management m)
            {
                return this.PushData(string.Format(
                    "INSERT INTO management (email, password) " +
                    "VALUES ('{0}', '{1}')",
                    m.email, Hashmanager.Hash(m.password)
                ));
            }

        #endregion


        #region "Guardian"
            /// <summary>
            ///     Gets the <seealso cref="Guardian"/> count as <seealso cref="String"/>.
            /// </summary>
            /// <returns name="String">
            ///     The <seealso cref="Guardian"/> count.
            /// </returns>
            public String GetGuardianCount {
                get {
                    return this.GetSingleValue(
                        "SELECT count(*) from guardian"
                    );
                }
            }

            /// <summary>
            ///     Gets the <seealso cref="Guardian"/> grid as <seealso cref="DataTable"/>.
            /// </summary>
            /// <returns name="DataTable">
            ///     The <seealso cref="Guardian"/> datagrid.
            /// </returns>
            public DataTable GetGuardianGrid {
                get {
                    return this.FillGridData("guardian",
                        "SELECT name as 'Vorname', surname as 'Nachname', birthday as 'Geb.' " +
                        "FROM guardian " +
                        "ORDER BY created_at asc"
                    );
                }
            }

            /// <summary>
            ///     Create a <seealso cref="Guardian"/> user and return a <seealso cref="Boolean"/>.
            /// </summary>
            /// <returns name="Boolean">
            ///     <c>true</c> if the user has been created successfully; otherwise, <c>false</c>.
            /// </returns>
            public Boolean CreateGuardian(Guardian g)
            {
                return this.PushData(string.Format(
                    "INSERT INTO guardian (name, surname, birthday) " +
                    "VALUES ('{0}', '{1}', '{2}')",
                    g.name, g.surname, g.birthday
                ));
            }

        #endregion


        #region "Animal"
            /// <summary>
            ///     Gets the <seealso cref="Animal"/> count as <seealso cref="String"/>.
            /// </summary>
            /// <returns name="String">
            ///     The <seealso cref="Animal"/> count.
            /// </returns>
            public String GetAnimalCount {
                get {
                    return this.GetSingleValue(
                        "SELECT count(*) from "
                    );
                }
            }

            /// <summary>
            ///     Gets the <seealso cref="Animal"/> count as <seealso cref="String"/>.
            /// </summary>
            /// <returns name="String">
            ///     The <seealso cref="Animal"/> count.
            /// </returns>
            public DataTable GetAnimalGrid {
                get {
                    return this.FillGridData("animal",
                        "SELECT " +
                        "FROM " +
                        "ORDER BY created_at asc"
                    );
                }
            }

            /// <summary>
            ///     Create a <seealso cref="Animal"/> user and return a <seealso cref="Boolean"/>.
            /// </summary>
            /// <returns name="Boolean">
            ///     <c>true</c> if the user has been created successfully; otherwise, <c>false</c>.
            /// </returns>
            public Boolean CreateAnimal(Animal a)
            {
                return this.PushData(string.Format(
                    "INSERT INTO animal () " +
                    "VALUES ('{0}', '{1}', '{2}')"

                ));
            }
        
        #endregion


        #region "Supplier"
            /// <summary>
            ///     Gets the <seealso cref="Supplier"/> count as <seealso cref="String"/>.
            /// </summary>
            /// <returns name="String">
            ///     The <seealso cref="Supplier"/> count.
            /// </returns>
            public String GetSupplierCount {
                get {
                    return this.GetSingleValue(
                        "SELECT count(*) from supplier"
                    );
                }
            }

            /// <summary>
            ///     Gets the <seealso cref="Supplier"/> count as <seealso cref="String"/>.
            /// </summary>
            /// <returns name="String">
            ///     The <seealso cref="Supplier"/> count.
            /// </returns>
            public DataTable GetSupplierGrid {
                get {
                    return this.FillGridData("Supplier",
                        "SELECT " +
                        "FROM " +
                        "ORDER BY created_at asc"
                    );
                }
            }
        
            /// <summary>
            ///     Create a <seealso cref="Animal"/> user and return a <seealso cref="Boolean"/>.
            /// </summary>
            /// <returns name="Boolean">
            ///     <c>true</c> if the user has been created successfully; otherwise, <c>false</c>.
            /// </returns>
            public Boolean CreateSupplier(Supplier s)
        {
            return this.PushData(string.Format(
                "INSERT INTO supplier() " +
                "VALUES ('{0}', '{1}', '{2}')"

            ));
        }
        #endregion
    }
}
