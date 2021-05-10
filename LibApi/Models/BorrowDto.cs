using LibApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Models
{
    public class BorrowDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughtTime { get; set; }


        public Book Book { get; set; }
    }
}
