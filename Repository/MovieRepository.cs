using System;
using System.Collections.Generic;
using movie_web_api.Models;
using MySql.Data.MySqlClient; //dotnet add package MySql.Data



namespace movie_web_api.Repository {
    
    public class MovieRepository : IMovieRepository {
        private static readonly List<Movie> movies = new List<Movie>(10)
        {
            new Movie {Name = "Mandela Catalogue", Genre = "Horror", Year = 2020},
            new Movie {Name = "Random Nonsense", Genre = "Drama", Year = 2023},
            new Movie {Name = "The Light Knight", Genre = "Action", Year = 2018}
        };


        private MySqlConnection _connection;

        public MovieRepository() {
            string connectionString = "server=localhost;userid=lpbeirne;password=supersecurepassword;database=entertainment";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        ~MovieRepository() {
            _connection.Close();
        }

        public IEnumerable<Movie> GetAll() {
            var statement = "Select * from Movies";
            var command = new MySqlCommand(statement, _connection);
            var results = command.ExecuteReader();

            List<Movie> list = new List<Movie>(20);

            while(results.Read()) {
                Movie m = new Movie {
                    Name = (string)results[1],
                    Year = (int)results[2],
                    Genre = (string)results[3]
                };
                list.Add(m);
            }
            results.Close();
            return list;
        }

        public Movie GetMovieByName(string name) {
            var statement = "Select * from Movies where Name = @targetName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@targetName", name);
            var results = command.ExecuteReader();

            Movie m = null;
            if(results.Read()) {
                m = new Movie {
                    Name = (string)results[1],
                    Year = (int)results[2],
                    Genre = (string)results[3]
                };
            }
            results.Close();
            return m;
        }

        public void InsertMovie(Movie m) {
            var statement = "Insert into Movies (Name, Year, Genre) Values(@n, @y, @g)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@n", m.Name);
            command.Parameters.AddWithValue("@y", m.Year);
            command.Parameters.AddWithValue("@g", m.Genre);
            var results = command.ExecuteNonQuery();

            Console.WriteLine(results);
        }

        public void UpdateMovie(string name, Movie movieIn) {
            var statement = "Update Movies Set Name=@newName, Year=@newYear, Genre=@newGenre Where Name=@updateName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", movieIn.Name);
            command.Parameters.AddWithValue("@newYear", movieIn.Year);
            command.Parameters.AddWithValue("@newGenre", movieIn.Genre);
            command.Parameters.AddWithValue("@updateName", name);
            var results = command.ExecuteNonQuery();
        }

        public void DeleteMovie(string name) {
            var statement = "Delete from Movies where Name = @targetName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@targetName", name);
            var results = command.ExecuteNonQuery();
        }

    }
}