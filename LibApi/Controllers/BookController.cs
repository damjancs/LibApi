using LibApi.Models;
using LibApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Controllers
{
    [Route("api/library/book")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> GetAll()
        {
            var bookDtos = _bookService.GetAll();

            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDto> Get([FromRoute] int id)
        {
            var book = _bookService.GetById(id);

            return Ok(book);
        }

        [HttpPost("{id}")]
        public ActionResult UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto dto)
        {
            _bookService.Update(id, dto);

            return Ok();


        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook([FromRoute] int id)
        {
            _bookService.Delete(id);

            return NoContent();


        }

        [HttpPost]
        [Authorize(Roles = "Administrator,Moderator")]
        public ActionResult CreateBook([FromBody] CreateBookDto dto)
        {
            var id = _bookService.Create(dto);

            return Created($"/api/library/book/{id}", null);
        }
    }
}
