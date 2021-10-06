using System;

namespace BojanDamchevski.MovieApp.Shared.CustomExceptions
{
    public class DirectorException : Exception
    {
        public DirectorException(string message) : base(message)
        {

        }
    }
}
