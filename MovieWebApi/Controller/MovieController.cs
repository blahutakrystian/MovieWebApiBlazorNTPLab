using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieWebApi.Interface;
using MovieWebApi.Model;

namespace MovieWebApi.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        // GET: api/Movie
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAll();
            if (movies.Any() == false)
                return NoContent();
            return Ok(movies);
        }

        // GET: api/Movie/5
        [HttpGet("{movieId}")]
        public IActionResult Get(int movieId)
        {
            Movie movie = _movieRepository.Get(movieId);
            if (movie == null)
                return NoContent();
            return Ok(movie);
        }

        // POST: api/Movie
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newMovie = _movieRepository.Post(movie);
            return CreatedAtAction(nameof(Get),
                new { movieId = newMovie.MovieId },
                newMovie);

        }

        // PUT: api/Movie/5
        [HttpPut]
        public IActionResult Put([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedMovie = _movieRepository.Put(movie);
            return Ok(updatedMovie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{movieId}")]
        public IActionResult Delete(int movieId)
        {
            var deletedMovie = _movieRepository.Delete(movieId);
            if (deletedMovie == null)
                return NoContent();
            return Ok(deletedMovie);
        }

    }
}