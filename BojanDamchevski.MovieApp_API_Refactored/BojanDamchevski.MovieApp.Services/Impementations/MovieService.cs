using BojanDamchevski.MovieApp.DataAccess.Implementations;
using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using BojanDamchevski.MovieApp.Mappers;
using BojanDamchevski.MovieApp.Services.Interfaces;
using System;
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

        public void DeleteMovie(int id)
        {
            Movie movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            _movieRepository.Delete(movie.Id);
        }

        public List<MovieDTO> GetAll()
        {
            return _movieRepository.GetAll().Select(x => x.ToMovieDTO()).ToList();
        }

        public MovieDTO GetById(int id)
        {
            Movie movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            return movie.ToMovieDTO();
        }

        public void UpdateMovie(MovieDTO movieDTO)
        {
            Movie movie = movieDTO.ToMovie();
            _movieRepository.Update(movie);
        }
    }
}
