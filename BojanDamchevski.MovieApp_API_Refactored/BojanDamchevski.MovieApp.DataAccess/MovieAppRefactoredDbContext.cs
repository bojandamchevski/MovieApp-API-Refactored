using BojanDamchevski.MovieApp.Domain.Enums;
using BojanDamchevski.MovieApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BojanDamchevski.MovieApp.DataAccess
{
    public class MovieAppRefactoredDbContext : DbContext
    {
        public MovieAppRefactoredDbContext(DbContextOptions<MovieAppRefactoredDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Director>()
                .Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Director>()
                .Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Director>()
                .Property(x => x.Country)
                .HasMaxLength(100);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie
                {
                    Id = 1,
                    Description = "description1",
                    Genre = MovieGenre.Action,
                    Title = "ActionMovie",
                    Year = 2000,
                    DirectorId = 1
                },
                new Movie
                {
                    Id = 2,
                    Description = "description2",
                    Genre = MovieGenre.Romance,
                    Title = "RomanceMovie",
                    Year = 2012,
                    DirectorId = 3
                },
                new Movie
                {
                    Id = 3,
                    Description = "description3",
                    Genre = MovieGenre.Mystery,
                    Title = "MysteryMovie",
                    Year = 2022,
                    DirectorId = 2
                });

            modelBuilder.Entity<Director>()
                .HasData(
                new Director
                {
                    Id = 1,
                    Country = "Country1",
                    FirstName = "Director1",
                    LastName = "Director1Ln"
                },
                new Director
                {
                    Id = 2,
                    Country = "Country2",
                    FirstName = "Director2",
                    LastName = "Director2Ln"
                },
                new Director
                {
                    Id = 3,
                    Country = "Country3",
                    FirstName = "Director3",
                    LastName = "Director3Ln"
                });
        }

    }
}
