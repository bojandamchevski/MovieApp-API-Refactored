using BojanDamchevski.MovieApp.Domain.Models;

namespace BojanDamchevski.MovieApp.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string password);
    }
}
