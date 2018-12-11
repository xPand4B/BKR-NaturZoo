using System;
using MySql.Data.MySqlClient;

/*
|-----------------------------------------------------------------------------
| Connector interface
|-----------------------------------------------------------------------------
|
| //
|
*/
namespace NaturZoo_Rheine.src.Database.Connection
{
    interface IConnector
    {
        /**
         * @var MySqlConnection _conn
         **/
        MySqlConnection _conn { get; }

        /**
         * Check Connection at startup
         * 
         * @return Boolean
         **/
        Boolean CheckConnection();

        /**
         * Create Database Connection
         * 
         * @return Boolean
         **/
        Boolean Connect();

        /**
         * Close Database Connection
         * 
         * @return Boolean
         **/
        Boolean Close();
    }
}
