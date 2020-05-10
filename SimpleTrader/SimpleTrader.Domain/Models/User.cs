using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.Domain.Models
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
