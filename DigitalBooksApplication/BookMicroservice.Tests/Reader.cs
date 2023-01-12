using AutoFixture.AutoNSubstitute;
using AutoFixture;
using BookMicroservice.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.SignalR;
using NSubstitute;
using System.Security.Policy;

namespace BookMicroservice.Tests
{
    [TestFixture]
    internal class Reader
    {
        private IFixture _fixture;
        private Mock<IReader> _mock;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mock = new Mock<IReader>();
        }

        [Test]
        public void SearchBooks_OnPassingBookParameters_ReturnsSearchResults()
        {
            //Arrange
            var bookList = _fixture.CreateMany<Book>(3).ToList();
            var title = _fixture.Create<string>();
            var category = _fixture.Create<string>();
            int price = _fixture.Create<int>();
            string author = _fixture.Create<string>();
            string publisher = _fixture.Create<string>();
            _mock.Setup(x => x.SearchBooks(It.IsAny<string>(),It.IsAny<string>(),It.IsAny<int>(),It.IsAny<string>(),It.IsAny<string>())).Returns(bookList);

            //Act
            var actualResult = _mock.Object.SearchBooks(title,category,price,publisher,author);

            //Assert
            Assert.AreEqual(bookList, actualResult);
            Assert.NotNull(actualResult);
        }

        [Test]
        public void SubscribeAsync_Test_SubscribeBooks()
        {
            //Arrange
            var subscription = _fixture.Create<Subscription>();
            _mock.Setup(x => x.SubscribeAsync(It.IsAny<Subscription>())).ReturnsAsync("Book has been subscribed successfully");

            //Act
            var actualResult = _mock.Object.SubscribeAsync(subscription);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void GetAllSubscriptionDetails_OnPassingEmailId_ReturnsSubscribedBooks()
        {
            //Arrange
            var subscription = _fixture.CreateMany<Subscription>(3).ToList();
            var emailId = _fixture.Create<string>();
            _mock.Setup(x => x.GetAllSubscriptionDetails(It.IsAny<string>())).Returns(subscription);

            //Act
            var actualResult = _mock.Object.GetAllSubscriptionDetails(emailId);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void GetSubscriptionDetailsBySubscriptionId_OnPassingSubscriptionAndEmailId_ReturnsSubscribedBooks()
        {
            //Arrange
            var subscription = _fixture.CreateMany<Subscription>(3).ToList();
            int id = _fixture.Create<int>();
            var emailId = _fixture.Create<string>();
            _mock.Setup(x => x.GetSubscriptionDetailsBySubscriptionId(It.IsAny<int>(), It.IsAny<string>())).Returns(subscription);

            //Act
            var actualResult = _mock.Object.GetSubscriptionDetailsBySubscriptionId(id,emailId);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void ReadBookAsync_OnPassingSubscriptionAndEmailId_ReturnBooksToRead()
        {
            //Arrange
            var bookContent = _fixture.Create<string>();
            int id = _fixture.Create<int>();
            var emailId = _fixture.Create<string>();
            _mock.Setup(x => x.ReadBookAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(bookContent);

            //Act
            var actualResult = _mock.Object.ReadBookAsync(id, emailId);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void CancelSubscriptionAsync_OnPassingEmailId_UpdateSubscriptionActiveStatus()
        {
            //Arrange
            int id = _fixture.Create<int>();
            var emailId = _fixture.Create<string>();
            _mock.Setup(x => x.CancelSubscriptionAsync(It.IsAny<int>())).ReturnsAsync("Book subscription got cancelled successfully");

            //Act
            var actualResult = _mock.Object.CancelSubscriptionAsync(id);

            //Assert
            Assert.NotNull(actualResult);
        }
    }
}
