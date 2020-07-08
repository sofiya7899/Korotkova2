using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KorotkovaWeb.Models;

namespace KorotkovaWeb.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
           : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
           

        public DbSet<KorotkovaWeb.Models.Authors> Authors { get; set; }
             
       
    
   
  

        public DbSet<Authors> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .OwnsMany(property => property.books);
        }

        public IEnumerable<Authors> GetPushkinBooks(IEnumerable<Authors> authors)
        {
            return authors.Where(p => p.NameAuthor == "Pushkin");
        }


    }
}
