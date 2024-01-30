using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookBox.Model
{
    using BookBox.Model;
    public class BookContext:DbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Book> book { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8HP5AKU\SQLEXPRESS;Database=BookDB;Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
