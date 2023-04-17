using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movie_web_api.Models;
using movie_web_api.Services;

namespace movie_web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        /*
        private static readonly List<Movie> movies = new List<Movie>(10)
        {
            new Movie {Name = "Mandela Catalogue 2", Genre = "Horror", Year = 2020},
            new Movie {Name = "Random Nonsense", Genre = "Drama", Year = 2023},
            new Movie {Name = "The Light Knight", Genre = "Action", Year = 2018}
        };
        */

        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _service;

        public MovieController(ILogger<MovieController> logger, IMovieService service)
        {
            _logger = logger;
            _service = service;
        }

        //endpoint 1
        [HttpGet]
        public IActionResult GetMovies()
        {
            IEnumerable<Movie> movies = _service.GetMovies();
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
            Movie m = _service.GetMovieByName(name);

            if(m != null) {
                return Ok(m);
            }

            return BadRequest();
        }

        //endpoint 3
        [HttpGet("year/{year}")]
        public IActionResult GetMoviesByYear(int year)
        {
            IEnumerable<Movie> list = _service.GetMoviesByYear(year);

            if(list != null) {
                return Ok(list);
            }

            return BadRequest();
        }

        //endpoint 4
        [HttpPost]
        public IActionResult CreateMovie(Movie m)
        {
            _service.CreateMovie(m);
            //determine if successful

            return CreatedAtRoute("GetMovie", new {name=m.Name}, m);

        }

        //endpoint 5
        [HttpPut("{name}")]
        public IActionResult UpdateMovie(string name, Movie movieIn)
        {
            _service.UpdateMovie(name, movieIn);

            return NoContent();

        }

        //endpoint 6
        [HttpDelete("{name}")]
        public IActionResult DeleteMovie(string name)
        {
            _service.DeleteMovie(name);
            
            return NoContent();

        }
        

    }
}
