using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException(string userName)
        {
            UserName = userName;
        }

        public UserNotFoundException(string message, string userName) : base(message)
        {
            UserName = userName;
        }

        public UserNotFoundException(string message, Exception innerException, string userName) : base(message, innerException)
        {
            UserName = userName;
        }

        public string UserName { get; set; }

    }
}
