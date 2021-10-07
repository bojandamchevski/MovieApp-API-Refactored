using BojanDamchevski.MovieApp.DTOs.DirectorDTOs;
using BojanDamchevski.MovieApp.DTOs.MovieDTOs;
using BojanDamchevski.MovieApp.Services.Interfaces;
using BojanDamchevski.MovieApp.Shared.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
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
    public class DirectorsController : ControllerBase
    {
        private IMovieService _movieService;
        private IDirectorService _directorService;

        public DirectorsController(IMovieService movieService, IDirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        [HttpGet("get-director-by-id")]
        public ActionResult<DirectorDTO> GetDirector(int id)
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

        [HttpPost("add-new-director")]
        public ActionResult<DirectorDTO> AddNewDirector([FromQuery] DirectorDTO directorDTO)
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

        [HttpGet("get-all-directors")]

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

        [HttpDelete("delete-director")]
        public IActionResult DeleteDirector(int id)
        {
            try
            {
                if (id > 0)
                {
                    _directorService.DeleteDirector(id);
                    return StatusCode(StatusCodes.Status202Accepted);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (UserException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "You are not authorized for this action");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Director not found");
            }
        }

        [HttpPut("update-director")]
        public IActionResult UpdateDirector([FromBody] DirectorDTO directorDTO)
        {
            try
            {
                if (directorDTO != null)
                {
                    _directorService.UpdateDirector(directorDTO);
                    return StatusCode(StatusCodes.Status202Accepted);
                }
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (DirectorException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "You are not authorized for this action");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Director not found");
            }
        }

        [HttpGet("filter-by-country")]
        public ActionResult<List<MovieDTO>> Filter(string country)
        {
            try
            {
                if (string.IsNullOrEmpty(country))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Filter parameter required!");
                }
                return StatusCode(StatusCodes.Status200OK, _directorService.FilterMoviesByCountry(country));
            }
            catch (UserException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "You are not authorized for this action");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Movie not found");
            }
        }
    }
}
