﻿using System;
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

        [HttpGet("{name}")]
        public IActionResult GetMovieByName(string name)
        {
            foreach(Movie m in movies) {
                if(m.Name.Equals(name)) {
                    return Ok(m);
                }
            }
            return BadRequest();
        }
    }
}
