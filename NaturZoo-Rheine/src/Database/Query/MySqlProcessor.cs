using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NaturZoo_Rheine.src.Database.Query {
    /// <summary>
    ///     
    /// </summary>
    internal struct MySqlProcessor
    {
        /// <summary>
        ///     Run query and return <seealso cref="DataTable"/> for datagrid.
        /// </summary>
        /// <param name="conn">The MySqlConnecion variable.</param>
        /// <param name="tableName">The Tablename</param>
        /// <param name="query">The query string.</param>
        /// <returns name="DataTable">
        ///     <seealso cref="DataTable"/> result based on the query.
        /// </returns>
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

        /// <summary>
        ///     Run query and return a single <seealso cref="String"/> as result.
        /// </summary>
        /// <param name="conn">The MySqlConnecion variable.</param>
        /// <param name="query">The query string.</param> 
        /// <returns name="String">
        ///     <seealso cref="String"/> result based on the query.
        /// </returns>
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

        /// <summary>
        ///     Push data to the database and return a <seealso cref="Boolean"/>.
        /// </summary>
        /// <param name="conn">The MySqlConnecion variable.</param>
        /// <param name="query">The query string.</param> 
        /// <returns name="Boolean">
        ///     <c>true</c> if the data has been pushed successfully; otherwise, <c>false</c>.
        /// </returns>
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
