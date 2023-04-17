using System.Collections.Generic;
using movie_web_api.Models;


namespace movie_web_api.Repository {

    public interface IMovieRepository {

        public IEnumerable<Movie> GetAll();

        public Movie GetMovieByName(string name);

        public void InsertMovie(Movie m);

        public void UpdateMovie(string name, Movie m);

        public void DeleteMovie(string name);

    }
}