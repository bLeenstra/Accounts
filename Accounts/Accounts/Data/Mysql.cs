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

        private MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = base.DataSource;
            //conn_string.Database
            MySqlConnection conn = new MySqlConnection(conn_string.ConnectionString);
            return conn;
        }
    }
}
