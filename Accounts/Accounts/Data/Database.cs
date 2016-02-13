namespace CashFlowManager.Data {
    class Database
    {
        public Database(string datasource)
        {
            DataSource = datasource;
        }

        protected string DataSource { get; }

        protected enum DatabaseNames
        {
            CashFlowManager
        }
    }
}
