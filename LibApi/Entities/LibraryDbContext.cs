using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Entities
{
    public class LibraryDbContext : DbContext
    {
        private string _connectionString =
            @"Server=(localdb)\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;";

        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Surname)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }




    }
}
