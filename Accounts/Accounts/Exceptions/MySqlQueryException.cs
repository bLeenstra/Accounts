using System;

namespace CashFlowManager.Exceptions
{
    internal class MySqlQueryException : Exception
    {
        public MySqlQueryException()
        {
        }

        public MySqlQueryException(string message) : base(message)
        {
        }

        public MySqlQueryException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}