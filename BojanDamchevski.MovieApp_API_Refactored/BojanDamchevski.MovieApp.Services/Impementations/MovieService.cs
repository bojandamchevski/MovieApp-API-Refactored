using BojanDamchevski.MovieApp.DataAccess.Implementations;
using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using BojanDamchevski.MovieApp.Mappers;
using BojanDamchevski.MovieApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.MovieApp.Services.Impementations
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;
        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddNewMovie(MovieDTO entity)
        {
            Movie newMovie = entity.ToMovie();
            _movieRepository.Insert(newMovie);
        }

        public List<MovieDTO> GetAll()
        {
            return _movieRepository.GetAll().Select(x => x.ToMovieDTO()).ToList();
        }

        public MovieDTO GetById(int id)
        {
            return _movieRepository.GetById(id).ToMovieDTO();
        }
    }
}
