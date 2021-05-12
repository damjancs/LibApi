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
    [Route("api/library/book/{BookId}/author")]
    [ApiController]
    [Authorize(Roles ="Administrator, Moderator")]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpPost]
        public ActionResult CreateAuthor([FromRoute] int bookId, [FromBody] CreateAuthorDto dto)
        {
            var newAuthorId = _authorService.Create(bookId, dto);

            return Created($"api/book/{bookId}/author/{newAuthorId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteAuthor([FromRoute] int bookId)
        {
            _authorService.Remove(bookId);

            return NoContent();
        }
    }
}
