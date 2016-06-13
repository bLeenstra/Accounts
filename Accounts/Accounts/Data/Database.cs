using System;
using System.Data;
using CashFlowManager.Enums;
using CashFlowManager.Exceptions;
using CashFlowManager.Helpers;
using MySql.Data.MySqlClient;

namespace CashFlowManager.Data
{
    public sealed class Database : IDisposable
    {
        private static string _address;
        private static uint _port;
        private static string _username;
        private static string _password;
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;

        public Database()
        {
            //get connection
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder
            {
                Server = _address,
                Port = _port,
                UserID = _username,
                Password = _password
            };
            _connection = new MySqlConnection(connString.ConnectionString);

            //create new transaction
            OpenConnection(_connection);
            _transaction = _connection.BeginTransaction();
        }

        public Database(DatabaseNames database)
        {
            //get connection
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder
            {
                Server = _address,
                Database = database.Name(),
                Port = _port,
                UserID = _username,
                Password = _password
            };
            _connection = new MySqlConnection(connString.ConnectionString);

            //create new transaction
            OpenConnection(_connection);
            _transaction = _connection.BeginTransaction();
        }

        public void Dispose()
        {
            // get rid of managed resources, call Dispose on member variables...
            _transaction.Dispose();
            _connection.Dispose();
        }

        /// <summary>
        ///     Sets the Database connection values
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static bool SetDatabaseConnection(string address, uint port, string username, string password)
        {
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder
            {
                Server = address,
                Port = port,
                UserID = username,
                Password = password
            };
            using (MySqlConnection conn = new MySqlConnection(connString.ConnectionString))
            {
                try
                {
                    OpenConnection(conn);
                }
                catch (MySqlException)
                {
                    return false;
                }
                _address = address;
                _port = port;
                _username = username;
                _password = password;
            }
            return true;
        }

        /// <summary>
        ///     Executes a query inside a MySqlTransaction object and returns the value in position [0,0]
        /// </summary>
        /// <param name="query">The Query you wish to execute</param>
        /// <param name="parameters">The MySqlParameter you wish to attach to the query</param>
        /// <returns>The value in position [0,0]</returns>
        internal T GetDataSingleResult<T>(string query, MySqlParameter[] parameters)
        {
            MySqlConnection conn = CheckConnectionValid();
            using (MySqlCommand cmd = CreateCommand(conn, query, parameters))
            {
                try
                {
                    object value = cmd.ExecuteScalar();
                    return (T) Convert.ChangeType(value, typeof (T));
                }
                catch (MySqlException ex)
                {
                    TransactionRollback();
                    throw new MySqlQueryException("Encountered an error running the query", ex);
                }
            }
        }

        /// <summary>
        ///     Executes a query inside a MySqlTransaction object and returns a datatable of the results
        /// </summary>
        /// <param name="query">The Query you wish to execute</param>
        /// <param name="parameters">The MySqlParameter you wish to attach to the query</param>
        /// <returns>A DataTable containing the results view</returns>
        internal DataTable GetDataTable(string query, MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = CheckConnectionValid();
            using (MySqlCommand cmd = CreateCommand(conn, query, parameters))
            {
                try
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        ds.EnforceConstraints = false;
                        dt.Load(dr);
                    }
                }
                catch (MySqlException ex)
                {
                    TransactionRollback();
                    throw new MySqlQueryException("Encountered an error running the query", ex);
                }
            }
            return dt;
        }

        internal long SetDataReturnLastInsertId(string query, MySqlParameter[] parameters)
        {
            using (MySqlCommand cmd = SetData(query, parameters))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    return cmd.LastInsertedId;
                }
                catch (MySqlException ex)
                {
                    TransactionRollback();
                    throw new MySqlQueryException("Encountered an error running the query", ex);
                }
            }
        }

        internal int SetDataReturnRowCount(string query, MySqlParameter[] parameters)
        {
            using (MySqlCommand cmd = SetData(query, parameters))
            {
                try
                {
                    int value = cmd.ExecuteNonQuery();
                    return value;
                }
                catch (MySqlException ex)
                {
                    TransactionRollback();
                    throw new MySqlQueryException("Encountered an error running the query", ex);
                }
            }
        }

        internal void SetDataReturnNone(string query, MySqlParameter[] parameters)
        {
            using (MySqlCommand cmd = SetData(query, parameters))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    TransactionRollback();
                    throw new MySqlQueryException("Encountered an error running the query", ex);
                }
            }
        }

        /// <summary>
        ///     Executes a query inside a MySqlTransaction object and returns meta information about the query
        /// </summary>
        /// <param name="query">The Query you wish to execute</param>
        /// <param name="parameters">The MySqlParameter you wish to attach to the query</param>
        /// <returns>A long value containing info in relation to the returnInfo parameter</returns>
        private MySqlCommand SetData(string query, MySqlParameter[] parameters)
        {
            MySqlConnection conn = CheckConnectionValid();
            MySqlCommand cmd = CreateCommand(conn, query, parameters);
            return cmd;
        }

        /// <summary>
        ///     Commits the contents of the MySqlTransaction Object to the database.
        /// </summary>
        internal void TransactionCommit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (MySqlException)
            {
                _transaction.Rollback();
            }
        }

        private void TransactionRollback()
        {
            _transaction.Rollback();
        }

        private MySqlConnection CheckConnectionValid()
        {
            MySqlConnection conn = _transaction.Connection;
            if (conn.State != ConnectionState.Closed)
            {
                return conn;
            }
            OpenConnection(conn);
            return conn;
        }

        private MySqlCommand CreateCommand(MySqlConnection conn, string query, MySqlParameter[] parameters)
        {
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = query,
                Transaction = _transaction,
                Connection = conn
            };
            cmd.Parameters.AddRange(parameters);
            return cmd;
        }

        private static void OpenConnection(IDbConnection conn)
        {
            conn.Open();
        }
    }
}