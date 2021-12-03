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
        public DbSet<PersonModel> People { get; set; }
        public DbSet<CountryModel> Country { get; set; }
        public DbSet<CityModel> City { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PersonModel>().HasKey(pm => new { pm.CityId });
            //modelBuilder.Entity<CityModel>().HasKey(cm => new { cm.CountryId });

            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 1, Name = "Pelle", Phone = "123-456 78 90", CityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 2, Name = "Lisa", Phone = "098-765 43 21", CityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 3, Name = "Gustav", Phone = "023-987 43 25", CityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 4, Name = "Åke", Phone = "023-543 78 35", CityId = 3 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 5, Name = "Nicklas", Phone = "070-992 12 84", CityId = 4 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 6, Name = "Åsa", Phone = "072-375 16 92", CityId = 1 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 7, Name = "Per", Phone = "023-530 32 39", CityId = 2 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 8, Name = "Lotta", Phone = "123-937 33 94", CityId = 6 });
            modelBuilder.Entity<PersonModel>().HasData(new PersonModel { PersonId = 9, Name = "Mona", Phone = "131-729 38 66", CityId = 4 });

            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 1, Country = "Sweden" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 2, Country = "Denmark" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 3, Country = "Norway" });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 1, City = "Gothenburg", CountryId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 2, City = "Stockholm", CountryId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 3, City = "Uppsala", CountryId = 1 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 4, City = "Oslo", CountryId = 3 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 5, City = "Copenhagen", CountryId = 2 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 6, City = "Trondheim", CountryId = 3 });
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 7, City = "Skagen", CountryId = 2 });
        }
    }
}