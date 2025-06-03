using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class AdminWindow : Window
    {
        private DatabaseService _dbService;

        public AdminWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                    string.IsNullOrWhiteSpace(GenreIDTextBox.Text) ||
                    string.IsNullOrWhiteSpace(RatingTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PlatformTextBox.Text) ||
                    string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                    ReleaseDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                if (int.TryParse(GenreIDTextBox.Text, out int genreId) &&
                    float.TryParse(RatingTextBox.Text, out float rating))
                {
                    Game newGame = new Game
                    {
                        Title = TitleTextBox.Text,
                        GenreID = genreId,
                        Rating = rating,
                        Platform = PlatformTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        ReleaseDate = ReleaseDatePicker.SelectedDate.Value
                    };

                    if (_dbService.AddGame(newGame))
                    {
                        MessageBox.Show("Игра успешно добавлена.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления игры.");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка: проверьте вводимые данные. Убедитесь, что GenreID является числом, а Rating - числом с плавающей запятой.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void EditGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(GameIDTextBox.Text) ||
                    string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                    string.IsNullOrWhiteSpace(GenreIDTextBox.Text) ||
                    string.IsNullOrWhiteSpace(RatingTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PlatformTextBox.Text) ||
                    string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                    ReleaseDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }

                if (int.TryParse(GameIDTextBox.Text, out int gameId) &&
                    int.TryParse(GenreIDTextBox.Text, out int genreId) &&
                    float.TryParse(RatingTextBox.Text, out float rating))
                {
                    Game updatedGame = new Game
                    {
                        GameID = gameId,
                        Title = TitleTextBox.Text,
                        GenreID = genreId,
                        Rating = rating,
                        Platform = PlatformTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        ReleaseDate = ReleaseDatePicker.SelectedDate.Value
                    };

                    if (_dbService.EditGame(updatedGame))
                    {
                        MessageBox.Show("Игра успешно отредактирована.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка редактирования игры.");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка: проверьте вводимые данные. Убедитесь, что ID игры и жанра являются числами, а Rating - числом с плавающей запятой.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }



        private void DeleteGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(GameIDTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите ID игры для удаления.");
                    return;
                }

                if (int.TryParse(GameIDTextBox.Text, out int gameId))
                {
                    if (_dbService.DeleteGame(gameId))
                    {
                        MessageBox.Show("Игра успешно удалена.");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка удаления игры.");
                    }
                }
                else
                {
                    MessageBox.Show("ID игры должен быть числом.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }



        private void AddGenreButton_Click(object sender, RoutedEventArgs e)
        {
            string genreName = GenreNameTextBox.Text;

            if (_dbService.AddGenre(genreName))
            {
                MessageBox.Show("Жанр успешно добавлен.");
            }
            else
            {
                MessageBox.Show("Ошибка добавления жанра.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
