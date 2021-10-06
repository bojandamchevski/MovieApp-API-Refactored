using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using BojanDamchevski.MovieApp.DTOs.DirectorDTOs;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using BojanDamchevski.MovieApp.Mappers;
using BojanDamchevski.MovieApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BojanDamchevski.MovieApp.Services.Impementations
{
    public class DirectorService : IDirectorService
    {
        private IRepository<Director> _directorRepository;
        public DirectorService(IRepository<Director> directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void AddNewDirector(DirectorDTO entity)
        {
            Director newDirector = entity.ToDirector();
            _directorRepository.Insert(newDirector);
        }

        public void DeleteDirector(int id)
        {
            Director director = _directorRepository.GetById(id);
            if (director == null)
            {
                throw new Exception("Director not found");
            }
            _directorRepository.Delete(director.Id);
        }

        public List<MovieDTO> FilterMoviesByCountry(string country)
        {
            return _directorRepository.GetAll().Where(x => x.Country.Equals(country, StringComparison.InvariantCultureIgnoreCase)).SelectMany(x => x.Movies.Select(n=>n.ToMovieDTO())).ToList();
        }

        public List<DirectorDTO> GetAll()
        {
            return _directorRepository.GetAll().Select(x => x.ToDirectorDTO()).ToList();
        }

        public DirectorDTO GetById(int id)
        {
            Director director = _directorRepository.GetById(id);
            if (director == null)
            {
                throw new Exception("Director not found");
            }
            return director.ToDirectorDTO();
        }

        public void UpdateDirector(DirectorDTO directorDTO)
        {
            Director director = directorDTO.ToDirector();
            _directorRepository.Update(director);
        }
    }
}
