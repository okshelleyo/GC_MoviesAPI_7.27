using Microsoft.AspNetCore.Mvc;
using MovieAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIs.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDAL _movie = new MovieDAL();

        public async Task<IActionResult> Index()
        {
            var movies = await _movie.GetMovies();
            return View(movies);
        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movie.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MovieForm(int id)
        {
            if (id == 0)
            {
                return View(new Movie());
            } else
            {
                var movie = await _movie.GetMovie(id);
                return View(movie);
            }
        }

        public async Task<IActionResult> AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movie.AddMovie(movie);
                return RedirectToAction("Index");
            }
            return View("MovieForm", movie);
        }

        public async Task <IActionResult> EditMovie(int id, Movie editedMovie)
        {
            if (ModelState.IsValid)
            {
                await _movie.EditMovie(editedMovie, id);
            }
            return RedirectToAction("MovieForm");
        }

    }

}
