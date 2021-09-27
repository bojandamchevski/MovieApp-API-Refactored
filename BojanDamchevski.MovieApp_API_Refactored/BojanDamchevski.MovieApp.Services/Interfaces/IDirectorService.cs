using BojanDamchevski.MovieApp.DTOs.DirectorDTOs;
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

    }
}
