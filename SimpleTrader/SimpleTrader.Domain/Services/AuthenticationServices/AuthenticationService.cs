using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordNotMatch;
            }

            var emailAccount = await _accountService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExist;
            }

            var userNameAccount = await _accountService.GetByUserName(username);
            if (userNameAccount != null)
            {
                result = RegistrationResult.UserNameAlreadyExist;
            }

            if (result == RegistrationResult.Success)
            {
                var hashedPassword = _passwordHasher.HashPassword(password);

                var user = new User
                {
                    Email = email,
                    UserName = username,
                    PasswordHash = hashedPassword,
                    DateJoined = DateTime.Now
                };

                var account = new Account() { AccountHolder = user };
                await _accountService.Create(account);
            }

            return result;
        }

        public async Task<Account> Login(string username, string password)
        {
            var account = await _accountService.GetByUserName(username);
            if (account == null)
            {
                throw new UserNotFoundException(username);
            }
            var result = _passwordHasher.VerifyHashedPassword(account.AccountHolder.PasswordHash, password);
            if (result != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return account;
        }
    }
}
