using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KorotkovaWeb.Models
{
    public class AuthorsContext : DbContext
    {       
        public AuthorsContext(DbContextOptions<AuthorsContext> options)
            : base(options)
        {
        }
       
        public DbSet<Authors> authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .OwnsMany(property => property.authors);
        }



    }
}
