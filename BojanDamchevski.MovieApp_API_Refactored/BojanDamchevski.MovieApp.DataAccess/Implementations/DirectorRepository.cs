using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.MovieApp.DataAccess.Implementations
{
    public class DirectorRepository : IRepository<Director>
    {
        private MovieAppRefactoredDbContext _movieAppRefactoredDbContext;
        public DirectorRepository(MovieAppRefactoredDbContext movieAppRefactoredDbContext)
        {
            _movieAppRefactoredDbContext = movieAppRefactoredDbContext;
        }
        public void Delete(int id)
        {
            _movieAppRefactoredDbContext.Directors
               .Remove(_movieAppRefactoredDbContext.Directors.FirstOrDefault(x => x.Id == id));
            _movieAppRefactoredDbContext.SaveChanges();
        }

        public List<Director> GetAll()
        {
            return _movieAppRefactoredDbContext.Directors
                .Include(x=>x.Movies)
                .ToList();
        }

        public Director GetById(int id)
        {
            return _movieAppRefactoredDbContext.Directors
                .Include(x => x.Movies)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Director entity)
        {
            _movieAppRefactoredDbContext.Directors.Add(entity);
            _movieAppRefactoredDbContext.SaveChanges();
        }

        public void Update(Director entity)
        {
            _movieAppRefactoredDbContext.Directors.Update(entity);
            _movieAppRefactoredDbContext.SaveChanges();
        }
    }
}
