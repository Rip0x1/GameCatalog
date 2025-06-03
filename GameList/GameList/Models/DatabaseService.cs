using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class DatabaseService
    {
        private string connectionString = "server=localhost;database=programma;uid=root;pwd=;";

        public void OpenConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT * FROM Games", connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        games.Add(new Game
                        {
                            GameID = reader.GetInt32("GameID"),
                            GenreID = reader.GetInt32("GenreID"),
                            Rating = reader.GetFloat("Rating"),
                            ReleaseDate = reader.GetDateTime("ReleaseDate"),
                            Platform = reader.GetString("Platform"),
                            Title = reader.GetString("Title"),
                            Description = reader.GetString("Description"),
                        });
                    }
                }
            }
            return games;
        }

        public bool RegisterUser(string name, string password)
        {
            if (UserExists(name))
            {
                return false; 
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("INSERT INTO Users (Name, Password, RegistrationDate) VALUES (@Name, @Password, @RegistrationDate)", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                return command.ExecuteNonQuery() > 0;
            }
        }

        private bool UserExists(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE Name = @Name", connection);
                command.Parameters.AddWithValue("@Name", name);
                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }



        public bool AuthenticateUser(string name, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM Users WHERE Name = @Name AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; 
            }
        }

        public int GetUserIdByName(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("SELECT UserID FROM Users WHERE Name = @Name", connection);
                command.Parameters.AddWithValue("@Name", name);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public bool AddGame(Game game)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("INSERT INTO Games (GenreID, Rating, ReleaseDate, Platform, Title, Description) VALUES (@GenreID, @Rating, @ReleaseDate, @Platform, @Title, @Description)", connection);
                command.Parameters.AddWithValue("@GenreID", game.GenreID);
                command.Parameters.AddWithValue("@Rating", game.Rating);
                command.Parameters.AddWithValue("@ReleaseDate", game.ReleaseDate);
                command.Parameters.AddWithValue("@Platform", game.Platform);
                command.Parameters.AddWithValue("@Title", game.Title);
                command.Parameters.AddWithValue("@Description", game.Description);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool EditGame(Game game)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("UPDATE Games SET Title = @Title, GenreID = @GenreID, Rating = @Rating, ReleaseDate = @ReleaseDate, Platform = @Platform, Description = @Description WHERE GameID = @GameID", connection);
                command.Parameters.AddWithValue("@GameID", game.GameID);
                command.Parameters.AddWithValue("@Title", game.Title);
                command.Parameters.AddWithValue("@GenreID", game.GenreID);
                command.Parameters.AddWithValue("@Rating", game.Rating);
                command.Parameters.AddWithValue("@ReleaseDate", game.ReleaseDate);
                command.Parameters.AddWithValue("@Platform", game.Platform);
                command.Parameters.AddWithValue("@Description", game.Description);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("DELETE FROM Games WHERE GameID = @GameID", connection);
                command.Parameters.AddWithValue("@GameID", gameId);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<Review> GetReviewsForGame(int gameId)
        {
            List<Review> reviews = new List<Review>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand(
                    @"SELECT r.*, u.Name AS UserName, g.Title AS GameTitle 
                      FROM Reviews r 
                      JOIN Users u ON r.UserID = u.UserID 
                      JOIN Games g ON r.GameID = g.GameID 
                      WHERE r.GameID = @GameID", connection);
                command.Parameters.AddWithValue("@GameID", gameId);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reviews.Add(new Review
                        {
                            ReviewID = reader.GetInt32("ReviewID"),
                            UserID = reader.GetInt32("UserID"),
                            GameID = reader.GetInt32("GameID"),
                            ReviewText = reader.GetString("ReviewText"),
                            Rating = reader.GetFloat("Rating"),
                            ReviewDate = reader.GetDateTime("ReviewDate"),
                            UserName = reader.GetString("UserName"),
                            GameTitle = reader.GetString("GameTitle")
                        });
                    }
                }
            }
            return reviews;
        }

        public bool AddReview(Review review)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("INSERT INTO Reviews (UserID, GameID, ReviewText, Rating, ReviewDate) VALUES (@UserID, @GameID, @ReviewText, @Rating, @ReviewDate)", connection);
                command.Parameters.AddWithValue("@UserID", review.UserID);
                command.Parameters.AddWithValue("@GameID", review.GameID);
                command.Parameters.AddWithValue("@ReviewText", review.ReviewText);
                command.Parameters.AddWithValue("@Rating", review.Rating);
                command.Parameters.AddWithValue("@ReviewDate", review.ReviewDate);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool AddGenre(string genreName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("INSERT INTO Genres (GenreName) VALUES (@GenreName)", connection);
                command.Parameters.AddWithValue("@GenreName", genreName);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteGenre(int genreId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                OpenConnection(connection);
                MySqlCommand command = new MySqlCommand("DELETE FROM Genres WHERE GenreID = @GenreID", connection);
                command.Parameters.AddWithValue("@GenreID", genreId);

                return command.ExecuteNonQuery() > 0;
            }
        }

    }
}
