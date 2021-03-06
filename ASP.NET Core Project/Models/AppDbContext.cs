using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }
        public DbSet<PersonEFModel> People { get; set; }
        public DbSet<CountryModel> Country { get; set; }
        public DbSet<CityModel> City { get; set; }
        public DbSet<LanguageModel> Language { get; set; }
        public DbSet<PersonLanguageModel> PersonLanguage { get; set; }
        public DbSet<ApplicationUser> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguageModel>().HasKey(pl => new { pl.PersonId, pl.LanguageId });
            modelBuilder.Entity<PersonLanguageModel>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.Languages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguageModel>()
                .HasOne(pl => pl.Language)
                .WithMany(p => p.Persons)
                .HasForeignKey(pl => pl.LanguageId);

            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 1, Name = "Pelle", Phone = "123-456 78 90", CityId = 1 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 2, Name = "Lisa", Phone = "098-765 43 21", CityId = 1 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 3, Name = "Gustav", Phone = "023-987 43 25", CityId = 2 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 4, Name = "Åke", Phone = "023-543 78 35", CityId = 3 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 5, Name = "Nicklas", Phone = "070-992 12 84", CityId = 4 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 6, Name = "Åsa", Phone = "072-375 16 92", CityId = 1 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 7, Name = "Per", Phone = "023-530 32 39", CityId = 2 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 8, Name = "Lotta", Phone = "123-937 33 94", CityId = 6 });
            modelBuilder.Entity<PersonEFModel>().HasData(new PersonEFModel { PersonId = 9, Name = "Mona", Phone = "131-729 38 66", CityId = 4 });

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

            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 1, Language = "Swedish" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 2, Language = "Danish" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 3, Language = "Norvegian" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 4, Language = "English" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 5, Language = "German" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 6, Language = "French" });

            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 1, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 2, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 3, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 1, LanguageId = 4 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 4, LanguageId = 6 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 7, LanguageId = 3 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 5, LanguageId = 5 });
            modelBuilder.Entity<PersonLanguageModel>().HasData(new PersonLanguageModel { PersonId = 3, LanguageId = 6 });

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            // Creates Admin-role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole 
            { 
                Id = adminRoleId, 
                Name = "Admin",
                NormalizedName = "ADMIN" 
            });
            // Creates User-role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });
            // Creates Admin user
            PasswordHasher< ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "asdfgh"),
                FirstName = "Admin",
                LastName = "Adminsson",
                BirthDate = DateTime.Parse("1978-06-15")
            });
            // Assign Admin user an Admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> {
                RoleId = adminRoleId, UserId = userId });
        }
    }
}