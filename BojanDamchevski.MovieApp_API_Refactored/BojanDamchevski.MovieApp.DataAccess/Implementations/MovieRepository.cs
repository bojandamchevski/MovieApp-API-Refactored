using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.MovieApp.DataAccess.Implementations
{
    public class MovieRepository : IRepository<Movie>
    {
        private MovieAppRefactoredDbContext _movieAppRefactoredDbContext;
        public MovieRepository(MovieAppRefactoredDbContext movieAppRefactoredDbContext)
        {
            _movieAppRefactoredDbContext = movieAppRefactoredDbContext;
        }
        public void Delete(int id)
        {
            _movieAppRefactoredDbContext.Movies
                .Remove(_movieAppRefactoredDbContext.Movies.FirstOrDefault(x => x.Id == id));
            _movieAppRefactoredDbContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _movieAppRefactoredDbContext.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _movieAppRefactoredDbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Movie entity)
        {
            _movieAppRefactoredDbContext.Movies.Add(entity);
            _movieAppRefactoredDbContext.SaveChanges();
        }

        public void Update(Movie entity)
        {
            _movieAppRefactoredDbContext.Movies.Update(entity);
            _movieAppRefactoredDbContext.SaveChanges();
        }
    }
}
