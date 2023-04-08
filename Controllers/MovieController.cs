using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movie_web_api.Models;

namespace movie_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static readonly List<Movie> movies = new List<Movie>(10)
        {
            new Movie {Name = "Mandela Catalogue", Genre = "Horror", Year = 2020},
            new Movie {Name = "Random Nonsense", Genre = "Drama", Year = 2023},
            new Movie {Name = "The Light Knight", Genre = "Action", Year = 2018}
        };

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        //endpoint 1
        [HttpGet]
        public IActionResult GetMovies()
        {
            if(movies != null) {
                return Ok(movies);
            }
            else {
                return BadRequest();
            }
        }

        //endpoint 2
        [HttpGet("{name}", Name = "GetMovie")]
        public IActionResult GetMovieByName(string name)
        {
            foreach(Movie m in movies) {
                if(m.Name.Equals(name)) {
                    return Ok(m);
                }
            }
            return BadRequest();
        }

        //endpoint 3
        [HttpGet("year/{year}")]
        public IActionResult GetMoviesByYear(int year)
        {
            foreach(Movie m in movies) {
                if(m.Year == year) {
                    return Ok(m);
                }
            }
            return BadRequest();
        }

        //endpoint 4
        [HttpPost]
        public IActionResult CreateMove(Movie m)
        {
            try {
                movies.Add(m);
                return CreatedAtRoute("GetMovie", new {name=m.Name}, m);
            }
            catch(Exception e) {
                return StatusCode(500);
            }
        }

        //endpoint 5
        [HttpPut("{name}")]
        public IActionResult UpdateMove(Movie movieIn, string name)
        {
            try {
                foreach(Movie m in movies) {
                    if(m.Name.Equals(name)) {
                        m.Name = movieIn.Name;
                        m.Genre = movieIn.Genre;
                        m.Year = movieIn.Year;
                        return NoContent();
                    }
                }
                return BadRequest();
            }
            catch(Exception e) {
                return StatusCode(500);
            }
        }

        //endpoint 6
        [HttpDelete("{name}")]
        public IActionResult DeleteMove(string name)
        {
            try {
                foreach(Movie m in movies) {
                    if(m.Name.Equals(name)) {
                        movies.Remove(m);
                        return NoContent();
                    }
                }
                return BadRequest();
            }
            catch(Exception e) {
                return StatusCode(500);
            }
        }

    }
}
