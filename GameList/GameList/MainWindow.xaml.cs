using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private DatabaseService _dbService;

        public MainWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.UserAuthenticated += OnUserAuthenticated;
            loginWindow.ShowDialog();
        }

        private void OnUserAuthenticated(int userId)
        {
            CurrentUserId = userId;
            LoadGames();
        }

        private void LoadGames()
        {
            if (CurrentUserId <= 0)
            {
                return;
            }

            GamesListWindow gamesListWindow = new GamesListWindow(_dbService, CurrentUserId);
            gamesListWindow.Show();
        }

        private void ShowAllGamesButton_Click(object sender, RoutedEventArgs e)
        {
            LoadGames();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        public int CurrentUserId { get; set; } = -1;
    }
}
