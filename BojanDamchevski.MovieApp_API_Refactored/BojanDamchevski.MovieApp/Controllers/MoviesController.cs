﻿using BojanDamchevski.MovieApp.Domain.Enums;
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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
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

        [HttpDelete("delete-movie")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                if (id > 0)
                {
                    _movieService.DeleteMovie(id);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Movie not found");
            }
        }

        [HttpPut("update-movie")]
        public IActionResult UpdateMovie([FromBody] MovieDTO movieDTO)
        {
            try
            {
                if (movieDTO != null)
                {
                    _movieService.UpdateMovie(movieDTO);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Movie not found");
            }
        }

        [HttpGet("filter-by-genre-year")]
        public ActionResult<List<MovieDTO>> Filter(MovieGenre genre, int year)
        {
            try
            {
                if (genre == 0 && year == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Filter parameter required!");
                }
                if (genre == 0)
                {
                    List<MovieDTO> movies = _movieService.GetAll()
                        .Where(x => x.Year == year).ToList();
                    return StatusCode(StatusCodes.Status200OK, movies);
                }
                if (year == 0)
                {
                    List<MovieDTO> movies = _movieService.GetAll()
                        .Where(x => x.Genre == genre).ToList();
                    return StatusCode(StatusCodes.Status200OK, movies);
                }
                List<MovieDTO> moviesFiltered = _movieService.GetAll()
                    .Where(x => x.Genre == genre && x.Year == year).ToList();
                return StatusCode(StatusCodes.Status200OK, moviesFiltered);
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
