using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public InvalidPasswordException(string userName, string password, string message) : base(message)
        {
            UserName = userName;
            Password = password;
        }

        public InvalidPasswordException(string userName, string password, string message, Exception innerException) : base(message, innerException)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }


    }
}
