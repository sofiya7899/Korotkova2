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
        public DbSet<Authors> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //настраиваем связь один ко многим
            modelBuilder.Entity<Book>()
            .HasOne(p => p.Author)
            .WithMany(b => b.Book)
            .HasForeignKey(p => p.IdAuthor);
        }


        public DbSet<KorotkovaWeb.Models.Authors> Authors { get; set; }

       public IEnumerable<Book> GetPushkinBooks(IEnumerable<Book> books)
      {
            return books.Where(p => p.Authorr == 111);
       }
       
    }
}
