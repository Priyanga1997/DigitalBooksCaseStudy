using AutoFixture.AutoNSubstitute;
using AutoFixture;
using Moq;
using NUnit.Framework;
using DigitalBooksAppln.Services;
using DigitalBooksAppln.Models;

namespace UnitTests
{
    [TestFixture]
    public class Users
    {
        private IFixture _fixture;
        private Mock<IUsers> _mock;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mock = new Mock<IUsers>();
        }

        [Test]
        public void Login_OnPassingUsernameAndPassword_AllowsToLogin()
        {
            //Arrange
            var loginModel = _fixture.Create<LoginModel>();
            User user = _fixture.Create<User>();
            bool isRegister = _fixture.Create<bool>();
            _mock.Setup(x => x.LoginAsync(It.IsAny<User>(), It.IsAny<bool>())).ReturnsAsync(loginModel);

            //Act
            var actualResult = _mock.Object.LoginAsync(user, isRegister);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void Register_OnPassingUsernameAndPassword_AddUser()
        {
            //Arrange
            var token = _fixture.Create<string>();
            User user = _fixture.Create<User>();
            bool isRegister = _fixture.Create<bool>();
            _mock.Setup(x => x.RegisterAsync(It.IsAny<User>(), It.IsAny<bool>())).ReturnsAsync(token);

            //Act
            var actualResult = _mock.Object.RegisterAsync(user, isRegister);

            //Assert
            Assert.NotNull(actualResult);
        }
    }
}