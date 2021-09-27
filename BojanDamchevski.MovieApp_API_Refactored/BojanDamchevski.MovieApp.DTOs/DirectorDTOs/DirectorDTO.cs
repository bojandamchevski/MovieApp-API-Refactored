using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BojanDamchevski.MovieApp.DTOs.DirectorDTOs
{
    public class DirectorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public List<MovieDTO> Movies { get; set; }

        public DirectorDTO()
        {
            Movies = new List<MovieDTO>();
        }
    }
}
