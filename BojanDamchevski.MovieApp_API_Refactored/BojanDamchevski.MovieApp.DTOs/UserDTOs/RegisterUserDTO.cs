﻿namespace BojanDamchevski.MovieApp.DTOs.UserDTOs
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Role { get; set; }
    }
}
