using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowManager.Configuration {
    class ErrorLog {
        public static void CreateError(ErrorType type, string message ) {
            
        }

        public enum ErrorType
        {
            ErrorDatabaseConnection,
            ErrorDatabaseQuery
        }
    }
}
