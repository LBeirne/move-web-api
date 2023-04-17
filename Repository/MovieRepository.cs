using System.Collections.Generic;
using movie_web_api.Models;



namespace movie_web_api.Repository {
    
    public class MovieRepository : IMovieRepository {
        private static readonly List<Movie> movies = new List<Movie>(10)
        {
            new Movie {Name = "Mandela Catalogue", Genre = "Horror", Year = 2020},
            new Movie {Name = "Random Nonsense", Genre = "Drama", Year = 2023},
            new Movie {Name = "The Light Knight", Genre = "Action", Year = 2018}
        };


        public MovieRepository() {
            //repo
        }

        public IEnumerable<Movie> GetAll() {
            return movies;
        }

        public Movie GetMovieByName(string name) {
            foreach(Movie m in movies) {
                if(m.Name.Equals(name)) {
                    return m;
                }
            }
            return null;
        }

        public void InsertMovie(Movie m) {
            movies.Add(m);
        }

        public void UpdateMovie(string name, Movie movieIn) {
            foreach(Movie m in movies) {
                if(m.Name.Equals(name)) {
                    m.Name = movieIn.Name;
                    m.Genre = movieIn.Genre;
                    m.Year = movieIn.Year;
                    return;
                }
            }
        }

        public void DeleteMovie(string name) {
            foreach(Movie m in movies) {
                if(m.Name.Equals(name)) {
                    movies.Remove(m);
                    return;
                }
            }
        }

    }
}