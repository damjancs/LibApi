using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Models
{
    public class CreateBorrowDto
    {
        public DateTime TakenDate { get; set; }
        public DateTime BroughtTime { get; set; }
    }
}
