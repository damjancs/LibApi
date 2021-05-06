using LibApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public AuthorDto Author { get; set; }
        public string BookType { get; set; }
    }
}
