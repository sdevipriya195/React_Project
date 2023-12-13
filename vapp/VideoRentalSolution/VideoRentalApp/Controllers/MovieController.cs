using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using NuGet.Protocol.Core.Types;
using VideoRentalApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using VideoRentalApp.Controllers;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Cors;

namespace VideoRentalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]

    public class MovieController : ControllerBase

    {
        private readonly IMovieRepository _movieRepository = null;
        private readonly ILogger<MovieController> _logger;

        public MovieController(IMovieRepository movieRepository, ILogger<MovieController> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;

        }
        /// <summary>
        ///Get the list of the movies
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Get(string search, string genre)
        {
            try
            {
                List<Movie> movies = new List<Movie>();

                if (search == null)
                {
                    movies = _movieRepository.GetAllMovies(genre).ToList();
                }
                else
                {
                    movies = _movieRepository.GetAllMovies(genre)
                        .Where(c => c.MovieName.Contains(search, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                if (movies.Count > 0)
                {
                    return Ok(movies);
                }
                else
                {
                    return BadRequest("No results");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing the request");
                return StatusCode(500, "Internal Server Error");
            }
        }


        /// <summary>
        /// Get the movies by the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            try
            {
                Movie movie = _movieRepository.GetMovieById(id);

                if (movie != null)
                {
                    return movie;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting movie by id");
                return BadRequest("An error occurred while processing your request.");
            }
        }

        /// <summary>
        /// Add the movies 
        /// </summary>
        /// <param name="movies"></param>
        /// <returns></returns>

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public string Post(Movie movies)
        {
            try
            {
                string Response = _movieRepository.AddMovie(movies);
                return Response;
            }
            catch (Exception ex)
            {

                _logger.LogError("Movie is not added");

                return (ex.InnerException.Message);
            }
        }
        /// <summary>
        /// update the movie fields
        /// </summary>
        /// <param name="movies"></param>
        /// <returns></returns>
        [HttpPut]

        public string Put(Movie movies)
        {
            string errorMessage = string.Empty;
            try
            {
                string Response = _movieRepository.UpdateMovie(movies);
                return Response;
            }
            catch (Exception ex)
            {

                _logger.LogError("Movie update failed");

                return (ex.InnerException.Message);

            }
        }
        /// <summary>
        /// Delete the movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [Route("{id:int}")]
        [HttpDelete]

        public string Delete(int id)
        {
            try
            {
                string Response = _movieRepository.DeleteMovie(id);
                return Response;
            }
            catch (Exception ex)
            {

                _logger.LogError("Movie delete failed");

                return (ex.InnerException.Message);
            }
        }
    }
}