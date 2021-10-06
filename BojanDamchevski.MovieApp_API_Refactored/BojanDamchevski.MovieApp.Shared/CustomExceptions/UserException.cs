using System;

namespace BojanDamchevski.MovieApp.Shared.CustomExceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }
}
