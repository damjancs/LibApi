using AutoMapper;
using LibApi.Entities;
using LibApi.Models;
using Microsoft.EntityFrameworkCore;
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
    }
    public class BookService : IBookService
    {
        private LibraryDbContext _dbContext;
        private IMapper _mapper;

        public BookService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);

                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();

            return book.Id;
        }

        public IEnumerable<BookDto> GetAll()
        {
            var books = _dbContext
                .Books
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
                throw new Exception("Book not found.");
            }

            var result = _mapper.Map<BookDto>(book);

            return result;
        }
    }
}
