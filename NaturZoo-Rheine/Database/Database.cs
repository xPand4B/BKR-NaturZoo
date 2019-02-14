using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NaturZoo_Rheine.Models;

namespace NaturZoo_Rheine.Database
{
    public class Database : MySqlConnector
    {
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private readonly String DB_Database;


        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database(Config config) : base(config)
        {
            DB_Database = config.DB_Database;
            cmd = this._conn.CreateCommand();

            // Check connection
            if (!this.CheckConnection()) {
                /// TODO: Add Event for file log.
                /*
                CreateLog(new Log() {
                    Status = Log.status.Error,
                    Message = "Database connection could not be established. Application has been closed."
                });
                */

                Environment.Exit(1);

            } else {
                // Create Log
                CreateLog(new Log {
                    Status = Log.status.Info,
                    Message = "Database connection successfully established."
                });
            }
        }

        /// <summary>
        /// Adds the specified entity
        /// </summary>
        /// <param name="tableName">The Tablename</param>
        /// <param name="fillableFields">The fields to fill</param>
        /// <param name="values">The values</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="tableName"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="fillableFields"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="values"/> is null</exception>
        public void Add(String tableName, List<string> fillableFields, List<string> values)
        {
            if(string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            if(fillableFields.Count == 0)
                throw new ArgumentNullException("fillableFields");

            if(values.Count == 0)
                throw new ArgumentNullException("values");

            int count = fillableFields.Count;

            try {
                String query = "INSERT INTO " + tableName + "(";

                for (int i = 0; i < count; i++) {
                    query += fillableFields[i];

                    if (i != count - 1)
                        query += ", ";
                }

                query += ") VALUES (";

                for (int i = 0; i < count; i++) {
                    if(values[i] == null)
                        query += "null";
                    else
                        query += "'" + values[i] + "'";

                    if (i != count - 1)
                        query += ", ";
                }

                query += ")";

                Console.WriteLine(tableName + " :: Database.Add query:\n" + query + Environment.NewLine);

                this.Connect();
                // Set Query
                cmd.CommandText = query;
                // Run Query
                cmd.ExecuteNonQueryAsync();
               
                this.Close();

                // Create Log
                CreateLog(new Log() {
                    Status = Log.status.Update,
                    Message = "New entry has been added to the " + tableName + " table."
                });

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");

                this.Close();

                // Create Log
                CreateLog(new Log() {
                    Status = Log.status.Error,
                    Message = "Could not add new entity to the " + tableName + " table."
                });
            }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        /// <param name="tableName">The tablename</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="tableName"/> is null</exception>
        public DataTable GetAll(String tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            try {
                String query = "SELECT * FROM " + tableName + " ORDER BY created_at desc";

                Console.WriteLine(tableName + " :: Database.GetAll query:\n" + query + Environment.NewLine);

                this.Connect();

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, this._conn);
                DataSet ds = new DataSet();
                adapter.FillAsync(ds, tableName);

                this.Close();

                return ds.Tables[tableName];

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();
                return null;
            }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        /// <param name="showable">The fields to show</param>
        /// <param name="tableName">The tablename</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="showable"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="tableName"/> is null</exception>
        public DataTable GetAll(List<string> showable, String tableName)
        {
            if (showable.Count == 0)
                throw new ArgumentNullException("showable");

            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            try {
                String query = "SELECT ";

                for (int i = 0; i < showable.Count; i++) {
                    query += showable[i];

                    if(i != showable.Count - 1)
                        query += ", ";
                }

                query += " FROM " + tableName +
                         " ORDER BY created_at desc";

                Console.WriteLine(tableName + " :: Database.GetAll query:\n" + query + Environment.NewLine);

                this.Connect();

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, this._conn);
                DataSet ds = new DataSet();
                adapter.FillAsync(ds, tableName);

                this.Close();

                return ds.Tables[tableName];

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();
                return null;
            }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        /// <param name="showable">The fields to show</param>
        /// <param name="tableName">The tablename</param>
        /// <param name="foreignTable">The tablename</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="showable"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="tableName"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="foreignTable"/> is null</exception>
        public DataTable GetAll(List<string> showable, String tableName, List<string> foreignTable)
        {
            if(showable.Count == 0)
                throw new ArgumentNullException("showable");

            if(string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            if(foreignTable.Count == 0)
                throw new ArgumentNullException("foreignTable");

            try
            {
                String query = "SELECT ";

                for(int i = 0; i < showable.Count; i++)
                {
                    query += showable[i];

                    if(i != showable.Count - 1)
                        query += ", ";
                }

                query += " FROM " + tableName;

                if(foreignTable.Count != 0) {
                    foreach(String table in foreignTable) {
                        query += ", " + table;
                    }

                    query += " WHERE " + tableName + ".fk_" + foreignTable[0] + "Id = " + foreignTable[0] + ".Id ";

                    if(foreignTable.Count > 1){
                        for(int i = 1; i < foreignTable.Count; i++){
                            query += "AND " + tableName + ".fk_" + foreignTable[i] + "Id = " + foreignTable[i] + ".Id ";
                        }
                    }
                }

                query += " ORDER BY " + tableName + ".created_at desc";

                Console.WriteLine(tableName + " :: Database.GetAll query:\n" + query + Environment.NewLine);

                this.Connect();

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, this._conn);
                DataSet ds = new DataSet();
                adapter.FillAsync(ds, tableName);

                this.Close();

                return ds.Tables[tableName];

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();
                return null;
            }
        }

        /// <summary>
        /// Get dropdown items.
        /// </summary>
        /// <param name="tableName">The tablename</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="tableName"/> is null</exception>
        public DataTable GetDropdown(String tableName)
        {
            if(string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            try
            {
                String query = "SELECT * FROM " + tableName + " ORDER BY created_at desc";
                
                Console.WriteLine(tableName + " :: Database.GetDropdown query:\n" + query + Environment.NewLine);

                this.Connect();

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, this._conn);
                DataSet ds = new DataSet();
                adapter.FillAsync(ds, tableName);

                this.Close();

                return ds.Tables[tableName];

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();
                return null;
            }
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        /// <param name="tableName">The table name</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="tableName"/> is null</exception>
        public String LastUpdate(String tableName)
        {
            if(string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName");

            try {
                String query = string.Format(
                    "SELECT UPDATE_TIME " +
                    "FROM information_schema.tables " +
                    "WHERE TABLE_SCHEMA = '{0}' " +
                      "AND TABLE_NAME = '{1}' " +
                    "LIMIT 1",
                    DB_Database, tableName
                );

                Console.WriteLine(tableName + " :: Database.LastUpdate query:\n" + query + Environment.NewLine);

                this.Connect();

                // Set Query
                cmd.CommandText = query;
                // Run Query
                reader = cmd.ExecuteReader();

                String result = "";

                if (reader.Read()) {
                    if (!string.IsNullOrEmpty(reader[0].ToString()))
                        result = Convert.ToDateTime(reader[0]).ToString("dd.MM.yyyy - HH:mm").ToString() + " Uhr";
                    else
                        result = "undefined";
                }

                this.Close();
                
                return result;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();
                return null;
            }
        }

        /// <summary>
        /// Update data for the specified entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        public void Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a count <seealso cref="String"/> from the specified entity.
        /// </summary>
        /// <param name="tableName">The tablename</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="tableName"/> is null</exception>
        public String Count(String tableName)
        {
            if(string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tablename");

            try {
                String query  = "SELECT count(*) FROM " + tableName;
                String result = "";

                Console.WriteLine(tableName + " :: Database.Count query:\n" + query + Environment.NewLine);

                this.Connect();

                // Set Query
                cmd.CommandText = query;
                // Run Query
                reader = cmd.ExecuteReader();

                if (reader.Read())
                    result = reader[0].ToString();

                this.Close();

                return result;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();

                return null;
            }
        }

        /// <summary>
        /// Create a log.
        /// </summary>
        /// <param name="log">The <see cref="Log"/> parameter</param>
        private void CreateLog(Log log)
        {
            try {
                String query = string.Format(
                    "INSERT INTO log(status, message) " +
                    "VALUES ('{0}', '{1}')",
                    log.Status.ToString(), log.Message
                );

                Console.WriteLine("log :: Database.CreateLog query:\n" + query + Environment.NewLine);

                this.Connect();
                // Set Query
                cmd.CommandText = query;
                // Run Query
                cmd.ExecuteNonQueryAsync();

                this.Close();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();
            }
        }

        /// <summary>
        /// Runs a specified query.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="query">The tablename</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="query"/> is null</exception>
        public DataTable Query(String query)
        {
            if(string.IsNullOrEmpty(query))
                throw new ArgumentNullException("query");

            try
            {
                Console.WriteLine("Custom :: Database.Query query:\n" + query + Environment.NewLine);

                this.Connect();

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, this._conn);
                DataSet ds = new DataSet();
                adapter.FillAsync(ds, "special");

                this.Close();

                return ds.Tables["special"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "MySql Connection Error");
                this.Close();
                return null;
            }
        }
    }
}
