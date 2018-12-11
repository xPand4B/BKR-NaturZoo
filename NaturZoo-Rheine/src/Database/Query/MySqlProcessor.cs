using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

/*
|-----------------------------------------------------------------------------
| MySql Query Processor
|-----------------------------------------------------------------------------
|
| //
|
*/
namespace NaturZoo_Rheine.src.Database.Query
{
    class MySqlProcessor
    {
        /**
         * Run query and return result
         * 
         * @param MySqlConnection conn
         * @param String tableName
         * @param String query
         * @return DataTable results
         **/
        public static DataTable GetGridData(MySqlConnection conn, String tableName, String query)
        {
            try {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, tableName);

                return ds.Tables[tableName];

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                return null;
            }
        }

        /**
         * Run query and return a single result. 
         * This Method only returns the first found value.
         * 
         * @param MySqlConnection conn
         * @param String query
         * @return String result
         **/
        public static String GetSingleResult(MySqlConnection conn, String query)
        {
            try {
                // Set Query
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                // Run Query
                MySqlDataReader reader = cmd.ExecuteReader();

                String result = "";

                if (reader.Read()) {
                    result = reader[0].ToString();
                }
                return result;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                return null;
            }
        }

        /**
         * Push Data to the Database
         * 
         * @param MySqlConnection conn
         * @param String query
         * @return Boolean
         **/
        public static Boolean PushData(MySqlConnection conn, String query)
        {
            try {
                // Set Query
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                // Run Query
                cmd.ExecuteNonQuery();

                return true;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                return false;
            }
        }
    }
}
