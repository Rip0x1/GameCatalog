using System.Collections.Generic;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class GamesListWindow : Window
    {
        private DatabaseService _dbService;
        private int currentUserId; 

        public GamesListWindow(DatabaseService dbService, int userId)
        {
            InitializeComponent();
            _dbService = dbService;
            currentUserId = userId; 
            LoadGames();
        }

        private void LoadGames()
        {
            List<Game> games = _dbService.GetAllGames();
            GamesListView.ItemsSource = games;
        }

        private void GamesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (GamesListView.SelectedItem is Game selectedGame)
            {
                ReviewsAndRecommendationsWindow reviewsWindow = new ReviewsAndRecommendationsWindow(_dbService, selectedGame.GameID, currentUserId);
                reviewsWindow.ShowDialog();
            }
        }
    }
}
