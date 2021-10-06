using BojanDamchevski.MovieApp.DTOs.DirectorDTOs;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BojanDamchevski.MovieApp.Services.Interfaces
{
    public interface IDirectorService
    {
        List<DirectorDTO> GetAll();
        DirectorDTO GetById(int id);
        void AddNewDirector(DirectorDTO entity);
        void DeleteDirector(int id);
        void UpdateDirector(DirectorDTO directorDTO);
        List<MovieDTO> FilterMoviesByCountry(string country);
    }
}
