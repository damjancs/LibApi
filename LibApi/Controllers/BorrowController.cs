using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;
using LibApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibApi.Controllers
{
    [Route("api/library/borrow")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private IBorrowService _borrowService;
        private LibraryDbContext _dbContext;
        private IMapper _mapper;

        public BorrowController(IBorrowService borrowService, LibraryDbContext dbContext, IMapper mapper)
        {
            _borrowService = borrowService;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost("{bookId}")]
        [Authorize(Roles = "User")]
        public ActionResult Borrow([FromRoute] int bookId, [FromBody] CreateBorrowDto dto)
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
            borrowEntity.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            _dbContext.Borrows.Add(borrowEntity);
            _dbContext.SaveChanges();


            return Created($"api/library/borrow/{bookId}/dish/{borrowEntity.Id}", null);
        }

        [HttpGet]
        public ActionResult<BorrowDto> GetAll()
        {
            var borrowsDtos = _borrowService.GetAll();

            return Ok(borrowsDtos);
        }
    }
}
