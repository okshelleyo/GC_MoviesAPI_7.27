using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC_MovieAPILab_7._18._21.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GC_MovieAPILab_7._18._21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;
        public MovieController(MovieContext context)
        {
            _context = context;
        }

        #region Create

        //POST: api/Movie
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
            } else
            {
                return NotFound();
            }
        }

        #endregion

        #region Read
        //GET: api/movie
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies;  //returning list of movie objects
        }

        
        //GET: api/movie/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {

            var movie = await _context.Movies.FindAsync(id);
            
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return movie;
            }

        }

        #endregion

        #region Update
        //PUT: api/movie/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovie(int id, Movie updatedMovie)
        {
            if(!ModelState.IsValid || id != updatedMovie.Id)
            {
                return BadRequest();
            } else
            {
                Movie dbMovie = _context.Movies.Find(id);
                dbMovie.Runtime = updatedMovie.Runtime;
                dbMovie.Title = updatedMovie.Title;
                dbMovie.Genre = updatedMovie.Genre;
                dbMovie.Id = updatedMovie.Id;

                _context.Entry(dbMovie).State = EntityState.Modified;
                _context.Update(dbMovie);
                await _context.SaveChangesAsync();
                return NoContent();

            }

        }


        #endregion

        #region Delete
        //DELETE: api/movie/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {

            var movie = await _context.Movies.FindAsync(id);
            if(movie ==null )
            {
                return NotFound();
            } else
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }


        #endregion


    }
}
