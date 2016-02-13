using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Data {
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
