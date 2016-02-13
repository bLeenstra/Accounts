using System;
using MySql.Data.MySqlClient;

namespace CashFlowManager.Data {
    class Mysql : Database
    {
        private int _port;
        private string _username;
        private string _password;


        public Mysql(string datasource, int port, string username, string password) : base(datasource)
        {
            _port = port;
            _username = username;
            _password = password;

        }

        private MySqlConnection GetConnection(DatabaseNames database)
        {
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
            connString.Server = base.DataSource;
            //connString.Database = Helpers.EnumHelper.EnumName(database);

            MySqlConnection conn = new MySqlConnection(connString.ConnectionString);
            return conn;
        }
    }
}
