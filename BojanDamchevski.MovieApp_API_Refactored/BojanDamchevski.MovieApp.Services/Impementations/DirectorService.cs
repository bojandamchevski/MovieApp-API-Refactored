using BojanDamchevski.MovieApp.DataAccess.Interfaces;
using BojanDamchevski.MovieApp.Domain.Models;
using BojanDamchevski.MovieApp.DTOs.DirectorDTOs;
using BojanDamchevski.MovieApp.Mappers;
using BojanDamchevski.MovieApp.Services.Interfaces;
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

        public List<DirectorDTO> GetAll()
        {
            return _directorRepository.GetAll().Select(x => x.ToDirectorDTO()).ToList();
        }

        public DirectorDTO GetById(int id)
        {
            return _directorRepository.GetById(id).ToDirectorDTO();
        }
    }
}
