﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Models
{
    public class CreateBookDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string BookType { get; set; }
    }
}
