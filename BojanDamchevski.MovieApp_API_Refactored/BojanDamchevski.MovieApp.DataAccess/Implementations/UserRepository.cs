using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.MovieApp.DataAccess.Implementations
{
    public class UserRepository : IUserRepository
    {
        private MovieAppRefactoredDbContext _movieAppRefactoredDbContext;
        public UserRepository(MovieAppRefactoredDbContext movieAppRefactoredDbContext)
        {
            _movieAppRefactoredDbContext = movieAppRefactoredDbContext;
        }
        public void Delete(int id)
        {
            _movieAppRefactoredDbContext.Users
                 .Remove(_movieAppRefactoredDbContext.Users.FirstOrDefault(x => x.Id == id));
            _movieAppRefactoredDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _movieAppRefactoredDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _movieAppRefactoredDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _movieAppRefactoredDbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public void Insert(User entity)
        {
            _movieAppRefactoredDbContext.Users.Add(entity);
            _movieAppRefactoredDbContext.SaveChanges();
        }

        public User LoginUser(string username, string password)
        {
            return _movieAppRefactoredDbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower()
            && x.Password == password);
        }

        public void Update(User entity)
        {
            _movieAppRefactoredDbContext.Users.Update(entity);
            _movieAppRefactoredDbContext.SaveChanges();
        }
    }
}
