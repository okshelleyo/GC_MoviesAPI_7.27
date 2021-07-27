using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieAPIs.Models
{
    public class MovieDAL
    {
        public HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44324");

            return client;
        }


        #region Read

        public async Task<List<Movie>> GetMovies()
        {
            var client = GetHttpClient();

            var response = await client.GetAsync("/api/movie");
            var movies = await response.Content.ReadAsAsync<List<Movie>>();
            return movies;
        }

        public async Task<Movie> GetMovie(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"/api/movie/{id}");
            var movie = await response.Content.ReadAsAsync<Movie>();
            return movie;
        }


        #endregion

        #region DELETE
        public async Task DeleteMovie(int id)
        {
            var client = GetHttpClient();
            var response = client.DeleteAsync($"/api/movie/{id}");
        }

        #endregion

        #region CREATE
        public async Task AddMovie(Movie movie)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("/api/movie", movie);
        }
        #endregion

        #region Update 
        public async Task EditMovie(Movie editedMovie, int id)
        {
            var client = GetHttpClient();
            var response = await client.PutAsJsonAsync($"/api/movie/{id}", editedMovie);
        }

        #endregion
    }
}
