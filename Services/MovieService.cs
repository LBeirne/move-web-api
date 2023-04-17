using System.Collections.Generic;
using movie_web_api.Models;
using movie_web_api.Repository;


namespace movie_web_api.Services {

    public class MovieService : IMovieService {

        private IMovieRepository _repo;

        public MovieService(IMovieRepository repo) {
            _repo = repo;
        }


        public IEnumerable<Movie> GetMovies() {
            IEnumerable<Movie> myList = _repo.GetAll();
            //sort list
            return myList;
        }

        public Movie GetMovieByName(string name) {
            return _repo.GetMovieByName(name);
            //format movie
        }

        public IEnumerable<Movie> GetMoviesByYear(int year) {
            IEnumerable<Movie> movies = _repo.GetAll();
            List<Movie> list = new List<Movie>();

            foreach(Movie m in movies) {
                if(m.Year == year) {
                    list.Add(m);
                }
            }
            if(list != null) {
                return list;
            }
            return null;
        }

        public void CreateMovie(Movie m) {
            _repo.InsertMovie(m);
        }

        public void UpdateMovie(string name, Movie m) {
            _repo.UpdateMovie(name, m);
        }

        public void DeleteMovie(string name) {
            _repo.DeleteMovie(name);
        }

    }
}