﻿// <auto-generated />
using ASP.NET_Core_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP.NET_Core_Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211203120152_Added table Languages")]
    partial class AddedtableLanguages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP.NET_Core_Project.Models.CityModel", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("City")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            City = "Gothenburg",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 2,
                            City = "Stockholm",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 3,
                            City = "Uppsala",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 4,
                            City = "Oslo",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 5,
                            City = "Copenhagen",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 6,
                            City = "Trondheim",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 7,
                            City = "Skagen",
                            CountryId = 2
                        });
                });

            modelBuilder.Entity("ASP.NET_Core_Project.Models.CountryModel", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Country = "Sweden"
                        },
                        new
                        {
                            CountryId = 2,
                            Country = "Denmark"
                        },
                        new
                        {
                            CountryId = 3,
                            Country = "Norway"
                        });
                });

            modelBuilder.Entity("ASP.NET_Core_Project.Models.LanguageModel", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnName("Language")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("LanguageId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("ASP.NET_Core_Project.Models.PersonModel", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 1,
                            Name = "Pelle",
                            Phone = "123-456 78 90"
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 1,
                            Name = "Lisa",
                            Phone = "098-765 43 21"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 2,
                            Name = "Gustav",
                            Phone = "023-987 43 25"
                        },
                        new
                        {
                            PersonId = 4,
                            CityId = 3,
                            Name = "Åke",
                            Phone = "023-543 78 35"
                        },
                        new
                        {
                            PersonId = 5,
                            CityId = 4,
                            Name = "Nicklas",
                            Phone = "070-992 12 84"
                        },
                        new
                        {
                            PersonId = 6,
                            CityId = 1,
                            Name = "Åsa",
                            Phone = "072-375 16 92"
                        },
                        new
                        {
                            PersonId = 7,
                            CityId = 2,
                            Name = "Per",
                            Phone = "023-530 32 39"
                        },
                        new
                        {
                            PersonId = 8,
                            CityId = 6,
                            Name = "Lotta",
                            Phone = "123-937 33 94"
                        },
                        new
                        {
                            PersonId = 9,
                            CityId = 4,
                            Name = "Mona",
                            Phone = "131-729 38 66"
                        });
                });

            modelBuilder.Entity("ASP.NET_Core_Project.Models.CityModel", b =>
                {
                    b.HasOne("ASP.NET_Core_Project.Models.CountryModel", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.NET_Core_Project.Models.PersonModel", b =>
                {
                    b.HasOne("ASP.NET_Core_Project.Models.CityModel", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
