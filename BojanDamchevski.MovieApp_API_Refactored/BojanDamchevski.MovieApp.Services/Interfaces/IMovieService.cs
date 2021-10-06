using BojanDamchevski.MovieApp.Domain.Models;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using System.Collections.Generic;

namespace BojanDamchevski.MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieDTO> GetAll();
        MovieDTO GetById(int id);
        void AddNewMovie(MovieDTO entity);
        void DeleteMovie(int id);
        void UpdateMovie(MovieDTO movieDTO);
    }
}
