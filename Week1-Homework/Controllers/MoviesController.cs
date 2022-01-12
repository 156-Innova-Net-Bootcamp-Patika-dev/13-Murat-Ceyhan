using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week1_Homework.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week1_Homework.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> Movies = new List<Movie>()
        {
            new Movie()
            {
                Id=1,
                Name="Fight Club",
                Actors = new List<string>(){"Brad Pitt","Edward Norton"},
                Director = "David Fincher",
                Writers = new List<string>(){"Chuck Palahniuk","Jim Uhls"}
            },
            new Movie()
            {   
                Id=2,
                Name="Ezel",
                Actors = new List<string>(){"Kenan Imirzalioglu","Tuncel Kurtiz","Cansu Dere"},
                Director = "Uluç Bayraktar",
                Writers= new List<string>(){"Kerem Deren","Pınar Bulut" }
            }
        };


        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return Movies;
        }


        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = Movies.FirstOrDefault(x => x.Id == id);
            if(movie == null)
            {
                return NotFound(string.Format("No movie found id = {0}", id));
            }
            return movie;
        }
        // GET api/<MoviesController>/5
        [HttpGet]
        public ActionResult<List<Movie>> GetMoviesByName(string Name)
        {
            var movies = Movies.Where(x => x.Name == Name).ToList();
            if (movies.Count == 0)
            {
                return NotFound(string.Format("No movie found with name = {0}", Name));
            }
            return movies;
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult SaveMovie([FromBody] Movie movie)
        {
            if(movie.Id == 0 || string.IsNullOrEmpty(movie.Name) || (Movies.FirstOrDefault(x=>x.Id==movie.Id)!=null) )
            {
                return BadRequest();
            }
            Movies.Add(movie);
            return Ok();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public ActionResult<Movie> UpdateMovie(int id, [FromBody] Movie movie)
        {
            var _movie = Movies.FirstOrDefault(x => x.Id == id);
            if(_movie == null)
            {
                return NotFound(string.Format("No movie found id = {0}", id));
            }
            Movies.Remove(_movie);
            Movies.Add(movie);
            return Ok("Updated Succesfully!");
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movie = Movies.FirstOrDefault(x=>x.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            Movies.Remove(movie);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetMoviesByDirector(string DirectorName)
        {
            var movies = Movies.Where(x => x.Director == DirectorName).ToList();
            if (movies.Count == 0)
            {
                return NotFound(string.Format("No movie found with Director = {0}", DirectorName));
            }
            return movies;
        }
        [HttpGet]
        public ActionResult<List<Movie>> GetMoviesByActor(string ActorName)
        {
            var movies = Movies.Where(x => x.Actors.Contains(ActorName)).ToList();
            if (movies.Count == 0)
            {
                return NotFound(string.Format("No movie found with Director = {0}", ActorName));
            }
            return movies;
        }
    }
}
