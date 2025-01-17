﻿using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        Task<RegistrationResult> Register(string email, string username, string password, string confirmpassword);
        Task<bool> Login(string username, string password);
        void Logout();
        event Action StateChanged;
    }
}
