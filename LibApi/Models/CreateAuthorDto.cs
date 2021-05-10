using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Models
{
    public class CreateAuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int BookId { get; set; }
    }
}
