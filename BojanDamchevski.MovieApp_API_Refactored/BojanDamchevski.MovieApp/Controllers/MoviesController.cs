using BojanDamchevski.MovieApp.DTOs.DirectorDTOs;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using BojanDamchevski.MovieApp.Services.Interfaces;
using BojanDamchevski.MovieApp.Shared.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;
        private IDirectorService _directorService;

        public MoviesController(IMovieService movieService, IDirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        [HttpGet("get-all-movies")]

        public ActionResult<List<MovieDTO>> GetAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _movieService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet("get-all-directors-with-movies")]

        public ActionResult<List<DirectorDTO>> GetAllDirectors()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _directorService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet("get-movie-by-id")]
        public ActionResult<MovieDTO> GetMovie(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _movieService.GetById(id));
            }
            catch (ResourceNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet("get-director-by-id")]
        public ActionResult<MovieDTO> GetDirector(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _directorService.GetById(id));
            }
            catch (ResourceNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpPost("add-new-movie")]
        public ActionResult<MovieDTO> AddNewMovie([FromQuery] MovieDTO movieDTO)
        {
            try
            {
                _movieService.AddNewMovie(movieDTO);
                return StatusCode(StatusCodes.Status201Created, "Movie created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpPost("add-new-director")]
        public ActionResult<MovieDTO> AddNewDirector([FromQuery] DirectorDTO directorDTO)
        {
            try
            {
                _directorService.AddNewDirector(directorDTO);
                return StatusCode(StatusCodes.Status201Created, "Director created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
    }
}
