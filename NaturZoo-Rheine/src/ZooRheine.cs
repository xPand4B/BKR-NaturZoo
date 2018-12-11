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
        /*
        |-----------------------------------------------------------------------------
        |                               Management
        |-----------------------------------------------------------------------------
        */
        /**
         * Get Management count
         * 
         * @return String result
         **/
        public String GetManagementCount {
            get {
                return this.GetSingleValue(
                    "SELECT count(*) from management"
                );
            }
        }
        /**
         * Get Management data for datagrid
         * 
         * @return Datatable results
         **/
        public DataTable GetManagementGrid {
            get {
                return this.FillGridData("Management",
                    "SELECT email as 'E-Mail', created_at as 'Erstelldatum' " +
                    "FROM management " +
                    "ORDER BY created_at asc"
                );
            }
        }
        /**
         * Create new Management User
         * 
         * @param Management m
         * @return Boolean
         **/
        public Boolean CreateManagement(Management m)
        {
            return this.PushData(string.Format(
                "INSERT INTO management (email, password) " +
                "VALUES ('{0}', '{1}')",
                m.email, Hashmanager.Hash(m.password)
            ));
        }


        /*
        |-----------------------------------------------------------------------------
        |                               Guardian
        |-----------------------------------------------------------------------------
        */
        /**
         * Get Guardian count
         * 
         * @return String result
         **/
        public String GetGuardianCount {
            get {
                return this.GetSingleValue(
                    "SELECT count(*) from guardian"
                );
            }
        }
        /**
         * Get Guardian data for datagrid
         * 
         * @return Datatable results
         **/
        public DataTable GetGuardianGrid {
            get {
                return this.FillGridData("guardian",
                    "SELECT name as 'Vorname', surname as 'Nachname', birthday as 'Geb.' " +
                    "FROM guardian " +
                    "ORDER BY created_at asc"
                );
            }
        }
        /**
         * Create new Guardian
         * 
         * @param Guardian g
         * @return Boolean
         **/
        public Boolean CreateGuardian(Guardian g)
        {
            return this.PushData(string.Format(
                "INSERT INTO guardian (name, surname, birthday) " +
                "VALUES ('{0}', '{1}', '{2}')",
                g.name, g.surname, g.birthday
            ));
        }


        /*
        |-----------------------------------------------------------------------------
        |                               Gehege
        |-----------------------------------------------------------------------------
        */
        /**
         * Get Gehege count
         * 
         * @return String result
         **/
        public String GetGehegeCount {
            get {
                return this.GetSingleValue(
                    "SELECT count(*) from "
                );
            }
        }
        /**
         * Get Gehege data for datagrid
         * 
         * @return Datatable results
         **/
        public DataTable GetGehegeGrid {
            get {
                return this.FillGridData("gehege",
                    "SELECT " +
                    "FROM " +
                    "ORDER BY created_at asc"
                );
            }
        }
        /**
         * Create new Gehege
         * 
         * @param 
         * @return Boolean
         **/
        public Boolean CreateGehege()
        {
            return this.PushData(string.Format(
                "INSERT INTO gehege () " +
                "VALUES ('{0}', '{1}', '{2}')"
                
            ));
        }


        /*
        |-----------------------------------------------------------------------------
        |                               Animal
        |-----------------------------------------------------------------------------
        */
        /**
         * Get Animal count
         * 
         * @return String result
         **/
        public String GetAnimalCount {
            get {
                return this.GetSingleValue(
                    "SELECT count(*) from "
                );
            }
        }
        /**
         * Get Animal data for datagrid
         * 
         * @return Datatable results
         **/
        public DataTable GetAnimalGrid {
            get {
                return this.FillGridData("animal",
                    "SELECT " +
                    "FROM " +
                    "ORDER BY created_at asc"
                );
            }
        }
        /**
         * Create new Animal
         * 
         * @param Animal a
         * @return Boolean
         **/
        public Boolean CreateAnimal(Animal a)
        {
            return this.PushData(string.Format(
                "INSERT INTO animal () " +
                "VALUES ('{0}', '{1}', '{2}')"

            ));
        }


        /*
        |-----------------------------------------------------------------------------
        |                               Supplier
        |-----------------------------------------------------------------------------
        */
        /**
         * Get Supplier count
         * 
         * @return String result
         **/
        public String GetSupplierCount {
            get {
                return this.GetSingleValue(
                    "SELECT count(*) from supplier"
                );
            }
        }
        /**
         * Get Supplier data for datagrid
         * 
         * @return Datatable results
         **/
        public DataTable GetSupplierGrid {
            get {
                return this.FillGridData("Supplier",
                    "SELECT " +
                    "FROM " +
                    "ORDER BY created_at asc"
                );
            }
        }
        /**
         * Create new Supplier
         * 
         * @param 
         * @return Boolean
         **/
        public Boolean CreateSupplier()
        {
            return this.PushData(string.Format(
                "INSERT INTO supplier() " +
                "VALUES ('{0}', '{1}', '{2}')"

            ));
        }


        /*
        |-----------------------------------------------------------------------------
        |                               Food
        |-----------------------------------------------------------------------------
        */
        /**
         * Get Food data for datagrid
         * 
         * @return Datatable results
         **/
        public DataTable GetFoodGrid {
            get {
                return this.FillGridData("Food",
                    "SELECT " +
                    "FROM " +
                    "ORDER BY created_at asc"
                );
            }
        }
        /**
         * Create new Food
         * 
         * @param 
         * @return Boolean
         **/
        public Boolean CreateFood()
        {
            return this.PushData(string.Format(
                "INSERT INTO food() " +
                "VALUES ('{0}', '{1}', '{2}')"

            ));
        }

    }
}
