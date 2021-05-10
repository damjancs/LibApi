using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibApi.Services
{
    public interface IBorrowService 
    {
        int BorrowBook(int bookId, CreateBorrowDto dto);
        IEnumerable<BorrowDto> GetAll();
    }
    public class BorrowService : IBorrowService
    {
        private LibraryDbContext _dbContext;
        private IMapper _mapper;

        public BorrowService(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int BorrowBook(int bookId, CreateBorrowDto dto)
        {
            var book = _dbContext.Books
                .FirstOrDefault(b => b.Id == bookId);

            if (book is null)
            {
                throw new NotFoundException("Book not found.");
            }

            var borrowEntity = _mapper.Map<Borrow>(dto);

            borrowEntity.BookId = bookId;
            borrowEntity.TakenDate = DateTime.Now;

            _dbContext.Borrows.Add(borrowEntity);
            _dbContext.SaveChanges();

            return borrowEntity.Id;

        }

        public IEnumerable<BorrowDto> GetAll()
        {
            var borrows = _dbContext
                .Borrows
                .Include(b => b.User)
                .Include(b => b.Book)
                .ToList();

            var borrowDtos = _mapper.Map<List<BorrowDto>>(borrows);

            return borrowDtos;
        }
    }
}
