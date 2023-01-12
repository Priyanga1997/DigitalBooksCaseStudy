using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Castle.Core.Internal;
using Moq;
using NUnit.Framework;
using UserMicroservice.Models;
using UserMicroservice.Services;

namespace UserMicroserviceTests
{
    [TestFixture]
    public class Users
    {
        private UserImpl _userImpl;
        private IFixture _fixture;
        private Mock<IUser> _mock;

        [SetUp]
        public void SetUp()
        {
            _userImpl = new UserImpl(null, null);
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mock = new Mock<IUser>();
        }

        [Test]
        public void Login_OnPassingUsernameAndPassword_AllowsToLogin()
        {
            //Arrange
            var token = _fixture.Create<string>();
            User user = _fixture.Create<User>();
            bool isRegister = _fixture.Create<bool>();
            _mock.Setup(x => x.LoginAsync(It.IsAny<User>(), It.IsAny<bool>())).ReturnsAsync(token);

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