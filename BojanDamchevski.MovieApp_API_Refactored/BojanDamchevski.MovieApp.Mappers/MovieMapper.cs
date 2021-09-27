using BojanDamchevski.MovieApp.Domain.Models;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BojanDamchevski.MovieApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDTO ToMovieDTO(this Movie movie)
        {
            return new MovieDTO
            {
                Description = movie.Description,
                Genre = movie.Genre,
                DirectorId = movie.DirectorId,
                Title = movie.Title,
                Year = movie.Year
            };
        }

        public static Movie ToMovie(this MovieDTO movie)
        {
            return new Movie
            {
                Description = movie.Description,
                Genre = movie.Genre,
                DirectorId = movie.DirectorId,
                Title = movie.Title,
                Year = movie.Year
            };
        }
    }
}
