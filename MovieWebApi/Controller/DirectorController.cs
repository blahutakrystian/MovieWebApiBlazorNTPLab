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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorController(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        //GET : api/Director
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Director> directors = _directorRepository.GetAll();
            if (directors.Any() == false)
            {
                return NoContent();
            }
            return Ok(directors);
        }

        [HttpGet("{directorId}")]
        public IActionResult Get(int directorId)
        {
            Director director = _directorRepository.Get(directorId);
            if (director == null)
            {
                return NoContent();
            }

            return Ok(director);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDirector = _directorRepository.Post(director);
            return CreatedAtAction(nameof(Get), new {directorId = newDirector.DirectorId}, newDirector);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedDirector = _directorRepository.Put(director);
            return Ok(updatedDirector);
        }

        [HttpDelete("{directorId}")]
        public IActionResult Delete(int directorId)
        {
            var deletedDirector = _directorRepository.Delete(directorId);
            if (deletedDirector == null)
            {
                return NoContent();
            }

            return Ok(deletedDirector);
        }
    }
}
