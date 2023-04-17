using System.Collections.Generic;
using movie_web_api.Models;
using movie_web_api.Repository;


namespace movie_web_api.Services {

    public interface IMovieService {

        public IEnumerable<Movie> GetMovies();

        public Movie GetMovieByName(string name);

        public IEnumerable<Movie> GetMoviesByYear(int year);

        public void CreateMovie(Movie m);

        public void UpdateMovie(string name, Movie m);

        public void DeleteMovie(string name);

    }

}