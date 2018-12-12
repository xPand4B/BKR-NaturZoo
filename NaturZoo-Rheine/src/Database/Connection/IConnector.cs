using System;
using MySql.Data.MySqlClient;

namespace NaturZoo_Rheine.src.Database.Connection
{
    /// <summary>
    ///     Provides the Connector base structure.
    /// </summary>
    interface IConnector
    {
        MySqlConnection _conn { get; }


        /// <summary>
        ///     Check connection at startup.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection is available; otherwise, <c>false</c>.
        /// </returns>
        Boolean CheckConnection();

        /// <summary>
        ///     Create database connection.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection has been opened successfully; otherwise, <c>false</c>.
        /// </returns>
        Boolean Connect();

        /// <summary>
        ///     Close database connection.
        /// </summary>
        /// <returns name="Boolean">
        ///     <c>true</c> if the connection has been closed successfully; otherwise, <c>false</c>.
        /// </returns> 
        Boolean Close();
    }
}
