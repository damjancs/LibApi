using LibApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libapi
{
    public class LibrarySeeder
    {
        private LibraryDbContext _dbcontext;

        public LibrarySeeder(LibraryDbContext dbcontext)
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

            if (_dbcontext.Database.CanConnect())
            {
                if (!_dbcontext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbcontext.Roles.AddRange(roles);
                    _dbcontext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Administrator"
                },
                new Role()

                {
                    Name = "Moderator"
                },
                new Role()

                {
                    Name = "User"
                }
            };
            return roles;
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
