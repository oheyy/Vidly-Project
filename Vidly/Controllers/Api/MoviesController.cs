using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genre);

            //if query is not null or whitespace 
            if (!String.IsNullOrWhiteSpace(query))
            {
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));
            }
            //For eager loading remember to include using System.Data.Entity
            var movieDtos = movieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        //GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            //Select the entry in the table
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            //Checks if it's null and throws not found exception
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //Passing 2 argument
            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
