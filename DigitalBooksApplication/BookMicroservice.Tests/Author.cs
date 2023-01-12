using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BookMicroservice.Models;
using BookMicroservice.Services;
using DigitalBooksApplication.Controllers;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Drawing.Text;

namespace BookMicroservice.Tests
{
    [TestFixture]
    internal class Author
    {
        private IFixture _fixture;
        private Mock<IAuthor> _mock;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mock = new Mock<IAuthor>();
        }

        [Test]
        public void Get_Test_ReturnAllBooks()
        {
            //Arrange
            var bookList = _fixture.CreateMany<Book>(3).ToList();
            _mock.Setup(x => x.Index()).Returns(bookList);

            //Act
            var actualResult = _mock.Object.Index();

            //Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(bookList, actualResult);
        }

        [Test]
        public void Get_Test_ReturnsNoBooks()
        {
            //Arrange
            var bookList = _fixture.CreateMany<Book>(0).ToList();
            _mock.Setup(x => x.Index()).Returns(bookList);

            //Act
            var actualResult = _mock.Object.Index();

            //Assert
            Assert.IsEmpty(actualResult);
        }

        [Test]
        public void Details_OnPassingEmailId_ReturnBooks()
        {
            //Arrange
            var bookList = _fixture.CreateMany<Book>(3).ToList();
            var emailId = _fixture.Create<string>();
            _mock.Setup(x => x.Details(It.IsAny<string>())).Returns(bookList);

            //Act
            var actualResult = _mock.Object.Details(emailId);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void CreateAsync_OnPassingBookDetails_CreateBooks()
        {
            //Arrange
            var bookModel = _fixture.Create<BookModel>();
            var book = _fixture.Create<Book>();
            var dbPath = _fixture.Create<string>();
            _mock.Setup(x => x.CreateAsync(It.IsAny<BookModel>(),It.IsAny<string>())).ReturnsAsync(book);

            //Act
            var actualResult = _mock.Object.CreateAsync(bookModel,dbPath);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void EditAsync_OnPassingBookId_UpdateBooks()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            var bookModel = _fixture.Create<BookModel>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.EditAsync(It.IsAny<BookModel>(), It.IsAny<int>())).ReturnsAsync(book);

            //Act
            var actualResult = _mock.Object.EditAsync(bookModel, id);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void DeleteAsync_OnPassingBookId_DeleteBooks()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(book);

            //Act
            var actualResult = _mock.Object.DeleteAsync(id);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void BlockBookAsync_OnPassingBookId_BlockBooks()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.BlockBookAsync(It.IsAny<int>())).ReturnsAsync(book);

            //Act
            var actualResult = _mock.Object.BlockBookAsync(id);

            //Assert
            Assert.NotNull(actualResult);
        }

        [Test]
        public void UnblockBookAsync_OnPassingBookId_UnblockBooks()
        {
            //Arrange
            var book = _fixture.Create<Book>();
            var id = _fixture.Create<int>();
            _mock.Setup(x => x.UnblockBookAsync(It.IsAny<int>())).ReturnsAsync(book);

            //Act
            var actualResult = _mock.Object.UnblockBookAsync(id);

            //Assert
            Assert.NotNull(actualResult);
        }
    }
}
