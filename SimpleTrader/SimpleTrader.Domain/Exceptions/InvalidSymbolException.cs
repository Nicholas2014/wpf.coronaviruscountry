using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        public InvalidSymbolException(string symbol)
        {

        }

        public InvalidSymbolException(string symbol, string message) : base(message)
        {

        }

        public InvalidSymbolException(string symbol, string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
