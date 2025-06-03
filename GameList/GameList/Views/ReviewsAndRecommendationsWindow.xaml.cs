using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class ReviewsAndRecommendationsWindow : Window
    {
        private DatabaseService _dbService;
        private int _gameId;
        public int UserID { get; set; } 

        public ReviewsAndRecommendationsWindow(DatabaseService dbService, int gameId, int userId)
        {
            InitializeComponent();
            _dbService = dbService;
            _gameId = gameId;
            UserID = userId; 
            LoadReviews();
        }

        private void LoadReviews()
        {
            List<Review> reviews = _dbService.GetReviewsForGame(_gameId);
            ReviewsListView.ItemsSource = reviews;
        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserID <= 0) 
            {
                StatusTextBlock.Text = "Пожалуйста, войдите в систему, чтобы оставлять отзывы.";
                StatusTextBlock.Visibility = Visibility.Visible; 
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(RatingTextBox.Text) || string.IsNullOrWhiteSpace(ReviewTextBox.Text) || Convert.ToInt32(RatingTextBox.Text) > 5)
                {
                    StatusTextBlock.Text = "Ошибка. Введите корректные данные";
                    StatusTextBlock.Visibility = Visibility.Visible; 
                    return;
                }

                if (int.TryParse(RatingTextBox.Text, out int rating))
                {
                    Review newReview = new Review
                    {
                        UserID = UserID,
                        GameID = _gameId,
                        ReviewText = ReviewTextBox.Text,
                        Rating = rating,
                        ReviewDate = DateTime.Now
                    };

                    if (_dbService.AddReview(newReview))
                    {
                        StatusTextBlock.Text = "Отзыв успешно добавлен.";
                        StatusTextBlock.Visibility = Visibility.Visible; 
                        LoadReviews();
                    }
                    else
                    {
                        StatusTextBlock.Text = "Ошибка добавления отзыва.";
                        StatusTextBlock.Visibility = Visibility.Visible; 
                    }
                }
                else
                {
                    StatusTextBlock.Text = "Ошибка: Рейтинг должен быть целым числом.";
                    StatusTextBlock.Visibility = Visibility.Visible; 
                }
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Ошибка: {ex.Message}";
                StatusTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadReviews(); 
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
