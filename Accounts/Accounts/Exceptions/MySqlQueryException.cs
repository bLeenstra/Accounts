using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowManager.Exceptions {
    class MySqlQueryException : Exception {
        public MySqlQueryException() {

        }

        public MySqlQueryException(string message) : base(message) {

        }

        public MySqlQueryException(string message, Exception inner) : base(message, inner) {

        }
    }
}
