using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Service
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAll();
        BookDto GetById(int id);
        int Create(CreateBookDto dto);
        public void Delete(int id);
        public void Update(int id, UpdateBookDto dto);
    }
    public class BookService : IBookService
    {
        private LibraryDbContext _dbContext;
        private IMapper _mapper;
        private ILogger _logger;

        public BookService(LibraryDbContext dbContext, IMapper mapper, ILogger<BookService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public int Create(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);

                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();

            return book.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Book with id: {id} DELETE action invoked.");

            var book = _dbContext
                .Books
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                throw new NotFoundException("Book not found.");
            }

            _dbContext.Remove(book);
            _dbContext.SaveChanges();
        }

        public IEnumerable<BookDto> GetAll()
        {
            var books = _dbContext
                .Books
                .Include(b => b.Author)
                .ToList();

            var bookDtos = _mapper.Map<List<BookDto>>(books);

            return bookDtos;
        }

        public BookDto GetById(int id)
        {
            var book = _dbContext
                .Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                throw new NotFoundException("Book not found.");
            }

            var result = _mapper.Map<BookDto>(book);

            return result;
        }

        public void Update(int id, UpdateBookDto dto)
        {
            var book = _dbContext
                .Books
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                throw new NotFoundException("Book not found.");
            }

            book.Name = dto.Name;
            book.BookType = dto.BookType;
            _dbContext.SaveChanges();


        }
    }
}
