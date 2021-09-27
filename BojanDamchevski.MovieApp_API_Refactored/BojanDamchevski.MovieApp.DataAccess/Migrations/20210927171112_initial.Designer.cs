﻿// <auto-generated />
using BojanDamchevski.MovieApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BojanDamchevski.MovieApp.DataAccess.Migrations
{
    [DbContext(typeof(MovieAppRefactoredDbContext))]
    [Migration("20210927171112_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BojanDamchevski.MovieApp.Domain.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Country = "Country1",
                            FirstName = "Director1",
                            LastName = "Director1Ln"
                        },
                        new
                        {
                            Id = 2,
                            Country = "Country2",
                            FirstName = "Director2",
                            LastName = "Director2Ln"
                        },
                        new
                        {
                            Id = 3,
                            Country = "Country3",
                            FirstName = "Director3",
                            LastName = "Director3Ln"
                        });
                });

            modelBuilder.Entity("BojanDamchevski.MovieApp.Domain.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "description1",
                            DirectorId = 1,
                            Genre = 4,
                            Title = "ActionMovie",
                            Year = 2000
                        },
                        new
                        {
                            Id = 2,
                            Description = "description2",
                            DirectorId = 3,
                            Genre = 7,
                            Title = "RomanceMovie",
                            Year = 2012
                        },
                        new
                        {
                            Id = 3,
                            Description = "description3",
                            DirectorId = 2,
                            Genre = 2,
                            Title = "MysteryMovie",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("BojanDamchevski.MovieApp.Domain.Models.Movie", b =>
                {
                    b.HasOne("BojanDamchevski.MovieApp.Domain.Models.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("BojanDamchevski.MovieApp.Domain.Models.Director", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
