using FakeItEasy;
using LibApi.Controllers;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;
using LibApi.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LibApi_tests
{
    public class BookControllerTest
    {
        private Mock<IBookService> _bookService;
        private BookController _controller;

        public BookControllerTest()
        {
            _bookService = new Mock<IBookService>();
            _controller = new BookController(_bookService.Object);
        }
        [Fact]
        public void Get_ExistingBookPassed_ReturnsOkResult()
        {
            // Arange
            _bookService.Setup(book => book.GetById(It.IsAny<int>()));
            // Act
            var result = _controller.Get(4);

            // Assert

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Create_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            CreateBookDto dto = new CreateBookDto()
            {
                Name = "C# Book",
                PageCount = 425,
                BookType = "Learning"
            };

            // Act
            var result = _controller.CreateBook(dto);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void GetAll_ValidBooksPassed_ShouldNotBeNull()
        {
            // Arrange
            var books = GetBooks();
            _bookService.Setup(b => b.GetAll())
                .Returns(books);

            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.NotNull(result);

        }
        private IEnumerable<BookDto> GetBooks()
        {
            var books = new List<BookDto>();
            books.Add(new BookDto { Id = 1, Name = "a" });
            books.Add(new BookDto { Id = 2, Name = "b" });
            books.Add(new BookDto { Id = 3, Name = "c" });
            books.Add(new BookDto { Id = 4, Name = "d" });

            return books;
        }
    }
}
