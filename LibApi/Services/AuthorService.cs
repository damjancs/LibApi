using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Service
{
    public interface IAuthorService
    {
        int Create(int bookId, CreateAuthorDto dto);
        void Remove(int bookId);
    }

    public class AuthorService : IAuthorService
    {
        private LibraryDbContext _dbContext;
        private IMapper _mapper;

        public AuthorService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(int bookId, CreateAuthorDto dto)
        {
            //var book = GetBookById(bookId);

            var authorEntity = _mapper.Map<Author>(dto);

            authorEntity.BookId = bookId;

            _dbContext.Authors.Add(authorEntity);
            _dbContext.SaveChanges();

            return authorEntity.Id;
        }

        public void Remove(int bookId)
        {
            var book = GetBookById(bookId);

            _dbContext.Remove(book.Author);
            _dbContext.SaveChanges();
        }

        private Book GetBookById(int BookId)
        {
            var book = _dbContext.Books
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == BookId);

            if (book is null)
            {
                throw new NotFoundException("Restaurant not found.");
            }
            return book;
        }
    }
}
