using BojanDamchevski.MovieApp.DTOs.UserDTOs;

namespace BojanDamchevski.MovieApp.Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterUserDTO registerUserDTO);
        string Login(LoginUserDTO loginUserDTO);
    }
}
