using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }
        public DbSet<PersonEF> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 1, Name = "Pelle", Phone = "123-456 78 90", City = "Stockholm" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 2, Name = "Lisa", Phone = "098-765 43 21", City = "Umeå" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 3, Name = "Gustav", Phone = "023-987 43 25", City = "Göteborg" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 4, Name = "Åke", Phone = "023-543 78 35", City = "Göteborg" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 5, Name = "Nicklas", Phone = "070-992 12 84", City = "Umeå" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 6, Name = "Åsa", Phone = "072-375 16 92", City = "Stockholm" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 7, Name = "Per", Phone = "023-530 32 39", City = "Uppsala" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 8, Name = "Lotta", Phone = "123-937 33 94", City = "Stockholm" });
            modelBuilder.Entity<PersonEF>().HasData(new PersonEF { PersonId = 9, Name = "Mona", Phone = "131-729 38 66", City = "Göteborg" });
        }
    }
}