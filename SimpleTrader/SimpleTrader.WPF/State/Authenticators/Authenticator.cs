using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.WPF.State.Accounts;
using System;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator :  IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService,IAccountStore accountStore)
        {
            this._authenticationService = authenticationService;
            this._accountStore = accountStore;
        }

        public Account CurrentAccount
        {
            get { return _accountStore.CurrentAccount; }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;


        public bool IsLoggedIn => CurrentAccount != null;

        public async Task<bool> Login(string username, string password)
        {
            try
            {
                CurrentAccount = await _authenticationService.Login(username, password);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmpassword)
        {
            return await _authenticationService.Register(email, username, password, confirmpassword);
        }
    }
}
