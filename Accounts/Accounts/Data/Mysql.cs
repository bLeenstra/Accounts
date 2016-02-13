using System;
using System.Windows.Forms;
using CashFlowManager.Configuration;
using CashFlowManager.Properties;
using MySql.Data.MySqlClient;

namespace CashFlowManager.Data {
    class Mysql : Database
    {
        private readonly uint _port;
        private readonly string _username;
        private readonly string _password;


        public Mysql(string datasource, uint port, string username, string password) : base(datasource)
        {
            _port = port;
            _username = username;
            _password = password;

            //test the connection
            using (MySqlConnection conn = GetConnection(DatabaseNames.CashFlowManager) )
            {
                if (!OpenConnection(conn)) {
                    //throw invalid credentials error or something
                }
                conn.Close();
            }

        }

        /// <summary>
        /// Creates a new connection to the database.
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        private MySqlConnection GetConnection(DatabaseNames database)
        {
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder
            {
                Server = base.DataSource,
                Database = HelperFunctions.EnumHelpers.EnumName(database),
                Port = _port,
                UserID = _username,
                Password = _password
            };

            MySqlConnection conn = new MySqlConnection(connString.ConnectionString);
            return conn;
        }

        private bool OpenConnection(MySqlConnection conn)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.MysqlConnectionFailure);
                Configuration.ErrorLog.CreateError(ErrorLog.ErrorType.ErrorDatabaseConnection, ex.Message);
                return false;
            }
            return true;
        }
    }
}
