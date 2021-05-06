using LibApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libapi
{
    public class BookSeeder
    {
        private LibraryDbContext _dbcontext;

        public BookSeeder(LibraryDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Seed()
        {
            if (_dbcontext.Database.CanConnect())
            {
                if (!_dbcontext.Books.Any())
                {
                    var books = GetBooks();
                    _dbcontext.Books.AddRange(books);
                    _dbcontext.SaveChanges();
                }
            }
        }

        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Name = "W pustyni i w puszczy",
                    PageCount = 765,
                    Author = new Author()
                    {
                        Name = "Henryk",
                        Surname = "Sienkiewicz"
                    },
                },
                new Book()
                {
                    Name = "Lalka",
                    PageCount = 543,
                    Author = new Author()
                    {
                        Name = "Bolesław",
                        Surname = "Prus"
                    },
                }
            };

            return books;
        }
    }
}
