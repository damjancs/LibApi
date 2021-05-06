using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Entities
{
    public class Borrow
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughtTime { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
