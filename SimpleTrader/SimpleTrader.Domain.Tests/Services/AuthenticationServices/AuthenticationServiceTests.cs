using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.AuthenticationServices;

namespace SimpleTrader.Domain.Tests.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private Mock<IAccountService> _accountService;
        private Mock<IPasswordHasher> _passwordHasher;
        private IAuthenticationService _authenticationService;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _passwordHasher = new Mock<IPasswordHasher>();
            _authenticationService = new AuthenticationService(_accountService.Object, _passwordHasher.Object);
        }

        [Test]
        public async Task Login_WithCorrectPasswordForExistingUserName_ReturnsAccountForCorrectUserName()
        {
            // Arrange
            var expectUserName = "testuser";
            var password = "asdfatete";

            _accountService
                .Setup(a => a.GetByUserName(expectUserName))
                .ReturnsAsync(new Account() { AccountHolder = new User() { UserName = expectUserName } });

            _passwordHasher
                .Setup(p => p.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Success);

            // Act
            Account account = await _authenticationService.Login(expectUserName, password);

            // Assert
            string actualUserName = account.AccountHolder.UserName;
            Assert.AreEqual(expectUserName, actualUserName);

        }

        [Test]
        public void Login_WithInCorrectPasswordForExistingUserName_ThrowsInvalidPasswordForCorrectUserName()
        {
            // Arrange
            var expectUserName = "testuser";
            var password = "asdfatete";

            _accountService
                .Setup(a => a.GetByUserName(expectUserName))
                .ReturnsAsync(new Account() { AccountHolder = new User() { UserName = expectUserName } });

            _passwordHasher
                .Setup(p => p.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            // Act
            var ex = Assert.ThrowsAsync<InvalidPasswordException>(() => _authenticationService.Login(expectUserName, password));

            // Assert
            string actualUserName = ex.UserName;
            Assert.AreEqual(expectUserName, actualUserName);
        }

        [Test]
        public void Login_WithNonExistingUserName_ThrowsUserNotFoundForCorrectUserName()
        {
            // Arrange
            var expectUserName = "testuser";
            var password = "asdfatete";

            _passwordHasher
                .Setup(p => p.VerifyHashedPassword(It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Failed);

            // Act
            var ex = Assert.ThrowsAsync<UserNotFoundException>(() => _authenticationService.Login(expectUserName, password));

            // Assert
            string actualUserName = ex.UserName;
            Assert.AreEqual(expectUserName, actualUserName);
        }

        [Test]
        public async Task Register_WithPasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            // Arrange
            RegistrationResult expected = RegistrationResult.PasswordNotMatch;
            var password = "2222";
            var confirmPassword = "33444";

            // Act
            var actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), password, confirmPassword);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithEmailAlreadyExists_ReturnsEmailAlreadyExists()
        {
            RegistrationResult expected = RegistrationResult.EmailAlreadyExist;

            // Arrange
            var email = "test@126.com";
            _accountService.Setup(s => s.GetByEmail(email)).ReturnsAsync(new Account());

            // Act
            var actual = await _authenticationService.Register(email, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithUserNameAlreadyExists_ReturnsUserNameAlreadyExists()
        {
            RegistrationResult expected = RegistrationResult.UserNameAlreadyExist;

            // Arrange
            var username = "testuser";
            _accountService.Setup(s => s.GetByUserName(username)).ReturnsAsync(new Account());

            // Act
            var actual = await _authenticationService.Register(It.IsAny<string>(), username, It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task Register_WithNonExistintUserAndMatchingPasswords_ReturnsSuccess()
        {
            // Arrange
            RegistrationResult expected = RegistrationResult.Success;

            // Act
            var actual = await _authenticationService.Register(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
